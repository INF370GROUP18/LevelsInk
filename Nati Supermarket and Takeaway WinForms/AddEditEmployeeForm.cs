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
    public partial class AddEditEmployeeForm : Form
    {
        string formOption = "";
        public AddEditEmployeeForm(string option)
        {
            string formOption = option;
            InitializeComponent();
        }

        private void AddEditEmployeeForm_Load(object sender, EventArgs e)
        {
            if (formOption == "Add")
                lblTitle.Text = "Add new Employee";
            else if (formOption == "Edit")
                lblTitle.Text = "Edit existing Employee";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeForm empfrm = new EmployeeForm();
            empfrm.ShowDialog();
            this.Close();
        }
    }
}
