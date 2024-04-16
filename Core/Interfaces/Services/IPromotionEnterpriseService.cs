using Core.Models;

namespace Core.Interfaces.Services;

public interface IPromotionEnterpriseService
{
    Task<PromotionEnterpriseDTO> AsignarPromocionAEmpresa(int id);
}
