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
    public partial class soldAndunsold_players : System.Web.UI.Page
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
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"select player.FirstName, player.LastName, player.Image, auction.Team, auction.SoldPrice, auction.AuctionStatus 
                                from player inner join auction on player.PlayerID=auction.PlayerID  where auction.TrophyID='" + id + "'and AuctionStatus <>'pending'";
            cmd.ExecuteNonQuery();

            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dl_auctionList.DataSource = dt;
            dl_auctionList.DataBind();

        }
    }
}