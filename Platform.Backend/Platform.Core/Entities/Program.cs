namespace Platform.Core.Entities
{
    public class Program
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Selection>? Selections { get; set; } 
        public ICollection<Item> Items { get; set; } = new List<Item>();
        public List<ItemProgram> ItemPrograms { get; set; } = new();
    }
}
