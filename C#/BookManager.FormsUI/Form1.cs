using BookManager.Service.Dto_s;
using BookManager.Service.Interfaces;
using BookManager.UI;

namespace BookManager.FormsUI
{
    public partial class Form1 : Form
    {
        private readonly IBookService _bookService;

        public Form1(IBookService bookService)
        {
            InitializeComponent();
            _bookService = bookService;
        }

        public async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                var books = await _bookService.GetAllBooksAsync();
                bindingSource.DataSource = books;
                BooksGrid.AutoGenerateColumns = true;
                BooksGrid.DataSource = bindingSource;
                BooksGrid.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddBookBtn_Click(object sender, EventArgs e)
        {
            Form2 addBookform = new Form2(_bookService);
            addBookform.ShowDialog();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            string filterText = SearchBox.Text.Trim().ToLower();

            bindingSource.Filter = string.IsNullOrEmpty(filterText)
            ? null
            : $"Title LIKE '*{filterText}*'";

            BooksGrid.DataSource = bindingSource;
        }
    }
}