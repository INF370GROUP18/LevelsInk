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
using System.IO;
using System.Security.Cryptography;


namespace Nati_Supermarket_and_Takeaway_WinForms
{
    public partial class LoginForm : Form
    {


        public LoginForm()
        {
            InitializeComponent();
        }
        int Employee_ID;
        string Employee_Name;
        byte[] Employee_Password;
        byte[] Employee_Picture;
        int Employee_Access_Level;


        public string PasswordHash(string password)
        {
            SHA512Managed HashTool = new SHA512Managed();
            Byte[] PhraseAsByte = Encoding.UTF8.GetBytes(string.Concat(password));
            Byte[] EncryptedBytes = HashTool.ComputeHash(PhraseAsByte);
            HashTool.Clear();
            return Convert.ToBase64String(EncryptedBytes);
        }


        public bool CanLogin()
        {
                using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                {
                    bool CanLogin = false;
                    int ExisQuery = (from el in db.Employees
                                     where el.Employee_Name.Equals(txtName.Text.Trim())
                                     select new { el.Employee_ID, el.Employee_Name, el.Employee_Login_Password, el.Employee_Picture }
                                     ).Count();

                    if (ExisQuery > 0)
                    {
                        var LoginQuery = (from et in db.Employee_Type
                                          join ua in db.Employee_Access_Level
                                          on et.Employee_Access_Level_ID equals ua.Employee_Access_Level_ID
                                          join emp in db.Employees
                                          on et.Employee_Type_ID equals emp.Employee_Type_ID
                                          where emp.Employee_Name.Equals(txtName.Text.Trim())
                                          select new { emp.Employee_ID, emp.Employee_Name, emp.Employee_Login_Password, emp.Employee_Picture, ua.Employee_Access_Level_ID }
                                          ).First();

                        Employee_Access_Level = LoginQuery.Employee_Access_Level_ID;
                        Employee_ID = LoginQuery.Employee_ID;
                        Employee_Name = LoginQuery.Employee_Name;
                        Employee_Password = LoginQuery.Employee_Login_Password;
                        Employee_Picture = LoginQuery.Employee_Picture;

                        if (LoginQuery.Employee_Name == txtName.Text.Trim() && Convert.ToBase64String(LoginQuery.Employee_Login_Password) == PasswordHash(txtPassword.Text.Trim()))
                        {
                            CanLogin = true;
                        }
                        else
                        {
                            CanLogin = false;
                            MessageBox.Show("Error: Incorrect UserName or Password, Please Check Spelling");
                        }
                    }

                    return CanLogin;
                }
            }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (CanLogin() == true)
                {
                    DashboardForm f = new DashboardForm(Employee_ID, Employee_Name, Employee_Password, Employee_Picture, Employee_Access_Level);
                    f.ShowDialog();
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Login was unsuccessful, please try again.");
            }

        }
       


        //        string query = "SELECT Employee_Type_ID, Employee_Surname , Employee_ID FROM Employee WHERE Employee_Login_Password = @Employee_Login_Password AND Employee_Name = @Employee_Name ";
        //SqlConnection newConn = new SqlConnection(Globals.MyConnString);
        //SqlCommand sqlComm = new SqlCommand(query, newConn);
        //sqlComm.Parameters.AddWithValue("@Employee_Login_Password", Employee_Login_Password);
        //        sqlComm.Parameters.AddWithValue("@Employee_Name", Employee_Name);


        //            try
        //                {
        //                        newConn.Open();
        //                        SqlDataAdapter adapter = new SqlDataAdapter(sqlComm);
        //        DataSet SalesDataSet = new DataSet();
        //        adapter.Fill(SalesDataSet);
        //                        newConn.Close();
        //                        int count = SalesDataSet.Tables[0].Rows.Count;
        //                        if (count > 0)
        //                        {
        //                            this.Hide();

        //        string UserAccess = SalesDataSet.Tables[0].Rows[0]["Employee_Type_ID"].ToString();

        //                            switch (UserAccess)
        //                            {
        //                                case "1":
        //                                    DashboardForm frmDash = new DashboardForm( Convert.ToInt32(SalesDataSet.Tables[0].Rows[0]["Employee_ID"]));
        //                                frmDash.ShowDialog();
        //                                    this.Close();
        //                                    break;
        //                                case "2":
        //                                    //Show a different form
        //                                    POSForm frmCashier = new POSForm(Employee_Name, SalesDataSet.Tables[0].Rows[0]["Employee_Surname"].ToString(), Convert.ToInt32(SalesDataSet.Tables[0].Rows[0]["Employee_ID"]), "", "", "", "", "", "", "", "");
        //        frmCashier.ShowDialog();
        //                                    this.Close();
        //                                    break;
        //                            }
        //}
        //                        else
        //                        {
        //                        if (MessageBox.Show("The Name and/or Password field are invalid. \n Please try again.", "Incorrect Username or Password", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.Retry)
        //                        {
        //                            txtName.Text = "";
        //                            txtPassword.Text = "";
        //                        }
        //                        else return;
        //                        }
        //                    }
        //                    catch (Exception err)
        //                    {
        //                        MessageBox.Show(err.Message);
        //                    }
        //                }
        //                else
        //                {
        //                   MessageBox.Show("Please make sure that the Name and Password fields are Filled in.","Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                }
        //        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            ChangePasswordForm frmCP = new ChangePasswordForm();
            frmCP.ShowDialog();
            this.Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnExit_CursorChanged(object sender, EventArgs e)
        {            
        }

        private void btnExit_MouseHover(object sender, EventArgs e)
        {
            //MessageBox.Show("Exit the program");
            //ForeColor = Color.Peru;
            //btnExit.Text = ForeColor.ToString();
        }

        private void btnLogin_MouseHover(object sender, EventArgs e)
        {
            //Message("Login into the program");

            //ForeColor = Color.RoyalBlue;
            //btnLogin.Text = ForeColor.ToString();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }

