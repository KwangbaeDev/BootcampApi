using Core.Constants;

namespace Core.Entities;

public class Product
{
    public int Id { get; set; }
    public ProductType ProductType { get; set; }

    public int ApplicationFormId { get; set; }
    public ApplicationForm ApplicationForm { get; set; } = null!;

    //public virtual ICollection<ApplicationForm> ApplicationForms { get; set; } = new List<ApplicationForm>();
}
