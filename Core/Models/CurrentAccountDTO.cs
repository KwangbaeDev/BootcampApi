﻿using Core.Entities;
using Core.Requests;

namespace Core.Models;

public class CurrentAccountDTO
{
    public int? Id { get; set; }
    public decimal? OperationalLimit { get; set; }
    public decimal? MonthAverage { get; set; }
    public decimal? Interest { get; set; }
}
