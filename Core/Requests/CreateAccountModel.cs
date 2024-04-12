using Core.Constants;
using Core.Entities;

namespace Core.Requests;

public class CreateAccountModel
{
    public string Holder { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public int Type { get; set; } = 0;
    public int CurrencyId { get; set; }
    public int CustomerId { get; set; }
}
