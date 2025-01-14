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
        public ObservableCollection<Shopkeeper> Shopkeepers { get; set; }
        private Menu? selectedMenu;

        public AddMenu()
        {
            InitializeComponent();
            Menus = new ObservableCollection<Menu>();
            Shopkeepers = new ObservableCollection<Shopkeeper>();
            DataContext = this;

            // Load existing menus and shops from the database
            LoadMenusFromDatabase();
            LoadShopsFromDatabase();
        }

        private void LoadMenusFromDatabase()
        {
            using (var context = new MenuDb())
            {
                var menus = context.Menus.ToList();
                foreach (var menu in menus)
                {
                    Menus.Add(menu);
                }
            }
        }

        private void LoadShopsFromDatabase()
        {
            using (var context = new MenuDb())
            {
                var shops = context.Shopkeepers.ToList();
                foreach (var shop in shops)
                {
                    Shopkeepers.Add(shop);
                }
                ShopNameComboBox.ItemsSource = Shopkeepers;
            }
        }

        private void AddMenuButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(ProductIdTextBox.Text, out int productId) &&
                decimal.TryParse(PriceTextBox.Text, out decimal price) &&
                int.TryParse(QuantityTextBox.Text, out int quantity) &&
                ShopNameComboBox.SelectedItem is Shopkeeper selectedShop)
            {
                if (selectedMenu != null)
                {
                    // Update existing menu item
                    selectedMenu.ProductId = productId;
                    selectedMenu.Name = NameTextBox.Text;
                    selectedMenu.Price = price;
                    selectedMenu.Quantity = quantity;
                    selectedMenu.ShopName = selectedShop.ShopName;

                    using (var context = new MenuDb())
                    {
                        context.Menus.Update(selectedMenu);
                        context.SaveChanges();
                    }

                    selectedMenu = null;
                }
                else
                {
                    // Add new menu item
                    var newMenu = new Menu
                    {
                        ProductId = productId,
                        Name = NameTextBox.Text,
                        Price = price,
                        Quantity = quantity,
                        ShopName = selectedShop.ShopName
                    };

                    Menus.Add(newMenu);

                    using (var context = new MenuDb())
                    {
                        context.Menus.Add(newMenu);
                        context.SaveChanges();
                    }
                }

                // Clear input fields
                ProductIdTextBox.Clear();
                NameTextBox.Clear();
                PriceTextBox.Clear();
                QuantityTextBox.Clear();
                ShopNameComboBox.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Please enter valid values for Product ID, Price, Quantity, and select a Shop.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateMenuButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Menu menu)
            {
                // Populate input fields with selected menu item
                ProductIdTextBox.Text = menu.ProductId.ToString();
                NameTextBox.Text = menu.Name;
                PriceTextBox.Text = menu.Price.ToString();
                QuantityTextBox.Text = menu.Quantity.ToString();
                ShopNameComboBox.SelectedValue = menu.ShopName;
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
