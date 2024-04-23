using Core.Constants;

namespace Core.Entities;

public class Movement
{
    public int Id { get; set; }
    public string Destination { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime? TransferredDateTime { get; set; }
    public TransferStatus TransferStatus { get; set; } = TransferStatus.Pending;
    public MovementType MovementType { get; set; }

    public int AccountId { get; set; }
    public Account Account { get; set; } = null!;


    public virtual ICollection<PaymentService> PaymentServices { get; set; } = new List<PaymentService>();

    public virtual ICollection<Deposit> Deposits { get; set; } = new List<Deposit>();
}
