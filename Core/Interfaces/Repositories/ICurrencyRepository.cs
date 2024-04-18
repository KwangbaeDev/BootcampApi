using Core.Models;
using Core.Requests.CurrencyModels;

namespace Core.Interfaces.Repositories;

public interface ICurrencyRepository
{
    Task<List<CurrencyDTO>> GetFiltered(FilterCurrencysModel filter);
    Task<CurrencyDTO> Add(CreateCurrencyModel model);
    Task<List<CurrencyDTO>> GetAll();
    Task<CurrencyDTO> GetById(int id);
    Task<CurrencyDTO> Update(UpdateCurrencyModel model);
    Task<bool> Delete(int id);
}
