using Core.Constants;

namespace Core.Entities;

public class ApplicationForm
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Lastname { get; set; }
    public string DocumentNumber { get; set; } = string.Empty;
    public string? Address { get; set; }
    public string? Mail { get; set; }
    public string? Phone { get; set; }
    public string? Descripcion { get; set; }
    public DateTime ApplicationDate { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public DateTime? RejectionDate { get; set; }
    public RequestStatus RequestStatus { get; set; } = RequestStatus.Pending;

    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
    public int CurrencyId { get; set; }
    public Currency Currency { get; set; } = null!;
    public Product Product { get; set; } = null!;
}
