namespace Nati_Supermarket_and_Takeaway_WinForms
{
    partial class POSInventoryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(POSInventoryForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.gbxProductInformation = new System.Windows.Forms.GroupBox();
            this.btnAddInventoryItem = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtSalesDiscount = new System.Windows.Forms.TextBox();
            this.txtSalesPrice = new System.Windows.Forms.TextBox();
            this.txtSalesQuantity = new System.Windows.Forms.TextBox();
            this.txtSalesDescription = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvInventoryItem = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.cbxSearchCriteria = new System.Windows.Forms.ComboBox();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbxProductInformation.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventoryItem)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label11);
            this.panel5.Controls.Add(this.pictureBox1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(879, 103);
            this.panel5.TabIndex = 33;
            this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Georgia", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(216, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(509, 43);
            this.label11.TabIndex = 3;
            this.label11.Text = "Nati: Add Inventory Item";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(115, 103);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(315, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(568, 100);
            this.panel4.TabIndex = 32;
            // 
            // gbxProductInformation
            // 
            this.gbxProductInformation.Controls.Add(this.btnAddInventoryItem);
            this.gbxProductInformation.Controls.Add(this.btnClear);
            this.gbxProductInformation.Controls.Add(this.txtSalesDiscount);
            this.gbxProductInformation.Controls.Add(this.txtSalesPrice);
            this.gbxProductInformation.Controls.Add(this.txtSalesQuantity);
            this.gbxProductInformation.Controls.Add(this.txtSalesDescription);
            this.gbxProductInformation.Controls.Add(this.label7);
            this.gbxProductInformation.Controls.Add(this.label6);
            this.gbxProductInformation.Controls.Add(this.label5);
            this.gbxProductInformation.Controls.Add(this.label4);
            this.gbxProductInformation.Controls.Add(this.label3);
            this.gbxProductInformation.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.gbxProductInformation.Location = new System.Drawing.Point(644, 150);
            this.gbxProductInformation.Name = "gbxProductInformation";
            this.gbxProductInformation.Size = new System.Drawing.Size(226, 269);
            this.gbxProductInformation.TabIndex = 22;
            this.gbxProductInformation.TabStop = false;
            this.gbxProductInformation.Text = "Inventory Information";
            // 
            // btnAddInventoryItem
            // 
            this.btnAddInventoryItem.BackColor = System.Drawing.Color.Green;
            this.btnAddInventoryItem.Location = new System.Drawing.Point(6, 185);
            this.btnAddInventoryItem.Name = "btnAddInventoryItem";
            this.btnAddInventoryItem.Size = new System.Drawing.Size(97, 59);
            this.btnAddInventoryItem.TabIndex = 11;
            this.btnAddInventoryItem.Text = "Add Inventory Item";
            this.btnAddInventoryItem.UseVisualStyleBackColor = false;
            this.btnAddInventoryItem.Click += new System.EventHandler(this.btnFinaliseSale_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Red;
            this.btnClear.Location = new System.Drawing.Point(132, 185);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(88, 59);
            this.btnClear.TabIndex = 18;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            // 
            // txtSalesDiscount
            // 
            this.txtSalesDiscount.Enabled = false;
            this.txtSalesDiscount.Location = new System.Drawing.Point(105, 147);
            this.txtSalesDiscount.Name = "txtSalesDiscount";
            this.txtSalesDiscount.Size = new System.Drawing.Size(183, 20);
            this.txtSalesDiscount.TabIndex = 8;
            // 
            // txtSalesPrice
            // 
            this.txtSalesPrice.Enabled = false;
            this.txtSalesPrice.Location = new System.Drawing.Point(105, 106);
            this.txtSalesPrice.Name = "txtSalesPrice";
            this.txtSalesPrice.Size = new System.Drawing.Size(183, 20);
            this.txtSalesPrice.TabIndex = 7;
            // 
            // txtSalesQuantity
            // 
            this.txtSalesQuantity.Location = new System.Drawing.Point(105, 67);
            this.txtSalesQuantity.Name = "txtSalesQuantity";
            this.txtSalesQuantity.Size = new System.Drawing.Size(183, 20);
            this.txtSalesQuantity.TabIndex = 6;
            // 
            // txtSalesDescription
            // 
            this.txtSalesDescription.Enabled = false;
            this.txtSalesDescription.Location = new System.Drawing.Point(105, 25);
            this.txtSalesDescription.Name = "txtSalesDescription";
            this.txtSalesDescription.Size = new System.Drawing.Size(183, 20);
            this.txtSalesDescription.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 199);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 13);
            this.label7.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Discount (%):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Price (Per Item):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Quantity:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Name:";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.DarkGreen;
            this.btnAdd.Location = new System.Drawing.Point(6, 19);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(106, 59);
            this.btnAdd.TabIndex = 19;
            this.btnAdd.Text = "Add Quantity";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.dgvInventoryItem);
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.gbxProductInformation);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.ForeColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(879, 509);
            this.panel3.TabIndex = 33;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 413);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(552, 87);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select an Action:";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(440, 19);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 59);
            this.btnCancel.TabIndex = 28;
            this.btnCancel.Text = "Cancel ";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "Select Inventory Item:";
            // 
            // dgvInventoryItem
            // 
            this.dgvInventoryItem.AllowUserToAddRows = false;
            this.dgvInventoryItem.AllowUserToDeleteRows = false;
            this.dgvInventoryItem.BackgroundColor = System.Drawing.Color.White;
            this.dgvInventoryItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInventoryItem.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInventoryItem.GridColor = System.Drawing.Color.Black;
            this.dgvInventoryItem.Location = new System.Drawing.Point(12, 176);
            this.dgvInventoryItem.Name = "dgvInventoryItem";
            this.dgvInventoryItem.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInventoryItem.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInventoryItem.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvInventoryItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventoryItem.Size = new System.Drawing.Size(614, 232);
            this.dgvInventoryItem.TabIndex = 37;
            this.dgvInventoryItem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSaleLine_CellContentClick);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Black;
            this.groupBox3.Controls.Add(this.txtResult);
            this.groupBox3.Controls.Add(this.cbxSearchCriteria);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(12, 109);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(614, 48);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Search Inventory Item";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(146, 20);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(382, 20);
            this.txtResult.TabIndex = 37;
            this.txtResult.TextChanged += new System.EventHandler(this.txtResult_TextChanged);
            // 
            // cbxSearchCriteria
            // 
            this.cbxSearchCriteria.FormattingEnabled = true;
            this.cbxSearchCriteria.Items.AddRange(new object[] {
            "Inventory Item ID:",
            "Barcode Number:",
            "Inventory Item Name:"});
            this.cbxSearchCriteria.Location = new System.Drawing.Point(6, 19);
            this.cbxSearchCriteria.Name = "cbxSearchCriteria";
            this.cbxSearchCriteria.Size = new System.Drawing.Size(134, 21);
            this.cbxSearchCriteria.TabIndex = 36;
            this.cbxSearchCriteria.Text = "Select Search Criteria:";
            // 
            // POSInventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(876, 509);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "POSInventoryForm";
            this.Text = "POSForm";
            this.Load += new System.EventHandler(this.POSInventoryForm_Load);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbxProductInformation.ResumeLayout(false);
            this.gbxProductInformation.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventoryItem)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox gbxProductInformation;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtSalesDiscount;
        private System.Windows.Forms.TextBox txtSalesPrice;
        private System.Windows.Forms.TextBox txtSalesQuantity;
        private System.Windows.Forms.TextBox txtSalesDescription;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvInventoryItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.ComboBox cbxSearchCriteria;
        private System.Windows.Forms.Button btnAddInventoryItem;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}