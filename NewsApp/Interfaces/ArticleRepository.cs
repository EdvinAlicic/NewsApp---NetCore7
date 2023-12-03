using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsApp.Data;
using NewsApp.DTOs;
using NewsApp.Entities;
using System.Reflection.Metadata.Ecma335;

namespace NewsApp.Interfaces
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        public ArticleRepository(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }
        public async Task<ArticleDto> AddArticle(ArticleDto article)
        {
            try
            {
                if (article == null)
                {
                    throw new ArgumentNullException(nameof(article));
                }
                var articleEntity = _mapper.Map<Article>(article);

                var createdArticle = await _dataContext.Articles.AddAsync(articleEntity);

                await _dataContext.SaveChangesAsync();

                var createdArticleDto = _mapper.Map<ArticleDto>(createdArticle.Entity);

                return createdArticleDto;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ArticleDto> DeleteArticle(int id)
        {
            try
            {
                var articleEntity = await _dataContext.Articles.FindAsync(id);

                if(articleEntity == null)
                {
                    return null;
                }

                var deletedArticle = _mapper.Map<ArticleDto>(articleEntity);

                _dataContext.Remove(articleEntity);

                await _dataContext.SaveChangesAsync();

                return deletedArticle;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ArticleDto> GetArticle(int id)
        {
            var articleEntity = await _dataContext.Articles.FindAsync(id);

            if(articleEntity == null)
            {
                return null;
            }

            return _mapper.Map<ArticleDto>(articleEntity);
        }

        public async Task<List<ArticleDto>> GetArticles()
        {
            var articleEntity = await _dataContext.Articles.ToListAsync();

            return _mapper.Map<List<ArticleDto>>(articleEntity);
        }

        public async Task<ArticleDto> UpdateArticle(int id, ArticleDto updatedArticle)
        {
            var articleEntity = await _dataContext.Articles.FindAsync(id);

            if(articleEntity == null)
            {
                return null;
            }

            _mapper.Map(updatedArticle, articleEntity);

            await _dataContext.SaveChangesAsync();

            return _mapper.Map<ArticleDto>(articleEntity);
        }
    }
}
