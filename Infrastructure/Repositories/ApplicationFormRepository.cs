using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests.ApplicationFormModels;
using Infrastructure.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ApplicationFormRepository : IApplicationFormRepository
{
    private readonly BootcampContext _context;

    public ApplicationFormRepository(BootcampContext context)
    {
        _context = context;
    }

    public async Task<ApplicationFormDTO> CreateApplicationForm(CreateApplicationFormModel model)
    {
        var applicationForm = model.Adapt<ApplicationForm>();

        

        _context.ApplicationForms.Add(applicationForm);

        await _context.SaveChangesAsync();

        var createApplicationForm = await _context.ApplicationForms
            .Include(af => af.Customer)
            .ThenInclude(c => c.DocumentNumber == c.DocumentNumber)
            .Include(af => af.Currency)
            .Include(af => af.Product)
            .FirstOrDefaultAsync(af => af.Id == applicationForm.Id);

        return createApplicationForm.Adapt<ApplicationFormDTO>();
    }
}
