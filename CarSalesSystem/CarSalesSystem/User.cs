using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesSystem
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        // Список избранных объявлений
        public string FavCars { get; set; }

        // Для различия пользователя и админа
        public string Type { get; set; }
        public virtual UserProfile Profile { get; set; }
        // Для каждого пользоваеля будет храниться вся коллекция его объявлений
        public virtual ICollection<Car> Cars { get; set; }
        public User()
        {
            Cars = new List<Car>();
        }

    }
}
