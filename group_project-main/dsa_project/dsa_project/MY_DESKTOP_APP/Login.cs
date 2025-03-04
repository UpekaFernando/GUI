namespace MY_DESKTOP_APP
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Dashboard dS = new Dashboard("Guest");
            dS.Show();
            this.Hide();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtpassword.Text == "Admin123" && txtusername.Text == "Admin")
            {
                Dashboard dashboard2 = new Dashboard("User");
                dashboard2.Show();
                this.Hide();

            }

            else if (txtpassword.Text == "Admin123" && txtusername.Text != "Admin")
            {

                MessageBox.Show("The username you entered is incorrect. Please try again.",
                                "Invalid Username",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                

                txtusername.Clear();
                txtusername.Focus();




            }

            else if (txtpassword.Text != "Admin123" && txtusername.Text == "Admin")
            {
                MessageBox.Show("The password you entered is incorrect. Please try again.",
                               "Invalid Password",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);

                txtpassword.Clear(); 
                txtpassword.Focus();
            }

            else
            {
                MessageBox.Show("Both username and password is incorrect. Please try again.",
                               "Login Failed",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);

                cleartext();

            }

        }

        public void cleartext()
        {
            txtpassword.Clear();
            txtusername.Clear();
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
