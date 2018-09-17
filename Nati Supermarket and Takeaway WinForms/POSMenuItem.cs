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
    public partial class POSMenuItem : Form
    {
        SqlConnection MyConn = new SqlConnection(Globals.MyConnString);
        SqlCommand myCmd = new SqlCommand();
        SqlDataAdapter myAdapter = new SqlDataAdapter();
        DataSet MenuDS = new DataSet();
        public POSMenuItem()
        {
            InitializeComponent();
            string myString = "SELECT Menu_Item.Menu_Item_ID, Menu_Item_Description, Menu_Item_Discount,  Menu_Item_Price_Amount from Menu_Item_Price inner join Menu_Item ON Menu_Item.Menu_Item_ID = Menu_Item_Price.Menu_Item_ID ";
            try
            {
                myCmd.Connection = MyConn;
                myCmd.CommandText = myString;

                MyConn.Open();
                myAdapter.SelectCommand = myCmd;

                myAdapter.Fill(MenuDS, "Menu_Item");
                dgvMenuItem.DataSource = MenuDS;
                dgvMenuItem.DataMember = "Menu_Item";
                dgvMenuItem.ReadOnly = true;

                dgvMenuItem.Columns[0].HeaderText = "ID";
                dgvMenuItem.Columns[1].HeaderText = "Menu Item Name";
                dgvMenuItem.Columns[1].Width = 150;
                dgvMenuItem.Columns[2].HeaderText = "Discount";
                dgvMenuItem.Columns[3].HeaderText = "Price (Per Unit)";
                dgvMenuItem.Columns[3].Width = 150;


                MyConn.Close();

            }
            catch (Exception myErr)
            {
                MessageBox.Show("Error: " + myErr.Message);
            }
        }

        private void POSMenuItem_Load(object sender, EventArgs e)
        {

        }

        private void txtResult_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection newConn = new SqlConnection(Globals.MyConnString))
            {
                if (cbxSearchCriteria.Text == "Menu Item Name:")
                {
                    SqlCommand myCmd = new SqlCommand("select Menu_Item.Menu_Item_ID, Menu_Item_Description ,  Menu_Item_Price_Amount from Menu_Item_Price inner join Menu_Item ON Menu_Item.Menu_Item_ID = Menu_Item_Price.Menu_Item_ID where Menu_Item.Menu_Item_Description like '%" + txtResult.Text + "%'", newConn);
                    try
                    {
                        newConn.Open();

                        SqlDataReader reader = myCmd.ExecuteReader();

                        while (reader.Read())
                        {
                            txtSalesDiscount.Text = "0";
                            txtSalesDescription.Text = (reader["Menu_Item_Description"].ToString());
                            txtSalesDescription.Enabled = false;
                            int InitialQty = 1;
                            txtSalesQuantity.Text = InitialQty.ToString();
                            txtSalesPrice.Text = (reader["Menu_Item_Price_Amount"].ToString());
                            txtSalesPrice.Enabled = false;
                        }
                        reader.Close();
                        newConn.Close();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    newConn.Close();
                }
                else if (cbxSearchCriteria.Text == " " || cbxSearchCriteria.Text == null || cbxSearchCriteria.Text == "Select Search Criteria:")
                {
                    MessageBox.Show("Please select a criteria to search for the item that the customer wishes to purchase.", "Select Search Criteria", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("The item you searched for is not registered /n Please ensure you entered the correct details.", "No Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgvMenuItem.SelectedRows.Count > 0)
            {
                string MenuName = dgvMenuItem.SelectedRows[0].Cells[1].Value + string.Empty;
                string MenuPrice = dgvMenuItem.SelectedRows[0].Cells[2].Value + string.Empty;
                string MenuDiscount = dgvMenuItem.SelectedRows[0].Cells[3].Value + string.Empty;

                txtSalesDescription.Text = MenuName;
                txtSalesPrice.Text = MenuPrice;
                txtSalesDiscount.Text = MenuDiscount;
            }
        }

        private void btnAddInventoryItem_Click(object sender, EventArgs e)
        {
            POSForm frmSale = new POSForm("", "", 1, null, null, null, null, txtSalesDescription.Text, txtSalesQuantity.Text, txtSalesPrice.Text, txtSalesDiscount.Text);
            frmSale.Show();
        }
    }
}

