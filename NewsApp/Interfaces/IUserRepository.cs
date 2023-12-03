using NewsApp.DTOs;

namespace NewsApp.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserDto>> GetUsers();
        Task<UserDto> GetUserById(int id);
    }
}
