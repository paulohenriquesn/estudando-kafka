namespace ProducerApi.Services
{
    public class OrderService : IOrderService
    {
        public void ProcessOrder(IList<string> items)
        {
            Console.WriteLine("processando lista");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
