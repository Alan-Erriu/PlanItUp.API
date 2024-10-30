using Dapper;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;

namespace PlanItUp.Data.Implementations
{
    public class ClientDAO
    {
        private SqlConnection _connection;
        public ClientDAO(IOptions<SqlConnection> sqlConnection)
        {
            _connection = sqlConnection.Value;
        }

        private string _selectEmailClient = "SELECT email FROM[client] where email = @Email";

        public async Task<bool> CheckEmailExists(string emailClient)
        {
            using (var connection = new SqlConnection(_connection.ConnectionString))
            {
                var parameters = new
                {
                    Email = emailClient
                };
                var emailClientInDB = await connection.QueryFirstOrDefaultAsync<String>(_selectEmailClient, parameters);
                if (emailClientInDB == null) return false;
                return true;
            }


        }
    }
}
