namespace Core.Requests.PaymentServiceModels;

public class CreatePaymentServiceModel
{
    public string DocumentNumber { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string Concept { get; set; } =string.Empty;
    public int AccountId { get; set; }
}
