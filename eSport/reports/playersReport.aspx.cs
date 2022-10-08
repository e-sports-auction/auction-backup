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


namespace eSport.reports
{
    public partial class playersReport : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            //clear_labels();
            loadTeam();
        }

        private void loadTeam()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            //select command
            string status = Request.QueryString["player"].ToString();
            int id = 0;
            if(status== "accepted") { id = 1; }
            if (status == "decline") { id = 2; }


            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"select * from player where Status='" + id + "'";
            cmd.ExecuteNonQuery();

            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dl_auctionList.DataSource = dt;
            dl_auctionList.DataBind();

        }
    }
}