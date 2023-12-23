using Application.Addresses.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Addresses.Queries;

public class SearchAddressSettlementQuery : IRequest<IEnumerable<ViewAddressModel>>
{
    /// <summary>
    ///     Строка запроса
    /// </summary>
    [FromQuery]
    public string Query { get; set; }

    /// <summary>
    ///     Идентификатор области
    /// </summary>
    [FromQuery]
    public string AreaFiasId { get; set; }

    /// <summary>
    ///     Идентификатор города
    /// </summary>
    [FromQuery]
    public string CityFiasId { get; set; }
}