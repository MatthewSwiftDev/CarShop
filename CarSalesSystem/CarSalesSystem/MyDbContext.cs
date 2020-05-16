using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesSystem
{
    public class MyDbContext : DbContext
    {
        // В конструктор передаём строку подключния к БД
        public MyDbContext() : base("DbConnectionString")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<FileData> Files { get; set; }
    }
}
