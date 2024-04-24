namespace Core.Entities
{
    public class Transfer
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransferredDateTime { get; set; }
        public string Concept {  get; set; } = string.Empty;
        public int OriginAccountId { get; set; }
        public Account OriginAccount { get; set; } = null!;
        public int DestinationAccountId { get; set; }
        public int DestinationBankId { get; set; }
        public Bank Bank { get; set; } = null!;
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; } = null!;
    }
}
