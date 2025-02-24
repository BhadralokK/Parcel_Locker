using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParcelLockerKiosk.PICKUP
{
    public partial class ScanShippingNoteNo : Form
    {
        public ScanShippingNoteNo()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
        }
       
        private void ScanShippingNoteNo_Load(object sender, EventArgs e)
        {
            axVLCPlugin21.playlist.items.clear();

            string videoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LockerImages", "SnapSave.io-QR Scanner Animation.mp4");

            var uri = new Uri(videoPath);
            var convertedURI = uri.AbsoluteUri;
            axVLCPlugin21.playlist.add(convertedURI);
            axVLCPlugin21.playlist.play();
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            OTPVerification obj = new OTPVerification();
            obj.Show();
            Application.DoEvents();
            this.Dispose();
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
            SearchShippingNoteNo obj = new SearchShippingNoteNo();
            obj.Show();
            Application.DoEvents();
            this.Dispose();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
