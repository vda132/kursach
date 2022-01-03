using System;
using System.Linq;
using System.Windows.Forms;
using TVProgram.Models;
using TVProgram.Providers.Factories;

namespace TVProgram.Forms
{
    public partial class AddEditShow : Form
    {
        private TVShow editableShow;

        public AddEditShow(TVShow show = null)
        {
            InitializeComponent();

            // If we don't transmit genre as parameter we can add genre
            // Otherwise we can edit transmited genre
            if (show is null)
            {
                AddEditButton.Text = "Добавить";
                Text = "Добавить";
            }
            else
            {
                AddEditButton.Text = "Изменить";
                Text = "Изменить";
            }

            editableShow = show;
        }

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

        private bool TryAdd(string showName)
        {
            if (!CheckOnIdentity(showName))
                return false;

            ProviderFactory.Instance.ShowProvider.Add(new TVShow { NameShow = showName });
            return true;
        }

        private bool TryEdit(string showName)
        {
            if (!CheckOnIdentity(showName))
                return false;

            ProviderFactory.Instance.ShowProvider.Update(editableShow.IDShow, new TVShow { NameShow = showName });
            return true;
        }

        private bool CheckOnIdentity(string showName)
        {
            // Check is show with similar name not contained
            return !ProviderFactory.Instance.ShowProvider.GetAll().Select(x => x.NameShow).Contains(showName);
        }

        private void BackToPrevious()
        {
            this.Close();
        }
    }
}
