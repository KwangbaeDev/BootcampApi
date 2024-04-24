using Core.Models;
using Core.Requests.TransactionHistoryModels;

namespace Core.Interfaces.Repositories;

public interface ITransactionHistoryRepository
{
    Task<List<TransactionHistoryDTO>> GetFiltered(FilterTransactionHistoryModel filter);
}
