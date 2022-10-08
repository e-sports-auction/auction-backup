using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;
using System.Diagnostics.Contracts;
using System.IO;
using System.Drawing.Imaging;

namespace eSport
{
    public partial class admin : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            getCount();
        }

        private void getCount()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            SqlCommand Com1 = new SqlCommand("select count(*) from player where Status=1", con);
            SqlDataReader DR2 = Com1.ExecuteReader();
            if (DR2.Read())
            {
                lb_playerCount.Text = DR2.GetValue(0).ToString();
            }
            DR2.Close();

            SqlCommand Com = new SqlCommand("select count(TrophyID) from trophy", con);
            SqlDataReader DR1 = Com.ExecuteReader();
            if (DR1.Read())
            {
                lb_trophtCount.Text = DR1.GetValue(0).ToString();
            }
            DR1.Close();

         

            SqlCommand Com2 = new SqlCommand("select count(*) from owner", con);
            SqlDataReader DR3 = Com2.ExecuteReader();
            if (DR3.Read())
            {
                lb_ownerCount.Text = DR3.GetValue(0).ToString();
            }
            DR3.Close();

            SqlCommand Com3 = new SqlCommand("select count(*) from team", con);
            SqlDataReader DR4 = Com3.ExecuteReader();
            if (DR4.Read())
            {
                lb_teamCount.Text = DR4.GetValue(0).ToString();
            }
            DR4.Close();

            SqlCommand Com4 = new SqlCommand("select count(*) from player where Status=0", con);
            SqlDataReader DR5 = Com4.ExecuteReader();
            if (DR5.Read())
            {
                lb_pendingPlayerCount.Text = DR5.GetValue(0).ToString();
            }
            DR5.Close();
        }
    }
}