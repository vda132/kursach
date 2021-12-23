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
            if (providerFactory.UserProvider.GetAll().Select(user => user.UserLogin).Contains(loginTextBox.Text))
            {
                MessageBox.Show("Пользователь с таким логином уже существует", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(passwordTextBox1.Text) ||
                string.IsNullOrEmpty(passwordTextBox2.Text) ||
                string.IsNullOrEmpty(loginTextBox.Text) ||
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
                int count = providerFactory.UserProvider.GetAll().Count;
                int readerId = ++count;
                try
                {
                    providerFactory.ReaderProvider.Add(new Models.Reader
                    {
                        ReaderNo = readerId,
                        ReaderName = readerNameTextBox.Text,
                        Adress = adressTextBox.Text,
                        Phone = phoneTextBox.Text
                    });
                    providerFactory.UserProvider.Add(new Models.Users
                    {
                        UserLogin = loginTextBox.Text,
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
