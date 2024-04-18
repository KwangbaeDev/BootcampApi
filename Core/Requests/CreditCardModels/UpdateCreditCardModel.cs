using Core.Constants;

namespace Core.Requests.CreditCardModels;

public class UpdateCreditCardModel
{
    public int Id { get; set; }
    public string? Designation { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    public string? CardNumber { get; set; }
    public int CVV { get; set; }
    public int CreditCardStatus { get; set; } = 0;
    public decimal CreditLimit { get; set; }
    public decimal AvailableCredit { get; set; }
    public decimal CurrentDebt { get; set; }
    public decimal InterestRate { get; set; }
    public int CustomerId { get; set; }
    public int CurrencyId { get; set; }
}
