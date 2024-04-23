namespace Core.Models;

public class DepositDTO
{
    public int Id { get; set; }
    public int MovementId { get; set; }
    public MovementDTO Movement { get; set; } = null!;
}
