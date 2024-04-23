namespace Core.Requests.DepositModels;

public class CreateDepositModel
{
    public int AccountId { get; set; }
    public int BankId { get; set; }
    public decimal Amount { get; set; }
}
