using Core.Constants;

namespace Core.Requests.ApplicationFormModels;

public class UpdateApplicationFormModel
{
    public int Id { get; set; }
    public RequestStatus RequestStatus { get; set; } = RequestStatus.Pending;
}
