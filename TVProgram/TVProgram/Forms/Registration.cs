using System;
using System.Windows.Forms;
using TVProgram.Providers.Factories;

namespace TVProgram.Forms
{
    public partial class Registration : Form
    {
        private Form previousForm;

        public Registration(Form previousForm)
        {
            this.previousForm = previousForm;
            InitializeComponent();
        }

        #region Handlers
        private void submitButton_Click(object sender, EventArgs e)
        {
            var login = loginTextBox.Text;
            var password = passwordTextBox.Text;
            var password2 = passwordConfirmTextBox.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(password2))
            {
                MessageBox.Show("Поля не должны быть пустыми", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!password.Equals(password2))
            {
                MessageBox.Show("Пароли должны совпадать", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ProviderFactory.Instance.UserProvider.Get(login) != null)
            {
                MessageBox.Show("Пользователь с такой учётной записью уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ProviderFactory.Instance.UserProvider.Add(new Models.User { Login = login, Password = password, Status = null });
            MessageBox.Show("Попробуй войти под новой учётной записью");

            GoBackToPreviousForm();
        }

        private void backToPreviousFormButton_Click(object sender, EventArgs e)
        {
            GoBackToPreviousForm();
        }

        private void Registration_FormClosed(object sender, FormClosedEventArgs e)
        {
            previousForm.Show();
        }
        #endregion

        private void GoBackToPreviousForm()
        {
            previousForm.Show();
            this.Close();
        }
    }
}
