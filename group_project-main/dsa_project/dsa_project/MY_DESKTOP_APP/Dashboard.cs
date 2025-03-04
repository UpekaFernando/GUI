using MY_DESKTOP_APP.Allusercontrol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MY_DESKTOP_APP
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        public Dashboard(String user)
        {
            if (user == "Guest")
            {
                InitializeComponent();

                btnPlaceorder.Hide();
                btnDelete.Hide();
                btnUpdate.Hide();
                btnContact.Hide();
                btnviewcustomer.Hide();


            }

            else if (user == "User")
            {
                InitializeComponent();
                btnAdd.Show();
                btnDelete.Show();
                btnUpdate.Show();
                btnContact.Show();
                btnviewcustomer.Show();

            }

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            uC_add1.Visible = true;
            uC_add1.BringToFront();
        }

        private void Logoutbtn_Click(object sender, EventArgs e)
        {
            Login L1 = new Login();
            L1.Show();
            this.Hide();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            uC_add1.Visible = false;
            uC_Placeorder1.Visible = false;
            uC_update1.Visible = false;
            uC_delete1.Visible = false;
            uC_contact1.Visible = false;
            uC_customerview1.Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            uC_welcome1.SendToBack();
            guna2Transition1.ShowSync(uC_Placeorder1);
            uC_Placeorder1.Visible = true;
            uC_Placeorder1.BringToFront();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            uC_update1.Visible = true;
            uC_update1.BringToFront();
        }

        private void btnPlaceorder_Click(object sender, EventArgs e)
        {
            uC_delete1.Visible = true;
            uC_delete1.BringToFront();
        }

        private void btnContact_Click(object sender, EventArgs e)
        {
            uC_contact1.Visible = true;
            uC_contact1.BringToFront();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            uC_customerview1.Visible = true;
            uC_customerview1.BringToFront();
        }

        private void uC_customerview1_Load(object sender, EventArgs e)
        {

        }
    }
}
