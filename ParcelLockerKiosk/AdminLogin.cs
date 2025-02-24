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

namespace ParcelLockerKiosk
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
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
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string UserName;
            string Password;
            UserName = txtUserId.Text;
            Password = txtPass.Text;
            try
            {
                ModFUNCTIONS.fetch("Select * from Admin where User_Id = '" + UserName + "' AND Password = '" + Password + "'", Dbconnect.ds1);
                if (Dbconnect.ds1.Tables[0].Rows.Count != 0)
                {
                    UserName = txtUserId.Text;
                    Password = txtPass.Text;
                    Variables.AdminId = Dbconnect.ds1.Tables[0].Rows[0]["Id"].ToString();

                    AdminPanel obj = new AdminPanel();
                    obj.Show();
                    Application.DoEvents();
                    this.Dispose();

                }
                else
                {
                    MessageBox.Show("Invalid Login Details", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
            }
            catch (Exception)
            {

                //MessageBox.Show("Error");
            }
            
            
            
            
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Home obj = new Home();
            obj.Show();
            Application.DoEvents();
            this.Dispose();
        }

        private void lblMsg_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUserId.Text = "";
            txtPass.Text = "";
        }

        private void KeyType(object sender, EventArgs e)
        {
            try
            {
                Button b = sender as Button;
                //Set focus
                if (strTxtFocus == "Admin")
                    txtUserId.Focus();
                else if (strTxtFocus == "Password")
                    txtPass.Focus();
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
               // MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); 
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

        private void txtUserId_Click(object sender, EventArgs e)
        {
            strTxtFocus = "Admin";
        }

        private void txtPass_Click(object sender, EventArgs e)
        {
            strTxtFocus = "Password";
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {
           
        }
    }
}
