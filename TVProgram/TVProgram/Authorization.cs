using System;
using System.Windows.Forms;
using TVProgram.Forms;
using TVProgram.Providers.Factories;

namespace TVProgram
{
	public partial class Authorization : Form
	{
		public Authorization()
		{
			InitializeComponent();
        }

        // Sign in act
        private void signInButton_Click(object sender, EventArgs e)
        {
            var login = loginTextBox.Text;
            var password = passwordTextBox.Text;

            // Validate on empty strings
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Поля не должны быть пустыми", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Try to get user
                var user = ProviderFactory.Instance.UserProvider.Get(login);
                if (user.Password.Equals(password))
                {
                    // Set user on cache
                    Cache.Instance.CurrectUser = user;
                }
                else
                {
                    MessageBox.Show("Проверьте правильность пароля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var currentUser = Cache.Instance.CurrectUser;
            if (string.IsNullOrEmpty(currentUser.Status))
            {
                // Show form with programs list
                this.Hide();
                new ProgramsShow().Show();
            }
            else if (currentUser.Status.Equals("admin"))
            {
                // Show form with admin menu
                this.Hide();
                new AdminMenu().Show();
            }
            else
            {
                // Show form with channel admin menu
                this.Hide();
                new ChannelAdminMenu().Show();
            }
        }

        // Move to registration form
        private void signUpButton_MouseClick(object sender, MouseEventArgs e)
        {
            // Set empty to text boxes
            loginTextBox.Text = string.Empty;
            passwordTextBox.Text = string.Empty;

            this.Hide();
            new Registration(this).Show();
        }
    }
}
