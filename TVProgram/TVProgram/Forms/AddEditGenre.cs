using System;
using System.Linq;
using System.Windows.Forms;
using TVProgram.Models;
using TVProgram.Providers.Factories;

namespace TVProgram.Forms
{
    public partial class AddEditGenre : Form
    {
        private TVGenre editableGenre;

        public AddEditGenre(TVGenre genre = null)
        {
            InitializeComponent();

            // If we don't transmit genre as parameter we can add genre
            // Otherwise we can edit transmited genre
            if (genre is null)
            {
                AddEditButton.Text = "Добавить";
                Text = "Добавить";
            }
            else
            {
                AddEditButton.Text = "Изменить";
                Text = "Изменить";
            }

            editableGenre = genre;
        }

        #region Handlers
        private void AddEditButton_Click(object sender, EventArgs e)
        {
            var name = GenreTextBox.Text;
            if (editableGenre is null)
            {
                if (!string.IsNullOrEmpty(name))
                {
                    if (TryAdd(name)) BackToPrevious();
                    else MessageBox.Show("Такой жанр уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Название не должно быть пустым", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(name))
                {
                    if (TryEdit(name)) BackToPrevious();
                    else MessageBox.Show("Не получилось изменить жанр", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Название не должно быть пустым", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            BackToPrevious();
        }
        #endregion

        private bool TryAdd(string genreName)
        {
            if (!CheckOnIdentity(genreName))
                return false;

            ProviderFactory.Instance.GenreProvider.Add(new TVGenre { NameGenre = genreName });
            return true;
        }

        private bool TryEdit(string genreName)
        {
            if (!CheckOnIdentity(genreName))
                return false;

            ProviderFactory.Instance.GenreProvider.Update(editableGenre.IDGenre, new TVGenre { NameGenre = genreName });
            return true;
        }

        private bool CheckOnIdentity(string genreName)
        {
            // Check is genre with similar name not contained
            return !ProviderFactory.Instance.GenreProvider.GetAll().Select(x => x.NameGenre).Contains(genreName);
        }

        private void BackToPrevious()
        {
            this.Close();
        }
    }
}
