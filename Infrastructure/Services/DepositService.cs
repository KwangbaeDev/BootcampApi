using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;
using Core.Requests.DepositModels;

namespace Infrastructure.Services;

public class DepositService : IDepositService
{
    private readonly IDepositRepository _depositRepository;

    public DepositService(IDepositRepository depositRepository)
    {
        _depositRepository = depositRepository;
    }



    public async Task<DepositDTO> Depositing(CreateDepositModel model)
    {
        return await _depositRepository.Depositing(model);
    }
}
