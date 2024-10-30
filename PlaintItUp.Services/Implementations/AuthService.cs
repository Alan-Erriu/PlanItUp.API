using PlanItUp.Data.Interfaces;

namespace PlanItUp.Services.Implementations
{
    public class AuthService
    {
        public readonly IAuthDAO _authDAO;
        public readonly IRoleDAO _roleDAO;
        public AuthService(IAuthDAO authDAO, IRoleDAO roleDAO)
        {
            _authDAO = authDAO;
            _roleDAO = roleDAO;
        }

        //public async Task<int>SignUp()
        //{

        //}
    }
}
