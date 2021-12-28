using Library.Models;
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
    public partial class WorkSpace : Form
    {
        FactoryProvider provider = FactoryProvider.GetInstance();
        List<Users> users = new List<Users>();
        Form previousForm;
        Users user;
        public WorkSpace(Form form, Users user)
        {
            InitializeComponent();
            loginTextBox.ReadOnly = true;
            passwordTextBox.ReadOnly = true;
            dataGridView1.MultiSelect = false;
            ApplyChanges.Visible = false;
            DeleteLibrarianButton.Enabled = false;
            this.user = user;
            previousForm = form;
            loginTextBox.Text = user.UserLogin;
            passwordTextBox.Text = user.UserPassword;
            dataGridView1.Columns[0].Width = 90;
            dataGridView1.Columns[1].Width = 90;
            dataGridView1.Columns[2].Width = 120;
            LoadData();
        }
        private void LoadData()
        {
            dataGridView1.Rows.Clear();
            users = provider.UserProvider.GetAll().Where(A=>A.UserType=="Библиотекарь").ToList();
            foreach (var user in users)
            {
                dataGridView1.Rows.Add(user.UserLogin, user.UserPassword,user.UserType);
            }
        }

        private void editInfoButton_Click(object sender, EventArgs e)
        {
            editInfoButton.Enabled = false;
            loginTextBox.ReadOnly = false;
            passwordTextBox.ReadOnly = false;
            ApplyChanges.Visible = true;
        }

        private void ApplyChanges_Click(object sender, EventArgs e)
        {
            editInfoButton.Enabled = true;
            loginTextBox.ReadOnly = true;
            passwordTextBox.ReadOnly = true;
            dataGridView1.MultiSelect = false;
            ApplyChanges.Visible = false;
            if (String.IsNullOrEmpty(loginTextBox.Text) || String.IsNullOrEmpty(passwordTextBox.Text))
            {
                MessageBox.Show("Поля должны быть заполнены!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var tmpUser = provider.UserProvider.GetAll().FirstOrDefault(A => A.IdUser == user.IdUser);
            tmpUser.UserLogin = loginTextBox.Text;
            tmpUser.UserPassword = passwordTextBox.Text;
            if (provider.UserProvider.GetAll().FirstOrDefault(A => A.IdUser != tmpUser.IdUser && A.UserLogin == tmpUser.UserLogin) != null)
            {
                MessageBox.Show("Такой логин уже есть!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            provider.UserProvider.Update(tmpUser.IdUser,tmpUser);
            MessageBox.Show("Информация сохранена.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Вы точно хотите вернуться на страницу авторизации? ", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                previousForm.Show();
            }
        }

        private void AddLibrarianbutton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(libLoginTextBox.Text) || String.IsNullOrEmpty(libPasswordTextBox.Text))
            {
                MessageBox.Show("Поля должны быть заполнены!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (provider.UserProvider.GetAll().FirstOrDefault(A => A.UserLogin == libLoginTextBox.Text) != null)
            {
                MessageBox.Show("Такой логин уже есть!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Users tmpUser = new Users
            {
                UserLogin = libLoginTextBox.Text,
                UserPassword = libPasswordTextBox.Text,
                UserType = "Библиотекарь"
            };
            provider.UserProvider.Add(tmpUser);
            MessageBox.Show("Библиотекарь добавлен.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            libLoginTextBox.Text = null;
            libPasswordTextBox.Text = null;
            LoadData();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            DeleteLibrarianButton.Enabled=true;
        }

        private void DeleteLibrarianButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Вы точно хотите удалить данного библиотекаря? ", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Users tmpUser = users[dataGridView1.CurrentCell.RowIndex];
                provider.UserProvider.Delete(tmpUser.IdUser);
                LoadData();
            }
        }
    }
}
