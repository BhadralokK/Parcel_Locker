using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ParcelLockerKiosk.PICKUP;

namespace ParcelLockerKiosk
{
    public partial class ChooseUserType : Form
    {
        public ChooseUserType()
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

        private void btnPutter_Click(object sender, EventArgs e)
        {
            SelectEmployeeId obj=new SelectEmployeeId();
            obj.Show();
            Application.DoEvents();
            this.Dispose();
        }

        private void btnPicker_Click(object sender, EventArgs e)
        {
            SearchShippingNoteNo obj = new SearchShippingNoteNo();
            obj.Show();
            Application.DoEvents();
            this.Dispose();
        }

        private void ChooseUserType_Load(object sender, EventArgs e)
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
            Home obj = new Home();
            obj.Show();
            //this.Hide();
            Application.DoEvents();
        }
    }
}
