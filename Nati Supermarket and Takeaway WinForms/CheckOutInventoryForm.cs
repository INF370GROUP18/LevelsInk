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
    public partial class CheckOutInventoryForm : Form
    {
        public CheckOutInventoryForm()
        {
            InitializeComponent();
        }

        private void CheckOutInventoryForm_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Today.ToString();
        }
    }
}
