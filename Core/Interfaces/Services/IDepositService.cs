using Core.Models;
using Core.Requests.DepositModels;

namespace Core.Interfaces.Services;

public interface IDepositService
{
    Task<DepositDTO> Depositing(CreateDepositModel model);
}
