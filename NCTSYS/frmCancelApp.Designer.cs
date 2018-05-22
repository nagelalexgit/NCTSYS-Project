namespace NCTSYS
{
    partial class frmCancelApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCancelApp));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.backToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grbUniqCheck = new System.Windows.Forms.GroupBox();
            this.btnCheckAppID = new System.Windows.Forms.Button();
            this.lblAppID = new System.Windows.Forms.Label();
            this.txtAppID = new System.Windows.Forms.TextBox();
            this.grbAppDetails = new System.Windows.Forms.GroupBox();
            this.txtRegNo = new System.Windows.Forms.TextBox();
            this.lblRegNo = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.txtCentreName = new System.Windows.Forms.TextBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.txtCounty = new System.Windows.Forms.TextBox();
            this.lblAppTime = new System.Windows.Forms.Label();
            this.dtpAppDate = new System.Windows.Forms.DateTimePicker();
            this.lblAppDate = new System.Windows.Forms.Label();
            this.lblCentre = new System.Windows.Forms.Label();
            this.lblCounty = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.grbUniqCheck.SuspendLayout();
            this.grbAppDetails.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(669, 24);
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
            // grbUniqCheck
            // 
            this.grbUniqCheck.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("grbUniqCheck.BackgroundImage")));
            this.grbUniqCheck.Controls.Add(this.btnCheckAppID);
            this.grbUniqCheck.Controls.Add(this.lblAppID);
            this.grbUniqCheck.Controls.Add(this.txtAppID);
            this.grbUniqCheck.Font = new System.Drawing.Font("Perpetua Titling MT", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbUniqCheck.Location = new System.Drawing.Point(29, 42);
            this.grbUniqCheck.Name = "grbUniqCheck";
            this.grbUniqCheck.Size = new System.Drawing.Size(614, 58);
            this.grbUniqCheck.TabIndex = 61;
            this.grbUniqCheck.TabStop = false;
            this.grbUniqCheck.Text = "Unique Appointment ID Check";
            // 
            // btnCheckAppID
            // 
            this.btnCheckAppID.BackColor = System.Drawing.SystemColors.Control;
            this.btnCheckAppID.Font = new System.Drawing.Font("Perpetua Titling MT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckAppID.Location = new System.Drawing.Point(529, 22);
            this.btnCheckAppID.Name = "btnCheckAppID";
            this.btnCheckAppID.Size = new System.Drawing.Size(75, 23);
            this.btnCheckAppID.TabIndex = 59;
            this.btnCheckAppID.Text = "Check";
            this.btnCheckAppID.UseVisualStyleBackColor = true;
            this.btnCheckAppID.Click += new System.EventHandler(this.btnCheckAppID_Click);
            // 
            // lblAppID
            // 
            this.lblAppID.AutoSize = true;
            this.lblAppID.Font = new System.Drawing.Font("Perpetua Titling MT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppID.Location = new System.Drawing.Point(131, 29);
            this.lblAppID.Name = "lblAppID";
            this.lblAppID.Size = new System.Drawing.Size(192, 13);
            this.lblAppID.TabIndex = 57;
            this.lblAppID.Text = "Enter Unique Appointment ID";
            // 
            // txtAppID
            // 
            this.txtAppID.Font = new System.Drawing.Font("Perpetua Titling MT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAppID.Location = new System.Drawing.Point(333, 25);
            this.txtAppID.MaxLength = 14;
            this.txtAppID.Name = "txtAppID";
            this.txtAppID.Size = new System.Drawing.Size(147, 21);
            this.txtAppID.TabIndex = 58;
            this.txtAppID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // grbAppDetails
            // 
            this.grbAppDetails.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("grbAppDetails.BackgroundImage")));
            this.grbAppDetails.Controls.Add(this.txtRegNo);
            this.grbAppDetails.Controls.Add(this.lblRegNo);
            this.grbAppDetails.Controls.Add(this.btnNext);
            this.grbAppDetails.Controls.Add(this.txtCentreName);
            this.grbAppDetails.Controls.Add(this.txtTime);
            this.grbAppDetails.Controls.Add(this.txtCounty);
            this.grbAppDetails.Controls.Add(this.lblAppTime);
            this.grbAppDetails.Controls.Add(this.dtpAppDate);
            this.grbAppDetails.Controls.Add(this.lblAppDate);
            this.grbAppDetails.Controls.Add(this.lblCentre);
            this.grbAppDetails.Controls.Add(this.lblCounty);
            this.grbAppDetails.Font = new System.Drawing.Font("Perpetua Titling MT", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbAppDetails.Location = new System.Drawing.Point(29, 122);
            this.grbAppDetails.Name = "grbAppDetails";
            this.grbAppDetails.Size = new System.Drawing.Size(614, 156);
            this.grbAppDetails.TabIndex = 66;
            this.grbAppDetails.TabStop = false;
            this.grbAppDetails.Text = "Appointment detail";
            this.grbAppDetails.Visible = false;
            // 
            // txtRegNo
            // 
            this.txtRegNo.Font = new System.Drawing.Font("Perpetua Titling MT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegNo.Location = new System.Drawing.Point(321, 122);
            this.txtRegNo.Name = "txtRegNo";
            this.txtRegNo.ReadOnly = true;
            this.txtRegNo.Size = new System.Drawing.Size(119, 21);
            this.txtRegNo.TabIndex = 73;
            // 
            // lblRegNo
            // 
            this.lblRegNo.AutoSize = true;
            this.lblRegNo.Font = new System.Drawing.Font("Perpetua Titling MT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegNo.Location = new System.Drawing.Point(168, 126);
            this.lblRegNo.Name = "lblRegNo";
            this.lblRegNo.Size = new System.Drawing.Size(140, 13);
            this.lblRegNo.TabIndex = 72;
            this.lblRegNo.Text = "Registration Number:";
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.SystemColors.Control;
            this.btnNext.Font = new System.Drawing.Font("Perpetua Titling MT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(513, 122);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(90, 23);
            this.btnNext.TabIndex = 71;
            this.btnNext.Text = "next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtCentreName
            // 
            this.txtCentreName.Font = new System.Drawing.Font("Perpetua Titling MT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCentreName.Location = new System.Drawing.Point(347, 40);
            this.txtCentreName.Name = "txtCentreName";
            this.txtCentreName.ReadOnly = true;
            this.txtCentreName.Size = new System.Drawing.Size(247, 21);
            this.txtCentreName.TabIndex = 70;
            // 
            // txtTime
            // 
            this.txtTime.Font = new System.Drawing.Font("Perpetua Titling MT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTime.Location = new System.Drawing.Point(347, 75);
            this.txtTime.Name = "txtTime";
            this.txtTime.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(57, 21);
            this.txtTime.TabIndex = 69;
            // 
            // txtCounty
            // 
            this.txtCounty.Font = new System.Drawing.Font("Perpetua Titling MT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCounty.Location = new System.Drawing.Point(112, 40);
            this.txtCounty.Name = "txtCounty";
            this.txtCounty.ReadOnly = true;
            this.txtCounty.Size = new System.Drawing.Size(138, 21);
            this.txtCounty.TabIndex = 68;
            // 
            // lblAppTime
            // 
            this.lblAppTime.AutoSize = true;
            this.lblAppTime.Font = new System.Drawing.Font("Perpetua Titling MT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppTime.Location = new System.Drawing.Point(281, 78);
            this.lblAppTime.Name = "lblAppTime";
            this.lblAppTime.Size = new System.Drawing.Size(34, 13);
            this.lblAppTime.TabIndex = 66;
            this.lblAppTime.Text = "time:";
            // 
            // dtpAppDate
            // 
            this.dtpAppDate.Enabled = false;
            this.dtpAppDate.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtpAppDate.Location = new System.Drawing.Point(112, 78);
            this.dtpAppDate.Name = "dtpAppDate";
            this.dtpAppDate.Size = new System.Drawing.Size(138, 21);
            this.dtpAppDate.TabIndex = 65;
            // 
            // lblAppDate
            // 
            this.lblAppDate.AutoSize = true;
            this.lblAppDate.Font = new System.Drawing.Font("Perpetua Titling MT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppDate.Location = new System.Drawing.Point(40, 84);
            this.lblAppDate.Name = "lblAppDate";
            this.lblAppDate.Size = new System.Drawing.Size(39, 13);
            this.lblAppDate.TabIndex = 64;
            this.lblAppDate.Text = "date:";
            // 
            // lblCentre
            // 
            this.lblCentre.AutoSize = true;
            this.lblCentre.Font = new System.Drawing.Font("Perpetua Titling MT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCentre.Location = new System.Drawing.Point(281, 44);
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
            this.lblCounty.Location = new System.Drawing.Point(40, 44);
            this.lblCounty.Name = "lblCounty";
            this.lblCounty.Size = new System.Drawing.Size(60, 13);
            this.lblCounty.TabIndex = 61;
            this.lblCounty.Text = "County:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Perpetua Titling MT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(182, 337);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(303, 13);
            this.label3.TabIndex = 67;
            this.label3.Text = "Copyright © 2017 by NCT Systems Solutions LTD.";
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Perpetua Titling MT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClear.Location = new System.Drawing.Point(29, 300);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(96, 30);
            this.btnClear.TabIndex = 70;
            this.btnClear.Text = "Clear form";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Visible = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Perpetua Titling MT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Green;
            this.btnCancel.Location = new System.Drawing.Point(547, 300);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 30);
            this.btnCancel.TabIndex = 71;
            this.btnCancel.Text = "cancel ";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmCancelApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(669, 352);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.grbAppDetails);
            this.Controls.Add(this.grbUniqCheck);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCancelApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NCTSYS - Cancel Appointment";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.grbUniqCheck.ResumeLayout(false);
            this.grbUniqCheck.PerformLayout();
            this.grbAppDetails.ResumeLayout(false);
            this.grbAppDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.GroupBox grbUniqCheck;
        private System.Windows.Forms.Button btnCheckAppID;
        private System.Windows.Forms.Label lblAppID;
        private System.Windows.Forms.TextBox txtAppID;
        private System.Windows.Forms.GroupBox grbAppDetails;
        private System.Windows.Forms.Label lblCentre;
        private System.Windows.Forms.Label lblCounty;
        private System.Windows.Forms.DateTimePicker dtpAppDate;
        private System.Windows.Forms.Label lblAppDate;
        private System.Windows.Forms.Label lblAppTime;
        private System.Windows.Forms.TextBox txtCentreName;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.TextBox txtCounty;
        private System.Windows.Forms.TextBox txtRegNo;
        private System.Windows.Forms.Label lblRegNo;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCancel;
    }
}