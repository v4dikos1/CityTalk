namespace Domain.Entities.Json;

public class Address
{
    public string Region { get; set; }
    public string RegionFiasId { get; set; }
    public string Area { get; set; }
    public string AreaFiasId { get; set; }
    public string City { get; set; }
    public string CityFiasId { get; set; }
    public string Settlement { get; set; }
    public string SettlementFiasId { get; set; }
    public string Street { get; set; }
    public string StreetFiasId { get; set; }
    public string House { get; set; }
    public string HouseFiasId { get; set; }
    public string Apartment { get; set; }
    public string AddressFullName { get; set; }
}