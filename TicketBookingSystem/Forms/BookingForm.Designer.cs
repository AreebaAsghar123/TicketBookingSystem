namespace TicketBookingSystem.Forms
{
    partial class BookingForm
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
            this.lblTicketInfo = new System.Windows.Forms.Label();
            this.pnlTicketInfo = new System.Windows.Forms.Panel();
            this.lblRoute = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblFare = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.lblPassengerName = new System.Windows.Forms.Label();
            this.txtPassengerName = new System.Windows.Forms.TextBox();
            this.lblSeat = new System.Windows.Forms.Label();
            this.txtSeat = new System.Windows.Forms.TextBox();
            this.lblPayment = new System.Windows.Forms.Label();
            this.cmbPayment = new System.Windows.Forms.ComboBox();
            this.lblPromo = new System.Windows.Forms.Label();
            this.txtPromo = new System.Windows.Forms.TextBox();
            this.btnApplyPromo = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblSeats = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlTicketInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(500, 70);
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
            this.lblTitle.Text = "🎫 Book Ticket";
            // 
            // lblTicketInfo
            // 
            this.lblTicketInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTicketInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblTicketInfo.Location = new System.Drawing.Point(20, 75);
            this.lblTicketInfo.Name = "lblTicketInfo";
            this.lblTicketInfo.Size = new System.Drawing.Size(200, 22);
            this.lblTicketInfo.TabIndex = 1;
            this.lblTicketInfo.Text = "Ticket Details:";
            // 
            // pnlTicketInfo
            // 
            this.pnlTicketInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(228)))), ((int)(((byte)(240)))));
            this.pnlTicketInfo.Controls.Add(this.lblSeats);
            this.pnlTicketInfo.Controls.Add(this.lblRoute);
            this.pnlTicketInfo.Controls.Add(this.lblDate);
            this.pnlTicketInfo.Controls.Add(this.lblFare);
            this.pnlTicketInfo.Controls.Add(this.lblCompany);
            this.pnlTicketInfo.Location = new System.Drawing.Point(20, 85);
            this.pnlTicketInfo.Name = "pnlTicketInfo";
            this.pnlTicketInfo.Size = new System.Drawing.Size(450, 110);
            this.pnlTicketInfo.TabIndex = 2;
            // 
            // lblRoute
            // 
            this.lblRoute.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblRoute.Location = new System.Drawing.Point(10, 10);
            this.lblRoute.Name = "lblRoute";
            this.lblRoute.Size = new System.Drawing.Size(430, 22);
            this.lblRoute.TabIndex = 0;
            this.lblRoute.Text = "Route: ";
            // 
            // lblDate
            // 
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDate.Location = new System.Drawing.Point(10, 35);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(430, 20);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "Date: ";
            // 
            // lblFare
            // 
            this.lblFare.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblFare.Location = new System.Drawing.Point(10, 58);
            this.lblFare.Name = "lblFare";
            this.lblFare.Size = new System.Drawing.Size(200, 20);
            this.lblFare.TabIndex = 2;
            this.lblFare.Text = "Fare: ";
            this.lblFare.Click += new System.EventHandler(this.lblFare_Click);
            // 
            // lblCompany
            // 
            this.lblCompany.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblCompany.Location = new System.Drawing.Point(230, 58);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(200, 20);
            this.lblCompany.TabIndex = 3;
            this.lblCompany.Text = "Company: ";
            // 
            // lblPassengerName
            // 
            this.lblPassengerName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPassengerName.Location = new System.Drawing.Point(22, 198);
            this.lblPassengerName.Name = "lblPassengerName";
            this.lblPassengerName.Size = new System.Drawing.Size(200, 22);
            this.lblPassengerName.TabIndex = 3;
            this.lblPassengerName.Text = "Passenger Name:";
            // 
            // txtPassengerName
            // 
            this.txtPassengerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassengerName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassengerName.Location = new System.Drawing.Point(20, 228);
            this.txtPassengerName.Name = "txtPassengerName";
            this.txtPassengerName.Size = new System.Drawing.Size(450, 34);
            this.txtPassengerName.TabIndex = 4;
            // 
            // lblSeat
            // 
            this.lblSeat.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSeat.Location = new System.Drawing.Point(20, 265);
            this.lblSeat.Name = "lblSeat";
            this.lblSeat.Size = new System.Drawing.Size(200, 22);
            this.lblSeat.TabIndex = 5;
            this.lblSeat.Text = "Seat Number (e.g. A1):";
            // 
            // txtSeat
            // 
            this.txtSeat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSeat.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSeat.Location = new System.Drawing.Point(20, 290);
            this.txtSeat.Name = "txtSeat";
            this.txtSeat.Size = new System.Drawing.Size(150, 34);
            this.txtSeat.TabIndex = 6;
            // 
            // lblPayment
            // 
            this.lblPayment.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPayment.Location = new System.Drawing.Point(20, 330);
            this.lblPayment.Name = "lblPayment";
            this.lblPayment.Size = new System.Drawing.Size(200, 22);
            this.lblPayment.TabIndex = 7;
            this.lblPayment.Text = "Payment Method:";
            // 
            // cmbPayment
            // 
            this.cmbPayment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPayment.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbPayment.Items.AddRange(new object[] {
            "Cash",
            "Debit Card",
            "Credit Card",
            "Mobile Wallet"});
            this.cmbPayment.Location = new System.Drawing.Point(20, 355);
            this.cmbPayment.Name = "cmbPayment";
            this.cmbPayment.Size = new System.Drawing.Size(200, 36);
            this.cmbPayment.TabIndex = 8;
            // 
            // lblPromo
            // 
            this.lblPromo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPromo.Location = new System.Drawing.Point(20, 395);
            this.lblPromo.Name = "lblPromo";
            this.lblPromo.Size = new System.Drawing.Size(200, 22);
            this.lblPromo.TabIndex = 9;
            this.lblPromo.Text = "Promo Code (Optional):";
            // 
            // txtPromo
            // 
            this.txtPromo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPromo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPromo.Location = new System.Drawing.Point(20, 420);
            this.txtPromo.Name = "txtPromo";
            this.txtPromo.Size = new System.Drawing.Size(200, 34);
            this.txtPromo.TabIndex = 10;
            // 
            // btnApplyPromo
            // 
            this.btnApplyPromo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(117)))), ((int)(((byte)(182)))));
            this.btnApplyPromo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApplyPromo.FlatAppearance.BorderSize = 0;
            this.btnApplyPromo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyPromo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnApplyPromo.ForeColor = System.Drawing.Color.White;
            this.btnApplyPromo.Location = new System.Drawing.Point(235, 420);
            this.btnApplyPromo.Name = "btnApplyPromo";
            this.btnApplyPromo.Size = new System.Drawing.Size(100, 28);
            this.btnApplyPromo.TabIndex = 11;
            this.btnApplyPromo.Text = "Apply";
            this.btnApplyPromo.UseVisualStyleBackColor = false;
            this.btnApplyPromo.Click += new System.EventHandler(this.btnApplyPromo_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblTotal.Location = new System.Drawing.Point(20, 465);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(150, 25);
            this.lblTotal.TabIndex = 12;
            this.lblTotal.Text = "Total Amount:";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(160)))), ((int)(((byte)(44)))));
            this.lblTotalAmount.Location = new System.Drawing.Point(180, 462);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(200, 28);
            this.lblTotalAmount.TabIndex = 13;
            this.lblTotalAmount.Text = "Rs. 0";
            // 
            // lblError
            // 
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(20, 500);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(450, 20);
            this.lblError.TabIndex = 14;
            this.lblError.Visible = false;
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(160)))), ((int)(((byte)(44)))));
            this.btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(20, 530);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(210, 45);
            this.btnConfirm.TabIndex = 15;
            this.btnConfirm.Text = "✅ CONFIRM BOOKING";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(250, 530);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 45);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "❌ CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblSeats
            // 
            this.lblSeats.AutoSize = true;
            this.lblSeats.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeats.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblSeats.Location = new System.Drawing.Point(10, 78);
            this.lblSeats.Name = "lblSeats";
            this.lblSeats.Size = new System.Drawing.Size(130, 25);
            this.lblSeats.TabIndex = 17;
            this.lblSeats.Text = "Available Seats";
            // 
            // BookingForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(500, 595);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.lblTicketInfo);
            this.Controls.Add(this.pnlTicketInfo);
            this.Controls.Add(this.lblPassengerName);
            this.Controls.Add(this.txtPassengerName);
            this.Controls.Add(this.lblSeat);
            this.Controls.Add(this.txtSeat);
            this.Controls.Add(this.lblPayment);
            this.Controls.Add(this.cmbPayment);
            this.Controls.Add(this.lblPromo);
            this.Controls.Add(this.txtPromo);
            this.Controls.Add(this.btnApplyPromo);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "BookingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Book Ticket";
            this.Load += new System.EventHandler(this.BookingForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlTicketInfo.ResumeLayout(false);
            this.pnlTicketInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTicketInfo;
        private System.Windows.Forms.Panel pnlTicketInfo;
        private System.Windows.Forms.Label lblRoute;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblFare;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblPassengerName;
        private System.Windows.Forms.TextBox txtPassengerName;
        private System.Windows.Forms.Label lblSeat;
        private System.Windows.Forms.TextBox txtSeat;
        private System.Windows.Forms.Label lblPayment;
        private System.Windows.Forms.ComboBox cmbPayment;
        private System.Windows.Forms.Label lblPromo;
        private System.Windows.Forms.TextBox txtPromo;
        private System.Windows.Forms.Button btnApplyPromo;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblSeats;
    }
}