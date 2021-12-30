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

namespace Library.Forms.BookInfoForm
{
    public partial class BookInfo : Form
    {
        FactoryProvider provider = FactoryProvider.GetInstance();
        BookFund book;
        public BookInfo(BookFund _book)
        {
            InitializeComponent();
            book = provider.BookFundProvider.GetAll().FirstOrDefault(A=>A.BookID==_book.BookID);
            bookNameLabel.Text = book.BookName;
            foreach (var author in book.AuthorBookFunds)
            {
                authorsTextBox.Text +=" "+ provider.AuthorProvider.GetAll().FirstOrDefault(A=>A.AuthorID==author.AuthorID).AuthorName + "\n";
            }
            foreach (var theme in book.ThemeBookFunds)
            {
                themeTextBox.Text +=" "+ provider.ThemeProvider.GetAll().FirstOrDefault(A=>A.ThemeId==theme.ThemeID).ThemeName +"\n";
            }
        }
    }
}
