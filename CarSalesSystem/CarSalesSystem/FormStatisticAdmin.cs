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
    public partial class FormStatisticAdmin : Form
    {
        public FormStatisticAdmin()
        {
            InitializeComponent();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 10;

            using (var context = new MyDbContext())
            {
                var CurrentSale = context.Sales.ToList();

                foreach (Sale CarSale in CurrentSale)
                {
                    if (progressBar1.Value == 9)
                        progressBar1.Value = 0;
                    progressBar1.Value += 1;
                }
                label3.Text = Convert.ToString(progressBar1.Value) + "/10";
            }
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
