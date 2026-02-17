namespace ProducerApi.Repositories
{
    public interface IOrderRepository
    {
        Task<int> SaveAsync(IList<string> Items);
    }
}
