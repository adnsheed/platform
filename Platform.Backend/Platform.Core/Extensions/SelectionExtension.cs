using Platform.Core.Entities;

namespace Platform.Core.Extensions
{
    public static class SelectionExtension
    {
        public static IQueryable<Selection> Search(this IQueryable<Selection> selections, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return selections;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return selections.Where(e => e.Title.ToLower().Contains(lowerCaseTerm));
        }
    }
}
