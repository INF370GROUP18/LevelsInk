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
    public partial class LockForm : Form
    {
        public LockForm()
        {
            InitializeComponent();
        }

        private void LockForm_Load(object sender, EventArgs e)
        {
            tmrElapsedTime.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string Employee_Password;
            Employee_Password = txtPassword.Text;


            if (Employee_Password != null && Employee_Password != "")
            {
                string query = "SELECT * FROM Employee WHERE Employee_Password = @Employee_Password ";
                SqlConnection newConn = new SqlConnection(Globals.MyConnString);
                SqlCommand sqlComm = new SqlCommand(query, newConn);
                sqlComm.Parameters.AddWithValue("@Employee_Password", Employee_Password);
                try
                {
                    newConn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlComm);
                    DataSet SalesDataSet = new DataSet();
                    adapter.Fill(SalesDataSet);
                    newConn.Close();
                    int count = SalesDataSet.Tables[0].Rows.Count;
                    if (count > 0)
                    {
                        this.Hide();
                        MainForm frmAdmin = new MainForm(SalesDataSet.Tables[0].Rows[0]["Employee_Name"].ToString(),"", Convert.ToInt32(SalesDataSet.Tables[0].Rows[0]["Employee_ID"]));
                        frmAdmin.ShowDialog();
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("The Password is incorrect and the system cannot unlock, please try again.","Incorrect Password",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
            else
            {
                MessageBox.Show("Please make sure that the Password fields are Filled in.");
            }
        }

        private void tmrElapsedTime_Tick(object sender, EventArgs e)
        {
            if (tmrElapsedTime.Interval == 900000)
            {
                tmrElapsedTime.Enabled = false;
                this.Hide();
                MessageBox.Show("The 15 minute period to lock the system has elapsed.", "Time Elapsed", MessageBoxButtons.OK,MessageBoxIcon.Information);
                LoginForm lginfrm = new LoginForm();
                lginfrm.ShowDialog();
                this.Close();
            }
      
            
        }
    }
}

