namespace Core.Models;

public class TransactionHistoryDTO
{
    public int? Id { get; set; }
    public string? Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime TransactionDateTime { get; set; }
    public string Concept { get; set; } = string.Empty;
    public int? CurrencyId { get; set; }
    public int? AccountId { get; set; }
}
