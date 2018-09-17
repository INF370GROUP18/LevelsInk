using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nati_Supermarket_and_Takeaway_WinForms
{
    public partial class PerformStockTakeForm : Form
    {
        public PerformStockTakeForm()
        {
            InitializeComponent();
        }

        private void PerformStockTakeForm_Load(object sender, EventArgs e)
        {
            PopulateInvDGV();
        }
        void PopulateInvDGV()
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    var dgvQuery = (from Items in db.Inventory_Item
                                    select new { Items.Inventory_Item_ID, Items.Inventory_Item_Name, Items.Inventory_Item_Quantity }
                                   ).ToList();

                    dgvInventoryStockTake.Columns.Clear();
                    dgvInventoryStockTake.DataSource = dgvQuery;
                    dgvInventoryStockTake.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    dgvInventoryStockTake.Columns[0].HeaderText = "Inventory ID";
                    dgvInventoryStockTake.Columns[1].HeaderText = "Inventory Name";
                    dgvInventoryStockTake.Columns[1].Width = 100;
                    dgvInventoryStockTake.Columns[2].HeaderText = "Quantity";
                    dgvInventoryStockTake.Columns[2].Width = 100;

                }
            }
            catch (Exception myErr)
            {
                MessageBox.Show("Error: " + myErr.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    var dgvQuery = (from Items in db.Inventory_Item
                                    where Items.Inventory_Item_Name.Contains(txtSearchInventoryItem.Text)
                                    select new { Items.Inventory_Item_ID, Items.Inventory_Item_Name, Items.Inventory_Item_Quantity }
                                   ).ToList();

                    dgvInventoryStockTake.Columns.Clear();
                    dgvInventoryStockTake.DataSource = dgvQuery;
                    dgvInventoryStockTake.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    dgvInventoryStockTake.Columns[0].HeaderText = "Inventory ID";
                    dgvInventoryStockTake.Columns[1].HeaderText = "Inventory Name";
                    dgvInventoryStockTake.Columns[1].Width = 100;
                    dgvInventoryStockTake.Columns[2].HeaderText = "Quantity";
                    dgvInventoryStockTake.Columns[2].Width = 100;

                }
            }
            catch (Exception myErr)
            {
                MessageBox.Show("Error: " + myErr.Message);
            }
        }

        private void txtSearchInventoryItem_TextChanged(object sender, EventArgs e)
        {
            PopulateInvDGV();
        }

        private void btnUpdateQuantity_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Are you sure you want to update this quantity?","Confirmation",MessageBoxButtons.YesNo) == "Yes"
            using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
            {
                try
                {
                    int id =Convert.ToInt32(dgvInventoryStockTake.SelectedRows[0]);
                    var UpdateST = (from item in db.Inventory_Item
                                  where id == item.Inventory_Item_ID
                                  select item).First();
                    UpdateST.Inventory_Item_Quantity = Convert.ToInt32(nudQuantityST.Value);       
                    db.SaveChanges();
                    PopulateInvDGV();
                    this.Close();
                }
                catch (Exception ss)
                {
                    MessageBox.Show(ss.ToString());
                }
            }
                
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
