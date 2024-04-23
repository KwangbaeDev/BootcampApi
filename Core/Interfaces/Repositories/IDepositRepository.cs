using Core.Models;
using Core.Requests.DepositModels;

namespace Core.Interfaces.Repositories;

public interface IDepositRepository
{
    Task<DepositDTO> Depositing(CreateDepositModel model);
}
