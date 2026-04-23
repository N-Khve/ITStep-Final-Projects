using BookManager.Service.Dto_s;
using BookManager.Service.Interfaces;

namespace BookManager.UI
{
    public partial class Form2 : Form
    {
        private readonly IBookService _service;

        public Form2(IBookService service)
        {
            InitializeComponent();
            _service = service;
        }

        private async void AddBookBtn_Click(object sender, EventArgs e)
        {
            var newBook = new CreateBookDto
            {
                Title = TitleText.Text,
                Author = AuthorText.Text,
                PublicationYear = PublicationYearText.Text
            };

            try
            {
                await _service.AddBookAsync(newBook);
                MessageBox.Show("Book added successfully!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}