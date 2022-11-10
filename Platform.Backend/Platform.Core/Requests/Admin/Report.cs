namespace Platform.Core.Requests.Admin
{
    public class Report
    {
        public double? OverallSuccessRate { get; set; }
        public List<SelectionSuccess> SelectionSuccessesRate { get; set; } = new();
    }
}
