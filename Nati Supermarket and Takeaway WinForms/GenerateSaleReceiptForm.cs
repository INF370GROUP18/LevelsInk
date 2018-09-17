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
    public partial class SalesHistoryForm : Form
    {
        public SalesHistoryForm()
        {
            InitializeComponent();
            
        }

        private void ViewSalesForm_Load(object sender, EventArgs e)
        {
            SqlConnection myConn = new SqlConnection(Globals.MyConnString);
            SqlDataAdapter myAdapter = new SqlDataAdapter();
            DataSet myDS = new DataSet();
            string myQuery = "SELECT * from Sales";
            SqlCommand myCmd = new SqlCommand();
            try
            {
                myCmd.Connection = myConn;
                myCmd.CommandText = myQuery;

                myConn.Open();
                myAdapter.SelectCommand = myCmd;

                myAdapter.Fill(myDS, "Sales");
                dgvSales.DataSource = myDS;
                dgvSales.DataMember = "Sales";
                dgvSales.ReadOnly = true;

                myConn.Close();

            }
            catch (Exception myErr)
            {
                MessageBox.Show("Error: " + myErr.Message);
            }
        }

        private void makeSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            POSForm frmPOS = new POSForm("","",1,"","","","","","","","");
            frmPOS.ShowDialog();

        }

        private void btnReciept_Click(object sender, EventArgs e)
        {
            rtfReciept.Clear();

            rtfReciept.AppendText(Environment.NewLine);
            rtfReciept.AppendText("--------------------------------------------------------------------------------" + Environment.NewLine);
            rtfReciept.AppendText("\t" + "Nati Supermarket and Takeaways" + Environment.NewLine);
            rtfReciept.AppendText("--------------------------------------------------------------------------------" + Environment.NewLine + Environment.NewLine);
            rtfReciept.AppendText("Till Number....:" + "1" + Environment.NewLine);
            rtfReciept.AppendText("Sale ID........:" + "1" + "\n" + "BARCODE:" + "1982" + Environment.NewLine);
            rtfReciept.AppendText("Employee ID....:" + txtEmployeeID.Text + "\n" + "Employee Name:" + txtEmployeeName.Text + Environment.NewLine);
            rtfReciept.AppendText("------------------------------------------------------------------------------- " + Environment.NewLine);
            for (int i = 0; i < dgvSales.Rows.Count - 1; i++)
            {
                rtfReciept.Text = rtfReciept.Text + "-";

                for (int j = 0; j < dgvSales.Columns.Count; j++)
                {
                    rtfReciept.Text = rtfReciept.Text + "\t" + dgvSales.Rows[i].Cells[j].Value.ToString() + "\t";
                }
                rtfReciept.Text = rtfReciept.Text + "\n";
                rtfReciept.Text = rtfReciept.Text + "----------------------------------------------------------------------------------";
                rtfReciept.Text = rtfReciept.Text + "\n";
            }
            rtfReciept.AppendText("--------------------------------------------------------------------------------" + Environment.NewLine);
            rtfReciept.AppendText("Sub Total......:R " + 20 + Environment.NewLine);
            rtfReciept.AppendText("V.A.T..........:R " + 12 + Environment.NewLine);
            rtfReciept.AppendText("TOTAL..........:R " + 32 + Environment.NewLine);
            rtfReciept.AppendText("-------------------------------------------------------------------------------" + Environment.NewLine);
            rtfReciept.AppendText("Tendered Cash..:R " + 50 + Environment.NewLine);
            rtfReciept.AppendText("Customer Change:R " + 18 + Environment.NewLine);
            rtfReciept.AppendText("-------------------------------------------------------------------------------" + Environment.NewLine);

            //rtfReciept.AppendText(lblTime.Text + "\t\t" + lblDate.Text);
        }

        private void gbxAction_Enter(object sender, EventArgs e)
        {

        }

        private void txtResult_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void rtfReciept_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click_1(object sender, EventArgs e)
        {

        }
    }
}
