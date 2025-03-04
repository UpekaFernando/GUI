using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MY_DESKTOP_APP.Allusercontrol
{
    public partial class UC_CONTACT : UserControl
    {
        Function_db fn4 = new Function_db();
        string query;
        public UC_CONTACT()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Fixed SQL query
            query = "INSERT INTO people(name, email, gender) VALUES('" +
                     txtName.Text + "', '" +
                     txtEmail.Text + "', '" +
                     txtGender.Text + "')";

            fn4.SetData(query);
            clearAll();
        }

        public void clearAll()
        {
            txtGender.SelectedIndex = -1;
            txtEmail.Clear();
            txtName.Clear();
        }

        private void UC_CONTACT_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
