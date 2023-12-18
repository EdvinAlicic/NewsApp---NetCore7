using NewsApp.Entities;

namespace NewsApp.DTOs
{
    public class ArticleDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string? PhotoUrl { get; set; }
        public List<CommentDto> Comments { get; set; }
    }
}
