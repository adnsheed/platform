using AutoMapper;
using Platform.Core.Entities;
using Platform.Core.Requests.Comment;

namespace Platform.Core.MapperProfiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentDto>();
        }
        
    }
}
