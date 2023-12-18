using NewsApp.DTOs;

namespace NewsApp.Interfaces
{
    public interface ICommentRepository
    {
        Task<CommentDto> AddComment(CommentDto commentDto);
        Task<List<CommentDto>> GetAllCommentsByArticleId(int articleId);
    }
}
