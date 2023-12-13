using AutoMapper;
using NewsApp.DTOs;
using NewsApp.Entities;

namespace NewsApp.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Article, ArticleDto>();
            CreateMap<ArticleDto, Article>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
