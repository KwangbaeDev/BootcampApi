namespace Core.Models;

public class DepositDTO
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime DepositDateTime { get; set; }
    public int AccountId { get; set; }
    public AccountDTO Account { get; set; } = null!;
    public int BankId { get; set; }
    public BankDTO Bank { get; set; } = null!;
    //public int MovementId { get; set; }
    //public MovementDTO Movement { get; set; } = null!;
}
