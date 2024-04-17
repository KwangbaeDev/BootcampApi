using static System.Net.Mime.MediaTypeNames;

namespace Core.Entities;

public class ProductRequests
{
    public int Id { get; set; }
    public DateTime? Dateofapplication { get; set; }
    public DateTime? ApprovalDate {  get; set; }
    public int ProductId { get; set; } = 0;
    public virtual Product Product { get; set; } = null!;

}
