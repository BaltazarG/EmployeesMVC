using server.Contexts;
using server.Entities;
using server.Models;
using server.Repositories.Interfaces;

namespace server.Repositories.Implementations
{
    public class UserRepository : Repository, IUserRepository
    {


        public UserRepository(AppDbContext context) : base(context)
        {
        }
        public User? ValidateUser(AuthDto authenticationRequestBody)
        {
            return _context.Users?.FirstOrDefault(p => p.Email == authenticationRequestBody.Email && p.Password == authenticationRequestBody.Password);
        }
        public bool UserExists(string email)
        {
            var user = _context.Users?.FirstOrDefault(p => p.Email == email);

            if(user == null)
                return false;
            return true;
        }
                
        public void AddUser(User newUser)
        {
            _context.Users?.Add(newUser);
            SaveChanges();
        }

        public void UpdateUser(int id, User userUpdated)
        {
            
            User? user = GetUser(id);

            if (user != null)
            {
                user.Username = userUpdated.Username;
                user.Password = userUpdated.Password;
                user.Email = userUpdated.Email;
            }
            SaveChanges();
        }

        public User? GetUser(int id)
        {

            return _context.Users?.FirstOrDefault(u => u.Id == id);
        }

        public void DeleteUser(int id)
        {
            User? user = GetUser(id);

            if (user != null)
            {
                _context.Users?.Remove(user);
            }
            SaveChanges();
        }
    }
}
