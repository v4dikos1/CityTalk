using Application.Abstractions.DaData;
using Application.Abstractions.Mapping;
using AutoMapper;
using Domain.Entities.Json;

namespace Application.Addresses.Dtos;

/// <summary>
///     Модель адреса
/// </summary>
public class ViewAddressModel : IMapWith<Address>
{
    /// <summary>
    ///     Полное наименование адреса
    /// </summary>
    public string AddressFullName { get; set; }

    /// <summary>
    ///     Регион
    /// </summary>
    public string Region { get; set; }

    /// <summary>
    ///     ФИАС идентификатор региона
    /// </summary>
    public string RegionFiasId { get; set; }

    /// <summary>
    ///     Район в регионе
    /// </summary>
    public string Area { get; set; }

    /// <summary>
    ///     ФИАС идентификатор района
    /// </summary>
    public string AreaFiasId { get; set; }

    /// <summary>
    ///     Город
    /// </summary>
    public string City { get; set; }

    /// <summary>
    ///     ФИАС идентификатор города
    /// </summary>
    public string CityFiasId { get; set; }

    /// <summary>
    ///     Населенный пункт
    /// </summary>
    public string Settlement { get; set; }

    /// <summary>
    ///     ФИАС идентификатор населенного пункта
    /// </summary>
    public string SettlementFiasId { get; set; }

    /// <summary>
    ///     Улица
    /// </summary>
    public string Street { get; set; }

    /// <summary>
    ///     ФИАС идентификатор улицы
    /// </summary>
    public string StreetFiasId { get; set; }

    /// <summary>
    ///     Дом
    /// </summary>
    public string House { get; set; }

    /// <summary>
    ///     ФИАС идентификатор дома
    /// </summary>
    public string HouseFiasId { get; set; }

    /// <summary>
    ///     Идентификатор КЛАДР
    /// </summary>
    public string Kladr { get; set; }

    /// <summary>
    ///     Номер квартиры
    /// </summary>
    public string Apartment { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Address, ViewAddressModel>();
        profile.CreateMap<ViewAddressModel, Address>();
        profile.CreateMap<SuggestionResponseModel, Address>()
            .ForMember(d => d.Area, opt => opt.MapFrom(src => src.Data.Area))
            .ForMember(d => d.City, opt => opt.MapFrom(src => src.Data.City))
            .ForMember(d => d.House, opt => opt.MapFrom(src => src.Data.House))
            .ForMember(d => d.Kladr, opt => opt.MapFrom(src => src.Data.KladrId))
            .ForMember(d => d.Region, opt => opt.MapFrom(src => src.Data.Region))
            .ForMember(d => d.Settlement, opt => opt.MapFrom(src => src.Data.Settlement))
            .ForMember(d => d.Street, opt => opt.MapFrom(src => src.Data.Street))
            .ForMember(d => d.AreaFiasId, opt => opt.MapFrom(src => src.Data.AreaFiasId))
            .ForMember(d => d.CityFiasId, opt => opt.MapFrom(src => src.Data.CityFiasId))
            .ForMember(d => d.RegionFiasId, opt => opt.MapFrom(src => src.Data.RegionFiasId))
            .ForMember(d => d.SettlementFiasId, opt => opt.MapFrom(src => src.Data.SettlementFiasId))
            .ForMember(d => d.StreetFiasId, opt => opt.MapFrom(src => src.Data.StreetFiasId))
            .ForMember(d => d.AddressFullName, opt => opt.MapFrom(src => src.UnrestrictedValue))
            .ForMember(d => d.HouseFiasId, opt => opt.MapFrom(src => src.Data.HouseFiasId));

        profile.CreateMap<SuggestionResponseModel, ViewAddressModel>()
            .ForMember(d => d.Area, opt => opt.MapFrom(src => src.Data.Area))
            .ForMember(d => d.City, opt => opt.MapFrom(src => src.Data.City))
            .ForMember(d => d.House, opt => opt.MapFrom(src => src.Data.House))
            .ForMember(d => d.Kladr, opt => opt.MapFrom(src => src.Data.KladrId))
            .ForMember(d => d.Region, opt => opt.MapFrom(src => src.Data.Region))
            .ForMember(d => d.Settlement, opt => opt.MapFrom(src => src.Data.Settlement))
            .ForMember(d => d.Street, opt => opt.MapFrom(src => src.Data.Street))
            .ForMember(d => d.AreaFiasId, opt => opt.MapFrom(src => src.Data.AreaFiasId))
            .ForMember(d => d.CityFiasId, opt => opt.MapFrom(src => src.Data.CityFiasId))
            .ForMember(d => d.RegionFiasId, opt => opt.MapFrom(src => src.Data.RegionFiasId))
            .ForMember(d => d.SettlementFiasId, opt => opt.MapFrom(src => src.Data.SettlementFiasId))
            .ForMember(d => d.StreetFiasId, opt => opt.MapFrom(src => src.Data.StreetFiasId))
            .ForMember(d => d.AddressFullName, opt => opt.MapFrom(src => src.UnrestrictedValue))
            .ForMember(d => d.HouseFiasId, opt => opt.MapFrom(src => src.Data.HouseFiasId));
    }
}