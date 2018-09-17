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
    public partial class MenuItemForm : Form
    {
        SqlConnection MyConn = new SqlConnection(Globals.MyConnString);
        public MenuItemForm()
        {
            InitializeComponent();
        }

        private void MenuItem_Load(object sender, EventArgs e)
        {
            try
            {
                string query = "Select Menu_Item.Menu_Item_ID, Menu_Item.Menu_Item_Name, Menu_Item.Menu_Item_Description,Menu_Item.Meni_Item_Price, Menu_Item_Category.Menu_Item_Category_Description FROM Menu_Item INNER JOIN Menu_Item_Category ON Menu_Item.Menu_Item_Category_ID = Menu_Item_Category.Menu_Item_Category_ID";
                MyConn.Open();

                SqlCommand cmd = new SqlCommand(query, MyConn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                SqlDataReader myReader = cmd.ExecuteReader();

                ListViewItem x = null;
                lstMenuItem.Items.Clear();

                while (myReader.Read() == true)
                {
                    x = new ListViewItem(myReader["Menu_Item_ID"].ToString());
                    x.SubItems.Add(myReader["Menu_Item_Name"].ToString());
                    x.SubItems.Add(myReader["Menu_Item_Description"].ToString());
                    x.SubItems.Add(myReader["Meni_Item_Price"].ToString());
                    x.SubItems.Add(myReader["Menu_Item_Category_Description"].ToString());
                   

                    lstMenuItem.Items.Add(x);
                    MyConn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddEditMenuItemForm frmMenu = new AddEditMenuItemForm("Add");
            frmMenu.ShowDialog();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm frmMain = new MainForm("","",3);
            frmMain.ShowDialog();
            this.Close();
        }

        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddEditMenuItemForm editMenu = new AddEditMenuItemForm("Edit");
            editMenu.ShowDialog();
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
