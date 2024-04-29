using Core.Constants;

namespace Core.Models;

public class CreditCardDTO
{
    public int Id { get; set; }
    public string? Designation { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    public int CardNumber { get; set; }
    public int CVV { get; set; }
    public int CreditCardStatus { get; set; } = 0;
    public decimal CreditLimit { get; set; }
    public decimal AvailableCredit { get; set; }
    public decimal CurrentDebt { get; set; }
    public decimal InterestRate { get; set; }
    public string RestrictedCreditCard {  get; set; } = string.Empty;

    public CustomerDTO Customer { get; set; } = null!;
    public CurrencyDTO Currency { get; set; } = null!;
}
