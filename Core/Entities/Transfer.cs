namespace Core.Entities
{
    public class Transfer
    {
        public int Id { get; set; }
        public string? DestinationBank { get; set; }
        public string? AccountNumber { get; set; }
        public string? DocumentNumber { get; set; }

        public int SourceAccountId { get; set; }
        public Account SourceAccount { get; set; } = null!;
        public int? TargetAccountId { get; set; }
        //public Account TargetAccount { get; set; } = null!;
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; } = null!;

        public ICollection<MovementAccount> MovementAccounts { get; set; } = new List<MovementAccount>();
    }
}
