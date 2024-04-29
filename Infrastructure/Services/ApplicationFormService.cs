using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;
using Core.Requests.ApplicationFormModels;

namespace Infrastructure.Services;

public class ApplicationFormService : IApplicationFormService
{
    private readonly IApplicationFormRepository _applicationRepository;

    public ApplicationFormService(IApplicationFormRepository applicationRepository)
    {
        _applicationRepository = applicationRepository;
    }


    public async Task<ApplicationFormDTO> CreateApplicationForm(CreateApplicationFormModel model)
    {
        return await _applicationRepository.CreateApplicationForm(model);
    }



    public async Task<ApplicationFormDTO> Update(UpdateApplicationFormModel model)
    {
        return await _applicationRepository.Update(model);
    }
}
