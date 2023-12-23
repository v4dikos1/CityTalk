using Application.Abstractions;
using Application.BaseModels;
using Application.BaseUsers.Commands;
using Application.BaseUsers.Dtos;
using AutoMapper;
using Domain;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Application.BaseUsers.Handlers;

internal class BaseUserCommandsHandler(ApplicationDbContext dbContext, IMapper mapper,
    IPasswordService passwordService, IVerificationService verificationService, IEmailService emailService, ITokenService tokenService) 
      : IRequestHandler<CreateUserCommand, CreatedOrUpdatedEntityViewModel>,
        IRequestHandler<AuthorizeBaseUserCommand, UserAuthorizationSuccessModel>,
        IRequestHandler<ConfirmEmailCommand, EmptyViewModel>
{
    public async Task<CreatedOrUpdatedEntityViewModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var userExisted = await dbContext.BaseUsers
            .SingleOrDefaultAsync(x => x.Email == request.Body.Email, cancellationToken);
        if (userExisted != null)
        {
            throw new ObjectExistsException(
                $"Пользователь с почтой {request.Body.Email} уже зарегистрирован в системе!");
        }

        var userToCreate = mapper.Map<BaseUser>(request.Body);
        passwordService.CreatePasswordHash(request.Body.Password, out var passwordHash, out var passwordSalt);
        userToCreate.PasswordHash = passwordHash;
        userToCreate.PasswordSalt = passwordSalt;

        var verificationToken = verificationService.CreateVerificationToken();
        userToCreate.VerificationToken = verificationToken;
        await emailService.SendEmailAsync(userToCreate.Email, "Подтвердите почту, перейдя по ссылке: ", verificationToken);

        var createdUser = await dbContext.AddAsync(userToCreate, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreatedOrUpdatedEntityViewModel(createdUser.Entity.Id);
    }

    public async Task<UserAuthorizationSuccessModel> Handle(AuthorizeBaseUserCommand request, CancellationToken cancellationToken)
    {
        var existedUser =
            await dbContext.BaseUsers.SingleOrDefaultAsync(x => x.Email == request.Body.Email, cancellationToken);
        if (existedUser == null || !passwordService.VerifyPasswordHash(request.Body.Password, existedUser.PasswordHash, existedUser.PasswordSalt))
        {
            throw new ObjectNotFoundException(
                $"Пользователь с указанной почтой не найден или пара логин/пароль не совпадают!");
        }
        if (!existedUser.IsEmailConfirmed)
        {
            throw new BusinessLogicException($"Почта не подтверждена!");
        }

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, existedUser.Id.ToString()),
            new Claim(ClaimTypes.Email, existedUser.Email),
            new Claim(ClaimTypes.Name, existedUser.Name),
            new Claim(ClaimTypes.Surname, existedUser.Surname),
            new Claim("Patronymic", existedUser.Patronymic ?? string.Empty)
        };

        var accessToken = tokenService.Create(claims);
        var refreshToken = tokenService.CreateRefreshToken();
        existedUser.RefreshToken = refreshToken;
        existedUser.RefreshTokenExpiryTime = DateTimeOffset.UtcNow.AddDays(7);
        await dbContext.SaveChangesAsync(cancellationToken);

        var result = new UserAuthorizationSuccessModel
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            RefreshTokenExpireIn = existedUser.RefreshTokenExpiryTime.Value
        };
        return result;
    }

    public async Task<EmptyViewModel> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
    {
        var existedUser =
            await dbContext.BaseUsers.SingleOrDefaultAsync(x => x.VerificationToken == request.Code, cancellationToken);
        if (existedUser == null)
        {
            throw new ObjectNotFoundException($"Пользователь с указанным кодом верификации не найден!");
        }

        existedUser.IsEmailConfirmed = true;
        await dbContext.SaveChangesAsync(cancellationToken);

        return new EmptyViewModel
        {
            Message = "Почта успешно подтверждена! Вы можете закрыть это окно."
        };
    }
}