using Core.Models;
using Core.Requests.CurrencyModels;
using System.Threading.Tasks;

namespace Core.Interfaces.Services;

public interface ICurrencyService
{
    Task<CurrencyDTO> Add(CreateCurrencyModel model);
    Task<List<CurrencyDTO>> GetFiltered(FilterCurrencysModel filter);
    Task<CurrencyDTO> GetById(int id);
    Task<List<CurrencyDTO>> GetAll();
    Task<CurrencyDTO> Update(UpdateCurrencyModel model);
    Task<bool> Delete(int id);
}
