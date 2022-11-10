using Platform.Core.Entities;
using Platform.Core.Requests.Program;
using Platform.Core.Requests.Student;

namespace Platform.Core.Requests.Selection
{
    public class SelectionDto
    {
        public Guid? Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public SelectionStatus Status { get; set; }
        public ProgramDto? Program { get; set; }
        public List<StudentDto> Students { get; set; } = new List<StudentDto>();
    }
}
