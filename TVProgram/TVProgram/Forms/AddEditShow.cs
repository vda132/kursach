using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TVProgram.Models;
using TVProgram.Providers.Factories;

namespace TVProgram.Forms
{
    public partial class AddEditShow : Form
    {
        private TVShow editableShow;

        private List<TVGenre> genres;
        private List<TVGenre> comboBoxGenres = new();
        private List<TVGenre> comboBoxShowGenres = new();
        private TVGenre selectedGenre;
        private TVGenre selectedShowGenre;

        private List<int> genresForDeleting = new();
        private List<int> genresForAdding = new();

        public AddEditShow(TVShow show = null)
        {
            InitializeComponent();

            if (show is not null)
            {
                ShowTextBox.Text = show.NameShow;
            }

            // If we don't transmit genre as parameter we can add genre
            // Otherwise we can edit transmited genre
            if (show is null)
            {
                AddEditButton.Text = "Добавить";
                Text = "Добавить";

                genres = ProviderFactory.Instance.GenreProvider.GetAll().ToList();
                comboBoxGenres = genres;
            }
            else
            {
                AddEditButton.Text = "Изменить";
                Text = "Изменить";

                genres = ProviderFactory.Instance.GenreProvider.GetAll().ToList();
                foreach (var genre in genres)
                {
                    if (genre.Shows.Any(x => x.IDShow == show.IDShow))
                        comboBoxShowGenres.Add(genre);
                    else
                        comboBoxGenres.Add(genre);
                }
            }

            UpdateComboBoxs();

            editableShow = show;
        }

        #region Handlers
        private void BackButton_Click(object sender, EventArgs e)
        {
            BackToPrevious();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var name = ShowTextBox.Text;
            if (editableShow is null)
            {
                if (!string.IsNullOrEmpty(name))
                {
                    if (TryAdd(name)) BackToPrevious();
                    else MessageBox.Show("Такая передача уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    else MessageBox.Show("Не получилось изменить передачу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Название не должно быть пустым", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void GenresComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedGenre = comboBoxGenres[GenresComboBox.SelectedIndex];
        }

        private void ShowGenresComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedShowGenre = comboBoxShowGenres[ShowGenresComboBox.SelectedIndex];
        }

        private void AddGenreButton_Click(object sender, EventArgs e)
        {
            if (selectedGenre is null)
            {
                MessageBox.Show("Выберете жанр", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!genresForDeleting.Contains(selectedGenre.IDGenre))
            {
                if (genresForAdding.Contains(selectedGenre.IDGenre))
                    return;
                genresForAdding.Add(selectedGenre.IDGenre);
            }
            else
            {
                genresForDeleting.Remove(selectedGenre.IDGenre);
            }

            comboBoxGenres.Remove(selectedGenre);
            comboBoxShowGenres.Add(selectedGenre);

            UpdateComboBoxs();
        }

        private void RemoveGenreButton_Click(object sender, EventArgs e)
        {
            if (selectedShowGenre is null)
            {
                MessageBox.Show("Выберете жанр", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!genresForAdding.Contains(selectedShowGenre.IDGenre))
            {
                if (genresForDeleting.Contains(selectedShowGenre.IDGenre))
                    return;
                genresForDeleting.Add(selectedShowGenre.IDGenre);
            }
            else
            {
                genresForAdding.Remove(selectedShowGenre.IDGenre);
            }

            comboBoxShowGenres.Remove(selectedShowGenre);
            comboBoxGenres.Add(selectedShowGenre);

            UpdateComboBoxs();
        }
        #endregion

        private bool TryAdd(string showName)
        {
            if (!CheckOnIdentity(showName))
                return false;

            ProviderFactory.Instance.ShowProvider.Add(new TVShow { NameShow = showName });
            var newShow = ProviderFactory.Instance.ShowProvider.GetAll().First(x => x.NameShow.Equals(showName));

            // Get current channel by user
            var currentUser = Cache.Instance.CurrectUser;
            var currentChannel = ProviderFactory.Instance.ChannelProvider.GetAll().First(x => x.NameChannel.Equals(currentUser.Status));
            ProviderFactory.Instance.ChannelProvider.AddShow(currentChannel.IDChannel, newShow.IDShow);

            foreach (var genre in genresForAdding)
                ProviderFactory.Instance.ShowProvider.AddGenre(newShow.IDShow, genre);

            return true;
        }

        private bool TryEdit(string showName)
        {
            var nameValidate = showName.Equals(editableShow.NameShow) ? true : CheckOnIdentity(showName);
            if (!nameValidate)
                return false;

            ProviderFactory.Instance.ShowProvider.Update(editableShow.IDShow, new TVShow { NameShow = showName });

            foreach (var genre in genresForDeleting)
                ProviderFactory.Instance.ShowProvider.DeleteGenre(editableShow.IDShow, genre);

            foreach (var genre in genresForAdding)
                ProviderFactory.Instance.ShowProvider.AddGenre(editableShow.IDShow, genre);

            return true;
        }

        private bool CheckOnIdentity(string showName)
        {
            // Check is show with similar name not contained
            return !ProviderFactory.Instance.ShowProvider.GetAll().Select(x => x.NameShow).Contains(showName);
        }

        private void UpdateComboBoxs()
        {
            GenresComboBox.Items.Clear();
            GenresComboBox.Text = "";
            GenresComboBox.Items.AddRange(comboBoxGenres.Select(x => x.NameGenre).ToArray());

            ShowGenresComboBox.Items.Clear();
            ShowGenresComboBox.Text = "";
            ShowGenresComboBox.Items.AddRange(comboBoxShowGenres.Select(x => x.NameGenre).ToArray());
        }

        private void BackToPrevious()
        {
            this.Close();
        }
    }
}
