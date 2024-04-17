namespace Core.Entities;

public class Product
{
    public int Id { get; set; }
    public string? Tipo { get; set; }
    //public int? CurrencyId { get; set; }
    //public Currency Currency { get; set; } = null!;

    public virtual ICollection<Credit> Credits { get; set; } = new List<Credit>();
    public virtual ICollection<Currency> Currencies { get; set; } = new List<Currency>();
    public virtual ICollection<CreditCard> CreditCards { get; set; } = new List<CreditCard>();
    public virtual ICollection<CurrentAccount> CurrentAccounts { get; set; } = new List<CurrentAccount>();
    public virtual ICollection<ProductRequests> ProductRequests { get; set; } = new List<ProductRequests>();
}
