namespace Platform.Core.Entities
{
    public class ItemStudent
    {
        public int? StudentId { get; set; }
        public Student? Student { get; set; }
        public int ItemProgramId { get; set; }
        public ItemProgram ItemProgram { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Progress { get; set; } = 0;
        public string ProgressStatus { get; set; } = "Not Started";
    }
}
