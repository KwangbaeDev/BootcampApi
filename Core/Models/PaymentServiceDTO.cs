namespace Core.Models;

public class PaymentServiceDTO
{
    public int Id { get; set; }
    public string DocumentNumber { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string Description { get; set; } = string.Empty;
    public int AccountId { get; set; }
    public AccountDTO Account { get; set; } = null!;
}
