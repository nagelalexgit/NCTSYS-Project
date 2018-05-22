using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NCTSYS
{
    public partial class frmNewCentre : Form
    {
        private Form parent;
        public frmNewCentre()
        {
            InitializeComponent();
        }
        public frmNewCentre(Form parent)
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

        private void frmNewCentre_Load(object sender, EventArgs e)
        {
            loadCounties();
            cboCounty.DropDownStyle = ComboBoxStyle.DropDownList;
            txtCentreId.Text = Centre.nextCentreID().ToString("0000");
        }
        //Register + Centre details validation
        private void btnRegCentre_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "" || txtAdd1.Text.Trim() == "" || txtAdd2.Text.Trim() == "" || txtTelNo.Text.Trim() == "" || txtEmail.Text.Trim() == "" || cboCounty.Text == "")
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
            else
            {
                //instantiate Centre Object
                char status = 'A';
                Centre aCentre = new Centre(Convert.ToInt32(txtCentreId.Text.Trim()), txtName.Text.ToUpper().Trim(), txtAdd1.Text.ToUpper().Trim(), txtAdd2.Text.ToUpper().Trim(), txtTelNo.Text.Trim(), txtEmail.Text.ToLower().Trim(), cboCounty.SelectedItem.ToString().ToUpper().Trim(), status);
                //call regCentre method
                aCentre.regCentre();

                //Display confirmation message
                MessageBox.Show("Test Centre is now registered" + "\nThank you !", "Confirmation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Clear registration form
                clearForm();
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
        private void clearForm()
        {
            txtCentreId.Text = Centre.nextCentreID().ToString("000");
            txtName.Text = String.Empty;
            txtAdd1.Text = String.Empty;
            txtAdd2.Text = String.Empty;
            txtTelNo.Text = String.Empty;
            txtEmail.Text = String.Empty;
            cboCounty.Items.Clear();
            loadCounties();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearForm();
        }
    }
}
