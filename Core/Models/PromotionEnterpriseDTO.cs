using Core.Entities;

namespace Core.Models;

public class PromotionEnterpriseDTO
{
    public PromotionDTO Promotion { get; set; } = null!;
    public EnterpriseDTO Enterprise { get; set; } = null!;
}
