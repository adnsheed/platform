namespace Platform.Core.Requests.Admin
{
    public class SelectionSuccess
    {
        public Guid Id { get; set; }
        public string SelectionTitle { get; set; }
        public string ProgramTitle { get; set; }
        public double SuccessRate { get; set; }
    }
}
