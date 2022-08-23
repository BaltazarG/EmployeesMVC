using server.Entities;
using server.Models;

namespace server.Services.Interfaces
{
    public interface IUserService
    {
        public string? AddUser(UserToCreateDto newUser);
        public void UpdateUser(int id, UserToUpdateDto userUpdated);
        public User? GetUser(int id);
        public void DeleteUser(int id);
    }
}
