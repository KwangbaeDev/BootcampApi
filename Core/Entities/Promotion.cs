using Core.Models;

namespace Core.Entities;

public class Promotion
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime? DurationTime {  get; set; }
    public decimal? PercentageOff { get; set; }
    public int CompanyBusinessId {  get; set; }
    public Company_Business CompanyBusinesses { get; set; } = null!;
}
