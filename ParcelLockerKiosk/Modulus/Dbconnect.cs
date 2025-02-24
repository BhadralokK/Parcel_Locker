using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Data.OleDb;
using System.Threading;
using System.Net;
using System.Configuration;


namespace ParcelLockerKiosk.Modulus
{
    public class Dbconnect
    {
        public static OleDbConnection OledbCon1 = new OleDbConnection();
        public static OleDbConnection OledbCon2 = new OleDbConnection();
        public static OleDbConnection OledbCon3 = new OleDbConnection();
        public static SqlConnection con1 = new SqlConnection();
        public static SqlConnection con2 = new SqlConnection();
        public static SqlConnection con3 = new SqlConnection();
        public static SqlConnection con4 = new SqlConnection();
        public static SqlConnection con5 = new SqlConnection();
        public static SqlConnection con6 = new SqlConnection();
        public static SqlConnection con10 = new SqlConnection();
        public static SqlConnection con11 = new SqlConnection();
        public static SqlConnection con12 = new SqlConnection();

        public static OleDbCommand Oledbcmd1 = new OleDbCommand();
        public static SqlCommand cmd1 = new SqlCommand();
        public static SqlCommand cmd2 = new SqlCommand();
        public static SqlCommand cmd3 = new SqlCommand();
        public static SqlCommand cmd4 = new SqlCommand();
        public static SqlCommand cmd10 = new SqlCommand();
        public static SqlCommand cmd11 = new SqlCommand();
        public static SqlCommand cmd12 = new SqlCommand();

        public static OleDbDataAdapter Oledbda1 = new OleDbDataAdapter();
        public static OleDbConnection Oledbda2 = new OleDbConnection();
        public static SqlDataAdapter da1 = new SqlDataAdapter();
        public static SqlDataAdapter da2 = new SqlDataAdapter();
        public static SqlDataAdapter da3 = new SqlDataAdapter();
        public static SqlDataAdapter da4 = new SqlDataAdapter();
        public static SqlDataAdapter da5 = new SqlDataAdapter();
        public static SqlDataAdapter da6 = new SqlDataAdapter();
        public static SqlDataAdapter da10 = new SqlDataAdapter();
        public static SqlDataAdapter da11 = new SqlDataAdapter();
        public static SqlDataAdapter da12 = new SqlDataAdapter();

        public static DataSet ds1 = new DataSet();
        public static DataSet ds2 = new DataSet();
        public static DataSet ds3 = new DataSet();
        public static DataSet ds4 = new DataSet();
        public static DataSet ds5 = new DataSet();
        public static DataSet ds6 = new DataSet();
        public static DataSet ds10 = new DataSet();
        public static DataSet ds11 = new DataSet();
        public static DataSet ds12 = new DataSet();
        public static DataSet ds13 = new DataSet();
        public static DataSet ds14 = new DataSet();

        public static DataSet ds15 = new DataSet();
        public static DataSet ds16 = new DataSet();

        public static StreamReader objStreamReader;
        public static StreamReader objStreamReader2;

        public static string strLine;
        public static string strLine2;

        public static string constr;
        public static string constring;

        public static string SrvName;
        public static string DbName;
        public static string UserID;
        public static string Pass;
        public static string Port;


        public static void main()
        {

            SrvName = ConfigurationManager.AppSettings["SrvName"];
            DbName = ConfigurationManager.AppSettings["DbName"];
            UserID = ConfigurationManager.AppSettings["UserId"];
            Pass = ConfigurationManager.AppSettings["Pass"];
            Port = ConfigurationManager.AppSettings["Port"];

            constring = "Data Source='" + SrvName + "';Initial Catalog='" + DbName + "';User Id='" + UserID + "';Password='" + Pass + "';";
            if (constring != "")
            {
                con1 = new SqlConnection(constring);
                con2 = new SqlConnection(constring);
                con3 = new SqlConnection(constring);
                con4 = new SqlConnection(constring);
                con5 = new SqlConnection(constring);
                con6 = new SqlConnection(constring);
                con10 = new SqlConnection(constring);
                con11 = new SqlConnection(constring);
                con12 = new SqlConnection(constring);
            }
        }

        public static void OledbStart1()
        {
            if (OledbCon1.State == ConnectionState.Open)
                OledbCon1.Close();
            OledbCon1.Open();
        }
        public static void OledbStart2()
        {
            if (OledbCon2.State == ConnectionState.Open)
                OledbCon2.Close();
            OledbCon2.Open();
        }
        public static void OledbStart3()
        {
            if (OledbCon3.State == ConnectionState.Open)
                OledbCon3.Close();
            OledbCon3.Open();
        }

        public static void Start1()
        {
            if (con1.State == ConnectionState.Open)
                con1.Close();
            con1.Open();
        }

        public static void Start2()
        {
            if (con2.State == ConnectionState.Open)
                con2.Close();
            con2.Open();
        }

        public static void Start3()
        {
            if (con3.State == ConnectionState.Open)
                con3.Close();
            con3.Open();
        }


        public static void Start4()
        {
            if (con4.State == ConnectionState.Open)
                con4.Close();
            con4.Open();
        }
        public static void Start5()
        {
            if (con5.State == ConnectionState.Open)
                con5.Close();
            con5.Open();
        }

        public static void Start6()
        {
            if (con6.State == ConnectionState.Open)
                con6.Close();
            con6.Open();
        }

        public static void Start10()
        {
            if (con10.State == ConnectionState.Open)
                con10.Close();
            con10.Open();
        }

        public static void Start11()
        {
            if (con11.State == ConnectionState.Open)
                con11.Close();
            con11.Open();
        }

        public static void Start12()
        {
            if (con12.State == ConnectionState.Open)
                con12.Close();
            con12.Open();
        }

        public static void OledbClose1()
        {
            if (OledbCon1.State == ConnectionState.Open)
                OledbCon1.Close();
        }

        public static void OledbClose3()
        {
            if (OledbCon3.State == ConnectionState.Open)
                OledbCon3.Close();
        }
        public static void OledbClose2()
        {
            if (OledbCon2.State == ConnectionState.Open)
                OledbCon2.Close();
        }

        public static void Close1()
        {
            if (con1.State == ConnectionState.Open)
                con1.Close();
        }

        public static void Close2()
        {
            if (con2.State == ConnectionState.Open)
                con2.Close();
        }

        public static void Close3()
        {
            if (con3.State == ConnectionState.Open)
                con3.Close();
        }

        public static void Close4()
        {
            if (con4.State == ConnectionState.Open)
                con4.Close();
        }

        public static void Close5()
        {
            if (con5.State == ConnectionState.Open)
                con5.Close();
        }

        public static void Close6()
        {
            if (con6.State == ConnectionState.Open)
                con6.Close();
        }

        public static void Close10()
        {
            if (con10.State == ConnectionState.Open)
                con10.Close();
        }

        public static void Close11()
        {
            if (con11.State == ConnectionState.Open)
                con11.Close();
        }

        public static void Close12()
        {
            if (con12.State == ConnectionState.Open)
                con12.Close();
        }



    }       
}
