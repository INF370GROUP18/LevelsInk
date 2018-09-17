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
    public partial class NewForm : Form
    {
        SqlConnection MyConn = new SqlConnection(Globals.MyConnString);

        public NewForm()
        {
            InitializeComponent();

        }

        private void NewForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            

            try
            {
                MyConn.Open();


                // Adding to Supplier table

                SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Supplier]
           ([Supplier_Name],[Supplier_Surname]
           )
     VALUES
           ( '"+ tbxNameSupplier.Text +"','"+ tbxSurnameSupplier.Text +"')", MyConn);


                //Adding to Supplier Contact

                SqlCommand cmd4 = new SqlCommand(@"INSERT INTO [dbo].[Supplier_Contact]
           ([Supplier_Cellphone_Number]
           ,[Supplier_Telephone]
           ,[Supplier_Email]
           ,[Supplier_Address])
     VALUES
           ('" + tbxCNumSupplier.Text + "','" + tbxTPhoneSupplier.Text + "', '" + tbxEmailSupplier.Text + "', '" + tbxAddressSupp.Text + "')", MyConn);


                cmd.ExecuteNonQuery();
                cmd4.ExecuteNonQuery();

                MessageBox.Show("Supplier has been successfully added");

                MyConn.Close();
            }


            catch (Exception Error)
            {

                MessageBox.Show("Supplier was not added on to the system " + Error.Message);
            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
