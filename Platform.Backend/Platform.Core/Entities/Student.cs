namespace Platform.Core.Entities
{
    public class Student : User
    {
        public StudentStatus Status { get; set; }
        public Guid? SelectionId { get; set; }
        public Selection? Selection { get; set; }
        public List<Comment>? Comments { get; set; }
       
        public ICollection<ItemProgram> ItemPrograms { get; set; } = new List<ItemProgram>();
        public List<ItemStudent> ItemStudents { get; set; } = new List<ItemStudent>();
    }
}
