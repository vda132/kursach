using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TVProgram.Models;
using TVProgram.Providers.Factories;

namespace TVProgram.Forms
{
    public partial class AdminMenu : Form
    {
        private List<TVGenre> genres;
        private List<TVGenre> displayGenres;

        private List<TVChannel> channels;
        private List<TVChannel> displayChannels;

        public AdminMenu()
        {
            InitializeComponent();

            LoadGenres();
            UpdateGenresDataGrid();
            GenresDataGrid.Columns["IDGenre"].Visible = false;
            GenresDataGrid.Columns["Shows"].Visible = false;

            LoadChannels();
            UpdateChannelsDataGrid();
            ChannelsDataGrid.Columns["IDChannel"].Visible = false;
            ChannelsDataGrid.Columns["Programs"].Visible = false;
        }

        #region Handlers
        // Filters
        private void GenreButton_Click(object sender, EventArgs e)
        {
            FilterGenres();
            UpdateGenresDataGrid();
        }

        private void ChannelButton_Click(object sender, EventArgs e)
        {
            FilterChannels();
            UpdateChannelsDataGrid();
        }

        // Adding
        private void AddGenreButton_Click(object sender, EventArgs e)
        {
            new AddEditGenre().Show();
            UpdateGenres();
        }

        private void AddChannelButton_Click(object sender, EventArgs e)
        {
            new AddEditChannel().Show();
            UpdateChannels();
        }

        // Removing
        private void RemoveGenreButton_Click(object sender, EventArgs e)
        {
            var selectedGenre = GetSelectedGenre();
            if (selectedGenre is not null)
            {
                ProviderFactory.Instance.GenreProvider.Delete(selectedGenre.IDGenre);
                UpdateGenres();
            }
            else
            {
                MessageBox.Show("Выберете жанр", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RemoveChannelButton_Click(object sender, EventArgs e)
        {
            var selectedChannel = GetSelectedChannel();
            if (selectedChannel is not null)
            {
                ProviderFactory.Instance.ChannelProvider.Delete(selectedChannel.IDChannel);
                UpdateChannels();
            }
            else
            {
                MessageBox.Show("Выберете канал", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Editing
        private void GenresDataGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var selectedGenre = GetSelectedGenre();
            if (selectedGenre is not null) 
            {
                new AddEditGenre(selectedGenre).Show();
                UpdateGenres();
            }
        }

        private void ChannelsDataGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var selectedChannel = GetSelectedChannel();
            if (selectedChannel is not null)
            {
                new AddEditChannel(selectedChannel).Show();
                UpdateChannels();
            }
        }

        private void AdminMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        #endregion

        private TVGenre GetSelectedGenre()
        {
            // If nothing is selected but method is called
            // We will do nothing
            if (GenresDataGrid.SelectedRows.Count <= 0) return null;

            // Get index of genre in displayGenres
            var index = GenresDataGrid.SelectedRows[0].Index;
            // Get selected genre
            return displayGenres[index];
        }

        private TVChannel GetSelectedChannel()
        {
            // If nothing is selected but method is called
            // We will do nothing
            if (ChannelsDataGrid.SelectedRows.Count <= 0) return null;

            // Get index of channel in displayChannels
            var index = ChannelsDataGrid.SelectedRows[0].Index;
            // Get selected channel
            return displayChannels[index];
        }

        private void UpdateGenres()
        {
            LoadGenres();
            FilterGenres();
            UpdateGenresDataGrid();
        }

        private void UpdateChannels()
        {
            LoadChannels();
            FilterChannels();
            UpdateChannelsDataGrid();
        }

        private void LoadGenres()
        {
            genres = ProviderFactory.Instance.GenreProvider.GetAll().ToList();
            displayGenres = genres;
        }

        private void LoadChannels()
        {
            channels = ProviderFactory.Instance.ChannelProvider.GetAll().ToList();
            displayChannels = channels;
        }

        private void FilterGenres()
        {
            displayGenres = new();
            foreach (var genre in genres)
                if (genre.NameGenre.Contains(GenreTextBox.Text))
                    displayGenres.Add(genre);
        }

        private void FilterChannels()
        {
            displayChannels = new();
            foreach (var channel in channels)
                if (channel.NameChannel.Contains(ChannelTextBox.Text))
                    displayChannels.Add(channel);
        }

        private void UpdateGenresDataGrid()
        {
            GenresDataGrid.DataSource = displayGenres;
        }

        private void UpdateChannelsDataGrid()
        {
            ChannelsDataGrid.DataSource = displayChannels;
        }
    }
}
