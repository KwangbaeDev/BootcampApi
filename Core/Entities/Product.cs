using Core.Constants;

namespace Core.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public virtual ICollection<ApplicationForm> ApplicationForms { get; set; } = new List<ApplicationForm>();
}
