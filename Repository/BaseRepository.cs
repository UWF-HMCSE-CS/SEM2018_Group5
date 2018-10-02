using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace TUTORized.Repository
{
    public class BaseRepository
    {

        private IDbConnection Connection => new SqlConnection(ConnectionString);

        private string ConnectionString = "Server=tcp:tma.database.windows.net,1433;Initial Catalog=TMA;Persist Security Info=False;User ID=tmadev;Password=!qa@ws3ed;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public BaseRepository()
        {

        }
        public async Task testConnection()
        {
            using (IDbConnection conn = Connection)
            {
                string query = "SELECT * FROM USERS";
                conn.Open();
                var result = await conn.QueryAsync<String>(query);
            }
                

        }

    }
}
