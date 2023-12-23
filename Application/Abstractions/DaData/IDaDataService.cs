namespace Application.Abstractions.DaData;

public interface IDaDataService
{
    Task<IEnumerable<SuggestionResponseModel>> GetListSuggestionAddressByQuery(AddressQueryModel queryModel);
    Task<SuggestionResponseModel> GetAddressByHouseFiasId(string fiasHouseId);
}