using System;
using System.Windows.Forms;

namespace NCTSYS
{
    public partial class frmCancelApp : Form
    {
        private Form parent;
        public frmCancelApp()
        {
            InitializeComponent();
        }
        public frmCancelApp(Form parent)
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

        private void btnCheckAppID_Click(object sender, EventArgs e)
        {
            if (txtAppID.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Appointment ID !", "Confirmation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAppID.Focus();
                return;
            }

            if(Appointment.isExists(txtAppID.Text.Trim()) == "canceled")//Appointment already canceled
            {
                MessageBox.Show("Appointment already canceled !", "Confirmation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAppID.Focus();
                return;
            }
            if (Appointment.isExists(txtAppID.Text.Trim()) == "non")// Appointment not found
            {
                MessageBox.Show("Appointment not found !!!\nPlease re-check your Appointment ID", "Confirmation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAppID.Focus();
                return;
            }

            Appointment aAppointment = new Appointment();
            aAppointment.getAppointmentDetails(txtAppID.Text.Trim());

            Centre aCentre = new Centre();
            aCentre.getCentreDetails(aAppointment.getCentreID());
            txtCounty.Text = aCentre.getCounty();
            txtCentreName.Text = aCentre.getCentreName();

            dtpAppDate.Text = aAppointment.getAppDate();
            txtTime.Text = aAppointment.getAppTime();
            txtRegNo.Text = aAppointment.getRegNo();

            grbAppDetails.Visible = true;
            btnCheckAppID.Visible = false;
            btnNext.Focus();
            btnClear.Visible = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            btnNext.Visible = false;
            btnCancel.Visible = true;
            btnCancel.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Appointment.cancelAppointment(txtAppID.Text.Trim());

            MessageBox.Show("Appointment have neen canceled !\nThank You !", "Confirmation",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
            clearForm();
            txtAppID.Focus();
            return;

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        private void clearForm()
        {
            this.Controls.Clear();
            this.InitializeComponent();
        }
    }
}
