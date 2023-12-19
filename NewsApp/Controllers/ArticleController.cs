using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpGet]
        public async Task<List<ArticleDto>> GetAllArticles()
        {
            return await _articleRepository.GetArticles();
        }

        [Authorize]
        [HttpGet("id")]
        public async Task<ArticleDto> GetArticleById(int id)
        {
            return await _articleRepository.GetArticle(id);
        }

        [Authorize]
        [HttpPost]
        public async Task<ArticleDto> CreateArticle(ArticleDto article)
        {
            return await _articleRepository.AddArticle(article);
        }

        [Authorize]
        [HttpPut]
        public async Task<ArticleDto> UpdateEntireArticle(int id, ArticleDto article)
        {
            return await _articleRepository.UpdateArticle(id, article);
        }

        [Authorize]
        [HttpDelete]
        public async Task<ArticleDto> DeleteArticleById(int id)
        {
            return await _articleRepository.DeleteArticle(id);
        }
    }
}
