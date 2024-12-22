namespace FraudDetectionSystem.Domain
{
    public class Transaction
    {
        public string TransactionId { get; set; }
        public string UserId { get; set; }
        public decimal Amount { get; set; }
        public string Location { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
