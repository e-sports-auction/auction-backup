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
    public partial class viewTrophyForPlayerStatus : System.Web.UI.Page
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
    }
}