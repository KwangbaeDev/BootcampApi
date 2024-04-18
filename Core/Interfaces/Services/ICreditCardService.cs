using Core.Models;
using Core.Requests.CreditCardModels;

namespace Core.Interfaces.Services;

public interface ICreditCardService
{
    Task<CreditCardDTO> Add(CreateCreditCardModel model);
    Task<List<CreditCardDTO>> GetFiltered(FilterCreditCardModel filter);
    Task<List<CreditCardDTO>> GetAll();
    Task<CreditCardDTO> GetById(int id);
    Task<CreditCardDTO> Update(UpdateCreditCardModel model);
    Task<bool> Delete(int id);
}
