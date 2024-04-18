using Core.Models;

namespace Core.Requests;

public class CreateCreditRequestModel
{
    public string Name { get; set; } = string.Empty;
    public string? Lastname { get; set; }
    public string DocumentNumber { get; set; } = string.Empty;
    public string? Address { get; set; }
    public string? Mail { get; set; }
    public string? Phone { get; set; }
    public decimal Amount { get; set; }
    public int Term { get; set; }
    public DateTime ApplicationDate { get; set; } = DateTime.Now;

    public int CustomerId { get; set; }
    public int CurrencyId { get; set; }
}
