namespace Nati_Supermarket_and_Takeaway_WinForms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ToolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnInventory = new System.Windows.Forms.Button();
            this.btnEmployee = new System.Windows.Forms.Button();
            this.btnPOS = new System.Windows.Forms.Button();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.btnBackUpSystem = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnMenuItem = new System.Windows.Forms.Button();
            this.btnCashUp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUser = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLockSystem = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCheckInEmployee = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.btnCheckOutEmployee = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.btnRestoreSystem = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.btnSupplierOrder = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.ToolStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Timer1
            // 
            this.Timer1.Enabled = true;
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // ToolStripLabel1
            // 
            this.ToolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ToolStripLabel1.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripLabel1.ForeColor = System.Drawing.Color.White;
            this.ToolStripLabel1.Name = "ToolStripLabel1";
            this.ToolStripLabel1.Size = new System.Drawing.Size(133, 22);
            this.ToolStripLabel1.Text = "ToolStripLabel1";
            this.ToolStripLabel1.Click += new System.EventHandler(this.ToolStripLabel1_Click);
            // 
            // ToolStrip
            // 
            this.ToolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ToolStrip.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripLabel1});
            this.ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Size = new System.Drawing.Size(654, 25);
            this.ToolStrip.TabIndex = 10;
            this.ToolStrip.Text = "ToolStrip";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(146, 177);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 15);
            this.label10.TabIndex = 29;
            this.label10.Text = "Inventory";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(14, 405);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 18);
            this.label11.TabIndex = 27;
            this.label11.Text = "Backup System";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(515, 421);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 18);
            this.label3.TabIndex = 26;
            this.label3.Text = "&EXIT";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(276, 288);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 15);
            this.label9.TabIndex = 24;
            this.label9.Text = "Employee";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(14, 177);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "POS";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(269, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Menu Item";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(22, 290);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Supplier";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(407, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Cash Up";
            // 
            // btnInventory
            // 
            this.btnInventory.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnInventory.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnInventory.BackgroundImage")));
            this.btnInventory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInventory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInventory.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnInventory.FlatAppearance.BorderSize = 0;
            this.btnInventory.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.btnInventory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInventory.Location = new System.Drawing.Point(142, 82);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(105, 94);
            this.btnInventory.TabIndex = 19;
            this.btnInventory.UseVisualStyleBackColor = false;
            this.btnInventory.Click += new System.EventHandler(this.btnStocksReport_Click);
            // 
            // btnEmployee
            // 
            this.btnEmployee.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnEmployee.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEmployee.BackgroundImage")));
            this.btnEmployee.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEmployee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEmployee.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnEmployee.FlatAppearance.BorderSize = 0;
            this.btnEmployee.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.btnEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEmployee.Location = new System.Drawing.Point(272, 193);
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Size = new System.Drawing.Size(105, 94);
            this.btnEmployee.TabIndex = 18;
            this.btnEmployee.UseVisualStyleBackColor = false;
            this.btnEmployee.Click += new System.EventHandler(this.btnDailySales_Click);
            // 
            // btnPOS
            // 
            this.btnPOS.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnPOS.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPOS.BackgroundImage")));
            this.btnPOS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPOS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPOS.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPOS.FlatAppearance.BorderSize = 0;
            this.btnPOS.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.btnPOS.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPOS.Location = new System.Drawing.Point(12, 80);
            this.btnPOS.Name = "btnPOS";
            this.btnPOS.Size = new System.Drawing.Size(105, 94);
            this.btnPOS.TabIndex = 17;
            this.btnPOS.UseVisualStyleBackColor = false;
            this.btnPOS.Click += new System.EventHandler(this.btnPOS_Click);
            // 
            // btnSupplier
            // 
            this.btnSupplier.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSupplier.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSupplier.BackgroundImage")));
            this.btnSupplier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSupplier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSupplier.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSupplier.FlatAppearance.BorderSize = 0;
            this.btnSupplier.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.btnSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSupplier.Location = new System.Drawing.Point(12, 193);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Size = new System.Drawing.Size(105, 94);
            this.btnSupplier.TabIndex = 15;
            this.btnSupplier.UseVisualStyleBackColor = false;
            this.btnSupplier.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // btnBackUpSystem
            // 
            this.btnBackUpSystem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnBackUpSystem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBackUpSystem.BackgroundImage")));
            this.btnBackUpSystem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBackUpSystem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackUpSystem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnBackUpSystem.FlatAppearance.BorderSize = 0;
            this.btnBackUpSystem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.btnBackUpSystem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBackUpSystem.Location = new System.Drawing.Point(12, 308);
            this.btnBackUpSystem.Name = "btnBackUpSystem";
            this.btnBackUpSystem.Size = new System.Drawing.Size(105, 94);
            this.btnBackUpSystem.TabIndex = 14;
            this.btnBackUpSystem.UseVisualStyleBackColor = false;
            this.btnBackUpSystem.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Location = new System.Drawing.Point(526, 308);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(105, 94);
            this.btnExit.TabIndex = 13;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnMenuItem
            // 
            this.btnMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnMenuItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMenuItem.BackgroundImage")));
            this.btnMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMenuItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuItem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnMenuItem.FlatAppearance.BorderSize = 0;
            this.btnMenuItem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.btnMenuItem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMenuItem.Location = new System.Drawing.Point(272, 80);
            this.btnMenuItem.Name = "btnMenuItem";
            this.btnMenuItem.Size = new System.Drawing.Size(105, 94);
            this.btnMenuItem.TabIndex = 20;
            this.btnMenuItem.UseVisualStyleBackColor = false;
            this.btnMenuItem.Click += new System.EventHandler(this.btnMenuItem_Click);
            // 
            // btnCashUp
            // 
            this.btnCashUp.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnCashUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCashUp.BackgroundImage")));
            this.btnCashUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCashUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCashUp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCashUp.FlatAppearance.BorderSize = 0;
            this.btnCashUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.btnCashUp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCashUp.Location = new System.Drawing.Point(405, 80);
            this.btnCashUp.Name = "btnCashUp";
            this.btnCashUp.Size = new System.Drawing.Size(105, 94);
            this.btnCashUp.TabIndex = 12;
            this.btnCashUp.UseVisualStyleBackColor = false;
            this.btnCashUp.Click += new System.EventHandler(this.btnStaff_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(402, 405);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 18);
            this.label1.TabIndex = 31;
            this.label1.Text = "Logout";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnLogout.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLogout.BackgroundImage")));
            this.btnLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogout.Location = new System.Drawing.Point(405, 308);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(105, 94);
            this.btnLogout.TabIndex = 30;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Purple;
            this.panel1.Controls.Add(this.lblUser);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 448);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(664, 50);
            this.panel1.TabIndex = 32;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(12, 15);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(59, 18);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "Default";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(269, 405);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 31);
            this.label2.TabIndex = 24;
            this.label2.Text = "Lock System";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnLockSystem
            // 
            this.btnLockSystem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnLockSystem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLockSystem.BackgroundImage")));
            this.btnLockSystem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLockSystem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLockSystem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnLockSystem.FlatAppearance.BorderSize = 0;
            this.btnLockSystem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.btnLockSystem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLockSystem.Location = new System.Drawing.Point(272, 308);
            this.btnLockSystem.Name = "btnLockSystem";
            this.btnLockSystem.Size = new System.Drawing.Size(105, 94);
            this.btnLockSystem.TabIndex = 33;
            this.btnLockSystem.UseVisualStyleBackColor = false;
            this.btnLockSystem.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(402, 288);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 15);
            this.label4.TabIndex = 35;
            this.label4.Text = "Check In Employee";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnCheckInEmployee
            // 
            this.btnCheckInEmployee.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnCheckInEmployee.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCheckInEmployee.BackgroundImage")));
            this.btnCheckInEmployee.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCheckInEmployee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheckInEmployee.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCheckInEmployee.FlatAppearance.BorderSize = 0;
            this.btnCheckInEmployee.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.btnCheckInEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCheckInEmployee.Location = new System.Drawing.Point(405, 193);
            this.btnCheckInEmployee.Name = "btnCheckInEmployee";
            this.btnCheckInEmployee.Size = new System.Drawing.Size(105, 94);
            this.btnCheckInEmployee.TabIndex = 34;
            this.btnCheckInEmployee.UseVisualStyleBackColor = false;
            this.btnCheckInEmployee.Click += new System.EventHandler(this.btnCheckInEmployee_Click);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(523, 290);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(128, 20);
            this.label12.TabIndex = 35;
            this.label12.Text = "Check Out Employee";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnCheckOutEmployee
            // 
            this.btnCheckOutEmployee.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnCheckOutEmployee.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCheckOutEmployee.BackgroundImage")));
            this.btnCheckOutEmployee.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCheckOutEmployee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheckOutEmployee.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCheckOutEmployee.FlatAppearance.BorderSize = 0;
            this.btnCheckOutEmployee.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.btnCheckOutEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCheckOutEmployee.Location = new System.Drawing.Point(526, 193);
            this.btnCheckOutEmployee.Name = "btnCheckOutEmployee";
            this.btnCheckOutEmployee.Size = new System.Drawing.Size(105, 94);
            this.btnCheckOutEmployee.TabIndex = 36;
            this.btnCheckOutEmployee.UseVisualStyleBackColor = false;
            this.btnCheckOutEmployee.Click += new System.EventHandler(this.btnCheckOutEmployee_Click);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(146, 405);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(102, 18);
            this.label13.TabIndex = 38;
            this.label13.Text = "Restore System";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnRestoreSystem
            // 
            this.btnRestoreSystem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnRestoreSystem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRestoreSystem.BackgroundImage")));
            this.btnRestoreSystem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRestoreSystem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestoreSystem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnRestoreSystem.FlatAppearance.BorderSize = 0;
            this.btnRestoreSystem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.btnRestoreSystem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRestoreSystem.Location = new System.Drawing.Point(142, 308);
            this.btnRestoreSystem.Name = "btnRestoreSystem";
            this.btnRestoreSystem.Size = new System.Drawing.Size(105, 94);
            this.btnRestoreSystem.TabIndex = 37;
            this.btnRestoreSystem.UseVisualStyleBackColor = false;
            this.btnRestoreSystem.Click += new System.EventHandler(this.btnRestoreSystem_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(139, 288);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(91, 13);
            this.label14.TabIndex = 40;
            this.label14.Text = "Supplier Order";
            // 
            // btnSupplierOrder
            // 
            this.btnSupplierOrder.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSupplierOrder.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSupplierOrder.BackgroundImage")));
            this.btnSupplierOrder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSupplierOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSupplierOrder.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSupplierOrder.FlatAppearance.BorderSize = 0;
            this.btnSupplierOrder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.btnSupplierOrder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSupplierOrder.Location = new System.Drawing.Point(142, 193);
            this.btnSupplierOrder.Name = "btnSupplierOrder";
            this.btnSupplierOrder.Size = new System.Drawing.Size(105, 94);
            this.btnSupplierOrder.TabIndex = 39;
            this.btnSupplierOrder.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Purple;
            this.panel2.Controls.Add(this.label15);
            this.panel2.Location = new System.Drawing.Point(0, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(654, 47);
            this.panel2.TabIndex = 41;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(12, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(361, 29);
            this.label15.TabIndex = 0;
            this.label15.Text = "Nati Supermarket and Takeaway";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 502);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnSupplierOrder);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnRestoreSystem);
            this.Controls.Add(this.btnCheckOutEmployee);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCheckInEmployee);
            this.Controls.Add(this.btnLockSystem);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnInventory);
            this.Controls.Add(this.btnEmployee);
            this.Controls.Add(this.btnPOS);
            this.Controls.Add(this.btnSupplier);
            this.Controls.Add(this.btnBackUpSystem);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnMenuItem);
            this.Controls.Add(this.btnCashUp);
            this.Controls.Add(this.ToolStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Menu";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Timer Timer1;
        internal System.Windows.Forms.ToolTip ToolTip;
        internal System.Windows.Forms.ToolStripLabel ToolStripLabel1;
        internal System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnEmployee;
        private System.Windows.Forms.Button btnPOS;
        private System.Windows.Forms.Button btnSupplier;
        private System.Windows.Forms.Button btnBackUpSystem;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnMenuItem;
        private System.Windows.Forms.Button btnCashUp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLockSystem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCheckInEmployee;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnCheckOutEmployee;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnRestoreSystem;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnSupplierOrder;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label15;
    }
}