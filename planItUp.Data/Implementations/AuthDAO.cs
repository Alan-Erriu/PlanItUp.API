using Dapper;
using Microsoft.Extensions.Options;
using PlanItUp.Configuration;
using PlanItUp.Data.Interfaces;
using PlanItUP.Entities.Models;
using System.Data.SqlClient;

namespace PlanItUp.Data.Implementations
{
    public class AuthDAO : IAuthDAO
    {
        private SQLServerConfig _SQLServerConfig;

        public AuthDAO(IOptions<SQLServerConfig> bdConfig)
        {
            _SQLServerConfig = bdConfig.Value;
        }

        private string _InsertUser = @"INSERT INTO [client] (name, lastname, email,password_hash, role_id,phone_number)
                                         VALUES (@Name, @LastName, @Email,@Password, @Roleid, @PhoneNumber)";


        public async Task<int> signUp(Client client)
        {
            using (var connection = new SqlConnection(_SQLServerConfig.ConnectionString))
            {

                var parameters = new
                {
                    Name = client.name.ToLower(),
                    LastName = client.lastname.ToLower(),
                    Email = client.email,
                    Password = client.password_hash,
                    Roleid = client.role_id,
                    PhoneNumber = client.phone_number
                };
                var rowsAffected = await connection.ExecuteAsync(_InsertUser, parameters);
                return rowsAffected;
            }
        }
    }
}