using NewsApp.DTOs;
using NewsApp.Entities;

namespace NewsApp.Interfaces
{
    public interface IArticleRepository
    {
        Task<List<ArticleDto>> GetArticles();
        Task<ArticleDto> GetArticle(int id);
        Task<ArticleDto> AddArticle(ArticleDto article);
        Task<ArticleDto> UpdateArticle(int id, ArticleDto article);
        Task<ArticleDto> DeleteArticle(int id);
    }
}
