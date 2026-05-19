namespace TicketBookingSystem.Forms
{
    partial class SearchTicketsForm
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
            this.lblFrom = new System.Windows.Forms.Label();
            this.cmbFrom = new System.Windows.Forms.ComboBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.cmbTo = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.dgvTickets = new System.Windows.Forms.DataGridView();
            this.lblResults = new System.Windows.Forms.Label();
            this.btnBook = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTickets)).BeginInit();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Size = new System.Drawing.Size(850, 70);

            // lblTitle
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 18);
            this.lblTitle.Size = new System.Drawing.Size(400, 35);
            this.lblTitle.Text = "🔍 Search Tickets";

            // lblFrom
            this.lblFrom.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblFrom.Location = new System.Drawing.Point(20, 90);
            this.lblFrom.Size = new System.Drawing.Size(150, 22);
            this.lblFrom.Text = "From (Source):";

            // cmbFrom
            this.cmbFrom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbFrom.Location = new System.Drawing.Point(20, 115);
            this.cmbFrom.Size = new System.Drawing.Size(180, 28);
            this.cmbFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFrom.Items.AddRange(new object[] {
                "Faisalabad", "Lahore", "Karachi",
                "Islamabad", "Multan", "Peshawar"});

            // lblTo
            this.lblTo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTo.Location = new System.Drawing.Point(220, 90);
            this.lblTo.Size = new System.Drawing.Size(150, 22);
            this.lblTo.Text = "To (Destination):";

            // cmbTo
            this.cmbTo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTo.Location = new System.Drawing.Point(220, 115);
            this.cmbTo.Size = new System.Drawing.Size(180, 28);
            this.cmbTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTo.Items.AddRange(new object[] {
                "Faisalabad", "Lahore", "Karachi",
                "Islamabad", "Multan", "Peshawar"});

            // lblDate
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDate.Location = new System.Drawing.Point(420, 90);
            this.lblDate.Size = new System.Drawing.Size(150, 22);
            this.lblDate.Text = "Travel Date:";

            // dtpDate
            this.dtpDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDate.Location = new System.Drawing.Point(420, 115);
            this.dtpDate.Size = new System.Drawing.Size(180, 28);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.MinDate = System.DateTime.Today;

            // lblCategory
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCategory.Location = new System.Drawing.Point(620, 90);
            this.lblCategory.Size = new System.Drawing.Size(150, 22);
            this.lblCategory.Text = "Category:";

            // cmbCategory
            this.cmbCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbCategory.Location = new System.Drawing.Point(620, 115);
            this.cmbCategory.Size = new System.Drawing.Size(150, 28);
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Items.AddRange(new object[] { "All", "Bus", "Train" });
            this.cmbCategory.SelectedIndex = 0;

            // btnSearch
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSearch.Location = new System.Drawing.Point(20, 160);
            this.btnSearch.Size = new System.Drawing.Size(150, 40);
            this.btnSearch.Text = "🔍 SEARCH";
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // btnBack
            this.btnBack.BackColor = System.Drawing.Color.Gray;
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBack.Location = new System.Drawing.Point(190, 160);
            this.btnBack.Size = new System.Drawing.Size(150, 40);
            this.btnBack.Text = "⬅ BACK";
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // lblResults
            this.lblResults.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblResults.ForeColor = System.Drawing.Color.FromArgb(50, 80, 120);
            this.lblResults.Location = new System.Drawing.Point(20, 215);
            this.lblResults.Size = new System.Drawing.Size(400, 25);
            this.lblResults.Text = "Available Tickets:";

            // dgvTickets
            this.dgvTickets.Location = new System.Drawing.Point(20, 245);
            this.dgvTickets.Size = new System.Drawing.Size(810, 280);
            this.dgvTickets.AllowUserToAddRows = false;
            this.dgvTickets.AllowUserToDeleteRows = false;
            this.dgvTickets.ReadOnly = true;
            this.dgvTickets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTickets.BackgroundColor = System.Drawing.Color.White;
            this.dgvTickets.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTickets.RowHeadersVisible = false;
            this.dgvTickets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTickets.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvTickets.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.dgvTickets.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvTickets.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvTickets.EnableHeadersVisualStyles = false;

            // btnBook
            this.btnBook.BackColor = System.Drawing.Color.FromArgb(44, 160, 44);
            this.btnBook.ForeColor = System.Drawing.Color.White;
            this.btnBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBook.FlatAppearance.BorderSize = 0;
            this.btnBook.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnBook.Location = new System.Drawing.Point(620, 540);
            this.btnBook.Size = new System.Drawing.Size(210, 45);
            this.btnBook.Text = "🎫 BOOK TICKET";
            this.btnBook.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);

            // SearchTicketsForm
            this.ClientSize = new System.Drawing.Size(850, 600);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.cmbFrom);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.cmbTo);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.dgvTickets);
            this.Controls.Add(this.btnBook);
            this.BackColor = System.Drawing.Color.FromArgb(240, 245, 255);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SearchTicketsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Tickets";
            this.Load += new System.EventHandler(this.SearchTicketsForm_Load);
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTickets)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.ComboBox cmbFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.ComboBox cmbTo;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.DataGridView dgvTickets;
        private System.Windows.Forms.Button btnBook;
    }
}