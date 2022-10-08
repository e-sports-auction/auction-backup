using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace eSport
{
    public partial class viewTrophy : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            loadPlayer();

            
        }

        private void loadPlayer()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            //select command

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from trophy";
            cmd.ExecuteNonQuery();

            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dtl_player.DataSource = dt;
            dtl_player.DataBind();

        }

        protected void btn_applyTrophy_Click(object sender, EventArgs e)
        {

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            string email = Session["email"].ToString();

            string TrophyID = ((Button)sender).CommandArgument.ToString();
            int trophyID = int.Parse(TrophyID);

            int playerID=0;
            SqlCommand Com = new SqlCommand("select PlayerID from player where Email='" + email + "'", con);
            SqlDataReader DR1 = Com.ExecuteReader();
            if (DR1.Read())
            {
                string player = DR1.GetValue(0).ToString();
                playerID = int.Parse(player);

            }

            DR1.Close();

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();


            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from auction where PlayerID='" + playerID + "' and TrophyID='" + trophyID + "'";

            //error message
            if (cmd.ExecuteReader().Read())
            {
                Response.Write("<script>alert('Already Applied')</script>");
            }


            else
            {
                //insert command

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();

                string query = "insert into auction(PlayerID, TrophyID, AuctionStatus, Team, SoldPrice) values('" + playerID + "', '" + trophyID + "', 'pending' , null, 0)";

                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = query;
                cmd1.ExecuteNonQuery();
                Response.Write("<script>alert('Applied Successfully')</script>");
            }
            
        }
    }
}