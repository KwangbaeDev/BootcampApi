namespace Core.Requests;

public class FilterPromotionModel
{
    public string Name { get; set; } = string.Empty;
    public int? PromotionTimeFrom { get; set; }
    public int? PromotionTimeTo { get; set; }
    public int? Discount { get; set; }
    //public decimal? PercentageOff { get; set; }
}
