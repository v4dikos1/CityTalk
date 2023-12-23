using Application.Addresses.Dtos;
using MediatR;

namespace Application.Addresses.Queries;

public class SearchAddressByFullNameQuery : IRequest<IEnumerable<ViewAddressModel>>
{
    public string Query { get; set; }
}