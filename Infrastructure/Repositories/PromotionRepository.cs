using Core.Constants;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests;
using Infrastructure.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Infrastructure.Repositories;

public class PromotionRepository : IPromotionRepository
{
    private readonly BootcampContext _context;

    public PromotionRepository(BootcampContext context)
    {
        _context = context;
    }

    public async Task<PromotionDTO> Add(CreatePromotionModel model)
    {
        var promotion = model.Adapt<Promotion>();

        _context.Promotions.Add(promotion);

        await _context.SaveChangesAsync();

        if (model.EnterpriseIds != null && model.EnterpriseIds.Any())
        {
            foreach (var enterpriseIds in model.EnterpriseIds)
            {
                var promotionEnterprise = new PromotionEnterprise
                {
                    PromotionId = promotion.Id,
                    EnterpriseId = enterpriseIds
                };

                _context.PromotionEnterprises.Add(promotionEnterprise);
            }

            await _context.SaveChangesAsync();
        }

        var promotionToCreate = await _context.Promotions
            .Include(x => x.PromotionsEnterprises)
            .ThenInclude(x => x.Enterprise)
            .FirstOrDefaultAsync(x => x.Id == promotion.Id);

        return promotionToCreate.Adapt<PromotionDTO>();
    }

    public async Task<bool> Delete(int id)
    {
        var promotion = await _context.Promotions.FindAsync(id);

        if (promotion is null || promotion.IsDeleted == IsDeleteStatus.True)
        {
            throw new Exception("Promotion not found.");
        }

        promotion.IsDeleted = IsDeleteStatus.True;

        var result = await _context.SaveChangesAsync();

        return result > 0;
    }

    public async Task<PromotionDTO> GetById(int id)
    {
        //var promotion = await _context.Promotions.FindAsync(id);
        var promotion = await _context.Promotions
                                      .Include(x => x.PromotionsEnterprises)
                                      .ThenInclude(x => x.Enterprise)
                                      .FirstOrDefaultAsync(x => x.Id == id); 

        if (promotion is null || promotion.IsDeleted == IsDeleteStatus.True)
        {
            throw new Exception("Promotion not found");
        }

        var promotionDTO = promotion.Adapt<PromotionDTO>();

        return promotionDTO;
    }

    public async Task<List<PromotionDTO>> GettAll()
    {
        var promotion = await _context.Promotions
                                            .Where(x => x.IsDeleted != IsDeleteStatus.True)
                                            .ToListAsync();

        var promotionDTO = promotion.Adapt<List<PromotionDTO>>();

        return promotionDTO;
    }

    public async Task<PromotionDTO> Update(UpdatePromotionModel model)
    {
        var promotion = await _context.Promotions.FindAsync(model.Id);

        if (promotion is null || promotion.IsDeleted == IsDeleteStatus.True)
        {
            throw new Exception("Promotion was not found.");
        }
        model.Adapt(promotion);

        _context.Promotions.Update(promotion);

        await _context.SaveChangesAsync();

        var promotionDTO = promotion.Adapt<PromotionDTO>();

        return promotionDTO;
    }
}
