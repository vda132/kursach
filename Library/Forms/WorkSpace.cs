using Library.Forms.AddingInfoBookForms;
using Library.Forms.BookInfoForm;
using Library.Models;
using Library.Models.PK;
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

namespace Library.Forms
{
    public partial class WorkSpace : Form
    {
        FactoryProvider provider = FactoryProvider.GetInstance();
        List<Users> users = new List<Users>();
        List<Author> authors = new List<Author>();
        List<Theme> themes = new List<Theme>();
        List<BookFund> books = new List<BookFund>();
        List<Reader> readers = new List<Reader>();
        List<Reader> extraditionReaders = new List<Reader>();
        List<BookFund> extraditionBooks = new List<BookFund>();
        List<Extradition> extraditions = new List<Extradition>();
        List<Extradition> readerHistory = new List<Extradition>();
        List<BookFund> booksCatalogue = new List<BookFund>();
        List<BookFund> booksCatalogueForInfo = new List<BookFund>();
        Form previousForm;
        Users user;
        public WorkSpace(Form form, Users _user)
        {
            InitializeComponent();
            this.user = _user;
            previousForm = form;
            UserLogic();
        }

        private void UserLogic()
        {
            switch (user.UserType)
            {
                case "Админ БД":
                    AdminProperties();
                    break;
                case "Библиотекарь":
                    LibrarianProperties();
                    break;
                case "Читатель":
                    ReaderProperties();
                    break;
            }
        }
        private void AdminProperties()
        {
            this.Size = new Size(700, 400);
            ExitButton.Location = new Point(600, 20);
            tabControl1.Visible = true;
            loginTextBox.ReadOnly = true;
            passwordTextBox.ReadOnly = true;
            dataGridView1.MultiSelect = false;
            ApplyChanges.Visible = false;
            DeleteLibrarianButton.Enabled = false;
            loginTextBox.Text = user.UserLogin;
            passwordTextBox.Text = user.UserPassword;
            dataGridView1.Columns[0].Width = 90;
            dataGridView1.Columns[1].Width = 90;
            dataGridView1.Columns[2].Width = 120;
            LoadData();
        }

        private void LibrarianProperties()
        {
            tabControl2.Visible = true;
            libLogin.Text = user.UserLogin;
            libPassword.Text = user.UserPassword;
            authorDataGridView.MultiSelect = false;
            bookDataGridView.MultiSelect = false;
            reportDataGridView.MultiSelect = false;
            booksDataGridView.MultiSelect = false;
            readersDataGridView.MultiSelect = false;
            readerDataGridView.MultiSelect = false;
            themeDataGridView.MultiSelect = false;
            DeleteAuthorButton.Enabled = false;
            DeleteBookButton.Enabled = false;
            deleteReaderButton.Enabled = false;
            addBookAuthorbutton.Enabled = false;
            addBookThemeButton.Enabled = false;
            authorDataGridView.ColumnCount = 2;
            authorDataGridView.Columns[0].Width = 50;
            authorDataGridView.Columns[0].Name = "Номер автора";
            authorDataGridView.Columns[1].Width = 90;
            authorDataGridView.Columns[1].Name = "ФИО автора";
            themeDataGridView.ColumnCount = 1;
            themeDataGridView.Columns[0].Width = 120;
            themeDataGridView.Columns[0].Name = "Название темы";
            bookDataGridView.ColumnCount = 4;
            bookDataGridView.Columns[0].Width = 50;
            bookDataGridView.Columns[0].Name = "Номер книги";
            bookDataGridView.Columns[1].Width = 80;
            bookDataGridView.Columns[1].Name = "Название книги";
            bookDataGridView.Columns[2].Width = 80;
            bookDataGridView.Columns[2].Name = "Дата публикации";
            bookDataGridView.Columns[3].Width = 50;
            bookDataGridView.Columns[3].Name = "Кол-во страниц";
            readerDataGridView.ColumnCount = 6;
            readerDataGridView.Columns[0].Width = 40;
            readerDataGridView.Columns[0].Name = "Билет";
            readerDataGridView.Columns[1].Width = 40;
            readerDataGridView.Columns[1].Name = "ФИО";
            readerDataGridView.Columns[2].Width = 70;
            readerDataGridView.Columns[2].Name = "Адресс";
            readerDataGridView.Columns[3].Width = 60;
            readerDataGridView.Columns[3].Name = "Телефон";
            readerDataGridView.Columns[4].Width = 50;
            readerDataGridView.Columns[4].Name = "Логин";
            readerDataGridView.Columns[5].Width = 50;
            readerDataGridView.Columns[5].Name = "Пароль";
            readersDataGridView.ColumnCount = 2;
            readersDataGridView.Columns[0].Width = 45;
            readersDataGridView.Columns[0].Name = "Билет";
            readersDataGridView.Columns[1].Width = 70;
            readersDataGridView.Columns[1].Name = "ФИО";
            booksDataGridView.ColumnCount = 5;
            booksDataGridView.Columns[0].Width = 50;
            booksDataGridView.Columns[0].Name = "Номер книги";
            booksDataGridView.Columns[1].Width = 80;
            booksDataGridView.Columns[1].Name = "Номер экземпляра";
            booksDataGridView.Columns[2].Width = 75;
            booksDataGridView.Columns[2].Name = "Название";
            booksDataGridView.Columns[3].Name = "Дата публикации";
            booksDataGridView.Columns[3].Width = 70;
            booksDataGridView.Columns[4].Width = 60;
            booksDataGridView.Columns[4].Name = "Статус";
            reportDataGridView.ColumnCount = 8;
            reportDataGridView.Columns[0].Width = 40;
            reportDataGridView.Columns[0].Name = "Билет";
            reportDataGridView.Columns[1].Width = 40;
            reportDataGridView.Columns[1].Name = "ФИО";
            reportDataGridView.Columns[2].Width = 50;
            reportDataGridView.Columns[2].Name = "Номер книги";
            reportDataGridView.Columns[3].Width = 50;
            reportDataGridView.Columns[3].Name = "Номер экземпляра";
            reportDataGridView.Columns[4].Width = 75;
            reportDataGridView.Columns[4].Name = "Название";
            reportDataGridView.Columns[5].Width = 75;
            reportDataGridView.Columns[5].Name = "Дата выдачи";
            reportDataGridView.Columns[6].Width = 75;
            reportDataGridView.Columns[6].Name = "Дата возврата";
            reportDataGridView.Columns[7].Width = 75;
            reportDataGridView.Columns[7].Name = "Информация";
            chart1.Series[0].Name = "";
            bookSearchReportButton.Enabled = false;
            ApplyLibButton.Visible = false;
            beginDateTimePicker.Enabled = false;
            beginDateTimePicker.Value = DateTime.Now;
            LoadThemes();
            LoadAuthors();
            LoadBooks();
            LoadReaders();
        }

        private void ReaderProperties()
        {
            tabControl3.Visible = true;
            readerLoginTextBox.Text = user.UserLogin;
            readerPassTextBox.Text = user.UserPassword;
            editReaderButton.Enabled = true;
            applyChangesReaderButton.Visible = false;
            int value;
            int.TryParse(string.Join("", user.UserLogin.Where(c => char.IsDigit(c))), out value);
            Reader reader = provider.ReaderProvider.GetAll().FirstOrDefault(A => A.ReaderNo == value);
            readerHistory = provider.ExtraditionProvider.GetAll().Where(A => A.ReaderNo == reader.ReaderNo).ToList();
            bookHistoryDataGridView.ColumnCount = 6;
            bookHistoryDataGridView.Columns[0].Width = 50;
            bookHistoryDataGridView.Columns[0].Name = "Номер книги";
            bookHistoryDataGridView.Columns[1].Width = 50;
            bookHistoryDataGridView.Columns[1].Name = "Номер экземпляра";
            bookHistoryDataGridView.Columns[2].Width = 75;
            bookHistoryDataGridView.Columns[2].Name = "Название";
            bookHistoryDataGridView.Columns[3].Width = 75;
            bookHistoryDataGridView.Columns[3].Name = "Дата выдачи";
            bookHistoryDataGridView.Columns[4].Width = 75;
            bookHistoryDataGridView.Columns[4].Name = "Дата возврата";
            bookHistoryDataGridView.Columns[5].Width = 75;
            bookHistoryDataGridView.Columns[5].Name = "Информация";
            bookHistoryDataGridView.Rows.Clear();
            foreach (var extradition in readerHistory)
            {
                bookHistoryDataGridView.Rows.Add(extradition.BookID, extradition.LibraryBookNO, extradition.BookFund.BookName, extradition.DateOfExtradition.ToShortDateString(), extradition.DateOfReturn.ToShortDateString(), extradition.Information);
            }
            booksCatalogueDataGridView.ColumnCount = 5;
            booksCatalogueDataGridView.Columns[0].Width = 50;
            booksCatalogueDataGridView.Columns[0].Name = "Номер книги";
            booksCatalogueDataGridView.Columns[1].Width = 80;
            booksCatalogueDataGridView.Columns[1].Name = "Название книги";
            booksCatalogueDataGridView.Columns[2].Width = 80;
            booksCatalogueDataGridView.Columns[2].Name = "Дата публикации";
            booksCatalogueDataGridView.Columns[3].Width = 50;
            booksCatalogueDataGridView.Columns[3].Name = "Кол-во страниц";
            booksCatalogueDataGridView.Columns[4].Width = 75;
            booksCatalogueDataGridView.Columns[4].Name = "Автор";
        }
        private void LoadData()
        {
            dataGridView1.Rows.Clear();
            users = provider.UserProvider.GetAll().Where(A=>A.UserType=="Библиотекарь").ToList();
            foreach (var user in users)
            {
                dataGridView1.Rows.Add(user.UserLogin, user.UserPassword,user.UserType);
            }
        }

        private void LoadAuthors()
        {
            authorDataGridView.Rows.Clear();
            authors = provider.AuthorProvider.GetAll().ToList();
            foreach (var author in authors)
            {
                authorDataGridView.Rows.Add(author.AuthorID, author.AuthorName);
            }
        }

        private void LoadThemes()
        {
            themeDataGridView.Rows.Clear();
            themes = provider.ThemeProvider.GetAll().ToList();
            foreach (var theme in themes)
            {
                themeDataGridView.Rows.Add(theme.ThemeName);
            }
        }

        private void LoadBooks()
        {
            bookDataGridView.Rows.Clear();
            List<int> ids = provider.BookFundProvider.GetAll().Select(A => A.BookID).Distinct().ToList();
            foreach(var id in ids)
            {
                books.Add(provider.BookFundProvider.GetAll().FirstOrDefault(A => A.BookID == id));
            }
            foreach (var book in books)
            {
                bookDataGridView.Rows.Add(book.BookID, book.BookName, book.DateOfPublication.ToShortDateString(), book.Capacity);
            }
        }

        private void LoadReaders()
        {
            readerDataGridView.Rows.Clear();
            readers = provider.ReaderProvider.GetAll().ToList();
            foreach (var reader in readers)
            {
                var user = provider.UserProvider.GetAll().FirstOrDefault(A => A.UserLogin == "Reader" + reader.ReaderNo.ToString());
                readerDataGridView.Rows.Add(reader.ReaderNo, reader.ReaderName, reader.Adress, reader.Phone, user.UserLogin, user.UserPassword);
            }
        }

        private void LoadReadersExtradition()
        {
            readersDataGridView.Rows.Clear();
            foreach (var reader in extraditionReaders)
            {
                readersDataGridView.Rows.Add(reader.ReaderNo, reader.ReaderName);
            }
        }

        private void LoadBooksExtradition()
        {
            booksDataGridView.Rows.Clear();
            foreach (var book in extraditionBooks)
            {
                if (book.BookStatus)
                    booksDataGridView.Rows.Add(book.BookID, book.LibraryBookNO, book.BookName, book.DateOfPublication, "Есть в наличии");
                else
                    booksDataGridView.Rows.Add(book.BookID, book.LibraryBookNO, book.BookName, book.DateOfPublication, "Нет в наличии");
            }
        }

        private void LoadExtraditions()
        {
            reportDataGridView.Rows.Clear();
            foreach (var extradition in extraditions)
            {
                reportDataGridView.Rows.Add(extradition.ReaderNo, extradition.Reader.ReaderName, extradition.BookID, extradition.LibraryBookNO, extradition.BookFund.BookName, extradition.DateOfExtradition.ToShortDateString(), extradition.DateOfReturn.ToShortDateString(), extradition.Information);
            }
        }

        private void Reset()
        {
            libLoginTextBox.Text = null;
            libPasswordTextBox.Text = null;
            libPassword.Text = null;
            libLogin.Text = null;
            authorTextBox.Text = null;
            themeTextBox.Text = null;
            idBookTextBox.Text = null;
            bookNameTextBox.Text = null;
            bookPublicationDateTimePicker.Value = DateTime.Now;
            bookCapacityTextBox.Text = null;
            bookAmountTextBox.Text = null;
            readerNameTextBox.Text = null;
            readerPasswordTextBox.Text = null;
            readerExtraditionTextBox.Text = null;
            bookExtraditionTextBox.Text = null;
            beginDateTimePicker.Value = DateTime.Now;
            endDateTimePicker.Value = DateTime.Now;
            readerReportTextBox.Text = null;
            bookReportTextBox.Text = null;
            adressTextBox.Text = null;
            phoneTextBox.Text = null;
            booksDataGridView.Rows.Clear();
            readersDataGridView.Rows.Clear();
            reportDataGridView.Rows.Clear();
        }

        private void editInfoButton_Click(object sender, EventArgs e)
        {
            editInfoButton.Enabled = false;
            loginTextBox.ReadOnly = false;
            passwordTextBox.ReadOnly = false;
            ApplyChanges.Visible = true;
        }

        private void ApplyChanges_Click(object sender, EventArgs e)
        {
            editInfoButton.Enabled = true;
            loginTextBox.ReadOnly = true;
            passwordTextBox.ReadOnly = true;
            dataGridView1.MultiSelect = false;
            ApplyChanges.Visible = false;
            if (String.IsNullOrEmpty(loginTextBox.Text) || String.IsNullOrEmpty(passwordTextBox.Text))
            {
                MessageBox.Show("Поля должны быть заполнены!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var tmpUser = provider.UserProvider.GetAll().FirstOrDefault(A => A.IdUser == user.IdUser);
            tmpUser.UserLogin = loginTextBox.Text;
            tmpUser.UserPassword = passwordTextBox.Text;
            if (provider.UserProvider.GetAll().FirstOrDefault(A => A.IdUser != tmpUser.IdUser && A.UserLogin == tmpUser.UserLogin) != null)
            {
                MessageBox.Show("Такой логин уже есть!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            provider.UserProvider.Update(tmpUser.IdUser,tmpUser);
            MessageBox.Show("Информация сохранена.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ApplyChanges.Visible = false;
            editInfoButton.Enabled = true;
            loginTextBox.ReadOnly = true;
            passwordTextBox.ReadOnly = true;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Вы точно хотите вернуться на страницу авторизации? ", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                previousForm.Show();
            }
        }

        private void AddLibrarianbutton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(libLoginTextBox.Text) || String.IsNullOrEmpty(libPasswordTextBox.Text))
            {
                MessageBox.Show("Поля должны быть заполнены!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (provider.UserProvider.GetAll().FirstOrDefault(A => A.UserLogin == libLoginTextBox.Text) != null)
            {
                MessageBox.Show("Такой логин уже есть!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Users tmpUser = new Users
            {
                UserLogin = libLoginTextBox.Text,
                UserPassword = libPasswordTextBox.Text,
                UserType = "Библиотекарь"
            };
            provider.UserProvider.Add(tmpUser);
            MessageBox.Show("Библиотекарь добавлен.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData();
            Reset();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            DeleteLibrarianButton.Enabled=true;
        }

        private void DeleteLibrarianButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Вы точно хотите удалить данного библиотекаря? ", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Users tmpUser = users[dataGridView1.CurrentCell.RowIndex];
                provider.UserProvider.Delete(tmpUser.IdUser);
                LoadData();
            }
        }

        private void EditLibButton_Click(object sender, EventArgs e)
        {
            EditLibButton.Enabled = false;
            ApplyLibButton.Visible = true;
            libPassword.ReadOnly = false;
            libLogin.ReadOnly = false;
        }

        private void ApplyLibButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(libPassword.Text) || String.IsNullOrEmpty(libLogin.Text))
            {
                MessageBox.Show("Поля должны быть заполнены!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var tmpUser = provider.UserProvider.GetAll().FirstOrDefault(A => A.IdUser == user.IdUser);
            tmpUser.UserLogin = libLogin.Text;
            tmpUser.UserPassword = libPassword.Text;
            if (provider.UserProvider.GetAll().FirstOrDefault(A => A.IdUser != tmpUser.IdUser && A.UserLogin == tmpUser.UserLogin) != null)
            {
                MessageBox.Show("Такой логин уже есть!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            provider.UserProvider.Update(tmpUser.IdUser, tmpUser);
            MessageBox.Show("Информация сохранена.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            EditLibButton.Enabled = true;
            ApplyLibButton.Visible = false;
            libPassword.ReadOnly = true;
            libLogin.ReadOnly = true;
        }

        private void AddAuthorButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(authorTextBox.Text))
            {
                MessageBox.Show("Поля должны быть заполнены!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var tmpAuthor = new Author()
            {
                AuthorName=authorTextBox.Text
            };
            provider.AuthorProvider.Add(tmpAuthor);
            LoadAuthors();
            Reset();
        }

        private void authorDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            DeleteAuthorButton.Enabled = true;
        }

        private void DeleteAuthorButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Вы точно хотите удалить данного автора? ", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes && authorDataGridView.CurrentCell.RowIndex != authors.Count)
            {
                Author tmpAuthor = authors[authorDataGridView.CurrentCell.RowIndex];
                provider.AuthorProvider.Delete(tmpAuthor.AuthorID);
                LoadData();
            }
        }

        private void AddThemeButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(themeTextBox.Text))
            {
                MessageBox.Show("Поля должны быть заполнены!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Theme tmpTheme = new Theme()
            {
                ThemeName = themeTextBox.Text
            };
            provider.ThemeProvider.Add(tmpTheme);
            LoadThemes();
            Reset();
        }

     

        private void AddBookButton_Click(object sender, EventArgs e)
        {
            int idBook = 0;
            int bookCapacity = 0;
            int bookAmount = 0;
            if (String.IsNullOrEmpty(idBookTextBox.Text) || String.IsNullOrEmpty(bookNameTextBox.Text) || String.IsNullOrEmpty(bookCapacityTextBox.Text)||String.IsNullOrEmpty(bookAmountTextBox.Text))
            {
                MessageBox.Show("Поля должны быть заполнены!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(idBookTextBox.Text, out idBook) || !int.TryParse(bookCapacityTextBox.Text, out bookCapacity)||!int.TryParse(bookAmountTextBox.Text, out bookAmount))
            {
                MessageBox.Show("Неверный формат данных!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (bookPublicationDateTimePicker.Value > DateTime.Now)
            {
                MessageBox.Show("Выбранная дата не может быть больше сегодняшней!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            BookFund tmpBookCheck = provider.BookFundProvider.GetAll().FirstOrDefault(A => A.BookID == idBook);
            if (tmpBookCheck != null && tmpBookCheck.BookName != bookNameTextBox.Text)
            {
                MessageBox.Show("Данный номер занят под другой книгой!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            BookFund tmpBook = new BookFund()
            {
                BookID = idBook,
                BookName = bookNameTextBox.Text,
                DateOfPublication = bookPublicationDateTimePicker.Value,
                Capacity = bookCapacity,
                BookStatus = true
            };
            while (bookAmount != 0)
            {
                provider.BookFundProvider.Add(tmpBook);
                --bookAmount;
            }
            LoadBooks();
            Reset();
        }
        private void bookDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            DeleteBookButton.Enabled = true;
            addBookAuthorbutton.Enabled = true;
            addBookThemeButton.Enabled = true;
        }

        private void DeleteBookButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Вы точно хотите удалить все экземпляры данной книги? ", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes && bookDataGridView.CurrentCell.RowIndex != books.Count)
            {
                BookFund tmpBook = new BookFund();
                tmpBook = books[bookDataGridView.CurrentCell.RowIndex];
                BookFundPK pk = new BookFundPK()
                {
                    BookID = tmpBook.BookID,
                    LibraryBookNO = tmpBook.LibraryBookNO
                };
                provider.BookFundProvider.Delete(pk);
                LoadData();
            }
        }

        private void addBookAuthorbutton_Click(object sender, EventArgs e)
        {
            if (books.Count == 0 || bookDataGridView.CurrentCell.RowIndex==books.Count)
            {
                MessageBox.Show("Выберите какуюто книгу", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            BookFund book = new BookFund();
            book = books[bookDataGridView.CurrentCell.RowIndex];
            new AddAuthor(book).Show();
        }

        private void addBookThemeButton_Click(object sender, EventArgs e)
        {
            if (books.Count == 0 || bookDataGridView.CurrentCell.RowIndex == books.Count)
            {
                MessageBox.Show("Выберите какуюто книгу", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            BookFund book = new BookFund();
            book = books[bookDataGridView.CurrentCell.RowIndex];
            new AddTheme(book).Show();
        }

        private void AddReaderButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(readerNameTextBox.Text) || String.IsNullOrEmpty(readerPasswordTextBox.Text)||
                String.IsNullOrEmpty(adressTextBox.Text) ||
                String.IsNullOrEmpty(phoneTextBox.Text))
            {
                MessageBox.Show("Поля должны быть заполнены!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (phoneTextBox.Text.Length != 13)
            {
                MessageBox.Show("Вы ввели слишком некоректный номер телефона.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                return;
            }
            try
            {
                provider.ReaderProvider.Add(new Models.Reader
                {
                    ReaderName = readerNameTextBox.Text,
                    Adress = adressTextBox.Text,
                    Phone = phoneTextBox.Text
                });
                int id = provider.ReaderProvider.GetAll().Max(A => A.ReaderNo);
                provider.UserProvider.Add(new Models.Users
                {
                    UserLogin = "Reader"+id.ToString(),
                    UserPassword = readerPasswordTextBox.Text,
                    UserType = "Читатель"
                });
                MessageBox.Show("Добавление успешно!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Вы ввели некоректные данные.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadReaders();
            Reset();
        }

        private void readerDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            deleteReaderButton.Enabled = true;
        }

        private void deleteReaderButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Вы точно хотите удалить данного читателя? ", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes&& readerDataGridView.CurrentCell.RowIndex!=readers.Count)
            {
                Reader tmpReader = new Reader();
                tmpReader = readers[readerDataGridView.CurrentCell.RowIndex];
                var user = provider.UserProvider.GetAll().FirstOrDefault(A => A.UserLogin == "Reader" + tmpReader.ReaderNo.ToString());
                provider.UserProvider.Delete(user.IdUser);
                provider.ReaderProvider.Delete(tmpReader.ReaderNo);
                LoadReaders();
            }
        }

        private void SearchReaderButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(readerExtraditionTextBox.Text))
            {
                MessageBox.Show("Введите номер билета", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            extraditionReaders = provider.ReaderProvider.GetAll().Where(A => A.ReaderNo.ToString().ToLower().Contains(readerExtraditionTextBox.Text.ToLower())).ToList();
            if (extraditionReaders.Count > 0)
            {
                LoadReadersExtradition();
            }
            else
            {
                return;
            }
        }

        private void SearchBookButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(bookExtraditionTextBox.Text))
            {
                MessageBox.Show("Введите название книги", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            extraditionBooks = provider.BookFundProvider.GetAll().Where(A => A.BookName.ToLower().Contains(bookExtraditionTextBox.Text.ToLower())).ToList();
            if (extraditionBooks.Count > 0)
            {
                LoadBooksExtradition();
            }
            else
                return;
        }

        private void resetExtraditionbutton_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void ExtraditionButton_Click(object sender, EventArgs e)
        {
            if (extraditionReaders.Count==0 || extraditionBooks.Count==0)
            {
                MessageBox.Show("Выберите и читателя и книгу", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (endDateTimePicker.Value < beginDateTimePicker.Value)
            {
                MessageBox.Show("Дата возврата не может быть меньше даты выдания", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Reader tmpReader = extraditionReaders[readersDataGridView.CurrentCell.RowIndex];
            BookFund tmpBook = extraditionBooks[booksDataGridView.CurrentCell.RowIndex];
            if (!tmpBook.BookStatus)
            {
                MessageBox.Show("Данная книга недоступна.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Extradition tmpExtradition = new Extradition()
            {
                ReaderNo=tmpReader.ReaderNo,
                BookID=tmpBook.BookID,
                LibraryBookNO=tmpBook.LibraryBookNO,
                DateOfExtradition = beginDateTimePicker.Value,
                DateOfReturn = endDateTimePicker.Value,
                Information = "Не вернута"
            };
            if (provider.ExtraditionProvider.Get(new Models.PK.ExtraditionPK { BookID = tmpExtradition.BookID, LibraryBookNO = tmpExtradition.LibraryBookNO, DateOfExtradition = tmpExtradition.DateOfExtradition }) != null)
            {
                MessageBox.Show("Такая информация уже существует", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            tmpBook.BookStatus = false;
            BookFundPK bookFundPK = new BookFundPK()
            {
                BookID=tmpBook.BookID,
                LibraryBookNO=tmpBook.LibraryBookNO
            };
            provider.BookFundProvider.Update(bookFundPK,tmpBook);
            provider.ExtraditionProvider.Add(tmpExtradition);
            Reset();
        }

        private void readerSearchReportButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(readerReportTextBox.Text))
            {
                MessageBox.Show("Введите номер билета", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            extraditions = provider.ExtraditionProvider.GetAll().Where(A => A.ReaderNo.ToString().ToLower().Contains(readerReportTextBox.Text.ToLower())).ToList();
            if (extraditions.Count > 0)
            { 
                LoadExtraditions();
                bookSearchReportButton.Enabled = true;   
            }
            else
                return;
        }

        private void bookSearchReportButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(bookReportTextBox.Text))
            {
                MessageBox.Show("Введите название книги", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            extraditions = provider.ExtraditionProvider.GetAll().Where(A => A.BookFund.BookName.ToLower().Contains(bookReportTextBox.Text.ToLower())).ToList();
            if (extraditions.Count > 0)
            {
                LoadExtraditions();
            }
            else
            {
                MessageBox.Show("Данная книга не выдавалась", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void BackBookButton_Click(object sender, EventArgs e)
        {
            if (extraditions.Count == 0)
            {
                MessageBox.Show("Выберите какуюто информацию", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Extradition tmpExtradition = extraditions[reportDataGridView.CurrentCell.RowIndex];
            if (tmpExtradition.Information == "Вернута")
            {
                MessageBox.Show("Данная книга уже вернута.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            tmpExtradition.Information = "Вернута";
            tmpExtradition.BookFund.BookStatus = true;
            ExtraditionPK extraditionPK = new ExtraditionPK()
            {
                BookID=tmpExtradition.BookID,
                LibraryBookNO=tmpExtradition.LibraryBookNO,
                DateOfExtradition=tmpExtradition.DateOfExtradition
            };
            BookFundPK bookFundPK = new BookFundPK()
            {
                BookID=tmpExtradition.BookFund.BookID,
                LibraryBookNO = tmpExtradition.LibraryBookNO
            };
            provider.BookFundProvider.Update(bookFundPK,tmpExtradition.BookFund);
            provider.ExtraditionProvider.Update(extraditionPK, tmpExtradition);
            Reset();
        }

        private void bookInfoButton_Click(object sender, EventArgs e)
        {
            if (books.Count == 0|| bookDataGridView.CurrentCell==null || bookDataGridView.CurrentCell.RowIndex==books.Count)
            {
                MessageBox.Show("Выберите какуюто книгу", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            BookFund tmpBook = books[bookDataGridView.CurrentCell.RowIndex];
            new BookInfo(tmpBook).Show();
        }

        private void booksExtradInfoButton_Click(object sender, EventArgs e)
        {
            if (extraditionBooks.Count == 0 || booksDataGridView.CurrentCell == null || booksDataGridView.CurrentCell.RowIndex == extraditionBooks.Count)
            {
                MessageBox.Show("Выберите какуюто книгу", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            BookFund tmpBook = extraditionBooks[booksDataGridView.CurrentCell.RowIndex];
            new BookInfo(tmpBook).Show();
        }

        private void booksReportInfoButton_Click(object sender, EventArgs e)
        {
            if (extraditions.Count == 0 || reportDataGridView.CurrentCell == null || reportDataGridView.CurrentCell.RowIndex == extraditions.Count)
            {
                MessageBox.Show("Выберите какуюто книгу", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            BookFund tmpBook = provider.BookFundProvider.GetAll().FirstOrDefault(A=>A.BookID == extraditions[reportDataGridView.CurrentCell.RowIndex].BookID);
            new BookInfo(tmpBook).Show();
        }

        private void extraditionStatisticButton_Click(object sender, EventArgs e)
        {
            List<KeyValuePair<string, int>> statistics = Statistic.Statistic.GetExtraditionStatistic();
            chart1.DataSource = statistics;
            chart1.Series[0].Name = "Название книги";
            chart1.Series[0].XValueMember = "Key";
            chart1.Series[0].YValueMembers = "Value";
            chart1.DataBind();
        }

        private void visitingStatisticButton_Click(object sender, EventArgs e)
        {
            List<KeyValuePair<string, int>> visitings = Statistic.Statistic.GetVisitingStatistic();
            chart1.DataSource = visitings;
            chart1.Series[0].Name = "ФИО";
            chart1.Series[0].XValueMember = "Key";
            chart1.Series[0].YValueMembers = "Value";
            chart1.DataBind();
        }

        private void themeStatisticButton_Click(object sender, EventArgs e)
        {
            List<KeyValuePair<string, int>> themes = Statistic.Statistic.GetThemeStatistic();
            chart1.DataSource = themes;
            chart1.Series[0].Name = "Тематика";
            chart1.Series[0].XValueMember = "Key";
            chart1.Series[0].YValueMembers = "Value";
            chart1.DataBind();
        }

        private void bookHistoryInfoButton_Click(object sender, EventArgs e)
        {
            if (readerHistory.Count == 0 || bookHistoryDataGridView.CurrentCell == null || bookHistoryDataGridView.CurrentCell.RowIndex == readerHistory.Count)
            {
                MessageBox.Show("Выберите какуюто книгу", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            BookFund tmpBook = provider.BookFundProvider.GetAll().FirstOrDefault(A => A.BookID == readerHistory[bookHistoryDataGridView.CurrentCell.RowIndex].BookID);
            new BookInfo(tmpBook).Show();
        }

        private void editReaderButton_Click(object sender, EventArgs e)
        {
            editReaderButton.Enabled = false;
            applyChangesReaderButton.Visible = true;
            readerPassTextBox.ReadOnly = false;
        }

        private void applyChangesReaderButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(readerPassTextBox.Text))
            {
                MessageBox.Show("Поля должны быть заполнены!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var tmpUser = provider.UserProvider.GetAll().FirstOrDefault(A => A.IdUser == user.IdUser);
            tmpUser.UserPassword = readerPassTextBox.Text;
            provider.UserProvider.Update(tmpUser.IdUser, tmpUser);
            MessageBox.Show("Информация сохранена.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            editReaderButton.Enabled = true;
            applyChangesReaderButton.Visible = false;
            readerPassTextBox.ReadOnly = true;
        }

        private void alphaviteButton_Click(object sender, EventArgs e)
        {
            booksCatalogueForInfo.Clear();
            booksCatalogueDataGridView.ColumnCount = 5;
            booksCatalogueDataGridView.Columns[4].Name = "Автор";
            booksCatalogueDataGridView.Rows.Clear();
            booksCatalogue.Clear();
            List<int> ids = provider.BookFundProvider.GetAll().Select(A => A.BookID).Distinct().ToList();
            foreach (var id in ids)
            {
                booksCatalogue.Add(provider.BookFundProvider.GetAll().FirstOrDefault(A => A.BookID == id));
            }
            var tmp = booksCatalogue.Join(provider.AuthorBookFundProvider.GetAll(),
                A => A.BookID,
                B => B.BookID,
                (A, B) => new { BookName = A.BookName, DateOfPublication = A.DateOfPublication, Capacity = A.Capacity, BookID = A.BookID, AuthorID = B.AuthorID });
            var tmp2 = tmp.Join(provider.AuthorProvider.GetAll(),
                A => A.AuthorID,
                B => B.AuthorID,
                (A, B) => new { BookName = A.BookName, BookID = A.BookID, DateOfPublication = A.DateOfPublication, Capacity = A.Capacity, AuthorName = B.AuthorName }).ToList().OrderBy(A => A.AuthorName).Distinct();
            foreach (var book in tmp2)
            {
                booksCatalogueDataGridView.Rows.Add(book.BookID, book.BookName, book.DateOfPublication.ToShortDateString(), book.Capacity, book.AuthorName);
                booksCatalogueForInfo.Add(provider.BookFundProvider.GetAll().FirstOrDefault(A => A.BookID == book.BookID));
            }
        }

        private void themeCatologButton_Click(object sender, EventArgs e)
        {
            booksCatalogueForInfo.Clear();
            booksCatalogueDataGridView.ColumnCount = 6;
            booksCatalogueDataGridView.Columns[4].Name = "Тематика";
            booksCatalogueDataGridView.Columns[5].Width = 75;
            booksCatalogueDataGridView.Columns[5].Name = "Автор";
            booksCatalogueDataGridView.Rows.Clear();
            booksCatalogue.Clear();
            List<int> ids = provider.BookFundProvider.GetAll().Select(A => A.BookID).Distinct().ToList();
            foreach (var id in ids)
            {
                booksCatalogue.Add(provider.BookFundProvider.GetAll().FirstOrDefault(A => A.BookID == id));
            }
            var tmp = booksCatalogue.Join(provider.ThemeBookFundProvider.GetAll(),
                A => A.BookID,
                B => B.BookID,
                (A, B) => new { BookName = A.BookName, DateOfPublication = A.DateOfPublication, Capacity = A.Capacity, BookID = A.BookID, ThemeID = B.ThemeID });
            var tmp2 = tmp.Join(provider.ThemeProvider.GetAll(),
                A => A.ThemeID,
                B => B.ThemeId,
                (A, B) => new { BookName = A.BookName, BookID = A.BookID, DateOfPublication = A.DateOfPublication, Capacity = A.Capacity, ThemeName = B.ThemeName }).ToList().Distinct();
            var tmp3 = tmp2.Join(provider.AuthorBookFundProvider.GetAll(),
                A => A.BookID,
                B => B.BookID,
                (A, B) => new { BookName = A.BookName, BookID = A.BookID, DateOfPublication = A.DateOfPublication, Capacity = A.Capacity, ThemeName = A.ThemeName, AuthorID = B.AuthorID });
            var tmp4 = tmp3.Join(provider.AuthorProvider.GetAll(),
                A => A.AuthorID,
                B => B.AuthorID,
                (A, B) => new { BookName = A.BookName, BookID = A.BookID, DateOfPublication = A.DateOfPublication, Capacity = A.Capacity, ThemeName = A.ThemeName, AuthorName = B.AuthorName }).ToList().OrderBy(A=>A.ThemeName).ThenBy(A=>A.AuthorName).Distinct();
            foreach (var book in tmp4)
            {
                booksCatalogueDataGridView.Rows.Add(book.BookID, book.BookName, book.DateOfPublication.ToShortDateString(), book.Capacity, book.ThemeName,book.BookName);
                booksCatalogueForInfo.Add(provider.BookFundProvider.GetAll().FirstOrDefault(A => A.BookID == book.BookID));
            }

        }

        private void bookCatalogueInfoButton_Click(object sender, EventArgs e)
        {
            if (booksCatalogueForInfo.Count == 0 || booksCatalogueDataGridView.CurrentCell == null || booksCatalogueDataGridView.CurrentCell.RowIndex == booksCatalogueForInfo.Count)
            {
                MessageBox.Show("Выберите какуюто книгу", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            BookFund tmpBook = provider.BookFundProvider.GetAll().FirstOrDefault(A => A.BookID == booksCatalogueForInfo[booksCatalogueDataGridView.CurrentCell.RowIndex].BookID);
            new BookInfo(tmpBook).Show();
        }
    }
}
