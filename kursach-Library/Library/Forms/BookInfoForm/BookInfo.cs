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
        //Создание экземпляра фабрики провайдеров для работы с провайдерами базы данных чтобы получить необходимые данные
        FactoryProvider provider = FactoryProvider.GetInstance();
        //Экземпляр книги 
        BookFund book;
        public BookInfo(BookFund _book)
        {
            InitializeComponent();
            //присвоение книги
            book = provider.BookFundProvider.GetAll().FirstOrDefault(A=>A.BookID==_book.BookID);
            //присвоение label`у название книги
            bookNameLabel.Text = book.BookName;
            foreach (var author in book.AuthorBookFunds)
            {
                //заполнение авторов книги
                authorsTextBox.Text +=" "+ provider.AuthorProvider.GetAll().FirstOrDefault(A=>A.AuthorID==author.AuthorID).AuthorName + "\n";
            }
            foreach (var theme in book.ThemeBookFunds)
            {
                //заполнение тем книги
                themeTextBox.Text +=" "+ provider.ThemeProvider.GetAll().FirstOrDefault(A=>A.ThemeId==theme.ThemeID).ThemeName +"\n";
            }
        }
    }
}
