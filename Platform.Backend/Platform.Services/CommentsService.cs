using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Platform.Core.Entities;
using Platform.Core.Interfaces;
using Platform.Core.Requests.Comment;
using Platform.Database;

namespace Platform.Services
{
    public class CommentsService : ICommentsService
    {
        private readonly IMapper mapper;
        private readonly PlatformDbContext context;

        public CommentsService(IMapper mapper, PlatformDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        public async Task<ServiceResponse<CommentDto>> Create(CreateCommentDto newComment)
        {
            var student = await context.Students
            .FirstOrDefaultAsync(s => s.Id == newComment.StudentId);


            if (student == null)
            {
                throw new KeyNotFoundException("Student not found");
            }

            Comment comment = new Comment
            {
                Content = newComment.Content,
                Student = student,
            };

            context.Comments.Add(comment);
            await context.SaveChangesAsync();

            return new ServiceResponse<CommentDto>()
            {
                Data = mapper.Map<CommentDto>(comment),
                Message = "Successfully added comment"
            };
        }
    }
}
