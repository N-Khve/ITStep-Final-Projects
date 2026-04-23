namespace BookManager.Repository.Exceptions
{
    public class BookNotFoundException : BookManagerException
    {
        public int BookId { get; }

        public BookNotFoundException(int bookId) : base($"Book with ID {bookId} was not found")
        {
            BookId = bookId;
        }
    }
}