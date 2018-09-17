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
using System.Security.Cryptography;


namespace Nati_Supermarket_and_Takeaway_WinForms
{
    public partial class ChangePasswordForm : Form
    {
        SqlConnection MyConn = new SqlConnection(Globals.MyConnString);
        int Employee_ID;
        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm frmLogin = new LoginForm();
            frmLogin.ShowDialog();
            this.Close();
        }
        public bool ChangePassword()
        {

            using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
            {
                bool ChangePassword = false;
                int ExisQuery = (from el in db.Employees
                                 where el.Employee_Email.Equals(txtEmail.Text.Trim())
                                 select new { el.Employee_ID, el.Employee_Email, el.Security_Question}
                                 ).Count();

                if (ExisQuery > 0)
                {
                    var LoginQuery = (from sq in db.Security_Question
                                      join emp in db.Employees
                                      on sq.Security_Question_ID equals emp.Security_Question_ID
                                      where emp.Employee_Name.Equals(txtName.Text.Trim())
                                      select new { emp.Employee_ID, emp.Employee_Name, emp.Employee_Email, sq.Security_Question_Description, emp.Employee_Security_Answer }
                                      ).First();


                    if (LoginQuery.Employee_Name == txtName.Text.Trim() && LoginQuery.Employee_Email == txtEmail.Text.Trim() && LoginQuery.Security_Question_Description == cbxSecQuest.Text.Trim() && LoginQuery.Employee_Security_Answer == txtAnswer.Text)
                    {
                        ChangePassword = true;
                        Employee_ID = LoginQuery.Employee_ID;
                    }
                    else 
                    {
                        ChangePassword = false;
                        MessageBox.Show("Error: Incorrect details or not entered details. Please reconfirm all the details on the form.");
                    }
                }
                else
                {
                    ChangePassword = false;
                    MessageBox.Show("Error: Incorrect email or security question response, Please Check Spelling");
                }
                
                return ChangePassword;
            }
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {


            if (txtEmail.Text != null & txtName.Text != null & txtName.Text != "" & txtAnswer.Text != null & txtAnswer.Text != "" & cbxSecQuest.Text != null & cbxSecQuest.Text != "")
            {
                try
                {
                    if (ChangePassword() == true)
                    {
                        lblNewPassword.Visible = true;
                        txtPassword.Visible = true;
                        btnChangePassword.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Please input all the required information", "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
           
        }
        public string PasswordHash(string password)
        {
            SHA512Managed HashTool = new SHA512Managed();
            Byte[] PhraseAsByte = Encoding.UTF8.GetBytes(string.Concat(password));
            Byte[] EncryptedBytes = HashTool.ComputeHash(PhraseAsByte);
            HashTool.Clear();
            return Convert.ToBase64String(EncryptedBytes);
        }
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
             try
                {
                    using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
                    {
                        db.spChangeEmployeePassword(txtPassword.Text, txtEmail.Text, DateTime.Today.Date, DateTime.Now.TimeOfDay, txtName.Text, "Change of Password", "Password was changed.");

                        db.SaveChanges();
                        MessageBox.Show("You have successfully changed your password.");
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("There was an error in chnaging the password. Error:" + ex);
                }
            } 
         
        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {
            PopSecurityQuestionCbx();
        }
        void PopSecurityQuestionCbx()
        {
            using (NatiSupermarketandTakeawayFinalEntities db = new NatiSupermarketandTakeawayFinalEntities())
            {
                var cbxQuery = (from secQ in db.Security_Question
                                select new { secQ.Security_Question_Description }
                                   ).ToList();
                cbxSecQuest.DataSource = cbxQuery;
                cbxSecQuest.DisplayMember = "Security_Question_Description";
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cbxSecQuest_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label69_Click(object sender, EventArgs e)
        {

        }
    }
}





