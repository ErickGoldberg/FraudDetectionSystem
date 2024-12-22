namespace FraudDetectionSystem.Infrastructure.Configurations
{
    public class DynamoDbConfiguration
    {
        /// <summary>
        /// DynamoDB Service URL (Local)
        /// </summary>
        public string ServiceURL { get; set; } = string.Empty;

        /// <summary>
        /// AWS Cloud Region
        /// </summary>
        public string Region { get; set; } = string.Empty;    

        /// <summary>
        /// AccessKey to access DynamoDB in Production
        /// </summary>
        public string AccessKey { get; set; } = string.Empty;  

        /// <summary>
        /// SecretKey to access DynamoDB in Production
        /// </summary>
        public string SecretKey { get; set; } = string.Empty;  
    }
}
