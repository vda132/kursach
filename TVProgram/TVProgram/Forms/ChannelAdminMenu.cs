using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TVProgram.DataStructures;
using TVProgram.Models;
using TVProgram.Providers.Factories;

namespace TVProgram.Forms
{
    public partial class ChannelAdminMenu : Form
    {
        private TVChannel currentChannel;

        private List<TVShow> shows;
        private List<TVShow> displayShows;

        private List<TVGenre> genres;

        public ChannelAdminMenu()
        {
            InitializeComponent();

            // Get current channel by user
            var currentUser = Cache.Instance.CurrectUser;
            currentChannel = ProviderFactory.Instance.ChannelProvider.GetAll().First(x => x.NameChannel.Equals(currentUser.Status));

            // Fill labels and form name
            ChannelNameLabel.Text = currentChannel.NameChannel;
            Text = $"\"{currentChannel.NameChannel}\" канал";

            // Fill shows


            // Fill genres
            genres = ProviderFactory.Instance.GenreProvider.GetAll().ToList();
        }

        private void AddShowButton_Click(object sender, EventArgs e)
        {

        }

        private void RemoveShowButton_Click(object sender, EventArgs e)
        {

        }

        private void ShowsDataGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        // Filter
        private void ShowButton_Click(object sender, EventArgs e)
        {
            Filter();
            UpdateDataGrid();
        }

        private void ChannelAdminMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void UpdateDataGrid()
        {
            ShowsDataGrid.DataSource = displayShows;
        }

        private void LoadShows()
        {
            var showIds = currentChannel.Programs.Select(x => x.IDShow);

            shows = new();
            foreach (var showId in showIds)
            {

            }
        }

        private void Filter()
        {
            // Reset list
            displayShows = new();
        }
    }
}
