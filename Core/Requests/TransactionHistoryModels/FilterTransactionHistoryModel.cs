namespace Core.Requests.TransactionHistoryModels;

public class FilterTransactionHistoryModel
{
    public string? AccountNumber { get; set; }
    public int? Month {  get; set; }
    public int? DateFrom { get; set; }
    public int? DateTo { get; set; }
    public string? Description { get; set; }
}
