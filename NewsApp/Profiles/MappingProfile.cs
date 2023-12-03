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
            CreateMap<User, UserDto>();
        }
    }
}
