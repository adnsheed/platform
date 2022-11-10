using Platform.Core.Entities;

namespace Platform.Core.Requests.Item
{
    public class UpdateItemDto
    {
        public string Name { get; set; }

        public ItemType Type { get; set; }

        public string? Description { get; set; }

        public int WorkHours { get; set; }

        public string? Urls { get; set; }
    }
}
