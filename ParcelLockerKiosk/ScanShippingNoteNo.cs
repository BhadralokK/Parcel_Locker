using ParcelLockerKiosk.Modulus;
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

namespace ParcelLockerKiosk
{
    public partial class ScanShippingNoteNo : Form
    {
        public ScanShippingNoteNo()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
        }
       

        private void btnNext_Click(object sender, EventArgs e)
        {
            SelectDropLocker obj = new SelectDropLocker();
            obj.Show();
            Application.DoEvents();
            this.Dispose();
        }

        private void ScanShippingNoteNo_Load(object sender, EventArgs e)
        {

            axVLCPlugin21.playlist.items.clear();

            //string VideoLocation = @"D:\LatestProject\ParcelLockerKiosk\ParcelLockerKiosk\Video";
            string videoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LockerImages", "SnapSave.io-QR Scanner Animation.mp4");
            var uri = new Uri(videoPath);
            var convertedURI = uri.AbsoluteUri;
            axVLCPlugin21.playlist.add(convertedURI);
            axVLCPlugin21.playlist.play();

            label3.Text = "Shipper Name:-";
            label8.Text =  Variables.Shippername;
            label4.Text = "Shipper Address:-";
            label9.Text =  Variables.ShipperAddress;
            label6.Text = "Consignee Name:-";
            label10.Text =  Variables.ConsigneeName;
            label5.Text = "Consignee Address:-"; 
            label11.Text =  Variables.ConsigneeAddress;
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
            ShippingNoteNo obj = new ShippingNoteNo();
            obj.Show();
            Application.DoEvents();
            this.Dispose();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
