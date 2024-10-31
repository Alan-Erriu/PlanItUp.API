using Dapper;

using Microsoft.Extensions.Options;
using PlanItUp.Common.CustomRequest.RoomRequest;
using PlanItUp.Configuration;
using PlanItUp.Data.Interfaces;
using System.Data.SqlClient;
namespace PlanItUp.Data.Implementations
{
    public class RoomDAO : IRoomDAO
    {
        private SQLServerConfig _SQLServerConfig;

        public RoomDAO(IOptions<SQLServerConfig> bdConfig)
        {
            _SQLServerConfig = bdConfig.Value;
        }

        private string _InsertRoom = @"INSERT INTO [room] (nameRoom, capacity, client_id) VALUES (@NameRoom, @Capacity, @Client_id)";



        public async Task<int> CreateNewRoom(CreateRoomRequest roomRequest)
        {
            using (var connection = new SqlConnection(_SQLServerConfig.ConnectionString))
            {

                var parameters = new
                {
                    NameRoom = roomRequest.nameRoom,
                    Capacity = roomRequest.capacity,
                    Client_id = roomRequest.client_id,
                };
                var rowsAffected = await connection.ExecuteAsync(_InsertRoom, parameters);
                return rowsAffected;
            }
        }
    }
}
