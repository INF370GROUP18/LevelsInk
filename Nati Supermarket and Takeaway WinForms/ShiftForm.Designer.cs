namespace Nati_Supermarket_and_Takeaway_WinForms
{
    partial class ShiftForm
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
            this.calendar1 = new WindowsFormsCalendar.Calendar();
            this.SuspendLayout();
            // 
            // calendar1
            // 
            this.calendar1.AllowDrop = true;
            this.calendar1.CalendarTimeFormat = WindowsFormsCalendar.CalendarTimeFormat.TwentyFourHour;
            this.calendar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calendar1.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.calendar1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.calendar1.ItemsBackgroundColor = System.Drawing.Color.Red;
            this.calendar1.ItemsFont = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calendar1.ItemsForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.calendar1.Location = new System.Drawing.Point(0, 0);
            this.calendar1.Name = "calendar1";
            this.calendar1.Scrollbars = WindowsFormsCalendar.CalendarScrollBars.Horizontal;
            this.calendar1.Size = new System.Drawing.Size(871, 445);
            this.calendar1.TabIndex = 1;
            this.calendar1.Text = "calendar1";
            this.calendar1.TimeScale = WindowsFormsCalendar.CalendarTimeScale.SixtyMinutes;
            // 
            // ShiftForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 445);
            this.Controls.Add(this.calendar1);
            this.Name = "ShiftForm";
            this.Text = "ShiftForm";
            this.Load += new System.EventHandler(this.ShiftForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private WindowsFormsCalendar.Calendar calendar1;
    }
}