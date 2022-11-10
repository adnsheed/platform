using Platform.Common;

namespace Platform.Core.Requests.Student
{
    public class StudentParameters 
    {
        public string? Filter { get; set; }

        public string? Value { get; set; }

        public string? Sort { get; set; }

        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 5;
    }
}

