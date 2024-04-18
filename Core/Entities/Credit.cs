using Core.Constants;

namespace Core.Entities;

public class Credit
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public int Term { get; set; }
    public decimal PendingAmount { get; set; }
    public int PendingFee { get; set; }
    public CreditStatus CreditStatus { get; set; }
}
