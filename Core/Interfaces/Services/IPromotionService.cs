using Core.Models;
using Core.Requests;

namespace Core.Interfaces.Services;

public interface IPromotionService
{
    Task<List<PromotionDTO>> GetFiltered(FilterPromotionModel filter);
    Task<PromotionDTO> Add(CreatePromotionModel model);
    Task<PromotionDTO> GetById(int id);
    Task<List<PromotionDTO>> GettAll();
    Task<PromotionDTO> Update(UpdatePromotionModel model);
    Task<bool> Delete(int id);
}
