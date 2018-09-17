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
    public partial class CashUpForm : Form
    {
        //string Emp_Username;
        //string Emp_Password;
        public CashUpForm()
        {
            InitializeComponent();
            string Sales_Price;

            string query = "SELECT Inventory_Price from Inventory_Item Inner Join Sale On Sale.Inventory_Item_ID = Inventory_Item.Inventory_Item_ID WHERE Sales_Date = CAST(GETDATE() AS DATE)";
            SqlConnection newConn = new SqlConnection(Globals.MyConnString);
            SqlCommand sqlComm = new SqlCommand(query, newConn);

            try
            {
                newConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlComm);
                DataSet SalesDataSet = new DataSet();
                adapter.Fill(SalesDataSet);
                newConn.Close();
                Sales_Price = SalesDataSet.Tables[0].Rows[0]["Inventory_Price"].ToString();
                lblDailySales.Text = "Daily sales: R";
                lblDailySaleValue.Text =  Sales_Price;
            }
            catch (Exception )
            {
                MessageBox.Show("No sales have today");
                lblDailySales.Text = "No sales occurred today";

            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void CashUpForm_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblCashInTil.Visible = true;
            lblCashInTilValue.Visible = true;
            lblDailySaleValue.Visible = true;
            decimal CashOnHand = (NUD200.Value * 200) + (NUD100.Value * 100) + (NUD50.Value * 50) + (NUD20.Value * 20) + (NUD10.Value * 10) + (NUD5.Value * 5) + (NUD2.Value * 2) + (NUD1.Value * 1);
            lblCashInTil.Text = "Cash in Till: R";
            lblCashInTilValue.Text = CashOnHand.ToString();

            if (lblDailySaleValue.Text == lblCashInTilValue.Text)
            {
                lblNotificationMessage.Text = "Success: The value in the till matched the value recorded for the sales!";
                lblNotificationMessage.ForeColor = System.Drawing.Color.Green;

            }
            else
            {
                lblNotificationMessage.Text = "Unsuccessful: The value in the till did not match the value recorded for the sales!";
                lblNotificationMessage.ForeColor = System.Drawing.Color.Red;

            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm adForm = new MainForm(" ","",3);
            adForm.ShowDialog();
            this.Close();
        }

        private void lblDailySales_Click(object sender, EventArgs e)
        {

        }

        private void lblDailySales_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

        

