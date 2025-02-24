﻿using AForge.Video;
using AForge.Video.DirectShow;
using Microsoft.VisualBasic.CompilerServices;
using ParcelLockerKiosk.Modulus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParcelLockerKiosk.PICKUP
{
    public partial class CustomerPhotoWithIdCard : Form
    {
        private VideoCaptureDevice VideoCapture;
        FilterInfoCollection filterInfo;

        public CustomerPhotoWithIdCard()
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

        private void CustomerPhotoWithIdCard_Load(object sender, EventArgs e)
        {
            startCamera();
        }
        private void CameraOn(object sender, NewFrameEventArgs eventArgs)
        {
            picCapture.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void startCamera()
        {
            try
            {
                filterInfo = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                VideoCapture = new VideoCaptureDevice(filterInfo[0].MonikerString);
                VideoCapture.NewFrame += new NewFrameEventHandler(CameraOn);
                VideoCapture.Start();
            }
            catch (Exception e)
            {
            }
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (!(picCapture.Image == null))
            {
                Dbconnect.cmd1 = new SqlCommand("UPDATE LockerTransaction SET Pickuppackage_emp_Image=@Photo WHERE Emp_id='" + Variables.Id + "'", Dbconnect.con1);
                MemoryStream ms1 = new MemoryStream();
                picCapture.Image.Save(ms1, ImageFormat.Png);
                byte[] bytblobdata1 = new byte[Conversions.ToInteger(ms1.Length - (long)1) + 1];
                ms1.Position = 0;
                ms1.Read(bytblobdata1, 0, Conversions.ToInteger(ms1.Length));
                SqlParameter prm1 = new SqlParameter("@Photo", SqlDbType.VarBinary, bytblobdata1.Length, ParameterDirection.Input, false, 0, 0, null/* TODO Change to default(_) if this is not a reference type */, DataRowVersion.Current, bytblobdata1);
                Dbconnect.cmd1.Parameters.Add(prm1);
                Dbconnect.con1.Close();
                Dbconnect.con1.Open();
                Dbconnect.cmd1.ExecuteNonQuery();
                Dbconnect.con1.Close();
            }




            CollectParcel obj = new CollectParcel();
            obj.Show();
            Application.DoEvents();
            this.Dispose();


            StopCamera();


        }
        private void StopCamera()
        {
            if (VideoCapture != null && VideoCapture.IsRunning)
            {
                VideoCapture.SignalToStop();
                VideoCapture.WaitForStop();
                VideoCapture = null;
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
            VerifyCustomerDetails obj = new VerifyCustomerDetails();
            obj.Show();
            Application.DoEvents();
            this.Dispose();
        }
    }
}
