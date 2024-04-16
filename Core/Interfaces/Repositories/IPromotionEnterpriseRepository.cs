using Core.Models;

namespace Core.Interfaces.Repositories;

public interface IPromotionEnterpriseRepository
{
    Task<PromotionEnterpriseDTO> AsignarPromocionAEmpresa(int id);
}
