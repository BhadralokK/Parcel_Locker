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
using Microsoft.VisualBasic.CompilerServices;
using System.Windows.Forms;




namespace ParcelLockerKiosk.ADMIN
{
    public partial class EmployeeRegistration : Form
    {
        public EmployeeRegistration()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();

           
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
  
        private void LoadEmployee()
        {
            ModFUNCTIONS.fetch("SELECT *FROM EmployeeMaster order by Emp_id desc", Dbconnect.ds1);
            dataGridView1.Rows.Clear();
            for (var k = 0; k <= Dbconnect.ds1.Tables[0].Rows.Count - 1; k++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[k].Cells[0].Value = k + 1;

                dataGridView1.Rows[k].Cells[1].Value = Dbconnect.ds1.Tables[0].Rows[k]["Emp_Name"].ToString();
                dataGridView1.Rows[k].Cells[2].Value = Dbconnect.ds1.Tables[0].Rows[k]["Emp_Gender"].ToString();
                dataGridView1.Rows[k].Cells[3].Value = Dbconnect.ds1.Tables[0].Rows[k]["Emp_EmailID"];
                dataGridView1.Rows[k].Cells[4].Value = Dbconnect.ds1.Tables[0].Rows[k]["Emp_Designation"];
                dataGridView1.Rows[k].Cells[5].Value = Dbconnect.ds1.Tables[0].Rows[k]["Mobile"];
                dataGridView1.Rows[k].Cells[6].Value = Dbconnect.ds1.Tables[0].Rows[k]["Emp_Photo"];
                dataGridView1.Rows[k].Cells[7].Value = Dbconnect.ds1.Tables[0].Rows[k]["Emp_id"];
                //dataGridView1.Rows[k].Cells[3].Value = Dbconnect.ds1.Tables[0].Rows[k]["Emp_EmailID"];
                //dataGridView1.RowTemplate.Height = 60;
                //dataGridView1.Rows[k].Cells[4].Value = Dbconnect.ds1.Tables[0].Rows[k]["ItemGroupId"].ToString();
            }
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (SaveBtn.Text == "SAVE")
            {
                if (pictureBox1.Image == null)
                {
                    MessageBox.Show("Please Select An Image ");
                    return;
                }
                byte[] image;
                using (MemoryStream ms = new MemoryStream())
                {
                    pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                    image = ms.ToArray();
                }
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Enter Item Name!");
                }
                else if (textBox2.Text == "")
                {
                    MessageBox.Show(" Enter the Item Discription! ");
                }

                else
                {
                    try
                    {
                        ModFUNCTIONS.fetch("select Emp_id from EmployeeMaster order by Emp_id desc", Dbconnect.ds1);
                        if (Dbconnect.ds1.Tables[0].Rows.Count != 0)
                        {
                            Variables.Emp_Id = Convert.ToInt32(Dbconnect.ds1.Tables[0].Rows[0][0]) + 1;

                        }

                        else
                        {
                            Variables.Emp_Id = 1;
                        }

                        //DateTime.Now.ToString("dd/MMM/yyyy HH:mm")

                        ModFUNCTIONS.dml_statement("Insert INTO EmployeeMaster (Emp_id,Emp_Name,Emp_Gender,Emp_EmailID,Emp_Designation,Emp_Photo,Mobile) VALUES (" + Variables.Emp_Id + ",'" + textBox1.Text + "','" + comboBox1.SelectedItem + "','" + textBox2.Text + "','" + textBox3.Text + "','" + pictureBox1.Image + "','" + textBox4.Text + "')");
                        MessageBox.Show(" Added sucessfully! ");
                        ImageSave(Variables.Emp_Id);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error inserting the items! " + ex.Message);

                    }
                }
                LoadEmployee();
            }
            else 
            {
                try
                {
                    ModFUNCTIONS.dml_statement("Update EmployeeMaster set Emp_Name='" + textBox1.Text + "',Emp_Gender ='" + comboBox1.SelectedItem + "',Emp_EmailID = '" + textBox2.Text + "',Emp_Designation='" + textBox3.Text + "',Emp_Photo='" + pictureBox1.Image + "',Mobile='" + textBox4.Text + "' where Emp_id ='" + IdText.Text + "' ");
                    ImageSave(Convert.ToInt32(IdText.Text));
                    MessageBox.Show("Updated successfully :)");

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error updating the items!!" + ex.Message);
                }
                LoadEmployee();
                CLEAR();
            
            }
        }
        private void ImageSave(int sl)
        {
            if (!(pictureBox1.Image == null))
            {
                Dbconnect.cmd1 = new SqlCommand("UPDATE EmployeeMaster SET Emp_Photo=@Photo WHERE Emp_id='" + sl + "'", Dbconnect.con1);
                MemoryStream ms1 = new MemoryStream();
                pictureBox1.Image.Save(ms1, ImageFormat.Png);
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
        }

        private void BrowseBtn_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                textBox5.Text = openFileDialog1.FileName;
                Image i = new Bitmap(textBox5.Text);
                pictureBox1.Image = i;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void EmployeeRegistration_Load(object sender, EventArgs e)
        {
            Dbconnect.main();
            LoadEmployee();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShippingDetails obj = new ShippingDetails();
            obj.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void CLEAR()
        {
            comboBox1.SelectedIndex = -1;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            pictureBox1.Image = null;
            SaveBtn.Text = "SAVE";
        }

        private void eDITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["Emp_name"].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells["Emp_gender"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["Emp_EmialID"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["Emp_designation"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["Mobile"].Value.ToString();
            //pictur.ExpiryDate = dataGridView1.CurrentRow.Cells["BatchNo"].Value.ToString();
            byte[] image = (byte[])dataGridView1.CurrentRow.Cells["Emp_photo"].Value;
            if (image != null)
            {

                using (MemoryStream ms = new MemoryStream(image))
                {
                    pictureBox1.Image = System.Drawing.Image.FromStream(ms);
                }
            }
            else
            {

                pictureBox1.Image = null;
            }
            IdText.Text = dataGridView1.CurrentRow.Cells["Emp_id"].Value.ToString();
            SaveBtn.Text = "UPDATE";
        }

        private void dELETEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are You sure you want to delete this record", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                IdText.Text = dataGridView1.CurrentRow.Cells["Emp_id"].Value.ToString();
                ModFUNCTIONS.dml_statement("Delete from EmployeeMaster where Emp_id = '" + IdText.Text + "'");
                MessageBox.Show("Deleted successfully from the database!");
                LoadEmployee();

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
          
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            AdminPanel obj = new AdminPanel();
            obj.Show();
            this.Hide();
            Application.DoEvents();
        }
    }
}
