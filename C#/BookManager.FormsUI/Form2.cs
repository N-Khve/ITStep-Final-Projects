using BookManager.Service.Dto_s;
using BookManager.Service.Interfaces;

namespace BookManager.UI
{
    public partial class Form2 : Form
    {
        private readonly IBookService _service;

        private BindingSource _bindingSource;

        public Form2(IBookService service, BindingSource bs)
        {
            InitializeComponent();
            _service = service;
            _bindingSource = bs;
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