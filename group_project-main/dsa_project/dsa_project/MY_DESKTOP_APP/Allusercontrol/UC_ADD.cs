using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MY_DESKTOP_APP.Allusercontrol
{
    public partial class UC_ADD : UserControl
    {
        Function_db fn = new Function_db();
        String query;
        public UC_ADD()
        {
            InitializeComponent();
        }

        private void AddItem_Click(object sender, EventArgs e)
        {
            // Corrected query syntax
            query = "insert into cars3(type,brand,quantity,price) values('" + txttype.Text + "','" + txtname.Text + "','" + txtQuantity.Text + "'," + txtPrice.Text + ")";
            fn.SetData(query);
            clearAll();
        }

        public void clearAll()
        {
            txttype.SelectedIndex = -1;
            txtname.Clear();
            txtQuantity.Clear();
            txtPrice.Clear();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            txtPrice.Clear();
            txtQuantity.Clear();
            txtname.Clear();
            txttype.SelectedIndex = -1;
        }

        private void UC_ADD_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void txttype_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
