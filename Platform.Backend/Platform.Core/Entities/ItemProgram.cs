namespace Platform.Core.Entities
{
    public class ItemProgram
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }

        public Guid ProgramId { get; set; }
        public Program Program { get; set; }

        public int OrderNumber { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();
        public List<ItemStudent> ItemStudents { get; set; } = new List<ItemStudent>();
    }
}
