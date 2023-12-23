using Application.Addresses.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Addresses.Queries;

public class SearchAddressRegionQuery : IRequest<IEnumerable<ViewAddressModel>>
{
    /// <summary>
    ///     Строка запроса
    /// </summary>
    [FromQuery]
    public string Query { get; set; }
}