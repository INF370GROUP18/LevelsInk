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
    public partial class Check_in_Supply : Form
    {
        public Check_in_Supply()
        {
            InitializeComponent();
        }
        SqlConnection MyConn = new SqlConnection(Globals.MyConnString);


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MyConn.Open();

                SqlCommand cmd = new SqlCommand(@"SELECT INTO [dbo].[Supplier]
                      (
                        [Supplier_Surname]
                      )
                VALUES
                      ('" + tbxSurn.Text + "')", MyConn);

                SqlCommand cmd2 = new SqlCommand(@"INSERT INTO [dbo].[Supplier_Inventory]
                      ([Supplier_Inventory_Date])
                VALUES
                      ('" + dateTimePicker1.Value + "')", MyConn);



                SqlCommand cmd3 = new SqlCommand(@"INSERT INTO [dbo].[Supplier_Contact]
                      ([Supplier_Cellphone_Number], [Supplier_Email])
                VALUES
                      ('" + tbxCell.Text + "','" + tbxEm.Text + "')", MyConn);



                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Supply order was made " + ex.Message);
            }

        }

        private void Check_in_Supply_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'natiSupermarketandTakeawayFinalDataSet.Supplier_Inventory' table. You can move, or remove it, as needed.
            this.supplier_InventoryTableAdapter.Fill(this.natiSupermarketandTakeawayFinalDataSet.Supplier_Inventory);

        }

        private void btnReceiveOrder_Click(object sender, EventArgs e)
        {
            SupplierOrder_Details formm = new SupplierOrder_Details();
            formm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
