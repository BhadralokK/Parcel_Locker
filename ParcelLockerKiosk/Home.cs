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
    public partial class Home : Form
    {
        public Home()
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

        private void btnProceed_Click(object sender, EventArgs e)
        {
            ChooseUserType obj = new ChooseUserType();
            obj.Show();
            Application.DoEvents();
            this.Hide();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            Dbconnect.main();
        }
        int cnt = 0;
        private void btnAdmin_Click(object sender, EventArgs e)
        {
          
        }

        private void AdminBtn_Click(object sender, EventArgs e)
        {
            cnt = cnt + 1;
            if (cnt == 7)
            {
                cnt = 0;
                AdminLogin obj = new AdminLogin();
                obj.Show();
                Application.DoEvents();
                this.Hide();
            }
        }
    }
}
