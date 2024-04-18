using Core.Constants;
using Core.Entities;

namespace Core.Models;

public class CreditRequestDTO
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public int Term { get; set; }
    public DateTime ApplicationDate { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public DateTime? RejectionDate { get; set; }
    public RequestStatus RequestStatus { get; set; } = RequestStatus.Pending;

    public CustomerDTO Customer { get; set; } = null!;
    public CurrencyDTO Currency { get; set; } = null!;

}
