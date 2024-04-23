﻿using Core.Entities;

namespace Core.Models;

public class ExtractionDTO
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime ExtractionDateTime { get; set; }
    public string Description { get; set; } = string.Empty;
    public int AccountId { get; set; }
    public AccountDTO Account { get; set; } = null!;
    public int BankId { get; set; }
    public BankDTO Bank { get; set; } = null!;
    //public int MovementId { get; set; }
    //public MovementDTO Movement { get; set; } = null!;
}
