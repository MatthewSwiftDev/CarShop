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
    public partial class FormFavCars : Form
    {
        User CurrentUser;
        int k = 0;
        public FormFavCars(User U)
        {
            CurrentUser = U;
            InitializeComponent();
        }

        private void FormFavCars_Load(object sender, EventArgs e)
        {
            int[] massFavCars;

            using (var context = new MyDbContext())
            {
                var CurrentCar = context.Cars.ToList();
                int tempK = k;
                foreach (Car CarAd in CurrentCar)
                {
                    //if(CarAd.UserId == )

                }
            }

        }
    }
}
