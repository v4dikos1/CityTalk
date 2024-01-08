namespace Application.Events.Dtos;

public class OpenLayersViewModel
{
    public required string Type { get; set; }
    public List<Feature> Features { get; set; } = null!;
}

public class Feature
{
    public required string Type { get; set; }
    public Geometry Geometry { get; set; } = null!;
    public Dictionary<string, object> Properties { get; set; } = null!;
}

public class Geometry
{
    public string Type { get; set; } = null!;
    public required List<double> Coordinates { get; set; }
}