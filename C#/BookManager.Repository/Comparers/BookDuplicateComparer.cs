using BookManager.Repository.Models;
using System.Diagnostics.CodeAnalysis;

namespace BookManager.Repository.Comparers
{
    internal class BookDuplicateComparer : IEqualityComparer<Book>
    {
        public bool Equals(Book? x, Book? y)
        {
            if (x == null || y == null)
                return false;

            return string.Equals(x.Title, y.Title, StringComparison.OrdinalIgnoreCase) &&
                   string.Equals(x.Author, y.Author, StringComparison.OrdinalIgnoreCase) &&
                   x.PublicationDate == y.PublicationDate;
        }

        public int GetHashCode([DisallowNull] Book obj)
        {
            if (obj == null) return 0;

            return HashCode.Combine(
                obj.Title?.ToLowerInvariant(),
                obj.Author?.ToLowerInvariant(),
                obj.PublicationDate);
        }
    }
}