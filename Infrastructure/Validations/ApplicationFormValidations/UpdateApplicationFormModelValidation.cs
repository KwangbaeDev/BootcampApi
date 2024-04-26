using Core.Requests.ApplicationFormModels;
using FluentValidation;
using Core.Constants;

namespace Infrastructure.Validations.ApplicationFormValidations;

public class UpdateApplicationFormModelValidation : AbstractValidator<UpdateApplicationFormModel>
{
    public UpdateApplicationFormModelValidation()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required");

        List<RequestStatus> validValues = new List<RequestStatus>() { RequestStatus.Approved, RequestStatus.Rejected };
        RuleFor(x => x.RequestStatus)
            .NotEmpty()
            .WithMessage("RequestStatus is required")
            .NotEqual(RequestStatus.Pending)
            .WithMessage("Cannot use value 0 in this field")
            .Must(x => validValues.Contains(x)).WithMessage("It should only have the values ​​'1 --> Approved' | '2 --> Rejected'.");
    }
}
