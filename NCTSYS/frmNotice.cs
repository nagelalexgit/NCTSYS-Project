using System;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Windows.Forms;

namespace NCTSYS
{
    public partial class frmNotice : Form
    {
        int rowindex = 0;

        private Form parent;

        public frmNotice()
        {
            InitializeComponent();
        }
        public frmNotice(Form parent)
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

        private void frmNotice_Load(object sender, EventArgs e)
        {
            dtpCurrDate.Enabled = false;    
        }

        private void btnCheckDueNct_Click(object sender, EventArgs e)
        {
            if(isNoticeProcessed(dtpCurrDate.Text))
            {
                MessageBox.Show("This Function already Processed for Today. \nPlease do remember This function must be used daily!", "Confirmation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                getDueForNct();
            }
        }

        private bool isNoticeProcessed(string date)
        {
            bool result = false;
            //Connect to the DB
            OracleConnection myConn = new OracleConnection(DBConnect.oradb);
            myConn.Open();

            //Define SQL Query
            String strSQL = "SELECT * FROM NOTICES WHERE NOTICES_DATE = '" + date + "'";
            //Execute SQL Query 
            OracleCommand cmd = new OracleCommand(strSQL, myConn);

            OracleDataReader dr = cmd.ExecuteReader();

        
            if (dr.Read())
            {
                result = true;
            }

            myConn.Close();

            return result;

        }

        public void getDueForNct()
        {
            //Connect to the DB
            OracleConnection myConn = new OracleConnection(DBConnect.oradb);
            myConn.Open();

            //Define SQL Query
            String strSQL = "SELECT Reg_No,CAR_MAKE as MAKE,CAR_MODEL as MODEL ,First_Reg_Date AS REGDATE, SURNAME, FORENAME, EMAIL FROM CARS C, OWNERS O " +
                            "WHERE C.CURRENTOWNER = O.PPSN AND CAR_STATUS = 'A' AND NEXT_NCT = TRUNC(ADD_MONTHS(SYSDATE, 1))";

            //Execute SQL Query 
            OracleCommand cmd = new OracleCommand(strSQL, myConn);

            OracleDataAdapter oda = new OracleDataAdapter(cmd);

            DataSet ds = new DataSet();

            oda.Fill(ds);

            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("No active Vihicles due for NCT Today. \nPlease do remember This function must be used daily!", "Confirmation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                grdNotice.DataSource = ds.Tables[0];
                grdNotice.AllowUserToAddRows = false;
                this.grdNotice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
                // close DB
                myConn.Close();
                // make data grid visible
                grdNotice.Visible = true;
                //make notiece button visible
                btnNotice.Visible = true;
        }

        private void btnNotice_Click(object sender, EventArgs e)
        {
            issueNotice();
        }

        private void issueNotice()
        {
            foreach (DataGridViewRow row in grdNotice.Rows)
            {
                string email = grdNotice.Rows[rowindex].Cells[6].Value.ToString().Trim();
                string fname = grdNotice.Rows[rowindex].Cells[4].Value.ToString().Trim();
                string sname = grdNotice.Rows[rowindex].Cells[5].Value.ToString().Trim();
                string make = grdNotice.Rows[rowindex].Cells[1].Value.ToString().Trim();
                string model = grdNotice.Rows[rowindex].Cells[2].Value.ToString().Trim();
                string regNo = grdNotice.Rows[rowindex].Cells[0].Value.ToString().Trim();
                string date = DateTime.Today.AddMonths(1).ToShortDateString();

                Util.sentEmail(fname,sname,make,model,email,regNo,date);

                rowindex++;
            }

            makeDailyNoticeProcessed(dtpCurrDate.Text);

            MessageBox.Show("All Notices have been issued. \nPlease do remember This function must be used daily!", "Confirmation",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
            parent.Show();
            return;
        }
        private void makeDailyNoticeProcessed(string date)
        {
            //Connect to the DB
            OracleConnection myConn = new OracleConnection(DBConnect.oradb);
            myConn.Open();

            //Define SQL Query
            String strSQL = "INSERT INTO NOTICES VALUES('" + date + "')";
            //Execute SQL Query 
            OracleCommand cmd = new OracleCommand(strSQL, myConn);
            cmd.ExecuteNonQuery();

            //Close DB
            myConn.Close();
        }
    }
}
