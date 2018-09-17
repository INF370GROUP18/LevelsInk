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
    public partial class SupplyOrderMainForm : Form
    {
        SqlConnection MyConn = new SqlConnection(Globals.MyConnString);

        DataTable dt2 = new DataTable();
        public SupplyOrderMainForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            SupplierOrder_Details details = new SupplierOrder_Details();
            details.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
        }

        private void SupplyOrderMainForm_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT [Supplier_Inventory_ID],[Supplier_Order_Number_Description],[Supplier_Inventory_Quantity],[Supplier_Inventory_Total_Cost] FROM[dbo].[Supplier_Inventory]", MyConn);
                sda.Fill(dt2);
                dataGridView1.Rows.Clear();

                foreach (DataRow item in dt2.Rows)
                {


                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item["Supplier_Inventory_ID"].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item["Supplier_Order_Number_Description"].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = item["Supplier_Inventory_Quantity"].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = item["Supplier_Inventory_Total_Cost"].ToString();
                  
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReceiveOrder_Click(object sender, EventArgs e)
        {
            ReceiveOrder suporder = new ReceiveOrder();
            suporder.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void txtSearchEmployee_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
