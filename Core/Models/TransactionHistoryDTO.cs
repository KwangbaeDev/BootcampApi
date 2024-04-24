namespace Core.Models;

public class TransactionHistoryDTO
{
    //public AccountDTO Account { get; set; }
    //public TransferDTO Transfer { get; set; }
    //public PaymentServiceDTO Payment { get; set; }
    //public DepositDTO Deposit { get; set; }
    //public ExtractionDTO Extraction { get; set; }
    public int Id { get; set; }
    public string TransactionType { get; set; }
    public decimal Amount { get; set; }
    public DateTime TransactionDateTime { get; set; }
    public string AccountNumber { get; set; }
    public string? BankName { get; set; }
    public string? Description { get; set; }
}
