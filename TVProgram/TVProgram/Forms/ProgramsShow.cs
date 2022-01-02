using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TVProgram.DataStructures;
using TVProgram.Models;
using TVProgram.Providers.Factories;

namespace TVProgram.Forms
{
    public partial class ProgramsShow : Form
    {
        private List<Models.TVProgram> programs;
        private List<DisplayModels.TVProgram> displayPrograms;
        private DayTimeSortedList<DisplayModels.TVProgram> sortedDisplayPrograms = new DayTimeSortedList<DisplayModels.TVProgram>();

        private List<Models.TVGenre> genres;
        private Models.TVGenre selectedGenre;

        // ToDo: translate to russian
        private CircularList<string> daysOfWeek = new() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

        private string selectedLeftDay = "Monday";
        private string selectedRightDay = "Sunday";

        private Time leftTime = new Time(0, 0);
        private Time rightTime = new Time(23, 59);

        public ProgramsShow()
        {
            InitializeComponent();

            // Get programs from db
            programs = ProviderFactory.Instance.ProgramProvider.GetAll().ToList();

            SetDisplayProgramsByPrograms();

            // Hide Ids from DataGrid
            UpdateDataGrid();
            ShowsDataGrid.Columns["IDShow"].Visible = false;
            ShowsDataGrid.Columns["IDChannel"].Visible = false;

            // Get genres from db
            genres = ProviderFactory.Instance.GenreProvider.GetAll().ToList();

            // Fill genre
            GenresComboBox.Items.AddRange(genres.Select(x => x.NameGenre).ToArray());

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
        // Show info about program
        private void showsDataGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var selectedProgram = GetSelectedProgram();

            // Show MessageBox with this program
            MessageBox.Show(selectedProgram.FormMessage());
        }

        // Filters
        private void Filter_Click(object sender, System.EventArgs e)
        {
            FilterPrograms();
            UpdateDataGrid();
        }

        // Choose genre to filter
        private void genresComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (sender is ComboBox comboBox)
                selectedGenre = genres[comboBox.SelectedIndex];
        }

        // Choose start day of week to filter
        private void leftComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (sender is ComboBox comboBox)
                selectedLeftDay = daysOfWeek.GetElement(comboBox.Text);
        }

        // Choose end day of week to filter
        private void rightComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (sender is ComboBox comboBox)
                selectedRightDay = daysOfWeek.GetElement(comboBox.Text);
        }

        private void ProgramsShow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        #endregion

        private void FilterPrograms()
        {
            var showName = ShowTextBox.Text;
            var channelName = ChannelTextBox.Text;

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
                if (program.NameShow.Contains(showName) &&
                    program.NameChannel.Contains(channelName))
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

            UpdateDataGrid();
        }

        private DisplayModels.TVProgram GetSelectedProgram()
        {
            // If nothing is selected but method is called
            // We will do nothing
            if (ShowsDataGrid.SelectedRows.Count <= 0) return null;

            // Get index of program in displayPrograms
            var index = ShowsDataGrid.SelectedRows[0].Index;
            // Get selected program
            return sortedDisplayPrograms[index];
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

        private void UpdateDataGrid()
        {
            displayPrograms = sortedDisplayPrograms.ToList();
            ShowsDataGrid.DataSource = displayPrograms;
        }
    }
}
