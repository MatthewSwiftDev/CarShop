using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesSystem
{
    public class Car
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        // Название объявления
        public string Title { get; set; }//
        public string Model { get; set; }//
        public string Price { get; set; }//
        public string Year { get; set; }//
        // Пробег
        public string Mileage { get; set; }//
        public string BodyType { get; set; }//
        public string Colour { get; set; }//
        public string Engine { get; set; }//
        // Тип привода
        public string DriveUnit { get; set; }//
        public string Transmission { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string PlaceOfSale { get; set; }
        // Массив байт для хранения изображения
        public byte[] Image { get; set; }
        
        public virtual User User { get; set; }

        public virtual ICollection<FileData> File { get; set; }
        public Car()
        {
            File = new List<FileData>();
        }
    }
}
