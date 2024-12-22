using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using FraudDetectionSystem.Infrastructure.Configurations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace FraudDetectionSystem.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDynamoDb(this IServiceCollection services)
    {
        services.AddSingleton<IAmazonDynamoDB>(provider =>
        {
            var dynamoDbClient = new AmazonDynamoDBClient();
            var config = provider.GetRequiredService<IOptions<DynamoDbConfiguration>>().Value;

#if DEBUG
            if (!string.IsNullOrEmpty(config.ServiceURL))
            {
                dynamoDbClient = new AmazonDynamoDBClient(new AmazonDynamoDBConfig
                {
                    ServiceURL = config.ServiceURL
                });
            }
#else
            dynamoDBClient = new AmazonDynamoDBClient(
                new BasicAWSCredentials(config.AccessKey, config.SecretKey),
                new AmazonDynamoDBConfig { RegionEndpoint = Amazon.RegionEndpoint.GetBySystemName(config.Region) }
            );
#endif

            return dynamoDbClient;
        });


        services.AddSingleton<IDynamoDBContext, DynamoDBContext>();

        return services;
    }
}