using Core.Constants;
using Core.Entities;
using Core.Models;
using Core.Requests.CurrentAccountModels;
using Core.Requests.SavingAccountModels;

namespace Core.Requests.AccountModels;

public class CreateAccountModel
{
    public string Holder { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public AccountType Type { get; set; }
    public int CurrencyId { get; set; }
    public int CustomerId { get; set; }
    public CreateSavingAccountModel? CreateSavingAccount { get; set; }
    public CreateCurrentAccountModel? CreateCurrentAccount { get; set; }
}
