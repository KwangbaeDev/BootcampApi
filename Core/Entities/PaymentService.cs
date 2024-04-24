namespace Core.Entities;

public class PaymentService
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string Concept { get; set; } = string.Empty;
    public DateTime PaymentServiceDateTime { get; set; }
    public int AccountId { get; set; }
    public Account Account { get; set; } = null!;
}
