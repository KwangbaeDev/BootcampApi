using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;
using Core.Requests;

namespace Infrastructure.Services;

public class Company_BusinessService : ICompany_BusinessService
{
    private readonly ICompany_BusinessRepository _companyRepository;

    public Company_BusinessService(ICompany_BusinessRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    public async Task<Company_BusinessDTO> Add(CreateCompany_BusinessModel model)
    {
        return await _companyRepository.Add(model);
    }

    public async Task<bool> Delete(int id)
    {
        return await _companyRepository.Delete(id);
    }

    public async Task<Company_BusinessDTO> GetById(int id)
    {
        return await _companyRepository.GetById(id);
    }

    public async Task<List<Company_BusinessDTO>> GettAll()
    {
        return await _companyRepository.GettAll();
    }

    public async Task<Company_BusinessDTO> Update(UpdateCompany_BusinessModel model)
    {
        return await _companyRepository.Update(model);
    }
}
