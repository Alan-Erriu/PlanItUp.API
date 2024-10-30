using PlanItUP.Entities.Models;

namespace PlanItUp.Data.Interfaces
{
    public interface IAuthDAO
    {
        Task<int> signUp(Client client);
    }
}