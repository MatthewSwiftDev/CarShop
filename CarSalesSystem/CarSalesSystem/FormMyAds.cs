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
    public partial class FormMyAds : Form
    {
        // Счётчик для контроля порядка объявлений
        int k = 0;
        User CurrentUser;
        byte[] imageB;
        int UserCars = 0;
        // Список машин, привязанный к форме
        public Car D, D1, D2, D3, D4;


        public FormMyAds(User NeededUser)
        {
            Car[] DCars = { D, D1, D2, D3, D4 };
            
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

                UserCars = 0;
                // Считаем кол-во автомобилей у данного пользователя
                foreach (Car CarAd in CurrentCar)
                {
                    // Выбираем объявления только текущего пользователя
                    if (CurrentUser.Id == CarAd.UserId)                   
                        UserCars++;                   
                }

                int tempK = k;
                foreach (Car CarAd in CurrentCar)
                {
                    // Выбираем объявления только текущего пользователя
                    if (CurrentUser.Id == CarAd.UserId)
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

                            DCars[k % 5] = CarAd;
                        }
                        else
                            break;
                        k++;
                    }
                }

                // Постоянно храним где какое объявления
                D = DCars[0];
                D1 = DCars[1];
                D2 = DCars[2];
                D3 = DCars[3];
                D4 = DCars[4];

                if (k < UserCars)
                    buttonNext.Visible = true;
                else
                    buttonNext.Visible = false;

                if (k > 5)
                    buttonBack.Visible = true;
                else
                    buttonBack.Visible = false;
            }
        }


        // Если есть ещё объявления, то кнопка становится видимой        
        private void buttonNext_Click(object sender, EventArgs e)
        {
            Car[] DCars = { D, D1, D2, D3, D4 };
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
                    if (CurrentUser.Id == CarAd.UserId)
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

                                DCars[k % 5] = CarAd;

                            }
                            else
                                break;
                            k++;
                        }
                        StartK++;
                    }
                }

                // Постоянно храним где какое объявления
                D = DCars[0];
                D1 = DCars[1];
                D2 = DCars[2];
                D3 = DCars[3];
                D4 = DCars[4];

                if (k < UserCars)
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
            Car[] DCars = { D, D1, D2, D3, D4 };
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
                    if (CurrentUser.Id == CarAd.UserId)
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

                                DCars[k % 5] = CarAd;
                            }
                            else
                                break;
                            k++;
                        }
                        StartK++;
                    }
                }

                // Постоянно храним где какое объявления
                D = DCars[0];
                D1 = DCars[1];
                D2 = DCars[2];
                D3 = DCars[3];
                D4 = DCars[4];

                if (k < UserCars)
                    buttonNext.Visible = true;
                else
                    buttonNext.Visible = false;

                if (k > 5)
                    buttonBack.Visible = true;
                else
                    buttonBack.Visible = false;
            }
        }

        private void buttonDeleteAd_Click(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                if (D != null)
                {
                    context.Entry(D).State = EntityState.Deleted;
                    context.SaveChanges();
                    D = null;
                }
            }
        }

        private void buttonDeleteAd1_Click(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                if (D1 != null)
                {
                    context.Entry(D1).State = EntityState.Deleted;
                    context.SaveChanges();
                    D1 = null;
                }
            }
        }

        private void buttonDeleteAd2_Click(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                if (D2 != null)
                {
                    context.Entry(D2).State = EntityState.Deleted;
                    context.SaveChanges();
                    D2 = null;
                }
            }
        }

        private void buttonDeleteAd3_Click(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                if (D3 != null)
                {
                    context.Entry(D3).State = EntityState.Deleted;
                    context.SaveChanges();
                    D3 = null;
                }
            }
        }

        private void buttonDeleteAd4_Click(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                if (D4 != null)
                {
                    context.Entry(D4).State = EntityState.Deleted;
                    context.SaveChanges();
                    D4 = null;
                }
            }
        }
        private void buttonSale_Click(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                if (D != null)
                {
                    Sale S = new Sale
                    {
                        IDuser = D.UserId,
                        IDcar = D.Id,
                        Date = Convert.ToString(DateTime.Now)
                    };

                    context.Sales.Add(S);
                    context.Entry(D).State = EntityState.Deleted;
                    context.SaveChanges();
                    D = null;
                }
            }
        }


        private void buttonSale1_Click(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                if (D1 != null)
                {
                    Sale S = new Sale
                    {
                        IDuser = D1.UserId,
                        IDcar = D1.Id,
                        Date = Convert.ToString(DateTime.Now)
                    };

                    context.Sales.Add(S);
                    context.Entry(D1).State = EntityState.Deleted;
                    context.SaveChanges();
                    D1 = null;
                }
            }
        }

        private void buttonSale2_Click(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                if (D2 != null)
                {
                    Sale S = new Sale
                    {
                        IDuser = D2.UserId,
                        IDcar = D2.Id,
                        Date = Convert.ToString(DateTime.Now)
                    };

                    context.Sales.Add(S);
                    context.Entry(D2).State = EntityState.Deleted;
                    context.SaveChanges();
                    D2 = null;
                }
            }
        }

        private void buttonSale3_Click(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                if (D3 != null)
                {
                    Sale S = new Sale
                    {
                        IDuser = D3.UserId,
                        IDcar = D3.Id,
                        Date = Convert.ToString(DateTime.Now)
                    };

                    context.Sales.Add(S);
                    context.Entry(D3).State = EntityState.Deleted;
                    context.SaveChanges();
                    D3 = null;
                }
            }
        }

        private void buttonSale4_Click(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                if (D4 != null)
                {
                    Sale S = new Sale
                    {
                        IDuser = D4.UserId,
                        IDcar = D4.Id,
                        Date = Convert.ToString(DateTime.Now)
                    };

                    context.Sales.Add(S);
                    context.Entry(D4).State = EntityState.Deleted;
                    context.SaveChanges();
                    D4 = null;
                }
            }
        }
        private void buttonEditAd_Click(object sender, EventArgs e)
        {
            
            FormEditMyAd fEdit = new FormEditMyAd(D);
            fEdit.Show();
        }

        private void buttonEditAd1_Click(object sender, EventArgs e)
        {
            FormEditMyAd fEdit = new FormEditMyAd(D1);
            fEdit.Show();
        }

        private void buttonEditAd2_Click(object sender, EventArgs e)
        {
            FormEditMyAd fEdit = new FormEditMyAd(D2);
            fEdit.Show();
        }

        private void buttonEditAd3_Click(object sender, EventArgs e)
        {
            FormEditMyAd fEdit = new FormEditMyAd(D3);
            fEdit.Show();
        }

        private void buttonEditAd4_Click(object sender, EventArgs e)
        {
            FormEditMyAd fEdit = new FormEditMyAd(D4);
            fEdit.Show();
        }
    }
}
