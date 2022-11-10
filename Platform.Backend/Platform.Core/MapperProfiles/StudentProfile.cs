using AutoMapper;
using Platform.Core.Entities;
using Platform.Core.Requests.Student;

namespace Platform.Core.MapperProfiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDto>().ReverseMap();         
            CreateMap<CreateStudentDto, Student>();
        }
    }
}
