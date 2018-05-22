namespace NCTSYS
{
    partial class frmDailyApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDailyApp));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.backToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grbCentre = new System.Windows.Forms.GroupBox();
            this.txtCentreID = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpCurrentDate = new System.Windows.Forms.DateTimePicker();
            this.cboCentreName = new System.Windows.Forms.ComboBox();
            this.lblCentre = new System.Windows.Forms.Label();
            this.lblCounty = new System.Windows.Forms.Label();
            this.cboCounty = new System.Windows.Forms.ComboBox();
            this.grdAppointments = new System.Windows.Forms.DataGridView();
            this.btnPrint = new System.Windows.Forms.Button();
            this.grbAppFilter = new System.Windows.Forms.GroupBox();
            this.btnNotAttended = new System.Windows.Forms.Button();
            this.btnBooked = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnProcessed = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.grbCentre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAppointments)).BeginInit();
            this.grbAppFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("menuStrip1.BackgroundImage")));
            this.menuStrip1.Font = new System.Drawing.Font("Perpetua Titling MT", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(736, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // backToolStripMenuItem
            // 
            this.backToolStripMenuItem.Name = "backToolStripMenuItem";
            this.backToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.backToolStripMenuItem.Text = "back";
            this.backToolStripMenuItem.Click += new System.EventHandler(this.backToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.ForeColor = System.Drawing.Color.Maroon;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // grbCentre
            // 
            this.grbCentre.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("grbCentre.BackgroundImage")));
            this.grbCentre.Controls.Add(this.txtCentreID);
            this.grbCentre.Controls.Add(this.lblDate);
            this.grbCentre.Controls.Add(this.dtpCurrentDate);
            this.grbCentre.Controls.Add(this.cboCentreName);
            this.grbCentre.Controls.Add(this.lblCentre);
            this.grbCentre.Controls.Add(this.lblCounty);
            this.grbCentre.Controls.Add(this.cboCounty);
            this.grbCentre.Font = new System.Drawing.Font("Perpetua Titling MT", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbCentre.Location = new System.Drawing.Point(22, 39);
            this.grbCentre.Name = "grbCentre";
            this.grbCentre.Size = new System.Drawing.Size(691, 87);
            this.grbCentre.TabIndex = 66;
            this.grbCentre.TabStop = false;
            this.grbCentre.Text = "Test Centre details";
            // 
            // txtCentreID
            // 
            this.txtCentreID.Font = new System.Drawing.Font("Perpetua Titling MT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCentreID.Location = new System.Drawing.Point(658, 52);
            this.txtCentreID.Name = "txtCentreID";
            this.txtCentreID.ReadOnly = true;
            this.txtCentreID.Size = new System.Drawing.Size(27, 21);
            this.txtCentreID.TabIndex = 67;
            this.txtCentreID.Visible = false;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Perpetua Titling MT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(206, 22);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(96, 13);
            this.lblDate.TabIndex = 66;
            this.lblDate.Text = "Current date:";
            // 
            // dtpCurrentDate
            // 
            this.dtpCurrentDate.Enabled = false;
            this.dtpCurrentDate.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtpCurrentDate.Location = new System.Drawing.Point(311, 18);
            this.dtpCurrentDate.Name = "dtpCurrentDate";
            this.dtpCurrentDate.Size = new System.Drawing.Size(138, 21);
            this.dtpCurrentDate.TabIndex = 65;
            // 
            // cboCentreName
            // 
            this.cboCentreName.Font = new System.Drawing.Font("Perpetua Titling MT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCentreName.FormattingEnabled = true;
            this.cboCentreName.Location = new System.Drawing.Point(345, 54);
            this.cboCentreName.Name = "cboCentreName";
            this.cboCentreName.Size = new System.Drawing.Size(295, 21);
            this.cboCentreName.TabIndex = 63;
            this.cboCentreName.Visible = false;
            this.cboCentreName.SelectedIndexChanged += new System.EventHandler(this.cboCentreName_SelectedIndexChanged);
            // 
            // lblCentre
            // 
            this.lblCentre.AutoSize = true;
            this.lblCentre.Font = new System.Drawing.Font("Perpetua Titling MT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCentre.Location = new System.Drawing.Point(283, 58);
            this.lblCentre.Name = "lblCentre";
            this.lblCentre.Size = new System.Drawing.Size(52, 13);
            this.lblCentre.TabIndex = 62;
            this.lblCentre.Text = "Centre:";
            this.lblCentre.Visible = false;
            // 
            // lblCounty
            // 
            this.lblCounty.AutoSize = true;
            this.lblCounty.Font = new System.Drawing.Font("Perpetua Titling MT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCounty.Location = new System.Drawing.Point(58, 58);
            this.lblCounty.Name = "lblCounty";
            this.lblCounty.Size = new System.Drawing.Size(60, 13);
            this.lblCounty.TabIndex = 61;
            this.lblCounty.Text = "County:";
            // 
            // cboCounty
            // 
            this.cboCounty.Font = new System.Drawing.Font("Perpetua Titling MT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCounty.FormattingEnabled = true;
            this.cboCounty.Location = new System.Drawing.Point(136, 54);
            this.cboCounty.Name = "cboCounty";
            this.cboCounty.Size = new System.Drawing.Size(127, 21);
            this.cboCounty.TabIndex = 60;
            this.cboCounty.SelectedIndexChanged += new System.EventHandler(this.cboCounty_SelectedIndexChanged);
            // 
            // grdAppointments
            // 
            this.grdAppointments.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.grdAppointments.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAppointments.Location = new System.Drawing.Point(22, 236);
            this.grdAppointments.Name = "grdAppointments";
            this.grdAppointments.ReadOnly = true;
            this.grdAppointments.Size = new System.Drawing.Size(691, 233);
            this.grdAppointments.TabIndex = 67;
            this.grdAppointments.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Perpetua Titling MT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.Green;
            this.btnPrint.Location = new System.Drawing.Point(612, 484);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(101, 31);
            this.btnPrint.TabIndex = 69;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Visible = false;
            // 
            // grbAppFilter
            // 
            this.grbAppFilter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("grbAppFilter.BackgroundImage")));
            this.grbAppFilter.Controls.Add(this.btnNotAttended);
            this.grbAppFilter.Controls.Add(this.btnBooked);
            this.grbAppFilter.Controls.Add(this.btnAll);
            this.grbAppFilter.Controls.Add(this.btnProcessed);
            this.grbAppFilter.Font = new System.Drawing.Font("Perpetua Titling MT", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbAppFilter.Location = new System.Drawing.Point(22, 145);
            this.grbAppFilter.Name = "grbAppFilter";
            this.grbAppFilter.Size = new System.Drawing.Size(691, 72);
            this.grbAppFilter.TabIndex = 73;
            this.grbAppFilter.TabStop = false;
            this.grbAppFilter.Text = "Appointments Filter";
            this.grbAppFilter.Visible = false;
            // 
            // btnNotAttended
            // 
            this.btnNotAttended.Font = new System.Drawing.Font("Perpetua Titling MT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNotAttended.ForeColor = System.Drawing.Color.Maroon;
            this.btnNotAttended.Location = new System.Drawing.Point(533, 29);
            this.btnNotAttended.Name = "btnNotAttended";
            this.btnNotAttended.Size = new System.Drawing.Size(109, 24);
            this.btnNotAttended.TabIndex = 75;
            this.btnNotAttended.Text = "Not Attended";
            this.btnNotAttended.UseVisualStyleBackColor = true;
            this.btnNotAttended.Click += new System.EventHandler(this.btnNotAttended_Click);
            // 
            // btnBooked
            // 
            this.btnBooked.Font = new System.Drawing.Font("Perpetua Titling MT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBooked.ForeColor = System.Drawing.Color.Green;
            this.btnBooked.Location = new System.Drawing.Point(219, 29);
            this.btnBooked.Name = "btnBooked";
            this.btnBooked.Size = new System.Drawing.Size(101, 24);
            this.btnBooked.TabIndex = 74;
            this.btnBooked.Text = "booked";
            this.btnBooked.UseVisualStyleBackColor = true;
            this.btnBooked.Click += new System.EventHandler(this.btnBooked_Click);
            // 
            // btnAll
            // 
            this.btnAll.Font = new System.Drawing.Font("Perpetua Titling MT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAll.ForeColor = System.Drawing.Color.Green;
            this.btnAll.Location = new System.Drawing.Point(54, 29);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(101, 24);
            this.btnAll.TabIndex = 73;
            this.btnAll.Text = "All";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnProcessed
            // 
            this.btnProcessed.Font = new System.Drawing.Font("Perpetua Titling MT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcessed.ForeColor = System.Drawing.Color.Green;
            this.btnProcessed.Location = new System.Drawing.Point(378, 29);
            this.btnProcessed.Name = "btnProcessed";
            this.btnProcessed.Size = new System.Drawing.Size(101, 24);
            this.btnProcessed.TabIndex = 71;
            this.btnProcessed.Text = "processed";
            this.btnProcessed.UseVisualStyleBackColor = true;
            this.btnProcessed.Click += new System.EventHandler(this.btnProcessed_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Perpetua Titling MT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(230, 510);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 13);
            this.label1.TabIndex = 74;
            this.label1.Text = "Copyright © 2017 by NCT Systems Solutions LTD.";
            // 
            // frmDailyApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(736, 527);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grbAppFilter);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.grdAppointments);
            this.Controls.Add(this.grbCentre);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDailyApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NCTSYS - List Daily Appointments";
            this.Load += new System.EventHandler(this.frmDailyApp_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.grbCentre.ResumeLayout(false);
            this.grbCentre.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAppointments)).EndInit();
            this.grbAppFilter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.GroupBox grbCentre;
        private System.Windows.Forms.ComboBox cboCentreName;
        private System.Windows.Forms.Label lblCentre;
        private System.Windows.Forms.Label lblCounty;
        private System.Windows.Forms.ComboBox cboCounty;
        private System.Windows.Forms.DataGridView grdAppointments;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.GroupBox grbAppFilter;
        private System.Windows.Forms.Button btnBooked;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnProcessed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpCurrentDate;
        private System.Windows.Forms.TextBox txtCentreID;
        private System.Windows.Forms.Button btnNotAttended;
    }
}