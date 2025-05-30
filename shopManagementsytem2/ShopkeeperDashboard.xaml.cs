﻿using System;
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
    /// Interaction logic for ShopkeeperDashboard.xaml
    /// </summary>
    public partial class ShopkeeperDashboard : Window
    {
        private string shopName;

        public ShopkeeperDashboard(string shopName)
        {
            InitializeComponent();
            this.shopName = shopName;
        }

        // Home Button Click Event
        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            textBlock.Text = "Welcome to your Dashboard!";
            ordersPanel.Visibility = Visibility.Collapsed;
        }

        // Manage Listings Button Click Event
        private void btnManageListings_Click(object sender, RoutedEventArgs e)
        {
            textBlock.Text = "Manage your product listings here!";
            ordersPanel.Visibility = Visibility.Collapsed;
            AddMenu addMenuWindow = new AddMenu(shopName);
            addMenuWindow.Show();
        }

        // Orders Button Click Event
        private void btnOrders_Click(object sender, RoutedEventArgs e)
        {
            textBlock.Text = "View and manage your orders here!";
            LoadOrders();
            ordersPanel.Visibility = Visibility.Visible;
        }

        // Sales Report Button Click Event
        private void btnSalesReport_Click(object sender, RoutedEventArgs e)
        {
            textBlock.Text = "View your sales report here!";
            ordersPanel.Visibility = Visibility.Collapsed;
        }

        // Customer Feedback Button Click Event
        private void btnCustomerFeedback_Click(object sender, RoutedEventArgs e)
        {
            textBlock.Text = "View and respond to customer feedback!";
            ordersPanel.Visibility = Visibility.Collapsed;
        }

        // Settings Button Click Event
        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            textBlock.Text = "Manage your shop settings here!";
            ordersPanel.Visibility = Visibility.Collapsed;
        }

        // Clear Order History Button Click Event
        private void btnClearOrderHistory_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new MenuDb())
            {
                var orders = context.Orders.Where(o => o.ShopName == shopName).ToList();
                context.Orders.RemoveRange(orders);
                context.SaveChanges();
            }
            listBoxOrders.ItemsSource = null;
            MessageBox.Show("Order history cleared.");
        }

        private void LoadOrders()
        {
            using (var context = new MenuDb())
            {
                var orders = context.Orders.Where(o => o.ShopName == shopName).ToList();
                listBoxOrders.ItemsSource = orders.Select(o => $"{o.OrderDate}: {o.MenuName}").ToList();
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}


