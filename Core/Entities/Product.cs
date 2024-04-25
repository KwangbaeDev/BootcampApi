using Core.Constants;

namespace Core.Entities;

public class Product
{
    public int Id { get; set; }
    public ProductType ProductType { get; set; }

    public virtual ICollection<ApplicationForm> ApplicationForms { get; set; } = new List<ApplicationForm>();
}
