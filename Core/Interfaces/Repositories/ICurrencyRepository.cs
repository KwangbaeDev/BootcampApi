using Core.Models;
using Core.Requests.CurrencyModels;

namespace Core.Interfaces.Repositories;

public interface ICurrencyRepository
{
    Task<CurrencyDTO> Add(CreateCurrencyModel model);
    Task<List<CurrencyDTO>> GetFiltered(FilterCurrencysModel filter);
    Task<CurrencyDTO> GetById(int id);
    Task<List<CurrencyDTO>> GetAll();
    Task<CurrencyDTO> Update(UpdateCurrencyModel model);
    Task<bool> Delete(int id);
}
