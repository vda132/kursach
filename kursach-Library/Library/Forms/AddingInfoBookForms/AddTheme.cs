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
    public partial class AddTheme : Form
    {
        //Создание экземпляра фабрики провайдеров для работы с провайдерами базы данных чтобы получить необходимые данные
        FactoryProvider provider = FactoryProvider.GetInstance();
        //Экземпляр книги 
        BookFund book;
        //список авторов
        List<Theme> themes = new List<Theme>();
        public AddTheme(BookFund book)
        {
            InitializeComponent();
            //присвоение книги
            this.book = book;
            //настрока кнопки и data grid
            addThemeBookButton.Enabled = false;
            themesDataGridView.ColumnCount = 1;
            themesDataGridView.Columns[0].Width = 120;
            themesDataGridView.Columns[0].Name = "Название темы";
            //получение всех тем
            themes = provider.ThemeProvider.GetAll().ToList();
            //загрузка тем в data grid
            LoadThemes();
        }
        //метод для загрузки тем в data grid
        private void LoadThemes()
        {
            themesDataGridView.Rows.Clear();
            foreach (var theme in themes)
            {
                //загрзка по строково каждой темы
                themesDataGridView.Rows.Add(theme.ThemeName);
            }
        }
        //обработка события на выбранный елемент в data grid
        private void themesDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            //присвоение свойству значения
            addThemeBookButton.Enabled = true;
        }
        //обработка нажатия на кнопку поиска темы
        private void searchButton_Click(object sender, EventArgs e)
        {
            //проверка на пустое поле
            if (!String.IsNullOrEmpty(themeSearchTextBox.Text))
            {
                //поиск тем
                themes = provider.ThemeProvider.GetAll().Where(A => A.ThemeName.ToLower().Contains(themeSearchTextBox.Text.ToLower())).ToList();
                //загрузка тем в data grid
                LoadThemes();
            }
        }
        //обработка нажатия на кнопку добавления темы книге
        private void addThemeBookButton_Click(object sender, EventArgs e)
        {
            //получение выбранной темы
            Theme tmpTheme = themes[themesDataGridView.CurrentCell.RowIndex];
            //проверка на то есть ли уже данная тема у книги
            if (provider.ThemeBookFundProvider.GetAll().FirstOrDefault(A => A.ThemeID == tmpTheme.ThemeId && A.BookID == book.BookID) != null)
            {
                //вывод сообщения
                MessageBox.Show("Такая информация уже есть.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //получение книги и ее экземпляров
            List<BookFund> tmpBooks = provider.BookFundProvider.GetAll().Where(A => A.BookID == book.BookID).ToList();
            //создание экземпляра для добавления информации относительно книги и темы
            ThemeBookFund tmpThemeBookFund = new ThemeBookFund();
            //добавление всем экземплярам книги данной темы
            foreach (var book in tmpBooks)
            {
                tmpThemeBookFund.ThemeID = tmpTheme.ThemeId;
                tmpThemeBookFund.BookID = book.BookID;
                tmpThemeBookFund.LibraryBookNO = book.LibraryBookNO;
                provider.ThemeBookFundProvider.Add(tmpThemeBookFund);
            }
            //закрытие формы
            this.Close();
        }
        //обработка нажатия на кнопку сбрасывания
        private void resetButton_Click(object sender, EventArgs e)
        {
            //присвоение полю стандартоного значения
            themeSearchTextBox.Text = null;
            //получение всех тем
            themes = provider.ThemeProvider.GetAll().ToList();
            //загрузка тем в data grid
            LoadThemes();
        }
    }
}
