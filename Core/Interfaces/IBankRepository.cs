using Core.Models;

namespace Core.Interfaces;

public interface IBankRepository
{
    Task<BankDTO> Add(CreateBankModel model);
    Task<BankDTO> GetById(int id);
    Task<BankDTO> Update(UpdateBankModel model);
    Task<bool> Delete(int id);
    Task<List<BankDTO>> GetAll();
}
