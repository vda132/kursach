using Library.Models;
using Library.Providers.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library.Forms.AddingInfoBookForms
{
    public partial class AddAuthor : Form
    {
        FactoryProvider provider = FactoryProvider.GetInstance();
        BookFund book;
        List<Author> authors = new List<Author>();
        public AddAuthor(BookFund book)
        {
            InitializeComponent();
            this.book = book;
            addAuthorBookButton.Enabled = false;
            authorsDataGridView.MultiSelect = false;
            authorsDataGridView.ColumnCount = 2;
            authorsDataGridView.Columns[0].Width = 30;
            authorsDataGridView.Columns[0].Name = "Номер автора";
            authorsDataGridView.Columns[1].Width = 60;
            authorsDataGridView.Columns[1].Name = "ФИО атовра";
            authors = provider.AuthorProvider.GetAll().ToList();
            LoadAuthors();
        }
        private void LoadAuthors()
        {
            authorsDataGridView.Rows.Clear();
            foreach (var author in authors)
            {
                authorsDataGridView.Rows.Add(author.AuthorID, author.AuthorName);
            }
        }

        private void authorsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            addAuthorBookButton.Enabled = true;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(authorSearchTextBox.Text))
            { 
                authors = provider.AuthorProvider.GetAll().Where(A => A.AuthorName.ToLower().Contains(authorSearchTextBox.Text.ToLower())).ToList();
                LoadAuthors();
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            authorSearchTextBox.Text = null;
            authors = provider.AuthorProvider.GetAll().ToList();
            LoadAuthors();
        }

        private void addAuthorBookButton_Click(object sender, EventArgs e)
        {
            Author tmpAuthor = authors[authorsDataGridView.CurrentCell.RowIndex];
            if (provider.AuthorBookFundProvider.GetAll().FirstOrDefault(A => A.AuthorID == tmpAuthor.AuthorID && A.BookID == book.BookID) != null)
            {
                MessageBox.Show("Такая информация уже есть.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<BookFund> tmpBooks = provider.BookFundProvider.GetAll().Where(A => A.BookID == book.BookID).ToList();
            AuthorBookFund tmpAuthorBook = new AuthorBookFund();
            foreach (var book in tmpBooks)
            {
                tmpAuthorBook.AuthorID = tmpAuthor.AuthorID;
                tmpAuthorBook.BookID = book.BookID;
                tmpAuthorBook.LibraryBookNO = book.LibraryBookNO;
                provider.AuthorBookFundProvider.Add(tmpAuthorBook);
            }
            this.Close();
        }
    }
}
