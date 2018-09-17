namespace EmployeeForm_Exercise
{
    partial class EmployeeType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeType));
            this.btnDeleteType = new System.Windows.Forms.Button();
            this.btnCloseType = new System.Windows.Forms.Button();
            this.btnAddType = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnUpdateType = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.dgvType = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbxType = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvType)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDeleteType
            // 
            this.btnDeleteType.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDeleteType.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDeleteType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteType.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.btnDeleteType.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.btnDeleteType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteType.Font = new System.Drawing.Font("Georgia", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(42)))), ((int)(((byte)(82)))));
            this.btnDeleteType.Location = new System.Drawing.Point(106, 17);
            this.btnDeleteType.Name = "btnDeleteType";
            this.btnDeleteType.Size = new System.Drawing.Size(75, 63);
            this.btnDeleteType.TabIndex = 12;
            this.btnDeleteType.Text = "&Delete";
            this.btnDeleteType.UseVisualStyleBackColor = false;
            // 
            // btnCloseType
            // 
            this.btnCloseType.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCloseType.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCloseType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCloseType.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.btnCloseType.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.btnCloseType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseType.Font = new System.Drawing.Font("Georgia", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(42)))), ((int)(((byte)(82)))));
            this.btnCloseType.Location = new System.Drawing.Point(460, 20);
            this.btnCloseType.Name = "btnCloseType";
            this.btnCloseType.Size = new System.Drawing.Size(75, 63);
            this.btnCloseType.TabIndex = 10;
            this.btnCloseType.Text = "&Close";
            this.btnCloseType.UseVisualStyleBackColor = false;
            this.btnCloseType.Click += new System.EventHandler(this.btnCloseType_Click);
            // 
            // btnAddType
            // 
            this.btnAddType.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAddType.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddType.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.btnAddType.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.btnAddType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddType.Font = new System.Drawing.Font("Georgia", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(42)))), ((int)(((byte)(82)))));
            this.btnAddType.Location = new System.Drawing.Point(9, 17);
            this.btnAddType.Name = "btnAddType";
            this.btnAddType.Size = new System.Drawing.Size(75, 63);
            this.btnAddType.TabIndex = 10;
            this.btnAddType.Text = "&Add ";
            this.btnAddType.UseVisualStyleBackColor = false;
            this.btnAddType.Click += new System.EventHandler(this.btnAddType_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnUpdateType);
            this.groupBox1.Controls.Add(this.btnDeleteType);
            this.groupBox1.Controls.Add(this.btnCloseType);
            this.groupBox1.Controls.Add(this.btnAddType);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(12, 319);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(554, 90);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select an Action";
            // 
            // BtnUpdateType
            // 
            this.BtnUpdateType.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnUpdateType.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnUpdateType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnUpdateType.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.BtnUpdateType.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.BtnUpdateType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnUpdateType.Font = new System.Drawing.Font("Georgia", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnUpdateType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(42)))), ((int)(((byte)(82)))));
            this.BtnUpdateType.Location = new System.Drawing.Point(202, 17);
            this.BtnUpdateType.Name = "BtnUpdateType";
            this.BtnUpdateType.Size = new System.Drawing.Size(75, 63);
            this.BtnUpdateType.TabIndex = 13;
            this.BtnUpdateType.Text = "&Update";
            this.BtnUpdateType.UseVisualStyleBackColor = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(77, 85);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // dgvType
            // 
            this.dgvType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgvType.Location = new System.Drawing.Point(304, 110);
            this.dgvType.Name = "dgvType";
            this.dgvType.Size = new System.Drawing.Size(243, 191);
            this.dgvType.TabIndex = 43;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Employee Type ID";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Type";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(42)))), ((int)(((byte)(82)))));
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(-3, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(578, 85);
            this.panel2.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(210, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "Employees";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbxType);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox2.Location = new System.Drawing.Point(12, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(277, 85);
            this.groupBox2.TabIndex = 46;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Employee Type";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // tbxType
            // 
            this.tbxType.Location = new System.Drawing.Point(144, 37);
            this.tbxType.Name = "tbxType";
            this.tbxType.Size = new System.Drawing.Size(100, 21);
            this.tbxType.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(6, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 14);
            this.label5.TabIndex = 6;
            this.label5.Text = "Employee Type :";
            // 
            // EmployeeType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(42)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(571, 421);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvType);
            this.Controls.Add(this.panel2);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(42)))), ((int)(((byte)(82)))));
            this.Name = "EmployeeType";
            this.Text = "EmployeeType";
            this.Load += new System.EventHandler(this.EmployeeType_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvType)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnDeleteType;
        private System.Windows.Forms.Button btnCloseType;
        private System.Windows.Forms.Button btnAddType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataGridView dgvType;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button BtnUpdateType;
    }
}