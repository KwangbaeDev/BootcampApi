using Core.Constants;

namespace Core.Models;

public class TransferDTO
{
    public int Id { get; set; }
    public TransferType TransferType { get; set; }
    public int OriginAccountId { get; set; }
    public int MovementId { get; set; }
    public MovementDTO Movement { get; set; } = null!;
    //public AccountDTO OriginAccount { get; set; } = null!;
    //public int DenstinationBankId { get; set; }
    //public BankDTO Bank { get; set; } = null!;
    //public string AccountNumber { get; set; } = string.Empty;
    //public string DocumentNumber { get; set; } = string.Empty;
    //public int CurrencyId { get; set; }
    //public CurrencyDTO Currency { get; set; } = null!;
    //public decimal Amount { get; set; }
    public int DestinationAccountId { get; set; }
    public AccountDTO DestiationAccount { get; set; } = null!;
}
