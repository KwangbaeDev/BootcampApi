using Core.Models;
using Core.Requests.BankModels;

namespace Core.Interfaces.Repositories;

public interface IBankRepository
{
    Task<BankDTO> Add(CreateBankModel model);
    Task<BankDTO> GetById(int id);
    Task<List<BankDTO>> GetAll();
    Task<BankDTO> Update(UpdateBankModel model);
    Task<bool> Delete(int id);
    Task<bool> NameIsAlreadyTaken(string name);
}
