using server.Entities;

namespace server.Services.Interfaces
{
    public interface IJwtGeneratorService
    {
        public string? GenerateAuthToken(User user);

    }
}
