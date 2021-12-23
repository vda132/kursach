using Library.Cache;
using Library.Forms;
using Library.Providers.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class Authorization : Form
    {
        private FactoryProvider factoryProvider = FactoryProvider.GetInstance();
        public Authorization()
        {
            InitializeComponent();
            passwordTextBox.PasswordChar = '*';
            this.Text = "Авторизация";
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(loginTextBox.Text)|| String.IsNullOrEmpty(passwordTextBox.Text)) throw new Exception("Поля должны быть заполнены.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            var user = factoryProvider.UserProvider.GetAll().FirstOrDefault(A=>A.UserLogin.Equals(loginTextBox.Text)&&A.UserPassword.Equals(passwordTextBox.Text));
            if (user == null)
            {
                MessageBox.Show("Неверный логин или пароль!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var userCache = UserCache.GetInstance();
            userCache.CurrentUser = user;
            MessageBox.Show($"Вы вошли как {userCache.CurrentUser.UserType}.", "Успешно!", MessageBoxButtons.OK);
            ClearFields();
            this.Hide();
        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            new Registration(this).Show();
            this.Hide();
        }
        private void ClearFields()
        {
            loginTextBox.Text = null;
            passwordTextBox.Text = null;
        }
    }
}
