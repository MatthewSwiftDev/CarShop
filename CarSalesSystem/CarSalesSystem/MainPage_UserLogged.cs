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
    public partial class MainPage_UserLogged : Form
    {
        // Передаём данные авторизованного пользователя в форму для создания объявления
        User CurrentUser;
        public MainPage_UserLogged(User NeededUser)
        {
            CurrentUser = NeededUser;
            InitializeComponent();
        }

        private void AddAnnouncement_Click(object sender, EventArgs e)
        {
            //int a = CurrentUser.Id;
            FillingAd NewAd = new FillingAd(CurrentUser);
            NewAd.Show();
        }

        // Разлогиниться
        private void ExiteUserLogged_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainPage_Guest ReturnGuest = new MainPage_Guest();
            ReturnGuest.Show();

        }

        private void MyAds_Click(object sender, EventArgs e)
        {
            FormMyAds MyAllAds = new FormMyAds(CurrentUser);
            MyAllAds.Show();
        }

        private void buttonFindAds_Click(object sender, EventArgs e)
        {
            ListOfAds_UserLogged Ads = new ListOfAds_UserLogged(CurrentUser);
            Ads.Show();
        }

        private void buttonFavorites_Click(object sender, EventArgs e)
        {
            FormFavCars Ads = new FormFavCars(CurrentUser);
            Ads.Show();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            FormSendDetail Ads = new FormSendDetail();
            Ads.Show();           
        }

        private void buttonCLose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonAudi_Click(object sender, EventArgs e)
        {
            ListOfAdsFiltration Ads = new ListOfAdsFiltration("Audi");
            Ads.Show();
        }

        private void buttonBMW_Click(object sender, EventArgs e)
        {
            ListOfAdsFiltration Ads = new ListOfAdsFiltration("BMW");
            Ads.Show();
        }

        private void buttonMercedes_Click(object sender, EventArgs e)
        {
            ListOfAdsFiltration Ads = new ListOfAdsFiltration("Mercedes");
            Ads.Show();
        }

        private void buttonKia_Click(object sender, EventArgs e)
        {
            ListOfAdsFiltration Ads = new ListOfAdsFiltration("Kia");
            Ads.Show();
        }

        private void buttonToyota_Click(object sender, EventArgs e)
        {
            ListOfAdsFiltration Ads = new ListOfAdsFiltration("Toyota");
            Ads.Show();
        }

        private void buttonLADA_Click(object sender, EventArgs e)
        {
            ListOfAdsFiltration Ads = new ListOfAdsFiltration("LADA");
            Ads.Show();
        }

        private void buttonCLose_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
