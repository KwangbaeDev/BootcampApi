using Core.Models;
using Core.Requests.TransferModels;

namespace Core.Interfaces.Services;

public interface ITransferService
{
    Task<TransferDTO> Transferred(CreateTransferModel model);
}
