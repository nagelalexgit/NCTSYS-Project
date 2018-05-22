﻿using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace NCTSYS
{
    public partial class frmHistory : Form
    {
        private Form parent;
        public frmHistory()
        {
            InitializeComponent();
        }
        public frmHistory(Form parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void frmHistory_Load(object sender, EventArgs e)
        {
            txtRegNo.CharacterCasing = CharacterCasing.Upper;
            grdHistory.AllowUserToAddRows = false;
            this.grdHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }
        private void btnCheckReg_Click(object sender, EventArgs e)
        {
            if (txtRegNo.Text == "")
            {
                MessageBox.Show("Please Enter Registration Number", "Confirmation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRegNo.Focus();
                return;
            }
            if (Util.isValidReg(txtRegNo.Text.ToUpper().Trim()) == false)
            {
                MessageBox.Show("Registration Number you entered is invalid !\nPlease Re-enter", "Confirmation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRegNo.Focus();
                return;
            }

            getRegHistory(txtRegNo.Text.ToUpper().Trim());

        }
        public void getRegHistory(String regNo)
        {

            //Connect to the DB
            OracleConnection myConn = new OracleConnection(DBConnect.oradb);
            myConn.Open();

            //Define SQL Query
            String strSQL = "SELECT C.REG_NO, CAR_MAKE, CAR_MODEL, SURNAME, FORENAME, TEL_NO, REG_DATE " +
                            "FROM CARS C, OWNERS O, REGISTRATIONS R "+ 
                            "WHERE C.REG_NO = R.REG_NO AND " +
                            "R.PPSN = O.PPSN  AND " + 
                            "C.REG_NO = '" + txtRegNo.Text.Trim() + "' " +
                            "ORDER BY REG_DATE DESC";

            //Execute SQL Query 
            OracleCommand cmd = new OracleCommand(strSQL, myConn);

            OracleDataAdapter oda = new OracleDataAdapter(cmd);

            DataSet ds = new DataSet();

            oda.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Registration Number you entered in not in Database ", "Confirmation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearForm();
                return;
            }

            grdHistory.DataSource = ds.Tables[0];

            // close DB
            myConn.Close();
            // make data grid visible
            grdHistory.Visible = true;
            //make txtRegNo.ReadOnly
            txtRegNo.ReadOnly = true;
            //make clear form button visible
            btnClear.Visible = true;
            //hide check button
            btnCheckReg.Visible = false;
            //make print button visible
            btnPrint.Visible = true;
        }
        public void clearForm()
        {
            grdHistory.Visible = false;
            btnClear.Visible = false;
            btnCheckReg.Visible = true;
            btnPrint.Visible = false;
            txtRegNo.Text = String.Empty;
            txtRegNo.ReadOnly = false;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearForm();
        }
        //printing
        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog1 = new PrintDialog();
            printDialog1.Document = printDocument1;
            DialogResult result = printDialog1.ShowDialog();
            if (printDocument1.PrinterSettings.IsValid)
            {
                printDocument1.Print();
            }
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(this.grdHistory.Width, this.grdHistory.Height);
            this.grdHistory.DrawToBitmap(bmp, this.grdHistory.ClientRectangle);
            e.Graphics.DrawImage(bmp, 0, 0);
        }
    }
}
