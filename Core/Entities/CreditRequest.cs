using Core.Constants;

namespace Core.Entities;

public class CreditRequest
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public int Term {  get; set; }
    public DateTime ApplicationDate { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public DateTime? RejectionDate { get; set; }
    public RequestStatus RequestStatus { get; set; } = RequestStatus.Pending;

    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
    public int CurrencyId { get; set; }
    public Currency Currency { get; set; } = null!;
    public ICollection<Credit> Credits { get; set; } = new List<Credit>();

}
