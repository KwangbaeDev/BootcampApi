using Core.Entities;

namespace Core.Models;

public class PaymentServiceDTO
{
    public int Id { get; set; }
    public string DocumentNumber { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string Concept { get; set; } = string.Empty;
    public DateTime PaymentServiceDateTime { get; set; }

    public int AccountId { get; set; }
    public AccountDTO Account { get; set; } = null!;
    public int ServiceId { get; set; }
    public ServiceDTO Service { get; set; } = null!;
}
