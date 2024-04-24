using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;
using Core.Requests.TransactionHistoryModels;

namespace Infrastructure.Services;

public class TransactionHistoryService : ITransactionHistoryService
{
    private readonly ITransactionHistoryRepository _transactionHistoryRepository;

    public TransactionHistoryService(ITransactionHistoryRepository transactionHistoryRepository)
    {
        _transactionHistoryRepository = transactionHistoryRepository;
    }

    public async Task<List<TransactionHistoryDTO>> GetFiltered(FilterTransactionHistoryModel filter)
    {
        return await _transactionHistoryRepository.GetFiltered(filter);
    }
}
