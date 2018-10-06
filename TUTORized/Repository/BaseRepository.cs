using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TUTORized.Repository
{
    public class BaseRepository
    {
        private IDbConnection Connection => new SqlConnection(_connection);

        private readonly string _connection;

        //default constructor
        public BaseRepository(string connection)
        {
            _connection = connection;
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

        protected async Task ExecuteAsync(string procedureName, object parameters = null)
        {
            using (var connection = Connection)
            {
                connection.Open();

                await connection.ExecuteAsync(procedureName, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
            }
        }

        protected async Task<IEnumerable<T>> JsonResultAsync<T>(string procedureName, DynamicParameters parameters = null)
        {
            using (var connection = Connection)
            {
                connection.Open();

                return await connection.QueryAsync<T>(
                    procedureName,
                    parameters,
                    commandType: CommandType.StoredProcedure).ConfigureAwait(false);
            }
        }

        protected async Task<string> JsonResultAsync(string procedureName, object parameters = null)
        {
            using (var connection = Connection)
            {
                //opens the Db connection.
                connection.Open();

                //Gets the info from the specified Stored Procedure.
                var results = await connection.QueryAsync<string>(
                    procedureName,
                    parameters,
                    commandType: CommandType.StoredProcedure).ConfigureAwait(false);

                //turns the json into a long json string.
                return string.Join(string.Empty, results);
            }
        }

        protected async Task<T> FirstJsonResultAsync<T>(string procedureName, DynamicParameters parameters)
        {
            //Calls to JsonResult which grabs the JSON string from the specified stored proceudre.
            //It will then conver the json to the specified type (i.e. User model, student model, tutor model etc.).
            return JsonConvert.DeserializeObject<T>(await JsonResultAsync(procedureName, parameters).ConfigureAwait(false));
        }
    }
}
