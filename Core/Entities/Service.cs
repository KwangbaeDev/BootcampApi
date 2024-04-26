namespace Core.Entities;

public class Service
{
    public int Id { get; set; }
    public string? Name { get; set; } = null!;

    public virtual ICollection<PaymentService> PaymentServices { get; set; } = new List<PaymentService>();
}
