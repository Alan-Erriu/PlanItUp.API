using Dapper;
using Microsoft.Extensions.Options;
using PlanItUp.Configuration;
using System.Data.SqlClient;

namespace PlanItUp.Data.Implementations
{
    public class RoleDAO
    {
        private SQLServerConfig _SQLServerConfig;

        public RoleDAO(IOptions<SQLServerConfig> bdConfig)
        {
            _SQLServerConfig = bdConfig.Value;
        }

        private string _selecIdRolByName = "SELECT role_id FROM[role] where description = @NameRole";



        public async Task<int> GetIdRoleByName(string name)
        {


            using (var connection = new SqlConnection(_SQLServerConfig.ConnectionString))
            {

                var parameters = new { NameRole = name };
                var nameRoleFound = await connection.QueryFirstOrDefaultAsync<int>(_selecIdRolByName, parameters);

                return nameRoleFound;

            }

        }


    }
}
