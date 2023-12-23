using Application.Addresses.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Addresses.Queries;

public class SearchAddressBuildingQuery : IRequest<IEnumerable<ViewAddressModel>>
{
    /// <summary>
    ///     Строка запроса
    /// </summary>
    [FromQuery]
    public string Query { get; set; }

    /// <summary>
    ///     Идентификатор ученика
    /// </summary>
    [FromQuery]
    public string StreetFiasId { get; set; }
}