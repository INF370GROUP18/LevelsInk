using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeForm_Exercise
{
    public partial class ReceiveOrder : Form
    {
        public ReceiveOrder()
        {
            InitializeComponent();
        }

        private void ReceiveOrder_Load(object sender, EventArgs e)
        {

        }

        private void btnCloseSO_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNextSupOrd_Click(object sender, EventArgs e)
        {
            //SupplierPayment payment = new SupplierPayment();
            //payment.ShowDialog();
        }

        private void tbxOrderPriceSupplier_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnReceiveOrder_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Order Updated");
        }
    }
}
