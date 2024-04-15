using Core.Constants;

namespace Core.Entities;

public class SavingAccount
{
    public int Id { get; set; }
    public SavingType SavingType { get; set; } = SavingType.Insight;
    public string HolderName { get; set; } = string.Empty;
    public int AccountId { get; set; }
    public Account Account { get; set; } = null!;
}
