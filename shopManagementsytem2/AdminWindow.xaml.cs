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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            using (var context = new MenuDb())
            {
                UserListBox.ItemsSource = context.Users.ToList();
                ShopkeeperListBox.ItemsSource = context.Shopkeepers.ToList();
            }
        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (UserListBox.SelectedItem is User selectedUser)
            {
                using (var context = new MenuDb())
                {
                    context.Users.Remove(selectedUser);
                    context.SaveChanges();
                }
                LoadData();
            }
        }

        private void DeleteShopkeeperButton_Click(object sender, RoutedEventArgs e)
        {
            if (ShopkeeperListBox.SelectedItem is Shopkeeper selectedShopkeeper)
            {
                using (var context = new MenuDb())
                {
                    context.Shopkeepers.Remove(selectedShopkeeper);
                    context.SaveChanges();
                }
                LoadData();
            }
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
