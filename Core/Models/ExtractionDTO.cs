using Core.Entities;

namespace Core.Models;

public class ExtractionDTO
{
    public int Id { get; set; }
    public int MovementId { get; set; }
    public MovementDTO Movement { get; set; } = null!;
}
