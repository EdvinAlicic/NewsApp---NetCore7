using NewsApp.Entities;

namespace NewsApp.Interfaces
{
    public interface ITokenRepository
    {
        string CreateToken(User user);
    }
}
