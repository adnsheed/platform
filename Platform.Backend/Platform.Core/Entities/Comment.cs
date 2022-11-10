namespace Platform.Core.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int? AuthorId { get; set; }
        public User? Author { get; set; }
        public int? StudentId { get; set; }
        public Student? Student { get; set; }
    }
}
