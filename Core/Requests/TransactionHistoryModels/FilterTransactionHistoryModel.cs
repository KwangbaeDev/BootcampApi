using Core.Constants;

namespace Core.Requests.TransactionHistoryModels;

public class FilterTransactionHistoryModel
{
    public int? AccountId { get; set; }
    public int? Month { get; set; }
    public int? Year { get; set; }
    public DateTime? DateFrom { get; set; }
    public DateTime? DateTo { get; set; }
    public TransactionHistoryConcept Concept { get; set; } = TransactionHistoryConcept.All;
}
