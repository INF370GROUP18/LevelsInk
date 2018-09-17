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
using System.Data.Entity;

namespace Nati_Supermarket_and_Takeaway_WinForms
{
    public partial class POSInventoryForm : Form
    {
        //SqlConnection MyConn = new SqlConnection(Globals.MyConnString);
        //SqlCommand myCmd = new SqlCommand();
        //SqlDataAdapter myAdapter = new SqlDataAdapter();
        //DataSet InventoryDS = new DataSet();
        Inventory_Item Invmodel = new Inventory_Item();
        Inventory_Price Pricemodel = new Inventory_Price();
        Inventory_Item_Type TypeModel = new Inventory_Item_Type();
        public POSInventoryForm()
        {
            InitializeComponent();
        
            #region Connection string
            //string myString = "SELECT Inventory_Item.Inventory_Item_ID, Inventory_Item_Description, Inventory_Item_Discount,  Inventory_Price_Amount from Inventory_Price inner join Inventory_Item ON Inventory_Item.Inventory_Item_ID = Inventory_Price.Inventory_Item_ID ";
            //try
            //{
            //    myCmd.Connection = MyConn;
            //    myCmd.CommandText = myString;

            //    MyConn.Open();
            //    myAdapter.SelectCommand = myCmd;

            //    myAdapter.Fill(InventoryDS, "Inventory_Item");
            //    dgvInventoryItem.DataSource = InventoryDS;
            //    dgvInventoryItem.DataMember = "Inventory_Item";
            //    dgvInventoryItem.ReadOnly = true;

            //    dgvInventoryItem.Columns[0].HeaderText = "ID";
            //    dgvInventoryItem.Columns[1].HeaderText = "Inventory Item Name";
            //    dgvInventoryItem.Columns[1].Width = 150;
            //    dgvInventoryItem.Columns[2].HeaderText = "Discount";
            //    dgvInventoryItem.Columns[3].HeaderText = "Price (Per Unit)";
            //    dgvInventoryItem.Columns[3].Width = 150;

                
            //    MyConn.Close();

            //}
            //catch (Exception myErr)
            //{
            //    MessageBox.Show("Error: " + myErr.Message);
            //}
            //SqlConnection myConn = new SqlConnection(Globals.MyConnString);
            //SqlCommand myCmd = new SqlCommand();
            //SqlDataAdapter myAdapter = new SqlDataAdapter();
            //DataSet InventoryDS = new DataSet();

            //    string myString = "SELECT Inventory_Item.Inventory_Item_ID, Inventory_Item_Description, Inventory_Item_Discount,  Inventory_Price_Amount from Inventory_Price inner join Inventory_Item ON Inventory_Item.Inventory_Item_ID = Inventory_Price.Inventory_Item_ID ";
            //try
            //{
            //    myCmd.Connection = myConn;
            //    myCmd.CommandText = myString;
            //    DataTable dt = new DataTable();
            //    myConn.Open();
            //    myAdapter.SelectCommand = myCmd;


            //    myAdapter.Fill(InventoryDS, "Inventory_Item, Inventory_Item_Price");

            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {

            //        dataGridView.Rows.Add();
            //        dataGridView.Rows[i].Cells[1].Value =.Rows[i].ItemArray[0];
            //        dataGridView.Rows[i].Cells[2].Value = dt.Rows[i].ItemArray[1];
            //        dataGridView.Rows[i].Cells[3].Value = dt.Rows[i].ItemArray[2];
            //        dataGridView.Rows[i].Cells[4].Value = dt.Rows[i].ItemArray[3];
            //        dataGridView.Rows[i].Cells[5].Value = dt.Rows[i].ItemArray[4];
            //        dataGridView.Rows[i].Cells[6].Value = dt.Rows[i].ItemArray[5];

            //    }
            //    dgvInventoryItem.AutoGenerateColumns = false;
            //    dgvInventoryItem.DataSource = InventoryDS;
            //    dgvInventoryItem.DataMember = "Inventory_Item, Inventory_Item_Price";
            //    dgvInventoryItem.ReadOnly = true;

            //    myConn.Close();

            //}
            //catch (Exception)
            //{

            //    throw;
            //}
            #endregion
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnFinaliseSale_Click(object sender, EventArgs e)
        {
            //POSForm frmSale = new POSForm("","",1, txtSalesDescription.Text, txtSalesQuantity.Text, txtSalesPrice.Text,txtSalesDiscount.Text,"","","","");
            //frmSale.Show();
            #region Saving to database
            Invmodel.Inventory_Item_Name = txtSalesDescription.Text.Trim();
            //Invmodel.Inventory_Item_Barcode = txtBarcode.text.trim();
            Invmodel.Inventory_Item_Quantity = Convert.ToInt32(txtSalesQuantity.Text.Trim());
            Pricemodel.Inventory_Price1 = Convert.ToDecimal(txtSalesPrice.Text.Trim());
            using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
            {
                db.Inventory_Item.Add(Invmodel);
                db.Inventory_Price.Add(Pricemodel);
                db.Inventory_Item_Type.Add(TypeModel);
                db.SaveChanges();
            }
        }
            #endregion
            void PopulateDatagridviewData()
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                var dgvQuery = (from Items in db.Inventory_Item
                                join Price in db.Inventory_Price
                                on Items.Inventory_Item_ID equals Price.Inventory_Item_ID
                                join Type in db.Inventory_Item_Type 
                                on Items.Inventory_Item_Type_ID equals Type.Inventory_Item_Type_ID
                                //where ed.Employee_Details_Name.Contains(txtESearch.Text)
                                select new { Items.Inventory_Item_ID, Items.Inventory_Item_Barcode,Items.Inventory_Item_Name, Price.Inventory_Price1, Type.Inv_Item_Type_Description }
                               ).ToList();

                //dgvInventoryItem.DataSource = db.Inventory_Item.ToList<Inventory_Item>();
                //dgvInventoryItem.DataSource = db.Inventory_Price.ToList<Inventory_Price>();
                //dgvInventoryItem.DataSource = db.Inventory_Item_Type.ToList<Inventory_Item_Type>();
                dgvInventoryItem.Columns.Clear();
                dgvInventoryItem.DataSource = dgvQuery;
                dgvInventoryItem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                dgvInventoryItem.Columns[0].HeaderText = "Inventory ID";
                dgvInventoryItem.Columns[1].HeaderText = "Inventory Barcode";
                dgvInventoryItem.Columns[1].Width = 100;
                dgvInventoryItem.Columns[2].HeaderText = "Inventory Name";
                dgvInventoryItem.Columns[2].Width = 100;
                dgvInventoryItem.Columns[3].HeaderText = "Discount";
                dgvInventoryItem.Columns[4].HeaderText = "Price (Per Unit)";
                dgvInventoryItem.Columns[4].Width = 100;
                dgvInventoryItem.Columns[5].HeaderText = "Type";
                
            }
            }
        
        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvSaleLine_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           


        }

        private void POSInventoryForm_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateDatagridviewData();
            }
                catch (Exception)
                {

                    return;
                }
            
        }

        private void txtResult_TextChanged(object sender, EventArgs e)
        {
            //using (SqlConnection newConn = new SqlConnection(Globals.MyConnString))
            //{
            //    if (cbxSearchCriteria.Text == "Inventory Item ID:")
            //    {
            //        newConn.Open();

            //        SqlCommand myCmd = new SqlCommand("select Inventory_Item.Inventory_Item_ID, Inventory_Item_Description,  Inventory_Price_Amount from Inventory_Price inner join Inventory_Item ON Inventory_Item.Inventory_Item_ID = Inventory_Price.Inventory_Item_ID where Inventory_Item.Inventory_Item_ID like '%" + txtResult.Text + "%'", newConn);
            //        myAdapter.SelectCommand = myCmd;
            //        myAdapter.Fill(InventoryDS);
            //        dgvInventoryItem.DataSource = InventoryDS;
            //        dgvInventoryItem.Refresh();
            //        newConn.Close();
                    //try
                    //{
                    //    newConn.Open();

                    //    SqlDataReader reader = myCmd.ExecuteReader();

                    //    while (reader.Read())
                    //    {
                    //        txtSalesDiscount.Text = "0";
                    //        txtSalesDescription.Text = (reader["Inventory_Item_Description"].ToString());
                    //        txtSalesDescription.Enabled = false;
                    //        int InitialQty = 1;
                    //        txtSalesQuantity.Text = InitialQty.ToString();
                    //        txtSalesPrice.Text = (reader["Inventory_Price_Amount"].ToString());
                    //        txtSalesPrice.Enabled = false;
                    //    }
                    //    reader.Close();
                    //    newConn.Close();
                    //}

                    //catch (Exception)
                    //{

                    //    throw;
                    //}
                    //newConn.Close();
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
            //}
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            #region Manuel code
            //if(dgvInventoryItem.SelectedRows.Count > 0)
            //{
            //    string InventoryName = dgvInventoryItem.SelectedRows[0].Cells[1].Value + string.Empty;
            //    string InventoryPrice = dgvInventoryItem.SelectedRows[0].Cells[2].Value + string.Empty;
            //    string InventoryDiscount = dgvInventoryItem.SelectedRows[0].Cells[3].Value + string.Empty;

            //    txtSalesDescription.Text = InventoryName;
            //    txtSalesPrice.Text = InventoryPrice;
            //    txtSalesDiscount.Text = InventoryDiscount;
            //}
            #endregion 
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
          
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
