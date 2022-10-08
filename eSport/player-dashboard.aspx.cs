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
    public partial class player_dashboard : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        string email = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            loadPlayer();
        }


        private void loadPlayer()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            string email = Session["email"].ToString();
            Session.Remove("email");

            Session["email"] = email;

            //select command

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from player where Email='" + email + "'";
            cmd.ExecuteNonQuery();


            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dtl_player.DataSource = dt;
            dtl_player.DataBind();

        }
    }
}