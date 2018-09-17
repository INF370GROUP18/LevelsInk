using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;


namespace EmployeeForm_Exercise
{
    public partial class frmEmployeePassword : Form
    {
        public frmEmployeePassword()
        {
            SqlConnection MyConn = new SqlConnection(Globals.MyConnString);

            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmEmployeePassword_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSavePassword_Click(object sender, EventArgs e)
        {
            SqlConnection MyConn = new SqlConnection(Globals.MyConnString);


            try
            {
                MyConn.Open();


                SqlCommand cmd1 = new SqlCommand(@"INSERT INTO [dbo].[Employee_Login]
           (
           [Employee_Name]
           ,[Employee_Password]
  
     VALUES
           ('"+tbxUserName.Text +"','"+tbxPassWrd.Text +"')", MyConn);

                
               if (MessageBox.Show("Are you sure about about the password entered? ","Re-Type Password",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes);

                {
                    MessageBox.Show("Password confirmed! ");
                    this.Close();
                }


                MyConn.Close();
            }
            catch (Exception ErrorP)
            {

                MessageBox.Show("Saving password was not successful! " + ErrorP.Message);
                
                
            }
        }
    }
}
