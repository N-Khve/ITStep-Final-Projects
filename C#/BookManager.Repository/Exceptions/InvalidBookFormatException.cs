namespace BookManager.Repository.Exceptions
{
    public class InvalidBookFormatException : BookManagerException
    {
        public InvalidBookFormatException(string message) : base(message)
        {
        }
    }
}