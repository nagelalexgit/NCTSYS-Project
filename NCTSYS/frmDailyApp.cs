using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace NCTSYS
{
    public partial class frmDailyApp : Form
    {
        private Form parent;

        public frmDailyApp(Form parent)
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
        private void frmDailyApp_Load(object sender, EventArgs e)
        {
            grdAppointments.AllowUserToAddRows = false;
            this.grdAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            cboCounty.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCentreName.DropDownStyle = ComboBoxStyle.DropDownList;
            dtpCurrentDate.Value = DateTime.Today;
            loadCounties();
        }
        public void loadCounties()
        {
            //open database
            OracleConnection myConn = new OracleConnection(DBConnect.oradb);
            myConn.Open();

            String strSQL = "SELECT * FROM COUNTIES";
            OracleCommand cmd = new OracleCommand(strSQL, myConn);

            OracleDataReader dr = cmd.ExecuteReader();

            //load data from datareader into combo box
            cboCounty.Items.Clear();
            while (dr.Read())
            {
                cboCounty.Items.Add(dr.GetValue(0).ToString().Trim().ToUpper());
            }
            //Close DB
            myConn.Close();

        }

        private void cboCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadCentres(cboCounty.Text.ToUpper().Trim());
            grbAppFilter.Visible = false;
            btnPrint.Visible = false;
            grdAppointments.Visible = false;
        }
        public void loadCentres(String county)
        {
            //open database
            OracleConnection myConn = new OracleConnection(DBConnect.oradb);
            myConn.Open();

            String strSQL = "SELECT * FROM Centres WHERE COUNTY = '" + county + "'AND STATUS = 'A'";

            OracleCommand cmd = new OracleCommand(strSQL, myConn);

            OracleDataReader dr = cmd.ExecuteReader();

            cboCentreName.Items.Clear();

            while (dr.Read())
            {
                cboCentreName.Items.Add(dr.GetString(1).Trim());
            }

            cboCentreName.Visible = true;
            lblCentre.Visible = true;

            //Close DB
            myConn.Close();
        }

        private void cboCentreName_SelectedIndexChanged(object sender, EventArgs e)
        {
            grbAppFilter.Visible = true;
            loadCentreID(cboCentreName.SelectedItem.ToString());
            grdAppointments.Visible = false;
        }
        private void loadCentreID(string name)
        {
            //open database
            OracleConnection myConn = new OracleConnection(DBConnect.oradb);
            myConn.Open();

            String strSQL = "SELECT * FROM Centres WHERE C_NAME = '" + name + "'";
            OracleCommand cmd = new OracleCommand(strSQL, myConn);

            OracleDataReader dr = cmd.ExecuteReader();


            //load data from datareader into text box
            txtCentreID.Text = String.Empty;

            if (dr.Read())
            {
                txtCentreID.Text = dr.GetInt32(0).ToString();
            }

            //Close DB
            myConn.Close();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            getAllAppointments(Convert.ToInt16(txtCentreID.Text), dtpCurrentDate.Text);
        }

        private void getAllAppointments(int centreID, string date)
        {
            //Connect to the DB
            OracleConnection myConn = new OracleConnection(DBConnect.oradb);
            myConn.Open();

            //Define SQL Query
            String strSQL = "SELECT * FROM APPOINTMENTS WHERE CENTRE_ID = " + centreID + " AND APP_DATE = '" + date + "' ORDER BY APP_TIME *1";

            //Execute SQL Query 
            OracleCommand cmd = new OracleCommand(strSQL, myConn);

            OracleDataAdapter oda = new OracleDataAdapter(cmd);

            DataSet ds = new DataSet();

            oda.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                grdAppointments.DataSource = null;
                MessageBox.Show("No Appointments have been made for TODAY! ", "Confirmation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            grdAppointments.DataSource = ds.Tables[0];

            // close DB
            myConn.Close();
            // make data grid visible
            grdAppointments.Visible = true;
            //make print button visible
            btnPrint.Visible = true;
        }

        private void btnBooked_Click(object sender, EventArgs e)
        {
            getBookedAppointments(Convert.ToInt16(txtCentreID.Text), dtpCurrentDate.Text);
        }

        private void getBookedAppointments(int centreID, string date)
        {
            //Connect to the DB
            OracleConnection myConn = new OracleConnection(DBConnect.oradb);
            myConn.Open();

            //Define SQL Query
            String strSQL = "SELECT * FROM APPOINTMENTS WHERE CENTRE_ID = " + centreID + " AND APP_DATE = '" + date + "' AND APP_STATUS  = 'B' ORDER BY APP_TIME *1";

            //Execute SQL Query 
            OracleCommand cmd = new OracleCommand(strSQL, myConn);

            OracleDataAdapter oda = new OracleDataAdapter(cmd);

            DataSet ds = new DataSet();

            oda.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                grdAppointments.DataSource = null;
                MessageBox.Show("All Appointments have been processed or no booking have been made for TODAY! ", "Confirmation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            grdAppointments.DataSource = ds.Tables[0];

            // close DB
            myConn.Close();
            // make data grid visible
            grdAppointments.Visible = true;
            //make print button visible
            btnPrint.Visible = true;
            btnBooked.Focus();
        }

        private void btnProcessed_Click(object sender, EventArgs e)
        {
            getProcessedAppointments(Convert.ToInt16(txtCentreID.Text), dtpCurrentDate.Text);
        }
        private void getProcessedAppointments(int centreID, string date)
        {
            //Connect to the DB
            OracleConnection myConn = new OracleConnection(DBConnect.oradb);
            myConn.Open();

            //Define SQL Query
            String strSQL = "SELECT * FROM APPOINTMENTS WHERE CENTRE_ID = " + centreID + " AND APP_DATE = '" + date + "' AND APP_STATUS  = 'P' ORDER BY APP_TIME *1";

            //Execute SQL Query 
            OracleCommand cmd = new OracleCommand(strSQL, myConn);

            OracleDataAdapter oda = new OracleDataAdapter(cmd);

            DataSet ds = new DataSet();

            oda.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                grdAppointments.DataSource = null;
                MessageBox.Show("No Processed Appointments found yet for TODAY! ", "Confirmation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            grdAppointments.DataSource = ds.Tables[0];

            // close DB
            myConn.Close();
            // make data grid visible
            grdAppointments.Visible = true;
            //make print button visible
            btnPrint.Visible = true;
            btnProcessed.Focus();
        }
        

        private void btnNotAttended_Click(object sender, EventArgs e)
        {
            getNotAttendedAppointments(Convert.ToInt16(txtCentreID.Text), dtpCurrentDate.Text);
        }

        private void getNotAttendedAppointments(int centreID, string date)
        {
            //Connect to the DB
            OracleConnection myConn = new OracleConnection(DBConnect.oradb);
            myConn.Open();

            //Define SQL Query
            String strSQL = "SELECT * FROM APPOINTMENTS WHERE CENTRE_ID = " + centreID + " AND APP_DATE = '" + date + "' AND APP_STATUS  = 'N' ORDER BY APP_TIME *1";

            //Execute SQL Query 
            OracleCommand cmd = new OracleCommand(strSQL, myConn);

            OracleDataAdapter oda = new OracleDataAdapter(cmd);

            DataSet ds = new DataSet();

            oda.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                grdAppointments.DataSource = null;
                MessageBox.Show("Attendance is great for TODAY! ", "Confirmation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            grdAppointments.DataSource = ds.Tables[0];

            // close DB
            myConn.Close();
            // make data grid visible
            grdAppointments.Visible = true;
            //make print button visible
            btnPrint.Visible = true;
            btnNotAttended.Focus();
        }

        //private void btnPrint_Click(object sender, EventArgs e)
        //{
        //    printDocument1.Print();
        //}
        //private void printDocument1_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        //{
        //    PaintEventArgs myPaintArgs = new PaintEventArgs(e.Graphics, new Rectangle(new Point(0, 0), this.Size));
        //    this.InvokePaint(grdAppointments, myPaintArgs);
        //}

    }
}
