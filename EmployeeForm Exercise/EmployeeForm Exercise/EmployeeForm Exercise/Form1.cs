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
    public partial class Form1 : Form
    {
        SqlConnection MyConn = new SqlConnection(Globals.MyConnString);
        public Form1()
        {

            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           

            try
            {
                MyConn.Open();


                // Adding to table Employee
                SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Employee]
           ([Employee_Name]
           ,[Employee_Surname]
           )
     VALUES
           ( '" + tbxName.Text + "','" + tbxSurname.Text + "')",MyConn);


                // Adding to Employee Role
                SqlCommand cmd2 = new SqlCommand(@"INSERT INTO [dbo].[Employee_Type]
           ([Employee_Type_Description])
     VALUES
           ('"+ cmbRole.SelectedIndex+"')", MyConn);


                // Adding to Employee Title 

                SqlCommand cmd3 = new SqlCommand(@"INSERT INTO [dbo].[Employee_Title]
           ([Employee_Title_Description])
     VALUES
           ('"+cmbTitle.SelectedIndex + "')", MyConn);


                //Adding to Employee Contact

                SqlCommand cmd4 = new SqlCommand(@"INSERT INTO [dbo].[Employee_Contact]
           ([Employee_Cell_Number]
           ,[Employee_Telephone]
           ,[Employee_Email]
           ,[Employee_Address])
     VALUES
           ('"+tbxCNum.Text +"','"+tbxTPhone.Text + "', '"+tbxEmail.Text +"', '"+tbxAddress.Text +"')", MyConn);


                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                cmd4.ExecuteNonQuery();

                MessageBox.Show("Successful Save");

                MyConn.Close();
            }
            

            catch (Exception Error)
            {

                MessageBox.Show("Error in adding employee information " + Error.Message);
            }


        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            frmEmployeePassword form = new frmEmployeePassword();
            form.ShowDialog();
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            frmEmployeeBigForm bigF = new frmEmployeeBigForm();
            bigF.ShowDialog();
        }

        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            try
            {

                MyConn.Open();

                SqlCommand cmd2 = MyConn.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                
                cmd2.CommandText = "update Employee set name ='" + tbxSurname.Text + "' where name ='" + tbxName + "'";
                cmd2.ExecuteNonQuery();

                MessageBox.Show("Record updated successfully! ");

                MyConn.Close();

   
            }
            catch (Exception)
            {

                MessageBox.Show("Update successful! ");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            EmployeeType Type = new EmployeeType();
            Type.Show();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
