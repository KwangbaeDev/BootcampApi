﻿using Core.Models;
using Core.Requests.AccountModels;

namespace Core.Interfaces.Repositories;

public interface IAccountRepository
{
    Task<AccountDTO> Add(CreateAccountModel model);
    Task<List<AccountDTO>> GetFiltered(FilterAccountModel filter);
    Task<AccountDTO> GetById(int id);
    Task<List<AccountDTO>> GettAll();
    Task<AccountDTO> Update(UpdateAccountModel model);
    Task<bool> Delete(int id);
}
