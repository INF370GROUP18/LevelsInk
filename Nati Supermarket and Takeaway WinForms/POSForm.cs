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

    public partial class POSForm : Form
    {
        string Emp_Name;
        string Emp_Surname;
      //  int Emp_ID;
        public POSForm(string Emp_name, string Emp_surname, int Emp_id, string InvName, string InvQuantity, string InvPrice, string InvDiscount, string menuName, string menuQuantity, string menuPrice, string menuDiscount)
        {
            InitializeComponent();
            Emp_Name = Emp_name;
            Emp_Surname = Emp_surname;
           // Emp_id = Emp_id;

            dgvMenuItem.Rows.Add(menuName, menuQuantity, menuPrice, menuDiscount);
            dgvSaleLine.Rows.Add(InvName, InvQuantity, InvPrice, InvDiscount);

        }
       // double subTotalValue = 0 ;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnLineUp_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReceiveCashForm frmCash = new ReceiveCashForm();
            frmCash.ShowDialog();
        }

        private void POSForm_Load(object sender, EventArgs e)
        {
            SqlConnection myConn = new SqlConnection(Globals.MyConnString);
            myConn.Open();
            string query = "SELECT MAX(Sales_ID) FROM Sales";
            SqlCommand comSelect = new SqlCommand(query, myConn);
            int SaleID = (int)comSelect.ExecuteScalar() + 1;
            txtSalesID.Text = SaleID.ToString();
            myConn.Close();

            txtEmployeeName.Text = Emp_Name + " " + Emp_Surname;

           

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
           
          
}

private void txtResult_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void lblVat_Click(object sender, EventArgs e)
        {

        }

        private void btnVoidSale_Click(object sender, EventArgs e)
        {
            dgvSaleLine.Rows.Clear();
        }

        private void btnVoidLine_Click(object sender, EventArgs e)
        {

            dgvSaleLine.Rows.RemoveAt(dgvSaleLine.SelectedRows.Count);
            dgvMenuItem.Rows.RemoveAt(dgvMenuItem.SelectedRows.Count);

        }

        private void viewSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            
            SalesHistoryForm frmSaleHistory = new SalesHistoryForm();
            frmSaleHistory.ShowDialog();
        }

        private void makeSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void makeSaleToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //if (dgvSaleLine.Rows != null || txtSalesDescription.Text != "" || txtSalesDiscount.Text != "" || txtSalesPrice.Text != ""|| txtSalesQuantity.Text != "")
            //{
            //    if (MessageBox.Show("Are you sure you want to view sales, you will cause the current sale to be void", "Void Current Sale", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)

            //    {
            //        this.Hide();
            //        SalesHistoryForm frmSaleHistory = new SalesHistoryForm();
            //        frmSaleHistory.ShowDialog();
            //    }
            //    else
            //        return;
            //}
            //else
            //{
            //    this.Hide();
            //    SalesHistoryForm frmSaleHistory = new SalesHistoryForm();
            //    frmSaleHistory.ShowDialog();
            //}
           
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void txtSalesID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void gbxProductInformation_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSubmit_Click_1(object sender, EventArgs e)
        {
            //using (SqlConnection newConn = new SqlConnection(Globals.MyConnString))
            //{
            //    if (cbxSearchCriteria.Text == "Inventory Item ID:")
            //    {
            //        SqlCommand myCmd = new SqlCommand("select Inventory_Item.Inventory_Item_ID, Inventory_Item_Description,  Inventory_Price_Amount from Inventory_Price inner join Inventory_Item ON Inventory_Item.Inventory_Item_ID = Inventory_Price.Inventory_Item_ID where Inventory_Item.Inventory_Item_ID like '%" + txtResult.Text + "%'", newConn);


            //        try
            //        {
            //            newConn.Open();

            //            SqlDataReader reader = myCmd.ExecuteReader();

            //            while (reader.Read())
            //            {
            //                txtSalesDiscount.Text = "0";
            //                txtSalesDescription.Text = (reader["Inventory_Item_Description"].ToString());
            //                txtSalesDescription.Enabled = false;
            //                int InitialQty = 1;
            //                txtSalesQuantity.Text = InitialQty.ToString();
            //                txtSalesPrice.Text = (reader["Inventory_Price_Amount"].ToString());
            //                txtSalesPrice.Enabled = false;
            //            }
            //            reader.Close();
            //            newConn.Close();
            //        }

            //        catch (Exception)
            //        {

            //            throw;
            //        }
            //        newConn.Close();
            //    }
            //    else if (cbxSearchCriteria.Text == "Barcode Number:")
            //    {
            //        SqlCommand myCmd = new SqlCommand("select Inventory_Item.Inventory_Item_ID, Inventory_Item_Description,  Inventory_Price_Amount from Inventory_Price inner join Inventory_Item ON Inventory_Item.Inventory_Item_ID = Inventory_Price.Inventory_Item_ID where Inventory_Item.Inventory_Item_Barcode like '%" + txtResult.Text + "%'", newConn);
            //        try
            //        {
            //            newConn.Open();

            //            SqlDataReader reader = myCmd.ExecuteReader();

            //            while (reader.Read())
            //            {
            //                txtSalesDiscount.Text = "0";
            //                txtSalesDescription.Text = (reader["Inventory_Item_Description"].ToString());
            //                txtSalesDescription.Enabled = false;
            //                int InitialQty = 1;
            //                txtSalesQuantity.Text = InitialQty.ToString();
            //                txtSalesPrice.Text = (reader["Inventory_Price_Amount"].ToString());
            //                txtSalesPrice.Enabled = false;
            //            }
            //            reader.Close();
            //            newConn.Close();
            //        }

            //        catch (Exception)
            //        {

            //            throw;
            //        }
            //        newConn.Close();
            //    }
            //    else if (cbxSearchCriteria.Text == "Inventory Item Name:")
            //    {
            //        SqlCommand myCmd = new SqlCommand("select Inventory_Item.Inventory_Item_ID, Inventory_Item_Description,  Inventory_Price_Amount from Inventory_Price inner join Inventory_Item ON Inventory_Item.Inventory_Item_ID = Inventory_Price.Inventory_Item_ID where Inventory_Item.Inventory_Item_Description like '%" + txtResult.Text + "%'", newConn);
            //        try
            //        {
            //            newConn.Open();

            //            SqlDataReader reader = myCmd.ExecuteReader();

            //            while (reader.Read())
            //            {
            //                txtSalesDiscount.Text = "0";
            //                txtSalesDescription.Text = (reader["Inventory_Item_Description"].ToString());
            //                txtSalesDescription.Enabled = false;
            //                int InitialQty = 1;
            //                txtSalesQuantity.Text = InitialQty.ToString();
            //                txtSalesPrice.Text = (reader["Inventory_Price_Amount"].ToString());
            //                txtSalesPrice.Enabled = false;
            //            }
            //            reader.Close();
            //            newConn.Close();
            //        }

            //        catch (Exception)
            //        {

            //            throw;
            //        }
            //        newConn.Close();
            //    }
            //    else if (cbxSearchCriteria.Text == "Menu Item ID:")
            //    {
            //        SqlCommand myCmd = new SqlCommand("select Menu_Item.Menu_Item_ID, Menu_Item_Description ,  Menu_Item_Price_Amount from Menu_Item_Price inner join Menu_Item ON Menu_Item.Menu_Item_ID = Menu_Item_Price.Menu_Item_ID where Menu_Item.Menu_Item_ID like '%" + txtResult.Text + "%'", newConn);
            //        try
            //        {
            //            newConn.Open();

            //            SqlDataReader reader = myCmd.ExecuteReader();

            //            while (reader.Read())
            //            {
            //                txtSalesDiscount.Text = "0";
            //                txtSalesDescription.Text = (reader["Menu_Item_Description"].ToString());
            //                txtSalesDescription.Enabled = false;
            //                int InitialQty = 1;
            //                txtSalesQuantity.Text = InitialQty.ToString();
            //                txtSalesPrice.Text = (reader["Menu_Item_Price_Amount"].ToString());
            //                txtSalesPrice.Enabled = false;
            //            }
            //            reader.Close();
            //            newConn.Close();
            //        }

            //        catch (Exception)
            //        {

            //            throw;
            //        }
            //        newConn.Close();
            //    }
            //    else if (cbxSearchCriteria.Text == "Menu Item Name:")
            //    {
            //        SqlCommand myCmd = new SqlCommand("select Menu_Item.Menu_Item_ID, Menu_Item_Description ,  Menu_Item_Price_Amount from Menu_Item_Price inner join Menu_Item ON Menu_Item.Menu_Item_ID = Menu_Item_Price.Menu_Item_ID where Menu_Item.Menu_Item_Description like '%" + txtResult.Text + "%'", newConn);
            //        try
            //        {
            //            newConn.Open();

            //            SqlDataReader reader = myCmd.ExecuteReader();

            //            while (reader.Read())
            //            {
            //                txtSalesDiscount.Text = "0";
            //                txtSalesDescription.Text = (reader["Menu_Item_Description"].ToString());
            //                txtSalesDescription.Enabled = false;
            //                int InitialQty = 1;
            //                txtSalesQuantity.Text = InitialQty.ToString();
            //                txtSalesPrice.Text = (reader["Menu_Item_Price_Amount"].ToString());
            //                txtSalesPrice.Enabled = false;
            //            }
            //            reader.Close();
            //            newConn.Close();
            //        }
            //        catch (Exception)
            //        {

            //            throw;
            //        }
            //        newConn.Close();
            //    }
            //    else if (cbxSearchCriteria.Text == " " || cbxSearchCriteria.Text == null || cbxSearchCriteria.Text == "Select Search Criteria:")
            //    {
            //        MessageBox.Show("Please select a criteria to search for the item that the customer wishes to purchase.", "Select Search Criteria", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //    else
            //    {
            //        MessageBox.Show("The item you searched for is not registered /n Please ensure you entered the correct details.", "No Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    }
            //}

        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            //int Price = Convert.ToInt32(txtSalesPrice.Text);
            //int Quantity = Convert.ToInt32(txtSalesQuantity.Text);
            //decimal DiscountPerc = Convert.ToInt32(txtSalesDiscount.Text) / 100;
            //decimal Discount = DiscountPerc * Price;
            //decimal Amount = (Price * Quantity) + Discount;
            //dgvSaleLine.Rows.Add(txtSalesDescription.Text, txtSalesQuantity.Text, txtSalesPrice.Text, txtSalesDiscount.Text, Amount);

            //for (int i = 0; i < dgvSaleLine.RowCount; i++)
            //{
            //    subTotalValue += Convert.ToDouble(dgvSaleLine.Rows[i].Cells[4].Value);
            //}

            //lblSubTotal.Text = subTotalValue.ToString();
            //double vat = 0.15;
            //double vatCharge = subTotalValue * vat;
            //double saleTotal = 0;
            //saleTotal = subTotalValue + vatCharge;
            //lblVat.Text = Convert.ToString(vatCharge);
            //lblTotal.Text = Convert.ToString(saleTotal);


            //lblSubTotal.Refresh();
            //lblTotal.Refresh();
            //lblVat.Refresh();
            ////lblSubTotal.Text = dgvSaleLine.Rows.Cast<DataGridViewRow>().AsEnumerable().Sum(x => double.Parse(x.Cells[1].Value.ToString())).ToString();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //txtSalesDescription.Text = "";
            //txtSalesDiscount.Text = "";
            //txtSalesPrice.Text = "";
            //txtSalesQuantity.Text = "";
        }

        private void dgvSaleLine_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gbxTransactionInformation_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void lblSubTotal_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void lblVat_Click_1(object sender, EventArgs e)
        {

        }

        private void lblTotal_Click_1(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void txtEmployeeName_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblEmployeeName_Click(object sender, EventArgs e)
        {

        }

        private void txtEmployeeID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txtResult_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void cbxSearchCriteria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gbxProductInformation_Enter_1(object sender, EventArgs e)
        {

        }

        private void txtSalesDiscount_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSalesPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSalesQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSalesDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtSalesID_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnAddInventory_Click(object sender, EventArgs e)
        {
            POSInventoryForm frmAddInv = new POSInventoryForm();
            frmAddInv.Show();
        }

        private void btnAddMenu_Click(object sender, EventArgs e)
        {
            POSMenuItem frmAddMenu = new POSMenuItem();
            frmAddMenu.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            LockForm frmLock = new LockForm();
            frmLock.Show();

        }
    }
}
    

