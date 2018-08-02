using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Text;
using System.Data;
using System.Web.Script.Serialization;
using System.Collections;
namespace ManhattanMap
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public static int RRCount;
        public static int RVCount;
        public string[] Request1X = new string[23];
        public string[] Request1Y = new string[23];
        public string[] Request2X = new string[23];
        public string[] Request2Y = new string[23];


        public string[] VehicleX = new string[30];
        public string[] VehicleY = new string[30];
        public string[] RequestX = new string[30];
        public string[] RequestY = new string[30];

        public SqlConnection baglanti = new SqlConnection(@"Data Source=.;Initial Catalog=RideSharing_coordinates;Integrated Security=True;Connect Timeout=30");

        public void DbRequestRequest()
        {
                baglanti.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter("Select * from RequestRequestMatch", baglanti);
                sda.Fill(dt);
                //SqlDataAdapter sda1 = new SqlDataAdapter("Select TOP '"+txtDataCor.Text+"' * from RequestRequestMatch", baglanti);
                //sda1.Fill(dt);
                
            //Request1 için verileri diziye aktarma
            foreach (DataRow row in dt.Rows)
            {
                ListBoxRX1.Items.Add(row["Request1X"].ToString());
            }


            for (int i = 0; i < Request1X.Length; i++)
            {
                Request1X[i] = ListBoxRX1.Items[i].ToString();
            }

            foreach (DataRow row in dt.Rows)
            {
                ListBoxRY1.Items.Add(row["Request1Y"].ToString());
            }
            for (int i = 0; i < Request1Y.Length; i++)
            {
                Request1Y[i] = ListBoxRY1.Items[i].ToString();
            }
            //Request2 için verileri diziye aktarma
            foreach (DataRow row in dt.Rows)
            {
                ListBoxRX2.Items.Add(row["Request2X"].ToString());
            }
            for (int i = 0; i < Request2X.Length; i++)
            {
                Request2X[i] = ListBoxRX2.Items[i].ToString();
            }
            foreach (DataRow row in dt.Rows)
            {
                ListBoxRY2.Items.Add(row["Request2Y"].ToString());
            }
            for (int i = 0; i < Request2Y.Length; i++)
            {
                Request2Y[i] = ListBoxRY2.Items[i].ToString();
            }
            baglanti.Close();
        }
        public void DbRequestVehicle()
        {
            
            baglanti.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select * from VehicleRequestMatch", baglanti);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                ListBoxVX.Items.Add(row["VehicleX"].ToString());
            }
            for (int i = 0; i < Request1X.Length; i++)
            {
                VehicleX[i] = ListBoxVX.Items[i].ToString();
            }

            foreach (DataRow row in dt.Rows)
            {
                ListBoxVY.Items.Add(row["VehicleY"].ToString());
            }
            for (int i = 0; i < Request1X.Length; i++)
            {
                VehicleY[i] = ListBoxVY.Items[i].ToString();
            }

            foreach (DataRow row in dt.Rows)
            {
                ListBoxRX.Items.Add(row["RequestX"].ToString());
            }
            for (int i = 0; i < Request1X.Length; i++)
            {
                RequestX[i] = ListBoxRX.Items[i].ToString();
            }

            foreach (DataRow row in dt.Rows)
            {
                ListBoxRY.Items.Add(row["RequestY"].ToString());
            }
            for (int i = 0; i < Request1X.Length; i++)
            {
                RequestY[i] = ListBoxRY.Items[i].ToString();
            }

            baglanti.Close();
        }



        #region Get Request-Vehicle Array
        public string getVehicleXArray()
        {
            return (new JavaScriptSerializer().Serialize(VehicleX));
        }
        public string getVehicleYArray()
        {
            return (new JavaScriptSerializer().Serialize(VehicleY));
        }
        public string getRequestXArray()
        {
            return (new JavaScriptSerializer().Serialize(RequestX));
        }
        public string getRequestYArray()
        {
            return (new JavaScriptSerializer().Serialize(RequestY));
        }
        #endregion
        #region Get Request-Request Array
        public string getRequest1XArray()
        {
            return (new JavaScriptSerializer().Serialize(Request1X));
        }
        public string getRequest1YArray()
        {
            return (new JavaScriptSerializer().Serialize(Request1Y));
        }
        public string getRequest2XArray()
        {
            return (new JavaScriptSerializer().Serialize(Request2X));
        }
        public string getRequest2YArray()
        {
            return (new JavaScriptSerializer().Serialize(Request2Y));
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            DbRequestRequest();
            DbRequestVehicle();
        }
        
    }
}