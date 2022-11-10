using Platform.Core.Entities;
using Platform.Core.Requests.Comment;

namespace Platform.Core.Interfaces
{
    public interface ICommentsService
    {
        Task<ServiceResponse<CommentDto>> Create(CreateCommentDto newComment);
    }
}
