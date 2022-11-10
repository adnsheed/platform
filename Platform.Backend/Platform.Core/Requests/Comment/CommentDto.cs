using Platform.Core.Entities;

namespace Platform.Core.Requests.Comment
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public User? Author { get; set; }
    }
}
