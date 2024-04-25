namespace Core.Entities;

public class Extraction
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime ExtractionDateTime { get; set; }

    public int AccountId { get; set; }
    public Account Account { get; set; } = null!;
    public int BankId { get; set; }
    public Bank Bank { get; set; } = null!;
}
