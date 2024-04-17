using Core.Constants;
using Core.Models;

namespace Core.Entities;

public class Promotion
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime? Start { get; set; }
    public DateTime? End { get; set; }
    public int Discount { get; set; }

    public IsDeleteStatus IsDeleted { get; set; } = IsDeleteStatus.False;
    public ICollection<PromotionEnterprise> PromotionsEnterprises { get; set; } = new List<PromotionEnterprise>();
}
