using server.Entities;
using server.Models;

namespace server.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public User? ValidateUser(AuthDto authenticationRequestBody);
        public bool UserExists(string email);
        public void AddUser(User newUser);
        public void UpdateUser(int id, User userUpdated);
        public User? GetUser(int id);
        public void DeleteUser(int id);
    }
}
