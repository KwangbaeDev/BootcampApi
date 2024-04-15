using Core.Entities;

namespace Core.Models;

public class Company_BusinessDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; } = null;
    //public PromotionDTO? Promotions { get; set; }
}
