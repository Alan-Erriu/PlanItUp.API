using PlanItUp.Common.CustomRequest.AuthRequest;

namespace PlanItUp.Services.Interfaces
{
    public interface IAuthService
    {
        Task<int> SignUp(SignUpRequest signUpRequest);
    }
}