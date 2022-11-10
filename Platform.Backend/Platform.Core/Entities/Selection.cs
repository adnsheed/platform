namespace Platform.Core.Entities
{
    public class Selection
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public SelectionStatus Status { get; set; }
        public Guid ProgramId { get; set; }
        public Program? Program { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
    }
}
