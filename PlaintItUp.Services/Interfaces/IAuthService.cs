using PlanItUp.Common.CustomRequest.AuthRequest;
using PlanItUP.Entities.DTOs;

namespace PlanItUp.Services.Interfaces
{
    public interface IAuthService
    {
        Task<int> SignUp(SignUpRequest signUpRequest);
        Task<LoginDTO> SignIn(LoginRequest loginRequest);
    }
}