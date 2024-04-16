using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Models;
using Infrastructure.Contexts;
using Mapster;

namespace Infrastructure.Repositories;

public class PromotionEnterpriseRepository : IPromotionEnterpriseRepository
{
    private readonly BootcampContext _context;

    public PromotionEnterpriseRepository(BootcampContext context)
    {
        _context = context;
    }

    public async Task<PromotionEnterpriseDTO> AsignarPromocionAEmpresa(int promotionId, int enterpriseId)
    {
        var promotionEnterprise = new PromotionEnterprise
        {
            PromotionId = promotionId,
            EnterpriseId = enterpriseId
        };

        _context.PromotionEnterprises.Add(promotionEnterprise);
        await _context.SaveChangesAsync();

        return new PromotionEnterpriseDTO();
    }

    public Task<PromotionEnterpriseDTO> AsignarPromocionAEmpresa(int id)
    {
        throw new NotImplementedException();
    }
}
