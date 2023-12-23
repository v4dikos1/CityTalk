using System.Text.Json.Serialization;

namespace Application.Abstractions.DaData;

public class QueryBoundModel
{
    [JsonPropertyName("value")]
    public string Value { get; set; }
}