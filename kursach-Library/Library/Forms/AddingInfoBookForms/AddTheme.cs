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
        FactoryProvider provider = FactoryProvider.GetInstance();
        BookFund book;
        List<Theme> themes = new List<Theme>();
        public AddTheme(BookFund book)
        {
            InitializeComponent();
            this.book = book;
            addThemeBookButton.Enabled = false;
            themesDataGridView.ColumnCount = 1;
            themesDataGridView.Columns[0].Width = 120;
            themesDataGridView.Columns[0].Name = "Название темы";
            themes = provider.ThemeProvider.GetAll().ToList();
            LoadThemes();
        }
        private void LoadThemes()
        {
            themesDataGridView.Rows.Clear();
            foreach (var theme in themes)
            {
                themesDataGridView.Rows.Add(theme.ThemeName);
            }
        }

        private void themesDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            addThemeBookButton.Enabled = true;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(themeSearchTextBox.Text))
            {
                themes = provider.ThemeProvider.GetAll().Where(A => A.ThemeName.ToLower().Contains(themeSearchTextBox.Text.ToLower())).ToList();
                LoadThemes();
            }
        }

        private void addThemeBookButton_Click(object sender, EventArgs e)
        {
            Theme tmpTheme = themes[themesDataGridView.CurrentCell.RowIndex];
            if (provider.ThemeBookFundProvider.GetAll().FirstOrDefault(A => A.ThemeID == tmpTheme.ThemeId && A.BookID == book.BookID) != null)
            {
                MessageBox.Show("Такая информация уже есть.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<BookFund> tmpBooks = provider.BookFundProvider.GetAll().Where(A => A.BookID == book.BookID).ToList();
            ThemeBookFund tmpThemeBookFund = new ThemeBookFund();
            foreach (var book in tmpBooks)
            {
                tmpThemeBookFund.ThemeID = tmpTheme.ThemeId;
                tmpThemeBookFund.BookID = book.BookID;
                tmpThemeBookFund.LibraryBookNO = book.LibraryBookNO;
                provider.ThemeBookFundProvider.Add(tmpThemeBookFund);
            }
            this.Close();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            themeSearchTextBox.Text = null;
            themes = provider.ThemeProvider.GetAll().ToList();
            LoadThemes();
        }
    }
}
