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
    public partial class team_details : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        int id;
        int startingTeamPrice;
        string teamName;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

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

            id = Convert.ToInt32(Request.QueryString["id"].ToString());

            SqlCommand Com = new SqlCommand("select * from team where TeamID='" + id + "'", con);
            SqlDataReader DR1 = Com.ExecuteReader();
            if (DR1.Read())
            {
                string url = DR1.GetValue(3).ToString();
                teamBanner.ImageUrl = url;

                teamName= DR1.GetValue(4).ToString();
                lb_teamName.Text= DR1.GetValue(4).ToString();

                string Tid = DR1.GetValue(2).ToString();
                getTeamPrice(Tid);
                loadTeamPlayers();

            }


        }

        private void calBalance()
        {
            int total =0 ;
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select player.FirstName, player.LastName, team.Name, auction.SoldPrice from player join auction on player.PlayerID=auction.PlayerID join team on auction.Team=team.Name where auction.Team='" + teamName + "'", con);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
               total = total + int.Parse(dr["SoldPrice"].ToString());
            }

            teamBalance.Text = (startingTeamPrice - total).ToString();
        }

        private void loadTeamPlayers()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            //select command

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select player.FirstName, player.LastName, team.Name, auction.SoldPrice from player join auction on player.PlayerID=auction.PlayerID join team on auction.Team=team.Name where auction.Team='" + teamName + "'";
            cmd.ExecuteNonQuery();

            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dl_teamPlayer.DataSource = dt;
            dl_teamPlayer.DataBind();
            calBalance();

        }

        private void getTeamPrice(string id)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            //select command


            SqlCommand Com = new SqlCommand("select TeamPrice from trophy where TrophyID='" + id + "'", con);
            SqlDataReader DR1 = Com.ExecuteReader();
            if (DR1.Read())
            {
                string price = DR1.GetValue(0).ToString();
                teamBalance.Text = price;
                startingTeamPrice = int.Parse(price);

            }
        }
    }
}