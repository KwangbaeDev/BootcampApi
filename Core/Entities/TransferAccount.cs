namespace Core.Entities;

public class TransferAccount
{
    public int TransferId { get; set; }
    public int AccountId { get; set; }
    public Transfer Transfer { get; set; } = null!;
    public Account Account { get; set; } = null!;
}
