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

namespace Library.Forms
{
    public partial class Registration : Form
    {
        private Form previousForm;
        private string userType = "Читатель";
        private FactoryProvider providerFactory = FactoryProvider.GetInstance();
        public Registration(Form previousForm)
        {
            InitializeComponent();
            this.previousForm = previousForm; 
            this.Text = "Библиотека регистрация";
            passwordTextBox1.PasswordChar = '*';
            passwordTextBox2.PasswordChar = '*';
        }

        private bool IsValid()
        {
            if (string.IsNullOrEmpty(passwordTextBox1.Text) ||
                string.IsNullOrEmpty(passwordTextBox2.Text) ||
                string.IsNullOrEmpty(readerNameTextBox.Text)||
                string.IsNullOrEmpty(adressTextBox.Text)||
                string.IsNullOrEmpty(phoneTextBox.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (phoneTextBox.Text.Length > 13)
            {
                MessageBox.Show("Вы ввели слишком длинный номер телефона.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                return false;
            }
            if (passwordTextBox1.Text != passwordTextBox2.Text)
            {
                MessageBox.Show("Пароли не совпадают", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
            return true;
        }
        private void BackToPreviousForm()
        {
            previousForm.Show();
            this.Close();
        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                try
                {
                    providerFactory.ReaderProvider.Add(new Models.Reader
                    {
                        ReaderName = readerNameTextBox.Text,
                        Adress = adressTextBox.Text,
                        Phone = phoneTextBox.Text
                    });
                    int id = providerFactory.ReaderProvider.GetAll().Max(A => A.ReaderNo);
                    providerFactory.UserProvider.Add(new Models.Users
                    {
                        UserLogin = id.ToString(),
                        UserPassword = passwordTextBox1.Text,
                        UserType = userType
                    });
                    MessageBox.Show("Регистрация успешна!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BackToPreviousForm();
                }
                catch
                {
                    MessageBox.Show("Вы ввели некоректные данные.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
