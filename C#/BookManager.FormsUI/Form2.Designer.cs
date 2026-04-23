namespace BookManager.UI
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TitleLabel = new Label();
            TitleText = new TextBox();
            AuthorText = new TextBox();
            AuthorLabel = new Label();
            PublicationYearText = new TextBox();
            PublicationYearLabel = new Label();
            AddBookBtn = new Button();
            SuspendLayout();
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.Location = new Point(39, 29);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(29, 15);
            TitleLabel.TabIndex = 0;
            TitleLabel.Text = "Title";
            // 
            // TitleText
            // 
            TitleText.Location = new Point(39, 47);
            TitleText.Name = "TitleText";
            TitleText.Size = new Size(100, 23);
            TitleText.TabIndex = 1;
            // 
            // AuthorText
            // 
            AuthorText.Location = new Point(39, 103);
            AuthorText.Name = "AuthorText";
            AuthorText.Size = new Size(100, 23);
            AuthorText.TabIndex = 3;
            // 
            // AuthorLabel
            // 
            AuthorLabel.AutoSize = true;
            AuthorLabel.Location = new Point(39, 85);
            AuthorLabel.Name = "AuthorLabel";
            AuthorLabel.Size = new Size(44, 15);
            AuthorLabel.TabIndex = 2;
            AuthorLabel.Text = "Author";
            // 
            // PublicationYearText
            // 
            PublicationYearText.Location = new Point(39, 160);
            PublicationYearText.Name = "PublicationYearText";
            PublicationYearText.Size = new Size(100, 23);
            PublicationYearText.TabIndex = 5;
            // 
            // PublicationYearLabel
            // 
            PublicationYearLabel.AutoSize = true;
            PublicationYearLabel.Location = new Point(39, 142);
            PublicationYearLabel.Name = "PublicationYearLabel";
            PublicationYearLabel.Size = new Size(92, 15);
            PublicationYearLabel.TabIndex = 4;
            PublicationYearLabel.Text = "Publication Year";
            // 
            // AddBookBtn
            // 
            AddBookBtn.Location = new Point(39, 201);
            AddBookBtn.Name = "AddBookBtn";
            AddBookBtn.Size = new Size(92, 23);
            AddBookBtn.TabIndex = 6;
            AddBookBtn.Text = "Add Book";
            AddBookBtn.UseVisualStyleBackColor = true;
            AddBookBtn.Click += AddBookBtn_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(181, 236);
            Controls.Add(AddBookBtn);
            Controls.Add(PublicationYearText);
            Controls.Add(PublicationYearLabel);
            Controls.Add(AuthorText);
            Controls.Add(AuthorLabel);
            Controls.Add(TitleText);
            Controls.Add(TitleLabel);
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TitleLabel;
        private TextBox TitleText;
        private TextBox AuthorText;
        private Label AuthorLabel;
        private TextBox PublicationYearText;
        private Label PublicationYearLabel;
        private Button AddBookBtn;
    }
}