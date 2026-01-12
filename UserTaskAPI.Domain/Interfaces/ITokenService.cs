using UserTask.Domain.Entities;

namespace UserTask.Domain.Interfaces;

public interface ITokenService
{
    string GenerateToken(User user);
}
