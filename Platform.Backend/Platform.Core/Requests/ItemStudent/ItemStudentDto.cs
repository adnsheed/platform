
using Platform.Core.Entities;

namespace Platform.Core.Requests.ItemStudent
{
    public class ItemStudentDto
    {
        public int OrderNumber { get; set; }

        public string Name { get; set; }

        public ItemType Type { get; set; }

        public string Description { get; set; }

        public int WorkHours { get; set; }

        public string Urls { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int Progress { get; set; } = 0;
        public string ProgressStatus { get; set; } = "Not Started";
    }
}
