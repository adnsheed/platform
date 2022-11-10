using AutoMapper;
using Platform.Core.Entities;
using Platform.Core.Requests.Comment;
using Platform.Core.Requests.Program;
using Platform.Core.Requests.Selection;
using Platform.Core.Requests.Student;

namespace Platform.Core
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Student, StudentDto>();
            
            CreateMap<CreateStudentDto, Student>();
            CreateMap<Program, ProgramDto>();
            CreateMap<Selection, SelectionDto>();
          
            CreateMap<CreateSelectionDto, Selection>();
            CreateMap<Comment, CommentDto>();
        }
    }
}
