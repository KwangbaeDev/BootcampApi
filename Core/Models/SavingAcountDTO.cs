using Core.Constants;
using Core.Entities;
using Core.Requests;

namespace Core.Models;

public class SavingAcountDTO
{
    public int? Id { get; set; }
    public string SavingType { get; set; } = string.Empty;
}
