using server.Entities;
using server.Models;
using server.Repositories.Interfaces;
using server.Services.Interfaces;

namespace server.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User? ValidateUser(AuthDto authenticationRequestBody)
        {
            if (string.IsNullOrEmpty(authenticationRequestBody.Email) || string.IsNullOrEmpty(authenticationRequestBody.Password))
                return null;

            return _userRepository.ValidateUser(authenticationRequestBody);
        }

        public bool UserExists(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;
            return _userRepository.UserExists(email);
        }

    }
}
