namespace BookManager.Repository.Exceptions
{
    internal class DuplicateBookException : BookManagerException
    {
        private string Title { get; }
        private string Author { get; }
        private DateOnly PublicationDate { get; }

        public DuplicateBookException(string title, string author, DateOnly publicationDate)
            : base($"Duplicate book: {title} by {author} ({publicationDate})")
        {
            Title = title;
            Author = author;
            PublicationDate = publicationDate;
        }
    }
}