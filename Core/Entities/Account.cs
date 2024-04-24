using Core.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Account
{
    public int Id { get; set; }
    public string Holder { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public AccountType Type { get; set; } = AccountType.Current;
    public decimal Balance { get; set; }
    public AccountStatus Status { get; set; } = AccountStatus.Active;
    public IsDeleteStatus IsDeleted { get; set; } = IsDeleteStatus.False;

    public int CurrencyId { get; set; }
    public Currency Currency { get; set; } = null!;  
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
    public SavingAccount? SavingAccount { get; set; }
    public CurrentAccount? CurrentAccount { get; set; }

    //public virtual ICollection<Movement> Movements { get; set; } = new List<Movement>();
    public virtual ICollection<Transfer> Transfers { get; set; } = new List<Transfer>();
    public virtual ICollection<PaymentService> PaymentServices { get; set; } = new List<PaymentService>();
    public virtual ICollection<Deposit> Deposits { get; set; } = new List<Deposit>();
    public virtual ICollection<Extraction> Extractions { get; set; } = new List<Extraction>();
}
