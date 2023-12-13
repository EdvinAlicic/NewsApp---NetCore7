using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NewsApp.Data;
using NewsApp.DTOs;
using NewsApp.Entities;
using NewsApp.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace NewsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly ITokenRepository _tokenRepository;
        private readonly IUserRepository _userRepository;
        public UserController(DataContext dataContext, ITokenRepository tokenRepository, IUserRepository userRepository)
        {
            _dataContext = dataContext;
            _tokenRepository = tokenRepository;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<List<UserDto>> GetAllUsers()
        {
            return await _userRepository.GetUsers();
        }

        [HttpGet("id")]
        public async Task<UserDto> GetUser(int id)
        {
            return await _userRepository.GetUserById(id);
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserViewDto>> Register(UserRegisterDto userRegisterDto)
        {
            using var hmac = new HMACSHA512();

            var user = new User
            {
                FirstName = userRegisterDto.FirstName,
                LastName = userRegisterDto.LastName,
                Email = userRegisterDto.Email,
                Username = userRegisterDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userRegisterDto.Password)),
                PasswordSalt = hmac.Key
            };

            _dataContext.Users.Add(user);
            await _dataContext.SaveChangesAsync();

            return new UserViewDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Token = _tokenRepository.CreateToken(user),
                Email = user.Email
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserViewDto>> Login(UserLoginDto userLoginDto)
        {
            var user = await _dataContext.Users.SingleOrDefaultAsync(x => x.Username == userLoginDto.Username);

            if(user == null)
            {
                return Unauthorized("Invalid username");
            }

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userLoginDto.Password));

            for(int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                {
                    return Unauthorized("Invalid Password");
                }
            }
            return new UserViewDto
            {
                Username = userLoginDto.Username,
                Token = _tokenRepository.CreateToken(user)
            };
        }
    }
}
