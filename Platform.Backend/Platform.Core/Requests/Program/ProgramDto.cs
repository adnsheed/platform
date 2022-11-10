using Platform.Core.Requests.Item;
using Platform.Core.Requests.ItemProgram;

namespace Platform.Core.Requests.Program
{
    public class ProgramDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<ItemDto> Items { get; set; }
       
    }
}
