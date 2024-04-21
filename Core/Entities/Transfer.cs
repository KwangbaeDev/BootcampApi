namespace Core.Entities
{
    public class Transfer
    {
        public int Id { get; set; }
        //public string? DestinationBank { get; set; }
        //public string? AccountNumber { get; set; }
        //public string? DocumentNumber { get; set; }

        public int OriginAccountId { get; set; }
        public Account OriginAccount { get; set; } = null!;
        public int DestinationAccountId { get; set; }
        //public Account TargetAccount { get; set; } = null!;
        //public int CurrencyId { get; set; }
        //public Currency Currency { get; set; } = null!;
        public int MovementId { get; set; }
        public Movement Movement { get; set; } = null!;
    }
}
