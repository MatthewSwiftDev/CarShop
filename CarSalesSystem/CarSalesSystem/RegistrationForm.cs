using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarSalesSystem
{
    public partial class RegistrationForm : Form
    {
        MainPage_Guest PreForm;
        public RegistrationForm(MainPage_Guest BackForm)
        {
            PreForm = BackForm;
            InitializeComponent();
        }

 
        private void buttonRegistration_Click(object sender, EventArgs e)
        {
            bool LoginRight = false; // Флаг для проверки уникальности Login                  
            bool PasswordMatch = false; // Флаг для проверки совпадения паролей

            LoginRight = false;
            PasswordMatch = false;

            // Проверка на совпадение двух паролей
            if (PasswordText.Text == RePasswordText.Text)
                PasswordMatch = true;
            else
                MessageBox.Show("Пароли не совпадают,\nвведите заново");
            // Поиск в базе пользователя с таким же Login (Этот параметр должен быть уникальным для каждого пользователя)

            bool ExistUsers = false;
            using (var context = new MyDbContext())
            {
                var UserFind = context.Users.ToList();
                foreach (User userF in UserFind)
                {
                    ExistUsers = true;
                    // Если встречаем такой логин в базе, то сразу выходим из цикла
                    if (userF.Login.Equals(LoginText.Text))
                    {
                        LoginRight = false;
                        break;
                    }
                    else
                        LoginRight = true;
                }
            }

            // Различаем обычного пользователся от админа
            bool FlagContinue = false;
            string PasswordAdmin = "1111";

            bool FlagAdminPassword = false;
            if (PasswordForAdmin.Text != "" && PasswordForAdmin.Text != PasswordAdmin)
            {
                MessageBox.Show("Неверный пароль\nдля администратора");
                FlagContinue = false;
            }
            else
                FlagContinue = true;

            if (PasswordForAdmin.Text == PasswordAdmin)
            {
                FlagContinue = true;
                FlagAdminPassword = true;
            }

            // Если  пользователей в базе пока нет, то первый зарегистрировавшийся может выбрать любой логин
            if (!ExistUsers)
                LoginRight = true;

            if (LoginRight == false)
                MessageBox.Show("Данный логин уже занят,\nзамените его");


            if (LoginRight && PasswordMatch && FlagContinue)
            {
                User CurrUser;
                using (var context = new MyDbContext())
                {
                    User user1 = new User();
                    UserProfile profile1 = new UserProfile();

                    user1.Login = LoginText.Text;
                    user1.Password = PasswordText.Text;

                    profile1.UserName = NameText.Text;
                    profile1.PhoneNumber = NumberText.Text;

                    if (FlagAdminPassword)
                        user1.Type = "admin";

                    context.Users.Add(user1);
                    context.UserProfiles.Add(profile1);
                    context.SaveChanges();

                    CurrUser = user1;
                }
                if (!FlagAdminPassword)
                {
                    // Переход на форму для авторизованного пользователя
                    this.Hide();
                    MainPage_UserLogged mainFormUser = new MainPage_UserLogged(CurrUser);
                    mainFormUser.Show();
                }
                else
                {
                    // Переход на форму для админа
                    this.Hide();
                    MainPage_AdminLogged mainFormAdmin = new MainPage_AdminLogged(CurrUser);
                    mainFormAdmin.Show();
                }
            }
        }

        private void ContinueAsGuest_Click(object sender, EventArgs e)
        {
            // Переход на форму главного экрана у гостя
            this.Close();
            PreForm.Show();
        }

        private void PasswordForAdmin_TextChanged(object sender, EventArgs e)
        {


        }
    }
}
