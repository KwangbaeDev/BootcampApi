namespace Core.Entities;

public class Extraction
{
    public int Id { get; set; }
    public int MovementId { get; set; }
    public Movement Movement { get; set; } = null!;
}
