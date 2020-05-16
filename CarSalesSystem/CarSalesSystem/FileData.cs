using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesSystem
{
    public class FileData
    {
        public int id { get; set; }
        public int userI { get; set; }
        public byte[] Image { get; set; }
        public virtual Car Car { get; set; }

    }
}
