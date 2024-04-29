using Core.Constants;
using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.Requests.PromotionModels;
using Infrastructure.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        foreach (int enterpriseId in model.RelatedEnterpriseIds)
        {
            var promotionEnterprise = new PromotionEnterprise
            {
                Promotion = promotion,
                EnterpriseId = enterpriseId
            };
            _context.PromotionEnterprises.Add(promotionEnterprise);
        }

        _context.Promotions.Add(promotion);
        await _context.SaveChangesAsync();

        var createdPromotion = await _context.Promotions
                                             .Include(x => x.PromotionsEnterprises)
                                             .ThenInclude(x => x.Enterprise)
                                             .FirstOrDefaultAsync(x => x.Id == promotion.Id);

        var promotionDTO = promotion.Adapt<PromotionDTO>();
        return promotionDTO;
    }



    public async Task<bool> Delete(int id)
    {
        var promotion = await _context.Promotions
                                      .FindAsync(id);
        if (promotion == null || promotion.IsDeleted == IsDeleteStatus.True)
        {
            throw new NotFoundException($"Promotion with id: {id} doest not exist");
        }

        promotion.IsDeleted = IsDeleteStatus.True;

        var result = await _context.SaveChangesAsync();
        return result > 0;
    }



    public async Task<PromotionDTO> GetById(int id)
    {
        var promotion = await _context.Promotions
                                      .Include(x => x.PromotionsEnterprises)
                                      .ThenInclude(x => x.Enterprise)
                                      .FirstOrDefaultAsync(x => x.Id == id); 
        if (promotion == null || promotion.IsDeleted == IsDeleteStatus.True)
        {
            throw new NotFoundException($"Promotion with id: {id} doest not exist");
        }

        var promotionDTO = promotion.Adapt<PromotionDTO>();
        return promotionDTO;
    }



    public async Task<List<PromotionDTO>> GetFiltered(FilterPromotionModel filter)
    {
        var query = _context.Promotions
                            .Include(x => x.PromotionsEnterprises)
                            .ThenInclude(x => x.Enterprise)
                            .AsQueryable();

        if (filter.Name is not null)
        {
            query = query.Where(x =>
                                x.Name == filter.Name);
        }

        if (filter.PromotionTimeFrom is not null)
        {
            query = query.Where(x =>
                                x.Start != null &&
                                x.Start.Value.Year >= filter.PromotionTimeFrom);
        }

        if (filter.PromotionTimeTo is not null)
        {
            query = query.Where(x =>
                                x.End != null &&
                                x.End.Value.Year <= filter.PromotionTimeTo);
        }

        if (filter.Discount is not null)
        {
            query = query.Where(x =>
                                x.Discount == filter.Discount);
        }

        var result = await query.ToListAsync();

        var promotionDTO = result.Adapt<List<PromotionDTO>>();
        return promotionDTO;
    }



    public async Task<List<PromotionDTO>> GettAll()
    {
        var promotions = await _context.Promotions
                                       .Where(x => x.IsDeleted != IsDeleteStatus.True)
                                       .Include(x => x.PromotionsEnterprises)
                                       .ThenInclude(x => x.Enterprise)
                                       .ToListAsync();

        var promotionDTOs = promotions.Select(x => x.Adapt<PromotionDTO>()).ToList();
        return promotionDTOs;
    }



    public async Task<PromotionDTO> Update(UpdatePromotionModel model)
    {
        var query = _context.Promotions
                            .Include(a => a.PromotionsEnterprises)
                            .ThenInclude(a => a.Enterprise)
                            .AsQueryable();

        var result = await query.ToListAsync();

        var promotion = await _context.Promotions
                                      .Include(x => x.PromotionsEnterprises)
                                      .FirstOrDefaultAsync(x => x.Id == model.Id);
        if (promotion == null || promotion.IsDeleted == IsDeleteStatus.True)
        {
            throw new NotFoundException($"Promotion with id: {model.Id} doest not exist");
        }

        model.Adapt(promotion);

        promotion.PromotionsEnterprises.Clear();

        foreach (int enterpriseId in model.RelatedEnterpriseIds)
        {
            var promotionEnterprise = new PromotionEnterprise
            {
                PromotionId = promotion.Id,
                EnterpriseId = enterpriseId
            };
            promotion.PromotionsEnterprises.Add(promotionEnterprise);
        }

        await _context.SaveChangesAsync();

        var promotionDTO = promotion.Adapt<PromotionDTO>();
        return promotionDTO;
    }
}
