using Core.Constants;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests;
using Infrastructure.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace Infrastructure.Repositories;

public class EnterpriseRepository : IEnterpriseRepository
{
    private readonly BootcampContext _context;

    public EnterpriseRepository(BootcampContext context)
    {
        _context = context;
    }   

    public async Task<EnterpriseDTO> Add(CreateEnterpriseModel model)
    {
        var enterpriseToCreate = model.Adapt<Enterprise>();

        _context.Enterprises.Add(enterpriseToCreate);

        await _context.SaveChangesAsync();

        var enterpriseDTO = enterpriseToCreate.Adapt<EnterpriseDTO>();

        return enterpriseDTO;
    }

    public async Task<bool> Delete(int id)
    {
        var enterprise = await _context.Enterprises.FindAsync(id);

        if (enterprise is null || enterprise.IsDeleted == IsDeleteStatus.True)
        {
            throw new Exception("Enterprise not found.");
        }

        enterprise.IsDeleted = IsDeleteStatus.True;

        var result = await _context.SaveChangesAsync();

        return result > 0;
    }

    public async Task<EnterpriseDTO> GetById(int id)
    {
        var enterprise = await _context.Enterprises.FindAsync(id);

        if (enterprise is null || enterprise.IsDeleted == IsDeleteStatus.True)
        {
            throw new Exception("Enterprise not found");
        }

        var enterpriseDTO = enterprise.Adapt<EnterpriseDTO>();

        return enterpriseDTO;
    }

    public async Task<List<EnterpriseDTO>> GettAll()
    {
        var enterprise = await _context.Enterprises
                                            .Where(x => x.IsDeleted != IsDeleteStatus.True)
                                            .ToListAsync();

        var enterpriseDTO = enterprise.Adapt<List<EnterpriseDTO>>();

        return enterpriseDTO;
    }

    public async Task<EnterpriseDTO> Update(UpdateEnterpriseModel model)
    {
        var enterprise = await _context.Enterprises.FindAsync(model.Id);

        if (enterprise is null || enterprise.IsDeleted == IsDeleteStatus.True)
        {
            throw new Exception("Enterprise was not found.");
        }
        model.Adapt(enterprise);

        _context.Enterprises.Update(enterprise);

        await _context.SaveChangesAsync();

        var enterpriseDTO = enterprise.Adapt<EnterpriseDTO>();

        return enterpriseDTO;
    }
}
