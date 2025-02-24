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

namespace ParcelLockerKiosk.ADMIN
{
    public partial class ShippingDetails : Form
    {
        public ShippingDetails()
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
        private void LoadShipDetails()
        {
            ModFUNCTIONS.fetch("SELECT *FROM ShippingDetails order by Shipping_Id desc", Dbconnect.ds1);
            dataGridView1.Rows.Clear();
            for (var k = 0; k <= Dbconnect.ds1.Tables[0].Rows.Count - 1; k++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[k].Cells[0].Value = k + 1;

                dataGridView1.Rows[k].Cells[1].Value = Dbconnect.ds1.Tables[0].Rows[k]["Ship_No"].ToString();
                dataGridView1.Rows[k].Cells[2].Value = Dbconnect.ds1.Tables[0].Rows[k]["Ship_Name"].ToString();
                dataGridView1.Rows[k].Cells[3].Value = Dbconnect.ds1.Tables[0].Rows[k]["Ship_Address"];
                dataGridView1.Rows[k].Cells[4].Value = Dbconnect.ds1.Tables[0].Rows[k]["Consignee_Name"];
                dataGridView1.Rows[k].Cells[5].Value = Dbconnect.ds1.Tables[0].Rows[k]["Consignee_Address"];
                dataGridView1.Rows[k].Cells[6].Value = Dbconnect.ds1.Tables[0].Rows[k]["Shipping_Id"];
                //dataGridView1.Rows[k].Cells[6].Value = Dbconnect.ds1.Tables[0].Rows[k]["Emp_Photo"];
                //dataGridView1.Rows[k].Cells[3].Value = Dbconnect.ds1.Tables[0].Rows[k]["Emp_EmailID"];
                //dataGridView1.RowTemplate.Height = 60;
                //dataGridView1.Rows[k].Cells[4].Value = Dbconnect.ds1.Tables[0].Rows[k]["ItemGroupId"].ToString();
            }
        }
        public void CLEAR()
        {
            
            ShpNoTxt.Text = "";
            ShpNameTxt.Text = "";
            SprAddreTxt.Text = "";
            ConNameTxt.Text = "";
            ConAddTxt.Text = "";
            SaveBn.Text = "SAVE";
        }

        private void SaveBn_Click(object sender, EventArgs e)
        {
            if (SaveBn.Text == "SAVE")
            {


                if (ShpNoTxt.Text == "")
                {
                    MessageBox.Show("Enter Item Name!");
                }
                else if (ShpNameTxt.Text == "")
                {
                    MessageBox.Show(" Enter the Item Discription! ");
                }

                else
                {
                    try
                    {
                        ModFUNCTIONS.fetch("select Shipping_Id from ShippingDetails order by Shipping_Id desc", Dbconnect.ds1);
                        if (Dbconnect.ds1.Tables[0].Rows.Count != 0)
                        {
                            Variables.Shp_id = Convert.ToInt32(Dbconnect.ds1.Tables[0].Rows[0][0]) + 1;

                        }

                        else
                        {
                            Variables.Shp_id = 1;
                        }

                        //DateTime.Now.ToString("dd/MMM/yyyy HH:mm")

                        ModFUNCTIONS.dml_statement("Insert INTO ShippingDetails (Shipping_Id,Ship_No,Ship_Name,Ship_Address,Consignee_Name,Consignee_Address) VALUES (" + Variables.Shp_id + ",'" + ShpNoTxt.Text + "','" + ShpNameTxt.Text + "','" + SprAddreTxt.Text + "','" + ConNameTxt.Text + "','" + ConAddTxt.Text + "')");
                        MessageBox.Show(" Added sucessfully! ");
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Error inserting the items! " + ex.Message);
                    }
                    LoadShipDetails();
                    
                }
            }
            else 
            {
                try
                {
                    ModFUNCTIONS.dml_statement("Update ShippingDetails set Ship_No='" + ShpNoTxt.Text + "',Ship_Name ='" + ShpNameTxt.Text + "',Ship_Address='" + SprAddreTxt.Text + "',Consignee_Name = '" + ConNameTxt.Text + "',Consignee_Address='" + ConAddTxt.Text + "' where Shipping_Id ='" + IdText.Text + "' ");
                    //ImageSave(Convert.ToInt32(idTxt.Text));
                    MessageBox.Show("Updated successfully :)");

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error updating the items!!" + ex.Message);
                }
               
                LoadShipDetails();
                CLEAR();
            
            }
        }
       
      

        private void ShippingDetails_Load(object sender, EventArgs e)
        {
            Dbconnect.main();
            LoadShipDetails();
        }

        private void eDITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShpNoTxt.Text = dataGridView1.CurrentRow.Cells["ShippingNumber"].Value.ToString();
            ShpNameTxt.Text = dataGridView1.CurrentRow.Cells["ShipperName"].Value.ToString();
            SprAddreTxt.Text = dataGridView1.CurrentRow.Cells["ShipperAddress"].Value.ToString();
            ConNameTxt.Text = dataGridView1.CurrentRow.Cells["ConsigneeName"].Value.ToString();
            ConAddTxt.Text = dataGridView1.CurrentRow.Cells["ConsigneeAddress"].Value.ToString();
            IdText.Text = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
            //pictur.ExpiryDate = dataGridView1.CurrentRow.Cells["BatchNo"].Value.ToString();
            //byte[] pictureBox1 = (byte[])dataGridView1.CurrentRow.Cells["Photo"].Value;

            SaveBn.Text = "UPDATE";
        }

        private void dELETEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are You sure you want to delete this record", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                IdText.Text = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
                ModFUNCTIONS.dml_statement("Delete from ShippingDetails where Shipping_Id = '" + IdText.Text + "'");
                MessageBox.Show("Deleted successfully from the database!");
                LoadShipDetails();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminPanel obj = new AdminPanel();
            obj.Show();
           
            Application.DoEvents();
            this.Hide();

           
        }
    }
}
