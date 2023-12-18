using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NewsApp.Entities
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }

        //Foreign keys
        public int UserId { get; set; }
        public int ArticleId { get; set; }

        //Navigation properties
        public User User { get; set; }
        public Article Article { get; set; }
    }
}
