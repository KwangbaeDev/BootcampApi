using Core.Constants;
using Core.Entities;

namespace Core.Models;

public class ApplicationFormDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Lastname { get; set; }
    public string DocumentNumber { get; set; } = string.Empty;
    public string? Address { get; set; }
    public string? Mail { get; set; }
    public string? Phone { get; set; }
    public string? Descripcion { get; set; }
    public DateTime ApplicationDate { get; set; } = DateTime.Now;
    public DateTime? ApprovalDate { get; set; } /*= DateTime.Now;*/
    public DateTime? RejectionDate { get; set; } /*= DateTime.Now;*/
    public RequestStatus RequestStatus { get; set; } = RequestStatus.Pending;

    public CustomerDTO Customer { get; set; } = null!;
    public CurrencyDTO Currency { get; set; } = null!;
    public ProductDTO Product { get; set; } = null!;
}
