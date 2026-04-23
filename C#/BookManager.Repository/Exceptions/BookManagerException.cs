namespace BookManager.Repository.Exceptions
{
    public class BookManagerException : Exception
    {
        public BookManagerException()
        {
        }

        public BookManagerException(string? message) : base(message)
        {
        }

        public BookManagerException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}