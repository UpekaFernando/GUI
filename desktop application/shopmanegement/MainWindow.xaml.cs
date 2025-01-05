using System.Windows;

namespace ShopManagement
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // User Login Button Click Event
        private void btnUserLogin_Click(object sender, RoutedEventArgs e)
        {
            string email = txtUserEmail.Text;
            string password = txtUserPassword.Password;

            // Simple validation logic (replace with actual implementation)
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both email and password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBox.Show($"User login successful for {email}!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Shopkeeper Login Button Click Event
        private void btnShopLogin_Click(object sender, RoutedEventArgs e)
        {
            string shopName = txtShopName.Text;
            string email = txtShopEmail.Text;
            string password = txtShopPassword.Password;

            // Simple validation logic (replace with actual implementation)
            if (string.IsNullOrEmpty(shopName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter all details.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBox.Show($"Shopkeeper login successful for shop {shopName}!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Register Button Click Event
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string name = txtRegName.Text;
            string email = txtRegEmail.Text;
            string password = txtRegPassword.Password;
            string confirmPassword = txtRegConfirmPassword.Password;

            // Basic validation
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBox.Show($"Registration successful for {name}!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
