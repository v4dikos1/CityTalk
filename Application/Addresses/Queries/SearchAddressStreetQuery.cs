using Application.Addresses.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Addresses.Queries;

public class SearchAddressStreetQuery : IRequest<IEnumerable<ViewAddressModel>>
{
    /// <summary>
    ///     Строка запроса
    /// </summary>
    [FromQuery]
    public string Query { get; set; }

    /// <summary>
    ///     Идентфикатор города
    /// </summary>
    [FromQuery]
    public string CityFiasId { get; set; }

    /// <summary>
    ///     Идентификатор поселения
    /// </summary>
    [FromQuery]
    public string SettlementFiasId { get; set; }
}