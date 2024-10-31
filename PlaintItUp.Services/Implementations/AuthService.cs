using PlanItUp.Common.CustomExceptions.GenericResponsesExceptions;
using PlanItUp.Common.CustomRequest.AuthRequest;
using PlanItUp.Data.Interfaces;
using PlanItUp.Services.Interfaces;
using PlanItUP.Entities.DTOs;
using PlanItUP.Entities.Models;

namespace PlanItUp.Services.Implementations
{
    public class AuthService : IAuthService
    {
        public readonly IAuthDAO _authDAO;
        public readonly IRoleDAO _roleDAO;
        public readonly IClientDAO _clientDAO;
        public readonly IHasherService _hasherService;
        public AuthService(IAuthDAO authDAO, IRoleDAO roleDAO, IClientDAO clientDAO, IHasherService hasherService)
        {
            _authDAO = authDAO;
            _roleDAO = roleDAO;
            _clientDAO = clientDAO;
            _hasherService = hasherService;
        }

        public async Task<int> SignUp(SignUpRequest signUpRequest)
        {
            if (await _clientDAO.CheckEmailExists(signUpRequest.email.ToLower())) throw new ConflictException("El email ya esta en uso");
            var idRole = await _roleDAO.GetIdRoleByName("user");
            if (idRole == null) throw new NotFoundException("role not found in data base");
            signUpRequest.password_hash = _hasherService.HashPasswordUser(signUpRequest.password_hash);
            var newClient = new Client

            {
                email = signUpRequest.email,
                lastname = signUpRequest.lastname,
                phone_number = signUpRequest.phone_number,
                name = signUpRequest.name,
                role_id = idRole,
                password_hash = signUpRequest.password_hash,
            };
            return await _authDAO.signUp(newClient);
        }

        public async Task<LoginDTO> SignIn(LoginRequest loginRequest)
        {
            var client = await _authDAO.SignIn(loginRequest);
            if (client == null) throw new NotFoundException("User Not Found");
            if (!_hasherService.VerifyPassword(loginRequest.password, client.password_hash)) throw new UnauthorizedException("Incorrect password");
            if (!client.status) throw new UnauthorizedException("The user is disabled");
            return client;
        }
    }
}
