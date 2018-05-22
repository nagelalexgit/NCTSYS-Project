using System;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace NCTSYS
{
    public partial class frmMakeApp : Form
    {
        private Form parent;
        public frmMakeApp()
        {
            InitializeComponent();
        }
        public frmMakeApp(Form parent)
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

        private void frmMakeApp_Load(object sender, EventArgs e)
        {
            cboCounty.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCentreName.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTime.DropDownStyle = ComboBoxStyle.DropDownList;
            //set minimum Appointment date, cannot be in the past
            dtpAppDate.MinDate = DateTime.Now;
            //set maximum Appointment date, can by up to 3 months in the future
            dtpAppDate.MaxDate = DateTime.Today.AddMonths(3);
            btnCheckReg.Focus();
            
        }
        private void btnCheckReg_Click(object sender, EventArgs e)
        {
            //if Reg NO text field is empty
            if (txtRegNo.Text == "")
            {
                MessageBox.Show("Please Enter Registration Number", "Confirmation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRegNo.Focus();
                return;
            }
            //if reg no not valid
            if (Util.isValidReg(txtRegNo.Text.Trim()) == false)
            {
                MessageBox.Show("Registration Number you entered is invalid !\nPlease Re-enter", "Confirmation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRegNo.Focus();
                return;
            }
            //get and fill car details
            fillCarDetails();
            btnContinue.Focus();
        }
        private void btnContinue_Click(object sender, EventArgs e)
        {
            grbCentre.Visible = true;
            btnContinue.Visible = false;
            loadCounties();
        }
        
        private void cboCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
            //dtpAppDate.Value = DateTime.Today.AddDays(-1);
            cboTime.Items.Clear();
            loadCentres(cboCounty.Text.ToUpper().Trim());
            grbAppDate.Visible = false;
            grbTime.Visible = false;
            btnBook.Visible = false;
            
            
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
            grbAppDate.Visible = true;
            loadCentreID(cboCentreName.SelectedItem.ToString());
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
        private void dtpAppDate_ValueChanged(object sender, EventArgs e)
         
        {
      
            getAvalibleTimeSlots(Convert.ToInt32(txtCentreID.Text), dtpAppDate.Value.ToString("dd-MMM-yy"));


        }

        private void getAvalibleTimeSlots(int centreId, string appDate)
        {
            //open database
            OracleConnection myConn = new OracleConnection(DBConnect.oradb);
            myConn.Open();
            String strSQL = "SELECT APP_TIME FROM TIMESLOTS WHERE APP_TIME NOT IN (SELECT APP_TIME FROM APPOINTMENTS WHERE APP_DATE = '" + appDate + "' AND CENTRE_ID = " + centreId + ") ORDER BY APP_TIME *1";
            OracleCommand cmd = new OracleCommand(strSQL, myConn);

            OracleDataReader dr = cmd.ExecuteReader();


            //load data from datareader into text box
            cboTime.Items.Clear();
            String x;

            while (dr.Read())
            {
                x = dr.GetString(0);
                cboTime.Items.Add(x);
            }

            //Close DB
            myConn.Close();

            grbTime.Visible = true;
        }

        public void fillCarDetails()
        {
            //creating an instance of an Car object
            Car aCar = new Car();
            //geting Car Details
            aCar.getCarDetails(txtRegNo.Text.Trim().ToUpper());

            //if car not found
            if (aCar.getRegNo().Equals(""))
            {
                MessageBox.Show("Registration Number you entered not in database  !\nPlease Re-enter", "Confirmation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRegNo.Focus();
                return;
            }
            //if car is allready De-Registered
            if (aCar.getCarStatus().ToString().Equals("I"))
            {
                MessageBox.Show("Registration Number you entered is De-Registered!\nAppointment can not be made !", "Confirmation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRegNo.Focus();
                return;
            }
            else
            {
                //make check button not visible
                btnCheckReg.Visible = false;
                //insert existing  car RegNo in to text box
                txtRegNo.Text = aCar.getRegNo();

                //insert existing  car Make in to text box
                txtMake.Text = aCar.getMake();

                //insert existing  car Model in to text box
                txtModel.Text = aCar.getModel();

                //insert existing  car Color in to text box
                txtColor.Text = aCar.getColor();

                //insert existing  car Engine Size in to text box
                txtEngine.Text = aCar.getEngine().ToString();

                //insert existing  car Fuel Type in to text box
                txtFuel.Text = aCar.getFuel();

                // insert existing  car First Reg date in to DateTime Picker
                dtpFregdate.Value = Convert.ToDateTime(aCar.getFirstRegDate());

                //getting current owner PPSN
                txtOwnerPPSN.Text = aCar.getCurrentOwner();

                //make all fields not editable
                txtRegNo.ReadOnly = true;
                txtMake.ReadOnly = true;
                txtModel.ReadOnly = true;
                txtColor.ReadOnly = true;
                txtEngine.ReadOnly = true;
                txtFuel.ReadOnly = true;
                dtpFregdate.Enabled = false;
                grbCarDetails.Visible = true;
                btnClear.Visible = true;
            }
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

        private void cboTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnBook.Visible = true;
            btnBook.Focus();
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            //geting Appointment details
            int AppID = Appointment.nextAppID();
            String time = cboTime.Text.Trim();
            String date = String.Format("{0:dd-MMM-yy}", dtpAppDate.Value);
            char status = 'B'; //for booked
            String regNo = txtRegNo.Text.Trim();
            int centreID = Convert.ToUInt16(txtCentreID.Text);
            String centreName = cboCentreName.SelectedItem.ToString();

            // generating uniqueAppID
            int uniquePart1 = dtpAppDate.Text.GetHashCode();
            int uniquePart2 = cboTime.Text.GetHashCode();
            int uniquePart3 = txtRegNo.Text.Trim().GetHashCode();
            int uniqueFinal = Math.Abs(uniquePart1 + uniquePart3 + uniquePart2);
            String uniqueAppID = uniqueFinal + "";

            //getting current owner details
            Owner aOwner = new Owner();
            aOwner.getOwnerDetails(txtOwnerPPSN.Text.Trim());
            String email = aOwner.getEmail();
            String sname = aOwner.getSname();
            String fname = aOwner.getFname();

            //================
            Appointment newAppointment = new Appointment(AppID, time, date, status, regNo, centreID, uniqueAppID);
            newAppointment.bookAppointment();

            Util.sentAppConfirmEmail(time, date, regNo, uniqueAppID, email, centreName,sname, fname);

            MessageBox.Show("Appointment Details: \nDate: " + date + "\nTime: " + time + "\nLocation: " + centreName + "\nUnique App ID: " + uniqueAppID + "\n\nConfirmation email will be sent shortly.\nThank You!","Booking Successful!",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
            clearForm();

        }

        public void clearForm()
        {
            this.Controls.Clear();
            this.InitializeComponent();
            cboCounty.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCentreName.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTime.DropDownStyle = ComboBoxStyle.DropDownList;
            dtpAppDate.MinDate = DateTime.Today.AddDays(-1);
            dtpAppDate.MaxDate = DateTime.Today.AddMonths(3);
            btnCheckReg.Focus();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearForm();
        }

    }
}
