using Application.Abstractions.DaData;
using System.Text.Json.Serialization;

namespace Infrastructure.Services.DaData;

public class AddressResponseModel
{
    [JsonPropertyName("suggestions")]
    public IEnumerable<SuggestionResponseModel> Suggestions { get; set; }
}