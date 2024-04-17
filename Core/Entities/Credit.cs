namespace Core.Entities;

public class Credit
{
    public int Id { get; set; }
    public int? CreditAmount { get; set; }
    public string? PreferredTerm { get; set; }
    public int ProducId { get; set; }
    public virtual Product Product { get; set; } = null!;
}
