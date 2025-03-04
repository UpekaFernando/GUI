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
    public partial class UC_UPDATE : UserControl
    {
        Function_db fn2 = new Function_db();
        String query;
        public UC_UPDATE()
        {
            InitializeComponent();
        }

        int id;
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            string type = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            string brand = guna2DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            int quantity = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
            decimal price = decimal.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());

            txtType.Text = type;
            txtName.Text = brand;
            txtQuantity.Text = quantity.ToString();
            txtPrice.Text = price.ToString();


        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void UC_UPDATE_Load(object sender, EventArgs e)
        {
            query = "select * from cars3 ";
            LoadData(query);
        }

        public void LoadData(string qur)
        {
            query = qur;
            DataSet ds = fn2.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];

        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            query = "select * from cars3 where brand like'" + txtSearchName.Text + "%'";
            LoadData(query);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Corrected SQL query
            query = "UPDATE cars3 SET brand='" + txtName.Text +
                    "', type='" + txtType.Text +
                    "', quantity=" + txtQuantity.Text +
                    ", price=" + txtPrice.Text +
                    " WHERE iid=" + id;

            fn2.SetData(query); // Execute the query
            LoadData("SELECT * FROM cars3"); // Refresh data after update
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
