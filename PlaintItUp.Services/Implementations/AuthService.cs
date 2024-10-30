using PlanItUp.Data.Interfaces;

namespace PlanItUp.Services.Implementations
{
    public class AuthService
    {
        public readonly IAuthDAO _authDAO;
        public AuthService(IAuthDAO authDAO)
        {
            _authDAO = authDAO;
        }


    }
}
