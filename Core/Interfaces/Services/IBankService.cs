﻿using Core.Models;
using Core.Requests.BankModels;
using System.Threading.Tasks;

namespace Core.Interfaces.Services;

public interface IBankService
{
    Task<BankDTO> Add(CreateBankModel model);
    Task<BankDTO> GetById(int id);
    Task<List<BankDTO>> GetAll();
    Task<BankDTO> Update(UpdateBankModel model);
    Task<bool> Delete(int id);
}
