using Core.Entities;

namespace Core.Models;

public class ExtractionDTO
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime ExtractionDateTime { get; set; }

    public int AccountId { get; set; }
    public AccountDTO Account { get; set; } = null!;
    public int BankId { get; set; }
    public BankDTO Bank { get; set; } = null!;
}
