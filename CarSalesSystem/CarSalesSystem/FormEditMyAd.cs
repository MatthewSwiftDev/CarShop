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
    public partial class FormEditMyAd : Form
    {
        public byte[] imageB;     
        FileData files = new FileData();
        bool flagPhoto = false;

        Car D;
        public FormEditMyAd(Car dCar)
        {
            D = dCar;
            InitializeComponent();         
            comboBoxMark.Text = dCar.Title;
            PriceText.Text = dCar.Price;
            textBoxYear.Text = dCar.Year;
            textBoxMil.Text = dCar.Mileage;
            comboBoxTypeBody.Text = dCar.BodyType;
            textBoxColour.Text = dCar.Colour;
            comboBoxEngine.Text = dCar.Engine;
            textBoxModel.Text = dCar.Model;
            comboBoxDriveUnit.Text = dCar.DriveUnit;
            comboBoxTransmission.Text = dCar.Transmission;
            textBoxDescription.Text = dCar.Description;
            textBoxPhone.Text = dCar.PhoneNumber;
            textBoxPlace.Text = dCar.PlaceOfSale;           
        }
        private void ButtonEditAd_Click(object sender, EventArgs e)
        {

            D.Title = comboBoxMark.Text;
            D.Price = PriceText.Text;
            D.Year = textBoxYear.Text;
            D.Mileage = textBoxMil.Text;
            D.BodyType = comboBoxTypeBody.Text;
            D.Colour = textBoxColour.Text;
            D.Engine = comboBoxEngine.Text;
            D.Model = textBoxModel.Text;
            D.DriveUnit = comboBoxDriveUnit.Text;
            D.Transmission = comboBoxTransmission.Text;
            D.Description = textBoxDescription.Text;
            D.PhoneNumber = textBoxPhone.Text;
            D.PlaceOfSale = textBoxPlace.Text;

            using (MyDbContext context = new MyDbContext())
            {
                if (D != null)
                {
                    context.Entry(D).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }

            if (flagPhoto)
            {
                using (var context = new MyDbContext())
                {
                    var F = context.Files.ToList();
                    bool flagFind = false;
                    // Ищем картинку для этого объявления и заменяем её
                    foreach (FileData F1 in F)
                    {
                        if (F1.userI == D.Id)
                        {
                            F1.Image = imageB;
                            context.Entry(F1).State = EntityState.Modified;
                            flagFind = true;
                        }
                    }
                    // Если фото для этого авто ещё не было, то необходимо создать новое поле в таблице
                    if(!flagFind)
                    {
                        // Сохраняем Id объявления для этой картинки
                        files.userI = D.Id;
                        files.Image = imageB;
                        context.Files.Add(files);
                    }
                    context.SaveChanges();
                }
            }
        }

        private void FormEditMyAd_Load(object sender, EventArgs e)
        {

        }

        private void buttonPhoto_Click(object sender, EventArgs e)
        {
            // Передавать id пользователя
            using (var context = new MyDbContext())
            {
                // Передавать id пользователя


                OpenFileDialog dialog = new OpenFileDialog();

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    Image image = Image.FromFile(dialog.FileName);
                    System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
                    image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                    imageB = memoryStream.ToArray();
                
                    pictureBox1.Image = image;
                  
                    var F = context.Files.ToList();
                    flagPhoto = true;
                }
            }
        }
    }
}
