namespace BookManager.FormsUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            bindingSource = new BindingSource(components);
            BooksGrid = new DataGridView();
            AddBookBtn = new Button();
            SearchBox = new TextBox();
            SearchBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)bindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BooksGrid).BeginInit();
            SuspendLayout();
            // 
            // BooksGrid
            // 
            BooksGrid.AllowUserToAddRows = false;
            BooksGrid.AllowUserToDeleteRows = false;
            BooksGrid.AllowUserToResizeColumns = false;
            BooksGrid.AllowUserToResizeRows = false;
            BooksGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BooksGrid.AutoGenerateColumns = false;
            BooksGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            BooksGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            BooksGrid.BackgroundColor = SystemColors.Control;
            BooksGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            BooksGrid.DataSource = bindingSource;
            BooksGrid.Location = new Point(0, 50);
            BooksGrid.Name = "BooksGrid";
            BooksGrid.Size = new Size(785, 400);
            BooksGrid.TabIndex = 0;
            // 
            // AddBookBtn
            // 
            AddBookBtn.Location = new Point(698, 12);
            AddBookBtn.Name = "AddBookBtn";
            AddBookBtn.Size = new Size(75, 23);
            AddBookBtn.TabIndex = 1;
            AddBookBtn.Text = "Add Book";
            AddBookBtn.UseVisualStyleBackColor = true;
            AddBookBtn.Click += AddBookBtn_Click;
            // 
            // SearchBox
            // 
            SearchBox.ForeColor = SystemColors.MenuText;
            SearchBox.Location = new Point(12, 13);
            SearchBox.Name = "SearchBox";
            SearchBox.PlaceholderText = "Search by title";
            SearchBox.Size = new Size(278, 23);
            SearchBox.TabIndex = 2;
            // 
            // SearchBtn
            // 
            SearchBtn.Location = new Point(296, 13);
            SearchBtn.Name = "SearchBtn";
            SearchBtn.Size = new Size(75, 23);
            SearchBtn.TabIndex = 3;
            SearchBtn.Text = "Search";
            SearchBtn.UseVisualStyleBackColor = true;
            SearchBtn.Click += SearchBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(785, 450);
            Controls.Add(SearchBtn);
            Controls.Add(SearchBox);
            Controls.Add(AddBookBtn);
            Controls.Add(BooksGrid);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)bindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)BooksGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private BindingSource bindingSource;
        private DataGridView BooksGrid;
        private Button AddBookBtn;
        private TextBox SearchBox;
        private Button SearchBtn;
    }
}
