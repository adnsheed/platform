using Platform.Core.Entities;
using Platform.Core.Requests.ItemProgram;

namespace Platform.Core.Requests.Item
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ItemType Type { get; set; }

        public string? Description { get; set; }

        public int WorkHours { get; set; }

        public string? Urls { get; set; }

    }
}
