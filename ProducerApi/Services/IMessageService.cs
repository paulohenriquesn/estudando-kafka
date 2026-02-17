namespace ProducerApi.Services
{
    public interface IMessageService
    {
        Task Notify(string Topic, object Message);
    }
}
