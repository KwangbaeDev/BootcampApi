using Core.Models;
using Core.Requests.CreditCardModels;

namespace Core.Interfaces.Repositories;

public interface ICreditCardRepository
{
    Task<CreditCardDTO> Add(CreateCreditCardModel model);
    Task<List<CreditCardDTO>> GetFiltered(FilterCreditCardModel filter);
    Task<CreditCardDTO> GetById(int id);
    Task<List<CreditCardDTO>> GetAll();
    Task<CreditCardDTO> Update(UpdateCreditCardModel model);
    Task<bool> Delete(int id);
}
