using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Transactions;

namespace FraudDetectionSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly IAmazonSQS _sqsClient;
        private readonly IConfiguration _configuration;

        public TransactionsController(IAmazonSQS sqsClient, IConfiguration configuration)
        {
            _sqsClient = sqsClient;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> ProcessTransaction([FromBody] Transaction transaction)
        {
            var queueUrl = _configuration["AWS:SQS:QueueUrl"];
            var message = new SendMessageRequest
            {
                QueueUrl = queueUrl,
                MessageBody = JsonConvert.SerializeObject(transaction)
            };

            await _sqsClient.SendMessageAsync(message);

            return Ok(new { Status = "Transaction received for processing." });
        }
    }
}
