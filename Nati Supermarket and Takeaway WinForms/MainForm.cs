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
    public partial class MainForm : Form

    {
        string Emp_Username;
        string Emp_Password;
        int Emp_ID;
        SqlConnection MyConn = new SqlConnection(Globals.MyConnString);

        public MainForm(string Emp_username, string Emp_password, int Emp_id)
        {
            InitializeComponent();
            Emp_Username = Emp_username;
            Emp_Password = Emp_password;
            Emp_ID = Emp_id;
        }

        private void SystemToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void LogoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void ProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void inventoryToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void AdminToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CashUpForm CashOnHand = new CashUpForm();
            CashOnHand.Show();
        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            //.SupplierForm ViewSupplier = new SupplierForm();
            //ViewSupplier.ShowDialog();
            this.Close();
        }

        private void checkOutSupplyOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void InventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void checkInEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void checkOutEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void LockSystemToolStripMenuItem1(object sender, EventArgs e)
        {
            this.Hide();
            LockForm lockFrm = new LockForm();
            lockFrm.ShowDialog();
            this.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblUser.Text = "Login user : " + Emp_Username.ToUpper();
        }

        private void backUpDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to backup the Database?", "Backup Database", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                //backup database code..

            }
            else return;

        }

        private void restoreDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to restore the Database?", "Restore Database", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                //Restore database code..

            }
            else return;
        }

        private void ToolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            var dateAndTime = DateTime.Now;
            var date = dateAndTime.Date;
            ToolStripLabel1.Text = date.ToString("dd/MM/yyyy");
        }

        private void RecieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void addMenuItemCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void addMenuItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuItemForm frmMenuItem = new MenuItemForm();
            frmMenuItem.Show();
        }

        private void placeSupplyOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void InventoryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EmployeeForm frmEmployee = new EmployeeForm();
            frmEmployee.ShowDialog();
        }

        private void checkInEmployeeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            CheckInEmployeeForm empCheckIn = new CheckInEmployeeForm("In");
            empCheckIn.ShowDialog();
            this.Close();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {

        }

        private void btnDailySales_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeForm EmpForm = new EmployeeForm();
            EmpForm.ShowDialog();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            this.Hide();
            CashUpForm frmCU = new CashUpForm();
            frmCU.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Form ChildForm in this.MdiChildren)
                ChildForm.Close();

            if (MessageBox.Show("Are you sure you want to lock the system? \nThe system will lock for a period of 15 minutes before it returns to the login form", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Hide();
                LockForm frmLock = new LockForm();
                frmLock.ShowDialog();
                this.Close();

            }
            else
                return;
          
        }

        private void btnCheckInEmployee_Click(object sender, EventArgs e)
        {
            this.Hide();
            CheckInEmployeeForm InOut = new CheckInEmployeeForm("In");
            InOut.ShowDialog();
            this.Close();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCheckOutEmployee_Click(object sender, EventArgs e)
        {
            this.Hide();
            CheckInEmployeeForm InOut = new CheckInEmployeeForm("Out");
            InOut.ShowDialog();
            this.Close();
        }

        private void btnRestoreSystem_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //RestoreForm frmRestore = new RestoreForm();
            //frmRestore.ShowDialog();
            //this.Close();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            this.Hide();
            //SupplierForm suppFrm = new SupplierForm();
            //suppFrm.ShowDialog();
            this.Close();
        }

        private void btnMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuItemForm menuFrm = new MenuItemForm();
            menuFrm.ShowDialog();
            this.Close();
        }

        private void btnStocksReport_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //InventoryItemForm invForm = new InventoryItemForm();
            //invForm.ShowDialog();
            //this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            foreach (Form ChildForm in this.MdiChildren)
                ChildForm.Close();

            if (MessageBox.Show("Are you sure you want to exit?", "Exit System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                Application.Exit();
            else
                return;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Form ChildForm in this.MdiChildren)
                ChildForm.Close();

            if (MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Hide();
                LoginForm lginForm = new LoginForm();
                lginForm.ShowDialog();
                this.Close();

            }
            else
                return;
        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            this.Hide();
            POSForm frmPOS = new POSForm(Emp_Username,Emp_Password,Emp_ID,"","","","","","","","");
            frmPOS.ShowDialog();
            this.Close();
        }
    }
}
