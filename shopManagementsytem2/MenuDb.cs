using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;

namespace shopManagementsytem2
{
    public class MenuDb :DbContext
    {
        public DbSet<Menu> Menus { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Shopkeeper> Shopkeepers { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=D:\GUI\GUI\Database\database.db");
            //give the address to make database, and open package manager console " Add-Migration initial"
            //"Update-Database" and it make the db file to that given address , and it generates initials.cs file
            //base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>()
                .HasKey(m => m.ProductId);
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
