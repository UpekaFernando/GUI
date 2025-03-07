﻿using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace shopManagementsytem2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnUserLogin_Click(object sender, RoutedEventArgs e)
        {
            string email = txtUserEmail.Text;
            string password = txtUserPassword.Password;

            using (var context = new MenuDb())
            {
                var user = context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
                if (user != null)
                {
                    MessageBox.Show("User login successful!");
                    UserDashboard userDashboard = new UserDashboard();
                    userDashboard.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid email or password.");
                }
            }
        }

        private void btnShopLogin_Click(object sender, RoutedEventArgs e)
        {
            string shopName = txtShopName.Text;
            string emailOrPhone = txtShopEmail.Text;
            string password = txtShopPassword.Password;

            using (var context = new MenuDb())
            {
                var shopkeeper = context.Shopkeepers.FirstOrDefault(s => s.ShopName == shopName && s.Email == emailOrPhone && s.Password == password);
                if (shopkeeper != null)
                {
                    MessageBox.Show("Shopkeeper login successful!");
                    ShopkeeperDashboard shopkeeperDashboard = new ShopkeeperDashboard(shopName);
                    shopkeeperDashboard.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid shop name, email/phone, or password.");
                }
            }
        }

        private void btnAdminLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtAdminUsername.Text;
            string password = txtAdminPassword.Password;

            // Admin login logic here
            if (username == "admin" && password == "admin")
            {
                MessageBox.Show("Admin login successful!");
                AdminWindow adminWindow = new AdminWindow();
                adminWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string name = txtRegName.Text;
            string emailOrPhone = txtRegEmail.Text;
            string password = txtRegPassword.Password;
            string confirmPassword = txtRegConfirmPassword.Password;

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            using (var context = new MenuDb())
            {
                try
                {
                    var user = new User { Name = name, Email = emailOrPhone, Password = password };
                    context.Users.Add(user);
                    context.SaveChanges();
                    MessageBox.Show("User registration successful!");
                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show($"An error occurred while saving the entity changes: {ex.InnerException?.Message}");
                }
            }
        }

        private void btnShopRegister_Click(object sender, RoutedEventArgs e)
        {
            string shopName = txtShopRegName.Text;
            string emailOrPhone = txtShopRegEmail.Text;
            string password = txtShopRegPassword.Password;
            string confirmPassword = txtShopRegConfirmPassword.Password;

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            using (var context = new MenuDb())
            {
                try
                {
                    var shopkeeper = new Shopkeeper { ShopName = shopName, Email = emailOrPhone, Password = password };
                    context.Shopkeepers.Add(shopkeeper);
                    context.SaveChanges();
                    MessageBox.Show("Shopkeeper registration successful!");
                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show($"An error occurred while saving the entity changes: {ex.InnerException?.Message}");
                }
            }
        }
    }
}