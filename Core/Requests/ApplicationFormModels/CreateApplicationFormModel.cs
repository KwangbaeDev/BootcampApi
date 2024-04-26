using Core.Constants;
using Core.Models;

namespace Core.Requests.ApplicationFormModels;

public class CreateApplicationFormModel
{
    public string Name { get; set; } = string.Empty;
    public string? Lastname { get; set; }
    public string DocumentNumber { get; set; } = string.Empty;
    public string? Address { get; set; }
    public string? Mail { get; set; }
    public string? Phone { get; set; }
    public int CurrencyId { get; set; }
    public int ProductId { get; set; }
    public string? Description { get; set; }
}
