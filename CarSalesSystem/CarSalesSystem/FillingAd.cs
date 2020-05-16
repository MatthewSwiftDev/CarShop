using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarSalesSystem
{
    public partial class FillingAd : Form
    {
        public byte[] imageB;
        User CurrentUser;
        FileData files = new FileData();
        bool flagPhoto = false;

        public FillingAd(User NeededUser)
        {
            CurrentUser = NeededUser;
            InitializeComponent();
        }
       
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            Car AdCar = new Car();
            using (var context = new MyDbContext())
            {
                AdCar.Title = comboBoxMark.Text;
                AdCar.Model = textBoxModel.Text;
                AdCar.Price = PriceText.Text;
                AdCar.Year = textBoxYear.Text;
                AdCar.Mileage = textBoxMil.Text;
                AdCar.BodyType = comboBoxTypeBody.Text;
                AdCar.Colour = textBoxColour.Text;
                AdCar.Engine = comboBoxEngine.Text;
                AdCar.DriveUnit = comboBoxDriveUnit.Text;
                AdCar.Transmission = comboBoxTransmission.Text;
                AdCar.Description = textBoxDescription.Text;
                AdCar.PhoneNumber = textBoxPhone.Text;
                AdCar.PlaceOfSale = textBoxPlace.Text;
                //Передаём ID пользователя, который продаёт этот автомобиль
                AdCar.UserId = CurrentUser.Id;

                context.Cars.Add(AdCar);
                context.SaveChanges();
            }

            if (flagPhoto)
            {
                using (var context = new MyDbContext())
                {
                    // Сохраняем Id объявления для этой картинки
                    files.userI = AdCar.Id;
                    context.Entry(files).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }
        private void FillingAd_Load(object sender, EventArgs e)
        {

        }

        private void buttonPhoto_Click(object sender, EventArgs e)
        {
        
            using (var context = new MyDbContext())
            {             
                OpenFileDialog dialog = new OpenFileDialog();

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    Image image = Image.FromFile(dialog.FileName);
                    System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
                    image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                    imageB = memoryStream.ToArray();

                    long Size = imageB.Length;
                    if (imageB.Length < 10485760)
                    {
                        files.Image = imageB;

                        context.Files.Add(files);
                        context.SaveChanges();
                        pictureBox1.Image = image;
                        flagPhoto = true;
                    }
                    else
                        MessageBox.Show("Размер картинки должен\nбыть меньше 10 MB");
                }
            }
            

        }

        private void comboBoxDriveUnit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
