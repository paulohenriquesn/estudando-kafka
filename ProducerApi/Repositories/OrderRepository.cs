using Dapper;
using ProducerApi.Infra;
using System.Text.Json;

namespace ProducerApi.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DBContext _dbContext;

        public OrderRepository(DBContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<int> SaveAsync(IList<string> Items)
        {
            object parameters = new
            {
                Items = JsonSerializer.Serialize(Items)
            };

            var query = "INSERT INTO orders (list) VALUES (@Items::jsonb) RETURNING id";
            return await _dbContext.DBConnection.ExecuteScalarAsync<int>(query, parameters);
        }
    }
}
