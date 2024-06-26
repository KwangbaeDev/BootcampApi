﻿namespace Core.Entities;

public class Currency
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal BuyValue { get; set; }
    public decimal SellValue { get; set; }

    public ICollection<Account> Accounts { get; set; } = new List<Account>();
    public ICollection<CreditCard> CreditCards { get; set; } = new List<CreditCard>();
    public ICollection<ApplicationForm> ApplicationForms { get; set; } = new List<ApplicationForm>();
    public virtual ICollection<Transfer> Transfers { get; set; } = new List<Transfer>();
}
