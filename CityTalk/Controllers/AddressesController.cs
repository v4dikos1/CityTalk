using Application.Addresses.Dtos;
using Application.Addresses.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/addresses")]
[Authorize]
public class AddressesController(IMediator mediator) : BaseController
{
    /// <summary>
    ///     Поиск по полному адресу
    /// </summary>
    /// <param name="request">Модель запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    [HttpGet("fullname")]
    public async Task<IEnumerable<ViewAddressModel>> SearchFullName([FromQuery] SearchAddressByFullNameQuery request,
        CancellationToken cancellationToken)
    {
        return await mediator.Send(request, cancellationToken);
    }

    /// <summary>
    ///     Поиск региона
    /// </summary>
    /// <param name="request">Модель запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    [HttpGet("region")]
    public async Task<IEnumerable<ViewAddressModel>> SearchRegion([FromQuery] SearchAddressRegionQuery request,
        CancellationToken cancellationToken)
    {
        return await mediator.Send(request, cancellationToken);
    }

    /// <summary>
    ///     Поиск района в регион
    /// </summary>
    /// <param name="request">Модель запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    [HttpGet("area")]
    public async Task<IEnumerable<ViewAddressModel>> SearchArea([FromQuery] SearchAddressAreaQuery request,
        CancellationToken cancellationToken)
    {
        return await mediator.Send(request, cancellationToken);
    }

    /// <summary>
    ///     Поиск города (Доступно: всем)
    /// </summary>
    /// <param name="request">Модель запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    [HttpGet("city")]
    public async Task<IEnumerable<ViewAddressModel>> SearchCity([FromQuery] SearchAddressCityQuery request,
        CancellationToken cancellationToken)
    {
        return await mediator.Send(request, cancellationToken);
    }

    /// <summary>
    ///     Поиск населенного пункта (Доступно: всем)
    /// </summary>
    /// <param name="request">Модель запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    [HttpGet("settlement")]
    public async Task<IEnumerable<ViewAddressModel>> SearchSettlement([FromQuery] SearchAddressSettlementQuery request,
        CancellationToken cancellationToken)
    {
        return await mediator.Send(request, cancellationToken);
    }

    /// <summary>
    ///     Поиск улицы (Доступно: всем)
    /// </summary>
    /// <param name="request">Модель запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    [HttpGet("street")]
    public async Task<IEnumerable<ViewAddressModel>> SearchStreet([FromQuery] SearchAddressStreetQuery request,
        CancellationToken cancellationToken)
    {
        return await mediator.Send(request, cancellationToken);
    }


    /// <summary>
    ///     Поиск дома (Доступно: всем)
    /// </summary>
    /// <param name="request">Модель запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    [HttpGet("house")]
    public async Task<IEnumerable<ViewAddressModel>> SearchBuilding([FromQuery] SearchAddressBuildingQuery request,
        CancellationToken cancellationToken)
    {
        return await mediator.Send(request, cancellationToken);
    }
}