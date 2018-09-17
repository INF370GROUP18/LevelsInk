using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Nati_Supermarket_and_Takeaway_WinForms
{
    public partial class CheckInEmployeeForm : Form
    {
        SqlConnection MyConn = new SqlConnection(Globals.MyConnString);

        string formtype = "";
        

        public CheckInEmployeeForm(string type)
        {
            formtype = type;
            InitializeComponent();
           
        }

        private void EmployeeCheckInForm_Load(object sender, EventArgs e)
        {
            try
            {
                string query = "Select Employee.Employee_ID, Employee.employee_name, Employee.employee_surname, Employee_Type.Employee_Type_Description FROM Employee INNER JOIN Employee_Type ON Employee.Employee_Type_ID = Employee_Type.Employee_Type_ID";
                MyConn.Open();

                SqlCommand cmd = new SqlCommand(query, MyConn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                SqlDataReader myReader = cmd.ExecuteReader();

                ListViewItem x = null;
                lstEmployees.Items.Clear();

                while (myReader.Read() == true)
                {
                    x = new ListViewItem(myReader["Employee_ID"].ToString());
                    x.SubItems.Add(myReader["Employee_name"].ToString());
                    x.SubItems.Add(myReader["Employee_surname"].ToString());
                    lstEmployees.Items.Add(x);
                }
                MyConn.Close();
                if (formtype == "In")
            {
                btnCheckIn.Visible = true;
                lblEmployeeCheckOut.Visible = false;
                this.Text = "Employee Check-" + formtype;
                lblInOut.Text = "Check In Employee";
            }
            else
            {
                btnCheckOut.Visible = true;
                lblEmployeeCheckIn.Visible = false;
                this.Text = "Employee Check-" + formtype;
                lblInOut.Text = "Check Out Employee";
            }
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "Select Employee.Employee_ID, Employee.employee_name, Employee.employee_surname, Employee_Type.Employee_Type_Description FROM Employee INNER JOIN Employee_Type ON Employee.Employee_Type_ID = Employee_Type.Employee_Type_ID";
                MyConn.Open();

                DateTime datenow = DateTime.Now;
                SqlCommand cmd = new SqlCommand(query, MyConn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                SqlDataReader myReader = cmd.ExecuteReader();

                ListViewItem x = null;
                lstEmployees.Items.Clear();

                while (myReader.Read() == true)
                {
                    x = new ListViewItem(myReader["Employee_ID"].ToString());
                    x.SubItems.Add(myReader["Employee_name"].ToString());
                    x.SubItems.Add(myReader["Employee_surname"].ToString()) ;
                   

                    lstEmployees.Items.Add(x);
                }

                MessageBox.Show("The employee " + lstEmployees.Items[0].SubItems[1].Text + " " + lstEmployees.Items[0].SubItems[2].Text + " was checked in at " + datenow.ToString() + ". ","Successful Check in",MessageBoxButtons.OK,MessageBoxIcon.Information);

            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                throw;
            }
           
        }

        private void lblCheckIn_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm frmMain = new MainForm(" ","",1);
            frmMain.ShowDialog();
            this.Close();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "Select Employee.Employee_ID, Employee.employee_name, Employee.employee_surname, Employee_Type.Employee_Type_Description FROM Employee INNER JOIN Employee_Type ON Employee.Employee_Type_ID = Employee_Type.Employee_Type_ID";
                MyConn.Open();

                DateTime datenow = DateTime.Now;
                SqlCommand cmd = new SqlCommand(query, MyConn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                SqlDataReader myReader = cmd.ExecuteReader();

                ListViewItem x = null;
                lstEmployees.Items.Clear();

                while (myReader.Read() == true)
                {
                    x = new ListViewItem(myReader["Employee_ID"].ToString());
                    x.SubItems.Add(myReader["Employee_name"].ToString());
                    x.SubItems.Add(myReader["Employee_surname"].ToString());


                    lstEmployees.Items.Add(x);
                }

                MessageBox.Show("The employee " + lstEmployees.Items[0].SubItems[1].Text + " " + lstEmployees.Items[0].SubItems[2].Text + " was checked out at " + datenow.ToString() + ". ", "Successful Check out", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                throw;
            }

        }
    }
}
