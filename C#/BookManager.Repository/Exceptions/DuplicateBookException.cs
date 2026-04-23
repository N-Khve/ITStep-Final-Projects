namespace BookManager.Repository.Exceptions
{
    internal class DuplicateBookException : BookManagerException
    {
        public bookId { get; set; }
    }
}