using System;
using System.Data;
using System.Windows.Forms;
using DGVPrinterHelper;

namespace MY_DESKTOP_APP.Allusercontrol
{
    public partial class UC_Placeorder : UserControl
    {
        Function_db fn1 = new Function_db();
        String query;

        public UC_Placeorder()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void ComboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            String category = ComboType.Text;
            query = "SELECT brand FROM cars3 WHERE type = '" + category + "'";
            ShowItemList(query);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            String category = ComboType.Text;
            query = "SELECT brand FROM cars3 WHERE type = '" + category + "' AND brand LIKE '" + txtSearch.Text + "%'";
            ShowItemList(query);
        }

        private void ShowItemList(String query)
        {
            listBox1.Items.Clear();

            DataSet ds = fn1.getData(query);
            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            {
                listBox1.Items.Add(ds.Tables[0].Rows[j][0]);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtQuantity.ResetText();
            txtTotal.Clear();
            string text = listBox1.GetItemText(listBox1.SelectedItem);
            txtItemName.Text = text;

            query = "SELECT price FROM cars3 WHERE brand = '" + text + "'";
            DataSet ds = fn1.getData(query);

            try
            {
                txtPrice.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch
            {
                MessageBox.Show("Error retrieving price data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtQuantity_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                // Ensure both values are parsed correctly
                decimal price = decimal.Parse(txtPrice.Text);
                decimal quantity = txtQuantity.Value; // Directly using the NumericUpDown control's value

                // Calculate the total price
                decimal total = price * quantity;
                txtTotal.Text = total.ToString("F2"); // Format with two decimal places
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid input format. Please ensure the price is a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal total = 0m; // Use decimal for the total amount
        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            try
            {
                // Add row to the DataGridView
                if (txtTotal.Text != "0" && txtTotal.Text != "")
                {
                    int n = guna2DataGridView1.Rows.Add();
                    guna2DataGridView1.Rows[n].Cells[0].Value = txtItemName.Text;
                    guna2DataGridView1.Rows[n].Cells[1].Value = txtQuantity.Value;
                    guna2DataGridView1.Rows[n].Cells[2].Value = txtPrice.Text;
                    guna2DataGridView1.Rows[n].Cells[3].Value = txtTotal.Text;

                    // Add the total price of the current item to the overall total
                    decimal itemTotal = decimal.Parse(txtTotal.Text);
                    total += itemTotal;

                    // Update the total amount label
                    labelTotalAmount.Text = "RS: " + total.ToString("F2");
                    // Format with two decimal places
                }

                else
                {
                    MessageBox.Show("You should include atleast one item", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid input format. Please ensure the total is a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        int amount;
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                amount = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
            }
            catch
            {
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the amount from the selected row
                decimal amountToRemove = decimal.Parse(guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString());

                // Remove the selected row
                guna2DataGridView1.Rows.RemoveAt(this.guna2DataGridView1.SelectedRows[0].Index);

                // Recalculate the total by summing up all the items
                total = 0;
                foreach (DataGridViewRow row in guna2DataGridView1.Rows)
                {
                    total += Convert.ToDecimal(row.Cells[3].Value); // Add the total price from each row
                }

                // Update the total amount label
                labelTotalAmount.Text = "RS: " + total.ToString("F2");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Customer Bill";
            printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Total payment :" + labelTotalAmount.Text;
            printer.PrintDataGridView(guna2DataGridView1);

            total = 0;
            guna2DataGridView1.Rows.Clear();
            labelTotalAmount.Text = "RS :" + total;

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
