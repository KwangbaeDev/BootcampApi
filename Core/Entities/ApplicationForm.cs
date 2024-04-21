using Core.Constants;

namespace Core.Entities;

public class ApplicationForm
{
    public int Id { get; set; }
    public string? Descripcion { get; set; }
    public DateTime ApplicationDate { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public DateTime? RejectionDate { get; set; }
    public RequestStatus RequestStatus { get; set; } = RequestStatus.Pending;

    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
    public int CurrencyId { get; set; }
    public Currency Currency { get; set; } = null!;
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
}
