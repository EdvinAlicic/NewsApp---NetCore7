using NewsApp.Entities;

namespace NewsApp.DTOs
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        // User information
        public int UserId { get; set; }
        public string UserName { get; set; }

        // Article information
        public int ArticleId { get; set; }
        public string ArticleTitle { get; set; }
    }
}
