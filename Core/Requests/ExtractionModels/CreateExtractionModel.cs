namespace Core.Requests.ExtractionModels;

public class CreateExtractionModel
{
    public int AccountId { get; set; }
    public int BankID { get; set; }
    public decimal Amount { get; set; }
}
