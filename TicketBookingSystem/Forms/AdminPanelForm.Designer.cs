namespace TicketBookingSystem.Forms
{
    partial class AdminPanelForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabRoutes = new System.Windows.Forms.TabPage();
            this.lblSource = new System.Windows.Forms.Label();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.lblDestination = new System.Windows.Forms.Label();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.lblDistance = new System.Windows.Forms.Label();
            this.txtDistance = new System.Windows.Forms.TextBox();
            this.lblDuration = new System.Windows.Forms.Label();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.lblRouteCategory = new System.Windows.Forms.Label();
            this.cmbRouteCategory = new System.Windows.Forms.ComboBox();
            this.btnAddRoute = new System.Windows.Forms.Button();
            this.btnDeleteRoute = new System.Windows.Forms.Button();
            this.dgvRoutes = new System.Windows.Forms.DataGridView();
            this.tabTickets = new System.Windows.Forms.TabPage();
            this.dgvAllBookings = new System.Windows.Forms.DataGridView();
            this.btnBack = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabRoutes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoutes)).BeginInit();
            this.tabTickets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllBookings)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(80)))), ((int)(((byte)(0)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(900, 70);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(400, 35);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "⚙️ Admin Panel";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabRoutes);
            this.tabControl.Controls.Add(this.tabTickets);
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.tabControl.Location = new System.Drawing.Point(15, 85);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(865, 490);
            this.tabControl.TabIndex = 1;
            // 
            // tabRoutes
            // 
            this.tabRoutes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.tabRoutes.Controls.Add(this.lblSource);
            this.tabRoutes.Controls.Add(this.txtSource);
            this.tabRoutes.Controls.Add(this.lblDestination);
            this.tabRoutes.Controls.Add(this.txtDestination);
            this.tabRoutes.Controls.Add(this.lblDistance);
            this.tabRoutes.Controls.Add(this.txtDistance);
            this.tabRoutes.Controls.Add(this.lblDuration);
            this.tabRoutes.Controls.Add(this.txtDuration);
            this.tabRoutes.Controls.Add(this.lblRouteCategory);
            this.tabRoutes.Controls.Add(this.cmbRouteCategory);
            this.tabRoutes.Controls.Add(this.btnAddRoute);
            this.tabRoutes.Controls.Add(this.btnDeleteRoute);
            this.tabRoutes.Controls.Add(this.dgvRoutes);
            this.tabRoutes.Location = new System.Drawing.Point(4, 37);
            this.tabRoutes.Name = "tabRoutes";
            this.tabRoutes.Size = new System.Drawing.Size(857, 449);
            this.tabRoutes.TabIndex = 0;
            this.tabRoutes.Text = "🛣️ Manage Routes";
            // 
            // lblSource
            // 
            this.lblSource.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSource.Location = new System.Drawing.Point(10, 15);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(120, 22);
            this.lblSource.TabIndex = 0;
            this.lblSource.Text = "Source City:";
            // 
            // txtSource
            // 
            this.txtSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSource.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSource.Location = new System.Drawing.Point(10, 38);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(140, 34);
            this.txtSource.TabIndex = 1;
            // 
            // lblDestination
            // 
            this.lblDestination.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDestination.Location = new System.Drawing.Point(165, 15);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(140, 22);
            this.lblDestination.TabIndex = 2;
            this.lblDestination.Text = "Destination City:";
            // 
            // txtDestination
            // 
            this.txtDestination.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDestination.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDestination.Location = new System.Drawing.Point(165, 38);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(140, 34);
            this.txtDestination.TabIndex = 3;
            // 
            // lblDistance
            // 
            this.lblDistance.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDistance.Location = new System.Drawing.Point(320, 15);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(100, 22);
            this.lblDistance.TabIndex = 4;
            this.lblDistance.Text = "Distance (km):";
            // 
            // txtDistance
            // 
            this.txtDistance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDistance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDistance.Location = new System.Drawing.Point(320, 38);
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.Size = new System.Drawing.Size(100, 34);
            this.txtDistance.TabIndex = 5;
            // 
            // lblDuration
            // 
            this.lblDuration.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDuration.Location = new System.Drawing.Point(435, 15);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(100, 22);
            this.lblDuration.TabIndex = 6;
            this.lblDuration.Text = "Duration:";
            // 
            // txtDuration
            // 
            this.txtDuration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDuration.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDuration.Location = new System.Drawing.Point(435, 38);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(120, 34);
            this.txtDuration.TabIndex = 7;
            this.txtDuration.Text = "e.g. 2h 30min";
            // 
            // lblRouteCategory
            // 
            this.lblRouteCategory.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblRouteCategory.Location = new System.Drawing.Point(570, 15);
            this.lblRouteCategory.Name = "lblRouteCategory";
            this.lblRouteCategory.Size = new System.Drawing.Size(100, 22);
            this.lblRouteCategory.TabIndex = 8;
            this.lblRouteCategory.Text = "Category:";
            // 
            // cmbRouteCategory
            // 
            this.cmbRouteCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRouteCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbRouteCategory.Items.AddRange(new object[] {
            "Bus",
            "Train"});
            this.cmbRouteCategory.Location = new System.Drawing.Point(570, 38);
            this.cmbRouteCategory.Name = "cmbRouteCategory";
            this.cmbRouteCategory.Size = new System.Drawing.Size(100, 36);
            this.cmbRouteCategory.TabIndex = 9;
            // 
            // btnAddRoute
            // 
            this.btnAddRoute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.btnAddRoute.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddRoute.FlatAppearance.BorderSize = 0;
            this.btnAddRoute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddRoute.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnAddRoute.ForeColor = System.Drawing.Color.White;
            this.btnAddRoute.Location = new System.Drawing.Point(685, 33);
            this.btnAddRoute.Name = "btnAddRoute";
            this.btnAddRoute.Size = new System.Drawing.Size(80, 38);
            this.btnAddRoute.TabIndex = 10;
            this.btnAddRoute.Text = "➕ Add";
            this.btnAddRoute.UseVisualStyleBackColor = false;
            this.btnAddRoute.Click += new System.EventHandler(this.btnAddRoute_Click);
            // 
            // btnDeleteRoute
            // 
            this.btnDeleteRoute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnDeleteRoute.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteRoute.FlatAppearance.BorderSize = 0;
            this.btnDeleteRoute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteRoute.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnDeleteRoute.ForeColor = System.Drawing.Color.White;
            this.btnDeleteRoute.Location = new System.Drawing.Point(775, 33);
            this.btnDeleteRoute.Name = "btnDeleteRoute";
            this.btnDeleteRoute.Size = new System.Drawing.Size(80, 38);
            this.btnDeleteRoute.TabIndex = 11;
            this.btnDeleteRoute.Text = "🗑 Delete";
            this.btnDeleteRoute.UseVisualStyleBackColor = false;
            this.btnDeleteRoute.Click += new System.EventHandler(this.btnDeleteRoute_Click);
            // 
            // dgvRoutes
            // 
            this.dgvRoutes.AllowUserToAddRows = false;
            this.dgvRoutes.AllowUserToDeleteRows = false;
            this.dgvRoutes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRoutes.BackgroundColor = System.Drawing.Color.White;
            this.dgvRoutes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(80)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRoutes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRoutes.ColumnHeadersHeight = 34;
            this.dgvRoutes.EnableHeadersVisualStyles = false;
            this.dgvRoutes.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvRoutes.Location = new System.Drawing.Point(10, 85);
            this.dgvRoutes.Name = "dgvRoutes";
            this.dgvRoutes.ReadOnly = true;
            this.dgvRoutes.RowHeadersVisible = false;
            this.dgvRoutes.RowHeadersWidth = 62;
            this.dgvRoutes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRoutes.Size = new System.Drawing.Size(840, 360);
            this.dgvRoutes.TabIndex = 12;
            this.dgvRoutes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRoutes_CellContentClick);
            // 
            // tabTickets
            // 
            this.tabTickets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.tabTickets.Controls.Add(this.dgvAllBookings);
            this.tabTickets.Location = new System.Drawing.Point(4, 37);
            this.tabTickets.Name = "tabTickets";
            this.tabTickets.Size = new System.Drawing.Size(857, 449);
            this.tabTickets.TabIndex = 1;
            this.tabTickets.Text = "📋 All Bookings";
            // 
            // dgvAllBookings
            // 
            this.dgvAllBookings.AllowUserToAddRows = false;
            this.dgvAllBookings.AllowUserToDeleteRows = false;
            this.dgvAllBookings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAllBookings.BackgroundColor = System.Drawing.Color.White;
            this.dgvAllBookings.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(80)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAllBookings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAllBookings.ColumnHeadersHeight = 34;
            this.dgvAllBookings.EnableHeadersVisualStyles = false;
            this.dgvAllBookings.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvAllBookings.Location = new System.Drawing.Point(10, 10);
            this.dgvAllBookings.Name = "dgvAllBookings";
            this.dgvAllBookings.ReadOnly = true;
            this.dgvAllBookings.RowHeadersVisible = false;
            this.dgvAllBookings.RowHeadersWidth = 62;
            this.dgvAllBookings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllBookings.Size = new System.Drawing.Size(840, 435);
            this.dgvAllBookings.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Gray;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(730, 585);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(150, 42);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "⬅ Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // AdminPanelForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(900, 640);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AdminPanelForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Panel";
            this.Load += new System.EventHandler(this.AdminPanelForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabRoutes.ResumeLayout(false);
            this.tabRoutes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoutes)).EndInit();
            this.tabTickets.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllBookings)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabRoutes;
        private System.Windows.Forms.TabPage tabTickets;
        private System.Windows.Forms.DataGridView dgvRoutes;
        private System.Windows.Forms.DataGridView dgvAllBookings;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.TextBox txtDistance;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.ComboBox cmbRouteCategory;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Label lblDestination;
        private System.Windows.Forms.Label lblDistance;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label lblRouteCategory;
        private System.Windows.Forms.Button btnAddRoute;
        private System.Windows.Forms.Button btnDeleteRoute;
        private System.Windows.Forms.Button btnBack;
    }
}