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
    public partial class EmployeeForm : Form
    {
        SqlConnection MyConn = new SqlConnection(Globals.MyConnString);

        public EmployeeForm()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            try
            {
                string query = "Select Employee.Employee_ID, Employee.employee_name, Employee.employee_surname, Employee_Contact.Employee_Address, Employee_Contact.Employee_Cell_Number, Employee_Contact.Employee_Email FROM Employee INNER JOIN Employee_Contact ON Employee.Employee_Contact_ID = Employee_Contact.Employee_Contact_ID";
                MyConn.Open();

                SqlCommand cmd = new SqlCommand(query, MyConn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                SqlDataReader myReader = cmd.ExecuteReader();
                
                ListViewItem x = null;
                lstEmployee.Items.Clear();

                while (myReader.Read() == true)
                {
                    x = new ListViewItem(myReader["Employee_ID"].ToString());
                    x.SubItems.Add(myReader["employee_name"].ToString());
                    x.SubItems.Add(myReader["employee_surname"].ToString());
                    x.SubItems.Add(myReader["Employee_Address"].ToString());
                    x.SubItems.Add(myReader["Employee_Cell_Number"].ToString());
                    x.SubItems.Add(myReader["Employee_Email"].ToString());

                    lstEmployee.Items.Add(x);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //finally
            //{
            //    SQLConn.cmd.Dispose();
            //    SQLConn.conn.Close();
            //}
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddEditEmployeeForm addEmpl = new AddEditEmployeeForm("Add");
            addEmpl.ShowDialog();
            this.Close();
        }

        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddEditEmployeeForm editEmpl = new AddEditEmployeeForm("Edit");
            editEmpl.ShowDialog();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm frmMain = new MainForm("","",4);
            frmMain.ShowDialog();
            this.Close();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
