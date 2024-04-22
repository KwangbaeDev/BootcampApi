using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;
using Core.Requests.TransferModels;

namespace Infrastructure.Services;

public class TransferService : ITransferService
{
    private readonly ITransferRepository _repository;

    public TransferService(ITransferRepository repository)
    {
        _repository = repository;
    }

    public async Task<TransferDTO> Transferred(CreateTransferModel model)
    {
        return await _repository.Transferred(model);
    }
}
