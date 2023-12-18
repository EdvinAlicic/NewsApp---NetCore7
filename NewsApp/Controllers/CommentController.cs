using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsApp.DTOs;
using NewsApp.Interfaces;

namespace NewsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        public readonly ICommentRepository _commentRepository;
        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddComment([FromBody] CommentDto commentDto)
        {
            var addedComment = await _commentRepository.AddComment(commentDto);

            return Ok(addedComment);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetCommentsByArticleId(int articleId)
        {
            var comments = await _commentRepository.GetAllCommentsByArticleId(articleId);

            return Ok(comments);
        }
    }
}
