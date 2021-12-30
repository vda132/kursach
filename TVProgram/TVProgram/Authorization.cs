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

        private void signInButton_Click(object sender, EventArgs e)
        {
            var login = loginTextBox.Text;
            var password = passwordTextBox.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Поля не должны быть пустыми", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var user = ProviderFactory.GetInstance().UserProvider.Get(login);
                if (user.Password.Equals(password))
                {
                    Cache.Instance.CurrectUser = user;
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Вы вошли как : " + Cache.Instance.CurrectUser.Login);
        }

        private void signUpButton_MouseClick(object sender, MouseEventArgs e)
        {
            loginTextBox.Text = string.Empty;
            passwordTextBox.Text = string.Empty;

            this.Hide();
            new Registration(this).Show();
        }
    }
}
