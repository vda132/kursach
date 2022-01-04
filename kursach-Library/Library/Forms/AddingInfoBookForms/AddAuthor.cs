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
        //Создание экземпляра фабрики провайдеров для работы с провайдерами базы данных чтобы получить необходимые данные
        FactoryProvider provider = FactoryProvider.GetInstance();
        //Экземпляр книги 
        BookFund book;
        //список авторов
        List<Author> authors = new List<Author>();
        public AddAuthor(BookFund book)
        {
            InitializeComponent();
            //присвоение книги
            this.book = book;
            //настрока кнопки и data grid
            addAuthorBookButton.Enabled = false;
            authorsDataGridView.MultiSelect = false;
            authorsDataGridView.ColumnCount = 2;
            authorsDataGridView.Columns[0].Width = 30;
            authorsDataGridView.Columns[0].Name = "Номер автора";
            authorsDataGridView.Columns[1].Width = 60;
            authorsDataGridView.Columns[1].Name = "ФИО атовра";
            //получение всех авторов
            authors = provider.AuthorProvider.GetAll().ToList();
            //загрузка авторов в data grid
            LoadAuthors();
        }
        //метод для загрузки авторов в data grid
        private void LoadAuthors()
        {
            authorsDataGridView.Rows.Clear();
            foreach (var author in authors)
            {
                //загрзка по строково каждого автора
                authorsDataGridView.Rows.Add(author.AuthorID, author.AuthorName);
            }
        }
        //обработка события на выбранный елемент в data grid
        private void authorsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            //присвоение свойству значения
            addAuthorBookButton.Enabled = true;
        }
        //обработка нажатия на кнопку поиска автора
        private void searchButton_Click(object sender, EventArgs e)
        {
            //проверка на пустое поле
            if (!String.IsNullOrEmpty(authorSearchTextBox.Text))
            { 
                //поиск авторов по ФИО
                authors = provider.AuthorProvider.GetAll().Where(A => A.AuthorName.ToLower().Contains(authorSearchTextBox.Text.ToLower())).ToList();
                //загрузка авторов в data grid
                LoadAuthors();
            }
        }
        //обработка нажатия на кнопку сбрасывания
        private void resetButton_Click(object sender, EventArgs e)
        {
            //присвоение полю стандартоного значения
            authorSearchTextBox.Text = null;
            //получение всех авторов
            authors = provider.AuthorProvider.GetAll().ToList();
            //загрузка авторов в data grid
            LoadAuthors();
        }
        //обработка нажатия на кнопку добавления автора книге
        private void addAuthorBookButton_Click(object sender, EventArgs e)
        {
            //получение выбранного автора 
            Author tmpAuthor = authors[authorsDataGridView.CurrentCell.RowIndex];
            //проверка на то есть ли уже данный автор у книги
            if (provider.AuthorBookFundProvider.GetAll().FirstOrDefault(A => A.AuthorID == tmpAuthor.AuthorID && A.BookID == book.BookID) != null)
            {
                //вывод сообщения
                MessageBox.Show("Такая информация уже есть.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //получение книги и ее экземпляров
            List<BookFund> tmpBooks = provider.BookFundProvider.GetAll().Where(A => A.BookID == book.BookID).ToList();
            //создание экземпляра для добавления информации относительно книги и автора
            AuthorBookFund tmpAuthorBook = new AuthorBookFund();
            //добавление всем экземплярам книги данного автора
            foreach (var book in tmpBooks)
            {
                tmpAuthorBook.AuthorID = tmpAuthor.AuthorID;
                tmpAuthorBook.BookID = book.BookID;
                tmpAuthorBook.LibraryBookNO = book.LibraryBookNO;
                provider.AuthorBookFundProvider.Add(tmpAuthorBook);
            }
            //закрытие формы
            this.Close();
        }
    }
}
