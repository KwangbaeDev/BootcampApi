using Core.Constants;
using Core.Entities;
using Core.Models;

namespace Core.Requests.CustomerModels;

public class CreateCustomerModel
{
    public string Name { get; set; } = string.Empty;
    public string? Lastname { get; set; }
    public string DocumentNumber { get; set; } = string.Empty;
    public string? Address { get; set; }
    public string? Mail { get; set; }
    public string? Phone { get; set; }
    public int CustomerStatus { get; set; } = 0;
    public DateTime? Birth { get; set; }
    public int BankId { get; set; }
}
