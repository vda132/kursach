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

        private List<Models.TVProgram> programs;
        private List<DisplayModels.TVProgram> displayPrograms;
        private DayTimeSortedList<DisplayModels.TVProgram> sortedDisplayPrograms = new DayTimeSortedList<DisplayModels.TVProgram>();

        private List<TVGenre> genres;
        private TVGenre selectedGenre;

        private CircularList<string> daysOfWeek = new(Models.DayOfWeek.DaysOfWeek);

        private string selectedLeftDay = "Monday";
        private string selectedRightDay = "Sunday";

        private Time leftTime = new Time(0, 0);
        private Time rightTime = new Time(23, 59);

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
            LoadShows();
            UpdateShowsDataGrid();
            ShowsDataGrid.Columns["IDShow"].Visible = false;
            ShowsDataGrid.Columns["Genres"].Visible = false;
            ShowsDataGrid.Columns["Programs"].Visible = false;
            ShowsDataGrid.Columns["Channels"].Visible = false;

            // Fill programs
            LoadPrograms();
            UpdateProgramsDataGrid();
            ProgramsDataGrid.Columns["IDShow"].Visible = false;
            ProgramsDataGrid.Columns["IDChannel"].Visible = false;
            ProgramsDataGrid.Columns["DayOfWeek"].Visible = false;
            ProgramsDataGrid.Columns["Time"].Visible = false;

            // Fill genres
            genres = ProviderFactory.Instance.GenreProvider.GetAll().ToList();

            // Fill genres combo box
            GenresComboBox.Items.AddRange(genres.Select(x => x.NameGenre).ToArray());
            GenresComboBox.Items.Add("Все");
            GenresComboBox.Text = "Все";

            GenresProgramsComboBox.Items.AddRange(genres.Select(x => x.NameGenre).ToArray());
            GenresProgramsComboBox.Items.Add("Все");
            GenresProgramsComboBox.Text = "Все";

            // Fill days of week
            LeftComboBox.Items.AddRange(daysOfWeek.ToArray());
            RightComboBox.Items.AddRange(daysOfWeek.ToArray());

            LeftComboBox.Text = selectedLeftDay;
            RightComboBox.Text = selectedRightDay;

            // Fill times
            StartTimeTextBox.Text = "00:00";
            EndTimeTextBox.Text = "23:59";
        }

        #region Handlers
        private void AddShowButton_Click(object sender, EventArgs e)
        {
            var form = new AddEditShow();
            form.FormClosed += AddEditFormClosed;
            form.Show();
        }

        private void RemoveShowButton_Click(object sender, EventArgs e)
        {
            ProviderFactory.Instance.ShowProvider.Delete(GetSelectedShow().IDShow);
            LoadShows();
            FilterShows();
        }

        private void ShowsDataGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var form = new AddEditShow(GetSelectedShow());
            form.FormClosed += AddEditFormClosed;
            form.Show();
        }

        // Filter
        private void ShowButton_Click(object sender, EventArgs e)
        {
            FilterShows();
            UpdateShowsDataGrid();
        }

        private void ChannelAdminMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void GenresComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectedGenre = genres[GenresComboBox.SelectedIndex];
            }
            catch (ArgumentOutOfRangeException)
            {
                selectedGenre = null;
            }
        }

        private void ProgramsDataGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var selectedProgram = GetSelectedProgram();
            var editableProgram = ProviderFactory.Instance.ProgramProvider.Get(new TVProgramPK
            {
                IDShow = selectedProgram.IDShow,
                IDChannel = selectedProgram.IDChannel,
                StartDayOfWeek = selectedProgram.StartWeekDay,
                StartTime = selectedProgram.StartTime
            });
            var form = new AddEditProgram(editableProgram);
            form.FormClosed += AddEditFormClosed;
            form.Show();
        }

        private void AddProgram_Click(object sender, EventArgs e)
        {
            var form = new AddEditProgram();
            form.FormClosed += AddEditFormClosed;
            form.Show();
        }

        private void RemoveProgram_Click(object sender, EventArgs e)
        {
            var selectedProgram = GetSelectedProgram();
            ProviderFactory.Instance.ProgramProvider.Delete(new TVProgramPK
            {
                IDShow = selectedProgram.IDShow,
                IDChannel = selectedProgram.IDChannel,
                StartDayOfWeek = selectedProgram.StartWeekDay,
                StartTime = selectedProgram.StartTime
            });
            LoadPrograms();
            FilterPrograms();
        }

        private void Filter_Click(object sender, EventArgs e)
        {
            FilterPrograms();
        }

        private void GenresProgramsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectedGenre = genres[GenresComboBox.SelectedIndex];
            }
            catch (ArgumentOutOfRangeException)
            {
                selectedGenre = null;
            }
        }

        private void LeftComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedLeftDay = daysOfWeek.GetElement(LeftComboBox.Text);
        }

        private void RightComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedRightDay = daysOfWeek.GetElement(RightComboBox.Text);
        }
        #endregion

        private void AddEditFormClosed(object sender, FormClosedEventArgs e)
        {
            LoadShows();
            FilterShows();

            LoadPrograms();
            FilterPrograms();
        }

        private void LoadShows()
        {
            shows = ProviderFactory.Instance.ChannelProvider.Get(currentChannel.IDChannel).Shows.ToList();
            displayShows = shows;
        }

        private void LoadPrograms()
        {
            programs = ProviderFactory.Instance.ProgramProvider.GetAll().Where(x => x.IDChannel == currentChannel.IDChannel).ToList();
            SetDisplayProgramsByPrograms();
        }

        private void FilterShows()
        {
            // Reset list
            displayShows = new();

            // Select by name
            var name = ShowTextBox.Text;
            if (!string.IsNullOrEmpty(name))
            {
                foreach (var show in shows)
                {
                    if (show.NameShow.Contains(name))
                        displayShows.Add(show);
                }
            }
            else
            {
                displayShows = shows;
            }

            // Select by genre
            var temp = new List<TVShow>();
            if (selectedGenre is not null)
            {
                foreach (var show in displayShows)
                {
                    if (show.Genres.Contains(selectedGenre))
                        temp.Add(show);
                }
                displayShows = temp;
            }

            UpdateShowsDataGrid();
        }

        private void FilterPrograms()
        {
            var showName = ShowTextBox.Text;

            // Reset list
            sortedDisplayPrograms = new();

            // Select by genre
            if (selectedGenre is not null)
            {
                foreach (var program in programs)
                {
                    var show = ProviderFactory.Instance.ShowProvider.Get(program.IDShow);
                    if (show.Genres.ToList().Any(x => x.IDGenre == selectedGenre.IDGenre))
                        sortedDisplayPrograms.TryAdd(new DisplayModels.TVProgram(program));
                }
            }
            else
            {
                SetDisplayProgramsByPrograms();
            }

            // Select by show and channel
            var temp = new DayTimeSortedList<DisplayModels.TVProgram>();
            foreach (var program in sortedDisplayPrograms)
            {
                if (program.NameShow.Contains(showName))
                    temp.TryAdd(program);
            }
            sortedDisplayPrograms = temp;

            // Select by day of week
            temp = new DayTimeSortedList<DisplayModels.TVProgram>();

            var days = daysOfWeek.GetElementsBetween(selectedLeftDay, selectedRightDay).ToList();
            foreach (var program in sortedDisplayPrograms)
            {
                if (days.Contains(program.StartWeekDay))
                    temp.TryAdd(program);
            }
            sortedDisplayPrograms = temp;

            // Select by time
            // Default values
            Time leftTime = new Time(0, 0);
            Time rightTime = new Time(23, 59);
            try
            {
                leftTime = Time.FromString(StartTimeTextBox.Text);
                rightTime = Time.FromString(EndTimeTextBox.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Время было задано в неправильном формате", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            temp = new DayTimeSortedList<DisplayModels.TVProgram>();
            foreach (var program in sortedDisplayPrograms)
            {
                if (program.StartWeekDay.Equals(days[0])) // Check start time
                {
                    if (program.StartTime.GreaterOrEqualTo(leftTime))
                        temp.TryAdd(program);
                }
                else if (program.StartWeekDay.Equals(days[^1])) // Check end time
                {
                    if (program.StartTime.LessOrEqualTo(rightTime))
                        temp.TryAdd(program);
                }
                else if (!program.StartWeekDay.Equals(days[0]) &&
                    !program.StartWeekDay.Equals(days[^1]) &&
                    days.Contains(program.StartWeekDay)) // Write if value between left and right lines
                    temp.TryAdd(program);
            }
            sortedDisplayPrograms = temp;

            UpdateProgramsDataGrid();
        }

        private void UpdateShowsDataGrid()
        {
            ShowsDataGrid.DataSource = displayShows;
        }

        private void UpdateProgramsDataGrid()
        {
            displayPrograms = sortedDisplayPrograms.ToList();
            ProgramsDataGrid.DataSource = displayPrograms;
        }

        private void SetDisplayProgramsByPrograms()
        {
            // Set programs to displayPrograms to show them
            // Used to not override ToString()
            sortedDisplayPrograms = new DayTimeSortedList<DisplayModels.TVProgram>();
            foreach (var program in programs)
                sortedDisplayPrograms.TryAdd(new DisplayModels.TVProgram(program));

            displayPrograms = sortedDisplayPrograms.ToList();
        }

        private TVShow GetSelectedShow()
        {
            // If nothing is selected but method is called
            // We will do nothing
            if (ShowsDataGrid.SelectedRows.Count <= 0) return null;

            // Get index of program in displayPrograms
            var index = ShowsDataGrid.SelectedRows[0].Index;
            // Get selected program
            return displayShows[index];
        }

        private DisplayModels.TVProgram GetSelectedProgram()
        {
            // If nothing is selected but method is called
            // We will do nothing
            if (ProgramsDataGrid.SelectedRows.Count <= 0) return null;

            // Get index of program in displayPrograms
            var index = ProgramsDataGrid.SelectedRows[0].Index;
            // Get selected program
            return sortedDisplayPrograms[index];
        }
    }
}
