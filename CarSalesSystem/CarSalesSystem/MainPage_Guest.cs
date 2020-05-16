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
    public partial class MainPage_Guest : Form
    {
        public MainPage_Guest()
        {
            InitializeComponent();
        }

        private void LogIn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var PreForm = this;
            LoginForm LogForm = new LoginForm(PreForm);            
            LogForm.Show();        
        }        

        private void Register_Click(object sender, EventArgs e)
        {
            this.Hide();
            var PreForm = this;
            RegistrationForm RegForm = new RegistrationForm(PreForm);
            RegForm.Show();            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonFindAds_Click(object sender, EventArgs e)
        {
            ListOfAds_Guest Ads = new ListOfAds_Guest();
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

        private void buttonLADA_Click(object sender, EventArgs e)
        {
            ListOfAdsFiltration Ads = new ListOfAdsFiltration("LADA");
            Ads.Show();
        }

        private void buttonToyota_Click(object sender, EventArgs e)
        {
            ListOfAdsFiltration Ads = new ListOfAdsFiltration("Toyota");
            Ads.Show();
        }

        private void buttonKia_Click(object sender, EventArgs e)
        {
            ListOfAdsFiltration Ads = new ListOfAdsFiltration("Kia");
            Ads.Show();
        }
    }
}
