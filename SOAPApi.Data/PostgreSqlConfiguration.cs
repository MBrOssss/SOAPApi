using System.Data.Entity;
using Npgsql;

namespace SOAPApi.Data
{
    public class PostgreSqlConfiguration : DbConfiguration
    {
        public PostgreSqlConfiguration()
        {
            SetProviderServices("Npgsql", NpgsqlServices.Instance);
            SetDefaultConnectionFactory(new NpgsqlConnectionFactory());
        }
    }
}
