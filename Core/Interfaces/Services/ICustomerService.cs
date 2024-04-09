﻿using Core.Models;
using Core.Requests;
using System.Threading.Tasks;

namespace Core.Interfaces.Services;

public interface ICustomerService
{
    Task<List<CustomerDTO>> GetFiltered(FilterCustomersModel filter);
    Task<CustomerDTO> Add(CreateCustomerModel model);
    Task<CustomerDTO> GetById(int id);
    Task<List<CustomerDTO>> GetAll();
    Task<CustomerDTO> Update(UpdateCustomerModel model);
    Task<bool> Delete(int id);
}