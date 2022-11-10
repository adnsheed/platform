namespace Platform.Core.Requests.Comment
{
    public class CreateCommentDto
    {
        public string Content { get; set; } = string.Empty;
        public int StudentId { get; set; }
    }
}
