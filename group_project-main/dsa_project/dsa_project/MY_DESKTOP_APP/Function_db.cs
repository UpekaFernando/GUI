using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace MY_DESKTOP_APP
{
    public class Function_db
    {
        // Method to establish the database connection
        protected SqlConnection getconnection()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source=DESKTOP-6AKQJ9L\\SQLEXPRESS;database=motors3;integrated security=True";
            return con;
        }

        // Method to fetch data from the database
        public DataSet getData(String query)
        {
            SqlConnection con = getconnection(); // Get the connection
            SqlCommand cmd = new SqlCommand();  // Create a command object
            cmd.CommandText = query;           // Assign the query text
            cmd.Connection = con;              // Associate the command with the connection
            SqlDataAdapter da = new SqlDataAdapter(cmd); // Create a data adapter
            DataSet ds = new DataSet();        // Create a dataset to hold the results
            da.Fill(ds);                       // Fill the dataset with the query results
            return ds;                         // Return the dataset
        }

        // Method to insert, update, or delete data in the database
        public void SetData(String query)
        {
            SqlConnection con = getconnection(); // Get the connection
            SqlCommand cmd = new SqlCommand();  // Create a command object
            cmd.Connection = con;              // Associate the command with the connection
            con.Open();                        // Open the connection
            cmd.CommandText = query;           // Assign the query text
            cmd.ExecuteNonQuery();             // Execute the query
            con.Close();                       // Close the connection
            MessageBox.Show("Data stored successfully", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}