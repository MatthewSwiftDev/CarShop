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
    public partial class LoginForm : Form
    {
        MainPage_Guest PreForm;
        public LoginForm(MainPage_Guest BackForm)
        {
            PreForm = BackForm;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Флаг нахождения такого логина в базе
            bool LoginRight = false;          
            var NeededUser = new User();
           
            // Сверяем с данными из БД
            using (var context = new MyDbContext())
            {
                var UserFind = context.Users.ToList();
                foreach (User userF in UserFind)
                {
                    // Если встречаем такой логин в базе, то сверяем пароль
                    if (userF.Login.Equals(LoginText.Text))
                    {
                        LoginRight = true;
                        NeededUser = userF;
                    }
                }
                if (!LoginRight)
                    MessageBox.Show("Неверный логин.");
                else
                {
                    if (PasswordText.Text == NeededUser.Password)
                    {
                        if (NeededUser.Type == "admin")
                        {
                            // Переход на форму админа
                            MainPage_AdminLogged mainFormAdmin = new MainPage_AdminLogged(NeededUser);
                            mainFormAdmin.Show();
                        }
                        else
                        {
                            // Переход на форму для авторизованного пользователя
                            MainPage_UserLogged mainFormUser = new MainPage_UserLogged(NeededUser);
                            int a = NeededUser.Id;
                            mainFormUser.Show();

                            this.Hide(); // Скрываем эту форму
                        }
                      
                    }
                    else
                        MessageBox.Show("Неверный пароль.");
                }
            }
            // Окно входа скрывается по завершению работы с ней  
        }

        private void ContinueAsGuest_Click(object sender, EventArgs e)
        {
            // Переход на форму главного экрана у гостя
            this.Close();           
            PreForm.Show();          
        }        
    }
}
