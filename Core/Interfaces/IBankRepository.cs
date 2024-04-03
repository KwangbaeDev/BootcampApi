using Core.Models;

namespace Core.Interfaces;

public interface IBankRepository
{
    Task Add(CreateBankModel model);
    Task<BankDTO> GetById(int id);
    //update
    //Delete
    //GetById
    //GetAll
}
