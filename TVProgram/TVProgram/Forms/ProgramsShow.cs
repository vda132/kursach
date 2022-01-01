using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TVProgram.Providers.Factories;

namespace TVProgram.Forms
{
    public partial class ProgramsShow : Form
    {
        private List<Models.TVProgram> programs;
        private List<DisplayModels.TVProgram> displayPrograms;

        private List<Models.TVGenre> genres;
        private Models.TVGenre selectedGenre;

        public ProgramsShow()
        {
            InitializeComponent();

            // Get programs from db
            programs = ProviderFactory.Instance.ProgramProvider.GetAll().ToList();

            SetDisplayProgramsByPrograms();

            // Hide Ids from DataGrid
            UpdateDataGrid();
            showsDataGrid.Columns["IDShow"].Visible = false;
            showsDataGrid.Columns["IDChannel"].Visible = false;

            // Get genres from db
            genres = ProviderFactory.Instance.GenreProvider.GetAll().ToList();

            // Fill genre
            genresComboBox.Items.AddRange(genres.Select(x => x.NameGenre).ToArray());
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
        #endregion

        private void FilterPrograms()
        {
            var showName = ShowTextBox.Text;
            var channelName = channelTextBox.Text;

            // Reset list
            displayPrograms = new();

            // Select by genre
            if (selectedGenre is not null)
            {
                foreach (var program in programs)
                {
                    var show = ProviderFactory.Instance.ShowProvider.Get(program.IDShow);
                    if (show.Genres.ToList().Any(x => x.IDGenre == selectedGenre.IDGenre))
                        displayPrograms.Add(new DisplayModels.TVProgram(program));
                }
            }
            else
            {
                SetDisplayProgramsByPrograms();
            }

            // Select by show and channel
            var temp = new List<DisplayModels.TVProgram>();
            foreach (var program in displayPrograms)
            {
                if (program.NameShow.Contains(showName) &&
                    program.NameChannel.Contains(channelName))
                    temp.Add(program);
            }

            displayPrograms = temp;
        }

        private DisplayModels.TVProgram GetSelectedProgram()
        {
            // If nothing is selected but method is called
            // We will do nothing
            if (showsDataGrid.SelectedRows.Count <= 0) return null;

            // Get index of program in displayPrograms
            var index = showsDataGrid.SelectedRows[0].Index;
            // Get selected program
            return displayPrograms[index];
        }

        private void SetDisplayProgramsByPrograms()
        {
            // Set programs to displayPrograms to show them
            // Used to not override ToString()
            displayPrograms = new List<DisplayModels.TVProgram>();
            foreach (var program in programs)
                displayPrograms.Add(new DisplayModels.TVProgram(program));
        }

        private void UpdateDataGrid()
        {
            showsDataGrid.DataSource = displayPrograms;
        }
    }
}
