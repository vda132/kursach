using System.Windows.Forms;
using TVProgram.Models;
using System;
using TVProgram.Providers.Factories;
using System.Linq;

namespace TVProgram.Forms
{
    public partial class AddEditChannel : Form
    {
        private TVChannel editableChannel;
        
        public AddEditChannel(TVChannel channel = null)
        {
            InitializeComponent();

            if (channel is not null)
            {
                ChannelTextBox.Text = channel.NameChannel;
                var userChannel = ProviderFactory.Instance.UserProvider.GetAll().First(x => x.Status.Equals(channel.NameChannel));
                LoginTextBox.Text = userChannel.Login;
                PasswordTextBox.Text = userChannel.Password;
            }

            // If we don't transmit genre as parameter we can add genre
            // Otherwise we can edit transmited genre
            if (channel is null)
            {
                AddEditButton.Text = "Добавить";
                Text = "Добавить";
            }
            else
            {
                AddEditButton.Text = "Изменить";
                Text = "Изменить";
            }

            editableChannel = channel;
        }

        #region Handlers
        private void AddEditButton_Click(object sender, EventArgs e)
        {
            var name = ChannelTextBox.Text;
            var login = LoginTextBox.Text;
            var password = PasswordTextBox.Text;
            if (editableChannel is null)
            {
                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password))
                {
                    if (TryAdd(name, login, password)) BackToPrevious();
                    else MessageBox.Show("Такой канал уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if (TryEdit(name, login, password)) BackToPrevious();
                    else MessageBox.Show("Не получилось изменить канал", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private bool TryAdd(string channelName, string channelLogin, string channelPassword)
        {
            if (!CheckNameOnIdentity(channelName) || !CheckLoginOnIdentity(channelLogin))
                return false;

            ProviderFactory.Instance.ChannelProvider.Add(new TVChannel { NameChannel = channelName });
            ProviderFactory.Instance.UserProvider.Add(new User { Login = channelLogin, Password = channelPassword, Status = channelName });
            return true;
        }

        private bool TryEdit(string channelName, string channelLogin, string channelPassword)
        {
            var userChannel = ProviderFactory.Instance.UserProvider.GetAll().First(x => x.Status.Equals(editableChannel.NameChannel));

            // If name is not changed name passes validation
            var nameValidate = channelName.Equals(editableChannel.NameChannel) ? true : CheckNameOnIdentity(channelName); 
            // If login is not changed login passes validation
            var loginValid = channelLogin.Equals(userChannel.Login) ? true : CheckLoginOnIdentity(channelLogin);

            if (!nameValidate || !loginValid)
                return false;

            ProviderFactory.Instance.ChannelProvider.Update(editableChannel.IDChannel, new TVChannel { NameChannel = channelName });
            ProviderFactory.Instance.UserProvider.Update(userChannel.Login, new User 
            {
                Login = channelLogin, 
                Password = channelPassword, 
                Status = channelName 
            });
            return true;
        }

        private bool CheckNameOnIdentity(string channelName)
        {
            // Check is channel with similar name not contained
            return !ProviderFactory.Instance.ChannelProvider.GetAll().Select(x => x.NameChannel).Contains(channelName);
        }

        private bool CheckLoginOnIdentity(string channelLogin)
        {
            // Check is channel with similar login not contained
            return !ProviderFactory.Instance.UserProvider.GetAll().Select(x => x.Login).Contains(channelLogin);
        }

        private void BackToPrevious()
        {
            this.Close();
        }
    }
}
