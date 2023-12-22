using Application.Abstractions;
using Application.BaseModels;
using Application.BaseUsers.Commands;
using AutoMapper;
using Domain;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.BaseUsers.Handlers;

internal class BaseUserCommandsHandler(ApplicationDbContext dbContext, IMapper mapper,
    IPasswordService passwordService, IVerificationService verificationService, IEmailService emailService) 
    : IRequestHandler<CreateUserCommand, CreatedOrUpdatedEntityViewModel>
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
}