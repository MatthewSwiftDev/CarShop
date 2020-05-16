using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using CsvHelper;

namespace CarSalesSystem
{
    public partial class FormSendDetail : Form
    {
        public FormSendDetail()
        {
            InitializeComponent();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                var CurrentCar = context.Cars.ToList();

                string OutFile = textBox1.Text;            
                   
                StringBuilder newstiring = new StringBuilder();
                newstiring.AppendLine("Марка;Модель;Номер телефона;Место продажи;Цена;Тип двигателя;" + OutFile);

                foreach (var CarAd in CurrentCar)
                {
                    newstiring.AppendLine(CarAd.Title + ";" + CarAd.Model + ";" + CarAd.PhoneNumber + ";" + CarAd.PlaceOfSale + ";" + CarAd.Price + ";" + CarAd.Engine);
                }

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Выберите файл";
                sfd.Filter = "Text files(*.csv)|*.csv|All files(*.*)|*.*";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string csvpath = sfd.FileName;
                    File.AppendAllText(csvpath, newstiring.ToString(), Encoding.UTF8);
                    MessageBox.Show("Отчет успешно сохранен в файл " + sfd.FileName, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }
    }
}
