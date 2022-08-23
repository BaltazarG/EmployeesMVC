using server.Entities;
using server.Models;

namespace server.Services.Interfaces
{
    public interface IAuthService
    {
        public User? ValidateUser(AuthDto authenticationRequestBody);
        public bool UserExists(string email);

    }
}
