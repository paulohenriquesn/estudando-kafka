namespace ProducerApi.Services
{
    public interface IOrderService
    {
        void ProcessOrder(IList<string> items);
    }
}
