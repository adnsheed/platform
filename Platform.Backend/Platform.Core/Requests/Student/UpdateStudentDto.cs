using Platform.Core.Entities;

namespace Platform.Core.Requests.Student
{
    public class UpdateStudentDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public StudentStatus Status { get; set; }
        public Guid SelectionId { get; set; }
    }
}
