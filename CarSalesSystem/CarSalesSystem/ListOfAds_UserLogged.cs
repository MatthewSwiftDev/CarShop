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
    public partial class ListOfAds_UserLogged : Form
    {
        // Передаём данные авторизованного пользователя в форму для создания объявления
        User CurrentUser;

        // Счётчик для контроля порядка объявлений
        int k = 0;

        // Массив байт для хранения изображения
        byte[] imageB;
        public ListOfAds_UserLogged(User NeededUser)
        {
            CurrentUser = NeededUser;
            InitializeComponent();

            // Изначально все формы невидимы, если хоть одно поле в форме заполняем, то она становится видимой
            using (var context = new MyDbContext())
            {
                Label[] L = { labelModel, labelModel1, labelModel2, labelModel3, labelModel4 };
                Label[] Col = { labelColour, labelColour1, labelColour2, labelColour3, labelColour4 };
                Label[] Trans = { labelTransmission, labelTransmission1, labelTransmission2, labelTransmission3, labelTransmission4 };
                Label[] Eng = { labelEngine, labelEngine1, labelEngine2, labelEngine3, labelEngine4 };
                Label[] DrUnit = { LabelDriveUnit, LabelDriveUnit1, LabelDriveUnit2, LabelDriveUnit3, LabelDriveUnit4 };
                Label[] Mil = { labelMileage, labelMileage1, labelMileage2, labelMileage3, labelMileage4 };
                Label[] bType = { labelBodyType, labelBodyType1, labelBodyType2, labelBodyType3, labelBodyType4 };
                Label[] P = { labelPrice, labelPrice1, labelPrice2, labelPrice3, labelPrice4 };
                Label[] Y = { labelYear, labelYear1, labelYear2, labelYear3, labelYear4 };
                Label[] NumPhone = { labeNumberPhone, labeNumberPhone1, labeNumberPhone2, labeNumberPhone3, labeNumberPhone4 };
                Label[] Name = { labelNameUser, labelNameUser1, labelNameUser2, labelNameUser3, labelNameUser4 };
                TextBox[] textBoxeDescription = { tBDesc, tBDesc1, tBDesc2, tBDesc3, tBDesc4 };
                Panel[] Pan = { panelAd, panelAd1, panelAd2, panelAd3, panelAd4 };
                PictureBox[] PB = { pictureBoxCar, pictureBoxCar1, pictureBoxCar2, pictureBoxCar3, pictureBoxCar4 };

                // Изначально, все панели невидимые
                for (int i = 0; i < 5; i++)
                    Pan[i].Visible = false;

                var CurrentCar = context.Cars.ToList();
                int tempK = k;
                foreach (Car CarAd in CurrentCar)
                {
                    if (k < tempK + 5)
                    {
                        //Показываем изображение
                        PB[k % 5].BorderStyle = BorderStyle.FixedSingle;
                        PB[k % 5].SizeMode = PictureBoxSizeMode.StretchImage;
                        PB[k % 5].Visible = false;

                        var F = context.Files.ToList();
                        foreach (FileData F1 in F)
                        {
                            if (F1.userI == CarAd.Id)
                            {
                                imageB = F1.Image; // Выводим фото для текущего элменета
                                System.IO.MemoryStream memoryStream1 = new System.IO.MemoryStream();
                                foreach (byte b1 in imageB) memoryStream1.WriteByte(b1);
                                Image image = Image.FromStream(memoryStream1);
                                PB[k % 5].Image = image;
                                PB[k % 5].Visible = true;
                                break;
                            }
                        }
                        Pan[k % 5].Visible = true;

                        L[k % 5].Text = CarAd.Title + " " + CarAd.Model;
                        Col[k % 5].Text = CarAd.Colour;
                        Trans[k % 5].Text = CarAd.Transmission;
                        Eng[k % 5].Text = CarAd.Engine;
                        DrUnit[k % 5].Text = CarAd.DriveUnit;
                        Mil[k % 5].Text = CarAd.Mileage + "км";
                        bType[k % 5].Text = CarAd.BodyType;
                        P[k % 5].Text = CarAd.Price + "руб";
                        Y[k % 5].Text = CarAd.Year + "год";
                        NumPhone[k % 5].Text = CarAd.PhoneNumber;

                        var CurrentSeller = context.UserProfiles.ToList();
                        int tempS = 0;
                        foreach (UserProfile CurS in CurrentSeller)
                        {
                            tempS++;
                            if (tempS == CarAd.UserId)
                                Name[k % 5].Text = CurS.UserName;
                        }
                        textBoxeDescription[k % 5].Text = CarAd.Description;
                        textBoxeDescription[k % 5].ReadOnly = true;
                    }
                    else
                        break;
                    k++;
                }

                if (k < CurrentCar.Count)
                    buttonNext.Visible = true;
                else
                    buttonNext.Visible = false;

                if (k > 5)
                    buttonBack.Visible = true;
                else
                    buttonBack.Visible = false;
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            // Изначально все формы невидимы, если хоть одно поле в форме заполняем, то она становится видимой
            using (var context = new MyDbContext())
            {
                Label[] L = { labelModel, labelModel1, labelModel2, labelModel3, labelModel4 };
                Label[] Col = { labelColour, labelColour1, labelColour2, labelColour3, labelColour4 };
                Label[] Trans = { labelTransmission, labelTransmission1, labelTransmission2, labelTransmission3, labelTransmission4 };
                Label[] Eng = { labelEngine, labelEngine1, labelEngine2, labelEngine3, labelEngine4 };
                Label[] DrUnit = { LabelDriveUnit, LabelDriveUnit1, LabelDriveUnit2, LabelDriveUnit3, LabelDriveUnit4 };
                Label[] Mil = { labelMileage, labelMileage1, labelMileage2, labelMileage3, labelMileage4 };
                Label[] bType = { labelBodyType, labelBodyType1, labelBodyType2, labelBodyType3, labelBodyType4 };
                Label[] P = { labelPrice, labelPrice1, labelPrice2, labelPrice3, labelPrice4 };
                Label[] Y = { labelYear, labelYear1, labelYear2, labelYear3, labelYear4 };
                Label[] NumPhone = { labeNumberPhone, labeNumberPhone1, labeNumberPhone2, labeNumberPhone3, labeNumberPhone4 };
                Label[] Name = { labelNameUser, labelNameUser1, labelNameUser2, labelNameUser3, labelNameUser4 };
                TextBox[] textBoxeDescription = { tBDesc, tBDesc1, tBDesc2, tBDesc3, tBDesc4 };
                Panel[] Pan = { panelAd, panelAd1, panelAd2, panelAd3, panelAd4 };
                PictureBox[] PB = { pictureBoxCar, pictureBoxCar1, pictureBoxCar2, pictureBoxCar3, pictureBoxCar4 };

                // Изначально, все панели невидимые
                for (int i = 0; i < 5; i++)
                    Pan[i].Visible = false;

                var CurrentCar = context.Cars.ToList();
                int StartK = 0;
                int tempK = k;
                foreach (Car CarAd in CurrentCar)
                {
                    if (StartK >= k)
                    {
                        if (k < tempK + 5)
                        {
                            //Показываем изображение
                            PB[k % 5].BorderStyle = BorderStyle.FixedSingle;
                            PB[k % 5].SizeMode = PictureBoxSizeMode.StretchImage;
                            PB[k % 5].Visible = false;

                            var F = context.Files.ToList();
                            foreach (FileData F1 in F)
                            {
                                if (F1.userI == CarAd.Id)
                                {
                                    imageB = F1.Image; // Выводим фото для текущего элменета
                                    System.IO.MemoryStream memoryStream1 = new System.IO.MemoryStream();
                                    foreach (byte b1 in imageB) memoryStream1.WriteByte(b1);
                                    Image image = Image.FromStream(memoryStream1);
                                    PB[k % 5].Image = image;
                                    PB[k % 5].Visible = true;
                                    break;
                                }
                            }
                            Pan[k % 5].Visible = true;

                            L[k % 5].Text = CarAd.Title + " " + CarAd.Model;
                            Col[k % 5].Text = CarAd.Colour;
                            Trans[k % 5].Text = CarAd.Transmission;
                            Eng[k % 5].Text = CarAd.Engine;
                            DrUnit[k % 5].Text = CarAd.DriveUnit;
                            Mil[k % 5].Text = CarAd.Mileage + "км";
                            bType[k % 5].Text = CarAd.BodyType;
                            P[k % 5].Text = CarAd.Price + "руб";
                            Y[k % 5].Text = CarAd.Year + "год";
                            NumPhone[k % 5].Text = CarAd.PhoneNumber;

                            var CurrentSeller = context.UserProfiles.ToList();
                            int tempS = 0;
                            foreach (UserProfile CurS in CurrentSeller)
                            {
                                tempS++;
                                if (tempS == CarAd.UserId)
                                    Name[k % 5].Text = CurS.UserName;
                            }

                            textBoxeDescription[k % 5].Text = CarAd.Description;
                            textBoxeDescription[k % 5].ReadOnly = true;


                        }
                        else
                            break;
                        k++;
                    }
                    StartK++;
                }

                if (k < CurrentCar.Count)
                    buttonNext.Visible = true;
                else
                    buttonNext.Visible = false;

                if (k > 5)
                    buttonBack.Visible = true;
                else
                    buttonBack.Visible = false;
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            // Изначально все формы невидимы, если хоть одно поле в форме заполняем, то она становится видимой
            using (var context = new MyDbContext())
            {
                Label[] L = { labelModel, labelModel1, labelModel2, labelModel3, labelModel4 };
                Label[] Col = { labelColour, labelColour1, labelColour2, labelColour3, labelColour4 };
                Label[] Trans = { labelTransmission, labelTransmission1, labelTransmission2, labelTransmission3, labelTransmission4 };
                Label[] Eng = { labelEngine, labelEngine1, labelEngine2, labelEngine3, labelEngine4 };
                Label[] DrUnit = { LabelDriveUnit, LabelDriveUnit1, LabelDriveUnit2, LabelDriveUnit3, LabelDriveUnit4 };
                Label[] Mil = { labelMileage, labelMileage1, labelMileage2, labelMileage3, labelMileage4 };
                Label[] bType = { labelBodyType, labelBodyType1, labelBodyType2, labelBodyType3, labelBodyType4 };
                Label[] P = { labelPrice, labelPrice1, labelPrice2, labelPrice3, labelPrice4 };
                Label[] Y = { labelYear, labelYear1, labelYear2, labelYear3, labelYear4 };
                Label[] NumPhone = { labeNumberPhone, labeNumberPhone1, labeNumberPhone2, labeNumberPhone3, labeNumberPhone4 };
                Label[] Name = { labelNameUser, labelNameUser1, labelNameUser2, labelNameUser3, labelNameUser4 };
                TextBox[] textBoxeDescription = { tBDesc, tBDesc1, tBDesc2, tBDesc3, tBDesc4 };
                Panel[] Pan = { panelAd, panelAd1, panelAd2, panelAd3, panelAd4 };
                PictureBox[] PB = { pictureBoxCar, pictureBoxCar1, pictureBoxCar2, pictureBoxCar3, pictureBoxCar4 };

                // Изначально, все панели невидимые
                for (int i = 0; i < 5; i++)
                    Pan[i].Visible = false;

                var CurrentCar = context.Cars.ToList();
                int StartK = 0;

                int TempAddK = 0;
                if (k % 5 != 0)
                    TempAddK = k % 5;
                else
                    if (k > 5)
                    TempAddK = 5;

                k = k - 5 - TempAddK;
                int tempK = k;
                foreach (Car CarAd in CurrentCar)
                {
                    if (StartK >= k)
                    {
                        if (k < tempK + 5)
                        {
                            //Показываем изображение
                            PB[k % 5].BorderStyle = BorderStyle.FixedSingle;
                            PB[k % 5].SizeMode = PictureBoxSizeMode.StretchImage;
                            PB[k % 5].Visible = false;

                            var F = context.Files.ToList();
                            foreach (FileData F1 in F)
                            {
                                if (F1.userI == CarAd.Id)
                                {
                                    imageB = F1.Image; // Выводим фото для текущего элменета
                                    System.IO.MemoryStream memoryStream1 = new System.IO.MemoryStream();
                                    foreach (byte b1 in imageB) memoryStream1.WriteByte(b1);
                                    Image image = Image.FromStream(memoryStream1);
                                    PB[k % 5].Image = image;
                                    PB[k % 5].Visible = true;
                                    break;
                                }
                            }
                            Pan[k % 5].Visible = true;

                            L[k % 5].Text = CarAd.Title + " " + CarAd.Model;
                            Col[k % 5].Text = CarAd.Colour;
                            Trans[k % 5].Text = CarAd.Transmission;
                            Eng[k % 5].Text = CarAd.Engine;
                            DrUnit[k % 5].Text = CarAd.DriveUnit;
                            Mil[k % 5].Text = CarAd.Mileage + "км";
                            bType[k % 5].Text = CarAd.BodyType;
                            P[k % 5].Text = CarAd.Price + "руб";
                            Y[k % 5].Text = CarAd.Year + "год";
                            NumPhone[k % 5].Text = CarAd.PhoneNumber;

                            var CurrentSeller = context.UserProfiles.ToList();
                            int tempS = 0;
                            foreach (UserProfile CurS in CurrentSeller)
                            {
                                tempS++;
                                if (tempS == CarAd.UserId)
                                    Name[k % 5].Text = CurS.UserName;
                            }

                            textBoxeDescription[k % 5].Text = CarAd.Description;
                            textBoxeDescription[k % 5].ReadOnly = true;

                        }
                        else
                            break;
                        k++;
                    }
                    StartK++;
                }

                if (k < CurrentCar.Count)
                    buttonNext.Visible = true;
                else
                    buttonNext.Visible = false;

                if (k > 5)
                    buttonBack.Visible = true;
                else
                    buttonBack.Visible = false;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        // Добавление в избранное
       
        private void checkBoxFav_CheckedChanged_1(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                int _K = k % 5;
                if (_K == 0)
                    _K = 5;

                int tK = k - _K + 1;
                //Если объявление выбрано добавляем его
                if (checkBoxFav.Checked == true)
                {                   
                    CurrentUser.FavCars += Convert.ToString(tK) + " ";
                }
                else
                {
                    // Иначе удаляем его из списка
                    int n = CurrentUser.FavCars.IndexOf(Convert.ToString(tK) + " ");
                    CurrentUser.FavCars = CurrentUser.FavCars.Remove(n, Convert.ToString(tK).Length + 1);

                }

                context.Entry(CurrentUser).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        private void checkBoxFav1_CheckedChanged(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                int _K = k % 5;
                if (_K == 0)
                    _K = 5;

                int tK = k - _K + 2;
                //Если объявление выбрано добавляем его
                if (checkBoxFav.Checked == true)
                {
                    CurrentUser.FavCars += Convert.ToString(tK) + " ";
                }
                else
                {
                    // Иначе удаляем его из списка
                    int n = CurrentUser.FavCars.IndexOf(Convert.ToString(tK) + " ");
                    CurrentUser.FavCars = CurrentUser.FavCars.Remove(n, Convert.ToString(tK).Length + 1);

                }

                context.Entry(CurrentUser).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        private void checkBoxFav2_CheckedChanged(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                int _K = k % 5;
                if (_K == 0)
                    _K = 5;

                int tK = k - _K + 3;
                //Если объявление выбрано добавляем его
                if (checkBoxFav.Checked == true)
                {
                    CurrentUser.FavCars += Convert.ToString(tK) + " ";
                }
                else
                {
                    // Иначе удаляем его из списка
                    int n = CurrentUser.FavCars.IndexOf(Convert.ToString(tK) + " ");
                    CurrentUser.FavCars = CurrentUser.FavCars.Remove(n, Convert.ToString(tK).Length + 1);

                }

                context.Entry(CurrentUser).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        private void checkBoxFav3_CheckedChanged(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                int _K = k % 5;
                if (_K == 0)
                    _K = 5;

                int tK = k - _K + 4;
                //Если объявление выбрано добавляем его
                if (checkBoxFav.Checked == true)
                {
                    CurrentUser.FavCars += Convert.ToString(tK) + " ";
                }
                else
                {
                    // Иначе удаляем его из списка
                    int n = CurrentUser.FavCars.IndexOf(Convert.ToString(tK) + " ");
                    CurrentUser.FavCars = CurrentUser.FavCars.Remove(n, Convert.ToString(tK).Length + 1);

                }

                context.Entry(CurrentUser).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        private void checkBoxFav4_CheckedChanged(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                int _K = k % 5;
                if (_K == 0)
                    _K = 5;

                int tK = k - _K + 5;
                //Если объявление выбрано добавляем его
                if (checkBoxFav.Checked == true)
                {
                    CurrentUser.FavCars += Convert.ToString(tK) + " ";
                }
                else
                {
                    // Иначе удаляем его из списка
                    int n = CurrentUser.FavCars.IndexOf(Convert.ToString(tK) + " ");
                    CurrentUser.FavCars = CurrentUser.FavCars.Remove(n, Convert.ToString(tK).Length + 1);

                }

                context.Entry(CurrentUser).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
