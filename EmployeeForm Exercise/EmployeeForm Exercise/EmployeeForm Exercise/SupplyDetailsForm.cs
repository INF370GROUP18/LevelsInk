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
using System.Data.Sql;

namespace EmployeeForm_Exercise
{
    public partial class SupplyDetailsForm : Form
    {
        SqlConnection MyConn = new SqlConnection(Globals.MyConnString);

        DataTable dt2 = new DataTable();
        
        public SupplyDetailsForm()
        {
            InitializeComponent();
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
           
           
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            NewForm SuppDetails = new NewForm();
            SuppDetails.ShowDialog();
        }



        private void SupplyDetailsForm_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();

            try

            {            //{
                         //    SqlDataAdapter sda = new SqlDataAdapter("Select Supplier.Supplier_ID, Supplier.Supplier_Name , Supplier.Supplier_Surname, Supplier.Supplier_Description, Supplier_Contact.Supplier_Cellphone_Number, Supplier_Contact.Supplier_Telephone, Supplier_Contact.Supplier_Email FROM Supplier, Supplier_Contact where Supplier.Supplier_ID = Supplier_Contact.Supplier_Contact_ID", MyConn);
                         //    sda.Fill(dt2);
                         //    dataGridView1.Rows.Clear();

                //    foreach (DataRow item in dt2.Rows)
                //    {


                //        int n = dataGridView1.Rows.Add();
                //        dataGridView1.Rows[n].Cells[0].Value = item["Supplier_ID"].ToString();
                //        dataGridView1.Rows[n].Cells[1].Value = item["Supplier_Name"].ToString();
                //        dataGridView1.Rows[n].Cells[2].Value = item["Supplier_Surname"].ToString();
                //        dataGridView1.Rows[n].Cells[3].Value = item["Supplier_Description"].ToString();
                //        dataGridView1.Rows[n].Cells[4].Value = item["Supplier_Cellphone_Number"].ToString();
                //        dataGridView1.Rows[n].Cells[5].Value = item["Supplier_Telephone"].ToString();
                //        dataGridView1.Rows[n].Cells[6].Value = item["Supplier_Email"].ToString();

            

            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSearchEmployee_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt2);

            string query = "SELECT Supplier_Name FROM Supplier where Supplier_ID = '%{0}%'";
            dv.RowFilter = String.Format(query,txtSearchSupplier.Text);
            dataGridView1.DataSource = dv;

            MessageBox.Show("No results were shown");
        }
    }
}
