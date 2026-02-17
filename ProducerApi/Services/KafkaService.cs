using Confluent.Kafka;
using System.Text.Json;

namespace ProducerApi.Services
{
    public class KafkaService : IMessageService
    {
        private readonly string _kafkaBootstrapServers;

        public KafkaService(IConfiguration configuration)
        {
            _kafkaBootstrapServers = configuration["Kafka:BootstrapServers"]!;
        }

        public async Task Notify(string Topic, object Message)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = _kafkaBootstrapServers
            };

            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                await producer.ProduceAsync(Topic, new Message<Null, string>
                {
                    Value = JsonSerializer.Serialize(Message)
                });
            }
        }
    }
}
