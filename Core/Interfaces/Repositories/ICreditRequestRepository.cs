using Core.Models;
using Core.Requests;

namespace Core.Interfaces.Repositories;

public interface ICreditRequestRepository
{
    Task<CreditRequestDTO> CreateCreditRequest(CreateCreditRequestModel model);
}
