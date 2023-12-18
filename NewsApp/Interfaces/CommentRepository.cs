using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NewsApp.Data;
using NewsApp.DTOs;
using NewsApp.Entities;

namespace NewsApp.Interfaces
{
    public class CommentRepository : ICommentRepository
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        public CommentRepository(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }
        public async Task<CommentDto> AddComment(CommentDto commentDto)
        {
            var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.Username == commentDto.UserName);
            if (user == null)
            {
                return null;
            }

            var article = await _dataContext.Articles.FirstOrDefaultAsync(a => a.Title == commentDto.ArticleTitle);
            if (article == null)
            {
                return null;
            }

            var comment = new Comment
            {
                Content = commentDto.Content,
                CreatedDate = DateTime.Now,
                User = user,
                Article = article
            };

            _dataContext.Comments.Add(comment);
            await _dataContext.SaveChangesAsync();

            var addedCommentDto = _mapper.Map<CommentDto>(comment);

            return addedCommentDto;
        }

        public async Task<List<CommentDto>> GetAllCommentsByArticleId(int articleId)
        {
            var comments = await _dataContext.Comments.Where(c => c.ArticleId == articleId).ToListAsync();

            var commentDto = _mapper.Map<List<CommentDto>>(comments);

            return commentDto;
        }
    }
}
