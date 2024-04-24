using Core.Constants;

namespace Core.Models;

public class TransferDTO
{
    public int Id { get; set; }
    public TransferType TransferType { get; set; }
    public int OriginAccountId { get; set; }
    public AccountDTO OriginAccount { get; set; } = null!;
    public int DestinationBankId { get; set; }
    public BankDTO Bank { get; set; } =null!;
    public int CurrencyId { get; set; }
    public CurrencyDTO Currency { get; set; } = null!;
    public decimal Amount { get; set; }
    public DateTime TransferredDateTime { get; set; }
    public string Concept {  get; set; } = string.Empty;
    public int DestinationAccountId { get; set; }
    public AccountDTO DestinationAccount { get; set; } = null!;
}
