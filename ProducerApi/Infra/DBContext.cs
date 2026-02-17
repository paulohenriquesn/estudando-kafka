using Npgsql;
using System.Data;

namespace ProducerApi.Infra
{
    public class DBContext
    {
        private readonly IDbConnection _dbConnection;
        public DBContext(IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("PostgressConnection");
            _dbConnection = new NpgsqlConnection(connectionString);
        }

        public IDbConnection DBConnection => _dbConnection;
    }

}
