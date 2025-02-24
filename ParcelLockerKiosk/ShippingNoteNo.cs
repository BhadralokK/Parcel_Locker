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

namespace ParcelLockerKiosk
{
    public partial class ShippingNoteNo : Form
    {
        public ShippingNoteNo()
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

        private void btnNext_Click(object sender, EventArgs e)
        {
            ScanShippingNoteNo obj = new ScanShippingNoteNo();
            obj.Show();
            Application.DoEvents();
            this.Dispose();
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

                if (b.Name == "btnKeyBoardBack2")
                    SendKeys.Send("{BS}");
                else if (b.Name == "btnspace")
                    SendKeys.Send(" ");
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
                    btncaps.Text = "ABC";
                    blCapsLock = true;
                    btna.Text = "a";
                    btnb.Text = "b";
                    btnc.Text = "c";
                    btnd.Text = "d";
                    btne.Text = "e";
                    btnf.Text = "f";
                    btng.Text = "g";
                    btnh.Text = "h";
                    btni.Text = "i";
                    btnj.Text = "j";
                    btnk.Text = "k";
                    btnl.Text = "l";
                    btnm.Text = "m";
                    btnn.Text = "n";
                    btno.Text = "o";
                    btnp.Text = "p";
                    btnq.Text = "q";
                    btnr.Text = "r";
                    btns.Text = "s";
                    btnt.Text = "t";
                    btnu.Text = "u";
                    btnv.Text = "v";
                    btnw.Text = "w";
                    btnx.Text = "x";
                    btny.Text = "y";
                    btnz.Text = "z";
                }
                else
                {
                    blCapsLock = false;
                    btncaps.Text = "abc";
                    btna.Text = "A";
                    btnb.Text = "B";
                    btnc.Text = "C";
                    btnd.Text = "D";
                    btne.Text = "E";
                    btnf.Text = "F";
                    btng.Text = "G";
                    btnh.Text = "H";
                    btni.Text = "I";
                    btnj.Text = "J";
                    btnk.Text = "K";
                    btnl.Text = "L";
                    btnm.Text = "M";
                    btnn.Text = "N";
                    btno.Text = "O";
                    btnp.Text = "P";
                    btnq.Text = "Q";
                    btnr.Text = "R";
                    btns.Text = "S";
                    btnt.Text = "T";
                    btnu.Text = "U";
                    btnv.Text = "V";
                    btnw.Text = "W";
                    btnx.Text = "X";
                    btny.Text = "Y";
                    btnz.Text = "Z";
                }
            }
        }

        private void ShippingNoteNo_Load(object sender, EventArgs e)
        {
            btnNext.Visible = false;
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
            TakePhoto obj = new TakePhoto();
            obj.Show();
            Application.DoEvents();
            this.Dispose();
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
           
            //btnNext.Visible = false;
            if (string.IsNullOrWhiteSpace(txtEmpId.Text))
            {
                MessageBox.Show("Enter a valid Shipping Number");
                return;
            }
            else 
            {
                
                Variables.Id = Convert.ToInt32(txtEmpId.Text);
                ModFUNCTIONS.fetch("SELECT *FROM [ShippingDetails] where Ship_No = '" + Variables.Id + "' ", Dbconnect.ds1);
                if (Dbconnect.ds1.Tables[0].Rows.Count > 0)
                {
                    Variables.Shippername = Dbconnect.ds1.Tables[0].Rows[0]["Ship_Name"].ToString();
                    Variables.ShipperAddress = Dbconnect.ds1.Tables[0].Rows[0]["Ship_Address"].ToString();
                    Variables.ConsigneeName = Dbconnect.ds1.Tables[0].Rows[0]["Consignee_Name"].ToString();
                    Variables.ConsigneeAddress = Dbconnect.ds1.Tables[0].Rows[0]["Consignee_Address"].ToString();
                    label3.Text = "Shipper Name:-"; 
                    label8.Text=  Variables.Shippername;
                    label4.Text = "Shipper Address:-";
                    label10.Text = Variables.ShipperAddress;
                     label6.Text = "Consignee Name:-";
                    label9.Text= Variables.ConsigneeName;
                    label5.Text = "Consignee Address:-";
                    label11.Text =  Variables.ConsigneeAddress;
                    btnNext.Visible = true;
                }
            
            }


           
            

        }

        private void txtEmpId_Click(object sender, EventArgs e)
        {
            strTxtFocus = "";
        }
    }
}
