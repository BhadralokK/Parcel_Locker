using ParcelLockerKiosk.ADMIN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParcelLockerKiosk
{
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED
                return cp;
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("shutdown.exe", "-r -t 0");
        }

        private void btnShutdown_Click(object sender, EventArgs e)
        {
            Process.Start("shutdown", "/s /t 0");
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Home obj = new Home();
            obj.Show();
            Application.DoEvents();
            this.Dispose();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmployeeRegistration obj = new EmployeeRegistration();
            
            obj.Show();
            Application.DoEvents();
            //this.Hide();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShippingDetails obj = new ShippingDetails();
           
            obj.Show();
           
        }
    }
}
