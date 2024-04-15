namespace Core.Requests;

public class FilterPromotionModel
{
    public string Name { get; set; } = string.Empty;
    public int? DurationTimeFrom { get; set; }
    public int? DurationTimeTo { get; set; }
    public decimal? PercentageOff { get; set; }
}
