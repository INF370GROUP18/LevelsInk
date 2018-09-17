namespace Nati_Supermarket_and_Takeaway_WinForms
{
    partial class CashUpForm
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
            this.lblDailySales = new System.Windows.Forms.Label();
            this.lblCashInTil = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NUD1 = new System.Windows.Forms.NumericUpDown();
            this.NUD2 = new System.Windows.Forms.NumericUpDown();
            this.NUD5 = new System.Windows.Forms.NumericUpDown();
            this.NUD10 = new System.Windows.Forms.NumericUpDown();
            this.NUD20 = new System.Windows.Forms.NumericUpDown();
            this.NUD50 = new System.Windows.Forms.NumericUpDown();
            this.NUD100 = new System.Windows.Forms.NumericUpDown();
            this.NUD200 = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCashUp = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.lblNotificationMessage = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.lblDailySaleValue = new System.Windows.Forms.Label();
            this.lblCashInTilValue = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD100)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD200)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDailySales
            // 
            this.lblDailySales.AutoSize = true;
            this.lblDailySales.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDailySales.Location = new System.Drawing.Point(12, 63);
            this.lblDailySales.Name = "lblDailySales";
            this.lblDailySales.Size = new System.Drawing.Size(108, 23);
            this.lblDailySales.TabIndex = 0;
            this.lblDailySales.Text = "Daily Sales:";
            this.lblDailySales.Click += new System.EventHandler(this.lblDailySales_Click_1);
            // 
            // lblCashInTil
            // 
            this.lblCashInTil.AutoSize = true;
            this.lblCashInTil.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashInTil.Location = new System.Drawing.Point(12, 86);
            this.lblCashInTil.Name = "lblCashInTil";
            this.lblCashInTil.Size = new System.Drawing.Size(112, 23);
            this.lblCashInTil.TabIndex = 2;
            this.lblCashInTil.Text = "Cash in Till:";
            this.lblCashInTil.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.NUD1);
            this.groupBox1.Controls.Add(this.NUD2);
            this.groupBox1.Controls.Add(this.NUD5);
            this.groupBox1.Controls.Add(this.NUD10);
            this.groupBox1.Controls.Add(this.NUD20);
            this.groupBox1.Controls.Add(this.NUD50);
            this.groupBox1.Controls.Add(this.NUD100);
            this.groupBox1.Controls.Add(this.NUD200);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(18, 290);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(493, 161);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cash";
            // 
            // NUD1
            // 
            this.NUD1.Location = new System.Drawing.Point(371, 104);
            this.NUD1.Name = "NUD1";
            this.NUD1.Size = new System.Drawing.Size(67, 29);
            this.NUD1.TabIndex = 5;
            // 
            // NUD2
            // 
            this.NUD2.Location = new System.Drawing.Point(371, 69);
            this.NUD2.Name = "NUD2";
            this.NUD2.Size = new System.Drawing.Size(67, 29);
            this.NUD2.TabIndex = 15;
            // 
            // NUD5
            // 
            this.NUD5.Location = new System.Drawing.Point(371, 43);
            this.NUD5.Name = "NUD5";
            this.NUD5.Size = new System.Drawing.Size(67, 29);
            this.NUD5.TabIndex = 14;
            // 
            // NUD10
            // 
            this.NUD10.Location = new System.Drawing.Point(371, 17);
            this.NUD10.Name = "NUD10";
            this.NUD10.Size = new System.Drawing.Size(67, 29);
            this.NUD10.TabIndex = 13;
            // 
            // NUD20
            // 
            this.NUD20.Location = new System.Drawing.Point(114, 106);
            this.NUD20.Name = "NUD20";
            this.NUD20.Size = new System.Drawing.Size(67, 29);
            this.NUD20.TabIndex = 12;
            // 
            // NUD50
            // 
            this.NUD50.Location = new System.Drawing.Point(114, 80);
            this.NUD50.Name = "NUD50";
            this.NUD50.Size = new System.Drawing.Size(67, 29);
            this.NUD50.TabIndex = 11;
            // 
            // NUD100
            // 
            this.NUD100.Location = new System.Drawing.Point(114, 51);
            this.NUD100.Name = "NUD100";
            this.NUD100.Size = new System.Drawing.Size(67, 29);
            this.NUD100.TabIndex = 10;
            // 
            // NUD200
            // 
            this.NUD200.Location = new System.Drawing.Point(114, 21);
            this.NUD200.Name = "NUD200";
            this.NUD200.Size = new System.Drawing.Size(67, 29);
            this.NUD200.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 229);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 23);
            this.label11.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(264, 101);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 23);
            this.label10.TabIndex = 7;
            this.label10.Text = "R1:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(264, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 23);
            this.label9.TabIndex = 6;
            this.label9.Text = "R2:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(264, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 23);
            this.label8.TabIndex = 5;
            this.label8.Text = "R5:";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(264, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 23);
            this.label7.TabIndex = 4;
            this.label7.Text = "R10:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 23);
            this.label6.TabIndex = 3;
            this.label6.Text = "R20:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 23);
            this.label5.TabIndex = 2;
            this.label5.Text = "R50:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 23);
            this.label4.TabIndex = 1;
            this.label4.Text = "R100:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "R200:";
            // 
            // btnCashUp
            // 
            this.btnCashUp.BackColor = System.Drawing.Color.Purple;
            this.btnCashUp.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCashUp.Location = new System.Drawing.Point(18, 457);
            this.btnCashUp.Name = "btnCashUp";
            this.btnCashUp.Size = new System.Drawing.Size(196, 51);
            this.btnCashUp.TabIndex = 5;
            this.btnCashUp.Text = "Enter Cash on Hand";
            this.btnCashUp.UseVisualStyleBackColor = false;
            this.btnCashUp.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.BackColor = System.Drawing.Color.Purple;
            this.btnMenu.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu.Location = new System.Drawing.Point(327, 457);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(195, 51);
            this.btnMenu.TabIndex = 6;
            this.btnMenu.Text = "Go to Main Menu";
            this.btnMenu.UseVisualStyleBackColor = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // lblNotificationMessage
            // 
            this.lblNotificationMessage.AutoSize = true;
            this.lblNotificationMessage.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotificationMessage.Location = new System.Drawing.Point(12, 255);
            this.lblNotificationMessage.Name = "lblNotificationMessage";
            this.lblNotificationMessage.Size = new System.Drawing.Size(56, 14);
            this.lblNotificationMessage.TabIndex = 7;
            this.lblNotificationMessage.Text = "Default";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Purple;
            this.panel1.Controls.Add(this.label12);
            this.panel1.Location = new System.Drawing.Point(0, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(532, 57);
            this.panel1.TabIndex = 8;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Georgia", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(44, 6);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(415, 41);
            this.label12.TabIndex = 0;
            this.label12.Text = "Cash Up (Reconcilliation)";
            // 
            // lblDailySaleValue
            // 
            this.lblDailySaleValue.AutoSize = true;
            this.lblDailySaleValue.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDailySaleValue.Location = new System.Drawing.Point(130, 63);
            this.lblDailySaleValue.Name = "lblDailySaleValue";
            this.lblDailySaleValue.Size = new System.Drawing.Size(72, 23);
            this.lblDailySaleValue.TabIndex = 9;
            this.lblDailySaleValue.Text = "Default";
            this.lblDailySaleValue.Visible = false;
            // 
            // lblCashInTilValue
            // 
            this.lblCashInTilValue.AutoSize = true;
            this.lblCashInTilValue.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashInTilValue.Location = new System.Drawing.Point(140, 86);
            this.lblCashInTilValue.Name = "lblCashInTilValue";
            this.lblCashInTilValue.Size = new System.Drawing.Size(72, 23);
            this.lblCashInTilValue.TabIndex = 10;
            this.lblCashInTilValue.Text = "Default";
            this.lblCashInTilValue.Visible = false;
            // 
            // CashUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 533);
            this.Controls.Add(this.lblCashInTilValue);
            this.Controls.Add(this.lblDailySaleValue);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblNotificationMessage);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.btnCashUp);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblCashInTil);
            this.Controls.Add(this.lblDailySales);
            this.Name = "CashUpForm";
            this.Text = "CashUpForm";
            this.Load += new System.EventHandler(this.CashUpForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD100)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD200)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDailySales;
        private System.Windows.Forms.Label lblCashInTil;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown NUD1;
        private System.Windows.Forms.NumericUpDown NUD2;
        private System.Windows.Forms.NumericUpDown NUD5;
        private System.Windows.Forms.NumericUpDown NUD10;
        private System.Windows.Forms.NumericUpDown NUD20;
        private System.Windows.Forms.NumericUpDown NUD50;
        private System.Windows.Forms.NumericUpDown NUD100;
        private System.Windows.Forms.NumericUpDown NUD200;
        private System.Windows.Forms.Button btnCashUp;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Label lblNotificationMessage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblDailySaleValue;
        private System.Windows.Forms.Label lblCashInTilValue;
    }
}