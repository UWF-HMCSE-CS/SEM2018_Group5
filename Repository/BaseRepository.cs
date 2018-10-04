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

        //default constructor
        public BaseRepository()
        {

        }

        //test connection
        
        public async Task TestConnection()
        {
            using (IDbConnection conn = Connection)
            {
                string query = "SELECT * FROM USERS";
                conn.Open();
                var result = await conn.QueryAsync<String>(query);
            }
        }
        

        //Execute Async
        private async Task ExecuteAsync(string procedureName, object parameters = null)
        {
            using (var connection = Connection)
            {
                connection.Open();

                await connection.ExecuteAsync(procedureName, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
            }
        }

        //Retrives rows in a table
        

    }
}
