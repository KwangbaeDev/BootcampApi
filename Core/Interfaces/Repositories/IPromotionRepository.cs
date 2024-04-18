﻿using Core.Models;
using Core.Requests.PromotionModels;

namespace Core.Interfaces.Repositories;

public interface IPromotionRepository
{
    Task<List<PromotionDTO>> GetFiltered(FilterPromotionModel filter);
    Task<PromotionDTO> Add(CreatePromotionModel model);
    Task<PromotionDTO> GetById(int id);
    Task<List<PromotionDTO>> GettAll();
    Task<PromotionDTO> Update(UpdatePromotionModel model);
    Task<bool> Delete(int id);
}
