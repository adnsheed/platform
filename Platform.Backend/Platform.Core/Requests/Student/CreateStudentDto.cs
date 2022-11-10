using Platform.Core.Entities;

namespace Platform.Core.Requests.Student
{
    public class CreateStudentDto
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public StudentStatus Status { get; set; }
        public Guid? SelectionId { get; set; }
    }
}
