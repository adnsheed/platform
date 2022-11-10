using Platform.Core.Entities;

namespace Platform.Core.Requests.Selection
{
    public class UpdateSelectionDto
    {
        public string Title { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public SelectionStatus Status { get; set; }
        public Guid ProgramId { get; set; }
    }
}
