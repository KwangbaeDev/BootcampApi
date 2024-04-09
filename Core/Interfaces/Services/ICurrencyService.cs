using Core.Models;
using Core.Requests;
using System.Threading.Tasks;

namespace Core.Interfaces.Services;

public interface ICurrencyService
{
    Task<List<CurrencyDTO>> GetFiltered(FilterCurrencysModel filter);
    Task<CurrencyDTO> Add(CreateCurrencyModel model);
    Task<List<CurrencyDTO>> GetAll();
    Task<CurrencyDTO> GetById(int id);
    Task<CurrencyDTO> Update(UpdateCurrencyModel model);
    Task<bool> Delete(int id);
}
