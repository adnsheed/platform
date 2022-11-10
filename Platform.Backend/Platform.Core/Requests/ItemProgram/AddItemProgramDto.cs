namespace Platform.Core.Requests.ItemProgram
{
    public class AddItemProgramDto
    {
        public int ItemId { get; set; }

        public Guid ProgramId { get; set; }

        public int OrderNumber { get; set; }
    }
}
