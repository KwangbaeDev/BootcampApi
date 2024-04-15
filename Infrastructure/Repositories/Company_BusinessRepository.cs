using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests;
using Infrastructure.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class Company_BusinessRepository : ICompany_BusinessRepository
{
    private readonly BootcampContext _context;

    public Company_BusinessRepository(BootcampContext context)
    {
        _context = context;
    }   

    public async Task<Company_BusinessDTO> Add(CreateCompany_BusinessModel model)
    {
        var companyBusinessToCreate = model.Adapt<Company_Business>();

        _context.CompanyBusinesses.Add(companyBusinessToCreate);

        await _context.SaveChangesAsync();

        var companyBusinessDTO = companyBusinessToCreate.Adapt<Company_BusinessDTO>();

        return companyBusinessDTO;
    }

    public async Task<bool> Delete(int id)
    {
        var companyBusiness = await _context.CompanyBusinesses.FindAsync(id);

        if (companyBusiness is null) throw new Exception("CompanyBusiness not found.");

        _context.CompanyBusinesses.Remove(companyBusiness);

        var result = await _context.SaveChangesAsync();

        return result > 0;
    }

    public async Task<Company_BusinessDTO> GetById(int id)
    {
        var companyBusiness = await _context.CompanyBusinesses.FindAsync(id);

        if (companyBusiness is null) throw new Exception("CompanyBusiness not found");

        var companyBusinessDTO = companyBusiness.Adapt<Company_BusinessDTO>();

        return companyBusinessDTO;
    }

    public async Task<List<Company_BusinessDTO>> GettAll()
    {
        var companyBusiness = await _context.CompanyBusinesses.ToListAsync();

        var companyBusinessDTO = companyBusiness.Adapt<List<Company_BusinessDTO>>();

        return companyBusinessDTO;
    }

    public async Task<Company_BusinessDTO> Update(UpdateCompany_BusinessModel model)
    {
        var companyBusiness = await _context.CompanyBusinesses.FindAsync(model.Id);

        if (companyBusiness is null) throw new Exception("CompanyBusiness was not found.");

        model.Adapt(companyBusiness);

        _context.CompanyBusinesses.Update(companyBusiness);

        await _context.SaveChangesAsync();

        var companyBusinessDTO = companyBusiness.Adapt<Company_BusinessDTO>();

        return companyBusinessDTO;
    }
}
