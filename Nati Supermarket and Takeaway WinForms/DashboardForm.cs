using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Drawing.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Security.Cryptography;
using CrystalDecisions.CrystalReports;


namespace Nati_Supermarket_and_Takeaway_WinForms
{
    public partial class DashboardForm : Form
    {
        #region Declare Global Variables
        MailMessage message;
        SmtpClient smtp;
        int EmpID;
        string EmpName;
        byte[] EmpPassword;
        byte[] EmpPicture;
        int userAccess;
        double subTotal = 0;
        double VAT = 0.15;
        double newVAT = 0;
        double Total = 0;
        private FilterInfoCollection webcam;
        private VideoCaptureDevice cam;
        #endregion

        #region DashBoard Form
        public DashboardForm(int Employee_ID, string Employee_Name, byte[] Employee_Password, byte[] Employee_Picture, int EmployeeAccess)
        {
            InitializeComponent();
            EmpID = Employee_ID;
            EmpName = Employee_Name;
            EmpPassword = Employee_Password;
            EmpPicture = Employee_Picture;
            userAccess = EmployeeAccess;
        }
        #endregion

        #region Employee Access
        void Access(int EmployeeAccess)
        {
            try
            {
                if (EmployeeAccess == 1)
                {
                    PopulateSaleHistoryDgv();
                    PopulateFoodSaleHistoryDgv();
                    PopulateInvStockTakeDGV();
                    PopulateInvDGV();
                    PopulateInvStockTakeDGV();
                    PopulateEmpDGV();
                    PopulateSupDgv();
                    PopulateMenItmDgv();
                    PopulateSupplyOrderDgv();
                    PopulateAuditLogDGV();
                    PopulateCheckInInvDGV();
                    PopulateCheckOutInvDGV();
                    PopulateInvStockTakeLineDGV();
                    PopulateWriteOffInvDGV();
                    PopulateWriteOffHistoryDGV();
                    LoadFoodOrderScreenDGV();
                  //  tabControl1.Controls.Remove(tabLock);
                    btnShift.Enabled = false;
                    DailySales();
                }
                else if (EmployeeAccess == 2)
                {
                    PopulateSaleHistoryDgv();
                    PopulateFoodSaleHistoryDgv();
                    PopulateInvPOSDGV();
                    tabControl1.Controls.Remove(tabInventoryItem);
                    tabControl1.Controls.Remove(tabMenuItem);
                    tabControl1.Controls.Remove(tabSupplier);
                    tabControl1.Controls.Remove(tabEmployee);
                   // tabControl1.Controls.Remove(tabLock);
                    tabControl1.Controls.Remove(tabCashUp);
                    tabControl1.Controls.Remove(tabReport);
                    tabControl1.Controls.Remove(tabFoodOrderScreen);
                    tabControl1.Controls.Remove(tabAuditLog);
                    btnLogout.Enabled = false;

                }
                else if (EmployeeAccess == 3)
                {
                    LoadFoodOrderScreenDGV();
                    tabControl1.Controls.Remove(tabInventoryItem);
                    tabControl1.Controls.Remove(tabMenuItem);
                    tabControl1.Controls.Remove(tabSupplier);
                    tabControl1.Controls.Remove(tabEmployee);
                   // tabControl1.Controls.Remove(tabLock);
                    tabControl1.Controls.Remove(tabCashUp);
                    tabControl1.Controls.Remove(tabReport);
                    tabControl1.Controls.Remove(tabSalesHistory);
                    tabControl1.Controls.Remove(tabPOS);
                    tabControl1.Controls.Remove(tabAuditLog);
                    btnShift.Enabled = false;
                }
            }
            catch
            {
                MessageBox.Show("The employee access could not be found");
            }

        }
        #endregion

                 #region Form Load
        private void DashboardForm_Load(object sender, EventArgs e)
        {
            Access(userAccess);
            //Display current logged in employee details

            txtEmployeeID.Text = EmpID.ToString();
            txtEmployeeNameProfile.Text = EmpName;

            //Display Standard Date and Time
            lblDatePOS.Text = DateTime.Today.ToShortDateString();
            lblTimePOS.Text = DateTime.Now.ToShortTimeString();

            // Convert byte array (in database) into picture box
            if (EmpPicture != null)
            {
                pbxEmployeePicture.Image = convertBytetoImage(EmpPicture);
                //Byte[] byteBLOBData = new Byte[0];
                //byteBLOBData = (Byte[])(EmpPicture);
                //System.IO.MemoryStream ms = new System.IO.MemoryStream(byteBLOBData);
                //pbxEmployeePicture.Image = System.Drawing.Image.FromStream(ms);
            }

            //Populate all the data grid views in the dashboard
            //PopulateFoodSaleHistoryDgv();
            ////PopulateInvStockTakeDGV();
            ////PopulateInvDGV();
            ////PopulateInvStockTakeDGV();
            ////PopulateEmpDGV();
            ////PopulateSupDgv();
            ////PopulateMenItmDgv();
            ////PopulateSupplyOrderDgv();
            ////PopulateAuditLogDGV();
            ////PopulateCheckInInvDGV();
            ////PopulateCheckOutInvDGV();
            ////PopulateInvStockTakeLineDGV();
            ////PopulateWriteOffInvDGV();
            ////PopulateWriteOffHistoryDGV();
            ////LoadFoodOrderScreenDGV();
            //PopulateSaleHistoryDgv();

            //Populate lbls and txts 

            lblSubTotal.Text = subTotal.ToString();
            lblVat.Text = newVAT.ToString();
            lblTotal.Text = Total.ToString();

            //Populate all comboboxes
            PopMenuCbx();
            PopSOInventoryCbx();
            PopEmpTypeCbx();
            POPInventoryTypeCbx();
            POPInventoryUnitCbx();
            PopEmpTitleCbx();
            PopSecurityQuestionCbx();

            //Nullify comboboxes
            cbxInventoryType.Text = "";
            cbxUnit.Text = "";

            //Get IDs
            SalesID();
            InventoryItemID();
            MenuItemID();
            SupplierID();
            EmployeeID();
            StockTakeID();
            WriteOffID();

            //Picture Load
            EmployeePicture();

            //LOad Graphs
            Populate_Graphs();
            //Load();

        }
        #endregion

        #region GetIDs
        void SalesID()
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    int getid = db.Database.SqlQuery<int>("Select Count(*) FROM Sales").FirstOrDefault<int>();
                    if (getid > 0)
                    {
                        txtSalesID.Text = Convert.ToString(db.Database.SqlQuery<int>("Select MAX(Sales_ID) FROM Sales").FirstOrDefault<int>()/* + 1*/);
                    }
                    if (getid == 0)
                    {
                        txtSalesID.Text = 1.ToString();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Could not find the Sales ID", "The ID couldn't be found");
            }

        }
        void StockTakeID()
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    int getid = db.Database.SqlQuery<int>("Select Count(*) FROM Stock_Take").FirstOrDefault<int>();
                    if (getid > 0)
                    {
                        txtStockTakeID.Text = Convert.ToString(db.Database.SqlQuery<int>("Select MAX(Stock_Take_ID) FROM Stock_Take").FirstOrDefault<int>());
                    }
                    if (getid == 0)
                    {
                        txtStockTakeID.Text = 1.ToString();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Could not find the Stock Take ID", "The ID couldn't be found");
            }

        }
        void InventoryItemID()
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    int getid = db.Database.SqlQuery<int>("Select Count(*) FROM Inventory_Item").FirstOrDefault<int>();
                    if (getid > 0)
                    {
                        txtInventoryID.Text = db.Database.SqlQuery<int>("Select MAX(Inventory_Item_ID) FROM Inventory_Item").FirstOrDefault<int>().ToString();
                    }
                    if (getid == 0)
                    {
                        txtInventoryID.Text = 1.ToString();
                    }
                }
            }
            catch
            {

                MessageBox.Show("Could not find the Inventory Item ID", "The ID couldn't be found");
            }

        }
        void MenuItemID()
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    int getid = db.Database.SqlQuery<int>("Select Count(*) FROM Menu_Item").FirstOrDefault<int>();
                    if (getid > 0)
                    {
                        txtMenuItemID.Text = db.Database.SqlQuery<int>("Select MAX(Menu_Item_ID) FROM Menu_Item").FirstOrDefault<int>().ToString();
                    }
                    if (getid == 0)
                    {
                        txtMenuItemID.Text = 1.ToString();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Could not find the Menu Item ID", "The ID couldn't be found");
            }

        }
        void SupplierID()
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {

                    int getid = db.Database.SqlQuery<int>("Select Count(*) FROM Supplier").FirstOrDefault<int>();
                    if (getid > 0)
                    {
                        txtSupplierID.Text = db.Database.SqlQuery<int>("Select MAX(Supplier_ID) FROM Supplier").FirstOrDefault<int>().ToString();
                    }
                    if (getid == 0)
                    {
                        txtSupplierID.Text = 1.ToString();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Could not find the Supplier ID", "The ID couldn't be found");
            }

        }
        void EmployeeID()
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {

                    int getid = db.Database.SqlQuery<int>("Select Count(*) FROM Employee").FirstOrDefault<int>();
                    if (getid > 0)
                    {
                        txtEmpID.Text = db.Database.SqlQuery<int>("Select MAX(Employee_ID) FROM Employee").FirstOrDefault<int>().ToString();
                    }
                    if (getid == 0)
                    {
                        txtEmpID.Text = 1.ToString();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Could not find the Employee ID", "The ID couldn't be found");
            }

        }
        void WriteOffID()
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {

                    int getid = db.Database.SqlQuery<int>("Select Count(*) FROM Inventory_Write_Off").FirstOrDefault<int>();
                    if (getid > 0)
                    {
                        txtWriteOffID.Text = db.Database.SqlQuery<int>("Select MAX(Write_Off_ID) FROM Inventory_Write_Off").FirstOrDefault<int>().ToString();
                    }
                    if (getid == 0)
                    {
                        txtWriteOffID.Text = 1.ToString();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Could not find the Write Off ID", "The ID couldn't be found");
            }

        }
        #endregion

        #region Population DataGridView
        void PopulateAuditLogDGV()
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    var dgvQuery = (from log in db.Audit_Log
                                    select new { log.Audit_Log_ID, log.Audit_Log_User, log.Audit_Log_Date, log.Audit_Log_Time, log.Audit_Log_Transaction_Type, log.Audit_Log_Critical_Information }
                                   ).ToList();

                    dgvAuditLog.DefaultCellStyle.ForeColor = Color.Black;
                    dgvAuditLog.Columns.Clear();
                    dgvAuditLog.DataSource = dgvQuery;
                    dgvAuditLog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    dgvAuditLog.Columns[0].HeaderText = "Audit Log ID";
                    dgvAuditLog.Columns[1].HeaderText = "User ";
                    dgvAuditLog.Columns[1].Width = 100;
                    dgvAuditLog.Columns[2].HeaderText = "Date";
                    dgvAuditLog.Columns[2].Width = 100;
                    dgvAuditLog.Columns[3].HeaderText = "Time";
                    dgvAuditLog.Columns[4].HeaderText = "Transaction Type";
                    dgvAuditLog.Columns[4].Width = 200;
                    dgvAuditLog.Columns[5].HeaderText = "Critical Information";
                    dgvAuditLog.Columns[5].Width = 300;
                }
            }
            catch (Exception myErr)
            {
                MessageBox.Show("Error: " + myErr.Message);
            }
        }
        void PopulateInvPOSDGV()
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    var dgvQuery = (from Items in db.Inventory_Item
                                    join Price in db.Inventory_Price
                                    on Items.Inventory_Item_ID equals Price.Inventory_Item_ID
                                    join Type in db.Inventory_Item_Type
                                    on Items.Inventory_Item_Type_ID equals Type.Inventory_Item_Type_ID
                                    select new { Items.Inventory_Item_ID, Items.Inventory_Item_Name, Type.Inv_Item_Type_Description, Price.Inventory_Price1, Items.Inventory_Item_Quantity }
                                   ).ToList();

                    dgvAddItem.DefaultCellStyle.ForeColor = Color.Black;
                    dgvAddItem.Columns.Clear();
                    dgvAddItem.DataSource = dgvQuery;
                    dgvAddItem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    dgvAddItem.Columns[0].HeaderText = "Inventory ID";
                    dgvAddItem.Columns[1].HeaderText = "Inventory Name";
                    dgvAddItem.Columns[1].Width = 100;
                    dgvAddItem.Columns[2].HeaderText = "Type";
                    dgvAddItem.Columns[2].Width = 100;
                    dgvAddItem.Columns[3].HeaderText = "Price (Per Unit)";
                    dgvAddItem.Columns[4].HeaderText = "Quantity";
                    dgvAddItem.Columns[4].Visible = false;
                }
            }
            catch (Exception myErr)
            {
                MessageBox.Show("Error: " + myErr.Message);
            }
        }
        void PopulatemenuPOSDGV()
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    var dgvQuery = (from Items in db.Menu_Item
                                    join Price in db.Menu_Item_Price
                                    on Items.Menu_Item_ID equals Price.Menu_Item_ID
                                    join Cat in db.Menu_Item_Category
                                    on Items.Menu_Item_Category_ID equals Cat.Menu_Item_Category_ID
                                    select new { Items.Menu_Item_ID, Items.Menu_Item_Name, Cat.Menu_Item_Category_Description, Price.Menu_Item_Price1 }
                                   ).ToList();

                    dgvAddItem.DefaultCellStyle.ForeColor = Color.Black;
                    dgvAddItem.Columns.Clear();
                    dgvAddItem.DataSource = dgvQuery;
                    dgvAddItem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    dgvAddItem.Columns[0].HeaderText = "Menu ID";
                    dgvAddItem.Columns[1].HeaderText = "Menu Name";
                    dgvAddItem.Columns[1].Width = 100;
                    dgvAddItem.Columns[3].HeaderText = "Price (Per Unit)";
                    dgvAddItem.Columns[3].Width = 100;
                    dgvAddItem.Columns[2].HeaderText = "Category";
                    dgvAddItem.Columns[2].Width = 100;

                }
            }
            catch (Exception myErr)
            {
                MessageBox.Show("Error: " + myErr.Message);
            }
        }
        void PopulateInvDGV()
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    {
                        var dgvInvQuery = (from Items in db.Inventory_Item
                                           join Price in db.Inventory_Price
                                        on Items.Inventory_Item_ID equals Price.Inventory_Item_ID
                                           join type in db.Inventory_Item_Type
                                           on Items.Inventory_Item_Type_ID equals type.Inventory_Item_Type_ID
                                           join um in db.Unit_Of_Measure
                                           on Items.Unit_Of_Measure_ID equals um.Unit_Of_Measure_ID
                                           select new { Items.Inventory_Item_ID, Items.Inventory_Item_Name, Items.Inventory_Item_Barcode, Items.Inventory_Item_Quantity, Price.Inventory_Price1, type.Inv_Item_Type_Description, um.Unit_Of_Measure_Description }
                                   ).ToList();

                        dgvInventoryItem.DefaultCellStyle.ForeColor = Color.Black;
                        dgvInventoryItem.Columns.Clear();
                        dgvInventoryItem.DataSource = dgvInvQuery;
                        dgvInventoryItem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                        dgvInventoryItem.Columns[0].HeaderText = "Inventory ID";
                        dgvInventoryItem.Columns[1].HeaderText = "Item Name";
                        dgvInventoryItem.Columns[1].Width = 100;
                        dgvInventoryItem.Columns[2].HeaderText = "Item Barcode";
                        dgvInventoryItem.Columns[2].Width = 100;
                        dgvInventoryItem.Columns[3].HeaderText = "Item Quantity";
                        dgvInventoryItem.Columns[3].Width = 100;
                        dgvInventoryItem.Columns[4].HeaderText = "Price (Per Unit)";
                        dgvInventoryItem.Columns[4].Width = 100;
                        dgvInventoryItem.Columns[5].HeaderText = "Item Type";
                        dgvInventoryItem.Columns[6].HeaderText = "Unit of Measure";
                    }
                }
            }
            catch (Exception myErr)
            {
                MessageBox.Show("Error: " + myErr.Message);
            }
        }
        void PopulateCheckInInvDGV()
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    {
                        var dgvPrepInvQuery = (from Items in db.Inventory_Item
                                               select new { Items.Inventory_Item_ID, Items.Inventory_Item_Name, Items.Inventory_Item_Quantity }
                                   ).ToList();


                        dgvCheckInInventory.DefaultCellStyle.ForeColor = Color.Black;
                        dgvCheckInInventory.Columns.Clear();
                        dgvCheckInInventory.DataSource = dgvPrepInvQuery;
                        dgvCheckInInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                        dgvCheckInInventory.Columns[0].HeaderText = "Inventory ID";
                        dgvCheckInInventory.Columns[1].HeaderText = "Item Name";
                        dgvCheckInInventory.Columns[2].HeaderText = "Total Quantity";


                    }
                }
            }
            catch (Exception myErr)
            {
                MessageBox.Show("Error: " + myErr.Message);
            }
        }
        void PopulateCheckOutInvDGV()
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    {
                        var dgvPrepInvQuery = (from Items in db.Inventory_Item
                                               select new { Items.Inventory_Item_ID, Items.Inventory_Item_Name, Items.Inventory_Item_Quantity, }
                                   ).ToList();

                        dgvInventoryItem.DefaultCellStyle.ForeColor = Color.Black;
                        dgvCheckOutInventory.Columns.Clear();
                        dgvCheckOutInventory.DataSource = dgvPrepInvQuery;
                        dgvCheckOutInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                        dgvCheckOutInventory.Columns[0].HeaderText = "Inventory ID";
                        dgvCheckOutInventory.Columns[1].HeaderText = "Item Name";
                        dgvCheckOutInventory.Columns[2].HeaderText = "Total Quantity";


                    }
                }
            }
            catch (Exception myErr)
            {
                MessageBox.Show("Error: " + myErr.Message);
            }
        }
        void PopulateInvStockTakeLineDGV()
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    var dgvQuery = (from stock in db.Stock_Take
                                    join line in db.Stock_Take_Line
                                    on stock.Stock_Take_ID equals line.Stock_Take_ID
                                    join invItem in db.Inventory_Item
                                    on line.Inventory_Item_ID equals invItem.Inventory_Item_ID
                                    select new { stock.Stock_Take_ID, invItem.Inventory_Item_ID, invItem.Inventory_Item_Name, line.Stock_Take_Line_Type, line.Stock_Take_Line_Type_Quantity, line.Quantity_Available, stock.Stock_Take_Date, stock.Stock_Take_Time }
                                   ).ToList();

                    dgvInventoryStockTakeLine.DefaultCellStyle.ForeColor = Color.Black;
                    dgvInventoryStockTakeLine.Columns.Clear();
                    dgvInventoryStockTakeLine.DataSource = dgvQuery;
                    dgvInventoryStockTakeLine.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    dgvInventoryStockTakeLine.Columns[0].HeaderText = "Stock Take ID";
                    dgvInventoryStockTakeLine.Columns[0].Visible = false;
                    dgvInventoryStockTakeLine.Columns[1].HeaderText = "Inventory ID";
                    dgvInventoryStockTakeLine.Columns[1].Visible = false;
                    dgvInventoryStockTakeLine.Columns[2].HeaderText = "Inventory Name";
                    dgvInventoryStockTakeLine.Columns[3].HeaderText = "Type";
                    dgvInventoryStockTakeLine.Columns[3].Width = 100;
                    dgvInventoryStockTakeLine.Columns[4].HeaderText = "Previous Quantity";

                    dgvInventoryStockTakeLine.Columns[5].HeaderText = "Quantity Currently Available";
                    dgvInventoryStockTakeLine.Columns[5].Width = 100;
                    dgvInventoryStockTakeLine.Columns[6].HeaderText = "Date Removed";
                    dgvInventoryStockTakeLine.Columns[7].HeaderText = "Time Removed";

                }
            }
            catch (Exception myErr)
            {
                MessageBox.Show("Error: " + myErr.Message);
            }

        }
        void PopulateInvStockTakeDGV()
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    var dgvQuery = (from Items in db.Inventory_Item
                                    select new { Items.Inventory_Item_ID, Items.Inventory_Item_Name, Items.Inventory_Item_Quantity }
                                   ).ToList();

                    dgvStockTakeHistory.DefaultCellStyle.ForeColor = Color.Black;
                    dgvStockTakeHistory.Columns.Clear();
                    dgvStockTakeHistory.DataSource = dgvQuery;
                    dgvStockTakeHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    dgvStockTakeHistory.Columns[0].HeaderText = "Inventory ID";
                    dgvStockTakeHistory.Columns[1].HeaderText = "Inventory Name";
                    dgvStockTakeHistory.Columns[1].Width = 100;
                    dgvStockTakeHistory.Columns[2].HeaderText = "Quantity";
                    dgvStockTakeHistory.Columns[2].Width = 100;

                }
            }
            catch (Exception myErr)
            {
                MessageBox.Show("Error: " + myErr.Message);
            }
        }
        void PopulateEmpDGV()
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    var dgvQuery = (from e in db.Employees
                                    join et in db.Employee_Type
                                    on e.Employee_Type_ID equals et.Employee_Type_ID
                                    join title in db.Employee_Title
                                    on e.Employee_Title_ID equals title.Employee_Title_ID
                                    join sq in db.Security_Question
                                    on e.Security_Question_ID equals sq.Security_Question_ID
                                    select new { e.Employee_ID, e.Employee_Name, e.Employee_Surname, e.Employee_Address, e.Employee_Cellphone_Number, e.Employee_Email, et.Employee_Type_Description, title.Employee_Title_Description, e.Bank_Name, e.Branch_Code, e.Account_Number, e.Employee_Picture, sq.Security_Question_Description, e.Employee_Security_Answer, e.Employee_Login_Password }
                                   ).ToList();

                    dgvEmployee.DefaultCellStyle.ForeColor = Color.Black;
                    dgvEmployee.Columns.Clear();
                    dgvEmployee.DataSource = dgvQuery;
                    dgvEmployee.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    dgvEmployee.Columns[0].HeaderText = "ID";
                    dgvEmployee.Columns[1].HeaderText = "Name";
                    dgvEmployee.Columns[1].Width = 100;
                    dgvEmployee.Columns[2].HeaderText = "Surname";
                    dgvEmployee.Columns[2].Width = 100;
                    dgvEmployee.Columns[3].HeaderText = "Address";
                    dgvEmployee.Columns[3].Width = 100;
                    dgvEmployee.Columns[4].HeaderText = "Cellphone Number";
                    dgvEmployee.Columns[5].HeaderText = "Email";
                    dgvEmployee.Columns[6].HeaderText = "Type";
                    dgvEmployee.Columns[7].HeaderText = "Title";
                    dgvEmployee.Columns[8].HeaderText = "Bank Name";
                    dgvEmployee.Columns[9].HeaderText = "Branch Code";
                    dgvEmployee.Columns[10].HeaderText = "Account Number";
                    dgvEmployee.Columns[11].HeaderText = "Employee Picture";
                    dgvEmployee.Columns[11].Visible = false;
                    dgvEmployee.Columns[12].HeaderText = "Security Question";
                    dgvEmployee.Columns[12].Visible = false;
                    dgvEmployee.Columns[13].HeaderText = "Security Answer";
                    dgvEmployee.Columns[13].Visible = false;
                    dgvEmployee.Columns[14].HeaderText = "Password";
                    dgvEmployee.Columns[14].Visible = false;

                }
            }
            catch (Exception myErr)
            {
                MessageBox.Show("Error: " + myErr.Message);
            }
        }
        void PopulateSupDgv()
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    var SupplierdgvQuery = (from s in db.Suppliers
                                            select new { s.Supplier_ID, s.Supplier_Name, s.Supplier_Surname, s.Supplier_Cellphone_Number, s.Supplier_Telephone, s.Supplier_Email, s.Supplier_Location, s.Bank_Name, s.Branch_Code, s.Account_Number }).ToList();

                    dgvSupplier.DefaultCellStyle.ForeColor = Color.Black;
                    dgvSupplier.Columns.Clear();
                    dgvSupplier.DataSource = SupplierdgvQuery;
                    dgvSupplier.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    dgvSupplier.Columns[0].HeaderText = "Supplier ID";
                    dgvSupplier.Columns[1].HeaderText = "Name";
                    dgvSupplier.Columns[1].Width = 100;
                    dgvSupplier.Columns[2].HeaderText = "Surname";
                    dgvSupplier.Columns[2].Width = 100;
                    dgvSupplier.Columns[3].HeaderText = "Number";
                    dgvSupplier.Columns[3].Width = 100;
                    dgvSupplier.Columns[4].HeaderText = "Telephone";
                    dgvSupplier.Columns[5].HeaderText = "Email";
                    dgvSupplier.Columns[6].HeaderText = "Location";
                    dgvSupplier.Columns[7].HeaderText = "Bank";
                    dgvSupplier.Columns[7].Visible = false;
                    dgvSupplier.Columns[8].HeaderText = "Branch Code";
                    dgvSupplier.Columns[8].Visible = false;
                    dgvSupplier.Columns[9].HeaderText = "Account Number";
                    dgvSupplier.Columns[9].Visible = false;
                }
            }
            catch (Exception myErr)
            {
                MessageBox.Show("Error: " + myErr.Message);

            }
        }
        void PopulateMenItmDgv()
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    var menuItemdgvQuery = (from mi in db.Menu_Item
                                            join mic in db.Menu_Item_Category
                                    on mi.Menu_Item_Category_ID equals mic.Menu_Item_Category_ID
                                            join mp in db.Menu_Item_Price
                                            on mi.Menu_Item_ID equals mp.Menu_Item_ID
                                            select new { mi.Menu_Item_ID, mi.Menu_Item_Name, mic.Menu_Item_Category_Description, mp.Menu_Item_Price1 }
                   ).ToList();

                    dgvMenuItemMain.DefaultCellStyle.ForeColor = Color.Black;
                    dgvMenuItemMain.Columns.Clear();
                    dgvMenuItemMain.Refresh();
                    dgvMenuItemMain.DataSource = menuItemdgvQuery;
                    dgvMenuItemMain.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    dgvMenuItemMain.Columns[0].HeaderText = "Menu ID";
                    dgvMenuItemMain.Columns[1].HeaderText = "Name";
                    dgvMenuItemMain.Columns[1].Width = 100;
                    dgvMenuItemMain.Columns[2].HeaderText = "Category";
                    dgvMenuItemMain.Columns[2].Width = 100;
                    dgvMenuItemMain.Columns[3].HeaderText = "Price";
                }
            }
            catch (Exception myErr)
            {
                MessageBox.Show("Error: " + myErr.Message);

            }
        }
        void PopulateSupplyOrderDgv()
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {

                    var SupplierOrderDGVQuery = (from s in db.Suppliers
                                                 select new { s.Supplier_Name, s.Supplier_Surname, s.Supplier_Email, s.Supplier_Telephone }
                                   ).ToList();

                    dgvInventoryItem.DefaultCellStyle.ForeColor = Color.Black;
                    dgvSupplierOrder.Columns.Clear();
                    dgvSupplierOrder.DataSource = SupplierOrderDGVQuery;
                    dgvSupplierOrder.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    dgvSupplierOrder.Columns[0].HeaderText = "Name";
                    dgvSupplierOrder.Columns[1].HeaderText = "Surname";
                    dgvSupplierOrder.Columns[1].Width = 100;
                    dgvSupplierOrder.Columns[2].HeaderText = "Email";
                    dgvSupplierOrder.Columns[3].HeaderText = "Contact";
                }
            }
            catch
            {
                MessageBox.Show("The supplier order datagridview could not be loaded");
            }

        }
        void PopulateWriteOffInvDGV()
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    {
                        var dgvInvQuery = (from Items in db.Inventory_Item
                                           join Price in db.Inventory_Price
                                        on Items.Inventory_Item_ID equals Price.Inventory_Item_ID
                                           join type in db.Inventory_Item_Type
                                           on Items.Inventory_Item_Type_ID equals type.Inventory_Item_Type_ID
                                           join um in db.Unit_Of_Measure
                                           on Items.Unit_Of_Measure_ID equals um.Unit_Of_Measure_ID
                                           select new { Items.Inventory_Item_ID, Items.Inventory_Item_Name, Items.Inventory_Item_Barcode, Items.Inventory_Item_Quantity, type.Inv_Item_Type_Description }
                                   ).ToList();

                        dgvWriteOffInventory.DefaultCellStyle.ForeColor = Color.Black;
                        dgvWriteOffInventory.Columns.Clear();
                        dgvWriteOffInventory.DataSource = dgvInvQuery;
                        dgvWriteOffInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                        dgvWriteOffInventory.Columns[0].HeaderText = "Inventory ID";
                        dgvWriteOffInventory.Columns[1].HeaderText = "Item Name";
                        dgvWriteOffInventory.Columns[1].Width = 100;
                        dgvWriteOffInventory.Columns[2].HeaderText = "Item Barcode";
                        dgvWriteOffInventory.Columns[2].Width = 100;
                        dgvWriteOffInventory.Columns[3].HeaderText = "Item Quantity";
                        dgvWriteOffInventory.Columns[3].Width = 100;
                        dgvWriteOffInventory.Columns[4].HeaderText = "Item Type";
                    }
                }
            }
            catch (Exception myErr)
            {
                MessageBox.Show("Error: " + myErr.Message);
            }
        }
        void PopulateWriteOffHistoryDGV()
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    {
                        var dgvInvQuery = (from Items in db.Inventory_Item
                                           join WrittenOff in db.Inventory_Write_off_Line
                                        on Items.Inventory_Item_ID equals WrittenOff.Inventory_Item_ID
                                           join line in db.Inventory_Write_Off
                                           on WrittenOff.Write_Off_ID equals line.Write_Off_ID
                                           select new { Items.Inventory_Item_ID, Items.Inventory_Item_Name, WrittenOff.Quantity, line.Write_Off_Date, line.Write_Off_Reason }
                                   ).ToList();

                        dgvWrittenOffHistory.DefaultCellStyle.ForeColor = Color.Black;
                        dgvWrittenOffHistory.Columns.Clear();
                        dgvWrittenOffHistory.DataSource = dgvInvQuery;
                        dgvWrittenOffHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                        dgvWrittenOffHistory.Columns[0].HeaderText = "Inventory ID";
                        dgvWrittenOffHistory.Columns[1].HeaderText = "Item Name";
                        dgvWrittenOffHistory.Columns[1].Width = 100;
                        dgvWrittenOffHistory.Columns[2].HeaderText = "Quantity Written Off";
                        dgvWrittenOffHistory.Columns[2].Width = 100;
                        dgvWrittenOffHistory.Columns[3].HeaderText = "Date";
                        dgvWrittenOffHistory.Columns[3].Width = 100;
                        dgvWrittenOffHistory.Columns[4].HeaderText = "Reason";
                    }
                }
            }
            catch (Exception myErr)
            {
                MessageBox.Show("Error: " + myErr.Message);
            }
        }
        void LoadFoodOrderScreenDGV()
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    var FoodOrderdgvQuery = (from s in db.Sales
                                             join i in db.Food_Order_Line
                                             on s.Sales_ID equals i.Sales_ID
                                             join inv in db.Menu_Item
                                             on i.Menu_Item_ID equals inv.Menu_Item_ID
                                             join price in db.Menu_Item_Price
                                             on inv.Menu_Item_ID equals price.Menu_Item_ID
                                             select new
                                             {
                                                 s.Sales_Date,
                                                 s.Sales_Time,
                                                 inv.Menu_Item_Name,
                                                 i.Quantity,
                                                 i.Note
                                             }).ToList();



                    dgvFoodOrderScreen.DefaultCellStyle.ForeColor = Color.Black;
                    dgvFoodOrderScreen.Columns.Clear();
                    dgvFoodOrderScreen.DataSource = FoodOrderdgvQuery;
                    dgvFoodOrderScreen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    dgvFoodOrderScreen.Columns[0].HeaderText = "Sales Date";
                    dgvFoodOrderScreen.Columns[1].HeaderText = "Sales Time";
                    dgvFoodOrderScreen.Columns[1].Width = 100;
                    dgvFoodOrderScreen.Columns[2].HeaderText = "Item";
                    dgvFoodOrderScreen.Columns[2].Width = 100;
                    dgvFoodOrderScreen.Columns[3].HeaderText = "Quantity";
                    dgvFoodOrderScreen.Columns[3].Width = 100;
                    dgvFoodOrderScreen.Columns[4].HeaderText = "Note";
                    dgvFoodOrderScreen.Columns[4].Width = 100;

                }
            }
            catch (Exception myErr)
            {
                MessageBox.Show("Error: " + myErr.Message);

            }
        }
        void PopulateSaleHistoryDgv()
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    var SaledgvQuery = (from s in db.Sales
                                        join i in db.Sales_Line
                                        on s.Sales_ID equals i.Sales_ID
                                        join inv in db.Inventory_Item
                                        on i.Inventory_Item_ID equals inv.Inventory_Item_ID
                                        join price in db.Inventory_Price
                                        on inv.Inventory_Item_ID equals price.Inventory_Item_ID
                                        select new
                                        {
                                            s.Sales_Date,
                                            s.Sales_Time,
                                            inv.Inventory_Item_Name,
                                            i.Sales_Line_Quantity,
                                            price.Inventory_Price1,
                                            total = i.Sales_Line_Quantity * price.Inventory_Price1
                                        }).ToList();

                    dgvSalesHistory.DefaultCellStyle.ForeColor = Color.Black;
                    dgvSalesHistory.Columns.Clear();
                    dgvSalesHistory.DataSource = SaledgvQuery;
                    dgvSalesHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    dgvSalesHistory.Columns[0].HeaderText = "Sales Date";
                    dgvSalesHistory.Columns[1].HeaderText = "Sales Time";
                    dgvSalesHistory.Columns[1].Width = 100;
                    dgvSalesHistory.Columns[2].HeaderText = "Item";
                    dgvSalesHistory.Columns[2].Width = 100;
                    dgvSalesHistory.Columns[3].HeaderText = "Quantity Sold";
                    dgvSalesHistory.Columns[3].Width = 100;
                    dgvSalesHistory.Columns[4].HeaderText = "Price Per Unit";
                    dgvSalesHistory.Columns[4].Width = 100;
                    dgvSalesHistory.Columns[5].HeaderText = "Total";
                    dgvSalesHistory.Columns[5].Width = 100;
                }
            }
            catch (Exception myErr)
            {
                MessageBox.Show("Error: " + myErr.Message);

            }
        }
        void PopulateFoodSaleHistoryDgv()
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    var SaledgvQuery = (from s in db.Sales
                                        join i in db.Food_Order_Line
                                        on s.Sales_ID equals i.Sales_ID
                                        join inv in db.Menu_Item
                                        on i.Menu_Item_ID equals inv.Menu_Item_ID
                                        join price in db.Menu_Item_Price
                                        on inv.Menu_Item_ID equals price.Menu_Item_ID
                                        select new
                                        {
                                            s.Sales_Date,
                                            s.Sales_Time,
                                            inv.Menu_Item_Name,
                                            i.Quantity,
                                            price.Menu_Item_Price1,
                                            total = i.Quantity * price.Menu_Item_Price1
                                        }).ToList();



                    dgvMenuSaleHistory.DefaultCellStyle.ForeColor = Color.Black;
                    dgvMenuSaleHistory.Columns.Clear();
                    dgvMenuSaleHistory.DataSource = SaledgvQuery;
                    dgvMenuSaleHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    dgvMenuSaleHistory.Columns[0].HeaderText = "Sales Date";
                    dgvMenuSaleHistory.Columns[1].HeaderText = "Sales Time";
                    dgvMenuSaleHistory.Columns[1].Width = 100;
                    dgvMenuSaleHistory.Columns[2].HeaderText = "Item";
                    dgvMenuSaleHistory.Columns[2].Width = 100;
                    dgvMenuSaleHistory.Columns[3].HeaderText = "Quantity Sold";
                    dgvMenuSaleHistory.Columns[3].Width = 100;
                    dgvMenuSaleHistory.Columns[4].HeaderText = "Price Per Unit";
                    dgvMenuSaleHistory.Columns[4].Width = 100;
                    dgvMenuSaleHistory.Columns[5].HeaderText = "Total";
                    dgvMenuSaleHistory.Columns[5].Width = 100;
                }
            }
            catch (Exception myErr)
            {
                MessageBox.Show("Error: " + myErr.Message);

            }
        }

        #endregion()

        #region Employee
        private void txtSearchSupplier_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    if (cbxSearchSupplier.Text == "ID")
                    {
                        var SupplierdgvQuery = (from s in db.Suppliers
                                                where s.Supplier_ID.ToString().Contains(txtSearchSupplier.Text)
                                                select new { s.Supplier_ID, s.Supplier_Name, s.Supplier_Surname, s.Supplier_Cellphone_Number, s.Supplier_Telephone, s.Supplier_Email, s.Supplier_Location, s.Bank_Name, s.Branch_Code, s.Account_Number }).ToList();

                        dgvSupplier.DefaultCellStyle.ForeColor = Color.Black;
                        dgvSupplier.Columns.Clear();
                        dgvSupplier.DataSource = SupplierdgvQuery;
                        dgvSupplier.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                        dgvSupplier.Columns[0].HeaderText = "Supplier ID";
                        dgvSupplier.Columns[1].HeaderText = "Name";
                        dgvSupplier.Columns[1].Width = 100;
                        dgvSupplier.Columns[2].HeaderText = "Surname";
                        dgvSupplier.Columns[2].Width = 100;
                        dgvSupplier.Columns[3].HeaderText = "Number";
                        dgvSupplier.Columns[3].Width = 100;
                        dgvSupplier.Columns[4].HeaderText = "Telephone";
                        dgvSupplier.Columns[5].HeaderText = "Email";
                        dgvSupplier.Columns[6].HeaderText = "Location";
                        dgvSupplier.Columns[7].HeaderText = "Bank";
                        dgvSupplier.Columns[7].Visible = false;
                        dgvSupplier.Columns[8].HeaderText = "Branch Code";
                        dgvSupplier.Columns[8].Visible = false;
                        dgvSupplier.Columns[9].HeaderText = "Account Number";
                        dgvSupplier.Columns[9].Visible = false;
                    }
                    else if (cbxSearchSupplier.Text == "Name")
                    {
                        var SupplierdgvQuery = (from s in db.Suppliers
                                                where s.Supplier_Name.Contains(txtSearchSupplier.Text)
                                                select new { s.Supplier_ID, s.Supplier_Name, s.Supplier_Surname, s.Supplier_Cellphone_Number, s.Supplier_Telephone, s.Supplier_Email, s.Supplier_Location, s.Bank_Name, s.Branch_Code, s.Account_Number }).ToList();

                        dgvSupplier.DefaultCellStyle.ForeColor = Color.Black;
                        dgvSupplier.Columns.Clear();
                        dgvSupplier.DataSource = SupplierdgvQuery;
                        dgvSupplier.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                        dgvSupplier.Columns[0].HeaderText = "Supplier ID";
                        dgvSupplier.Columns[1].HeaderText = "Name";
                        dgvSupplier.Columns[1].Width = 100;
                        dgvSupplier.Columns[2].HeaderText = "Surname";
                        dgvSupplier.Columns[2].Width = 100;
                        dgvSupplier.Columns[3].HeaderText = "Number";
                        dgvSupplier.Columns[3].Width = 100;
                        dgvSupplier.Columns[4].HeaderText = "Telephone";
                        dgvSupplier.Columns[5].HeaderText = "Email";
                        dgvSupplier.Columns[6].HeaderText = "Location";
                        dgvSupplier.Columns[7].HeaderText = "Bank";
                        dgvSupplier.Columns[7].Visible = false;
                        dgvSupplier.Columns[8].HeaderText = "Branch Code";
                        dgvSupplier.Columns[8].Visible = false;
                        dgvSupplier.Columns[9].HeaderText = "Account Number";
                        dgvSupplier.Columns[9].Visible = false;
                    }
                    else if (cbxSearchSupplier.Text == "Surname")
                    {
                        var SupplierdgvQuery = (from s in db.Suppliers
                                                where s.Supplier_Surname.Contains(txtSearchSupplier.Text)
                                                select new { s.Supplier_ID, s.Supplier_Name, s.Supplier_Surname, s.Supplier_Cellphone_Number, s.Supplier_Telephone, s.Supplier_Email, s.Supplier_Location, s.Bank_Name, s.Branch_Code, s.Account_Number }).ToList();

                        dgvSupplier.DefaultCellStyle.ForeColor = Color.Black;
                        dgvSupplier.Columns.Clear();
                        dgvSupplier.DataSource = SupplierdgvQuery;
                        dgvSupplier.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                        dgvSupplier.Columns[0].HeaderText = "Supplier ID";
                        dgvSupplier.Columns[1].HeaderText = "Name";
                        dgvSupplier.Columns[1].Width = 100;
                        dgvSupplier.Columns[2].HeaderText = "Surname";
                        dgvSupplier.Columns[2].Width = 100;
                        dgvSupplier.Columns[3].HeaderText = "Number";
                        dgvSupplier.Columns[3].Width = 100;
                        dgvSupplier.Columns[4].HeaderText = "Telephone";
                        dgvSupplier.Columns[5].HeaderText = "Email";
                        dgvSupplier.Columns[6].HeaderText = "Location";
                        dgvSupplier.Columns[7].HeaderText = "Bank";
                        dgvSupplier.Columns[7].Visible = false;
                        dgvSupplier.Columns[8].HeaderText = "Branch Code";
                        dgvSupplier.Columns[8].Visible = false;
                        dgvSupplier.Columns[9].HeaderText = "Account Number";
                        dgvSupplier.Columns[9].Visible = false;
                    }
                    else if (cbxSearchSupplier.Text == "Location")
                    {
                        var SupplierdgvQuery = (from s in db.Suppliers
                                                where s.Supplier_Location.Contains(txtSearchSupplier.Text)
                                                select new { s.Supplier_ID, s.Supplier_Name, s.Supplier_Surname, s.Supplier_Cellphone_Number, s.Supplier_Telephone, s.Supplier_Email, s.Supplier_Location, s.Bank_Name, s.Branch_Code, s.Account_Number }).ToList();

                        dgvSupplier.DefaultCellStyle.ForeColor = Color.Black;
                        dgvSupplier.Columns.Clear();
                        dgvSupplier.DataSource = SupplierdgvQuery;
                        dgvSupplier.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                        dgvSupplier.Columns[0].HeaderText = "Supplier ID";
                        dgvSupplier.Columns[1].HeaderText = "Name";
                        dgvSupplier.Columns[1].Width = 100;
                        dgvSupplier.Columns[2].HeaderText = "Surname";
                        dgvSupplier.Columns[2].Width = 100;
                        dgvSupplier.Columns[3].HeaderText = "Number";
                        dgvSupplier.Columns[3].Width = 100;
                        dgvSupplier.Columns[4].HeaderText = "Telephone";
                        dgvSupplier.Columns[5].HeaderText = "Email";
                        dgvSupplier.Columns[6].HeaderText = "Location";
                        dgvSupplier.Columns[7].HeaderText = "Bank";
                        dgvSupplier.Columns[7].Visible = false;
                        dgvSupplier.Columns[8].HeaderText = "Branch Code";
                        dgvSupplier.Columns[8].Visible = false;
                        dgvSupplier.Columns[9].HeaderText = "Account Number";
                        dgvSupplier.Columns[9].Visible = false;
                    }
                    else
                    {
                        txtSearchSupplier.Clear();
                        MessageBox.Show("Please select a search criteria from the drop down list.", "No search Criteria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception myErr)
            {
                txtSearchSupplier.Clear();
                MessageBox.Show("Error: " + myErr.Message);
            }
        }
        private void btnAddNewEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    var EmpTypeIDQry = (from type in db.Employee_Type
                                        where type.Employee_Type_Description.Equals(cbxEmployeeType.Text)
                                        select new { type.Employee_Type_ID }
                              ).FirstOrDefault();

                    var EmpTitleIDQry = (from title in db.Employee_Title
                                         where title.Employee_Title_Description.Equals(cbxEmployeeTitle.Text)
                                         select new { title.Employee_Title_ID }
                                  ).FirstOrDefault();

                    var SecurityQuestionIDQry = (from question in db.Security_Question
                                                 where question.Security_Question_Description.Equals(cbxSecurityQuestion.Text)
                                                 select new { question.Security_Question_ID }
                                  ).FirstOrDefault();
                    db.spAddEmployee(txtEmpName.Text, txtEmpSurname.Text, txtEmpNumber.Text, txtEmpAddress.Text, txtEmpEmail.Text, PasswordHash(txtLoginPassword.Text), SecurityQuestionIDQry.Security_Question_ID, txtSecurityQuestion.Text, convertImagetoByte(pbxEmployeePhoto.Image), txtEmployeeBankName.Text, txtEmployeeBranchCode.Text, txtEmployeeAccountNo.Text, EmpTypeIDQry.Employee_Type_ID, EmpTitleIDQry.Employee_Title_ID, Convert.ToDateTime(lblDatePOS.Text), DateTime.Now.TimeOfDay, txtEmployeeNameProfile.Text, "Adding a new Employee", txtEmpName.Text + " was added");
                    //ConfirmPassword();
                    db.SaveChanges();

                    PopulateEmpDGV();
                    PopulateAuditLogDGV();
                    MessageBox.Show("The new Employee has been successfully added", "Successful Addition", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnUpdateEmployees_Click(object sender, EventArgs e)
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    var EmpTypeIDQry = (from type in db.Employee_Type
                                        where type.Employee_Type_Description.Equals(cbxEmployeeType.Text)
                                        select new { type.Employee_Type_ID }
                              ).FirstOrDefault();

                    var EmpTitleIDQry = (from title in db.Employee_Title
                                         where title.Employee_Title_Description.Equals(cbxEmployeeTitle.Text)
                                         select new { title.Employee_Title_ID }
                                  ).FirstOrDefault();

                    var SecurityQuestionIDQry = (from question in db.Security_Question
                                                 where question.Security_Question_Description.Equals(cbxSecurityQuestion.Text)
                                                 select new { question.Security_Question_ID }
                                  ).FirstOrDefault();
                    db.spUpdateEmployee(Convert.ToInt32(txtEmpID.Text), txtEmpName.Text, txtEmpSurname.Text, txtEmpNumber.Text, txtEmpAddress.Text, txtEmpEmail.Text, txtLoginPassword.Text, SecurityQuestionIDQry.Security_Question_ID, txtSecurityQuestion.Text, convertImagetoByte(pbxEmployeePhoto.Image), txtEmployeeBankName.Text, txtEmployeeBranchCode.Text, txtEmployeeAccountNo.Text, EmpTitleIDQry.Employee_Title_ID, EmpTypeIDQry.Employee_Type_ID, Convert.ToDateTime(lblDatePOS.Text), DateTime.Now.TimeOfDay, txtEmployeeNameProfile.Text, "Updating an existing Employee", txtEmpName.Text + " was updated");

                    db.SaveChanges();

                    PopulateEmpDGV();
                    PopulateAuditLogDGV();
                    MessageBox.Show("The new Employee has been successfully updated", "Successful Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnAddEmployeePicture_Click(object sender, EventArgs e)
        {
            try
            {
                btnStartPhoto.Visible = true;
                btnStopPhoto.Visible = true;
                btnSavePhoto.Visible = true;
                cbxImageDevice.Visible = true;
            }
            catch
            {
                MessageBox.Show("Could not process a picture at the moment");
            }

        }
        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    db.spDeleteEmployee(Convert.ToInt32(txtEmpID.Text), Convert.ToDateTime(lblDatePOS.Text), DateTime.Now.TimeOfDay, txtEmployeeNameProfile.Text, "Deleting a Employee", txtEmpName.Text + " " + txtEmpSurname.Text + ",ID:" + txtEmployeeID.Text + " was deleted");

                    db.SaveChanges();

                    PopulateEmpDGV();
                    PopulateAuditLogDGV();
                    MessageBox.Show("The Employee has been successfully deleted", "Successful Deletion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void txtEmployeeSearch_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    if (cbxSearchEmployee.Text == "Employee ID")
                    {
                        var dgvQuery = (from emp in db.Employees
                                        join et in db.Employee_Type
                                        on emp.Employee_Type_ID equals et.Employee_Type_ID
                                        join title in db.Employee_Title
                                        on emp.Employee_Title_ID equals title.Employee_Title_ID
                                        join sq in db.Security_Question
                                        on emp.Security_Question_ID equals sq.Security_Question_ID
                                        where emp.Employee_ID.ToString().Contains(txtEmployeeSearch.Text)
                                        select new { emp.Employee_ID, emp.Employee_Name, emp.Employee_Surname, emp.Employee_Address, emp.Employee_Cellphone_Number, emp.Employee_Email, et.Employee_Type_Description, title.Employee_Title_Description, emp.Bank_Name, emp.Branch_Code, emp.Account_Number, emp.Employee_Picture, sq.Security_Question_Description, emp.Employee_Security_Answer, emp.Employee_Login_Password }
                                   ).ToList();

                        dgvEmployee.DefaultCellStyle.ForeColor = Color.Black;
                        dgvEmployee.Columns.Clear();
                        dgvEmployee.DataSource = dgvQuery;
                        dgvEmployee.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                        dgvEmployee.Columns[0].HeaderText = "ID";
                        dgvEmployee.Columns[1].HeaderText = "Name";
                        dgvEmployee.Columns[1].Width = 100;
                        dgvEmployee.Columns[2].HeaderText = "Surname";
                        dgvEmployee.Columns[2].Width = 100;
                        dgvEmployee.Columns[3].HeaderText = "Address";
                        dgvEmployee.Columns[3].Width = 100;
                        dgvEmployee.Columns[4].HeaderText = "Cellphone Number";
                        dgvEmployee.Columns[5].HeaderText = "Email";
                        dgvEmployee.Columns[6].HeaderText = "Type";
                        dgvEmployee.Columns[7].HeaderText = "Title";
                        dgvEmployee.Columns[8].HeaderText = "Bank Name";
                        dgvEmployee.Columns[9].HeaderText = "Branch Code";
                        dgvEmployee.Columns[10].HeaderText = "Account Number";
                        dgvEmployee.Columns[11].HeaderText = "Employee Picture";
                        dgvEmployee.Columns[11].Visible = false;
                        dgvEmployee.Columns[12].HeaderText = "Security Question";
                        dgvEmployee.Columns[12].Visible = false;
                        dgvEmployee.Columns[13].HeaderText = "Security Answer";
                        dgvEmployee.Columns[13].Visible = false;
                        dgvEmployee.Columns[14].HeaderText = "Password";
                        dgvEmployee.Columns[14].Visible = false;
                    }

                    else if (cbxSearchEmployee.Text == "Employee Name")
                    {
                        var dgvQuery = (from emp in db.Employees
                                        join et in db.Employee_Type
                                        on emp.Employee_Type_ID equals et.Employee_Type_ID
                                        join title in db.Employee_Title
                                        on emp.Employee_Title_ID equals title.Employee_Title_ID
                                        join sq in db.Security_Question
                                        on emp.Security_Question_ID equals sq.Security_Question_ID
                                        where emp.Employee_Name.Contains(txtEmployeeSearch.Text)
                                        select new { emp.Employee_ID, emp.Employee_Name, emp.Employee_Surname, emp.Employee_Address, emp.Employee_Cellphone_Number, emp.Employee_Email, et.Employee_Type_Description, title.Employee_Title_Description, emp.Bank_Name, emp.Branch_Code, emp.Account_Number, emp.Employee_Picture, sq.Security_Question_Description, emp.Employee_Security_Answer, emp.Employee_Login_Password }
                                   ).ToList();

                        dgvEmployee.DefaultCellStyle.ForeColor = Color.Black;
                        dgvEmployee.Columns.Clear();
                        dgvEmployee.DataSource = dgvQuery;
                        dgvEmployee.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                        dgvEmployee.Columns[0].HeaderText = "ID";
                        dgvEmployee.Columns[1].HeaderText = "Name";
                        dgvEmployee.Columns[1].Width = 100;
                        dgvEmployee.Columns[2].HeaderText = "Surname";
                        dgvEmployee.Columns[2].Width = 100;
                        dgvEmployee.Columns[3].HeaderText = "Address";
                        dgvEmployee.Columns[3].Width = 100;
                        dgvEmployee.Columns[4].HeaderText = "Cellphone Number";
                        dgvEmployee.Columns[5].HeaderText = "Email";
                        dgvEmployee.Columns[6].HeaderText = "Type";
                        dgvEmployee.Columns[7].HeaderText = "Title";
                        dgvEmployee.Columns[8].HeaderText = "Bank Name";
                        dgvEmployee.Columns[9].HeaderText = "Branch Code";
                        dgvEmployee.Columns[10].HeaderText = "Account Number";
                        dgvEmployee.Columns[11].HeaderText = "Employee Picture";
                        dgvEmployee.Columns[11].Visible = false;
                        dgvEmployee.Columns[12].HeaderText = "Security Question";
                        dgvEmployee.Columns[12].Visible = false;
                        dgvEmployee.Columns[13].HeaderText = "Security Answer";
                        dgvEmployee.Columns[13].Visible = false;
                        dgvEmployee.Columns[14].HeaderText = "Password";
                        dgvEmployee.Columns[14].Visible = false;
                    }
                    else if (cbxSearchEmployee.Text == "Employee Surname")
                    {
                        var dgvQuery = (from emp in db.Employees
                                        join et in db.Employee_Type
                                        on emp.Employee_Type_ID equals et.Employee_Type_ID
                                        join title in db.Employee_Title
                                        on emp.Employee_Title_ID equals title.Employee_Title_ID
                                        join sq in db.Security_Question
                                        on emp.Security_Question_ID equals sq.Security_Question_ID
                                        where emp.Employee_Surname.Contains(txtEmployeeSearch.Text)
                                        select new { emp.Employee_ID, emp.Employee_Name, emp.Employee_Surname, emp.Employee_Address, emp.Employee_Cellphone_Number, emp.Employee_Email, et.Employee_Type_Description, title.Employee_Title_Description, emp.Bank_Name, emp.Branch_Code, emp.Account_Number, emp.Employee_Picture, sq.Security_Question_Description, emp.Employee_Security_Answer, emp.Employee_Login_Password }
                                   ).ToList();

                        dgvEmployee.DefaultCellStyle.ForeColor = Color.Black;
                        dgvEmployee.Columns.Clear();
                        dgvEmployee.DataSource = dgvQuery;
                        dgvEmployee.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                        dgvEmployee.Columns[0].HeaderText = "ID";
                        dgvEmployee.Columns[1].HeaderText = "Name";
                        dgvEmployee.Columns[1].Width = 100;
                        dgvEmployee.Columns[2].HeaderText = "Surname";
                        dgvEmployee.Columns[2].Width = 100;
                        dgvEmployee.Columns[3].HeaderText = "Address";
                        dgvEmployee.Columns[3].Width = 100;
                        dgvEmployee.Columns[4].HeaderText = "Cellphone Number";
                        dgvEmployee.Columns[5].HeaderText = "Email";
                        dgvEmployee.Columns[6].HeaderText = "Type";
                        dgvEmployee.Columns[7].HeaderText = "Title";
                        dgvEmployee.Columns[8].HeaderText = "Bank Name";
                        dgvEmployee.Columns[9].HeaderText = "Branch Code";
                        dgvEmployee.Columns[10].HeaderText = "Account Number";
                        dgvEmployee.Columns[11].HeaderText = "Employee Picture";
                        dgvEmployee.Columns[11].Visible = false;
                        dgvEmployee.Columns[12].HeaderText = "Security Question";
                        dgvEmployee.Columns[12].Visible = false;
                        dgvEmployee.Columns[13].HeaderText = "Security Answer";
                        dgvEmployee.Columns[13].Visible = false;
                        dgvEmployee.Columns[14].HeaderText = "Password";
                        dgvEmployee.Columns[14].Visible = false;
                    }
                    else if (cbxSearchEmployee.Text == "Employee Type")
                    {
                        var dgvQuery = (from emp in db.Employees
                                        join et in db.Employee_Type
                                        on emp.Employee_Type_ID equals et.Employee_Type_ID
                                        join title in db.Employee_Title
                                        on emp.Employee_Title_ID equals title.Employee_Title_ID
                                        join sq in db.Security_Question
                                        on emp.Security_Question_ID equals sq.Security_Question_ID
                                        where et.Employee_Type_Description.Contains(txtEmployeeSearch.Text)
                                        select new { emp.Employee_ID, emp.Employee_Name, emp.Employee_Surname, emp.Employee_Address, emp.Employee_Cellphone_Number, emp.Employee_Email, et.Employee_Type_Description, title.Employee_Title_Description, emp.Bank_Name, emp.Branch_Code, emp.Account_Number, emp.Employee_Picture, sq.Security_Question_Description, emp.Employee_Security_Answer, emp.Employee_Login_Password }
                                   ).ToList();

                        dgvEmployee.DefaultCellStyle.ForeColor = Color.Black;
                        dgvEmployee.Columns.Clear();
                        dgvEmployee.DataSource = dgvQuery;
                        dgvEmployee.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                        dgvEmployee.Columns[0].HeaderText = "ID";
                        dgvEmployee.Columns[1].HeaderText = "Name";
                        dgvEmployee.Columns[1].Width = 100;
                        dgvEmployee.Columns[2].HeaderText = "Surname";
                        dgvEmployee.Columns[2].Width = 100;
                        dgvEmployee.Columns[3].HeaderText = "Address";
                        dgvEmployee.Columns[3].Width = 100;
                        dgvEmployee.Columns[4].HeaderText = "Cellphone Number";
                        dgvEmployee.Columns[5].HeaderText = "Email";
                        dgvEmployee.Columns[6].HeaderText = "Type";
                        dgvEmployee.Columns[7].HeaderText = "Title";
                        dgvEmployee.Columns[8].HeaderText = "Bank Name";
                        dgvEmployee.Columns[9].HeaderText = "Branch Code";
                        dgvEmployee.Columns[10].HeaderText = "Account Number";
                        dgvEmployee.Columns[11].HeaderText = "Employee Picture";
                        dgvEmployee.Columns[11].Visible = false;
                        dgvEmployee.Columns[12].HeaderText = "Security Question";
                        dgvEmployee.Columns[12].Visible = false;
                        dgvEmployee.Columns[13].HeaderText = "Security Answer";
                        dgvEmployee.Columns[13].Visible = false;
                        dgvEmployee.Columns[14].HeaderText = "Password";
                        dgvEmployee.Columns[14].Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Please select a search criteria from the drop down list.", "No search Criteria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtEmployeeSearch.Clear();
                    }
                }
            }
            catch (Exception myErr)
            {
                MessageBox.Show("Error: " + myErr.Message);
                txtEmployeeSearch.Clear();
            }
        }

        #endregion 

        #region Suppliers  
        private void btnSearchSupplier_Click(object sender, EventArgs e)
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    var SupplierdgvQuery = (from s in db.Suppliers
                                            where s.Supplier_Name.Contains(txtSearchSupplier.Text)
                                            select new { s.Supplier_ID, s.Supplier_Name, s.Supplier_Surname, s.Supplier_Cellphone_Number, s.Supplier_Telephone, s.Supplier_Email /*,e.Employee_Telephone*/}
                                   ).ToList();

                    dgvSupplier.Columns.Clear();
                    dgvSupplier.DataSource = SupplierdgvQuery;
                    dgvSupplier.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    dgvSupplier.Columns[0].HeaderText = "Supplier ID";
                    dgvSupplier.Columns[1].HeaderText = "Name";
                    dgvSupplier.Columns[1].Width = 100;
                    dgvSupplier.Columns[2].HeaderText = "Surname";
                    dgvSupplier.Columns[2].Width = 100;
                    dgvSupplier.Columns[3].HeaderText = "Number";
                    dgvSupplier.Columns[3].Width = 100;
                    dgvSupplier.Columns[4].HeaderText = "Telephone";
                    dgvSupplier.Columns[5].HeaderText = "Email";
                }
            }
            catch
            {
                MessageBox.Show("The search could not be implemented");
            }
        }
        private void btnAddSupplier_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    db.spAddSupplier(txtSupplierName.Text, txtSupplierSurname.Text, txtSupplierCellphone.Text, txtSupplierTelepone.Text, txtSupplierEmail.Text, txtSupplierLocation.Text, txtSupplierBankName.Text, txtSupplierBranchCode.Text, txtSupplierAccountNo.Text, Convert.ToDateTime(lblDatePOS.Text), DateTime.Now.TimeOfDay, txtEmployeeNameProfile.Text, "Adding a new Supplier", txtSupplierName.Text + " was added");

                    db.SaveChanges();

                    PopulateSupDgv();
                    PopulateAuditLogDGV();
                    MessageBox.Show("The new Supplier has been successfully added", "Successful Addition", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnUpdateSupplier_Click(object sender, EventArgs e)
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    db.spUpdateSupplier(Convert.ToInt32(txtSupplierID.Text), txtSupplierName.Text, txtSupplierSurname.Text, txtSupplierCellphone.Text, txtSupplierTelepone.Text, txtSupplierEmail.Text, txtSupplierLocation.Text, txtSupplierBankName.Text, txtSupplierBranchCode.Text, txtSupplierAccountNo.Text, Convert.ToDateTime(lblDatePOS.Text), DateTime.Now.TimeOfDay, txtEmployeeNameProfile.Text, "Updating an existing Supplier", txtSupplierName.Text + " was updated");

                    db.SaveChanges();

                    PopulateSupDgv();
                    PopulateAuditLogDGV();
                    MessageBox.Show("The existing Supplier has been successfully updated", "Successful Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnDeleteSupplier_Click(object sender, EventArgs e)
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    db.spDeleteSupplier(Convert.ToInt32(txtSupplierID.Text), Convert.ToDateTime(lblDatePOS.Text), DateTime.Now.TimeOfDay, txtEmployeeNameProfile.Text, "Deleting a Supplier", txtSupplierName.Text + " " + txtSupplierSurname.Text + ",ID:" + txtSupplierID.Text + " was deleted");

                    db.SaveChanges();

                    PopulateSupDgv();
                    PopulateAuditLogDGV();
                    MessageBox.Show("The Supplier has been successfully deleted", "Successful Deletion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        void AddEmpPicture()
        {
            try
            {
                webcam = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                foreach (FilterInfo VideoCaptureDevice in webcam)
                {
                    cbxImageDevice.Items.Add(VideoCaptureDevice.Name);
                }
                cbxImageDevice.SelectedIndex = 0;
                btnSavePhoto.Enabled = false;
            }
            catch
            {
                MessageBox.Show("The webcam is not working");
            }

        }


        #endregion

        #region Maintenance
        //private void btnBackUp_Click(object sender, EventArgs e)
        //{
        //    progressBar1.Value = 0;
        //    try
        //    {
        //        //Server dbServer = new Server(new ServerConnection(txtServer.Text));
        //        //Backup dbBackup = new Backup() { Action = BackupActionType.Database, Database = txtDatabase.Text };
        //        //dbBackup.Devices.AddDevice(@"C:\Data\NatiSupermarketandTakeawayFinal.bak", DeviceType.File);
        //        //dbBackup.PercentComplete += DbBackup_PercentComplete;
        //        //dbBackup.Complete += DbBackup_Complete;
        //        //dbBackup.SqlBackupAsync(dbServer);

        //        //MessageBox.Show("The database has been successfully backed up.", "Successful Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        //btnCancel.Text = "Close";
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void DbBackup_Complete(object sender, ServerMessageEventArgs e)
        //{
        //    if (e.Error != null)
        //    {
        //        lblStatus.Invoke((MethodInvoker)delegate
        //        {
        //            lblStatus.Text = e.Error.Message;
        //        });
        //    }
        //}
        //private void DbBackup_PercentComplete(object sender, PercentCompleteEventArgs e)
        //{
        //    progressBar1.Invoke((MethodInvoker)delegate
        //    {
        //        progressBar1.Value = e.Percent;
        //        progressBar1.Update();
        //    });
        //    lblPercent.Invoke((MethodInvoker)delegate
        //    {
        //        lblPercent.Text = $"{e.Percent}%";
        //    });
        //}

        //private void btnRestore_Click(object sender, EventArgs e)
        //{
        //    progressBar2.Value = 0;
        //    try
        //    {
        //        Server dbServer = new Server(new ServerConnection(txtServer.Text));
        //        Restore dbRestore = new Restore() { Action = RestoreActionType.Database, ReplaceDatabase = true, NoRecovery = false, Database = txtDatabase.Text };
        //        dbRestore.Devices.AddDevice(@"C:\Data\NatiSupermarketandTakeawayFinal.bak", DeviceType.File);
        //        dbRestore.PercentComplete += DbRestore_PercentComplete;
        //        dbRestore.Complete += DbRestore_Complete;
        //        dbRestore.SqlRestoreAsync(dbServer);

        //        MessageBox.Show("The database has been successfully restored.", "Successful Restoration", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        btnClearInventoryItem.Text = "Close";
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(ex.Message);
        //    }
        //}
        //private void DbRestore_Complete(object sender, ServerMessageEventArgs e)
        //{
        //    if (e.Error != null)
        //    {
        //        lblStatus2.Invoke((MethodInvoker)delegate
        //        {
        //            lblStatus2.Text = e.Error.Message;
        //        });
        //    }
        //}

        //private void DbRestore_PercentComplete(object sender, PercentCompleteEventArgs e)
        //{
        //    progressBar2.Invoke((MethodInvoker)delegate
        //    {
        //        progressBar2.Value = e.Percent;
        //        progressBar2.Update();
        //    });
        //    lblPercent2.Invoke((MethodInvoker)delegate
        //    {
        //        lblPercent2.Text = $"{e.Percent}%";
        //    });
        //}
        #endregion

        #region Inventory    
        private void btnSaveInventory_Click_1(object sender, EventArgs e)
        {
            if (txtInventoryID.Text == "" || txtInventoryName.Text == "" || nudInventoryQuantity.Text == "" || txtUnitPrice.Text == "" || txtBarcode.Text == "" || cbxInventoryType.Text == "" || cbxUnit.Text == "")
            {
                MessageBox.Show("Please ensure that you enter a value for all of the inventory item details", "Null Values", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtInventoryID.Text != "" || txtInventoryName.Text != "" || nudInventoryQuantity.Text != "" || txtUnitPrice.Text != "" || txtBarcode.Text != "" || cbxInventoryType.Text != "" || cbxUnit.Text != "")
            {
                AddInventory();
            }

        }
        private void btnUpdateInventoryItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    if (InventoryValidation() == true)
                    {
                        var InvTypeIDQry = (from invType in db.Inventory_Item_Type
                                            where invType.Inv_Item_Type_Description.Equals(cbxInventoryType.Text)
                                            select new { invType.Inventory_Item_Type_ID }
                               ).FirstOrDefault();

                        var InvUnitIDQry = (from unit in db.Unit_Of_Measure
                                            where unit.Unit_Of_Measure_Description.Equals(cbxUnit.Text)
                                            select new { unit.Unit_Of_Measure_ID }
                                      ).FirstOrDefault();


                        db.spUpdateInventoryItem(txtInventoryName.Text, Convert.ToInt32(nudInventoryQuantity.Value), Convert.ToInt32(txtBarcode.Text), InvUnitIDQry.Unit_Of_Measure_ID, InvTypeIDQry.Inventory_Item_Type_ID, Convert.ToInt32(txtInventoryID.Text), Convert.ToDecimal(txtUnitPrice.Text), DateTime.Today, Convert.ToDateTime(lblDatePOS.Text), DateTime.Now.TimeOfDay, txtEmployeeNameProfile.Text, "Updating an Inventory Item", txtInventoryName.Text + " was updated ");

                        db.SaveChanges();

                        PopulateInvDGV();
                        PopulateAuditLogDGV();
                        MessageBox.Show("The Inventory Item has been successfully updated", "Successful Addition", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnClearInventoryItem_Click(object sender, EventArgs e)
        {
            InventoryItemID();
            txtInventoryName.Text = "";
            txtUnitPrice.Text = "";
            nudInventoryQuantity.Value = 1;
            nudInventoryQuantity.Enabled = true;
            txtBarcode.Text = "";
            cbxInventoryType.Text = "";
            cbxUnit.Text = "";

            btnAddInventoryItem.Enabled = true;
            btnUpdateInventoryItem.Enabled = false;
            btnDeleteInventoryItem.Enabled = false;

        }
        private void btnDeleteInventoryItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete?\nIf you delete this inventory item , the quantity associated with it will also be deleted.", "Confirmation for Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                    {
                        db.spDeleteInventoryItem(Convert.ToInt32(txtInventoryID.Text), Convert.ToDateTime(lblDatePOS.Text), DateTime.Now.TimeOfDay, txtEmployeeNameProfile.Text, "Deleting a Inventory", txtInventoryName.Text + "with the ID:" + txtInventoryID.Text + " was deleted" + " with" + nudInventoryQuantity.Value.ToString() + "Quantity Remaining");

                        db.SaveChanges();

                        PopulateInvDGV();
                        PopulateAuditLogDGV();
                        MessageBox.Show("The Inventory has been successfully deleted", "Successful Deletion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else return;

        }
        private void txtSearchInventoryItem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    if (cbxSearchInventoryItem.Text == "Inventory Name")
                    {
                        var dgvInvQuery = (from Items in db.Inventory_Item
                                           join Price in db.Inventory_Price
                                        on Items.Inventory_Item_ID equals Price.Inventory_Item_ID
                                           join type in db.Inventory_Item_Type
                                           on Items.Inventory_Item_Type_ID equals type.Inventory_Item_Type_ID
                                           join um in db.Unit_Of_Measure
                                           on Items.Unit_Of_Measure_ID equals um.Unit_Of_Measure_ID
                                           where Items.Inventory_Item_Name.Contains(txtSearchInventoryItem.Text)
                                           select new { Items.Inventory_Item_ID, Items.Inventory_Item_Name, Items.Inventory_Item_Barcode, Items.Inventory_Item_Quantity, Price.Inventory_Price1, type.Inv_Item_Type_Description, um.Unit_Of_Measure_Description }
                                   ).ToList();

                        dgvInventoryItem.DefaultCellStyle.ForeColor = Color.Black;
                        dgvInventoryItem.Columns.Clear();
                        dgvInventoryItem.DataSource = dgvInvQuery;
                        dgvInventoryItem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                        dgvInventoryItem.Columns[0].HeaderText = "Inventory ID";
                        dgvInventoryItem.Columns[1].HeaderText = "Item Name";
                        dgvInventoryItem.Columns[1].Width = 100;
                        dgvInventoryItem.Columns[2].HeaderText = "Item Barcode";
                        dgvInventoryItem.Columns[2].Width = 100;
                        dgvInventoryItem.Columns[3].HeaderText = "Item Quantity";
                        dgvInventoryItem.Columns[3].Width = 100;
                        dgvInventoryItem.Columns[4].HeaderText = "Price (Per Unit)";
                        dgvInventoryItem.Columns[4].Width = 100;
                        dgvInventoryItem.Columns[5].HeaderText = "Item Type";
                        dgvInventoryItem.Columns[6].HeaderText = "Unit of Measure";
                    }
                    else if (cbxSearchInventoryItem.Text == "Inventory ID")
                    {
                        var dgvInvQuery = (from Items in db.Inventory_Item
                                           join Price in db.Inventory_Price
                                        on Items.Inventory_Item_ID equals Price.Inventory_Item_ID
                                           join type in db.Inventory_Item_Type
                                           on Items.Inventory_Item_Type_ID equals type.Inventory_Item_Type_ID
                                           join um in db.Unit_Of_Measure
                                           on Items.Unit_Of_Measure_ID equals um.Unit_Of_Measure_ID
                                           where Items.Inventory_Item_ID.ToString().Contains(txtSearchInventoryItem.Text)
                                           select new { Items.Inventory_Item_ID, Items.Inventory_Item_Name, Items.Inventory_Item_Barcode, Items.Inventory_Item_Quantity, Price.Inventory_Price1, type.Inv_Item_Type_Description, um.Unit_Of_Measure_Description }
                                   ).ToList();

                        dgvInventoryItem.DefaultCellStyle.ForeColor = Color.Black;
                        dgvInventoryItem.Columns.Clear();
                        dgvInventoryItem.DataSource = dgvInvQuery;
                        dgvInventoryItem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                        dgvInventoryItem.Columns[0].HeaderText = "Inventory ID";
                        dgvInventoryItem.Columns[1].HeaderText = "Item Name";
                        dgvInventoryItem.Columns[1].Width = 100;
                        dgvInventoryItem.Columns[2].HeaderText = "Item Barcode";
                        dgvInventoryItem.Columns[2].Width = 100;
                        dgvInventoryItem.Columns[3].HeaderText = "Item Quantity";
                        dgvInventoryItem.Columns[3].Width = 100;
                        dgvInventoryItem.Columns[4].HeaderText = "Price (Per Unit)";
                        dgvInventoryItem.Columns[4].Width = 100;
                        dgvInventoryItem.Columns[5].HeaderText = "Item Type";
                        dgvInventoryItem.Columns[6].HeaderText = "Unit of Measure";
                    }
                    else if (cbxSearchInventoryItem.Text == "Inventory Barcode")
                    {
                        var dgvInvQuery = (from Items in db.Inventory_Item
                                           join Price in db.Inventory_Price
                                        on Items.Inventory_Item_ID equals Price.Inventory_Item_ID
                                           join type in db.Inventory_Item_Type
                                           on Items.Inventory_Item_Type_ID equals type.Inventory_Item_Type_ID
                                           join um in db.Unit_Of_Measure
                                           on Items.Unit_Of_Measure_ID equals um.Unit_Of_Measure_ID
                                           where Items.Inventory_Item_Barcode.Equals(Convert.ToInt32(txtSearchInventoryItem.Text))
                                           select new { Items.Inventory_Item_ID, Items.Inventory_Item_Name, Items.Inventory_Item_Barcode, Items.Inventory_Item_Quantity, Price.Inventory_Price1, type.Inv_Item_Type_Description, um.Unit_Of_Measure_Description }
                                   ).ToList();

                        dgvInventoryItem.DefaultCellStyle.ForeColor = Color.Black;
                        dgvInventoryItem.Columns.Clear();
                        dgvInventoryItem.DataSource = dgvInvQuery;
                        dgvInventoryItem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                        dgvInventoryItem.Columns[0].HeaderText = "Inventory ID";
                        dgvInventoryItem.Columns[1].HeaderText = "Item Name";
                        dgvInventoryItem.Columns[1].Width = 100;
                        dgvInventoryItem.Columns[2].HeaderText = "Item Barcode";
                        dgvInventoryItem.Columns[2].Width = 100;
                        dgvInventoryItem.Columns[3].HeaderText = "Item Quantity";
                        dgvInventoryItem.Columns[3].Width = 100;
                        dgvInventoryItem.Columns[4].HeaderText = "Price (Per Unit)";
                        dgvInventoryItem.Columns[4].Width = 100;
                        dgvInventoryItem.Columns[5].HeaderText = "Item Type";
                        dgvInventoryItem.Columns[6].HeaderText = "Unit of Measure";
                    }
                    else
                    {
                        txtSearchInventoryItem.Clear();
                        MessageBox.Show("Please select a search criteria from the drop down list.", "No search Criteria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch
            {
                txtSearchInventoryItem.Clear();
                MessageBox.Show("Error: The search cannot be performed.");
            }
        }
        #endregion

        #region Validation
        public bool InventoryValidation()
        {
            bool Validated;
            Validation v = new Validation();
            Validated = v.ValidationTextOnly(txtInventoryName.Text);
            if (Validated == true)
            {
                Validated = v.ValidationDecimal(txtUnitPrice.Text);
                if (Validated == true)
                {
                    Validated = v.ValidationNumeric(txtBarcode.Text);
                    if (Validated == true)
                    { v.ValidationTextOnly(cbxInventoryType.Text); }
                    if (Validated == true)
                    { v.ValidationTextOnly(cbxUnit.Text); }
                }
            }

            if (Validated == false)
            {
                MessageBox.Show("Error: Incorrect Data Format");
            }
            return Validated;

        }
        public bool POSValidation()
        {
            bool Validated;
            Validation v = new Validation();
            Validated = v.ValidationNumeric(txtCashFloat.Text);
            //if (Validated == true)
            //{
            //    Validated = v.ValidationDecimal(txtCash.Text);
            //}
            return Validated;

        }
        #endregion

        #region Add Inventory
        void AddInventory()
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    if (InventoryValidation() == true)
                    {
                        var InvTypeIDQry = (from invType in db.Inventory_Item_Type
                                            where invType.Inv_Item_Type_Description.Equals(cbxInventoryType.Text)
                                            select new { invType.Inventory_Item_Type_ID }
                                    ).FirstOrDefault();

                        var InvUnitIDQry = (from unit in db.Unit_Of_Measure
                                            where unit.Unit_Of_Measure_Description.Equals(cbxUnit.Text)
                                            select new { unit.Unit_Of_Measure_ID }
                                      ).FirstOrDefault();


                        db.spAddInventoryItem(txtInventoryName.Text, Convert.ToInt32(nudInventoryQuantity.Value), Convert.ToInt32(txtBarcode.Text), Convert.ToInt32(InvUnitIDQry.Unit_Of_Measure_ID), Convert.ToInt32(InvTypeIDQry.Inventory_Item_Type_ID), Convert.ToInt32(txtInventoryID.Text), Convert.ToDecimal(txtUnitPrice.Text), DateTime.Today, Convert.ToDateTime(lblDatePOS.Text), DateTime.Now.TimeOfDay, txtEmployeeNameProfile.Text, "Adding a new Inventory Item", txtInventoryName.Text + " was added at quantity:" + nudInventoryQuantity.Value.ToString());

                        db.SaveChanges();

                        PopulateInvDGV();
                        PopulateAuditLogDGV();

                        InventoryItemID();
                        txtInventoryName.Text = "";
                        txtUnitPrice.Text = "";
                        txtBarcode.Text = "";
                        cbxInventoryType.Text = "";
                        txtInventoryID.Text = "1";
                        txtInventoryID.Enabled = true;
                        cbxUnit.Text = "";

                        btnAddInventoryItem.Enabled = true;
                        btnUpdateInventoryItem.Enabled = false;
                        btnDeleteInventoryItem.Enabled = false;

                        MessageBox.Show("The new Inventory Item has been successfully added", "Successful Addition", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch
            {
                MessageBox.Show("The inventory item could not be saved. Please try again.", "Error Adding New Item", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Inventory Check In

        #endregion

        #region User Manual
        private void btnUsermanual_Click(object sender, EventArgs e)
        {
            OpenURL("https://u16232683.wixsite.com/natiusermanual");
        }
        private void OpenURL(string url)
        {
            string key = @"htmlfile\shell\open\command";
            RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey(key, false);
            // Get the default browser path on the system
            string Default_Browser_Path = ((string)registryKey.GetValue(null, null)).Split('"')[1];

            Process p = new Process();
            p.StartInfo.FileName = Default_Browser_Path;
            p.StartInfo.Arguments = url;
            p.Start();
        }
        #endregion

        #region Send Email
        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                btnSendEmail.Enabled = false;
                btnCancelOrder.Visible = true;

                message = new MailMessage();
                message.To.Add(txtSupplierOrderEmail.Text);
                message.Subject = txtSupplyOrderSubject.Text;



                message.From = new MailAddress("NatiSupermarketandTakeaway@gmail.com");

                message.Body = "Nati Supermarket and Takeaway, would like to place a new supply order for " + nudQuantityST.Text + " unit(s) of " + cbxSuppliyOrderInv.Text + ".\n" + txtSupplyOrderComment.Text;

                // set smtp details

                smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("NatiSupermarketandTakeaway@gmail.com", "NatiSupermarket0");
                smtp.SendAsync(message, message.Subject);
                smtp.SendCompleted += new SendCompletedEventHandler(smtp_SendCompleted);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                btnSendEmail.Enabled = true;
            }
        }
        void smtp_SendCompleted(object sender, AsyncCompletedEventArgs e)

        {
            if (e.Cancelled == true)
            {
                MessageBox.Show("Email sending cancelled!");
            }
            else if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else
            {
                MessageBox.Show("Email sent sucessfully!");
            }
            btnSendEmail.Enabled = true;
            btnClearInventoryItem.Visible = false;
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            {
                smtp.SendAsyncCancel();
                MessageBox.Show("Email sending cancelled!");
            }
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            if (dgvSupplierOrder.SelectedRows.Count > 0)
            {
                gbxEmailSupplyOrder.Visible = true;
                string supName = dgvSupplierOrder.SelectedRows[0].Cells[0].Value + string.Empty;
                string supSurname = dgvSupplierOrder.SelectedRows[0].Cells[1].Value + string.Empty;
                string supEmail = dgvSupplierOrder.SelectedRows[0].Cells[2].Value + string.Empty;
                string supContact = dgvSupplierOrder.SelectedRows[0].Cells[3].Value + string.Empty;


                txtSupplierOrderName.Text = supName + supSurname;
                txtSupplierOrderEmail.Text = supEmail;
                txtSupplierContact.Text = supContact;
                txtSupplyOrderSubject.Text = "Place a new supply order.";

            }
            else
            {
                MessageBox.Show("You must first select a supplier", "No Supplier Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Populate Combo boxes

        void PopMenuCbx()
        {
            using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
            {
                var cbxQuery = (from Cat in db.Menu_Item_Category
                                select new { Cat.Menu_Item_Category_Description }
                                   ).ToList();
                cbxMenuCategory.DataSource = cbxQuery;
                cbxMenuCategory.DisplayMember = "Menu_Item_Category_Description";
            }
        }
        void PopSOInventoryCbx()
        {
            using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
            {
                var cbxQuery = (from Item in db.Inventory_Item
                                select new { Item.Inventory_Item_Name }
                                   ).ToList();
                cbxSuppliyOrderInv.DataSource = cbxQuery;
                cbxSuppliyOrderInv.DisplayMember = "Inventory_Item_Name";
            }
        }
        void POPInventoryTypeCbx()
        {
            using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
            {
                var cbxQuery = (from Item in db.Inventory_Item_Type
                                select new { Item.Inv_Item_Type_Description }
                                   ).ToList();
                cbxInventoryType.DataSource = cbxQuery;
                cbxInventoryType.DisplayMember = "Inv_Item_Type_Description";
            }
        }
        void POPInventoryUnitCbx()
        {
            using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
            {
                var cbxQuery = (from unit in db.Unit_Of_Measure
                                select new { unit.Unit_Of_Measure_Description }
                                   ).ToList();
                cbxUnit.DataSource = cbxQuery;
                cbxUnit.DisplayMember = "Unit_Of_Measure_Description";
            }
        }
        void PopEmpTypeCbx()
        {
            using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
            {
                var cbxQuery = (from type in db.Employee_Type
                                select new { type.Employee_Type_Description }
                                   ).ToList();
                cbxEmployeeType.DataSource = cbxQuery;
                cbxEmployeeType.DisplayMember = "Employee_Type_Description";
            }
        }
        void PopEmpTitleCbx()
        {
            using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
            {
                var cbxQuery = (from title in db.Employee_Title
                                select new { title.Employee_Title_Description }
                                   ).ToList();
                cbxEmployeeTitle.DataSource = cbxQuery;
                cbxEmployeeTitle.DisplayMember = "Employee_Title_Description";
            }
        }
        void PopSecurityQuestionCbx()
        {
            using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
            {
                var cbxQuery = (from secQ in db.Security_Question
                                select new { secQ.Security_Question_Description }
                                   ).ToList();
                cbxSecurityQuestion.DataSource = cbxQuery;
                cbxSecurityQuestion.DisplayMember = "Security_Question_Description";
            }
        }
        #endregion

        #region Menu Item
        private void txtMenuItemSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    if (cbxSearchMenuItem.Text == "Menu ID")
                    {
                        var menuItemdgvQuery = (from mi in db.Menu_Item
                                                join mic in db.Menu_Item_Category
                                        on mi.Menu_Item_Category_ID equals mic.Menu_Item_Category_ID
                                                join mp in db.Menu_Item_Price
                                                on mi.Menu_Item_ID equals mp.Menu_Item_ID
                                                where mi.Menu_Item_ID.ToString().Contains(txtMenuItemSearch.Text)
                                                select new { mi.Menu_Item_ID, mi.Menu_Item_Name, mic.Menu_Item_Category_Description, mp.Menu_Item_Price1 }
                   ).ToList();

                        dgvMenuItemMain.DefaultCellStyle.ForeColor = Color.Black;
                        dgvMenuItemMain.Columns.Clear();
                        dgvMenuItemMain.Refresh();
                        dgvMenuItemMain.DataSource = menuItemdgvQuery;
                        dgvMenuItemMain.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                        dgvMenuItemMain.Columns[0].HeaderText = "Menu ID";
                        dgvMenuItemMain.Columns[1].HeaderText = "Name";
                        dgvMenuItemMain.Columns[1].Width = 100;
                        dgvMenuItemMain.Columns[2].HeaderText = "Category";
                        dgvMenuItemMain.Columns[2].Width = 100;
                        dgvMenuItemMain.Columns[3].HeaderText = "Price";
                    }
                    else if (cbxSearchMenuItem.Text == "Menu Category")
                    {
                        var menuItemdgvQuery = (from mi in db.Menu_Item
                                                join mic in db.Menu_Item_Category
                                        on mi.Menu_Item_Category_ID equals mic.Menu_Item_Category_ID
                                                join mp in db.Menu_Item_Price
                                                on mi.Menu_Item_ID equals mp.Menu_Item_ID
                                                where mic.Menu_Item_Category_Description.Contains(txtMenuItemSearch.Text)
                                                select new { mi.Menu_Item_ID, mi.Menu_Item_Name, mic.Menu_Item_Category_Description, mp.Menu_Item_Price1 }
                   ).ToList();

                        dgvMenuItemMain.DefaultCellStyle.ForeColor = Color.Black;
                        dgvMenuItemMain.Columns.Clear();
                        dgvMenuItemMain.Refresh();
                        dgvMenuItemMain.DataSource = menuItemdgvQuery;
                        dgvMenuItemMain.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                        dgvMenuItemMain.Columns[0].HeaderText = "Menu ID";
                        dgvMenuItemMain.Columns[1].HeaderText = "Name";
                        dgvMenuItemMain.Columns[1].Width = 100;
                        dgvMenuItemMain.Columns[2].HeaderText = "Category";
                        dgvMenuItemMain.Columns[2].Width = 100;
                        dgvMenuItemMain.Columns[3].HeaderText = "Price";
                    }
                    else
                    {
                        txtMenuItemSearch.Clear();
                        MessageBox.Show("Please select a search criteria from the drop down list.", "No search Criteria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception myErr)
            {
                txtMenuItemSearch.Clear();
                MessageBox.Show("Error: " + myErr.Message);
            }
        }
        private void btnAddNewMenu_Click(object sender, EventArgs e)
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    var MenuCatIDQry = (from cat in db.Menu_Item_Category
                                        where cat.Menu_Item_Category_Description.Equals(cbxMenuCategory.Text)
                                        select new { cat.Menu_Item_Category_ID }
                               ).FirstOrDefault();

                    db.spAddMenuItem(txtMenuItemName.Text, MenuCatIDQry.Menu_Item_Category_ID, Convert.ToInt32(txtMenuItemID.Text), Convert.ToDecimal(txtMenuItemPrice.Text), DateTime.Today, Convert.ToDateTime(lblDatePOS.Text), DateTime.Now.TimeOfDay, txtEmployeeNameProfile.Text, "Adding a new Menu Item", txtMenuItemName.Text + " was added");

                    db.SaveChanges();

                    PopulateMenItmDgv();
                    PopulateAuditLogDGV();
                    MessageBox.Show("The new Menu Item has been successfully added", "Successful Addition", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnDeleteMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    db.spDeleteMenuItem(Convert.ToInt32(txtMenuItemID.Text), Convert.ToDateTime(lblDatePOS.Text), DateTime.Now.TimeOfDay, txtEmployeeNameProfile.Text, "Deleting a Menu Item", txtMenuItemName.Text + ",ID:" + txtMenuItemID.Text + " was deleted");

                    db.SaveChanges();

                    PopulateMenItmDgv();
                    PopulateAuditLogDGV();
                    MessageBox.Show("The Menu Item has been successfully deleted", "Successful Deletion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    var MenuCatIDQry = (from cat in db.Menu_Item_Category
                                        where cat.Menu_Item_Category_Description.Equals(cbxMenuCategory.Text)
                                        select new { cat.Menu_Item_Category_ID }
                               ).FirstOrDefault();

                    db.spUpdateMenuItem(txtMenuItemName.Text, MenuCatIDQry.Menu_Item_Category_ID, Convert.ToInt32(txtMenuItemID.Text), Convert.ToDecimal(txtMenuItemPrice.Text), DateTime.Today, Convert.ToDateTime(lblDatePOS.Text), DateTime.Now.TimeOfDay, txtEmployeeNameProfile.Text, "Updating an existing Menu Item", txtMenuItemName.Text + " was updated");

                    db.SaveChanges();

                    PopulateMenItmDgv();
                    PopulateAuditLogDGV();
                    MessageBox.Show("The new Menu Item has been successfully updated", "Successful update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
            {
                var menuItemdgvQuery = (from mi in db.Menu_Item
                                        join mic in db.Menu_Item_Category
                                on mi.Menu_Item_ID equals mic.Menu_Item_Category_ID
                                        where mi.Menu_Item_Name.Contains(txtMenuItemSearch.Text)
                                        select new { mi.Menu_Item_ID, mic.Menu_Item_Category_ID, mi.Menu_Item_Name }
                               ).ToList();

                dgvMenuItemMain.Columns.Clear();
                dgvMenuItemMain.DataSource = menuItemdgvQuery;
                dgvMenuItemMain.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                //dgvMenuItem1.Columns[0].HeaderText = "Menu Item ID";
                //dgvMenuItem1.Columns[1].HeaderText = "Menu Item Category ID";
                //dgvMenuItem1.Columns[1].Width = 100;
                //dgvMenuItem1.Columns[2].HeaderText = "Menu Item Name";
                //dgvMenuItem1.Columns[2].Width = 100;
                //dgvMenuItem1.Columns[3].HeaderText = "Discount";
                //dgvMenuItem1.Columns[3].Width = 100;
                //OsManEntities Dbc = new OsManEntities();
                int MenItm = dgvMenuItemMain.CurrentCell.RowIndex;
                int itID = Convert.ToInt32(dgvMenuItemMain.Rows[MenItm].Cells[0].Value.ToString());

                int CandeleteQuery = (from TM in db.Menu_Item
                                      where TM.Menu_Item_ID == itID
                                      select TM).ToList().Count();

                if (CandeleteQuery > 0)
                {
                    MessageBox.Show("Error: Cannot Delete the Supplier");
                }
                else
                {
                    var toDelete = (from type in db.Menu_Item
                                    where type.Menu_Item_ID == itID
                                    select type).First();

                    db.Menu_Item.Remove(toDelete);

                    db.SaveChanges();
                    MessageBox.Show("Supplier Deleted Succesfully");
                    //dgvMenuItem1();
                }
            }
        }

        #endregion

        #region POS
        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    int subtotal = 0;
                    var dgvQuery = (from Items in db.Inventory_Item
                                    join Price in db.Inventory_Price
                                    on Items.Inventory_Item_ID equals Price.Inventory_Item_ID
                                    join Type in db.Inventory_Item_Type
                                    on Items.Inventory_Item_Type_ID equals Type.Inventory_Item_Type_ID
                                    where Items.Inventory_Item_Name.Contains(txtSearchPOSItem.Text)
                                    select new { Items.Inventory_Item_ID, Items.Inventory_Item_Name, Items.Inventory_Item_Quantity, Price.Inventory_Price1, subtotal }
                                   ).ToList();

                    dgvInventoryPOS.Columns.Clear();
                    dgvInventoryPOS.DataSource = dgvQuery;
                    dgvInventoryPOS.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    dgvInventoryPOS.Columns[0].HeaderText = "Inventory ID";
                    dgvInventoryPOS.Columns[1].HeaderText = "Inventory Name";
                    dgvInventoryPOS.Columns[1].Width = 100;
                    dgvInventoryPOS.Columns[2].HeaderText = "Quantity";
                    dgvInventoryPOS.Columns[2].Width = 100;
                    dgvInventoryPOS.Columns[3].HeaderText = "Price (Per Unit)";
                    dgvInventoryPOS.Columns[3].Width = 100;
                    dgvInventoryPOS.Columns[4].HeaderText = "Subtotal";
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }

        }
        private void btnAddInventory_Click(object sender, EventArgs e)
        {
            this.Hide();
            POSInventoryForm frmPOSInv = new POSInventoryForm();
            frmPOSInv.Show();
        }

        private void btnAddMenu_Click(object sender, EventArgs e)
        {

            cbxSearchAddItem.Items.Clear();
            cbxSearchAddItem.Items.Add("Menu ID");
            cbxSearchAddItem.Items.Add("Menu Name");
            cbxSearchAddItem.Items.Add("Menu Category");
            gbxAddPOSItem.Visible = true;
            gbxEnterCash.Visible = false;
            lblFoodOrderNote.Visible = true;
            txtFoodOrderNote.Visible = true;
            PopulatemenuPOSDGV();
            lblSelectItem.Text = "Select Menu Item";
            btnAddPOSItem.Text = "Add Menu Item";
        }

        private void btnAddInventory_Click_1(object sender, EventArgs e)
        {
            cbxSearchAddItem.Items.Clear();
            cbxSearchAddItem.Items.Add("Inventory ID");
            cbxSearchAddItem.Items.Add("Inventory Name");
            cbxSearchAddItem.Items.Add("Inventory Type");
            gbxAddPOSItem.Visible = true;
            gbxEnterCash.Visible = false;
            lblFoodOrderNote.Visible = false;
            txtFoodOrderNote.Visible = false;
            PopulateInvPOSDGV();
            lblSelectItem.Text = "Select Inventory Item";
            btnAddPOSItem.Text = "Add Inventory Item";

        }

        private void btnAddPOSItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnAddPOSItem.Text == "Add Inventory Item")
                {

                    int ID = Convert.ToInt32(dgvAddItem.SelectedRows[0].Cells[0].Value);
                    string Name = dgvAddItem.SelectedRows[0].Cells[1].Value + string.Empty;
                    int Quantity = Convert.ToInt32(txtPOSQuantity.Text);
                    double Price = Convert.ToDouble(dgvAddItem.SelectedRows[0].Cells[3].Value);
                    int OldQuantity = Convert.ToInt32(dgvAddItem.SelectedRows[0].Cells[4].Value);
                    double subtotal = Quantity * Price;
                    subTotal += Convert.ToDouble(subtotal);
                    lblSubTotal.Text = "R" + subTotal.ToString();
                    newVAT += subTotal * VAT;
                    lblVat.Text = "R" + newVAT.ToString();
                    Total = subTotal + newVAT;
                    lblTotal.Text = "R" + Total.ToString();

                    foreach (DataGridViewRow row in dgvInventoryPOS.Rows)
                    {

                        if (row.Cells[0].Value.ToString().Contains(Name))
                        {
                            
                        }
                    }

                    if (OldQuantity > Quantity & OldQuantity > 0)
                    {
                        dgvInventoryPOS.ForeColor = Color.Black;
                        dgvInventoryPOS.Rows.Add(Name, Quantity, Price, subtotal, ID, OldQuantity);
                    }
                    else
                    {
                        MessageBox.Show("There is less quantity in recorded than the quantity you are trying to sell.\nPlease enter a lower quantity.");
                    }
                }
                else if (btnAddPOSItem.Text == "Add Menu Item")
                {
                    int ID = Convert.ToInt32(dgvAddItem.SelectedRows[0].Cells[0].Value);
                    string Name = dgvAddItem.SelectedRows[0].Cells[1].Value + string.Empty;
                    int Quantity = Convert.ToInt32(txtPOSQuantity.Text);
                    decimal Price = Convert.ToDecimal(dgvAddItem.SelectedRows[0].Cells[3].Value);
                    string Note = txtFoodOrderNote.Text;
                    decimal subtotal = Quantity * Price;
                    subTotal += Convert.ToInt32(subtotal);
                    lblSubTotal.Text = "R" + subTotal.ToString();
                    newVAT += subTotal * VAT;
                    lblVat.Text = "R" + newVAT.ToString();
                    Total = subTotal + newVAT;
                    lblTotal.Text = "R" + Total.ToString();

                    dgvFoodPOS.ForeColor = Color.Black;
                    dgvFoodPOS.Rows.Add(Name, Quantity, Price, Note, subtotal, ID);
                }
            }
            catch
            {
                MessageBox.Show("The item could not be added.");
            }
        }
        private void btnFinaliseSale_Click(object sender, EventArgs e)
        {
            txtTotalSaleAmount.Text = lblTotal.Text.Remove(0, 1);

            txtTotalSaleAmount.Enabled = false;
            gbxAddPOSItem.Visible = false;

            gbxEnterCash.Visible = true;
            gbxEnterCash.Enabled = true;
        }
        private void btnVoidMenuLine_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedRowCount = dgvInventoryPOS.Rows.GetRowCount(DataGridViewElementStates.Selected);
                if (selectedRowCount > 0)
                {
                    for (int i = 0; i < selectedRowCount; i++)
                    {
                        dgvInventoryPOS.Rows.RemoveAt(dgvInventoryPOS.SelectedRows[0].Index);
                        decimal subtotal = Convert.ToDecimal(lblSubTotal.Text) - Convert.ToDecimal(dgvInventoryItem.SelectedRows[0].Cells[3].Value);
                        lblSubTotal.Text = subtotal.ToString();
                    }
                }
            }
            catch
            {
                MessageBox.Show("The item could not be voided");
            }

        }
        private void btn_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedRowCount = dgvFoodPOS.Rows.GetRowCount(DataGridViewElementStates.Selected);
                if (selectedRowCount > 0)
                {
                    for (int i = 0; i < selectedRowCount; i++)
                    {
                        dgvFoodPOS.Rows.RemoveAt(dgvFoodPOS.SelectedRows[0].Index);

                    }
                }
            }
            catch
            {
                MessageBox.Show("The item could not be voided");
            }

        }
        #endregion

        #region Recipe
        private void btnAddRecipe_Click(object sender, EventArgs e)
        {
            try
            {
                // Example #1: Write an array of strings to a file.
                // Create a string array that consists of three lines.
                string[] lines = { "Recipe Name:" + txtRecipeName.Text, " ", "Ingredients:", txtIngredients.Text, " ", "Directions:", txtDirection.Text, " ", "Note:", txtNote.Text };
                // WriteAllLines creates a file, writes a collection of strings to the file,
                // and then closes the file.  You do NOT need to call Flush() or Close().
                System.IO.File.WriteAllLines(@"C:\Users\Prince\Documents\Recipes\" + txtRecipeName.Text + ".txt", lines);

                MessageBox.Show("Your recipe has been successfully saved");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex);
            }
        }

        private void btnBrowseRecipes_Click(object sender, EventArgs e)
        {
            try
            {
                gbxViewTextRecipes.Visible = true;
                gbxViewVideoReceipt.Visible = false;
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.InitialDirectory = @"C:\Users\Prince\Documents\Visual Studio 2015\Projects\Nati Supermarket and Takeaway WinForms _Final_\Nati Supermarket and Takeaway WinForms\Recipes";

                openFileDialog1.Title = "Browse Text Files";

                openFileDialog1.CheckFileExists = true;

                openFileDialog1.CheckPathExists = true;

                openFileDialog1.DefaultExt = "txt";

                openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                openFileDialog1.FilterIndex = 2;

                openFileDialog1.RestoreDirectory = true;

                openFileDialog1.ReadOnlyChecked = true;

                openFileDialog1.ShowReadOnly = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    System.IO.StreamReader sr = new
            System.IO.StreamReader(openFileDialog1.FileName);
                    txtViewRecipes.Text = sr.ReadToEnd();
                    //  MessageBox.Show(sr.ReadToEnd());
                    sr.Close();
                }
            }
            catch
            {
                MessageBox.Show("Could not browse for the recipe, please try again");
            }

        }
        private void btnBrowseVideoRecipe_Click(object sender, EventArgs e)
        {
            gbxViewTextRecipes.Visible = false;
            gbxViewVideoReceipt.Visible = true;

            try
            {

                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.txtVideoPath.Text = openFileDialog1.FileName;
                }
                axWindowsMediaPlayer1.URL = txtVideoPath.Text;
                axWindowsMediaPlayer1.Ctlcontrols.play();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        private void btnEndVideo_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }
        #endregion

        #region Send SMS
        private void btnSendSMS_Click(object sender, EventArgs e)
        {
            try
            {
                using (var web = new WebClient())
                {
                    string msgRecepient = txtSupplierContact.Text;
                    string msgText = "Nati Supermarket and Takeaway, would like to place a new supply order for " + nudQuantityST.Value + " unit(s) of " + cbxSuppliyOrderInv.Text + ".\n" + txtSupplyOrderComment.Text;
                    string url = "http://smsc.vianett.no/v3/send.ashx?" +
                        "src=" + msgRecepient +
                        "&dst=" + msgRecepient +
                        "&msg=" + System.Web.HttpUtility.UrlEncode(msgText, Encoding.GetEncoding("ISO-8859-1")) +
                        "&username=" + System.Web.HttpUtility.UrlEncode("towani96@yahoo.com") +
                        "&password=" + "1yav4";
                    string result = web.DownloadString(url);
                    if (result.Contains("OK"))
                    {
                        MessageBox.Show("Sms sent successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Some issue delivering", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {
                MessageBox.Show("SMS could not be sent");
            }

        }

        #endregion

        #region DashBoard Controls
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm frm = new LoginForm();
            frm.ShowDialog();
            this.Close();
        }

        #endregion

        #region Employee Picture
        void EmployeePicture()
        {
            webcam = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo VideoCaptureDevice in webcam)
            {
                cbxImageDevice.Items.Add(VideoCaptureDevice.Name);
            }
            cbxImageDevice.SelectedIndex = 0;
            btnSavePhoto.Enabled = false;
        }

        private void btnBrowsePhoto_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog2 = new OpenFileDialog();

                openFileDialog2.InitialDirectory = @"C:\Users\Prince\Documents\Visual Studio 2015\Projects\Nati Supermarket and Takeaway WinForms _Final_\Nati Supermarket and Takeaway WinForms\bin\Debug\Employee\EmployeeImages";

                openFileDialog2.Title = "Browse Employee Photos";

                openFileDialog2.CheckFileExists = true;

                openFileDialog2.CheckPathExists = true;

                openFileDialog2.DefaultExt = "jpg";

                openFileDialog2.Filter = "JPG files (*.jpg)|*.jpg|All files (*.*)|*.*";

                openFileDialog2.FilterIndex = 2;

                openFileDialog2.RestoreDirectory = true;

                openFileDialog2.ReadOnlyChecked = true;

                openFileDialog2.ShowReadOnly = true;

                if (openFileDialog2.ShowDialog() == DialogResult.OK)
                {

                    pbxEmployeePhoto.Image = new Bitmap(openFileDialog2.FileName);
                }
            }
            catch
            {
                MessageBox.Show("Could not browse the pictures");
            }


        }

        private void btnStartPhoto_Click(object sender, EventArgs e)
        {
            try
            {
                cam = new VideoCaptureDevice(webcam[cbxImageDevice.SelectedIndex].MonikerString);
                cam.NewFrame += new NewFrameEventHandler(cam_NewFrame);
                cam.Start();
                btnSavePhoto.Enabled = true;
            }
            catch
            {
                MessageBox.Show("The camera could not be started");
            }

        }

        void cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bit = (Bitmap)eventArgs.Frame.Clone();
            pbxEmployeePhoto.Image = bit;
        }
        private void btnSavePhoto_Click(object sender, EventArgs e)
        {
            try
            {
                string photoSource = Path.Combine(Application.StartupPath, @"EmployeeImages\" + txtEmpName.Text + ".jpg");


                pbxEmployeePhoto.Image.Save(photoSource);


                DialogResult dialogResult = MessageBox.Show("Photo Has Been Saved!", "Employee Photo Captured", MessageBoxButtons.OK);
                if (dialogResult == DialogResult.OK)
                {
                    cam.Stop();
                }
            }
            catch
            {
                MessageBox.Show("The photo could not be saved");
            }

        }

        #endregion

        #region Methods
        public string PasswordHash(string password)
        {

            SHA512Managed HashTool = new SHA512Managed();
            Byte[] PhraseAsByte = Encoding.UTF8.GetBytes(string.Concat(password));
            Byte[] EncryptedBytes = HashTool.ComputeHash(PhraseAsByte);
            HashTool.Clear();
            return Convert.ToBase64String(EncryptedBytes);
        }
        public static byte[] convertImagetoByte(Image x)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(x, typeof(byte[]));
            return xByte;
        }
        public static Image convertBytetoImage(byte[] x)
        {
            Byte[] byteBLOBData = new Byte[0];
            byteBLOBData = (Byte[])(x);
            System.IO.MemoryStream ms = new System.IO.MemoryStream(byteBLOBData);
            return System.Drawing.Image.FromStream(ms);
        }

        #endregion

        #region dgv Cell Content Click
        private void dgvInventoryItem_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvInventoryItem.SelectedRows.Count > 0)
                {
                    int invID = Convert.ToInt32(dgvInventoryItem.SelectedRows[0].Cells[0].Value);
                    string Name = dgvInventoryItem.SelectedRows[0].Cells[1].Value + string.Empty;
                    int Quantity = Convert.ToInt32(dgvInventoryItem.SelectedRows[0].Cells[3].Value);
                    decimal UnitPrice = Convert.ToDecimal(dgvInventoryItem.SelectedRows[0].Cells[4].Value);
                    int Barcode = Convert.ToInt32(dgvInventoryItem.SelectedRows[0].Cells[2].Value);
                    string Type = dgvInventoryItem.SelectedRows[0].Cells[5].Value + string.Empty;
                    string UnitOfMeasure = dgvInventoryItem.SelectedRows[0].Cells[6].Value + string.Empty;

                    txtInventoryID.Clear();
                    txtInventoryID.Text = invID.ToString();
                    txtInventoryID.Enabled = false;
                    txtInventoryName.Text = Name;
                    nudInventoryQuantity.Value = Quantity;
                    nudInventoryQuantity.Enabled = false;
                    txtUnitPrice.Text = UnitPrice.ToString();
                    txtBarcode.Text = Barcode.ToString();
                    cbxUnit.Text = UnitOfMeasure;
                    cbxInventoryType.Text = Type;

                    btnAddInventoryItem.Enabled = false;
                    btnUpdateInventoryItem.Enabled = true;
                    btnClearInventoryItem.Enabled = true;
                    btnDeleteInventoryItem.Enabled = true;
                }
                else
                {
                    MessageBox.Show("You must first select a inventory item", "No Inventory Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Unable to populate the text box, please try again.");
            }
        }

        private void dgvMenuItemMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvMenuItemMain.SelectedRows.Count > 0)
                {
                    int menuID = Convert.ToInt32(dgvMenuItemMain.SelectedRows[0].Cells[0].Value);
                    string menuCat = dgvMenuItemMain.SelectedRows[0].Cells[2].Value + string.Empty;
                    string menuName = dgvMenuItemMain.SelectedRows[0].Cells[1].Value + string.Empty;
                    decimal menuPrice = Convert.ToDecimal(dgvMenuItemMain.SelectedRows[0].Cells[3].Value);

                    txtMenuItemID.Clear();
                    txtMenuItemID.Text = menuID.ToString();

                    cbxMenuCategory.Text = menuCat;
                    txtMenuItemName.Text = menuName;
                    txtMenuItemPrice.Text = menuPrice.ToString();


                    btnAddNewMenu.Enabled = false;
                    btnDeleteMenuItem.Enabled = true;

                }
                else
                {
                    MessageBox.Show("You must first select a supplier", "No Supplier Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Could add the menu item");
            }

        }
        private void dgvSupplier_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvSupplier.SelectedRows.Count > 0)
                {
                    int supID = Convert.ToInt32(dgvSupplier.SelectedRows[0].Cells[0].Value);
                    string Name = dgvSupplier.SelectedRows[0].Cells[1].Value + string.Empty;
                    string Surname = dgvSupplier.SelectedRows[0].Cells[2].Value + string.Empty;
                    string Number = dgvSupplier.SelectedRows[0].Cells[3].Value + string.Empty;
                    string Telephone = dgvSupplier.SelectedRows[0].Cells[4].Value + string.Empty;
                    string Email = dgvSupplier.SelectedRows[0].Cells[5].Value + string.Empty;
                    string Location = dgvSupplier.SelectedRows[0].Cells[6].Value + string.Empty;
                    string Bank = dgvSupplier.SelectedRows[0].Cells[7].Value + string.Empty;
                    string BranchCode = dgvSupplier.SelectedRows[0].Cells[8].Value + string.Empty;
                    string AccountNumber = dgvSupplier.SelectedRows[0].Cells[9].Value + string.Empty;

                    txtSupplierID.Text = supID.ToString();
                    txtSupplierName.Text = Name;
                    txtSupplierSurname.Text = Surname;
                    txtSupplierCellphone.Text = Number;
                    txtSupplierTelepone.Text = Telephone;
                    txtSupplierEmail.Text = Email;
                    txtSupplierLocation.Text = Location;
                    txtSupplierBankName.Text = Bank;
                    txtSupplierBranchCode.Text = BranchCode;
                    txtSupplierAccountNo.Text = AccountNumber;

                    btnAddSupplier.Enabled = false;
                    btnDeleteSupplier.Enabled = true;


                }
                else
                {
                    MessageBox.Show("You must first select a supplier", "No Supplier Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Couldn't select the supplier");
            }

        }
        private void dgvInventoryStockTake_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
        private void dgvStockTakeHistory_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvStockTakeHistory.SelectedRows.Count > 0)
            {
                int Quantity = Convert.ToInt32(dgvStockTakeHistory.SelectedRows[0].Cells[2].Value);
                txtQuantityRecordedST.Text = Quantity.ToString();
                //if (Quantity == Convert.ToInt32(txtQuantityRecordedST.Text))
                //{
                //    lblStockTakeResult.Text = "Result: The stock quantity is correct.";
                //    lblStockTakeResult.ForeColor = Color.Green;
                //    btnUpdateQuantity.Enabled = false;
                //}
                //if (Quantity > Convert.ToInt32(txtQuantityRecordedST.Text))
                //{
                //    lblStockTakeResult.Text = "Result: The stock on hand is more than the quantity recorded.";
                //    lblStockTakeResult.ForeColor = Color.DarkRed;
                //    btnUpdateQuantity.Enabled = false;
                //}
                // if (Quantity < Convert.ToInt32(txtQuantityRecordedST.Text))
                //{
                //    lblStockTakeResult.Text = "Result: The stock on hand is less than the quantity recorded.";
                //    lblStockTakeResult.ForeColor = Color.DarkRed;
                //    btnUpdateQuantity.Enabled = false;
                //}
            }
            else
            {
                MessageBox.Show("Please select an inventory item", "No Inventory Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void dgvEmployee_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvEmployee.SelectedRows.Count > 0)
            {
                int ID = Convert.ToInt32(dgvEmployee.SelectedRows[0].Cells[0].Value);
                string Name = dgvEmployee.SelectedRows[0].Cells[1].Value + string.Empty;
                string Surname = dgvEmployee.SelectedRows[0].Cells[2].Value + string.Empty;
                string Address = dgvEmployee.SelectedRows[0].Cells[3].Value + string.Empty;
                string Number = dgvEmployee.SelectedRows[0].Cells[4].Value + string.Empty;
                string Email = dgvEmployee.SelectedRows[0].Cells[5].Value + string.Empty;
                string Type = dgvEmployee.SelectedRows[0].Cells[6].Value + string.Empty;
                string Title = dgvEmployee.SelectedRows[0].Cells[7].Value + string.Empty;
                string Bank = dgvEmployee.SelectedRows[0].Cells[8].Value + string.Empty;
                string BranchCode = dgvEmployee.SelectedRows[0].Cells[9].Value + string.Empty;
                string AccountNumber = dgvEmployee.SelectedRows[0].Cells[10].Value + string.Empty;
                if (dgvEmployee.SelectedRows[0].Cells[11].Value != null)
                {
                    Image Picture = convertBytetoImage((byte[])dgvEmployee.SelectedRows[0].Cells[11].Value);
                    pbxEmployeePhoto.Image = Picture;
                }
                string Question = dgvEmployee.SelectedRows[0].Cells[12].Value + string.Empty;
                string Answer = dgvEmployee.SelectedRows[0].Cells[13].Value + string.Empty;
                string Password = dgvEmployee.SelectedRows[0].Cells[14].Value + string.Empty;


                txtEmpID.Text = ID.ToString();
                txtEmpName.Text = Name;
                txtEmpSurname.Text = Surname;
                txtEmpAddress.Text = Address;
                txtEmpNumber.Text = Number;
                txtEmpEmail.Text = Email;
                cbxEmployeeType.Text = Type;
                cbxEmployeeTitle.Text = Title;
                txtEmployeeBankName.Text = Bank;
                txtEmployeeBranchCode.Text = BranchCode;
                txtEmployeeAccountNo.Text = AccountNumber;

                txtSecurityQuestion.Text = Question;
                txtSecurityQuestion.Text = Answer;
                txtLoginPassword.Text = Password;

                btnAddEmployee.Enabled = false;
                btnDeleteEmployee.Enabled = true;


            }
            else
            {
                MessageBox.Show("You must first select a Employee", "No Employee Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void dgvCheckInInventory_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // nudCheckInQuantity.Maximum = Convert.ToInt32(dgvCheckInInventory.SelectedRows[0].Cells[2].Value);
            //int InvID = Convert.ToInt32(dgvCheckInInventory.SelectedRows[0].Cells[0].Value);

            //txtCheckInInventoryID.Text = InvID.ToString();
        }

        private void dgvWriteOffInventory_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvWriteOffInventory.SelectedRows.Count > 0)
            {
                int invID = Convert.ToInt32(dgvWriteOffInventory.SelectedRows[0].Cells[0].Value);
                string Name = dgvWriteOffInventory.SelectedRows[0].Cells[1].Value + string.Empty;
                int Quantity = Convert.ToInt32(dgvWriteOffInventory.SelectedRows[0].Cells[3].Value);

                txtWriteOffID.Clear();
                txtWriteOffID.Text = invID.ToString();
                txtWriteOffID.Enabled = false;
                txtWriteoffInventoryName.Text = Name;
            }
            else
            {
                MessageBox.Show("You must first select an inventory item", "No Inventory Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region Audit Log
        private void txtSearchAuditLog_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    if (cbxSearchAuditLog.Text == "User")
                    {
                        var dgvQuery = (from log in db.Audit_Log
                                        where log.Audit_Log_User.Contains(txtSearchAuditLog.Text)
                                        select new { log.Audit_Log_ID, log.Audit_Log_User, log.Audit_Log_Date, log.Audit_Log_Time, log.Audit_Log_Transaction_Type, log.Audit_Log_Critical_Information }
                                       ).ToList();

                        dgvAuditLog.DefaultCellStyle.ForeColor = Color.Black;
                        dgvAuditLog.Columns.Clear();
                        dgvAuditLog.DataSource = dgvQuery;
                        dgvAuditLog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                        dgvAuditLog.Columns[0].HeaderText = "Audit Log ID";
                        dgvAuditLog.Columns[1].HeaderText = "User ";
                        dgvAuditLog.Columns[1].Width = 100;
                        dgvAuditLog.Columns[2].HeaderText = "Date";
                        dgvAuditLog.Columns[2].Width = 100;
                        dgvAuditLog.Columns[3].HeaderText = "Time";
                        dgvAuditLog.Columns[4].HeaderText = "Transaction Type";
                        dgvAuditLog.Columns[4].Width = 200;
                        dgvAuditLog.Columns[5].HeaderText = "Critical Information";
                        dgvAuditLog.Columns[5].Width = 300;
                    }
                    else if (cbxSearchAuditLog.Text == "Date")
                    {
                        var dgvQuery = (from log in db.Audit_Log
                                        where log.Audit_Log_Date.Value.ToString().Contains(txtSearchAuditLog.Text)
                                        select new { log.Audit_Log_ID, log.Audit_Log_User, log.Audit_Log_Date, log.Audit_Log_Time, log.Audit_Log_Transaction_Type, log.Audit_Log_Critical_Information }
                                       ).ToList();

                        dgvAuditLog.DefaultCellStyle.ForeColor = Color.Black;
                        dgvAuditLog.Columns.Clear();
                        dgvAuditLog.DataSource = dgvQuery;
                        dgvAuditLog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                        dgvAuditLog.Columns[0].HeaderText = "Audit Log ID";
                        dgvAuditLog.Columns[1].HeaderText = "User ";
                        dgvAuditLog.Columns[1].Width = 100;
                        dgvAuditLog.Columns[2].HeaderText = "Date";
                        dgvAuditLog.Columns[2].Width = 100;
                        dgvAuditLog.Columns[3].HeaderText = "Time";
                        dgvAuditLog.Columns[4].HeaderText = "Transaction Type";
                        dgvAuditLog.Columns[4].Width = 200;
                        dgvAuditLog.Columns[5].HeaderText = "Critical Information";
                        dgvAuditLog.Columns[5].Width = 300;
                    }
                    else if (cbxSearchAuditLog.Text == "Time")
                    {
                        {
                            var dgvQuery = (from log in db.Audit_Log
                                            where log.Audit_Log_Time.Value.ToString().Contains(txtSearchAuditLog.Text)
                                            select new { log.Audit_Log_ID, log.Audit_Log_User, log.Audit_Log_Date, log.Audit_Log_Time, log.Audit_Log_Transaction_Type, log.Audit_Log_Critical_Information }
                                        ).ToList();

                            dgvAuditLog.DefaultCellStyle.ForeColor = Color.Black;
                            dgvAuditLog.Columns.Clear();
                            dgvAuditLog.DataSource = dgvQuery;
                            dgvAuditLog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                            dgvAuditLog.Columns[0].HeaderText = "Audit Log ID";
                            dgvAuditLog.Columns[1].HeaderText = "User ";
                            dgvAuditLog.Columns[1].Width = 100;
                            dgvAuditLog.Columns[2].HeaderText = "Date";
                            dgvAuditLog.Columns[2].Width = 100;
                            dgvAuditLog.Columns[3].HeaderText = "Time";
                            dgvAuditLog.Columns[4].HeaderText = "Transaction Type";
                            dgvAuditLog.Columns[4].Width = 200;
                            dgvAuditLog.Columns[5].HeaderText = "Critical Information";
                            dgvAuditLog.Columns[5].Width = 300;
                        }
                    }
                    else if (cbxSearchAuditLog.Text == "Transaction Type")
                    {
                        {
                            var dgvQuery = (from log in db.Audit_Log
                                            where log.Audit_Log_Transaction_Type.Contains(txtSearchAuditLog.Text)
                                            select new { log.Audit_Log_ID, log.Audit_Log_User, log.Audit_Log_Date, log.Audit_Log_Time, log.Audit_Log_Transaction_Type, log.Audit_Log_Critical_Information }
                                        ).ToList();

                            dgvAuditLog.DefaultCellStyle.ForeColor = Color.Black;
                            dgvAuditLog.Columns.Clear();
                            dgvAuditLog.DataSource = dgvQuery;
                            dgvAuditLog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                            dgvAuditLog.Columns[0].HeaderText = "Audit Log ID";
                            dgvAuditLog.Columns[1].HeaderText = "User ";
                            dgvAuditLog.Columns[1].Width = 100;
                            dgvAuditLog.Columns[2].HeaderText = "Date";
                            dgvAuditLog.Columns[2].Width = 100;
                            dgvAuditLog.Columns[3].HeaderText = "Time";
                            dgvAuditLog.Columns[4].HeaderText = "Transaction Type";
                            dgvAuditLog.Columns[4].Width = 200;
                            dgvAuditLog.Columns[5].HeaderText = "Critical Information";
                            dgvAuditLog.Columns[5].Width = 300;
                        }
                    }
                    else
                    {
                        txtSearchAuditLog.Clear();
                        MessageBox.Show("Please select a search criteria from the drop down list.", "No search Criteria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception myErr)
            {
                txtSearchAuditLog.Clear();
                MessageBox.Show("Error: " + myErr.Message);
            }
        }

        #endregion

        #region Inventory: StockTake
        private void txtSearchStockTake_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    if (cbxSearchInventoryItem.Text == "Inventory Name")
                    {
                        var dgvQuery = (from Items in db.Inventory_Item
                                        where Items.Inventory_Item_Name.Contains(txtSearchStockTake.Text)
                                        select new { Items.Inventory_Item_ID, Items.Inventory_Item_Name, Items.Inventory_Item_Quantity }
                                   ).ToList();

                        dgvStockTakeHistory.DefaultCellStyle.ForeColor = Color.Black;
                        dgvStockTakeHistory.Columns.Clear();
                        dgvStockTakeHistory.DataSource = dgvQuery;
                        dgvStockTakeHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                        dgvStockTakeHistory.Columns[0].HeaderText = "Inventory ID";
                        dgvStockTakeHistory.Columns[1].HeaderText = "Inventory Name";
                        dgvStockTakeHistory.Columns[1].Width = 100;
                        dgvStockTakeHistory.Columns[2].HeaderText = "Quantity";
                        dgvStockTakeHistory.Columns[2].Width = 100;

                    }
                    else if (cbxSearchInventoryItem.Text == "Inventory ID")
                    {
                        var dgvQuery = (from Items in db.Inventory_Item
                                        where Items.Inventory_Item_ID.ToString().Contains(txtSearchStockTake.Text)
                                        select new { Items.Inventory_Item_ID, Items.Inventory_Item_Name, Items.Inventory_Item_Quantity }
                                   ).ToList();

                        dgvStockTakeHistory.DefaultCellStyle.ForeColor = Color.Black;
                        dgvStockTakeHistory.Columns.Clear();
                        dgvStockTakeHistory.DataSource = dgvQuery;
                        dgvStockTakeHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                        dgvStockTakeHistory.Columns[0].HeaderText = "Inventory ID";
                        dgvStockTakeHistory.Columns[1].HeaderText = "Inventory Name";
                        dgvStockTakeHistory.Columns[1].Width = 100;
                        dgvStockTakeHistory.Columns[2].HeaderText = "Quantity";
                        dgvStockTakeHistory.Columns[2].Width = 100;
                    }
                    else
                    {
                        txtSearchInventoryItem.Clear();
                        MessageBox.Show("Please select a search criteria from the drop down list.", "No search Criteria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch
            {
                txtSearchInventoryItem.Clear();
                MessageBox.Show("Error: The search could not be performed.");
            }
        }
        private void txtSearchStockTakeHistory_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    if (cbxSearchStockTakeHistory.Text == "Inventory Name")
                    {
                        var dgvQuery = (from stock in db.Stock_Take
                                        join line in db.Stock_Take_Line
                                        on stock.Stock_Take_ID equals line.Stock_Take_ID
                                        join invItem in db.Inventory_Item
                                        on line.Inventory_Item_ID equals invItem.Inventory_Item_ID
                                        where invItem.Inventory_Item_Name.Contains(txtSearchStockTakeHistory.Text)
                                        select new { stock.Stock_Take_ID, invItem.Inventory_Item_ID, invItem.Inventory_Item_Name, line.Stock_Take_Line_Type, line.Stock_Take_Line_Type_Quantity, line.Quantity_Available, stock.Stock_Take_Date, stock.Stock_Take_Time }
                                  ).ToList();

                        dgvInventoryStockTakeLine.DefaultCellStyle.ForeColor = Color.Black;
                        dgvInventoryStockTakeLine.Columns.Clear();
                        dgvInventoryStockTakeLine.DataSource = dgvQuery;
                        dgvInventoryStockTakeLine.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                        dgvInventoryStockTakeLine.Columns[0].HeaderText = "Stock Take ID";
                        dgvInventoryStockTakeLine.Columns[0].Visible = false;
                        dgvInventoryStockTakeLine.Columns[1].HeaderText = "Inventory ID";
                        dgvInventoryStockTakeLine.Columns[1].Visible = false;
                        dgvInventoryStockTakeLine.Columns[2].HeaderText = "Inventory Name";
                        dgvInventoryStockTakeLine.Columns[3].HeaderText = "Type";
                        dgvInventoryStockTakeLine.Columns[3].Width = 100;
                        dgvInventoryStockTakeLine.Columns[4].HeaderText = "Previous Quantity";
                        dgvInventoryStockTakeLine.Columns[5].HeaderText = "Quantity Currently Available";
                        dgvInventoryStockTakeLine.Columns[5].Width = 100;
                        dgvInventoryStockTakeLine.Columns[6].HeaderText = "Date Removed";
                        dgvInventoryStockTakeLine.Columns[7].HeaderText = "Time Removed";

                    }
                    else if (cbxSearchStockTakeHistory.Text == "Date")
                    {
                        var dgvQuery = (from stock in db.Stock_Take
                                        join line in db.Stock_Take_Line
                                        on stock.Stock_Take_ID equals line.Stock_Take_ID
                                        join invItem in db.Inventory_Item
                                        on line.Inventory_Item_ID equals invItem.Inventory_Item_ID
                                        where stock.Stock_Take_Date.ToString().Contains(txtSearchStockTakeHistory.Text)
                                        select new { stock.Stock_Take_ID, invItem.Inventory_Item_ID, invItem.Inventory_Item_Name, line.Stock_Take_Line_Type, line.Stock_Take_Line_Type_Quantity, line.Quantity_Available, stock.Stock_Take_Date, stock.Stock_Take_Time }
                                  ).ToList();

                        dgvInventoryStockTakeLine.DefaultCellStyle.ForeColor = Color.Black;
                        dgvInventoryStockTakeLine.Columns.Clear();
                        dgvInventoryStockTakeLine.DataSource = dgvQuery;
                        dgvInventoryStockTakeLine.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                        dgvInventoryStockTakeLine.Columns[0].HeaderText = "Stock Take ID";
                        dgvInventoryStockTakeLine.Columns[0].Visible = false;
                        dgvInventoryStockTakeLine.Columns[1].HeaderText = "Inventory ID";
                        dgvInventoryStockTakeLine.Columns[1].Visible = false;
                        dgvInventoryStockTakeLine.Columns[2].HeaderText = "Inventory Name";
                        dgvInventoryStockTakeLine.Columns[3].HeaderText = "Type";
                        dgvInventoryStockTakeLine.Columns[3].Width = 100;
                        dgvInventoryStockTakeLine.Columns[4].HeaderText = "Previous Quantity";
                        dgvInventoryStockTakeLine.Columns[5].HeaderText = "Quantity Currently Available";
                        dgvInventoryStockTakeLine.Columns[5].Width = 100;
                        dgvInventoryStockTakeLine.Columns[6].HeaderText = "Date Removed";
                        dgvInventoryStockTakeLine.Columns[7].HeaderText = "Time Removed";
                    }
                    else if (cbxSearchStockTakeHistory.Text == "Time")
                    {
                        var dgvQuery = (from stock in db.Stock_Take
                                        join line in db.Stock_Take_Line
                                        on stock.Stock_Take_ID equals line.Stock_Take_ID
                                        join invItem in db.Inventory_Item
                                        on line.Inventory_Item_ID equals invItem.Inventory_Item_ID
                                        where stock.Stock_Take_Time.ToString().Contains(txtSearchStockTakeHistory.Text)
                                        select new { stock.Stock_Take_ID, invItem.Inventory_Item_ID, invItem.Inventory_Item_Name, line.Stock_Take_Line_Type, line.Stock_Take_Line_Type_Quantity, line.Quantity_Available, stock.Stock_Take_Date, stock.Stock_Take_Time }
                                  ).ToList();

                        dgvInventoryStockTakeLine.DefaultCellStyle.ForeColor = Color.Black;
                        dgvInventoryStockTakeLine.Columns.Clear();
                        dgvInventoryStockTakeLine.DataSource = dgvQuery;
                        dgvInventoryStockTakeLine.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                        dgvInventoryStockTakeLine.Columns[0].HeaderText = "Stock Take ID";
                        dgvInventoryStockTakeLine.Columns[0].Visible = false;
                        dgvInventoryStockTakeLine.Columns[1].HeaderText = "Inventory ID";
                        dgvInventoryStockTakeLine.Columns[1].Visible = false;
                        dgvInventoryStockTakeLine.Columns[2].HeaderText = "Inventory Name";
                        dgvInventoryStockTakeLine.Columns[3].HeaderText = "Type";
                        dgvInventoryStockTakeLine.Columns[3].Width = 100;
                        dgvInventoryStockTakeLine.Columns[4].HeaderText = "Previous Quantity";
                        dgvInventoryStockTakeLine.Columns[5].HeaderText = "Quantity Currently Available";
                        dgvInventoryStockTakeLine.Columns[5].Width = 100;
                        dgvInventoryStockTakeLine.Columns[6].HeaderText = "Date Removed";
                        dgvInventoryStockTakeLine.Columns[7].HeaderText = "Time Removed";
                    }
                    else
                    {
                        txtSearchInventoryItem.Clear();
                        MessageBox.Show("Please select a search criteria from the drop down list.", "No search Criteria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch
            {
                txtSearchInventoryItem.Clear();
                MessageBox.Show("Error: The search could not be performed.");
            }
        }
        private void btnUpdateQuantity_Click(object sender, EventArgs e)
        {
            if (dgvStockTakeHistory.SelectedRows == null)
            {
                MessageBox.Show("Please select an Item from the datagridview.", "Selection not made", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    string StockTakeType = "";
                    int StockTakeTypeQuantity = 0;
                    if (Convert.ToInt32(nudQuantityST.Value) < Convert.ToInt32(txtQuantityRecordedST.Text))
                    {
                        StockTakeType = "Removed";
                        StockTakeTypeQuantity = Convert.ToInt32(txtQuantityRecordedST.Text) - Convert.ToInt32(nudQuantityST.Value);
                        db.spStockTake(Convert.ToInt32(dgvStockTakeHistory.SelectedRows[0].Cells[0].Value), Convert.ToInt32(nudQuantityST.Value), StockTakeType, StockTakeTypeQuantity, Convert.ToInt32(txtStockTakeID.Text), Convert.ToDateTime(lblDatePOS.Text), DateTime.Now.TimeOfDay, Convert.ToDateTime(lblDatePOS.Text), DateTime.Now.TimeOfDay, txtEmployeeNameProfile.Text, "Performing stock take", dgvStockTakeHistory.SelectedRows[0].Cells[0].Value.ToString() + " was updated from a quantity of " + txtQuantityRecordedST.Text + " to" + nudQuantityST.Value.ToString());
                        db.SaveChanges();

                        PopulateInvDGV();
                        PopulateInvStockTakeDGV();
                        PopulateInvStockTakeLineDGV();
                        PopulateAuditLogDGV();
                        MessageBox.Show("The Inventory Item has been successfully updated", "Successful Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else if (Convert.ToInt32(nudQuantityST.Value) > Convert.ToInt32(txtQuantityRecordedST.Text))
                    {
                        StockTakeType = "Added";
                        StockTakeTypeQuantity = Convert.ToInt32(nudQuantityST.Value) - Convert.ToInt32(txtQuantityRecordedST.Text);
                        db.spStockTake(Convert.ToInt32(dgvStockTakeHistory.SelectedRows[0].Cells[0].Value), Convert.ToInt32(nudQuantityST.Value), StockTakeType, StockTakeTypeQuantity, Convert.ToInt32(txtStockTakeID.Text), Convert.ToDateTime(lblDatePOS.Text), DateTime.Now.TimeOfDay, Convert.ToDateTime(lblDatePOS.Text), DateTime.Now.TimeOfDay, txtEmployeeNameProfile.Text, "Performing stock take", dgvStockTakeHistory.SelectedRows[0].Cells[0].Value.ToString() + " was updated from a quantity of " + txtQuantityRecordedST.Text + " to" + nudQuantityST.Value.ToString());
                        db.SaveChanges();

                        PopulateInvDGV();
                        PopulateInvStockTakeDGV();
                        PopulateInvStockTakeLineDGV();
                        PopulateAuditLogDGV();
                        MessageBox.Show("The Inventory Item has been successfully updated", "Successful Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (Convert.ToInt32(nudQuantityST.Value) == Convert.ToInt32(txtQuantityRecordedST.Text))
                    {
                        MessageBox.Show("The quantity on hand matches the quantity recorded on the database", "Stock Matches", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The update was unsuccessful.\nPlease try again.", "Unsuccessful update", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Inventory: Prepare Inventory
        private void btnInventoryCheckIn_Click(object sender, EventArgs e)
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    string StockTakeType = "";
                    int StockTakeTypeQuantity = 0;
                    if (Convert.ToInt32(nudQuantityST.Value) < Convert.ToInt32(txtQuantityRecordedST.Text))
                    {
                        StockTakeType = "Removed";
                        StockTakeTypeQuantity = Convert.ToInt32(txtQuantityRecordedST.Text) - Convert.ToInt32(nudQuantityST.Value);
                        db.spStockTake(Convert.ToInt32(dgvStockTakeHistory.SelectedRows[0].Cells[0].Value), Convert.ToInt32(nudQuantityST.Value), StockTakeType, StockTakeTypeQuantity, Convert.ToInt32(txtStockTakeID.Text), Convert.ToDateTime(lblDatePOS.Text), DateTime.Now.TimeOfDay, Convert.ToDateTime(lblDatePOS.Text), DateTime.Now.TimeOfDay, txtEmployeeNameProfile.Text, "Performing stock take", dgvStockTakeHistory.SelectedRows[0].Cells[0].Value.ToString() + " was updated from a quantity of " + txtQuantityRecordedST.Text + " to" + nudQuantityST.Value.ToString());
                        db.SaveChanges();

                        PopulateInvDGV();
                        PopulateInvStockTakeDGV();
                        PopulateInvStockTakeLineDGV();
                        PopulateAuditLogDGV();
                        MessageBox.Show("The Inventory Item has been successfully updated", "Successful Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else if (Convert.ToInt32(nudQuantityST.Value) > Convert.ToInt32(txtQuantityRecordedST.Text))
                    {
                        StockTakeType = "Added";
                        StockTakeTypeQuantity = Convert.ToInt32(nudQuantityST.Value) - Convert.ToInt32(txtQuantityRecordedST.Text);
                        db.spStockTake(Convert.ToInt32(dgvStockTakeHistory.SelectedRows[0].Cells[0].Value), Convert.ToInt32(nudQuantityST.Value), StockTakeType, StockTakeTypeQuantity, Convert.ToInt32(txtStockTakeID.Text), Convert.ToDateTime(lblDatePOS.Text), DateTime.Now.TimeOfDay, Convert.ToDateTime(lblDatePOS.Text), DateTime.Now.TimeOfDay, txtEmployeeNameProfile.Text, "Performing stock take", dgvStockTakeHistory.SelectedRows[0].Cells[0].Value.ToString() + " was updated from a quantity of " + txtQuantityRecordedST.Text + " to" + nudQuantityST.Value.ToString());
                        db.SaveChanges();

                        PopulateInvDGV();
                        PopulateInvStockTakeDGV();
                        PopulateInvStockTakeLineDGV();
                        PopulateAuditLogDGV();
                        MessageBox.Show("The Inventory Item has been successfully updated", "Successful Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (Convert.ToInt32(nudQuantityST.Value) == Convert.ToInt32(txtQuantityRecordedST.Text))
                    {
                        MessageBox.Show("The quantity on hand matches the quantity recorded on the database", "Stock Matches", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The update was unsuccessful.\nPlease try again.", "Unsuccessful update", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Inventory: WriteOff
        private void btnWriteOffInventory_Click(object sender, EventArgs e)
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    if (Convert.ToInt32(dgvWriteOffInventory.SelectedRows[0].Cells[2].Value) >= Convert.ToInt32(nudWriteoffQuantity.Value))
                    {
                        db.spWriteOff(Convert.ToInt32(txtWriteOffID.Text), txtReason.Text, DateTime.Today.Date, Convert.ToInt32(txtWriteOffID.Text), Convert.ToInt32(nudWriteoffQuantity.Value), Convert.ToInt32(dgvWriteOffInventory.SelectedRows[0].Cells[2].Value), DateTime.Today.Date, DateTime.Now.TimeOfDay, txtEmployeeNameProfile.Text, "Writting off Inventory", txtInventoryName.Text + "was written off by:" + nudWriteoffQuantity.Value.ToString());
                        db.SaveChanges();

                    }
                    PopulateInvStockTakeDGV();
                    PopulateInvPOSDGV();
                    PopulateWriteOffHistoryDGV();
                    PopulateInvDGV();
                    PopulateWriteOffInvDGV();
                    PopulateAuditLogDGV();

                    MessageBox.Show("The Inventory has been successfully written off", "Successful Writting Off", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #region Receipt
        private void dgvInventoryPOS_MouseClick(object sender, MouseEventArgs e)
        {
            //List<items> item = new List<items>();
            //using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
            //{
            //    var SalesItemdgvQuery = (from t in db.Sales
            //                             join w in db.Inventory_Item
            //                            on t.Sales_ID equals w.Inventory_Item_ID
            //                             join x in db.Sales_Line
            //                            on w.Inventory_Item_ID equals x.Inventory_Item_ID
            //                             select new { t.Sales_ID, w.Inventory_Item_Name, x.Sales_Line_Quantity, w.Inventory_Price }
            //                   ).ToList();
            //}
            //    foreach (var item in SalesItemdgvQuery)
            //    { }
            //dgvInventoryPOS.SelectedRows.ToString().ToList();
            //txtName.Text. + txtPrice.Text
        }

        private void dgvFoodPOS_MouseClick(object sender, MouseEventArgs e)
        {
            ////List<menuitemdgv>
            //using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
            //{
            //    var menuItemdgvQuery = (from s in db.Sales
            //                            join f in db.Food_Order_Line
            //                            on s.Sales_ID equals f.Sales_ID
            //                            join m in db.Menu_Item
            //                           on f.Menu_Item_ID equals m.Menu_Item_ID
            //                            select new { s.Sales_ID, f.Menu_Item_ID, f.Note, m.Menu_Item_Price }
            //                   ).ToList();
            //    foreach (var item in menuItemdgvQuery)
            //    {

            //        lbxReceipt.Items.Add(item.Note.ToString().PadRight(30) + item.Menu_Item_Price);
            //        //txtName.Text. + txtPrice.Text
            //    }
            //}
        }

        private void btnRemoveReceiptItem_Click(object sender, EventArgs e)
        {
            try
            {
                lbxReceipt.Items.RemoveAt(lbxReceipt.SelectedIndex);
            }
            catch (Exception)
            {

                return;
            }
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            try
            {
                lbxReceipt.Items.Clear();
            }
            catch
            {
                return;
            }

        }


        private void groupBox32_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //This is the Check Out/Print Button
            try
            {
                Print();
                gbxAddPOSItem.Visible = false;
                gbxEnterCash.Visible = false;
                dgvInventoryPOS.Rows.Clear();
                dgvInventoryPOS.Rows.Clear();
            }
            catch
            {
                MessageBox.Show("The reciept could not be printed. Please try again.");
            }
        }
        private void Print()
        {
            {
                PrintPreviewDialog printDialog = new PrintPreviewDialog();
                //printPreviewDialog1 printDialog = new  
                PrintDocument printDocument = new PrintDocument();

                printDialog.Document = printDocument; //add the document to the dialog box...        

                printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(CreateReceipt); //add an event handler that will do the printing

                //on a till you will not want to ask the user where to print but this is fine for the test envoironment.

                DialogResult result = printDialog.ShowDialog();


                if (result == DialogResult.OK)
                {
                    printDocument.Print();

                }

            }
        }
        public void CreateReceipt(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            int total = 0;
            float cash = float.Parse(txtCash.Text);
            float change = 0.00f;
            string vat = lblVat.Text.Remove(0, 1);


            //this prints the reciept

            Graphics graphic = e.Graphics;

            Font font = new Font("Courier New", 12); //must use a mono spaced font as the spaces need to line up

            float fontHeight = font.GetHeight();

            int startX = 10;
            int startY = 10;
            int offset = 40;

            graphic.DrawString("Nati Supermarket & Take Away", new Font("Courier New", 18), new SolidBrush(Color.Black), startX, startY);
            string top = "Items".PadRight(30) + "Price";
            graphic.DrawString(top, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight; //make the spacing consistent
            graphic.DrawString("----------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 5; //make the spacing consistent

            float totalprice = 0.00f;

            foreach (string item in lbxReceipt.Items)
            {
                //create the string to print on the reciept
                string productDescription = item;
                string productTotal = item.Substring(item.Length - 6, 6);
                float productPrice = float.Parse(item.Substring(item.Length - 5, 5));

                MessageBox.Show(item.Substring(item.Length - 5, 5) + "PROD TOTAL: " + productTotal);


                totalprice += productPrice;

                if (productDescription.Contains("  -"))
                {
                    string productLine = productDescription.Substring(0, 24);

                    graphic.DrawString(productLine, new Font("Courier New", 12, FontStyle.Italic), new SolidBrush(Color.Red), startX, startY + offset);

                    offset = offset + (int)fontHeight + 5; //make the spacing consistent
                }
                else
                {
                    string productLine = productDescription;

                    graphic.DrawString(productLine, font, new SolidBrush(Color.Black), startX, startY + offset);

                    offset = offset + (int)fontHeight + 5; //make the spacing consistent
                }

            }

            change = (cash - totalprice);
            txtChange.Text = change.ToString();
            //lblVat.Text.Remove(0, 1);


            //when we have drawn all of the items add the total

            offset = offset + 20; //make some room so that the total stands out.

            graphic.DrawString("Total to pay ".PadRight(30) + String.Format("{0:c}", totalprice), new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);

            offset = offset + 30; //make some room so that the total stands out.
            graphic.DrawString("CASH ".PadRight(30) + String.Format("{0:c}", cash), font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 15;
            graphic.DrawString("CHANGE ".PadRight(30) + String.Format("{0:c}", change), font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 30; //make some room so that the total stands out.
            graphic.DrawString("     Thank you for supporting us,", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 15;
            graphic.DrawString("       please come back soon!", font, new SolidBrush(Color.Black), startX, startY + offset);

        }

        private void lbxReceipt_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region Misc
        private void btnRecievePayment_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow rowInv in dgvInventoryPOS.Rows)
                {
                    int newQuantity = Convert.ToInt32(rowInv.Cells[5].Value) - Convert.ToInt32(rowInv.Cells[2].Value);
                    lbxReceipt.Items.Add(rowInv.Cells[0].Value.ToString().PadRight(30) + rowInv.Cells[2].Value.ToString());

                    using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                    {
                        db.spAddInventorySale(DateTime.Now.TimeOfDay, DateTime.Now.Date, 1, 1, Convert.ToInt32(txtEmployeeID.Text), Convert.ToInt32(txtSalesID.Text), Convert.ToInt32(rowInv.Cells[4].Value), Convert.ToInt32(rowInv.Cells[2].Value), newQuantity, DateTime.Today.Date, DateTime.Now.TimeOfDay, txtEmployeeNameProfile.Text, "A new sale was added", rowInv.Cells[0].Value.ToString() + " was sold at a quantity of:" + Convert.ToInt32(rowInv.Cells[2].Value) + ".The new quantity is " + newQuantity.ToString());

                        db.SaveChanges();

                        DailySales();
                        PopulateSaleHistoryDgv();
                        PopulateInvDGV();
                        PopulateAuditLogDGV();
                    }
                }
                foreach (DataGridViewRow rowFood in dgvFoodPOS.Rows)
                {
                    lbxReceipt.Items.Add(rowFood.Cells[0].Value.ToString().PadRight(30) + rowFood.Cells[2].Value.ToString());

                    using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                    {
                        db.spAddFoodSale(DateTime.Now.TimeOfDay, DateTime.Now.Date, 2, 2, Convert.ToInt32(txtEmployeeID.Text), Convert.ToInt32(txtSalesID.Text), Convert.ToInt32(rowFood.Cells[5].Value), Convert.ToString(rowFood.Cells[3].Value), Convert.ToInt32(rowFood.Cells[2].Value), DateTime.Today.Date, DateTime.Now.TimeOfDay, txtEmployeeNameProfile.Text, "A new sale was added", rowFood.Cells[0].Value.ToString() + " was sold at a quantity of:" + Convert.ToInt32(rowFood.Cells[2].Value));

                        db.SaveChanges();

                        DailySales();
                        PopulateFoodSaleHistoryDgv();
                        PopulateInvDGV();
                        PopulateAuditLogDGV();
                    }
                }
                MessageBox.Show("The sale has been successfully recorded.");
                btnPrintReceipt.Enabled = true;
                gbxEnterCash.Visible = false;
            }
            catch
            {
                MessageBox.Show("The sale could not be processed", "Please Try Again", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAddCashFloat_Click(object sender, EventArgs e)
        {

            if (POSValidation() == true)
            {
                txtCashFloat.Enabled = false;
                btnAddCashFloat.Visible = false;
                gbxSalesLine.Visible = true;
                lblMessagePOS.Visible = false;
            }
            if (POSValidation() == false)
            {
                MessageBox.Show("Incorrect data format.", "Invalid Data ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (txtCashFloat.Text == "" || txtCashFloat.Text == null)
            {
                MessageBox.Show("Please enter a valid value for the cash float.", "Missing Data ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void txtSearchPOSItem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    if (cbxSearchAddItem.Text == "Inventory ID")
                    {
                        var dgvQuery = (from Items in db.Inventory_Item
                                        join Price in db.Inventory_Price
                                        on Items.Inventory_Item_ID equals Price.Inventory_Item_ID
                                        join Type in db.Inventory_Item_Type
                                        on Items.Inventory_Item_Type_ID equals Type.Inventory_Item_Type_ID
                                        where Items.Inventory_Item_ID.ToString().Contains(txtSearchPOSItem.Text)
                                        select new { Items.Inventory_Item_ID, Items.Inventory_Item_Name, Type.Inv_Item_Type_Description, Price.Inventory_Price1 }
                                   ).ToList();

                        dgvAddItem.DefaultCellStyle.ForeColor = Color.Black;
                        dgvAddItem.Columns.Clear();
                        dgvAddItem.DataSource = dgvQuery;
                        dgvAddItem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                        dgvAddItem.Columns[0].HeaderText = "Inventory ID";
                        dgvAddItem.Columns[1].HeaderText = "Inventory Name";
                        dgvAddItem.Columns[1].Width = 100;
                        dgvAddItem.Columns[2].HeaderText = "Type";
                        dgvAddItem.Columns[2].Width = 100;
                        dgvAddItem.Columns[3].HeaderText = "Price (Per Unit)";
                    }
                    else if (cbxSearchAddItem.Text == "Inventory Name")
                    {
                        var dgvQuery = (from Items in db.Inventory_Item
                                        join Price in db.Inventory_Price
                                        on Items.Inventory_Item_ID equals Price.Inventory_Item_ID
                                        join Type in db.Inventory_Item_Type
                                        on Items.Inventory_Item_Type_ID equals Type.Inventory_Item_Type_ID
                                        where Items.Inventory_Item_Name.Contains(txtSearchPOSItem.Text)
                                        select new { Items.Inventory_Item_ID, Items.Inventory_Item_Name, Type.Inv_Item_Type_Description, Price.Inventory_Price1 }
                                   ).ToList();

                        dgvAddItem.DefaultCellStyle.ForeColor = Color.Black;
                        dgvAddItem.Columns.Clear();
                        dgvAddItem.DataSource = dgvQuery;
                        dgvAddItem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                        dgvAddItem.Columns[0].HeaderText = "Inventory ID";
                        dgvAddItem.Columns[1].HeaderText = "Inventory Name";
                        dgvAddItem.Columns[1].Width = 100;
                        dgvAddItem.Columns[2].HeaderText = "Type";
                        dgvAddItem.Columns[2].Width = 100;
                        dgvAddItem.Columns[3].HeaderText = "Price (Per Unit)";
                    }
                    else if (cbxSearchAddItem.Text == "Inventory Type")
                    {
                        var dgvQuery = (from Items in db.Inventory_Item
                                        join Price in db.Inventory_Price
                                        on Items.Inventory_Item_ID equals Price.Inventory_Item_ID
                                        join Type in db.Inventory_Item_Type
                                        on Items.Inventory_Item_Type_ID equals Type.Inventory_Item_Type_ID
                                        where Type.Inv_Item_Type_Description.Contains(txtSearchPOSItem.Text)
                                        select new { Items.Inventory_Item_ID, Items.Inventory_Item_Name, Type.Inv_Item_Type_Description, Price.Inventory_Price1 }
                                   ).ToList();

                        dgvAddItem.DefaultCellStyle.ForeColor = Color.Black;
                        dgvAddItem.Columns.Clear();
                        dgvAddItem.DataSource = dgvQuery;
                        dgvAddItem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                        dgvAddItem.Columns[0].HeaderText = "Inventory ID";
                        dgvAddItem.Columns[1].HeaderText = "Inventory Name";
                        dgvAddItem.Columns[1].Width = 100;
                        dgvAddItem.Columns[2].HeaderText = "Type";
                        dgvAddItem.Columns[2].Width = 100;
                        dgvAddItem.Columns[3].HeaderText = "Price (Per Unit)";
                    }
                    else if (cbxSearchAddItem.Text == "Menu ID")
                    {
                        var dgvQuery = (from Items in db.Menu_Item
                                        join Price in db.Menu_Item_Price
                                        on Items.Menu_Item_ID equals Price.Menu_Item_ID
                                        join Cat in db.Menu_Item_Category
                                        on Items.Menu_Item_Category_ID equals Cat.Menu_Item_Category_ID
                                        where Items.Menu_Item_ID.ToString().Contains(txtSearchPOSItem.Text)
                                        select new { Items.Menu_Item_ID, Items.Menu_Item_Name, Cat.Menu_Item_Category_Description, Price.Menu_Item_Price1 }
                                  ).ToList();

                        dgvAddItem.DefaultCellStyle.ForeColor = Color.Black;
                        dgvAddItem.Columns.Clear();
                        dgvAddItem.DataSource = dgvQuery;
                        dgvAddItem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                        dgvAddItem.Columns[0].HeaderText = "Menu ID";
                        dgvAddItem.Columns[1].HeaderText = "Menu Name";
                        dgvAddItem.Columns[1].Width = 100;
                        dgvAddItem.Columns[3].HeaderText = "Price (Per Unit)";
                        dgvAddItem.Columns[3].Width = 100;
                        dgvAddItem.Columns[2].HeaderText = "Category";
                        dgvAddItem.Columns[2].Width = 100;
                    }
                    else if (cbxSearchAddItem.Text == "Menu Name")
                    {
                        var dgvQuery = (from Items in db.Menu_Item
                                        join Price in db.Menu_Item_Price
                                        on Items.Menu_Item_ID equals Price.Menu_Item_ID
                                        join Cat in db.Menu_Item_Category
                                        on Items.Menu_Item_Category_ID equals Cat.Menu_Item_Category_ID
                                        where Items.Menu_Item_Name.Contains(txtSearchPOSItem.Text)
                                        select new { Items.Menu_Item_ID, Items.Menu_Item_Name, Cat.Menu_Item_Category_Description, Price.Menu_Item_Price1 }
                                 ).ToList();

                        dgvAddItem.DefaultCellStyle.ForeColor = Color.Black;
                        dgvAddItem.Columns.Clear();
                        dgvAddItem.DataSource = dgvQuery;
                        dgvAddItem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                        dgvAddItem.Columns[0].HeaderText = "Menu ID";
                        dgvAddItem.Columns[1].HeaderText = "Menu Name";
                        dgvAddItem.Columns[1].Width = 100;
                        dgvAddItem.Columns[3].HeaderText = "Price (Per Unit)";
                        dgvAddItem.Columns[3].Width = 100;
                        dgvAddItem.Columns[2].HeaderText = "Category";
                        dgvAddItem.Columns[2].Width = 100;
                    }
                    else if (cbxSearchAddItem.Text == "Menu Category")
                    {
                        var dgvQuery = (from Items in db.Menu_Item
                                        join Price in db.Menu_Item_Price
                                        on Items.Menu_Item_ID equals Price.Menu_Item_ID
                                        join Cat in db.Menu_Item_Category
                                        on Items.Menu_Item_Category_ID equals Cat.Menu_Item_Category_ID
                                        where Cat.Menu_Item_Category_Description.Contains(txtSearchPOSItem.Text)
                                        select new { Items.Menu_Item_ID, Items.Menu_Item_Name, Cat.Menu_Item_Category_Description, Price.Menu_Item_Price1 }
                                 ).ToList();

                        dgvAddItem.DefaultCellStyle.ForeColor = Color.Black;
                        dgvAddItem.Columns.Clear();
                        dgvAddItem.DataSource = dgvQuery;
                        dgvAddItem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                        dgvAddItem.Columns[0].HeaderText = "Menu ID";
                        dgvAddItem.Columns[1].HeaderText = "Menu Name";
                        dgvAddItem.Columns[1].Width = 100;
                        dgvAddItem.Columns[3].HeaderText = "Price (Per Unit)";
                        dgvAddItem.Columns[3].Width = 100;
                        dgvAddItem.Columns[2].HeaderText = "Category";
                        dgvAddItem.Columns[2].Width = 100;
                    }
                    else
                    {
                        txtSearchPOSItem.Clear();
                        MessageBox.Show("Please select a search criteria from the drop down list.", "No search Criteria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch
            {
                txtSearchPOSItem.Clear();
                MessageBox.Show("Error: The search cannot be performed.");
            }
        }

        private void txtCash_TextChanged(object sender, EventArgs e)
        {

            string AmountDue = txtTotalSaleAmount.Text;
            double Cash = Convert.ToDouble(txtCash.Text);
            double frmChange = Cash - Convert.ToDouble(AmountDue);
            txtChange.Text = frmChange.ToString();
        }
        #endregion

        #region Add New New 
        //Remember to take CLear button aswell as select A ACTION GROUPBOX


        //private void btnAddCategory_Click(object sender, EventArgs e)
        //{
        //gbxCatDetails.Visible = true;
        //AddMenuCategory();
        //}
        void AddMenuCategory()
        {

        }

        //private void btnSaveCategory_Click(object sender, EventArgs e)
        //{

        //}

        private void groupBox15_Enter(object sender, EventArgs e)
        {

        }

        private void dgvSupplier_CellContentClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvSupplier.SelectedRows.Count > 0)
            {
                int supID = Convert.ToInt32(dgvSupplier.SelectedRows[0].Cells[0].Value);
                string Name = dgvSupplier.SelectedRows[0].Cells[1].Value + string.Empty;
                string Surname = dgvSupplier.SelectedRows[0].Cells[2].Value + string.Empty;
                string Number = dgvSupplier.SelectedRows[0].Cells[3].Value + string.Empty;
                string Telephone = dgvSupplier.SelectedRows[0].Cells[4].Value + string.Empty;
                string Email = dgvSupplier.SelectedRows[0].Cells[5].Value + string.Empty;
                string Location = dgvSupplier.SelectedRows[0].Cells[6].Value + string.Empty;
                string Bank = dgvSupplier.SelectedRows[0].Cells[7].Value + string.Empty;
                string BranchCode = dgvSupplier.SelectedRows[0].Cells[8].Value + string.Empty;
                string AccountNumber = dgvSupplier.SelectedRows[0].Cells[9].Value + string.Empty;

                txtSupplierID.Text = supID.ToString();
                txtSupplierName.Text = Name;
                txtSupplierSurname.Text = Surname;
                txtSupplierCellphone.Text = Number;
                txtSupplierTelepone.Text = Telephone;
                txtSupplierEmail.Text = Email;
                txtSupplierLocation.Text = Location;
                txtSupplierBankName.Text = Bank;
                txtSupplierBranchCode.Text = BranchCode;
                txtSupplierAccountNo.Text = AccountNumber;

                btnAddSupplier.Enabled = false;
                btnDeleteSupplier.Enabled = true;


            }
            else
            {
                MessageBox.Show("You must first select a supplier", "No Supplier Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        void PopulatedgvSupplyPaymentOrder()
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    var dgvSupplyQuery = (from Items in db.Suppliers
                                          join s in db.Supplier_Order
                                          on Items.Supplier_ID equals s.Supplier_ID
                                          join h in db.Supplier_Order_List
                                          on s.Supplier_Order_ID equals h.Supplier_Order_ID
                                          select new { s.Supplier_ID, Items.Supplier_Name, h.Inventory_Item, s.Supplier_Order_Quantity, s.Supplier_Payment_Date }
                                   ).ToList();

                    dgvSupplyPaymentOrder.DefaultCellStyle.ForeColor = Color.Black;
                    dgvSupplyPaymentOrder.Columns.Clear();
                    dgvSupplyPaymentOrder.DataSource = dgvSupplyQuery;
                    dgvSupplyPaymentOrder.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    dgvSupplyPaymentOrder.Columns[0].HeaderText = "ID";
                    dgvSupplyPaymentOrder.Columns[1].HeaderText = "Supplier Name";
                    dgvSupplyPaymentOrder.Columns[1].Width = 100;
                    dgvSupplyPaymentOrder.Columns[2].HeaderText = "Item";
                    dgvSupplyPaymentOrder.Columns[2].Width = 100;
                    dgvSupplyPaymentOrder.Columns[3].HeaderText = "Quantity";
                    dgvSupplyPaymentOrder.Columns[3].Width = 100;
                    dgvSupplyPaymentOrder.Columns[4].HeaderText = "Payment Date";
                    dgvSupplyPaymentOrder.Columns[4].Width = 100;

                }
            }
            catch (Exception myErr)
            {
                MessageBox.Show("Error: " + myErr.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            txtSupplierOrderID.Clear();
            txtSupplier_OrderName.Clear();
            txtSupplierOrderItem.Clear();
            txtSupplierOrderQuantity.Clear();
            //dateTimePicker1.Value.Day;

        }


        void ConfirmPassword()
        {
            if (txtConfirmPassword != txtLoginPassword)
            {
                btnAddNewEmployee.Enabled = false;
                string Password = "Password Details did not match." + "Please retry";
                MessageBox.Show(Password, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                txtConfirmPassword.Clear();
                txtLoginPassword.Clear();
            }
            else if (txtConfirmPassword == txtLoginPassword)
            {
                btnAddNewEmployee.Enabled = true;
            }
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        //private void btnLoad_Click(object sender, EventArgs e)
        //{
        //    ///Above Loads Code into Employee
        //    using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
        //    {
        //        var EmpRepQuery = (from q in db.Employees
        //                           join sh in db.Employee_Shift
        //                           on q.Employee_ID equals sh.Shift_ID
        //                           where sh.Start_Time.Equals(dtFromDate.Value) + sh.End_Time.Equals(dtToDate.Value)
        //                           select new { q.Employee_Name, q.Employee_Picture, sh.Start_Time, sh.End_Time, sh.Date }
        //                   ).ToList();


        //    }
        //}

        private void btnSaveCategory_Click(object sender, EventArgs e)
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    var MenuCatIDQry = (from cat in db.Menu_Item_Category
                                        where cat.Menu_Item_Category_Description.Equals(cbxMenuCategory.Text)
                                        select new { cat.Menu_Item_Category_ID, cat.Menu_Item_Category_Description }
                               ).FirstOrDefault();

                    db.spAddMenuCategory(txtEnterNewCategory.Text, DateTime.Today.Date, DateTime.Now.TimeOfDay, txtEmployeeNameProfile.Text, "Enterance of new category", txtEnterNewCategory.Text + " was created");

                    db.SaveChanges();
                    cbxMenuCategory.Text = txtEnterNewCategory.Text;
                }
            }
            catch (Exception ERR)
            {
                MessageBox.Show(ERR.Message, "Please select the button again", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //txtMenuItemID();
            txtMenuItemName.Text = "";
            txtMenuItemPrice.Text = "";
            ///nudInventoryQuantity.Value = 1;
            //nudInventoryQuantity.Enabled = true;
            //txtBarcode.Text = "";
            //txtBarcode.Text = "";
            cbxMenuCategory.Text = "";
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {

        }

        private void btnClearSupplierAction_Click(object sender, EventArgs e)
        {
            txtSupplierID.Clear();
            txtSupplierName.Clear();
            txtSupplierSurname.Clear();
            txtSupplierCellphone.Clear();
            txtSupplierTelepone.Clear();
            txtSupplierEmail.Clear();
            txtSupplierLocation.Clear();
            txtSupplierBankName.Clear();
            txtSupplierBranchCode.Clear();
            txtSupplierAccountNo.Clear();

            //btnUpdateSupplier.Enabled = false;
            btnDeleteSupplier.Enabled = false;
        }

        private void tabSupplier_Click(object sender, EventArgs e)
        {

        }

        private void btnAddCategory_Click_1(object sender, EventArgs e)
        {
            gbxCatDetails.Visible = true;
        }

        private void btnSaveCategory_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    var MenuCatIDQry = (from cat in db.Menu_Item_Category
                                        where cat.Menu_Item_Category_Description.Equals(cbxMenuCategory.Text)
                                        select new { cat.Menu_Item_Category_ID, cat.Menu_Item_Category_Description }
                               ).FirstOrDefault();

                    db.spAddMenuCategory(txtEnterNewCategory.Text, DateTime.Today.Date, DateTime.Now.TimeOfDay, txtEmployeeNameProfile.Text, "Enterance of new category", txtEnterNewCategory.Text + " was created");

                    db.SaveChanges();
                    PopMenuCbx();
                    gbxCatDetails.Visible = false;
                    txtEnterNewCategory.Clear();
                }
            }
            catch (Exception ERR)
            {
                MessageBox.Show(ERR.Message, "Please select the button again", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {

            //txtMenuItemID();
            txtMenuItemName.Text = "";
            txtMenuItemPrice.Text = "";
            ///nudInventoryQuantity.Value = 1;
            //nudInventoryQuantity.Enabled = true;
            //txtBarcode.Text = "";
            //txtBarcode.Text = "";
            cbxMenuCategory.Text = "";
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            txtSupplierOrderID.Clear();
            txtSupplier_OrderName.Clear();
            txtSupplierOrderItem.Clear();
            txtSupplierOrderQuantity.Clear();
            //dateTimePicker1.Value.Day;
        }

        private void dgvSupplyPaymentOrder_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            PopulatedgvSupplyPaymentOrder();
        }

        private void dgvSupplier_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvSupplier.SelectedRows.Count > 0)
                {
                    int supID = Convert.ToInt32(dgvSupplier.SelectedRows[0].Cells[0].Value);
                    string Name = dgvSupplier.SelectedRows[0].Cells[1].Value + string.Empty;
                    string Surname = dgvSupplier.SelectedRows[0].Cells[2].Value + string.Empty;
                    string Number = dgvSupplier.SelectedRows[0].Cells[3].Value + string.Empty;
                    string Telephone = dgvSupplier.SelectedRows[0].Cells[4].Value + string.Empty;
                    string Email = dgvSupplier.SelectedRows[0].Cells[5].Value + string.Empty;
                    string Location = dgvSupplier.SelectedRows[0].Cells[6].Value + string.Empty;
                    string Bank = dgvSupplier.SelectedRows[0].Cells[7].Value + string.Empty;
                    string BranchCode = dgvSupplier.SelectedRows[0].Cells[8].Value + string.Empty;
                    string AccountNumber = dgvSupplier.SelectedRows[0].Cells[9].Value + string.Empty;

                    txtSupplierID.Text = supID.ToString();
                    txtSupplierName.Text = Name;
                    txtSupplierSurname.Text = Surname;
                    txtSupplierCellphone.Text = Number;
                    txtSupplierTelepone.Text = Telephone;
                    txtSupplierEmail.Text = Email;
                    txtSupplierLocation.Text = Location;
                    txtSupplierBankName.Text = Bank;
                    txtSupplierBranchCode.Text = BranchCode;
                    txtSupplierAccountNo.Text = AccountNumber;

                    btnAddSupplier.Enabled = false;
                    btnDeleteSupplier.Enabled = true;


                }
                else
                {
                    MessageBox.Show("You must first select a supplier", "No Supplier Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                return;
            }
        }

        private void gbxAddPOSItem_Enter(object sender, EventArgs e)
        {

        }

        private void btnCompleted_Click(object sender, EventArgs e)
        {

        }

        private void tabFoodOrderScreen_Click(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {

        }

        #endregion

        void LoadCharts()
        {
            try
            {///Above Loads Code into Employee
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    var EmpRepQuery = (from q in db.Inventory_Item
                                       join sh in db.Sales_Line
                                       on q.Inventory_Item_ID equals sh.Sales_Line_Quantity
                                       //where sh.Start_Time.Equals(dtFromDate.Value) where sh.End_Time.Equals(dtToDate.Value)
                                       select new { q.Inventory_Item_Name, sh.Sales_Line_Quantity, q.Sales_Line, sh.Sale }
                               ).ToList();


                    //EmpRepQuery rpt = new EmpRepQuery();
                    // crystalReportViewer1.ReportSource = rpt;
                    //CrystalReport1 report1 = new ();
                    //report1.RecordSelectionFormula = item.Sale;
                    //report1.Subreports[0];
                    //crystalReportViewer2.ReportSource = report1;
                }
            }
            catch
            {
                MessageBox.Show("There was an error loading the graph please try again");
            }


            //internal int CarCode;
            //crystalReportViewer2 Sales = new crystalReportViewer2();
            ///crystalreportviewer1 Sales = new CrystalReport1();
            //Sales


        }

        private void gbxEnterCash_Enter(object sender, EventArgs e)
        {

        }

        #region Cash Up
        void DailySales()
        {
            try
            {
                string today = DateTime.Today.Date.ToString();
                decimal sum = 0;
                foreach (DataGridViewRow row in dgvSalesHistory.Rows)
                {
                    if (row.Cells[0].Value.ToString() == today)
                    {
                        sum += Convert.ToDecimal(row.Cells[5].Value);
                    }
                }
                foreach (DataGridViewRow row in dgvMenuSaleHistory.Rows)
                {
                    if (row.Cells[0].Value.ToString() == today)
                    {
                        sum += Convert.ToDecimal(row.Cells[5].Value);
                    }
                }
                string.Format("{0:C}", lblDailySalesValue.Text = sum.ToString().Trim());
            }
            catch
            {
                MessageBox.Show("There was no sale today.");
            }
        }
        #endregion

        private void btnCashUp_Click(object sender, EventArgs e)
        {
            lblCashInTil.Visible = true;
            lblCashInTilValue.Visible = true;
            lblDailySale.Visible = true;
            decimal CashOnHand = (NUD200.Value * 200) + (NUD100.Value * 100) + (NUD50.Value * 50) + (NUD20.Value * 20) + (NUD10.Value * 10) + (NUD5.Value * 5) + (NUD2.Value * 2) + (NUD1.Value * 1);
            lblCashInTil.Text = "Cash in Till: R";
            lblCashInTilValue.Text = CashOnHand.ToString();

            if (lblDailySalesValue.Text == lblCashInTilValue.Text)
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

        private void btnShift_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Add(tabCashUp);
            tabControl1.TabPages.Remove(tabSalesHistory);
            tabControl1.TabPages.Remove(tabPOS);
        }

        private void btnLockSystem_Click(object sender, EventArgs e)
        {
           // tabControl1.Controls.Add(tabLock);
            tabControl1.Controls.Remove(tabInventoryItem);
            tabControl1.Controls.Remove(tabMenuItem);
            tabControl1.Controls.Remove(tabSupplier);
            tabControl1.Controls.Remove(tabEmployee);
            tabControl1.Controls.Remove(tabCashUp);
            tabControl1.Controls.Remove(tabReport);
            tabControl1.Controls.Remove(tabSalesHistory);
            tabControl1.Controls.Remove(tabPOS);
            tabControl1.Controls.Remove(tabAuditLog);
            tabControl1.Controls.Remove(tabFoodOrderScreen);
            btnLockSystem.Enabled = false;
            btnLogout.Enabled = false;
            btnExit.Enabled = false;
            btnShift.Enabled = false;
        }

        private void btnUnlockSystem_Click(object sender, EventArgs e)
        {
        }
        //    try
        //    {
        //        using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
        //        {
        //            var passwordQry = (from emp in db.Employees
        //                               where emp.Employee_Name.Equals(txtEmployeeNameProfile.Text.Trim())
        //                               select new { emp.Employee_Login_Password }
        //                                     ).FirstOrDefault();

        //            if (PasswordHash(txtPassword.Text) == Convert.ToBase64String(passwordQry.Employee_Login_Password))
        //            {
        //                Access(Convert.ToInt32(txtEmployeeID.Text));
        //                tabControl1.Refresh();
        //                //tabControl1.Controls.Add(tabLock);
        //                //tabControl1.Controls.Remove(tabInventoryItem);
        //                //tabControl1.Controls.Remove(tabMenuItem);
        //                //tabControl1.Controls.Remove(tabSupplier);
        //                //tabControl1.Controls.Remove(tabEmployee);
        //                //tabControl1.Controls.Remove(tabCashUp);
        //                //tabControl1.Controls.Remove(tabReport);
        //                //tabControl1.Controls.Remove(tabSalesHistory);
        //                //tabControl1.Controls.Remove(tabPOS);
        //                //tabControl1.Controls.Remove(tabAuditLog);
        //                //tabControl1.Controls.(tabFoodOrderScreen);
        //                btnLockSystem.Enabled = true;
        //                btnLogout.Enabled = true;
        //                btnExit.Enabled = true;
        //                btnShift.Enabled = true;

        //            }
        //            else MessageBox.Show("The password you entered is incorrect.");
        //        }
        //    }
        //    catch
        //    {
        //        MessageBox.Show("The password you entered is incorrect.Please Retry");
        //    }
        //}

        private void tabLockedSystem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox20_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearchSaleHistory_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    if (cbxSearchSaleHistory.Text == "Inventory ID:")
                    {
                        var dgvQuery = (from Items in db.Inventory_Item
                                        join Price in db.Inventory_Price
                                        on Items.Inventory_Item_ID equals Price.Inventory_Item_ID
                                        join Type in db.Inventory_Item_Type
                                        on Items.Inventory_Item_Type_ID equals Type.Inventory_Item_Type_ID
                                        where Items.Inventory_Item_ID.ToString().Contains(txtSearchSaleHistory.Text)
                                        select new { Items.Inventory_Item_ID, Items.Inventory_Item_Name, Type.Inv_Item_Type_Description, Price.Inventory_Price1 }
                                   ).ToList();

                        dgvSalesHistory.DefaultCellStyle.ForeColor = Color.Black;
                        dgvSalesHistory.Columns.Clear();
                        dgvSalesHistory.DataSource = dgvQuery;
                        dgvSalesHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                        dgvSalesHistory.Columns[0].HeaderText = "Inventory ID";
                        dgvSalesHistory.Columns[1].HeaderText = "Inventory Name";
                        dgvSalesHistory.Columns[1].Width = 100;
                        dgvSalesHistory.Columns[2].HeaderText = "Type";
                        dgvSalesHistory.Columns[2].Width = 100;
                        dgvSalesHistory.Columns[3].HeaderText = "Price (Per Unit)";
                    }
                    else if (cbxSearchSaleHistory.Text == "Inventory Name:")
                    {
                        var dgvQuery = (from Items in db.Inventory_Item
                                        join Price in db.Inventory_Price
                                        on Items.Inventory_Item_ID equals Price.Inventory_Item_ID
                                        join Type in db.Inventory_Item_Type
                                        on Items.Inventory_Item_Type_ID equals Type.Inventory_Item_Type_ID
                                        where Items.Inventory_Item_Name.Contains(txtSearchSaleHistory.Text)
                                        select new { Items.Inventory_Item_ID, Items.Inventory_Item_Name, Type.Inv_Item_Type_Description, Price.Inventory_Price1 }
                                   ).ToList();

                        dgvSalesHistory.DefaultCellStyle.ForeColor = Color.Black;
                        dgvSalesHistory.Columns.Clear();
                        dgvSalesHistory.DataSource = dgvQuery;
                        dgvSalesHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                        dgvSalesHistory.Columns[0].HeaderText = "Inventory ID";
                        dgvSalesHistory.Columns[1].HeaderText = "Inventory Name";
                        dgvSalesHistory.Columns[1].Width = 100;
                        dgvSalesHistory.Columns[2].HeaderText = "Type";
                        dgvSalesHistory.Columns[2].Width = 100;
                        dgvSalesHistory.Columns[3].HeaderText = "Price (Per Unit)";
                    }
                    else if (cbxSearchSaleHistory.Text == "Inventory Type:")
                    {
                        var dgvQuery = (from Items in db.Inventory_Item
                                        join Price in db.Inventory_Price
                                        on Items.Inventory_Item_ID equals Price.Inventory_Item_ID
                                        join Type in db.Inventory_Item_Type
                                        on Items.Inventory_Item_Type_ID equals Type.Inventory_Item_Type_ID
                                        where Type.Inv_Item_Type_Description.Contains(txtSearchSaleHistory.Text)
                                        select new { Items.Inventory_Item_ID, Items.Inventory_Item_Name, Type.Inv_Item_Type_Description, Price.Inventory_Price1 }
                                   ).ToList();

                        dgvSalesHistory.DefaultCellStyle.ForeColor = Color.Black;
                        dgvSalesHistory.Columns.Clear();
                        dgvSalesHistory.DataSource = dgvQuery;
                        dgvSalesHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                        dgvSalesHistory.Columns[0].HeaderText = "Inventory ID";
                        dgvSalesHistory.Columns[1].HeaderText = "Inventory Name";
                        dgvSalesHistory.Columns[1].Width = 100;
                        dgvSalesHistory.Columns[2].HeaderText = "Type";
                        dgvSalesHistory.Columns[2].Width = 100;
                        dgvSalesHistory.Columns[3].HeaderText = "Price (Per Unit)";
                    }
                    else if (cbxSearchSaleHistory.Text == "Menu ID:")
                    {
                        var dgvQuery = (from Items in db.Menu_Item
                                        join Price in db.Menu_Item_Price
                                        on Items.Menu_Item_ID equals Price.Menu_Item_ID
                                        join Cat in db.Menu_Item_Category
                                        on Items.Menu_Item_Category_ID equals Cat.Menu_Item_Category_ID
                                        where Items.Menu_Item_ID.ToString().Contains(txtSearchSaleHistory.Text)
                                        select new { Items.Menu_Item_ID, Items.Menu_Item_Name, Cat.Menu_Item_Category_Description, Price.Menu_Item_Price1 }
                                  ).ToList();

                        dgvMenuSaleHistory.DefaultCellStyle.ForeColor = Color.Black;
                        dgvMenuSaleHistory.Columns.Clear();
                        dgvMenuSaleHistory.DataSource = dgvQuery;
                        dgvMenuSaleHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                        dgvMenuSaleHistory.Columns[0].HeaderText = "Menu ID";
                        dgvMenuSaleHistory.Columns[1].HeaderText = "Menu Name";
                        dgvMenuSaleHistory.Columns[1].Width = 100;
                        dgvMenuSaleHistory.Columns[3].HeaderText = "Price (Per Unit)";
                        dgvMenuSaleHistory.Columns[3].Width = 100;
                        dgvMenuSaleHistory.Columns[2].HeaderText = "Category";
                        dgvMenuSaleHistory.Columns[2].Width = 100;
                    }
                    else if (cbxSearchSaleHistory.Text == "Menu Name:")
                    {
                        var dgvQuery = (from Items in db.Menu_Item
                                        join Price in db.Menu_Item_Price
                                        on Items.Menu_Item_ID equals Price.Menu_Item_ID
                                        join Cat in db.Menu_Item_Category
                                        on Items.Menu_Item_Category_ID equals Cat.Menu_Item_Category_ID
                                        where Items.Menu_Item_Name.Contains(txtSearchSaleHistory.Text)
                                        select new { Items.Menu_Item_ID, Items.Menu_Item_Name, Cat.Menu_Item_Category_Description, Price.Menu_Item_Price1 }
                                 ).ToList();

                        dgvMenuSaleHistory.DefaultCellStyle.ForeColor = Color.Black;
                        dgvMenuSaleHistory.Columns.Clear();
                        dgvMenuSaleHistory.DataSource = dgvQuery;
                        dgvMenuSaleHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                        dgvMenuSaleHistory.Columns[0].HeaderText = "Menu ID";
                        dgvMenuSaleHistory.Columns[1].HeaderText = "Menu Name";
                        dgvMenuSaleHistory.Columns[1].Width = 100;
                        dgvMenuSaleHistory.Columns[3].HeaderText = "Price (Per Unit)";
                        dgvMenuSaleHistory.Columns[3].Width = 100;
                        dgvMenuSaleHistory.Columns[2].HeaderText = "Category";
                        dgvMenuSaleHistory.Columns[2].Width = 100;
                    }
                    else if (cbxSearchSaleHistory.Text == "Menu Category:")
                    {
                        var dgvQuery = (from Items in db.Menu_Item
                                        join Price in db.Menu_Item_Price
                                        on Items.Menu_Item_ID equals Price.Menu_Item_ID
                                        join Cat in db.Menu_Item_Category
                                        on Items.Menu_Item_Category_ID equals Cat.Menu_Item_Category_ID
                                        where Cat.Menu_Item_Category_Description.Contains(txtSearchSaleHistory.Text)
                                        select new { Items.Menu_Item_ID, Items.Menu_Item_Name, Cat.Menu_Item_Category_Description, Price.Menu_Item_Price1 }
                                 ).ToList();

                        dgvMenuSaleHistory.DefaultCellStyle.ForeColor = Color.Black;
                        dgvMenuSaleHistory.Columns.Clear();
                        dgvMenuSaleHistory.DataSource = dgvQuery;
                        dgvMenuSaleHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                        dgvMenuSaleHistory.Columns[0].HeaderText = "Menu ID";
                        dgvMenuSaleHistory.Columns[1].HeaderText = "Menu Name";
                        dgvMenuSaleHistory.Columns[1].Width = 100;
                        dgvMenuSaleHistory.Columns[3].HeaderText = "Price (Per Unit)";
                        dgvMenuSaleHistory.Columns[3].Width = 100;
                        dgvMenuSaleHistory.Columns[2].HeaderText = "Category";
                        dgvMenuSaleHistory.Columns[2].Width = 100;
                    }
                    else
                    {
                        txtSearchSaleHistory.Clear();
                        MessageBox.Show("Please select a search criteria from the drop down list.", "No search Criteria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch
            {
                txtSearchSaleHistory.Clear();
                MessageBox.Show("Error: The search cannot be performed.");
            }
        }
        void Populate_Graphs()
        {
            try
            {

                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    var InvTypeIDQry = (from invItem in db.Inventory_Item
                                        join unit in db.Sales_Line
                                        on invItem.Inventory_Item_ID equals unit.Sales_Line_Quantity
                                        select new { invItem.Inventory_Item_Name, unit.Sales_Line_Quantity }
                                ).ToList();

                        //db.spAddInventoryItem(txtInventoryName.Text, Convert.ToInt32(nudInventoryQuantity.Value), Convert.ToInt32(txtBarcode.Text),Convert.ToInt32(txtInventoryID.Text), Convert.ToDecimal(txtUnitPrice.Text), DateTime.Today, Convert.ToDateTime(lblDatePOS.Text), DateTime.Now.TimeOfDay, txtEmployeeNameProfile.Text, "Adding a new Inventory Item", txtInventoryName.Text + " was added at quantity:" + nudInventoryQuantity.Value.ToString());
                    foreach (var item in InvTypeIDQry)
                    {
                        //chart1.Series["Series1"].XValueMember = item.Inventory_Item_Name;
                        //chart1.Series["Series1"].YValueMembers = item.Sales_Line_Quantity.ToString();

                    }
                }
            }
            catch { return; }
        }

        private void crystalReportViewer1_Load_1(object sender, EventArgs e)
        {

        }

        private void crystalReportViewer2_Load(object sender, EventArgs e)
        {

        }

        private void tabPOS_Click(object sender, EventArgs e)
        {

        }

        private void groupBox36_Enter(object sender, EventArgs e)
        {

        }
        #region Adding inventory catergories
        private void btnSaveUnitOfMeasure_Click(object sender, EventArgs e)
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    var MenuCatIDQry = (from cat in db.Unit_Of_Measure
                                        where cat.Unit_Of_Measure_Description.Equals(cbxUnit.Text)
                                        select new { cat.Unit_Of_Measure_ID, cat.Unit_Of_Measure_Description }
                               ).FirstOrDefault();

                    db.spAddUnitOFMeasure(txtAddUnitOfMeasure.Text, DateTime.Today.Date, DateTime.Now.TimeOfDay, txtEmployeeNameProfile.Text, "Enterance of new Unit of measure", txtEnterNewCategory.Text + " was created");

                    db.SaveChanges();
                    POPInventoryUnitCbx();
                    //gbxCatDetails.Visible = false;
                    txtAddUnitOfMeasure.Clear();
                    MessageBox.Show("New Unit of measure has successfully been created");
                }
            }
            catch (Exception )
            {
                MessageBox.Show("Please select the button again");
            }
        }


        private void btnSaveNewType_Click(object sender, EventArgs e)
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    var MenuCatIDQry = (from cat in db.Inventory_Item_Type
                                        where cat.Inv_Item_Type_Description.Equals(cbxInventoryType.Text)
                                        select new { cat.Inventory_Item_Type_ID, cat.Inv_Item_Type_Description }
                               ).FirstOrDefault();

                    db.spAddInventoryItemType(txtAddNewType.Text, DateTime.Today.Date, DateTime.Now.TimeOfDay, txtEmployeeNameProfile.Text, "Enterance of new category", txtEnterNewCategory.Text + " was created");

                    db.SaveChanges();
                    POPInventoryTypeCbx();
                    
                    //gbxCatDetails.Visible = false;
                    txtAddNewType.Clear();
                    MessageBox.Show("New Inventory Type has successfully been created");
                }
            }
            catch (Exception ERR)
            {
                MessageBox.Show("Please try select the button again");
            }
        }
        

        private void btnAddUnitOfMeasure_Click(object sender, EventArgs e)
        {
            gbxAddUnitOfMeasure.Visible = true;
            gbxAddNewType.Visible = false;
        }

        private void btnAddType_Click(object sender, EventArgs e)
        {
            gbxAddNewType.Visible = true;
            gbxAddUnitOfMeasure.Visible = false;
        }
        #endregion
         #region Populate Food Order Screen
        void PopulateFoodDataGridView()
        {
            int n = 0;
            foreach(DataGridViewRow row in dgvFoodOrderScreen.Rows)
            {
                if (dgvFoodPOS.Rows.Count != n + 1)
                {
                    dgvFoodOrderScreen.Rows.Add();
                    dgvFoodOrderScreen.Rows[n].Cells[0].Value = row.Cells[0].Value.ToString();
                    dgvFoodOrderScreen.Rows[n].Cells[1].Value = row.Cells[0].Value.ToString();
                    dgvFoodOrderScreen.Rows[n].Cells[2].Value = row.Cells[0].Value.ToString();
                }
                n += 1;
            }
        }
        #endregion

        private void btnChangeVAT_Click(object sender, EventArgs e)
        {
            try
            {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    var VATQry = (from ID in db.VATs
                                        where ID.VatID
                                        select new {ID.VatID,ID.VatAmount}
                              ).FirstOrDefault();
                    db.spUpdateEmployee(Convert.ToInt32(txtEmpID.Text), txtEmpName.Text, txtEmpSurname.Text, txtEmpNumber.Text, txtEmpAddress.Text, txtEmpEmail.Text, txtLoginPassword.Text, SecurityQuestionIDQry.Security_Question_ID, txtSecurityQuestion.Text, convertImagetoByte(pbxEmployeePhoto.Image), txtEmployeeBankName.Text, txtEmployeeBranchCode.Text, txtEmployeeAccountNo.Text, EmpTitleIDQry.Employee_Title_ID, EmpTypeIDQry.Employee_Type_ID, Convert.ToDateTime(lblDatePOS.Text), DateTime.Now.TimeOfDay, txtEmployeeNameProfile.Text, "Updating an existing Employee", txtEmpName.Text + " was updated");

                    db.SaveChanges();

                    PopulateEmpDGV();
                    PopulateAuditLogDGV();
                    MessageBox.Show("The new Employee has been successfully updated", "Successful Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }
}
    }
}








