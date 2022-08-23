using AutoMapper;
using server.Entities;
using server.Models;
using server.Repositories.Interfaces;
using server.Services.Interfaces;

namespace server.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IJwtGeneratorService _jwtGenerator;


        public UserService(IUserRepository userRepository, IMapper mapper, IJwtGeneratorService jwtGenerator)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _jwtGenerator = jwtGenerator;
        }
        public string? AddUser(UserToCreateDto newUser)
        {
            var user = _mapper.Map<User>(newUser);

            _userRepository.AddUser(user);

            return _jwtGenerator.GenerateAuthToken(user);

        }
        public void UpdateUser(int id, UserToUpdateDto userUpdated)
        {
            var user = _mapper.Map<User>(userUpdated);
            _userRepository.UpdateUser(id, user);

        }
        public User? GetUser(int id)
        {
            return _userRepository.GetUser(id);
        }

        public void DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
        }
    }
}
