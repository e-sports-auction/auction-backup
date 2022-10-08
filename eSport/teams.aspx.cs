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
    public partial class teams : System.Web.UI.Page
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
            string email = Session["email"].ToString();

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            int owner = 0;
            SqlCommand Com = new SqlCommand("select OwnerID from owner where Email='" + email + "'", con);
            SqlDataReader DR1 = Com.ExecuteReader();
            if (DR1.Read())
            {
                string player = DR1.GetValue(0).ToString();
                owner = int.Parse(player);

            }


            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            //select command

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from team where OwnerID='" + owner + "'";
            cmd.ExecuteNonQuery();

            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dtl_player.DataSource = dt;
            dtl_player.DataBind();

        }
    }
}