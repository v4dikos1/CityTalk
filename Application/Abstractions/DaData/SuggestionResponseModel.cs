using System.Text.Json.Serialization;

namespace Application.Abstractions.DaData;

public class SuggestionResponseModel
{
    [JsonPropertyName("value")]
    public string Value { get; set; }

    [JsonPropertyName("unrestricted_value")]
    public string UnrestrictedValue { get; set; }

    [JsonPropertyName("data")]
    public DataResponseModel Data { get; set; }
}