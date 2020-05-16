using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesSystem
{
    public class Sale
    {
        public int id { get; set; }       
        public int IDuser { get; set; } // Id продавца
        public int IDcar { get; set; }  // Id объявления
        public String Date { get; set; }// Дата продажи
    }
}
