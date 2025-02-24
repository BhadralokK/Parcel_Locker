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
using System.Collections;
using System.IO;

namespace ParcelLockerKiosk
{
    public partial class SelectDropLocker : Form
    {

        private Button btn;
        private string BtnText;
        private string BtnName;
        private ArrayList LOCKER = new ArrayList();
        private ArrayList btnLOCKERS = new ArrayList();
        private int cnt = 0;
        private string LockerName;
        private string Locker_Status = "Active";
        private string TrnSl;
        private string filePath;
        private string LcSts;
        private int countr = 60;
        private string VisitId;
        private string QrId;

        private int LockerNo2;
        private int OTP;
        private Button button;
        private string LOCKERNO;

        public SelectDropLocker()
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

        private void Label63_Click(object sender, EventArgs e)
        {

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            ConfirmDetailsLockerOpen obj = new ConfirmDetailsLockerOpen();
            obj.Show();
            Application.DoEvents();
            this.Dispose();
        }

        private void SelectDropLocker_Load(object sender, EventArgs e)
        {
            SetAllButtonsToGreen();

            var btnLocker1 = new Button(); // Placeholder for actual button initialization
            var btnLocker2 = new Button(); // Placeholder for actual button initialization
            var btnLocker3 = new Button(); // Placeholder for actual button initialization
            var btnLocker4 = new Button(); // Placeholder for actual button initialization
            var btnOpen = new Button();    // Placeholder for actual button initialization

            // Fetch locker status from database
            var ds1 = new DataSet();
            ModFUNCTIONS.fetch("select * from LockerStatus where Locker_Status='BOOKED' order by Locker_No", ds1);

            if (ds1.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds1.Tables[0].Rows)
                {
                    string lockerNo = row["Locker_No"].ToString();

                    if (btnLocker1.Text == lockerNo)
                    {
                        btnLocker1.BackgroundImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LockerImages", "r1.png"));
                        btnLocker1.Enabled = false;
                    }
                    else if (btnLocker2.Text == lockerNo)
                    {
                        btnLocker2.BackgroundImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LockerImages", "r2.png"));
                        btnLocker2.Enabled = false;
                    }
                    else if (btnLocker3.Text == lockerNo)
                    {
                        btnLocker3.BackgroundImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LockerImages", "r3.png"));
                        btnLocker3.Enabled = false;
                    }
                    else if (btnLocker4.Text == lockerNo)
                    {
                        btnLocker4.BackgroundImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LockerImages", "r4.png"));
                        btnLocker4.Enabled = false;
                    }
                }
            }
            this.Enabled = true;
            btnHome.Enabled = true;
        }
        private void SetAllButtonsToGreen()
        {
            btnLocker1.BackgroundImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LockerImages", "g1.png"));
            btnLocker2.BackgroundImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LockerImages", "g2.png"));
            btnLocker3.BackgroundImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LockerImages", "g3.png"));
            btnLocker4.BackgroundImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LockerImages", "g4.png"));
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Home obj = new Home();
            obj.Show();
            Application.DoEvents();
            this.Dispose();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ScanShippingNoteNo obj = new ScanShippingNoteNo();
            obj.Show();
            Application.DoEvents();
            this.Dispose();
        }

        private void btnLocker1_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                BtnText = button.Text;
                BtnName = button.Name;
                LockerAssign();
            }

        }
        private void LockerAssign()
        {
            SetAllButtonsToGreen();

            // Set the selected button to blue
            if (BtnName == "btnLocker1")
            {
                btnLocker1.BackgroundImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LockerImages", "b1.png"));
                LOCKERNO = "1";
            }
            else if (BtnName == "btnLocker2")
            {
                btnLocker2.BackgroundImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LockerImages", "b2.png"));
                LOCKERNO = "2";
            }
            else if (BtnName == "btnLocker3")
            {
                btnLocker3.BackgroundImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LockerImages", "b3.png"));
                LOCKERNO = "3";
            }
            else if (BtnName == "btnLocker4")
            {
                btnLocker4.BackgroundImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LockerImages", "b4.png"));
                LOCKERNO = "4";
            }

            LOCKER.Clear();
            LOCKER.Add(BtnName);
            btnOpen.Visible = true;
        }
    }
}
