using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ParcelLockerKiosk.Modulus;
using ParcelLockerKiosk.ADMIN;

namespace ParcelLockerKiosk
{
    public partial class SelectEmployeeId : Form
    {
        public SelectEmployeeId()
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
                    txtEmpId.Focus();
                //else if (strTxtFocus == "SUBDIV")
                //    txtSubDivision.Focus();
                //else if (strTxtFocus == "COMPNM")
                //    txtCompName.Focus();
                //else if (strTxtFocus == "COMPCD")
                //    txtCompCode.Focus();

                if (b.Name == "btnBks")
                    SendKeys.Send("{BS}");
                else if (b.Name == "btnClear")
                    txtEmpId.Clear();
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
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (txtEmpId.Text == "" )
            {
                MessageBox.Show("Enter a valid Employee Number");
                return;
            }
            else
            {
                Variables.Id = Convert.ToInt32(txtEmpId.Text);
                ModFUNCTIONS.fetch("SELECT *FROM EmployeeMaster where Emp_id = '" + Variables.Id + "' ", Dbconnect.ds1);
                if (Dbconnect.ds1.Tables[0].Rows.Count > 0)
                {
                    TakePhoto obj = new TakePhoto();
                    obj.Show();
                    Application.DoEvents();
                    this.Dispose();
                }

                else
                {
                    MessageBox.Show("Employee not registered!");
                }
                ModFUNCTIONS.fetch("select LockerTrans_ID from LockerTransaction order by LockerTrans_ID desc", Dbconnect.ds1);
                if (Dbconnect.ds1.Tables[0].Rows.Count != 0)
                {
                    Variables.Locker_Id = Convert.ToInt32(Dbconnect.ds1.Tables[0].Rows[0][0]) + 1;

                }

                else
                {
                    Variables.Locker_Id = 1;
                }
                ModFUNCTIONS.dml_statement("Insert into LockerTransaction (Emp_id) values('" + Variables.Id + "') ");
               
            }

           






            
        }

        private void SelectEmployeeId_Load(object sender, EventArgs e)
        {

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
            ChooseUserType obj = new ChooseUserType();
            obj.Show();
            Application.DoEvents();
            this.Dispose();
        }

        private void txtEmpId_Click(object sender, EventArgs e)
        {
            strTxtFocus = "";
        }
    }
}
