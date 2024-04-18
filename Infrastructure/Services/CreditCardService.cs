using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;
using Core.Requests.CreditCardModels;

namespace Infrastructure.Services;

public class CreditCardService : ICreditCardService
{
    private readonly ICreditCardRepository _repository;

    public CreditCardService(ICreditCardRepository repository)
    {
        _repository = repository;
    }

    public async Task<CreditCardDTO> Add(CreateCreditCardModel model)
    {
        return await _repository.Add(model);
    }

    public async Task<bool> Delete(int id)
    {
        return await _repository.Delete(id);
    }

    public async Task<List<CreditCardDTO>> GetAll()
    {
        return await _repository.GetAll();
    }

    public async Task<CreditCardDTO> GetById(int id)
    {
        return await _repository.GetById(id);
    }

    public async Task<List<CreditCardDTO>> GetFiltered(FilterCreditCardModel filter)
    {
        return await _repository.GetFiltered(filter);
    }

    public async Task<CreditCardDTO> Update(UpdateCreditCardModel model)
    {
        return await _repository.Update(model);
    }
}
