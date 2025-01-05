using System.Windows;

namespace ShopManagement
{
    public partial class ShopkeeperDashboard : Window
    {
        public ShopkeeperDashboard()
        {
            InitializeComponent();
        }

        // Home Button Click Event
        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            textBlock.Text = "Welcome to your Dashboard!";
            // You can replace this with the actual content for the Home section
        }

        // Manage Listings Button Click Event
        private void btnManageListings_Click(object sender, RoutedEventArgs e)
        {
            textBlock.Text = "Manage your product listings here!";
            // Replace this with the Manage Listings content (a UserControl or another window)
        }

        // Orders Button Click Event
        private void btnOrders_Click(object sender, RoutedEventArgs e)
        {
            textBlock.Text = "View and manage your orders here!";
            // Replace this with the Orders content (like a list of orders)
        }

        // Sales Report Button Click Event
        private void btnSalesReport_Click(object sender, RoutedEventArgs e)
        {
            textBlock.Text = "View your sales report here!";
            // Replace this with the Sales Report content (graphs, charts, etc.)
        }

        // Customer Feedback Button Click Event
        private void btnCustomerFeedback_Click(object sender, RoutedEventArgs e)
        {
            textBlock.Text = "View and respond to customer feedback!";
            // Replace this with the Customer Feedback content (list of feedback entries)
        }

        // Settings Button Click Event
        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            textBlock.Text = "Manage your shop settings here!";
            // Replace this with the Settings content (input fields, options, etc.)
        }
    }
}
