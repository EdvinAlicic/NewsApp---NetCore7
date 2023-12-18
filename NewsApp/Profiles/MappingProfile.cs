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
            CreateMap<Comment, CommentDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Username))
                .ForMember(dest => dest.ArticleId, opt => opt.MapFrom(src => src.Article.Id))
                .ForMember(dest => dest.ArticleTitle, opt => opt.MapFrom(src => src.Article.Title)).ReverseMap();
        }
    }
}
