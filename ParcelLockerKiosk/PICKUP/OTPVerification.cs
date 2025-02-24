using ParcelLockerKiosk.Modulus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParcelLockerKiosk.PICKUP
{
    public partial class OTPVerification : Form
    {
        public OTPVerification()
        {
            InitializeComponent();
        }
        string strTxtFocus = "";
        bool blCapsLock = false;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED
                return cp;
            }
        }
        private void KeyType(object sender, EventArgs e)
        {
            try
            {
                Button b = sender as Button;
                //Set focus
                if (strTxtFocus == "")
                    txtPin.Focus();
                //else if (strTxtFocus == "SUBDIV")
                //    txtSubDivision.Focus();
                //else if (strTxtFocus == "COMPNM")
                //    txtCompName.Focus();
                //else if (strTxtFocus == "COMPCD")
                //    txtCompCode.Focus();

                if (b.Name == "btnBks")
                    SendKeys.Send("{BS}");
                else if (b.Name == "btnClear")
                    txtPin.Clear();
                else
                    SendKeys.Send(b.Text);
                //SendKeys.Send("{RIGHT}");  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btncaps_Click(object sender, EventArgs e)
        {
            {
                if (blCapsLock == false)
                {
                    //btncaps.Text = "ABC";
                    blCapsLock = true;
                    btn1.Text = "1";
                    btn2.Text = "2";
                    btn3.Text = "3";
                    btn4.Text = "4";
                    btn5.Text = "5";
                    btn6.Text = "6";
                    btn7.Text = "7";
                    btn8.Text = "8";
                    btn9.Text = "9";
                    btn0.Text = "0";
                }

            }
        }

        private void OTPVerification_Load(object sender, EventArgs e)
        {

        }

        private void btnVerify_Click(object sender, EventArgs e)
        {

            Variables.OTP = Convert.ToInt32(txtPin.Text);
            ModFUNCTIONS.fetch("SELECT *FROM LockerTransaction where OTP = '" + Variables.OTP + "' ", Dbconnect.ds1);
            if (Dbconnect.ds1.Tables[0].Rows.Count > 0)
            {
                VerifyCustomerDetails obj = new VerifyCustomerDetails();
                obj.Show();
                Application.DoEvents();
                this.Dispose();
            }

            else
            {
                MessageBox.Show("OTP is Wrong!");
            }







          
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Home obj = new Home();
            obj.Show();
            Application.DoEvents();
            this.Dispose();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ScanShippingNoteNo obj = new ScanShippingNoteNo();
            obj.Show();
            Application.DoEvents();
            this.Dispose();
        }

        private void txtPin_Click(object sender, EventArgs e)
        {
            strTxtFocus = "";
        }
    }
}
