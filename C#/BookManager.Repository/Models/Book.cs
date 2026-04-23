using BookManager.Repository.Exceptions;

namespace BookManager.Repository.Models
{
    public class Book
    {
        private int _id;

        private string _title;

        private string _author;

        private DateOnly _publicationDate;

        public int Id
        {
            get => _id;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Book ID must be a positive integer.", nameof(Id));
                _id = value;
            }
        }

        public string Title
        {
            get => _title;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new InvalidBookFormatException("Book title cannot be null or empty.");

                _title = value;
            }
        }

        public string Author
        {
            get => _author;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new InvalidBookFormatException("Book author cannot be null or empty.");

                if (value.All(char.IsDigit))
                    throw new InvalidBookFormatException("Book author cannot contain only digits.");

                _author = value;
            }
        }

        public DateOnly PublicationDate
        {
            get => _publicationDate;
            set
            {
                if (value > DateOnly.FromDateTime(DateTime.Now))
                    throw new InvalidBookFormatException("Publication date cannot be in the future.");

                _publicationDate = value;
            }
        }
    }
}