using System;
using System.Collections;
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
    public partial class UC_CUSTOMERVIEW : UserControl
    {
        Function_db fn5 = new Function_db();
        string query;
        public UC_CUSTOMERVIEW()
        {
            InitializeComponent();
        }

        private void UC_CUSTOMERVIEW_Load(object sender, EventArgs e)
        {
            query = "select * from people ";
            LoadData(query);
        }

        public void LoadData(string qur)
        {
            query = qur;
            DataSet ds = fn5.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
