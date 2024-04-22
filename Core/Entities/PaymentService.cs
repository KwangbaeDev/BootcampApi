namespace Core.Entities;

public class PaymentService
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public int MovementId { get; set; }
    public Movement Movement { get; set; } = null!;
}
