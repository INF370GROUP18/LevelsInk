using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeForm_Exercise
{
    public partial class SupplierOrder_Details : Form
    {
        SqlConnection MyConn = new SqlConnection(Globals.MyConnString);

     
        public SupplierOrder_Details()
        {
            InitializeComponent();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnNextSupOrd_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCloseSO_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddEmployeeSupOr_Click(object sender, EventArgs e)
        {

        }

        private void SupplierOrder_Details_Load(object sender, EventArgs e)
        {
  
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            MyConn.Open();

            SqlCommand cmd = MyConn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select from [Inventory_Item_Description],[Inventory_Item_Quantity],[Inventory_Price] from [Inventory_Item] where [Inventory_Item_Description] = '"+ tbxInvName.Text + "',[Inventory_Price] = '"+ tbxPrice.Text + "', [Inventory_Item_Quantity] between '"+ tbxMin.Text + "' and '"+ tbxMax.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            MyConn.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MyConn.Open();

            SqlCommand cmd2 = MyConn.CreateCommand();

            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = (@"INSERT INTO [dbo].[Supplier_Inventory ([Quantity_ordered]) Values ([Quantity_ordered]'" + tbxOrdered.Text + "')");
            cmd2.ExecuteNonQuery();

            MyConn.Close();

            MessageBox.Show("Inventory Item added");

            this.Close();


        }
    }
}
