﻿namespace Core.Requests.CurrentAccountModels;

public class CreateCurrentAccountModel
{
    public decimal? OperationalLimit { get; set; }
    public decimal? MonthAverage { get; set; }
    public decimal? Interest { get; set; }
}