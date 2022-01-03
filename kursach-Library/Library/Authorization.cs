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
        //Создание экземпляра фабрики провайдеров для работы с провайдерами базы данных чтобы получить необходимые данные
        private FactoryProvider factoryProvider = FactoryProvider.GetInstance();

        public Authorization()
        {
            InitializeComponent();
            //заполнение текстбокса для пароля символом * при вводе текста
            passwordTextBox.PasswordChar = '*';
            //задание названия окошка
            this.Text = "Авторизация";
        }
        //обработка нажатия на кнопку
        private void EnterButton_Click(object sender, EventArgs e)
        {
            try
            {
                //проверка на то пустые ли поля если да то выкидуем исключение
                if (String.IsNullOrEmpty(loginTextBox.Text)|| String.IsNullOrEmpty(passwordTextBox.Text)) throw new Exception("Поля должны быть заполнены.");
            }
            //ловля исключения
            catch (Exception ex)
            {
                //вывод сообщения об ошибке на экран
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //поиск пользователя в табличке Users с помощью провайдеров 
            var user = factoryProvider.UserProvider.GetAll().FirstOrDefault(A=>A.UserLogin.Equals(loginTextBox.Text)&&A.UserPassword.Equals(passwordTextBox.Text));
            //проверка на ситуацию если пользователя не существует
            if (user == null)
            {
                //вывод сообщения
                MessageBox.Show("Неверный логин или пароль!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //создание кеша для хранения текущего пользователя
            var userCache = UserCache.GetInstance();
            userCache.CurrentUser = user;
            //вывод сообщения о том какой тип пользователя вошел
            MessageBox.Show($"Вы вошли как {userCache.CurrentUser.UserType}.", "Успешно!", MessageBoxButtons.OK);
            //вызов метода для очистки полей
            ClearFields();
            //скрытие текущей формы
            this.Hide();
            //вызов рабочей формы пользователя
            new WorkSpace(this, user).Show();
        }
        //метод для очистки полей
        private void ClearFields()
        {
            loginTextBox.Text = null;
            passwordTextBox.Text = null;
        }
    }
}
