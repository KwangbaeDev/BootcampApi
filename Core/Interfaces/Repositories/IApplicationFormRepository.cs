using Core.Models;
using Core.Requests.ApplicationFormModels;

namespace Core.Interfaces.Repositories;

public interface IApplicationFormRepository
{
    Task<ApplicationFormDTO> CreateApplicationForm(CreateApplicationFormModel model);
}
