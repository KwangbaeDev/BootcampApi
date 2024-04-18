using Core.Models;
using Core.Requests;

namespace Core.Interfaces.Services;

public interface ICreditRequestService
{
    Task<CreditRequestDTO> CreateCreditRequest(CreateCreditRequestModel model);
}
