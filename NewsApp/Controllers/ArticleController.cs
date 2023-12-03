using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsApp.DTOs;
using NewsApp.Interfaces;

namespace NewsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleRepository _articleRepository;
        public ArticleController(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        [HttpGet]
        public async Task<List<ArticleDto>> GetAllArticles()
        {
            return await _articleRepository.GetArticles();
        }

        [HttpGet("id")]
        public async Task<ArticleDto> GetArticleById(int id)
        {
            return await _articleRepository.GetArticle(id);
        }

        [HttpPost]
        public async Task<ArticleDto> CreateArticle(ArticleDto article)
        {
            return await _articleRepository.AddArticle(article);
        }

        [HttpPut]
        public async Task<ArticleDto> UpdateEntireArticle(int id, ArticleDto article)
        {
            return await _articleRepository.UpdateArticle(id, article);
        }
    }
}
