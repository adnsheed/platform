using Platform.Common;
using Platform.Core.Entities;
using Platform.Core.Requests.Student;

namespace Platform.Core.Interfaces
{
    public interface IStudentsService
    {
        Task<ServiceResponse<List<StudentDto>>> GetAll(RequestParameters studentParameters);
        Task<ServiceResponse<StudentDto>> GetById(int id);
        Task<ServiceResponse<List<StudentDto>>> Create(CreateStudentDto createStudent);
        Task<ServiceResponse<StudentDto>> Update(int id, UpdateStudentDto updatedStudent);
        Task<ServiceResponse<List<StudentDto>>> Delete(int id);
    }
}
