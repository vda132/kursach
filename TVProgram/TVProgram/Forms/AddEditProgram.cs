using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TVProgram.DataStructures;
using TVProgram.Models;
using TVProgram.Providers.Factories;

namespace TVProgram.Forms
{
    public partial class AddEditProgram : Form
    {
        private TVChannel currentChannel;
        private TVShow currentShow;

        private Models.TVProgram editableProgram;

        private List<TVShow> shows;
        private TVShow selectedShow;

        private CircularList<string> daysOfWeek = new(Models.DayOfWeek.DaysOfWeek);

        private string selectedLeftDay = "Monday";
        private string selectedRightDay = "Sunday";

        private Time leftTime = new Time(0, 0);
        private Time rightTime = new Time(23, 59);

        public AddEditProgram(Models.TVProgram program = null)
        {
            InitializeComponent();

            // Get current channel by user
            var currentUser = Cache.Instance.CurrectUser;
            currentChannel = ProviderFactory.Instance.ChannelProvider.GetAll().First(x => x.NameChannel.Equals(currentUser.Status));

            editableProgram = program;

            if (program is null)
            {
                ShowLabel.Visible = true;
                ShowsComboBox.Visible = true;
                ShowName.Visible = false;

                AddEditButton.Text = "Добавить";
            }
            else
            {
                ShowLabel.Visible = false;
                ShowsComboBox.Visible = false;
                ShowName.Visible = true;

                currentShow = ProviderFactory.Instance.ShowProvider.Get(program.IDShow);
                ShowName.Text = currentShow.NameShow;

                AddEditButton.Text = "Изменить";
            }

            // Fill shows
            shows = ProviderFactory.Instance.ShowProvider.GetAll().Where(x => x.Channels.Select(c => c.IDChannel).Contains(currentChannel.IDChannel)).ToList();
            ShowsComboBox.Items.AddRange(shows.Select(x => x.NameShow).ToArray());

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
        private void BackButton_Click(object sender, EventArgs e)
        {
            BackToPrevious();
        }

        private void AddEditButton_Click(object sender, EventArgs e)
        {
            if (selectedShow is null)
            {
                MessageBox.Show("Нужно выбрать передачу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(StartTimeTextBox.Text) || string.IsNullOrEmpty(EndTimeTextBox.Text))
            {
                MessageBox.Show("Нужно заполнить времена", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var startDayOfWeek = selectedLeftDay;
            var endDayOfWeek = selectedRightDay;
            Time startTime;
            Time endTime;
            try
            {
                startTime = Time.FromString(StartTimeTextBox.Text);
                endTime = Time.FromString(EndTimeTextBox.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Неправильный формат времени", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!CheckForIdentity(startDayOfWeek, endDayOfWeek, startTime, endTime))
            {
                MessageBox.Show("Невозможно создать", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (editableProgram is null)
            {
                ProviderFactory.Instance.ProgramProvider.Add(new Models.TVProgram
                {
                    IDChannel = currentChannel.IDChannel,
                    IDShow = selectedShow.IDShow,
                    StartWeekDay = startDayOfWeek,
                    EndWeekDay = endDayOfWeek,
                    StartTime = startTime,
                    EndTime = endTime
                });
            }
            else
            {
                ProviderFactory.Instance.ProgramProvider.Update(
                    new TVProgramPK
                    {
                        IDChannel = editableProgram.IDChannel,
                        IDShow = editableProgram.IDShow,
                        StartDayOfWeek = editableProgram.StartWeekDay,
                        StartTime = editableProgram.StartTime
                    },
                    new Models.TVProgram
                    {
                        IDChannel = currentChannel.IDChannel,
                        IDShow = selectedShow.IDShow,
                        StartWeekDay = startDayOfWeek,
                        EndWeekDay = endDayOfWeek,
                        StartTime = startTime,
                        EndTime = endTime
                    });
            }

            BackToPrevious();
        }

        private void ShowsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedShow = shows[ShowsComboBox.SelectedIndex];
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

        private bool CheckForIdentity(string startDayOfWeek, string endDayOfWeek, Time startTime, Time endTime)
        {
            var programs = ProviderFactory.Instance.ProgramProvider.GetAll().Where(x => x.IDChannel == currentChannel.IDChannel).ToList();

            foreach (var program in programs)
            {
                if (!CheckTimeIntersect(startDayOfWeek, endDayOfWeek, startTime, endTime, 
                    program.StartWeekDay, program.EndWeekDay, program.StartTime, program.EndTime))
                    return false;
            }

            return true;
        }

        private bool CheckTimeIntersect(string leftStartDayOfWeek, string leftEndDayOfWeek, Time leftStartTime, Time leftEndTime,
            string rightStartDayOfWeek, string rightEndDayOfWeek, Time rightStartTime, Time rightEndTime)
        {
            var daysOfWeek = new CircularList<string>(Models.DayOfWeek.DaysOfWeek);

            var leftDays = daysOfWeek.GetElementsBetween(leftStartDayOfWeek, leftEndDayOfWeek).ToList();
            var rightDays = daysOfWeek.GetElementsBetween(rightStartDayOfWeek, rightEndDayOfWeek).ToList();

            var intersectResult = leftDays.Intersect(rightDays);

            // If days are not interset 
            // There is no conflicts
            if (!intersectResult.Any())
                return true;

            // Programs must go consistently 
            if (intersectResult.Count() == 1)
            {
                return leftStartTime.LessTo(rightStartTime) && leftEndTime.LessOrEqualTo(rightStartTime) ||
                    rightStartTime.LessTo(leftStartTime) && rightEndTime.LessOrEqualTo(leftStartTime);
            }

            return false;
        }

        private void BackToPrevious()
        {
            this.Close();
        }
    }
}
