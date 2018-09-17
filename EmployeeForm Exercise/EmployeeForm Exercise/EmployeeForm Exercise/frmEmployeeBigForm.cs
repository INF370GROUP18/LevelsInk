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
    public partial class frmEmployeeBigForm : Form
    {

        SqlConnection MyConn = new SqlConnection(Globals.MyConnString);
        public frmEmployeeBigForm()
        {

            InitializeComponent();
        }

        private void frmEmployeeBigForm_Load(object sender, EventArgs e)
        {
            

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("Select Employee.Employee_ID, Employee.employee_name, Employee.employee_surname, Employee_Contact.Employee_Address, Employee_Contact.Employee_Cell_Number, Employee_Contact.Employee_Telephone, Employee_Contact.Employee_Email FROM Employee, Employee_Contact where Employee.Employee_ID = Employee_Contact.Employee_Contact_ID", MyConn);

                DataTable dt2 = new DataTable();   
                sda.Fill(dt2);
                dataGridView1.Rows.Clear();
                foreach (DataRow item in dt2.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item["Employee_ID"].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item["employee_name"].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = item["employee_surname"].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = item["Employee_Address"].ToString();
                    dataGridView1.Rows[n].Cells[4].Value = item["Employee_Cell_Number"].ToString();
                    dataGridView1.Rows[n].Cells[5].Value = item["Employee_Telephone"].ToString();
                    dataGridView1.Rows[n].Cells[6].Value = item["Employee_Email"].ToString();
                  
                }
                
      
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LstEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            



        }

        private void txtSearchEmployee_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
