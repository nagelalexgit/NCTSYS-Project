using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace NCTSYS
{
    public partial class frmRecTestRes : Form
    {
        String text = "It is hereby certified that the vehicle described in this Certificate was tested on \nInaccordance with Road Traffic(National Car Test) Regulations and was found to comply \ntherewith";
        String uAppID;
        private Form parent;
        public frmRecTestRes()
        {
            InitializeComponent();
        }
        public frmRecTestRes(Form parent)
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

        private void frmRecTestRes_Load(object sender, EventArgs e)
        {
            lblText.Text = text;
            loadCounties();
            grdAppointments.AllowUserToAddRows = false;
            this.grdAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            cboCounty.DropDownStyle = ComboBoxStyle.DropDownList;
            cboUnits.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCentreName.DropDownStyle = ComboBoxStyle.DropDownList;
            //formating dates
            lblAppDate.Text = DateTime.Today.ToString("dd-MMM-yyyy").ToUpper();
            lblDiscTestDate.Text = DateTime.Today.ToString("dd-MMM-yyyy").ToUpper();
            //loading miles or kkilometers units
            loadUnits();

        }
        //load counties from DB
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
        //loading Centres in to combo box
        private void cboCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadCentres(cboCounty.Text.ToUpper().Trim());
            grdAppointments.Visible = false;
        }
        //load centres from DB
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

            //Close DB
            myConn.Close();

            cboCentreName.Visible = true;
            lblCentre.Visible = true;
        }
        private void cboCentreName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //loading centre ID
            loadCentreID(cboCentreName.SelectedItem.ToString());
            // loading Booked Appointments
            getBookedAppointments(Convert.ToInt32(txtCentreID.Text), dtpCurrentDate.Text);
        }
        //load centre ID from DB
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
                MessageBox.Show("All Appointments have been processed for NOW! ", "Confirmation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            grdAppointments.DataSource = ds.Tables[0];

            // close DB
            myConn.Close();
            // make data grid visible
            grdAppointments.Visible = true;
        }

        private void grdAppointments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.grdAppointments.Rows[e.RowIndex];
            //geting data from a Grid
            uAppID = row.Cells[6].Value.ToString().Trim();
            String time = row.Cells[1].Value.ToString().Trim();
            String regNo = row.Cells[4].Value.ToString().Trim();
            //instantiate Car object
            Car aCar = new Car();
            //loading Car details
            aCar.getCarDetails(regNo);

            //set details on a certificate
            lblRegNo.Text = aCar.getRegNo().ToUpper();
            lblDiscRegNo.Text = aCar.getRegNo().ToUpper();

            lblFirstRegDate.Text = aCar.getFirstRegDate();

            lblMake.Text = aCar.getMake();
            lblDiscMake.Text = aCar.getMake();

            lblModel.Text = aCar.getModel();
            lblDiscModel.Text = aCar.getModel();

            lblColor.Text = aCar.getColor().ToUpper();
            grbTextRes.Visible = true;
            grbCert.Visible = true;

            // generating uniqueTestID
            int uniquePart1 = lblRegNo.Text.GetHashCode();
            int uniquePart2 = lblFirstRegDate.Text.GetHashCode();
            int uniquePart3 = time.GetHashCode();
            int uniquePart4 = lblAppDate.Text.Trim().GetHashCode();
            int uniqueFinal = Math.Abs(uniquePart1 + uniquePart3 + uniquePart2 + uniquePart4);
            String uniqueTestID = uniqueFinal + "";

            lblUniqTestID.Text = uniqueTestID;
            lblDiscTestId.Text = uniqueTestID;
        }
        //
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtFrontAxle.Text.Trim() == "" || txtRearAxle.Text.Trim() == "" || txtBrake.Text.Trim() == "" || txtParking.Text.Trim() == "" || cboUnits.Text == "")
            {
                MessageBox.Show("All fields must be filled !!!", "Confirmation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!Util.isNumeric(txtFrontAxle.Text.Trim()) || !Util.isNumeric(txtRearAxle.Text.Trim()) || !Util.isNumeric(txtBrake.Text.Trim()) || !Util.isNumeric(txtParking.Text.Trim()) || !Util.isNumeric(txtOdometerRead.Text.Trim()))
            {
                MessageBox.Show("All fields must be numeric only !!!", "Confirmation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FaILPass(txtFrontAxle.Text.Trim(), txtRearAxle.Text.Trim(), txtBrake.Text.Trim(), txtParking.Text.Trim(), lblFirstRegDate.Text);

            btnNotAttended.Visible = false;
            btnSubmit.Visible = true;
            btnConfirm.Visible = false;

            txtBrake.Enabled = false;
            txtOdometerRead.Enabled = false;
            txtRearAxle.Enabled = false;
            txtFrontAxle.Enabled = false;
            txtParking.Enabled = false;

            grdAppointments.Enabled = false;

        }
        //
        private void FaILPass(String frontAxleAsString, String rearAxleAsString, String brakeAsString, String parkingAsString, String firstRegDate)
        {
            int frontAxle = Convert.ToInt32(frontAxleAsString);
            int rearAxle = Convert.ToInt32(rearAxleAsString);
            int brake = Convert.ToInt32(brakeAsString);
            int parking = Convert.ToInt32(parkingAsString);
            DateTime fRagDate = Convert.ToDateTime(firstRegDate);
            //extracting just a year
            int manYear = fRagDate.Year;

            if (frontAxle > 14 || frontAxle < -14)
            {
                lblFrontAxle.Text = "FAIL";
            }
            else
            {
                lblFrontAxle.Text = "PASS";
            }

            if (frontAxle > 18 || frontAxle < -18)
            {
                lblRearAxle.Text = "FAIL";
            }
            else
            {
                lblRearAxle.Text = "PASS";
            }
            if (brake < 55)
            {
                lblBrake.Text = "FAIL";
            }
            else
            {
                lblBrake.Text = "PASS";
            }
            if (parking < 16)
            {
                lblParking.Text = "FAIL";
            }
            else
            {
                lblParking.Text = "PASS";
            }
            if (lblFrontAxle.Text == "PASS" && lblRearAxle.Text == "PASS" && lblBrake.Text == "PASS" && lblParking.Text == "PASS")
            {
                grbDisc.Visible = true;
                lblExpire.Visible = true;
                lblExpireLabel.Visible = true;
            }
            else
            {
                lblFailTest.Visible = true;
                lblUniqTestID.Visible = false;
            }
            //seting next NCT Date
            if (fRagDate < DateTime.Today.AddYears(-4) && fRagDate > DateTime.Today.AddYears(-10))
            {
                lblExpire.Text = DateTime.Today.AddYears(2).ToString("dd-MMM-yyyy").ToUpper();
                lblDiscExpire.Text = DateTime.Today.AddYears(2).ToString("dd-MMM-yyyy").ToUpper();
            }
            else
            {
                lblExpire.Text = DateTime.Today.AddYears(1).ToString("dd-MMM-yyyy").ToUpper();
                lblDiscExpire.Text = DateTime.Today.AddYears(1).ToString("dd-MMM-yyyy").ToUpper();
            }

            lblOdometerUnits.Text = cboUnits.Text;
            lblOdometerRead.Text = txtOdometerRead.Text.Trim();
            lblDiscYear.Text = manYear.ToString();

        }
        private void loadUnits()
        {
            cboUnits.Items.Add("km");
            cboUnits.Items.Add("mi");
        }
        //sate test details and updating next NCT date
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(grbDisc.Visible)
            {
                Test aTest = new Test(Convert.ToInt32(lblDiscTestId.Text.Trim()), lblDiscRegNo.Text.Trim(), Convert.ToInt32(txtCentreID.Text.Trim()), dtpCurrentDate.Text, Convert.ToInt32(txtFrontAxle.Text.Trim()), Convert.ToInt32(txtRearAxle.Text.Trim()), Convert.ToInt32(txtBrake.Text.Trim()), Convert.ToInt32(txtParking.Text.Trim()));
                aTest.recordTestResults();
                Car.updNextNct(lblDiscRegNo.Text.Trim(), lblDiscExpire.Text);

                MessageBox.Show("Test Results have been saved and next NCT Date is updated successful! ", "Confirmation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            btnPrint.Visible = true;
            btnSubmit.Visible = false;
        }
        //updating Appointment status to not attended
        private void btnNotAttended_Click(object sender, EventArgs e)
        {
            Appointment.setNotAttended(uAppID);
            getBookedAppointments(Convert.ToInt32(txtCentreID.Text), dtpCurrentDate.Text);
            grbCert.Visible = false;
            grbTextRes.Visible = false;
        }
        private void clear()
        {
            //reset certificate
            grbDisc.Visible = false;
            lblExpire.Visible = false;
            lblExpireLabel.Visible = false;
            lblFailTest.Visible = false;
            lblFrontAxle.Text = "UNKNOWN";
            lblRearAxle.Text = "UNKNOWN";
            lblBrake.Text = "UNKNOWN";
            lblParking.Text = "UNKNOWN";
            lblOdometerRead.Text = "unknown";
            lblUniqTestID.Text = "unknown";

            //reset test results
            txtBrake.Enabled = true;
            txtOdometerRead.Enabled = true;
            txtRearAxle.Enabled = true;
            txtFrontAxle.Enabled = true;
            txtParking.Enabled = true;
            txtBrake.Text = String.Empty;
            txtParking.Text = String.Empty;
            txtFrontAxle.Text = String.Empty;
            txtRearAxle.Text = String.Empty;
            txtOdometerRead.Text = String.Empty;
            cboUnits.Items.Clear();
            grbTextRes.Visible = false;
            btnNotAttended.Visible = true;
            btnPrint.Visible = false;
            btnConfirm.Visible = true;
            grbCert.Visible = false;

            grdAppointments.Enabled = true;
            loadUnits();

        }
        //printing
        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += this.Doc_PrintPage;
            PrintDialog dlgSettings = new PrintDialog();
            dlgSettings.Document = doc;
            if (dlgSettings.ShowDialog() == DialogResult.OK)
            {
                doc.Print();
            }

            Appointment.setAsProcessed(uAppID);
            getBookedAppointments(Convert.ToInt32(txtCentreID.Text), dtpCurrentDate.Text);

            clear();
        }
        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;
            Bitmap bmp = new Bitmap(this.grbCert.Width, this.grbCert.Height);
            this.grbCert.DrawToBitmap(bmp, new Rectangle(0, 0, this.grbCert.Width, this.grbCert.Height));
            e.Graphics.DrawImage((Image)bmp, x, y);
        }
    }
}
