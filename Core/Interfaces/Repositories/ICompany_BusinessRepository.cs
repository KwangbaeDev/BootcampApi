﻿using Core.Models;
using Core.Requests;

namespace Core.Interfaces.Repositories;

public interface ICompany_BusinessRepository
{
    Task<Company_BusinessDTO> Add(CreateCompany_BusinessModel model);
    Task<Company_BusinessDTO> GetById(int id);
    Task<List<Company_BusinessDTO>> GettAll();
    Task<Company_BusinessDTO> Update(UpdateCompany_BusinessModel model);
    Task<bool> Delete(int id);
}