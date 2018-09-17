namespace Nati_Supermarket_and_Takeaway_WinForms
{
    partial class CheckInEmployeeForm
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
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblInOut = new System.Windows.Forms.Label();
            this.dtCheckInOut = new System.Windows.Forms.DateTimePicker();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.lblEmployeeCheckIn = new System.Windows.Forms.Label();
            this.lblEmployeeCheckOut = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lstEmployees = new System.Windows.Forms.ListView();
            this.CHEmployeeID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CHEmployeeName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CHEmployeeSurname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.BackColor = System.Drawing.Color.Purple;
            this.btnCheckIn.Location = new System.Drawing.Point(2, 330);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(96, 44);
            this.btnCheckIn.TabIndex = 10;
            this.btnCheckIn.Text = "Check In";
            this.btnCheckIn.UseVisualStyleBackColor = false;
            this.btnCheckIn.Visible = false;
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "List of Employees";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Purple;
            this.panel1.Controls.Add(this.lblInOut);
            this.panel1.Location = new System.Drawing.Point(1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(536, 48);
            this.panel1.TabIndex = 12;
            // 
            // lblInOut
            // 
            this.lblInOut.AutoSize = true;
            this.lblInOut.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInOut.Location = new System.Drawing.Point(11, 10);
            this.lblInOut.Name = "lblInOut";
            this.lblInOut.Size = new System.Drawing.Size(76, 29);
            this.lblInOut.TabIndex = 0;
            this.lblInOut.Text = "InOut";
            // 
            // dtCheckInOut
            // 
            this.dtCheckInOut.Enabled = false;
            this.dtCheckInOut.Location = new System.Drawing.Point(112, 286);
            this.dtCheckInOut.Name = "dtCheckInOut";
            this.dtCheckInOut.Size = new System.Drawing.Size(200, 20);
            this.dtCheckInOut.TabIndex = 14;
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.BackColor = System.Drawing.Color.Purple;
            this.btnCheckOut.Location = new System.Drawing.Point(1, 330);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(94, 44);
            this.btnCheckOut.TabIndex = 17;
            this.btnCheckOut.Text = "Check Out";
            this.btnCheckOut.UseVisualStyleBackColor = false;
            this.btnCheckOut.Visible = false;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // lblEmployeeCheckIn
            // 
            this.lblEmployeeCheckIn.AutoSize = true;
            this.lblEmployeeCheckIn.Location = new System.Drawing.Point(-1, 292);
            this.lblEmployeeCheckIn.Name = "lblEmployeeCheckIn";
            this.lblEmployeeCheckIn.Size = new System.Drawing.Size(99, 13);
            this.lblEmployeeCheckIn.TabIndex = 18;
            this.lblEmployeeCheckIn.Text = "Employee Check In";
            // 
            // lblEmployeeCheckOut
            // 
            this.lblEmployeeCheckOut.AutoSize = true;
            this.lblEmployeeCheckOut.Location = new System.Drawing.Point(-1, 293);
            this.lblEmployeeCheckOut.Name = "lblEmployeeCheckOut";
            this.lblEmployeeCheckOut.Size = new System.Drawing.Size(107, 13);
            this.lblEmployeeCheckOut.TabIndex = 19;
            this.lblEmployeeCheckOut.Text = "Employee Check Out";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Purple;
            this.btnCancel.Location = new System.Drawing.Point(218, 330);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 44);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lstEmployees
            // 
            this.lstEmployees.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CHEmployeeID,
            this.CHEmployeeName,
            this.CHEmployeeSurname});
            this.lstEmployees.FullRowSelect = true;
            this.lstEmployees.Location = new System.Drawing.Point(12, 79);
            this.lstEmployees.Name = "lstEmployees";
            this.lstEmployees.Size = new System.Drawing.Size(300, 201);
            this.lstEmployees.TabIndex = 21;
            this.lstEmployees.UseCompatibleStateImageBehavior = false;
            this.lstEmployees.View = System.Windows.Forms.View.Details;
            // 
            // CHEmployeeID
            // 
            this.CHEmployeeID.Text = "Employee ID";
            this.CHEmployeeID.Width = 100;
            // 
            // CHEmployeeName
            // 
            this.CHEmployeeName.Text = "Employee Name";
            this.CHEmployeeName.Width = 100;
            // 
            // CHEmployeeSurname
            // 
            this.CHEmployeeSurname.Text = "Employee Surname";
            this.CHEmployeeSurname.Width = 120;
            // 
            // CheckInEmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 395);
            this.ControlBox = false;
            this.Controls.Add(this.lstEmployees);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblEmployeeCheckOut);
            this.Controls.Add(this.lblEmployeeCheckIn);
            this.Controls.Add(this.dtCheckInOut);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCheckIn);
            this.Controls.Add(this.btnCheckOut);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CheckInEmployeeForm";
            this.Text = "Employee Check-in Form";
            this.Load += new System.EventHandler(this.EmployeeCheckInForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblInOut;
        private System.Windows.Forms.DateTimePicker dtCheckInOut;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.Label lblEmployeeCheckIn;
        private System.Windows.Forms.Label lblEmployeeCheckOut;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListView lstEmployees;
        private System.Windows.Forms.ColumnHeader CHEmployeeID;
        private System.Windows.Forms.ColumnHeader CHEmployeeName;
        private System.Windows.Forms.ColumnHeader CHEmployeeSurname;
    }
}