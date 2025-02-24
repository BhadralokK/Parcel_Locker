using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace ParcelLockerKiosk.Modulus
{
    public class ModFUNCTIONS
    {
        Dbconnect dbcon = new Dbconnect();
        private static TextBox txttext = new TextBox();
        public static string clk;

        public static void cmbclick(ComboBox sender, System.EventArgs e)
        {
            if (clk != "1")
            {
                if (sender.Height == 170)
                {
                    sender.Height = 40;
                    return;
                }
                else if (sender.Height == 40)
                {
                    sender.Height = 170;
                    return;
                }
            }
            else
            {
                sender.Height = 170;
                clk = clk + 1;
                return;
            }
        }

        //public static void num(System.Windows.Forms.KeyPressEventArgs e)
        //{
        //    short keyascii = Asc(e.KeyChar);
        //    if (keyascii >= 48 & keyascii <= 57)
        //        keyascii = keyascii - keyascii;
        //    else if (keyascii == 8)
        //        keyascii = keyascii;
        //    else
        //        e.KeyChar = "";
        //}

        //public static void num1(System.Windows.Forms.KeyPressEventArgs e)
        //{
        //    short keyascii = Asc(e.KeyChar);
        //    if (keyascii == 43 | keyascii == 45 | keyascii >= 48 & keyascii <= 57)
        //        keyascii = keyascii - keyascii;
        //    else if (keyascii == 8)
        //        keyascii = keyascii;
        //    else
        //        e.KeyChar = "";
        //}

        //public static void num2(System.Windows.Forms.KeyPressEventArgs e)
        //{
        //    short keyascii = Asc(e.KeyChar);
        //    if (keyascii >= 48 & keyascii <= 57)
        //    {
        //        txln = (txttext.Text).Length;
        //        crg = InStr(1, txttext.Text, ".");
        //        if (crg == 0)
        //        {
        //        }
        //        else if (txln > crg + 2)
        //            keyascii = keyascii - keyascii;
        //    }
        //    else if (keyascii == 46)
        //    {
        //        crg = InStr(1, txttext.Text, ".");
        //        if (crg >= 1)
        //            keyascii = keyascii - keyascii;
        //    }
        //    else if (keyascii == 8)
        //    {
        //    }
        //    else
        //        keyascii = keyascii - keyascii;
        //    e.KeyChar = Chr(keyascii);
        //    if (keyascii == 0)
        //        e.Handled = true;
        //}

        //public void key(object sender, System.Windows.Forms.KeyPressEventArgs e)
        //{
        //    short keyascii = Strings.Asc(e.KeyChar);
        //    if (keyascii == 13)
        //    {
        //        e.Handled = true;
        //        sender.Focus();
        //    }
        //}

        //public static void key(object sender, System.Windows.Forms.KeyPressEventArgs e)
        //{
        //    short keyascii = Asc(e.KeyChar);
        //    if (keyascii == 13)
        //    {
        //        e.Handled = true;
        //        sender.Focus();
        //    }
        //}

        public static void populate(ComboBox comb, string str)
        {
            clk = "1";
            string txt = comb.Text;
            comb.Items.Clear();
            fetch(str, Dbconnect.ds10);
            if (Dbconnect.ds10.Tables[0].Rows.Count != 0)
            {
                var loopTo = Dbconnect.ds10.Tables[0].Rows.Count - 1;
                for (var k = 0; k <= loopTo; k++)
                    comb.Items.Add((Dbconnect.ds10.Tables[0].Rows[k][0].ToString()).ToUpper());
            }
            comb.Text = txt;
        }


        public static void valid(ComboBox cmb, string str, string stri)  // For simple validation
        {
            if (cmb.Text != "")
            {
                fetch(str, Dbconnect.ds10);
                if (Dbconnect.ds10.Tables[0].Rows.Count == 0)
                {
                    cmb.Focus();
                    MessageBox.Show(stri, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmb.Text = "";
                }
            }
        }

        public static void vdated(TextBox txt, string str)  // For simple validated
        {
            fetch(str, Dbconnect.ds10);
            if (Dbconnect.ds10.Tables[0].Rows.Count != 0)
                txt.Text = Dbconnect.ds10.Tables[0].Rows[0][0].ToString();
            else
                txt.Text = "";
        }


        public static void Oledbfetch(string query, DataSet ds) // for checking the data
        {
            ds.Tables.Clear();
            Dbconnect.OledbStart1();
            Dbconnect.Oledbda1 = new OleDbDataAdapter(query, Dbconnect.OledbCon1);
            Dbconnect.Oledbda1.Fill(ds);
            Dbconnect.OledbClose1();
        }

        public static void Oledbfetch3(string query, DataSet ds) // for checking the data
        {
            ds.Tables.Clear();
            Dbconnect.OledbStart3();
            Dbconnect.Oledbda1 = new OleDbDataAdapter(query, Dbconnect.OledbCon3);
            Dbconnect.Oledbda1.Fill(ds);
            Dbconnect.OledbClose3();
        }
        public static void fetch(string query, DataSet ds) // for checking the data
        {
            ds.Tables.Clear();
            Dbconnect.Start10();
            Dbconnect.da10 = new SqlDataAdapter(query, Dbconnect.con10);
            Dbconnect.da10.Fill(ds);
            Dbconnect.Close10();
        }

        public static void grdv(string query, DataGridView g1)
        {
            fetch(query, Dbconnect.ds10);
            g1.DataSource = Dbconnect.ds1.Tables[0];
        }

        public static void Oledbdml_statement(string query_cmd)
        {
            Dbconnect.OledbStart1();
            Dbconnect.Oledbcmd1 = new OleDbCommand(query_cmd, Dbconnect.OledbCon1);
            Dbconnect.Oledbcmd1.ExecuteNonQuery();
            Dbconnect.OledbClose1();
        }

        public static void dml_statement(string query_cmd)
        {
            Dbconnect.Start10();
            Dbconnect.cmd10 = new SqlCommand(query_cmd, Dbconnect.con10);
            Dbconnect.cmd10.ExecuteNonQuery();
            Dbconnect.Close10();
        }

        
    }
}
