namespace BookManager.Repository.Models
{
    public class Book
    {
        private int _id { get; set; }
        private string _title { get; set; }
        private string _author { get; set; }
        private DateOnly _publicationDate { get; set; }

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
                    throw new ArgumentException("Book title cannot be null or empty.", nameof(Title));

                if (value.All(char.IsDigit))
                    throw new ArgumentException("Book title cannot contain only digits.", nameof(Title));

                _title = value;
            }
        }

        public string Author
        {
            get => _author;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Book author cannot be null or empty.", nameof(Author));

                if (value.All(char.IsDigit))
                    throw new ArgumentException("Book author cannot contain only digits.", nameof(Author));

                _author = value;
            }
        }

        public DateOnly PublicationDate
        {
            get => _publicationDate;
            set
            {
                if (value > DateOnly.FromDateTime(DateTime.Now))
                    throw new ArgumentException("Publication date cannot be in the future.", nameof(PublicationDate));

                _publicationDate = value;
            }
        }
    }
}