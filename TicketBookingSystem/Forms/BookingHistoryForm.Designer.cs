namespace TicketBookingSystem.Forms
{
    partial class BookingHistoryForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.dgvBookings = new System.Windows.Forms.DataGridView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).BeginInit();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(44, 160, 44);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Size = new System.Drawing.Size(850, 70);

            // lblTitle
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 18);
            this.lblTitle.Size = new System.Drawing.Size(400, 35);
            this.lblTitle.Text = "📋 My Booking History";

            // lblCount
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(50, 80, 120);
            this.lblCount.Location = new System.Drawing.Point(20, 85);
            this.lblCount.Size = new System.Drawing.Size(400, 25);
            this.lblCount.Text = "Total Bookings: 0";

            // dgvBookings
            this.dgvBookings.Location = new System.Drawing.Point(20, 120);
            this.dgvBookings.Size = new System.Drawing.Size(810, 350);
            this.dgvBookings.AllowUserToAddRows = false;
            this.dgvBookings.AllowUserToDeleteRows = false;
            this.dgvBookings.ReadOnly = true;
            this.dgvBookings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBookings.BackgroundColor = System.Drawing.Color.White;
            this.dgvBookings.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBookings.RowHeadersVisible = false;
            this.dgvBookings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBookings.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvBookings.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(44, 160, 44);
            this.dgvBookings.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvBookings.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvBookings.EnableHeadersVisualStyles = false;

            // btnCancel
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(200, 60, 60);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(20, 485);
            this.btnCancel.Size = new System.Drawing.Size(200, 42);
            this.btnCancel.Text = "❌ Cancel Booking";
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Click += new System.EventHandler(this.btnCancelBooking_Click);

            // btnBack
            this.btnBack.BackColor = System.Drawing.Color.Gray;
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBack.Location = new System.Drawing.Point(640, 485);
            this.btnBack.Size = new System.Drawing.Size(190, 42);
            this.btnBack.Text = "⬅ Back";
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // BookingHistoryForm
            this.ClientSize = new System.Drawing.Size(850, 545);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.dgvBookings);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBack);
            this.BackColor = System.Drawing.Color.FromArgb(240, 245, 255);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "BookingHistoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My Bookings";
            this.Load += new System.EventHandler(this.BookingHistoryForm_Load);
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.DataGridView dgvBookings;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBack;
    }
}