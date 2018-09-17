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
    
    public partial class SupplierPayment : Form
    {
        SqlConnection MyConn = new SqlConnection(Globals.MyConnString);
        public SupplierPayment()
        {
            InitializeComponent();
        }

        private void SupplierPayment_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Supply payment details were saved");
     //       try
     //       {
     //           MyConn.Open();

     //           SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Supplier_Payment]
     //      ([Supplier_Payment_Date]
     //      ,[Supplier_Payment_Status]
     //      ,[Supplier_Payment_Total]
     //      )
     //VALUES
     //      ('"+dateTimePicker1.Value + "', '"+ comboBox1.SelectedIndex + "','"+tbxTotal.Text +"' )", MyConn);

     //           SqlCommand cmd2 = new SqlCommand(@"INSERT INTO [dbo].[Supplier_Payment_Type]
     //      ([Supplier_Payment_Type_Description])
     //VALUES
     //      ('"+comboBox2.SelectedIndex +"')", MyConn);

     //           cmd.ExecuteNonQuery();
     //           cmd2.ExecuteNonQuery();

     //           MessageBox.Show("Supply payment details were saved ");
     //       }
     //       catch (Exception ex)
     //       {
     //           MessageBox.Show("Supply payment was not saved " + ex.Message);
     //       }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnUpdateS_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
