namespace TicketBookingSystem.Forms
{
    partial class MainDashboard
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
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblSection = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnMyBookings = new System.Windows.Forms.Button();
            this.btnFeedback = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.pnlHeader.Controls.Add(this.lblAppTitle);
            this.pnlHeader.Controls.Add(this.lblWelcome);
            this.pnlHeader.Controls.Add(this.btnLogout);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Size = new System.Drawing.Size(800, 90);

            // lblAppTitle
            this.lblAppTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblAppTitle.ForeColor = System.Drawing.Color.White;
            this.lblAppTitle.Location = new System.Drawing.Point(20, 15);
            this.lblAppTitle.Size = new System.Drawing.Size(500, 35);
            this.lblAppTitle.Text = "🚌 Online Ticket Booking System";

            // lblWelcome
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(180, 210, 240);
            this.lblWelcome.Location = new System.Drawing.Point(20, 55);
            this.lblWelcome.Size = new System.Drawing.Size(400, 22);
            this.lblWelcome.Text = "Welcome!";

            // btnLogout
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(200, 60, 60);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLogout.Location = new System.Drawing.Point(680, 28);
            this.btnLogout.Size = new System.Drawing.Size(100, 35);
            this.btnLogout.Text = "🔓 Logout";
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // lblSection
            this.lblSection.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSection.ForeColor = System.Drawing.Color.FromArgb(50, 80, 120);
            this.lblSection.Location = new System.Drawing.Point(40, 110);
            this.lblSection.Size = new System.Drawing.Size(400, 30);
            this.lblSection.Text = "What would you like to do?";

            // btnSearch
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(31, 119, 180);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSearch.Location = new System.Drawing.Point(40, 160);
            this.btnSearch.Size = new System.Drawing.Size(200, 150);
            this.btnSearch.Text = "🔍\n\nSearch Tickets\n(Bus / Train)";
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // btnMyBookings
            this.btnMyBookings.BackColor = System.Drawing.Color.FromArgb(44, 160, 44);
            this.btnMyBookings.ForeColor = System.Drawing.Color.White;
            this.btnMyBookings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyBookings.FlatAppearance.BorderSize = 0;
            this.btnMyBookings.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMyBookings.Location = new System.Drawing.Point(270, 160);
            this.btnMyBookings.Size = new System.Drawing.Size(200, 150);
            this.btnMyBookings.Text = "📋\n\nMy Bookings\n(View / Cancel)";
            this.btnMyBookings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMyBookings.Click += new System.EventHandler(this.btnMyBookings_Click);

            // btnFeedback
            this.btnFeedback.BackColor = System.Drawing.Color.FromArgb(188, 128, 0);
            this.btnFeedback.ForeColor = System.Drawing.Color.White;
            this.btnFeedback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFeedback.FlatAppearance.BorderSize = 0;
            this.btnFeedback.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnFeedback.Location = new System.Drawing.Point(500, 160);
            this.btnFeedback.Size = new System.Drawing.Size(200, 150);
            this.btnFeedback.Text = "⭐\n\nGive Feedback\n(Rate your trip)";
            this.btnFeedback.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFeedback.Click += new System.EventHandler(this.btnFeedback_Click);

            // MainDashboard
            this.ClientSize = new System.Drawing.Size(760, 400);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.lblSection);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnMyBookings);
            this.Controls.Add(this.btnFeedback);
            this.BackColor = System.Drawing.Color.FromArgb(240, 245, 255);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Online Ticket Booking - Dashboard";
            this.Load += new System.EventHandler(this.MainDashboard_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainDashboard_FormClosed);
            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblSection;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnMyBookings;
        private System.Windows.Forms.Button btnFeedback;
    }
}