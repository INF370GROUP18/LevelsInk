﻿using System;
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
    
    public partial class AddEditInventoryItemForm : Form
    {
        string formOption = "";

        public AddEditInventoryItemForm(string option)
        {
            string formOption = option;

            InitializeComponent();
        }

        private void AddEditInventoryItemForm_Load(object sender, EventArgs e)
        {
            if (formOption == "Add")
                lblTitle.Text = "Add new Inventory Item";
            else if (formOption == "Edit")
                lblTitle.Text = "Edit existing Inventory Item";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //InventoryItemForm invfrm = new InventoryItemForm();
            //invfrm.ShowDialog();
            //this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
