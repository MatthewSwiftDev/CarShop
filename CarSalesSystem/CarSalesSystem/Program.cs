using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarSalesSystem
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            /*
            using (var context = new MyDbContext())
            {
                
                User User = new User()
                {                 
                    Login = "Alexmail",
                    Password = "123"
                };
                context.Users.Add(User);
                //context.SaveChanges();

                UserProfile profile = new UserProfile()
                {
                    UserName = "Alex",
                    PhoneNumber = "894543135"
                };
                context.UserProfiles.Add(profile);
                context.SaveChanges();

            }
            */
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FillingAd_UserLogged());
            Application.Run(new MainPage_Guest());
            //Application.Exit();
        }
    }
}
