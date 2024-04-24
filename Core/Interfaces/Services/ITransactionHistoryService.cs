using Core.Models;
using Core.Requests.TransactionHistoryModels;

namespace Core.Interfaces.Services;

public  interface ITransactionHistoryService
{
    Task<List<TransactionHistoryDTO>> GetFiltered(FilterTransactionHistoryModel filter);
}
