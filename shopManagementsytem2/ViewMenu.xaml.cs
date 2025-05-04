using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace shopManagementsytem2
{
    /// <summary>
    /// Interaction logic for ViewMenu.xaml
    /// </summary>
    public partial class ViewMenu : Window
    {
        private string selectedShop;

        public ViewMenu(string shop)
        {
            InitializeComponent();
            selectedShop = shop;
            LoadMenus();
        }

        private void LoadMenus()
        {
            using (var context = new MenuDb())
            {
                var menus = context.Menus.Where(m => m.ShopName == selectedShop).ToList();
                listBoxMenus.ItemsSource = menus.Select(m => $"{m.Name} - Rs {m.Price}").ToList();
            }
        }

        private void btnChooseMenu_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxMenus.SelectedItem != null)
            {
                string selectedMenu = listBoxMenus.SelectedItem.ToString();
                SaveOrder(selectedShop, selectedMenu);
                MessageBox.Show($"Order placed for {selectedMenu} from {selectedShop}");
            }
        }

        private void SaveOrder(string shop, string menu)
        {
            using (var context = new MenuDb())
            {
                var order = new Order
                {
                    ShopName = shop,
                    MenuName = menu,
                    OrderDate = DateTime.Now
                };
                context.Orders.Add(order);
                context.SaveChanges();
            }
        }
    }
}
