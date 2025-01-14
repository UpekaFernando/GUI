using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopManagementsytem2
{
    public  class Menu
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ShopName { get; set; }

    }
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    }

    public class Shopkeeper
    {
        public int Id { get; set; }
        public string ShopName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
    }
}
