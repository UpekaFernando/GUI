using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class AddMenu : Window
    {
        public ObservableCollection<Menu> Menus { get; set; }
        private Menu? selectedMenu;
        private string shopName;

        public AddMenu(string shopName)
        {
            InitializeComponent();
            Menus = new ObservableCollection<Menu>();
            DataContext = this;
            this.shopName = shopName;
            ShopNameTextBlock.Text = shopName;

            // Load existing menus from the database
            LoadMenusFromDatabase();
        }

        private void LoadMenusFromDatabase()
        {
            using (var context = new MenuDb())
            {
                var menus = context.Menus.Where(m => m.ShopName == shopName).ToList();
                foreach (var menu in menus)
                {
                    Menus.Add(menu);
                }
            }
        }

        private void AddMenuButton_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(PriceTextBox.Text, out decimal price) &&
                int.TryParse(QuantityTextBox.Text, out int quantity))
            {
                if (selectedMenu != null)
                {
                    // Update existing menu item
                    selectedMenu.Name = NameTextBox.Text;
                    selectedMenu.Price = price;
                    selectedMenu.Quantity = quantity;
                    selectedMenu.ShopName = shopName;

                    using (var context = new MenuDb())
                    {
                        context.Menus.Update(selectedMenu);
                        context.SaveChanges();
                    }

                    selectedMenu = null;
                }
                else
                {
                    // Generate new Product ID within the shop
                    int newProductId = Menus.Any() ? Menus.Max(m => m.ProductId) + 1 : 1;

                    // Add new menu item
                    var newMenu = new Menu
                    {
                        ProductId = newProductId,
                        Name = NameTextBox.Text,
                        Price = price,
                        Quantity = quantity,
                        ShopName = shopName
                    };

                    Menus.Add(newMenu);

                    using (var context = new MenuDb())
                    {
                        context.Menus.Add(newMenu);
                        context.SaveChanges();
                    }
                }

                // Clear input fields
                NameTextBox.Clear();
                PriceTextBox.Clear();
                QuantityTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Please enter valid values for Price and Quantity.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateMenuButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Menu menu)
            {
                // Populate input fields with selected menu item
                NameTextBox.Text = menu.Name;
                PriceTextBox.Text = menu.Price.ToString();
                QuantityTextBox.Text = menu.Quantity.ToString();
                selectedMenu = menu;
            }
        }

        private void DeleteMenuButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Menu menu)
            {
                Menus.Remove(menu);

                using (var context = new MenuDb())
                {
                    context.Menus.Remove(menu);
                    context.SaveChanges();
                }
            }
        }
    }
}
