using System;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;


namespace NCTSYS
{
    public partial class frmReg : Form
    {
        private Form parent;
        public frmReg()
        {
            InitializeComponent();
        }
        public frmReg(Form parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Show();
        }
        //================================================================================

        //Load form components
        private void frmReg_Load(object sender, EventArgs e)
        {
            //loading makes, models, counties, engine sizes, colors, fuel types
            loadMake();
            loadModels();
            loadCounties();
            loadEngine();
            loadColor();
            loadFuel();
            // set combo boxes selectable only
            cboColour.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCounty.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEngine.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFuel.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMake.DropDownStyle = ComboBoxStyle.DropDownList;
            cboModel.DropDownStyle = ComboBoxStyle.DropDownList;
            //set minumum date of DOB to 17
            dtpDob.MaxDate = DateTime.Today.AddYears(-17);
            dtpDob.MinDate = DateTime.Today.AddYears(-130);
            //set date, cannot be in the future
            dtpFregdate.MaxDate = DateTime.Now;
            dtpRegDate.MaxDate = DateTime.Now;
        
            //casting to upper case
            txtRegNo.CharacterCasing = CharacterCasing.Upper;
            txtPPSN.CharacterCasing = CharacterCasing.Upper;
            txtFname.CharacterCasing = CharacterCasing.Upper;
            txtSname.CharacterCasing = CharacterCasing.Upper;
            txtAdd1.CharacterCasing = CharacterCasing.Upper;
            txtAdd2.CharacterCasing = CharacterCasing.Upper;
            txtEmail.CharacterCasing = CharacterCasing.Upper;

            btnClearCarReg.Visible = false;    
        }

        // Registration No validation
        private void btnCheckReg_Click(object sender, EventArgs e)
        {
            if (txtRegNo.Text == "")
            {
                MessageBox.Show("Please Enter Registration Number", "Confirmation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRegNo.Focus();
                return;
            }
            if (Util.isValidReg(txtRegNo.Text.Trim()) == false)
            {
                MessageBox.Show("Registration Number you entered is invalid !\nPlease Re-enter", "Confirmation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRegNo.Focus();
                return;
            }
            //loading fillCarDetails method
            fillCarDetails();

            grbCarDetails.Visible = true;
            txtRegNo.ReadOnly = true;
            btnCheckReg.Visible = false;
            btnClearCarReg.Visible = true;
        }
        public void fillCarDetails()
        {
            Car car = new Car();
            car.getCarDetails(txtRegNo.Text.ToUpper().Trim());

            //if a new car
            if (car.getMake().Equals(""))
            {
                chkCar.Checked = false;
            }

            //if car exists
            else
            {
                chkCar.Checked = true;

                lblNextNct.Visible = false;
                dtpNextNct.Visible = false;

                txtRegNo.Text = car.getRegNo();

                //insert existing  car Make in to combo box
                String strMake = car.getMake().Trim();
                cboMake.SelectedIndex = 0;
                while (!cboMake.Text.Equals(strMake))
                {
                    cboMake.SelectedIndex++;
                }

                //insert existing  car Model in to combo box
                String strModel = car.getModel().Trim();
                cboModel.SelectedIndex = 0;
                while (!cboModel.Text.Equals(strModel))
                {
                    cboModel.SelectedIndex++;
                }

                //insert existing  car Color in to combo box
                String strColor = car.getColor().Trim();
                cboColour.SelectedIndex = 0;
                while (!cboColour.Text.Equals(strColor))
                {
                    cboColour.SelectedIndex++;
                }

                //insert existing  car Engine Size in to combo box
                String strEngine = car.getEngine().ToString("0.#").Trim();
                cboEngine.SelectedIndex = 0;
                while (!cboEngine.Text.Equals(strEngine))
                {
                    cboEngine.SelectedIndex++;
                }

                //insert existing  car Fuel Type in to combo box
                String strFuelType = car.getFuel().Trim();
                cboFuel.SelectedIndex = 0;
                while (!cboFuel.Text.Equals(strFuelType))
                {
                    cboFuel.SelectedIndex++;
                }
                // insert existing  car First Reg date in to DateTime Picker
                dtpFregdate.Value = Convert.ToDateTime(car.getFirstRegDate());

                //make all fields not editable
                txtRegNo.ReadOnly = true;
                cboMake.Enabled = false;
                cboModel.Enabled = false;
                cboColour.Enabled = false;
                cboEngine.Enabled = false;
                cboFuel.Enabled = false;
                dtpFregdate.Enabled = false;
            }
        }
  
        private void btnCarSubmit_Click(object sender, EventArgs e)
        {
            //Car details validation for empty fields
            if (cboMake.Text == "" || cboModel.Text == "" || cboEngine.Text == "" || cboColour.Text == "" || cboFuel.Text == "")
            {
                MessageBox.Show("All fields must be filled !!!", "Confirmation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                grbPPSN.Visible = true;
                btnCarSubmit.Visible = false;
            }
        }

        //PPSN check and validation
        private void btnCheckPPSN_Click(object sender, EventArgs e)
        {
            if (txtPPSN.Text == "")
            {
                MessageBox.Show("Please Enter your PPSN !", "Confirmation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (Util.isValidPPSN(txtPPSN.Text) == false)
            {
                MessageBox.Show("PPS Number you entered is invalid !\nPlease Re-enter", "Confirmation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // set minimum date for new registration from current ownership date
                dtpRegDate.MinDate = Registration.getCurrentOwnerDate(txtRegNo.Text.ToUpper().Trim());
                //get Owner details
                Owner aOwner = new Owner();
                aOwner.getOwnerDetails(txtPPSN.Text);

                //if owner not found set checkbox = false
                if(aOwner.getPPSN().Equals(""))
                {
                    chkExists.Checked = false;
                    //set form controls enabled = true

                }
                else
                {
                    //if owner found set check box = true
                    chkExists.Checked = true;
                    //load owner details onto the form and set enabled = false

                    txtSname.Text = aOwner.getSname();
                    txtSname.Enabled = false;
                    txtFname.Text = aOwner.getFname();
                    txtFname.Enabled = false;
                    dtpDob.Text = aOwner.getDOB();
                    dtpDob.Enabled = false;
                    txtTelNo.Text = aOwner.getTelNum();
                    txtTelNo.Enabled = false;
                    txtEmail.Text = aOwner.getEmail();
                    txtEmail.Enabled = false;
                    txtAdd1.Text = aOwner.getAdd1();
                    txtAdd1.Enabled = false;
                    txtAdd2.Text = aOwner.getAdd2();
                    txtAdd2.Enabled = false;
                    cboCounty.Text = aOwner.getCounty();
                    cboCounty.Enabled = false;
                }
                
                grbOdetails.Visible = true;
                txtPPSN.ReadOnly = true;
                btnCheckPPSN.Visible = false;
            }
        }
        

        //Clear form
        private void btnClearCarReg_Click_1(object sender, EventArgs e)
        {
            clearReg();
        }

        //Register + Owner details validation
        private void btnRegCar_Click(object sender, EventArgs e)
        {
            if (txtSname.Text == "" || txtFname.Text == "" || txtEmail.Text == "" || txtAdd1.Text == "" || txtAdd2.Text == "" || cboCounty.Text == "" || txtTelNo.Text == "")
            {
                MessageBox.Show("All fields must be filled !!!", "Confirmation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!Util.isNumeric(txtTelNo.Text.Trim()))
            {
                MessageBox.Show("Phone Number must be numeric only !\nPlease Re-enter", "Confirmation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!Util.isValidEmail(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Email address you entered is invalid !\nPlease Re-enter", "Confirmation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dtpRegDate.Value.Date < dtpFregdate.Value.Date)
            {
                MessageBox.Show("Date of ownership transfer exids manufacture date !\nPlease Re-select", "Confirmation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (Registration.isProcessed(txtRegNo.Text.Trim(), dtpRegDate.Text))
            {
                MessageBox.Show("Already processed !", "Confirmation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                //Insert data into cars, owners and registrations tables
                //instantiate Car Object
                if (chkCar.Checked == false)
                {

                    char carStatus = 'A';
                    Car newCar = new Car(txtRegNo.Text.ToUpper(), cboMake.Text, cboModel.Text, Convert.ToDouble(cboEngine.Text), cboColour.Text, cboFuel.Text, carStatus, dtpFregdate.Text, txtPPSN.Text.ToUpper(), dtpNextNct.Text);
                    newCar.regCar();
                }
                else
                {
                    Car.updCurrentOwner(txtRegNo.Text.ToUpper(), txtPPSN.Text.ToUpper());
                }


                //instantiate Owner Object
                if (chkExists.Checked == false)
                {
                    Owner newOwner = new Owner(txtPPSN.Text.ToUpper(), txtSname.Text.Trim(), txtFname.Text.Trim().Replace(@"'", string.Empty), dtpDob.Text, txtTelNo.Text.Trim().Replace(@" ", string.Empty), txtEmail.Text.ToLower().Trim(), txtAdd1.Text.Trim(), txtAdd2.Text.Trim(), cboCounty.Text.ToUpper());
                    newOwner.regOwner();
                }
                
                //instantiate Registration Object
                Registration newRegistration = new Registration(txtRegNo.Text.ToUpper(), dtpRegDate.Text, txtPPSN.Text.ToUpper());
                //registering ownership
                newRegistration.regOwnership();

                //Display confirmation message
                MessageBox.Show("Registration Number: " + txtRegNo.Text.Trim() + " is now registered" + "\nThank you !", "Confirmation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Clear registration form
                clearReg();
            }
        }
        

        //load makes from DB
        public void loadMake()
        {
            //open database
            OracleConnection myConn = new OracleConnection(DBConnect.oradb);
            myConn.Open();

            String strSQL = "SELECT DISTINCT Make FROM MakeModels ORDER BY Make";
            OracleCommand cmd = new OracleCommand(strSQL, myConn);

            OracleDataReader dr = cmd.ExecuteReader();

            //load data from datareader into combo box
            cboMake.Items.Clear();

            while (dr.Read())
            {
                cboMake.Items.Add(dr.GetString(0).Trim());
            }

            myConn.Close();
        }

        //load models from DB
        public void loadModels()
        {
            //open database
            OracleConnection myConn = new OracleConnection(DBConnect.oradb);
            myConn.Open();

            String strSQL = "SELECT Model FROM MakeModels WHERE Make = '" + cboMake.Text + "' ORDER BY Make, Model";
            OracleCommand cmd = new OracleCommand(strSQL, myConn);

            OracleDataReader dr = cmd.ExecuteReader();

            //load data from datareader into combo box
            cboModel.Items.Clear();
            while (dr.Read())
            {
                cboModel.Items.Add(dr.GetString(0).Trim());
            }
            //Close DB
            myConn.Close();
        }

        //load models into como box
        private void cboMake_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadModels();
        }

        //clear form
        private void clearReg()
        {
            grbOdetails.Visible = false;
            grbPPSN.Visible = false;
            grbCarDetails.Visible = false;
            txtRegNo.Text = String.Empty;
            cboMake.Enabled = true;
            cboModel.Enabled = true;
            cboColour.Enabled = true;
            cboEngine.Enabled = true;
            cboFuel.Enabled = true;
            dtpFregdate.Enabled = true;
            cboColour.Items.Clear();
            cboEngine.Items.Clear();
            cboCounty.Items.Clear();
            cboFuel.Items.Clear();
            cboMake.Items.Clear();
            cboModel.Items.Clear();
            txtPPSN.Text = String.Empty;
            txtSname.Text = String.Empty;
            txtFname.Text = String.Empty;
            txtTelNo.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtAdd1.Text = String.Empty;
            txtAdd2.Text = String.Empty;
            txtRegNo.ReadOnly = false;
            txtPPSN.ReadOnly = false;
            btnCarSubmit.Visible = true;
            btnCheckReg.Visible = true;
            btnCheckPPSN.Visible = true;
            btnClearCarReg.Visible = false;
            txtSname.Enabled = true;
            txtFname.Enabled = true;
            dtpDob.Enabled = true;
            txtTelNo.Enabled = true;
            txtEmail.Enabled = true;
            txtAdd1.Enabled = true;
            txtAdd2.Enabled = true;
            cboCounty.Enabled = true;
            dtpDob.Value = DateTime.Today.AddYears(-17);
            dtpFregdate.Value = DateTime.Today;
            loadCounties();
            loadEngine();
            loadColor();
            loadFuel();
            loadMake();
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
        public void loadEngine()
        {
            //open database
            OracleConnection myConn = new OracleConnection(DBConnect.oradb);
            myConn.Open();

            String strSQL = "SELECT * FROM EngineSizes";
            OracleCommand cmd = new OracleCommand(strSQL, myConn);

            OracleDataReader dr = cmd.ExecuteReader();

            //clearing combo box befor load
            cboEngine.Items.Clear();
            //load data from datareader into combo box
            while (dr.Read())
            {
                cboEngine.Items.Add(dr.GetDouble(0).ToString("0.#").Trim());
            }
            //Close DB
            myConn.Close();
           
        }
        
        public void loadColor()
        {
            cboColour.Items.Add("White");
            cboColour.Items.Add("Black");
            cboColour.Items.Add("Green");
            cboColour.Items.Add("Gold");
            cboColour.Items.Add("Silver");
            cboColour.Items.Add("Pink");
            cboColour.Items.Add("Grey");
        }
        public void loadFuel()
        {
            cboFuel.Items.Add("PETROL");
            cboFuel.Items.Add("DIESEL");
        }
        //generating Next NCT Date
        private void dtpFregdate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFregdate.Value >= DateTime.Today.AddYears(-4))
            {
                dtpNextNct.Value = dtpFregdate.Value.AddYears(4);
                return;
            }
            else
            {
                dtpNextNct.Value = DateTime.Today.AddMonths(1);
                return;
            }
        }
    }
}
