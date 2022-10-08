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
    public partial class pending_player_details : System.Web.UI.Page
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

        }

        private void loadPlayer()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            //select command

            id = Convert.ToInt32(Request.QueryString["id"].ToString());

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from player where PlayerID='" + id + "'";
            cmd.ExecuteNonQuery();

            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dtl_playerDetails.DataSource = dt;
            dtl_playerDetails.DataBind();
            

        }

        protected void btnSetPrice_Click(object sender, EventArgs e)
        {
            string basePrice = txt_price.Text;
            if (basePrice == "")
            {
                //lb_UnError.Text = "Please enter the Product Name!";
            }
            else
            {
                try
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Open();
                    int price = int.Parse(basePrice);

                    //update command
                    string query = "update player set BasePrice = '" + basePrice + "', Status=1 where PlayerID ='" + id + "' ";
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();

                    Response.Redirect("pending-player.aspx");

                }

                catch (Exception ex)
                {

                }
            }
        }

        protected void btnDecline_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            // delete command
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update player set Status=2 where PlayerID ='" + id + "' ";
            cmd.ExecuteNonQuery();

            Response.Redirect("pending-player.aspx");
        }
    }
}