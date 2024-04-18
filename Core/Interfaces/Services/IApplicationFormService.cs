using Core.Models;
using Core.Requests.ApplicationFormModels;

namespace Core.Interfaces.Services;

public interface IApplicationFormService
{
    Task<ApplicationFormDTO> CreateApplicationForm(CreateApplicationFormModel model);
}
