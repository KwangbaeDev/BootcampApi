using Core.Constants;
using Core.Entities;

namespace Core.Models;

public class AccountDTO
{
    public int Id { get; set; }
    public string Holder { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public AccountType Type { get; set; } = AccountType.Current;
    public decimal Balance { get; set; }
    public String Status { get; set; } = string.Empty;

    public CurrencyDTO Currency { get; set; } = null!;
    public CustomerDTO Customer { get; set; } = null!;
    public SavingAcountDTO? SavingAccount { get; set; }
    public CurrentAccountDTO? CurrentAccount { get; set; }
}
