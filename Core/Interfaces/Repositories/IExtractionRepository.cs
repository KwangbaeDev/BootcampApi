using Core.Models;
using Core.Requests.ExtractionModels;

namespace Core.Interfaces.Repositories;

public interface IExtractionRepository
{
    Task<ExtractionDTO> Extracting(CreateExtractionModel model);
}
