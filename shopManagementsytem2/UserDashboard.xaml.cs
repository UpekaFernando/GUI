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
    /// Interaction logic for UserDashboard.xaml
    /// </summary>

    public partial class UserDashboard : Window
    {
        public UserDashboard()
        {
            InitializeComponent();
            LoadNearbyShops();
            LoadAllShops();
            LoadOrderHistory();
        }

        private void LoadNearbyShops()
        {
            using (var context = new MenuDb())
            {
                var shops = context.Shopkeepers.Select(s => s.ShopName).Distinct().ToList();
                listBoxNearbyShops.ItemsSource = shops;
            }
        }

        private void LoadAllShops()
        {
            using (var context = new MenuDb())
            {
                var shops = context.Shopkeepers.Select(s => s.ShopName).Distinct().ToList();
                listBoxAllShops.ItemsSource = shops;
            }
        }

        private void LoadOrderHistory()
        {
            using (var context = new MenuDb())
            {
                var orders = context.Orders.ToList();
                listBoxOrderHistory.ItemsSource = orders.Select(o => $"{o.OrderDate}: {o.MenuName} from {o.ShopName}").ToList();
            }
        }

        private void ListBoxNearbyShops_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBoxNearbyShops.SelectedItem != null)
            {
                string selectedShop = listBoxNearbyShops.SelectedItem.ToString();
                ViewMenu viewMenuWindow = new ViewMenu(selectedShop);
                viewMenuWindow.Show();
            }
        }

        private void ListBoxAllShops_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBoxAllShops.SelectedItem != null)
            {
                string selectedShop = listBoxAllShops.SelectedItem.ToString();
                ViewMenu viewMenuWindow = new ViewMenu(selectedShop);
                viewMenuWindow.Show();
            }
        }

        private void ClearOrderHistory_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new MenuDb())
            {
                context.Orders.RemoveRange(context.Orders);
                context.SaveChanges();
            }
            listBoxOrderHistory.Items.Clear();
        }

        private void TopUpButton_Click(object sender, RoutedEventArgs e)
        {
            // Handle top-up balance button click
            MessageBox.Show("Top-up balance functionality to be implemented.");
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text == "Search for a shop or product...")
            {
                textBox.Text = "";
                textBox.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Search for a shop or product...";
                textBox.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
    }
}
