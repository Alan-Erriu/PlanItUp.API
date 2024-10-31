using PlanItUp.Common.CustomRequest.RoomRequest;

namespace PlanItUp.Data.Interfaces
{
    public interface IRoomDAO
    {
        Task<int> CreateNewRoom(CreateRoomRequest roomRequest);
    }
}