using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace shopManagementsytem2
{
    public class MenuDb : DbContext
    {
        public DbSet<Menu> Menus { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Shopkeeper> Shopkeepers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=C:\Users\User\OneDrive\Desktop\CLONED\GUI\Database\database.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>()
                .HasKey(m => new { m.ShopName, m.ProductId });

            modelBuilder.Entity<Order>()
                .HasKey(o => o.Id);
        }
    }

    public class Order
    {
        public int Id { get; set; }
        public string ShopName { get; set; }
        public string MenuName { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
