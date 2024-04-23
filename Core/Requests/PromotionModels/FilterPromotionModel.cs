namespace Core.Requests.PromotionModels;

public class FilterPromotionModel
{
    public string Name { get; set; } = string.Empty;
    public int? PromotionTimeFrom { get; set; }
    public int? PromotionTimeTo { get; set; }
    public int? Discount { get; set; }
}
