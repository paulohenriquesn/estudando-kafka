using Confluent.Kafka;
using ProducerApi.Repositories;

namespace ProducerApi.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMessageService _messageService;

        private string _topicOrdersName;

        public OrderService(IConfiguration configuration, IOrderRepository orderRepository, IMessageService messageService)
        {
            _topicOrdersName = configuration.GetValue<string>("Kafka:OrdersTopicName");
            _orderRepository = orderRepository;
            _messageService = messageService;
        }


        public async void ProcessOrder(IList<string> items)
        {
            Console.WriteLine("processando lista");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }

            int orderId = await _orderRepository.SaveAsync(items);

            object Message = new
            {
                Id = orderId,
                Items = items
            };

            await _messageService.Notify(_topicOrdersName, Message);
        }
    }
}
