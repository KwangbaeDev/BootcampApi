namespace Core.Entities;

public class MovementAccount
{
    public int MovementId { get; set; }
    public int AccountId { get; set; }
    public int TransferId { get; set; }
    public Movement Movement { get; set; } = null!;
    public Account Account { get; set; } = null!;
    public Transfer Transfer { get; set; } = null!;
}
