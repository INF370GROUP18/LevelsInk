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
    public partial class AddEditMenuItemForm : Form
    {
        string formOption = "";

        SqlConnection MyConn = new SqlConnection(Globals.MyConnString);

        public AddEditMenuItemForm(string option)
        {
            string formOption = option;

            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //string query1 = "Select Menu_Item_Category_ID";

            try
            {
                string query = "INSERT INTO Menu_Item_Category VALUES(@Category)";


                string myQuery = "INSERT INTO Menu_Item VALUES(@Name, @Description, @Price)";
                SqlCommand myCmd = new SqlCommand(query, MyConn);
                myCmd.Parameters.Add(new SqlParameter("@Category", txtCategory.Text));

                SqlCommand Cmd = new SqlCommand(myQuery, MyConn);
                myCmd.Parameters.Add(new SqlParameter("@Name", txtName.Text));
                myCmd.Parameters.Add(new SqlParameter("@Description", txtDescription.Text));
                myCmd.Parameters.Add(new SqlParameter("@Price", txtUnitPrice.Text));
                myCmd.Parameters.Add(new SqlParameter("@CategoryID", +1));


                {
                    MyConn.Open();
                    SqlDataReader dr = myCmd.ExecuteReader();
                    SqlDataReader dr2 = Cmd.ExecuteReader();
                    MessageBox.Show("The new menu item has been successfully added.");

                    while (dr.Read() && dr2.Read())
                    {
                       
                    }
                }
            }
            catch (Exception myErr)
            {

                MessageBox.Show("Error: " + myErr.Message);
            }
        }

        private void AddEditMenuItemForm_Load(object sender, EventArgs e)
        {
            if (formOption == "Add")
                lblTitle.Text = "Add new Menu Item";
            else if (formOption == "Edit")
                lblTitle.Text = "Edit existing Menu Item";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuItemForm menufrm = new MenuItemForm();
            menufrm.ShowDialog();
            this.Close();
        }
    }
}



