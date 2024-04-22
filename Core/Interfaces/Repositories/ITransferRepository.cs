using Core.Models;
using Core.Requests.TransferModels;

namespace Core.Interfaces.Repositories;

public interface ITransferRepository
{
    Task<TransferDTO> Transferred(CreateTransferModel model);
}
