namespace Platform.Core.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ItemType Type { get; set; }

        public string Description { get; set; }

        public int WorkHours { get; set; }

        public string? Urls { get; set; }

        public ICollection<Program> Programs { get; set; }

        public List<ItemProgram> ItemPrograms { get; set; }
    }
}
