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
            try
            {
                // First attempt to use MySQL
                optionsBuilder.UseMySql(
                "server=localhost;database=shop_management_db;user=root;password=root",
                    new MySqlServerVersion(new Version(8, 0, 36))
                );
                System.Diagnostics.Debug.WriteLine("Using MySQL database connection");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"MySQL connection failed: {ex.Message}");
                
                // Fallback to SQLite if MySQL connection fails
                try 
                {
                    string dbPath = System.IO.Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "shopmanagement.db");
                    
                    System.Diagnostics.Debug.WriteLine($"Using SQLite database at: {dbPath}");
                    optionsBuilder.UseSqlite($"Data Source={dbPath}");
                }
                catch (Exception sqliteEx)
                {
                    System.Diagnostics.Debug.WriteLine($"SQLite fallback failed: {sqliteEx.Message}");
                    throw new Exception("Could not connect to any database", sqliteEx);
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the entity relationships
            modelBuilder.Entity<Menu>()
                .HasKey(m => new { m.ShopName, m.ProductId });

            modelBuilder.Entity<Order>()
                .HasKey(o => o.Id);
            
            // Add seed data for testing - this will only be used if the database is empty
            SeedData(modelBuilder);
        }
        
        private void SeedData(ModelBuilder modelBuilder)
        {
            // Add seed data for testing
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Test User", Email = "user@test.com", Password = "password" }
            );
            
            modelBuilder.Entity<Shopkeeper>().HasData(
                new Shopkeeper { Id = 1, ShopName = "Test Shop", Email = "shop@test.com", Password = "password" }
            );
            
            modelBuilder.Entity<Menu>().HasData(
                new Menu { ProductId = 1, Name = "Burger", Price = 5.99M, Quantity = 10, ShopName = "Test Shop" },
                new Menu { ProductId = 2, Name = "Pizza", Price = 8.99M, Quantity = 8, ShopName = "Test Shop" }
            );
        }
        
        // Ensure database is created and has required seed data
        public static void Initialize()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("Initializing database...");
                
                using (var context = new MenuDb())
                {
                    // This will create the database if it doesn't exist
                    bool created = context.Database.EnsureCreated();
                    if (created)
                    {
                        System.Diagnostics.Debug.WriteLine("Database was created");
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("Database already existed");
                    }
                    
                    // If there are no users, add the seed data
                    if (!context.Users.Any())
                    {
                        System.Diagnostics.Debug.WriteLine("Adding seed data");
                        context.Users.Add(new User { Name = "Test User", Email = "user@test.com", Password = "password" });
                        context.Shopkeepers.Add(new Shopkeeper { ShopName = "Test Shop", Email = "shop@test.com", Password = "password" });
                        context.Menus.Add(new Menu { ProductId = 1, Name = "Burger", Price = 5.99M, Quantity = 10, ShopName = "Test Shop" });
                        context.Menus.Add(new Menu { ProductId = 2, Name = "Pizza", Price = 8.99M, Quantity = 8, ShopName = "Test Shop" });
                        context.SaveChanges();
                        System.Diagnostics.Debug.WriteLine("Seed data added successfully");
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("Database already contains data");
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the error or display a message
                System.Diagnostics.Debug.WriteLine($"Database initialization error: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Stack trace: {ex.StackTrace}");
                
                // No need to throw here - we'll just continue with potentially no database
            }
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
