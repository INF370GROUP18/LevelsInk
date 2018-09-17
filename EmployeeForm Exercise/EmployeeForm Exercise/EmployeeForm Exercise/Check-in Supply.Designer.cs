namespace EmployeeForm_Exercise
{
    partial class Check_in_Supply
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Check_in_Supply));
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbxEm = new System.Windows.Forms.TextBox();
            this.tbxCell = new System.Windows.Forms.TextBox();
            this.tbxSurn = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCloseSupp = new System.Windows.Forms.Button();
            this.btnReceiveOrder = new System.Windows.Forms.Button();
            this.tbxTotalP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierInventoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.natiSupermarketandTakeawayFinalDataSet = new EmployeeForm_Exercise.NatiSupermarketandTakeawayFinalDataSet();
            this.supplier_InventoryTableAdapter = new EmployeeForm_Exercise.NatiSupermarketandTakeawayFinalDataSetTableAdapters.Supplier_InventoryTableAdapter();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierInventoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.natiSupermarketandTakeawayFinalDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(130, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(331, 34);
            this.label2.TabIndex = 6;
            this.label2.Text = "Placing Supply Order";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(3, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(100, 82);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Location = new System.Drawing.Point(-3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(507, 85);
            this.panel1.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(42)))), ((int)(((byte)(82)))));
            this.groupBox1.Controls.Add(this.tbxEm);
            this.groupBox1.Controls.Add(this.tbxCell);
            this.groupBox1.Controls.Add(this.tbxSurn);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(12, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 141);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Supplier Details";
            // 
            // tbxEm
            // 
            this.tbxEm.Location = new System.Drawing.Point(197, 102);
            this.tbxEm.Name = "tbxEm";
            this.tbxEm.Size = new System.Drawing.Size(252, 21);
            this.tbxEm.TabIndex = 13;
            // 
            // tbxCell
            // 
            this.tbxCell.Location = new System.Drawing.Point(197, 65);
            this.tbxCell.Name = "tbxCell";
            this.tbxCell.Size = new System.Drawing.Size(177, 21);
            this.tbxCell.TabIndex = 12;
            // 
            // tbxSurn
            // 
            this.tbxSurn.Location = new System.Drawing.Point(197, 29);
            this.tbxSurn.Name = "tbxSurn";
            this.tbxSurn.Size = new System.Drawing.Size(252, 21);
            this.tbxSurn.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(42)))), ((int)(((byte)(82)))));
            this.label4.Location = new System.Drawing.Point(17, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Supplier Cellphone :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(42)))), ((int)(((byte)(82)))));
            this.label3.Location = new System.Drawing.Point(17, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Supplier E-mail :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(42)))), ((int)(((byte)(82)))));
            this.label1.Location = new System.Drawing.Point(17, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Supplier Surname :";
            // 
            // btnCloseSupp
            // 
            this.btnCloseSupp.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCloseSupp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCloseSupp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCloseSupp.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.btnCloseSupp.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.btnCloseSupp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseSupp.Font = new System.Drawing.Font("Georgia", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseSupp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(42)))), ((int)(((byte)(82)))));
            this.btnCloseSupp.Location = new System.Drawing.Point(93, 427);
            this.btnCloseSupp.Name = "btnCloseSupp";
            this.btnCloseSupp.Size = new System.Drawing.Size(75, 35);
            this.btnCloseSupp.TabIndex = 11;
            this.btnCloseSupp.Text = "&Delete";
            this.btnCloseSupp.UseVisualStyleBackColor = false;
            // 
            // btnReceiveOrder
            // 
            this.btnReceiveOrder.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReceiveOrder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReceiveOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReceiveOrder.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.btnReceiveOrder.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.btnReceiveOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceiveOrder.Font = new System.Drawing.Font("Georgia", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceiveOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(42)))), ((int)(((byte)(82)))));
            this.btnReceiveOrder.Location = new System.Drawing.Point(12, 427);
            this.btnReceiveOrder.Name = "btnReceiveOrder";
            this.btnReceiveOrder.Size = new System.Drawing.Size(75, 35);
            this.btnReceiveOrder.TabIndex = 12;
            this.btnReceiveOrder.Text = "&Add";
            this.btnReceiveOrder.UseVisualStyleBackColor = false;
            this.btnReceiveOrder.Click += new System.EventHandler(this.btnReceiveOrder_Click);
            // 
            // tbxTotalP
            // 
            this.tbxTotalP.Location = new System.Drawing.Point(339, 427);
            this.tbxTotalP.Name = "tbxTotalP";
            this.tbxTotalP.Size = new System.Drawing.Size(122, 20);
            this.tbxTotalP.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(258, 434);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Total Price :";
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSend.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.btnSend.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(42)))), ((int)(((byte)(82)))));
            this.btnSend.Location = new System.Drawing.Point(295, 461);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 47);
            this.btnSend.TabIndex = 18;
            this.btnSend.Text = "&Send Order";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Georgia", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(42)))), ((int)(((byte)(82)))));
            this.btnClose.Location = new System.Drawing.Point(386, 461);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 47);
            this.btnClose.TabIndex = 19;
            this.btnClose.Text = "&Cancel";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView1.Location = new System.Drawing.Point(12, 313);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(449, 99);
            this.dataGridView1.TabIndex = 20;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Item Number";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Inventory Name";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Price";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Quantity Ordered";
            this.Column4.Name = "Column4";
            // 
            // supplierInventoryBindingSource
            // 
            this.supplierInventoryBindingSource.DataMember = "Supplier_Inventory";
            this.supplierInventoryBindingSource.DataSource = this.natiSupermarketandTakeawayFinalDataSet;
            // 
            // natiSupermarketandTakeawayFinalDataSet
            // 
            this.natiSupermarketandTakeawayFinalDataSet.DataSetName = "NatiSupermarketandTakeawayFinalDataSet";
            this.natiSupermarketandTakeawayFinalDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // supplier_InventoryTableAdapter
            // 
            this.supplier_InventoryTableAdapter.ClearBeforeFill = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(42)))), ((int)(((byte)(82)))));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(12, 272);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Order Issue Date :";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd-mm-yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(209, 272);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(214, 20);
            this.dateTimePicker1.TabIndex = 25;
            // 
            // Check_in_Supply
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(42)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(489, 520);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbxTotalP);
            this.Controls.Add(this.btnCloseSupp);
            this.Controls.Add(this.btnReceiveOrder);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(42)))), ((int)(((byte)(82)))));
            this.Name = "Check_in_Supply";
            this.Text = "Check_in_Supply";
            this.Load += new System.EventHandler(this.Check_in_Supply_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierInventoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.natiSupermarketandTakeawayFinalDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbxCell;
        private System.Windows.Forms.TextBox tbxSurn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCloseSupp;
        private System.Windows.Forms.Button btnReceiveOrder;
        private System.Windows.Forms.TextBox tbxEm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxTotalP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dataGridView1;
        private NatiSupermarketandTakeawayFinalDataSet natiSupermarketandTakeawayFinalDataSet;
        private System.Windows.Forms.BindingSource supplierInventoryBindingSource;
        private NatiSupermarketandTakeawayFinalDataSetTableAdapters.Supplier_InventoryTableAdapter supplier_InventoryTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}