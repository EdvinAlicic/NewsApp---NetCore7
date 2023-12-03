using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NewsApp.Data;
using NewsApp.DTOs;

namespace NewsApp.Interfaces
{
    public class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        public UserRepository(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }
        public async Task<UserDto> GetUserById(int id)
        {
            var userEntity = await _dataContext.Users.FindAsync(id);

            if(userEntity == null)
            {
                return null;
            }

            return _mapper.Map<UserDto>(userEntity);
        }

        public async Task<List<UserDto>> GetUsers()
        {
            var userEntity = await _dataContext.Users.ToListAsync();

            return _mapper.Map<List<UserDto>>(userEntity);
        }
    }
}
