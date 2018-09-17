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
    public partial class EmployeeType : Form
    {
        SqlConnection MyConn = new SqlConnection(Globals.MyConnString);
        public EmployeeType()
        {
            InitializeComponent();
        }

        private void EmployeeType_Load(object sender, EventArgs e)
        {

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT [Employee_Type_ID],[Employee_Type_Description]FROM [dbo].[Employee_Type]", MyConn);

                DataTable dt2 = new DataTable();
                sda.Fill(dt2);
                dgvType.Rows.Clear();
                foreach (DataRow item in dt2.Rows)
                {
                    int n = dgvType.Rows.Add();
                    dgvType.Rows[n].Cells[0].Value = item["[Employee_Type_ID]"].ToString();
                    dgvType.Rows[n].Cells[1].Value = item["[Employee_Type_Description]"].ToString();
               

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnAddType_Click(object sender, EventArgs e)
        {
            try
            {
                MyConn.Open();

                SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Employee_Type]
           ([Employee_Type_Description])
     VALUES
           ('" + tbxType.Text + "')", MyConn);


                if (MessageBox.Show("Are you sure about about the employee type? ", "Re-Type Type", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);

                {
                    MessageBox.Show("Employee type confirmed! ");
                    this.Close();
                }

            }
            catch (Exception Error)
            {
                MessageBox.Show("Error in saving an employee type" + Error.Message);

            }
        }

        private void btnCloseType_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
