namespace Core.Models;

public class PaymentServiceDTO
{
    public int Id { get; set; }
    public string DocumentNumber { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string Description { get; set; } = string.Empty;
    public int MovementId { get; set; }
    public MovementDTO Movement { get; set; } = null!;
}
