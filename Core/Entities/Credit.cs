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


    public int CreditRequestId { get; set; }
    public virtual CreditRequest CreditRequest { get; set; } = null!;
    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; } = null!;
    public int CurrencyId { get; set; }
    public virtual Currency Currency { get; set; } = null!;
}
