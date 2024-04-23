using Core.Models;
using Core.Requests.ExtractionModels;

namespace Core.Interfaces.Services;

public interface IExtractionService
{
    Task<ExtractionDTO> Extracting(CreateExtractionModel model);
}
