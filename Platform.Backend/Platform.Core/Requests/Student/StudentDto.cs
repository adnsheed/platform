using Platform.Core.Entities;
using Platform.Core.Requests.Comment;
using Platform.Core.Requests.ItemStudent;
using Platform.Core.Requests.Selection;
using Platform.Core.Requests.Users;

namespace Platform.Core.Requests.Student
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public StudentStatus Status { get; set; }
        public SelectionDto? Selection { get; set; }
        public List<CommentDto> Comments { get; set; } = new List<CommentDto>();
        public ICollection<UserRoleDto> UserRoles { get; set; }
        public List<ItemStudentDto> ItemStudents { get; set; } = new List<ItemStudentDto>();
    }
}
