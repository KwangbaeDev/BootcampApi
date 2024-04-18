using Core.Constants;

namespace Core.Entities;

public class CreditCard
{
    public int Id { get; set; }
    public string? Designation { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime ExpirationDate {  get; set; }
    public string? CardNumber { get; set; }
    public int CVV {  get; set; }
    public CreditCardStatus CreditCardStatus { get; set; } = CreditCardStatus.Enabled;
    public decimal CreditLimit { get; set; }
    public decimal AvailableCredit { get; set; }
    public decimal CurrentDebt { get; set; }
    public decimal InterestRate { get; set; }
    public int CustomerId { get; set; }
    public int CurrencyId { get; set; }
    public virtual Customer Customer { get; set; } = null!;
    public virtual Currency Currency { get; set; } = null!;


}
