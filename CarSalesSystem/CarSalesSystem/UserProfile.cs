using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesSystem
{
    public class UserProfile
    {
        [Key]   // Показывает, что это первичный ключ
        [ForeignKey("User")] // A также и внешний ключ

        public int Id { get; set; } 
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }

        public User User { get; set; }
    }
}
