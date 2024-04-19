using Core.Constants;
using Core.Models;
using Core.Requests.ProductModels;

namespace Core.Requests.ApplicationFormModels;

public class CreateApplicationFormModel
{
    public string Name { get; set; } = string.Empty;
    public string? Lastname { get; set; }
    public string DocumentNumber { get; set; } = string.Empty;
    public string? Address { get; set; }
    public string? Mail { get; set; }
    public string? Phone { get; set; }
    public int CustomerId { get; set; }
    public int CurrencyId { get; set; }
    public CreateProductModel? Product { get; set; }
    public string? Descripcion { get; set; }
    public DateTime ApplicationDate { get; set; } = DateTime.Now;
    public RequestStatus RequestStatus { get; set; } = RequestStatus.Pending;

    

}
