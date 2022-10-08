using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace e_sport_trial.admin
{
    public partial class pgAuction : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            loadPlayer();
            dplTeam.Items.Clear();
            getTeam();
        }

        private void loadPlayer()
        {
            lb_err.Text = "";

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            //select command

            lb_currentPrice.Text = "";
            lb_currentTeam.Text = "";

            id = Convert.ToInt32(Request.QueryString["id"].ToString());



            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"select TOP 1 auction.TrophyID, player.PlayerID, player.FirstName, player.LastName, player.Role, 
                                player.Runs, player.Wickets, player.Matches, player.ArmStyle, player.Image, player.BasePrice, 
                                auction.Team, auction.SoldPrice, auction.AuctionStatus from player inner join auction 
                                on player.PlayerID = auction.PlayerID  where auction.AuctionStatus = 'pending' and 
                                auction.TrophyID ='" + id + "'";
            cmd.ExecuteNonQuery();

            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dtl_playerDetails.DataSource = dt;
            dtl_playerDetails.DataBind();

        }

        private void getTeam()
        {
            //fill combo box

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select Name from team where TrophyID='" + id + "'", con);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                dplTeam.Items.Add(dr["Name"].ToString());
            }


        }

        protected void btnUpdateetPrice_Click(object sender, EventArgs e)
        {
            lb_err.Text = "";
            lb_currentPrice.Text = txt_price.Text;
            lb_currentTeam.Text = dplTeam.SelectedValue;
        }

        protected void btnSold_Click(object sender, EventArgs e)
        {
                // validation of name and number
                String price = txt_price.Text;
                String team = dplTeam.SelectedValue;
                int startingTeamPrice = 0;
                bool teamCanBuy = false;

                if (price == "")
                {
                    //lblError.Text = "All field is required !";
                }

         
                    try
                    {
                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                        con.Open();

                        string playerId = ((Button)sender).CommandArgument.ToString();
                        int pId = int.Parse(playerId);
                        int tId = Convert.ToInt32(Request.QueryString["id"].ToString());



                        // get team price

                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                        con.Open();

                        SqlCommand Com = new SqlCommand("select TeamPrice from trophy where TrophyID='" + tId + "'", con);
                        SqlDataReader DR1 = Com.ExecuteReader();
                        if (DR1.Read())
                        {
                            string Tprice = DR1.GetValue(0).ToString();
                            startingTeamPrice = int.Parse(Tprice);

                        }
                // get team price ends



                //check team balance
                int total = 0;
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select player.FirstName, player.LastName, team.Name, auction.SoldPrice from player join auction on player.PlayerID=auction.PlayerID join team on auction.Team=team.Name where auction.Team='" + team + "'", con);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    total = total + int.Parse(dr["SoldPrice"].ToString()); 
                }

                total = total+int.Parse(price);
                int teamBal = startingTeamPrice - total;

                if (teamBal >= 0)
                {
                    teamCanBuy=true;
                }
                else
                {
                    lb_currentPrice.Text = "";
                    lb_currentTeam.Text = "";
                    lb_err.Text="Player Price is more than "+ team + " balance";
                }

                //check team balance ends


                //check team member numbers
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();

                SqlCommand Com1 = new SqlCommand("select COUNT(*) from auction where Team='" + team + "' and TrophyID='" + tId + "'", con);
                SqlDataReader DR2 = Com1.ExecuteReader();
                if (DR2.Read())
                {
                    string count = DR2.GetValue(0).ToString();
                    int teamCount = int.Parse(count);

                    if(teamCount == 13)
                    {
                        lb_err.Text =  team + " Already has 13 members";
                        teamCanBuy = false;
                    }
                }
                //check team member numbers end


                //command for auction
                if (teamCanBuy==true)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Open();

                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update auction set AuctionStatus = 'Sold' , Team = '" + team + "', SoldPrice = '" + price + "' where PlayerID ='" + pId + "' and  TrophyID ='" + tId + "'";
                    cmd.ExecuteNonQuery();


                    loadPlayer();
                    con.Close();
                }



                }
                catch (Exception ex)
                {

                }
               
            
        }

        protected void btnDecline_Click(object sender, EventArgs e)
        {
            // validation of name and number
            String price = "0";
            String team = "";


            if (price == "")
            {
                //lblError.Text = "All field is required !";
            }


            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();

                string playerId = ((Button)sender).CommandArgument.ToString();
                int pId = int.Parse(playerId);
                int tId = Convert.ToInt32(Request.QueryString["id"].ToString());


                //insert command

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update auction set AuctionStatus = 'Unsold' , Team = '" + team + "', SoldPrice = '" + price + "' where PlayerID ='" + pId + "' and  TrophyID ='" + tId + "'";
                cmd.ExecuteNonQuery();


                loadPlayer();

                //registered successfully
                //clear_labels();



                con.Close();


            }
            catch (Exception ex)
            {

            }
        }
    }
    
}