using BookManager.Service.Interfaces;

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
            var books = await _bookService.GetAllBooksAsync();
            bindingSource.DataSource = books;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}