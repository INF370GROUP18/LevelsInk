namespace EmployeeForm_Exercise
{
    partial class SupplyDetailsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupplyDetailsForm));
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSearchSupplier = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnDeleteSupp = new System.Windows.Forms.Button();
            this.btnUpdateSupp = new System.Windows.Forms.Button();
            this.btnCloseSupp = new System.Windows.Forms.Button();
            this.btnAddEmployee = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(548, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 38);
            this.label2.TabIndex = 6;
            this.label2.Text = "Supplier";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(42)))), ((int)(((byte)(82)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Location = new System.Drawing.Point(-361, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1351, 82);
            this.panel1.TabIndex = 5;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(364, 8);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(100, 71);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-346, -34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(107, 71);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(-196, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employee Details";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Georgia", 6.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(42)))), ((int)(((byte)(82)))));
            this.btnSearch.Location = new System.Drawing.Point(372, 105);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 20);
            this.btnSearch.TabIndex = 41;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView1.Location = new System.Drawing.Point(3, 162);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(444, 150);
            this.dataGridView1.TabIndex = 40;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Supplier ID";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Name";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Surname";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Contact Number";
            this.Column4.Name = "Column4";
            // 
            // txtSearchSupplier
            // 
            this.txtSearchSupplier.Location = new System.Drawing.Point(3, 104);
            this.txtSearchSupplier.Name = "txtSearchSupplier";
            this.txtSearchSupplier.Size = new System.Drawing.Size(324, 20);
            this.txtSearchSupplier.TabIndex = 39;
            this.txtSearchSupplier.Text = "1";
            this.txtSearchSupplier.TextChanged += new System.EventHandler(this.txtSearchEmployee_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(42)))), ((int)(((byte)(82)))));
            this.groupBox1.Controls.Add(this.BtnDeleteSupp);
            this.groupBox1.Controls.Add(this.btnUpdateSupp);
            this.groupBox1.Controls.Add(this.btnCloseSupp);
            this.groupBox1.Controls.Add(this.btnAddEmployee);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(12, 370);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(435, 89);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select an Action";
            // 
            // BtnDeleteSupp
            // 
            this.BtnDeleteSupp.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnDeleteSupp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnDeleteSupp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDeleteSupp.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.BtnDeleteSupp.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.BtnDeleteSupp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDeleteSupp.Font = new System.Drawing.Font("Georgia", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDeleteSupp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(42)))), ((int)(((byte)(82)))));
            this.BtnDeleteSupp.Location = new System.Drawing.Point(208, 17);
            this.BtnDeleteSupp.Name = "BtnDeleteSupp";
            this.BtnDeleteSupp.Size = new System.Drawing.Size(75, 63);
            this.BtnDeleteSupp.TabIndex = 13;
            this.BtnDeleteSupp.Text = "&Delete";
            this.BtnDeleteSupp.UseVisualStyleBackColor = false;
            // 
            // btnUpdateSupp
            // 
            this.btnUpdateSupp.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUpdateSupp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUpdateSupp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateSupp.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.btnUpdateSupp.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.btnUpdateSupp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateSupp.Font = new System.Drawing.Font("Georgia", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateSupp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(42)))), ((int)(((byte)(82)))));
            this.btnUpdateSupp.Location = new System.Drawing.Point(106, 17);
            this.btnUpdateSupp.Name = "btnUpdateSupp";
            this.btnUpdateSupp.Size = new System.Drawing.Size(75, 63);
            this.btnUpdateSupp.TabIndex = 12;
            this.btnUpdateSupp.Text = "&Update";
            this.btnUpdateSupp.UseVisualStyleBackColor = false;
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
            this.btnCloseSupp.Location = new System.Drawing.Point(337, 17);
            this.btnCloseSupp.Name = "btnCloseSupp";
            this.btnCloseSupp.Size = new System.Drawing.Size(75, 63);
            this.btnCloseSupp.TabIndex = 10;
            this.btnCloseSupp.Text = "&Close";
            this.btnCloseSupp.UseVisualStyleBackColor = false;
            this.btnCloseSupp.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAddEmployee.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddEmployee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddEmployee.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.btnAddEmployee.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.btnAddEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddEmployee.Font = new System.Drawing.Font("Georgia", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddEmployee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(42)))), ((int)(((byte)(82)))));
            this.btnAddEmployee.Location = new System.Drawing.Point(9, 17);
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.Size = new System.Drawing.Size(75, 63);
            this.btnAddEmployee.TabIndex = 10;
            this.btnAddEmployee.Text = "&New";
            this.btnAddEmployee.UseVisualStyleBackColor = false;
            this.btnAddEmployee.Click += new System.EventHandler(this.btnAddEmployee_Click);
            // 
            // SupplyDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(42)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(503, 471);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtSearchSupplier);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(42)))), ((int)(((byte)(82)))));
            this.Name = "SupplyDetailsForm";
            this.Text = "SupplyDetailsForm";
            this.Load += new System.EventHandler(this.SupplyDetailsForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnUpdateSupp;
        private System.Windows.Forms.Button btnCloseSupp;
        private System.Windows.Forms.Button btnAddEmployee;
        private System.Windows.Forms.Button BtnDeleteSupp;
        internal System.Windows.Forms.TextBox txtSearchSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}