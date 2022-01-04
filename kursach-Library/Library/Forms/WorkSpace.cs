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
        //Создание экземпляра фабрики провайдеров для работы с провайдерами базы данных чтобы получить необходимые данные
        FactoryProvider provider = FactoryProvider.GetInstance();
        //создание списков различных таблиц для вывода их в datd grid и работы с ними
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
        //предыдущая форма
        Form previousForm;
        //текущий пользователь
        Users user;
        public WorkSpace(Form form, Users _user)
        {
            InitializeComponent();
            //присваивание текущего пользователя
            this.user = _user;
            //присваивание предыдущей формы
            previousForm = form;
            //вызов метода для определения какой пользователь вошел
            UserLogic();
        }
        //вызов для определения какой пользователь вошел
        private void UserLogic()
        {
            switch (user.UserType)
            {
                case "Админ БД":
                    //вызов метода для появление елементов работы для администратора БД
                    AdminProperties();
                    break;
                case "Библиотекарь":
                    //вызов метода для появление елементов работы для библиотекаря
                    LibrarianProperties();
                    break;
                case "Читатель":
                    //вызов метода для появление елементов работы для читателя
                    ReaderProperties();
                    break;
            }
        }
        //метод появления елементов для админимтратора БД
        private void AdminProperties()
        {
            //определение размера формы
            this.Size = new Size(700, 400);
            //определение позиции кнопки выход
            ExitButton.Location = new Point(600, 20);
            //появление необходимых елементов
            tabControl1.Visible = true;
            loginTextBox.ReadOnly = true;
            passwordTextBox.ReadOnly = true;
            dataGridView1.MultiSelect = false;
            ApplyChanges.Visible = false;
            DeleteLibrarianButton.Enabled = false;
            //присваивание текстбоксам пароль и логин пользователя
            loginTextBox.Text = user.UserLogin;
            passwordTextBox.Text = user.UserPassword;
            //задание ширины колонок data grid
            dataGridView1.Columns[0].Width = 90;
            dataGridView1.Columns[1].Width = 90;
            dataGridView1.Columns[2].Width = 120;
            //загрузка данных про библиотекарей в data grid
            LoadData();
        }
        //метод появления елементов для библиотекаря
        private void LibrarianProperties()
        {
            //появление необходимых елементов
            tabControl2.Visible = true;
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
            //настройка data grid`ов для атворов тем книг читателей и выдач книг
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
            chart1.Series[0].Name = ""; //задание пустой строки в названии диаграммы
            bookSearchReportButton.Enabled = false;
            ApplyLibButton.Visible = false;
            beginDateTimePicker.Enabled = false;
            //присвоение значения сегодняшней даты для календаря 
            beginDateTimePicker.Value = DateTime.Now;
            //присвоение текстбоксам логин и пароль библиотекаря
            libLogin.Text = user.UserLogin;
            libPassword.Text = user.UserPassword;
            //вызов методов для загрузки тем книг авторов и читателей
            LoadThemes();
            LoadAuthors();
            LoadBooks();
            LoadReaders();
        }
        //метод появления елементов для читателя
        private void ReaderProperties()
        {
            //появление необходимых елеметов 
            tabControl3.Visible = true;
            editReaderButton.Enabled = true;
            applyChangesReaderButton.Visible = false;
            //поиск по цифрам в логине читателя с таким же читательским билетом
            int value;
            int.TryParse(string.Join("", user.UserLogin.Where(c => char.IsDigit(c))), out value);
            Reader reader = provider.ReaderProvider.GetAll().FirstOrDefault(A => A.ReaderNo == value);
            //задание списку информации про историю выдач книг данного читателя
            readerHistory = provider.ExtraditionProvider.GetAll().Where(A => A.ReaderNo == reader.ReaderNo).ToList();
            //настройка data grid`ов 
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
            //заполнение data grid информацией про выданные книги 
            bookHistoryDataGridView.Rows.Clear();
            foreach (var extradition in readerHistory)
            {
                bookHistoryDataGridView.Rows.Add(extradition.BookID, extradition.LibraryBookNO, extradition.BookFund.BookName, extradition.DateOfExtradition.ToShortDateString(), extradition.DateOfReturn.ToShortDateString(), extradition.Information);
            }
            //задание текстбоксам значение логина и пароля текущего читателя
            readerLoginTextBox.Text = user.UserLogin;
            readerPassTextBox.Text = user.UserPassword;
        }
        //метод для загрузки данных про библиотекарей в data grid 
        private void LoadData()
        {
            //очистка всех строк 
            dataGridView1.Rows.Clear();
            //получение всех библиотекарей 
            users = provider.UserProvider.GetAll().Where(A=>A.UserType=="Библиотекарь").ToList();
            foreach (var user in users)
            {
                //загрузка каждого библиотекаря по строково
                dataGridView1.Rows.Add(user.UserLogin, user.UserPassword,user.UserType);
            }
        }
        //метод для загрузки авторов
        private void LoadAuthors()
        {
            //очистка всех строк
            authorDataGridView.Rows.Clear();
            //получение всех авторов
            authors = provider.AuthorProvider.GetAll().ToList();
            foreach (var author in authors)
            {
                //загрузка каждого автора по строково
                authorDataGridView.Rows.Add(author.AuthorID, author.AuthorName);
            }
        }
        //метод для загрузки тем
        private void LoadThemes()
        {
            //очистка всех строк 
            themeDataGridView.Rows.Clear();
            //получение всех тем
            themes = provider.ThemeProvider.GetAll().ToList();
            foreach (var theme in themes)
            {
                //загрузка каждой темы по строково
                themeDataGridView.Rows.Add(theme.ThemeName);
            }
        }
        //метод для загрузки книг 
        private void LoadBooks()
        {
            //очистка строк
            bookDataGridView.Rows.Clear();
            //очистка книг
            books.Clear();
            //заполнение айдишников каждой книги
            List<int> ids = provider.BookFundProvider.GetAll().Select(A => A.BookID).Distinct().ToList();
            foreach(var id in ids)
            {
                //поиск книги по заданому айдишнику
                books.Add(provider.BookFundProvider.GetAll().FirstOrDefault(A => A.BookID == id));
            }
            foreach (var book in books)
            {
                //загрузка каждой книги по строково
                bookDataGridView.Rows.Add(book.BookID, book.BookName, book.DateOfPublication.ToShortDateString(), book.Capacity);
            }
        }
        //метод для загрузки читателей
        private void LoadReaders()
        {
            //очистка строк
            readerDataGridView.Rows.Clear();
            //получение всех читателей
            readers = provider.ReaderProvider.GetAll().ToList();
            foreach (var reader in readers)
            {
                //загрузка каждого читателя с информацией про его логин и пароль
                var user = provider.UserProvider.GetAll().FirstOrDefault(A => A.UserLogin == "Reader" + reader.ReaderNo.ToString());
                readerDataGridView.Rows.Add(reader.ReaderNo, reader.ReaderName, reader.Adress, reader.Phone, user.UserLogin, user.UserPassword);
            }
        }
        //метод для загрузки читателей для оформления выдачи
        private void LoadReadersExtradition()
        {
            //очистка строк
            readersDataGridView.Rows.Clear();
            foreach (var reader in extraditionReaders)
            {
                //загрузка читателей
                readersDataGridView.Rows.Add(reader.ReaderNo, reader.ReaderName);
            }
        }
        //метод для загрузки книг для оформления выдачи
        private void LoadBooksExtradition()
        {
            //очистка строк
            booksDataGridView.Rows.Clear();
            foreach (var book in extraditionBooks)
            {
                //загрузка книг которые есть в наличии
                if (book.BookStatus)
                    booksDataGridView.Rows.Add(book.BookID, book.LibraryBookNO, book.BookName, book.DateOfPublication, "Есть в наличии");
                //загрузка книг которых нет в наличии
                else
                    booksDataGridView.Rows.Add(book.BookID, book.LibraryBookNO, book.BookName, book.DateOfPublication, "Нет в наличии");
            }
        }
        //загрузка всех выдач которые есть
        private void LoadExtraditions()
        {
            //очистка строк
            reportDataGridView.Rows.Clear();
            foreach (var extradition in extraditions)
            {
                //загрузка выдачи по строково
                reportDataGridView.Rows.Add(extradition.ReaderNo, extradition.Reader.ReaderName, extradition.BookID, extradition.LibraryBookNO, extradition.BookFund.BookName, extradition.DateOfExtradition.ToShortDateString(), extradition.DateOfReturn.ToShortDateString(), extradition.Information);
            }
        }
        //метод для обнуления и присвоения стандартных значений полям
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
        //обработка на нажатие кнопки редактировать у администратора
        private void editInfoButton_Click(object sender, EventArgs e)
        {
            //задание свойств
            editInfoButton.Enabled = false;
            loginTextBox.ReadOnly = false;
            passwordTextBox.ReadOnly = false;
            ApplyChanges.Visible = true;
        }
        //обработка на нажатие кнопки применить изменения у администратора
        private void ApplyChanges_Click(object sender, EventArgs e)
        {
            //задание свойств
            editInfoButton.Enabled = true;
            loginTextBox.ReadOnly = true;
            passwordTextBox.ReadOnly = true;
            dataGridView1.MultiSelect = false;
            ApplyChanges.Visible = false;
            //проверка на то пустые ли строки
            if (String.IsNullOrEmpty(loginTextBox.Text) || String.IsNullOrEmpty(passwordTextBox.Text))
            {
                //вывод сообщения если пусты
                MessageBox.Show("Поля должны быть заполнены!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //поиск информации о администраторе по его айдишнику
            var tmpUser = provider.UserProvider.GetAll().FirstOrDefault(A => A.IdUser == user.IdUser);
            //присвоение логину и паролю пользователя значений из текстбоксов
            tmpUser.UserLogin = loginTextBox.Text;
            tmpUser.UserPassword = passwordTextBox.Text;
            //проверка на то есть ли такой логин
            if (provider.UserProvider.GetAll().FirstOrDefault(A => A.IdUser != tmpUser.IdUser && A.UserLogin == tmpUser.UserLogin) != null)
            {
                //вывод сообщения если есть
                MessageBox.Show("Такой логин уже есть!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //обновление информации о пользователе
            provider.UserProvider.Update(tmpUser.IdUser,tmpUser);
            //вывод сообщения
            MessageBox.Show("Информация сохранена.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //задание свойств
            ApplyChanges.Visible = false;
            editInfoButton.Enabled = true;
            loginTextBox.ReadOnly = true;
            passwordTextBox.ReadOnly = true;
        }
        //обработка нажатия на кнопку выход
        private void ExitButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Вы точно хотите вернуться на страницу авторизации? ", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //закрытие текущей формы
                this.Close();
                //появление формы авторизации
                previousForm.Show();
            }
        }
        //обработка нажатия на кнопку добавить библиотекаря
        private void AddLibrarianbutton_Click(object sender, EventArgs e)
        {
            //проверка на пустые поля
            if (String.IsNullOrEmpty(libLoginTextBox.Text) || String.IsNullOrEmpty(libPasswordTextBox.Text))
            {
                //вывод сообщения если поля пусты
                MessageBox.Show("Поля должны быть заполнены!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //проверка на то занят ли такой логин
            if (provider.UserProvider.GetAll().FirstOrDefault(A => A.UserLogin == libLoginTextBox.Text) != null)
            {
                //вывод сообщения если занят
                MessageBox.Show("Такой логин уже есть!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //создание экземпляра типа User и присвоение его полям значения из текстбоксов
            Users tmpUser = new Users
            {
                UserLogin = libLoginTextBox.Text,
                UserPassword = libPasswordTextBox.Text,
                UserType = "Библиотекарь"
            };
            //добавление библиотекаря в базу
            provider.UserProvider.Add(tmpUser);
            //вывод сообщения 
            MessageBox.Show("Библиотекарь добавлен.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //загрузка данных про библиотекарей в data grid
            LoadData();
            //вызов метода для обнуления и присвоения стандартных значений 
            Reset();
        }
        //обработка события на выбранный елемент в data grid для библиотекарей
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //присвоение свойству значения
            DeleteLibrarianButton.Enabled=true;
        }
        //обработка нажатия на кнопку удалить библиотекаря
        private void DeleteLibrarianButton_Click(object sender, EventArgs e)
        {
            //проверка на то нажата кнопка да 
            if (MessageBox.Show($"Вы точно хотите удалить данного библиотекаря? ", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //удаление выбраного библиотекаря
                Users tmpUser = users[dataGridView1.CurrentCell.RowIndex];
                provider.UserProvider.Delete(tmpUser.IdUser);
                //загрузка информации про библиотекарей в data grid
                LoadData();
            }
        }
        //обработка нажатия на кнопку редактировать для библиотекаря
        private void EditLibButton_Click(object sender, EventArgs e)
        {
            //задание свойствам значений
            EditLibButton.Enabled = false;
            ApplyLibButton.Visible = true;
            libPassword.ReadOnly = false;
            libLogin.ReadOnly = false;
        }
        //обработка нажатия на кнопку применить изменения для библиотекаря
        private void ApplyLibButton_Click(object sender, EventArgs e)
        {
            //проверка на пустые поля 
            if (String.IsNullOrEmpty(libPassword.Text) || String.IsNullOrEmpty(libLogin.Text))
            {
                //вывод сообщения
                MessageBox.Show("Поля должны быть заполнены!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //нахождения нужного библиотекаря по айдишнику
            var tmpUser = provider.UserProvider.GetAll().FirstOrDefault(A => A.IdUser == user.IdUser);
            //присвоение логину и паролю библиотекаря значений из текстбоксов
            tmpUser.UserLogin = libLogin.Text;
            tmpUser.UserPassword = libPassword.Text;
            //проверка на то занят ли логин
            if (provider.UserProvider.GetAll().FirstOrDefault(A => A.IdUser != tmpUser.IdUser && A.UserLogin == tmpUser.UserLogin) != null)
            {
                //вывод сообщения если логин занят
                MessageBox.Show("Такой логин уже есть!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //обновление информации про данного библиотекаря
            provider.UserProvider.Update(tmpUser.IdUser, tmpUser);
            //вывод сообщения
            MessageBox.Show("Информация сохранена.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //присвоение свойствам значений
            EditLibButton.Enabled = true;
            ApplyLibButton.Visible = false;
            libPassword.ReadOnly = true;
            libLogin.ReadOnly = true;
        }
        //обработка нажатия на кнопку добавить при добавлении автора 
        private void AddAuthorButton_Click(object sender, EventArgs e)
        {
            //проверка на пустые поля
            if (String.IsNullOrEmpty(authorTextBox.Text))
            {
                //вывод сообщения
                MessageBox.Show("Поля должны быть заполнены!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //создание экземпляра типа автор и присвоение его полям значения из текстбоксов
            var tmpAuthor = new Author()
            {
                AuthorName=authorTextBox.Text
            };
            //добавление нового автора
            provider.AuthorProvider.Add(tmpAuthor);
            //загрузка авторов в data grid
            LoadAuthors();
            //обнуление и присвоение стандартных значений полям
            Reset();
        }
        //обработка события на выбранный елемент в data grid для авторов
        private void authorDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            //присвоение свойству значения
            DeleteAuthorButton.Enabled = true;
        }
        //обработка нажатия на кнопку при удалении автора
        private void DeleteAuthorButton_Click(object sender, EventArgs e)
        {
            //нажата ли кнопка да и выбрана ли не пустая строка 
            if (MessageBox.Show($"Вы точно хотите удалить данного автора? ", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes && authorDataGridView.CurrentCell.RowIndex != authors.Count)
            {
                //удаление выбраного автора
                Author tmpAuthor = authors[authorDataGridView.CurrentCell.RowIndex];
                provider.AuthorProvider.Delete(tmpAuthor.AuthorID);
                //загрузка авторов в data grid
                LoadAuthors();
                //обнуление и присвоение стандартных значений полям
                Reset();
            }
        }
        //обработка нажатия на кнопку при добавлении темы
        private void AddThemeButton_Click(object sender, EventArgs e)
        {
            //проверка на пустые поля
            if (String.IsNullOrEmpty(themeTextBox.Text))
            {
                //вывод сообщения
                MessageBox.Show("Поля должны быть заполнены!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //создание экземпляра темы и присвоение ее полям значения из текстбоксов
            Theme tmpTheme = new Theme()
            {
                ThemeName = themeTextBox.Text
            };
            //добавление темы
            provider.ThemeProvider.Add(tmpTheme);
            //загрузка темы в data grid
            LoadThemes();
            //обнуление и присвоение стандартных значений полям
            Reset();
        }
        //обработка нажатия на кнопку при добавлении книги 
        private void AddBookButton_Click(object sender, EventArgs e)
        {
            //переменные для номера книги ее количество страниц и для количества экземпляров
            int idBook = 0;
            int bookCapacity = 0;
            int bookAmount = 0;
            //проверка на пустые поля
            if (String.IsNullOrEmpty(idBookTextBox.Text) || String.IsNullOrEmpty(bookNameTextBox.Text) || String.IsNullOrEmpty(bookCapacityTextBox.Text)||String.IsNullOrEmpty(bookAmountTextBox.Text))
            {
                //вывод сообщения
                MessageBox.Show("Поля должны быть заполнены!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //проверка на корректный ввод
            if (!int.TryParse(idBookTextBox.Text, out idBook) || !int.TryParse(bookCapacityTextBox.Text, out bookCapacity)||!int.TryParse(bookAmountTextBox.Text, out bookAmount))
            {
                //вывод сообщения
                MessageBox.Show("Неверный формат данных!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //проверка на выбранную дату
            if (bookPublicationDateTimePicker.Value > DateTime.Now)
            {
                //вывод сообщения
                MessageBox.Show("Выбранная дата не может быть больше сегодняшней!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //поиск книги по введенному номеру
            BookFund tmpBookCheck = provider.BookFundProvider.GetAll().FirstOrDefault(A => A.BookID == idBook);
            //проверка на то ли не занят ли этот номер под другой книгой
            if (tmpBookCheck != null && tmpBookCheck.BookName != bookNameTextBox.Text)
            {
                //вывод сообщения
                MessageBox.Show("Данный номер занят под другой книгой!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //создание экземпляра книги и присвоение ее полям значения из текстбоксов
            BookFund tmpBook = new BookFund()
            {
                BookID = idBook,
                BookName = bookNameTextBox.Text,
                DateOfPublication = bookPublicationDateTimePicker.Value,
                Capacity = bookCapacity,
                BookStatus = true
            };
            //добавление данной книги относительно количества экземпляров
            while (bookAmount != 0)
            {
                provider.BookFundProvider.Add(tmpBook);
                --bookAmount;
            }
            //загрузка книг в data grid
            LoadBooks();
            //обнуление и присвоение стандартных значений полям
            Reset();
        }
        //обработка на выбранную книгу в data grid
        private void bookDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            //присвоение свойствам значений
            DeleteBookButton.Enabled = true;
            addBookAuthorbutton.Enabled = true;
            addBookThemeButton.Enabled = true;
        }
        //обработка нажатия на кнопку при удалении книги
        private void DeleteBookButton_Click(object sender, EventArgs e)
        {
            //проверка на то нажато ли да и на то выбрана ли непустая строка 
            if (MessageBox.Show($"Вы точно хотите удалить все экземпляры данной книги? ", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes && bookDataGridView.CurrentCell.RowIndex != books.Count)
            {
                //поиск данной книги и удаление ее
                BookFund tmpBook = new BookFund();
                tmpBook = books[bookDataGridView.CurrentCell.RowIndex];
                BookFundPK pk = new BookFundPK()
                {
                    BookID = tmpBook.BookID,
                    LibraryBookNO = tmpBook.LibraryBookNO
                };
                provider.BookFundProvider.Delete(pk);
                //загрузка книг в data grid
                LoadBooks();
                //обнуление и присвоение стандартных значений полям
                Reset();
            }
        }
        //обработка нажатия на кнопку о добавлении книги автора
        private void addBookAuthorbutton_Click(object sender, EventArgs e)
        {
            //проверка на то выбрана ли непустая строка
            if (books.Count == 0 || bookDataGridView.CurrentCell.RowIndex==books.Count)
            {
                //вывод сообщения
                MessageBox.Show("Выберите какуюто книгу", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //создание экземпляра книги и присвоение ей значений из выбраной строки
            BookFund book = new BookFund();
            book = books[bookDataGridView.CurrentCell.RowIndex];
            //появление формы для добавления автора книге
            new AddAuthor(book).Show();
        }
        //обработка нажатия на кнопку о добавлении книги темы
        private void addBookThemeButton_Click(object sender, EventArgs e)
        {
            //проверка на то выбрана ли непустая строка
            if (books.Count == 0 || bookDataGridView.CurrentCell.RowIndex == books.Count)
            {
                //вывод сообщения
                MessageBox.Show("Выберите какуюто книгу", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //создание экземпляра книги и присвоение ей значений из выбраной строки
            BookFund book = new BookFund();
            book = books[bookDataGridView.CurrentCell.RowIndex];
            //появление формы для добавления темы книге
            new AddTheme(book).Show();
        }
        //обработка нажатия на кнопку о добавлении читателя
        private void AddReaderButton_Click(object sender, EventArgs e)
        {
            //проверка на то пустые ли поля
            if (String.IsNullOrEmpty(readerNameTextBox.Text) || String.IsNullOrEmpty(readerPasswordTextBox.Text)||
                String.IsNullOrEmpty(adressTextBox.Text) ||
                String.IsNullOrEmpty(phoneTextBox.Text))
            {
                //вывод сообщения
                MessageBox.Show("Поля должны быть заполнены!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //проверка на длинну номера телефона
            if (phoneTextBox.Text.Length != 13)
            {
                //вывод сообщения
                MessageBox.Show("Вы ввели некоректный номер телефона.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                return;
            }
            try
            {
                //добавление нового читателя в базу
                provider.ReaderProvider.Add(new Models.Reader
                {
                    ReaderName = readerNameTextBox.Text,
                    Adress = adressTextBox.Text,
                    Phone = phoneTextBox.Text
                });
                //добаление учетной записи данному читателю
                int id = provider.ReaderProvider.GetAll().Max(A => A.ReaderNo);
                provider.UserProvider.Add(new Models.Users
                {
                    UserLogin = "Reader"+id.ToString(),
                    UserPassword = readerPasswordTextBox.Text,
                    UserType = "Читатель"
                });
                //вывод сообщения 
                MessageBox.Show("Добавление успешно!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                //вывод сообщения в случае если поля имеют некоректный ввод для базы данных
                MessageBox.Show("Вы ввели некоректные данные.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //загрузка читателей в data grid
            LoadReaders();
            //обнуление и присвоение стандартных значений полям
            Reset();
        }
        //обработка на выбор читателя из data grid
        private void readerDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            //присвоение свойству значения
            deleteReaderButton.Enabled = true;
        }
        //обработка нажатия на кнопку о удалении читателя
        private void deleteReaderButton_Click(object sender, EventArgs e)
        {
            //проверка на то нажато ли да и выбрана ли непустая строка
            if (MessageBox.Show($"Вы точно хотите удалить данного читателя? ", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes&& readerDataGridView.CurrentCell.RowIndex!=readers.Count)
            {
                //создание экземпляра читателя и присвоение его полям значений из выбраной строки
                Reader tmpReader = new Reader();
                tmpReader = readers[readerDataGridView.CurrentCell.RowIndex];
                //поиск данного читателя среди пользователей
                var user = provider.UserProvider.GetAll().FirstOrDefault(A => A.UserLogin == "Reader" + tmpReader.ReaderNo.ToString());
                //удаление читателя из читателей и пользователей
                provider.UserProvider.Delete(user.IdUser);
                provider.ReaderProvider.Delete(tmpReader.ReaderNo);
                //загрузка читателей в data grid
                LoadReaders();
                //обнуление и присвоение стандартных значений полям
                Reset();
            }
        }
        //обработка нажатия на кнопку при поиске читателя по читательскому билету для оформления выдачи
        private void SearchReaderButton_Click(object sender, EventArgs e)
        {
            //проверка на то пустое ли поле ввода
            if (String.IsNullOrEmpty(readerExtraditionTextBox.Text))
            {
                //вывод сообщения
                MessageBox.Show("Введите номер билета", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //заполнения списка читателей для оформления выдачи
            extraditionReaders = provider.ReaderProvider.GetAll().Where(A => A.ReaderNo.ToString().ToLower().Contains(readerExtraditionTextBox.Text.ToLower())).ToList();
            if (extraditionReaders.Count > 0)
            {
                //загрузка данных в дата грид для оформления выдачи
                LoadReadersExtradition();
            }
            else
            {
                return;
            }
        }
        //обработка нажатия на кнопку при поиске книги для оформления выдачи
        private void SearchBookButton_Click(object sender, EventArgs e)
        {
            //проверка на то пустое ли поле ввода
            if (String.IsNullOrEmpty(bookExtraditionTextBox.Text))
            {
                //вывод сообщения
                MessageBox.Show("Введите название книги", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //заполнения списка книг для оформления выдачи
            extraditionBooks = provider.BookFundProvider.GetAll().Where(A => A.BookName.ToLower().Contains(bookExtraditionTextBox.Text.ToLower())).ToList();
            if (extraditionBooks.Count > 0)
            {
                //загрузка данных в дата грид для оформления выдачи
                LoadBooksExtradition();
            }
            else
                return;
        }
        //обработка нажатия на кнопку для сбрасывания
        private void resetExtraditionbutton_Click(object sender, EventArgs e)
        {
            //обнуление и присвоение стандартных значений полям
            Reset();
        }
        //обработка нажатия на кнопку для оформления выдачи
        private void ExtraditionButton_Click(object sender, EventArgs e)
        {
            //проверка на то все ли выбрано
            if (extraditionReaders.Count==0 || extraditionBooks.Count==0)
            {
                //вывод сообщения
                MessageBox.Show("Выберите и читателя и книгу", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //проверка на то больше ли дата возврата чем дата выдачи
            if (endDateTimePicker.Value < beginDateTimePicker.Value)
            {
                //вывод сообщения
                MessageBox.Show("Дата возврата не может быть меньше даты выдания", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //создание экземпляров книги и читателя из выбранных
            Reader tmpReader = extraditionReaders[readersDataGridView.CurrentCell.RowIndex];
            BookFund tmpBook = extraditionBooks[booksDataGridView.CurrentCell.RowIndex];
            //проверка на то свободна ли данная книга
            if (!tmpBook.BookStatus)
            {
                //вывод сообщения
                MessageBox.Show("Данная книга недоступна.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //создание экземпляра выдачи и присвоение полям значений из выбранных строк
            Extradition tmpExtradition = new Extradition()
            {
                ReaderNo=tmpReader.ReaderNo,
                BookID=tmpBook.BookID,
                LibraryBookNO=tmpBook.LibraryBookNO,
                DateOfExtradition = beginDateTimePicker.Value,
                DateOfReturn = endDateTimePicker.Value,
                Information = "Не вернута"
            };
            //проверка на то есть ли такая информация
            if (provider.ExtraditionProvider.GetAll().FirstOrDefault(A=>A.BookID==tmpExtradition.BookID&&A.DateOfExtradition==tmpExtradition.DateOfExtradition&&A.LibraryBookNO==tmpExtradition.LibraryBookNO&&A.ReaderNo==tmpExtradition.ReaderNo) != null)
            {
                //вывод сообщения
                MessageBox.Show("Такая информация уже существует", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //присвоение книге статуса нет в наличии
            tmpBook.BookStatus = false;
            BookFundPK bookFundPK = new BookFundPK()
            {
                BookID=tmpBook.BookID,
                LibraryBookNO=tmpBook.LibraryBookNO
            };
            //обновление информации о книге и добавление выдачи 
            provider.BookFundProvider.Update(bookFundPK,tmpBook);
            provider.ExtraditionProvider.Add(tmpExtradition);
            //обнуление и присвоение стандартных значений полям
            Reset();
        }
        //обработка нажатия на кнопку о поиске учета для определенного читателя
        private void readerSearchReportButton_Click(object sender, EventArgs e)
        {
            //проверка на пустую строку
            if (String.IsNullOrEmpty(readerReportTextBox.Text))
            {
                //вывод сообщения
                MessageBox.Show("Введите номер билета", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //поиск информации для данного читателя
            extraditions = provider.ExtraditionProvider.GetAll().Where(A => A.ReaderNo.ToString().ToLower().Contains(readerReportTextBox.Text.ToLower())).ToList();
            if (extraditions.Count > 0)
            {
                //загрузка информации в data grid
                LoadExtraditions();
                bookSearchReportButton.Enabled = true;   
            }
            else
                return;
        }
        //обработка нажатия на кнопку о поиске учете для определенной книги
        private void bookSearchReportButton_Click(object sender, EventArgs e)
        {
            //проверка на пустую строку
            if (String.IsNullOrEmpty(bookReportTextBox.Text))
            {
                //вывод сообщения
                MessageBox.Show("Введите название книги", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //поиск информации для данной книги
            extraditions = provider.ExtraditionProvider.GetAll().Where(A => A.BookFund.BookName.ToLower().Contains(bookReportTextBox.Text.ToLower())).ToList();
            if (extraditions.Count > 0)
            {
                //загрузка информации в data grid
                LoadExtraditions();
            }
            else
            {
                //вывод сообщения если книга не выдавалась 
                MessageBox.Show("Данная книга не выдавалась", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        //обработка нажатия на кнопку при возврате книги
        private void BackBookButton_Click(object sender, EventArgs e)
        {
            //проверка на то выбрана ли непустая строка
            if (extraditions.Count == 0)
            {
                //вывод сообщения
                MessageBox.Show("Выберите какуюто информацию", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //поиск выбранной строки
            Extradition tmpExtradition = extraditions[reportDataGridView.CurrentCell.RowIndex];
            //проверка на то вернута ли книга
            if (tmpExtradition.Information == "Вернута")
            {
                //вывод сообщения
                MessageBox.Show("Данная книга уже вернута.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //изменение информациио выдаче и о книге
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
            //обновление информации
            provider.BookFundProvider.Update(bookFundPK,tmpExtradition.BookFund);
            provider.ExtraditionProvider.Update(extraditionPK, tmpExtradition);
            // обнуление и присвоение стандартных значений полям
            Reset();
        }
        //обработка нажатия на кнопку при получении полной информации о книге
        private void bookInfoButton_Click(object sender, EventArgs e)
        {
            //проверка на то выбрана ли не пустая строка
            if (books.Count == 0|| bookDataGridView.CurrentCell==null || bookDataGridView.CurrentCell.RowIndex==books.Count)
            {
                MessageBox.Show("Выберите какуюто книгу", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //поиск данной книги
            BookFund tmpBook = books[bookDataGridView.CurrentCell.RowIndex];
            //появление формы с полной информацией о книге
            new BookInfo(tmpBook).Show();
        }
        //обработка нажатия на кнопку при получении полной информации о книге
        private void booksExtradInfoButton_Click(object sender, EventArgs e)
        {
            //проверка на то выбрана ли не пустая строка
            if (extraditionBooks.Count == 0 || booksDataGridView.CurrentCell == null || booksDataGridView.CurrentCell.RowIndex == extraditionBooks.Count)
            {
                //вывод сообщения
                MessageBox.Show("Выберите какуюто книгу", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //поиск данной книги
            BookFund tmpBook = extraditionBooks[booksDataGridView.CurrentCell.RowIndex];
            //появление формы с полной информацией о книге
            new BookInfo(tmpBook).Show();
        }
        //обработка нажатия на кнопку при получении полной информации о книге
        private void booksReportInfoButton_Click(object sender, EventArgs e)
        {
            //проверка на то выбрана ли не пустая строка
            if (extraditions.Count == 0 || reportDataGridView.CurrentCell == null || reportDataGridView.CurrentCell.RowIndex == extraditions.Count)
            {
                //вывод сообщения
                MessageBox.Show("Выберите какуюто книгу", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //поиск данной книги
            BookFund tmpBook = provider.BookFundProvider.GetAll().FirstOrDefault(A=>A.BookID == extraditions[reportDataGridView.CurrentCell.RowIndex].BookID);
            //появление формы с полной информацией о книге
            new BookInfo(tmpBook).Show();
        }
        //обработка нажатия на кнопку о получении статистики выдач книг
        private void extraditionStatisticButton_Click(object sender, EventArgs e)
        {
            //получение статистики
            List<KeyValuePair<string, int>> statistics = Statistic.Statistic.GetExtraditionStatistic();
            chart1.DataSource = statistics;
            chart1.Series[0].Name = "Название книги";
            chart1.Series[0].XValueMember = "Key";
            chart1.Series[0].YValueMembers = "Value";
            //присвоение информации диаграмме
            chart1.DataBind();
        }
        //обработка нажатия на кнопку о получении статистики посещения
        private void visitingStatisticButton_Click(object sender, EventArgs e)
        {
            //получение статистики
            List<KeyValuePair<string, int>> visitings = Statistic.Statistic.GetVisitingStatistic();
            chart1.DataSource = visitings;
            chart1.Series[0].Name = "ФИО";
            chart1.Series[0].XValueMember = "Key";
            chart1.Series[0].YValueMembers = "Value";
            //присвоение информации диаграмме
            chart1.DataBind();
        }
        //обработка нажатия на кнопку о получении статистики тематик для каждой книге
        private void themeStatisticButton_Click(object sender, EventArgs e)
        {
            //получение статистики
            List<KeyValuePair<string, int>> themes = Statistic.Statistic.GetThemeStatistic();
            chart1.DataSource = themes;
            chart1.Series[0].Name = "Тематика";
            chart1.Series[0].XValueMember = "Key";
            chart1.Series[0].YValueMembers = "Value";
            //присвоение информации диаграмме
            chart1.DataBind();
        }
        //обработка нажатия на кнопку при получении полной информации о книге
        private void bookHistoryInfoButton_Click(object sender, EventArgs e)
        {
            //проверка на то выбрана ли не пустая строка
            if (readerHistory.Count == 0 || bookHistoryDataGridView.CurrentCell == null || bookHistoryDataGridView.CurrentCell.RowIndex == readerHistory.Count)
            {
                //вывод сообщения
                MessageBox.Show("Выберите какуюто книгу", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //поиск данной книги
            BookFund tmpBook = provider.BookFundProvider.GetAll().FirstOrDefault(A => A.BookID == readerHistory[bookHistoryDataGridView.CurrentCell.RowIndex].BookID);
            //появление формы с полной информацией о книге
            new BookInfo(tmpBook).Show();
        }
        //обработка нажатия на кнопку о редактировании информации о читателе
        private void editReaderButton_Click(object sender, EventArgs e)
        {
            //присвоение свойствам значений 
            editReaderButton.Enabled = false;
            applyChangesReaderButton.Visible = true;
            readerPassTextBox.ReadOnly = false;
        }
        //обработка нажатия на кнопку применение изменений для читателя
        private void applyChangesReaderButton_Click(object sender, EventArgs e)
        {
            //проверка на пустое поле
            if (String.IsNullOrEmpty(readerPassTextBox.Text))
            {
                //вывод сообщения
                MessageBox.Show("Поля должны быть заполнены!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //получение данной учетной записи 
            var tmpUser = provider.UserProvider.GetAll().FirstOrDefault(A => A.IdUser == user.IdUser);
            tmpUser.UserPassword = readerPassTextBox.Text;
            //обновление изменений
            provider.UserProvider.Update(tmpUser.IdUser, tmpUser);
            //вывод сообщения
            MessageBox.Show("Информация сохранена.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //присвоение свойствам значений
            editReaderButton.Enabled = true;
            applyChangesReaderButton.Visible = false;
            readerPassTextBox.ReadOnly = true;
        }
        //обработка нажатия на кнопку для алфавитного каталога
        private void alphaviteButton_Click(object sender, EventArgs e)
        {
            //настройка data grid
            booksCatalogueForInfo.Clear();
            booksCatalogueDataGridView.ColumnCount = 5;
            booksCatalogueDataGridView.Columns[4].Name = "Автор";
            booksCatalogueDataGridView.Rows.Clear();
            booksCatalogue.Clear();
            //выбор айдишников всех книг
            List<int> ids = provider.BookFundProvider.GetAll().Select(A => A.BookID).Distinct().ToList();
            foreach (var id in ids)
            {
                //добавление книг
                booksCatalogue.Add(provider.BookFundProvider.GetAll().FirstOrDefault(A => A.BookID == id));
            }
            //объединение таблицы книг и авторов по общим полям
            var tmp = booksCatalogue.Join(provider.AuthorBookFundProvider.GetAll(),
                A => A.BookID,
                B => B.BookID,
                (A, B) => new { BookName = A.BookName, DateOfPublication = A.DateOfPublication, Capacity = A.Capacity, BookID = A.BookID, AuthorID = B.AuthorID });
            var tmp2 = tmp.Join(provider.AuthorProvider.GetAll(),
                A => A.AuthorID,
                B => B.AuthorID,
                (A, B) => new { BookName = A.BookName, BookID = A.BookID, DateOfPublication = A.DateOfPublication, Capacity = A.Capacity, AuthorName = B.AuthorName }).ToList().
                OrderBy(A => A.AuthorName).Distinct(); //сортировка списка по ФИО автора
            foreach (var book in tmp2)
            {
                //вывод информации в дата грид
                booksCatalogueDataGridView.Rows.Add(book.BookID, book.BookName, book.DateOfPublication.ToShortDateString(), book.Capacity, book.AuthorName);
                booksCatalogueForInfo.Add(provider.BookFundProvider.GetAll().FirstOrDefault(A => A.BookID == book.BookID));
            }
        }
        //обработка нажатия на кнопку для тематического каталога
        private void themeCatologButton_Click(object sender, EventArgs e)
        {
            //настройка data grid
            booksCatalogueForInfo.Clear();
            booksCatalogueDataGridView.ColumnCount = 6;
            booksCatalogueDataGridView.Columns[4].Name = "Тематика";
            booksCatalogueDataGridView.Columns[5].Width = 75;
            booksCatalogueDataGridView.Columns[5].Name = "Автор";
            booksCatalogueDataGridView.Rows.Clear();
            booksCatalogue.Clear();
            //выбор айдишников всех книг
            List<int> ids = provider.BookFundProvider.GetAll().Select(A => A.BookID).Distinct().ToList();
            foreach (var id in ids)
            {
                //добавление книг
                booksCatalogue.Add(provider.BookFundProvider.GetAll().FirstOrDefault(A => A.BookID == id));
            }
            //объединение таблицы книг авторов и тематик по общим полям
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
                (A, B) => new { BookName = A.BookName, BookID = A.BookID, DateOfPublication = A.DateOfPublication, Capacity = A.Capacity, ThemeName = A.ThemeName, AuthorName = B.AuthorName }).ToList().
                OrderBy(A=>A.ThemeName).ThenBy(A=>A.AuthorName).Distinct(); //сортировка по тематике а потом по фио автора
            foreach (var book in tmp4)
            {
                //загрузка информации в data grid
                booksCatalogueDataGridView.Rows.Add(book.BookID, book.BookName, book.DateOfPublication.ToShortDateString(), book.Capacity, book.ThemeName,book.BookName);
                booksCatalogueForInfo.Add(provider.BookFundProvider.GetAll().FirstOrDefault(A => A.BookID == book.BookID));
            }
        }
        //обработка нажатия на кнопку при получении полной информации о книге
        private void bookCatalogueInfoButton_Click(object sender, EventArgs e)
        {
            //проверка на то выбрана ли не пустая строка
            if (booksCatalogueForInfo.Count == 0 || booksCatalogueDataGridView.CurrentCell == null || booksCatalogueDataGridView.CurrentCell.RowIndex == booksCatalogueForInfo.Count)
            {
               //вывод сообщения
                MessageBox.Show("Выберите какуюто книгу", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //поиск данной книги
            BookFund tmpBook = provider.BookFundProvider.GetAll().FirstOrDefault(A => A.BookID == booksCatalogueForInfo[booksCatalogueDataGridView.CurrentCell.RowIndex].BookID);
            //появление формы с полной информацией о книге
            new BookInfo(tmpBook).Show();
        }
    }
}
