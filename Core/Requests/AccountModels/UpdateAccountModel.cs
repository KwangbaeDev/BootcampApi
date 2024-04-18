﻿using Core.Constants;

namespace Core.Requests.AccountModels;

public class UpdateAccountModel
{
    public int Id { get; set; }
    public string Holder { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public decimal Balance { get; set; }
    public int Status { get; set; } = 0;
    public int CurrencyId { get; set; }
    public int CustomerId { get; set; }

}
