using Confluent.Kafka;

namespace Consumer
{
    public class Worker(IConfiguration configuration, ILogger<Worker> logger) : BackgroundService
    {
        private string _kafkaTopicOrders = configuration.GetValue<string>("Kafka:OrdersTopicName") ?? "orders";
        private string _kafkaBootstrapServers = configuration.GetValue<string>("Kafka:BootstrapServers");



        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var config = new ConsumerConfig
                {
                    BootstrapServers = _kafkaBootstrapServers,
                    GroupId = "grupo",
                    AutoOffsetReset = AutoOffsetReset.Earliest
                };

                using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
                {
                    consumer.Subscribe(_kafkaTopicOrders);

                    CancellationTokenSource cts = new CancellationTokenSource();
                    Console.CancelKeyPress += (_, e) =>
                    {
                        e.Cancel = true;
                        cts.Cancel();
                    };

                    try
                    {
                        while (true)
                        {
                            var consumerResult = consumer.Consume(cts.Token);

                            Console.WriteLine(consumerResult.Value);
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        consumer.Close();
                    }
                }

                logger.LogInformation(_kafkaTopicOrders);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
