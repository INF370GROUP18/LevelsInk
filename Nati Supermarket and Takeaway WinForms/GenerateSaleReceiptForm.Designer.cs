namespace Nati_Supermarket_and_Takeaway_WinForms
{
    partial class SalesHistoryForm
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
            this.dataSet1 = new System.Data.DataSet();
            this.btnReciept = new System.Windows.Forms.Button();
            this.btnLock = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnReceipt = new System.Windows.Forms.Button();
            this.gbxRecieptInfo = new System.Windows.Forms.GroupBox();
            this.rtfReciept = new System.Windows.Forms.RichTextBox();
            this.gbxAction = new System.Windows.Forms.GroupBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEmployeeID = new System.Windows.Forms.TextBox();
            this.lblEmployeeName = new System.Windows.Forms.Label();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.dgvSales = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.gbxRecieptInfo.SuspendLayout();
            this.gbxAction.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            // 
            // btnReciept
            // 
            this.btnReciept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(42)))), ((int)(((byte)(82)))));
            this.btnReciept.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReciept.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReciept.Location = new System.Drawing.Point(18, 24);
            this.btnReciept.Name = "btnReciept";
            this.btnReciept.Size = new System.Drawing.Size(122, 56);
            this.btnReciept.TabIndex = 23;
            this.btnReciept.Text = "&View Receipt";
            this.btnReciept.UseVisualStyleBackColor = false;
            this.btnReciept.Click += new System.EventHandler(this.btnReciept_Click);
            // 
            // btnLock
            // 
            this.btnLock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(42)))), ((int)(((byte)(82)))));
            this.btnLock.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLock.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLock.Location = new System.Drawing.Point(313, 19);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(76, 61);
            this.btnLock.TabIndex = 33;
            this.btnLock.Text = "&Lock";
            this.btnLock.UseVisualStyleBackColor = false;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(42)))), ((int)(((byte)(82)))));
            this.btnReset.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReset.Location = new System.Drawing.Point(191, 19);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(133, 56);
            this.btnReset.TabIndex = 32;
            this.btnReset.Text = "&RESET";
            this.btnReset.UseVisualStyleBackColor = false;
            // 
            // btnReceipt
            // 
            this.btnReceipt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReceipt.Location = new System.Drawing.Point(25, 19);
            this.btnReceipt.Name = "btnReceipt";
            this.btnReceipt.Size = new System.Drawing.Size(122, 56);
            this.btnReceipt.TabIndex = 34;
            this.btnReceipt.Text = "Print Receipt";
            this.btnReceipt.UseMnemonic = false;
            this.btnReceipt.UseVisualStyleBackColor = false;
            // 
            // gbxRecieptInfo
            // 
            this.gbxRecieptInfo.Controls.Add(this.btnReset);
            this.gbxRecieptInfo.Controls.Add(this.btnReceipt);
            this.gbxRecieptInfo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gbxRecieptInfo.Location = new System.Drawing.Point(3, 353);
            this.gbxRecieptInfo.Name = "gbxRecieptInfo";
            this.gbxRecieptInfo.Size = new System.Drawing.Size(336, 100);
            this.gbxRecieptInfo.TabIndex = 35;
            this.gbxRecieptInfo.TabStop = false;
            this.gbxRecieptInfo.Text = "Receipt Optiom";
            // 
            // rtfReciept
            // 
            this.rtfReciept.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtfReciept.Location = new System.Drawing.Point(3, 6);
            this.rtfReciept.Name = "rtfReciept";
            this.rtfReciept.Size = new System.Drawing.Size(333, 347);
            this.rtfReciept.TabIndex = 13;
            this.rtfReciept.Text = "";
            this.rtfReciept.TextChanged += new System.EventHandler(this.rtfReciept_TextChanged);
            // 
            // gbxAction
            // 
            this.gbxAction.Controls.Add(this.btnReciept);
            this.gbxAction.Controls.Add(this.btnBack);
            this.gbxAction.Controls.Add(this.btnLock);
            this.gbxAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxAction.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gbxAction.Location = new System.Drawing.Point(0, 0);
            this.gbxAction.Name = "gbxAction";
            this.gbxAction.Size = new System.Drawing.Size(515, 100);
            this.gbxAction.TabIndex = 36;
            this.gbxAction.TabStop = false;
            this.gbxAction.Text = "Select an Action:";
            this.gbxAction.Enter += new System.EventHandler(this.gbxAction_Enter);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(42)))), ((int)(((byte)(82)))));
            this.btnBack.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBack.Location = new System.Drawing.Point(395, 20);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(76, 61);
            this.btnBack.TabIndex = 34;
            this.btnBack.Text = "&Back";
            this.btnBack.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rtfReciept);
            this.panel1.Controls.Add(this.gbxRecieptInfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(515, 100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(339, 453);
            this.panel1.TabIndex = 41;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(854, 100);
            this.panel2.TabIndex = 42;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.gbxAction);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 453);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(515, 100);
            this.panel3.TabIndex = 43;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox2);
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Controls.Add(this.dgvSales);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 100);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(515, 353);
            this.panel4.TabIndex = 44;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtEmployeeID);
            this.groupBox1.Controls.Add(this.lblEmployeeName);
            this.groupBox1.Controls.Add(this.txtEmployeeName);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(7, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(504, 58);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Employee Details";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label10.Location = new System.Drawing.Point(6, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Employee ID:";
            // 
            // txtEmployeeID
            // 
            this.txtEmployeeID.Enabled = false;
            this.txtEmployeeID.Location = new System.Drawing.Point(83, 27);
            this.txtEmployeeID.Name = "txtEmployeeID";
            this.txtEmployeeID.Size = new System.Drawing.Size(57, 20);
            this.txtEmployeeID.TabIndex = 29;
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.AutoSize = true;
            this.lblEmployeeName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblEmployeeName.Location = new System.Drawing.Point(157, 30);
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.Size = new System.Drawing.Size(87, 13);
            this.lblEmployeeName.TabIndex = 30;
            this.lblEmployeeName.Text = "Employee Name:";
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Enabled = false;
            this.txtEmployeeName.Location = new System.Drawing.Point(250, 27);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(156, 20);
            this.txtEmployeeName.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "Search:";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(428, 13);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(68, 39);
            this.btnSubmit.TabIndex = 43;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click_1);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(56, 23);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(366, 20);
            this.txtResult.TabIndex = 42;
            // 
            // dgvSales
            // 
            this.dgvSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSales.Location = new System.Drawing.Point(7, 134);
            this.dgvSales.Name = "dgvSales";
            this.dgvSales.Size = new System.Drawing.Size(504, 217);
            this.dgvSales.TabIndex = 41;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnSubmit);
            this.groupBox2.Controls.Add(this.txtResult);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox2.Location = new System.Drawing.Point(7, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(502, 58);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Nati_Supermarket_and_Takeaway_WinForms.Properties.Resources.Revised_Logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(115, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Georgia", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label11.Location = new System.Drawing.Point(249, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(443, 43);
            this.label11.TabIndex = 6;
            this.label11.Text = "Generate Sale Receipt";
            // 
            // SalesHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(42)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(854, 553);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SalesHistoryForm";
            this.Text = "Sales";
            this.Load += new System.EventHandler(this.ViewSalesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.gbxRecieptInfo.ResumeLayout(false);
            this.gbxAction.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Data.DataSet dataSet1;
        private System.Windows.Forms.Button btnReciept;
        private System.Windows.Forms.Button btnLock;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnReceipt;
        private System.Windows.Forms.GroupBox gbxRecieptInfo;
        private System.Windows.Forms.RichTextBox rtfReciept;
        private System.Windows.Forms.GroupBox gbxAction;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEmployeeID;
        private System.Windows.Forms.Label lblEmployeeName;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.DataGridView dgvSales;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label11;
    }
}