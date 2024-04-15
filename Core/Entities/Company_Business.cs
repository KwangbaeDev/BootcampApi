namespace Core.Entities;

public class Company_Business
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; } = null;
    public virtual ICollection<Promotion> Promotions { get; set; } = new List<Promotion>();
}
