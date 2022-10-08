using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_sport_trial.admin
{
    public partial class pgTrophy : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

        protected void Page_Load(object sender, EventArgs e)
        {
            // Check the Connection Status & close/Open it
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            lblTError.Text = "";
            lblError.Text = "";
            load_trophy();
            fillloadcombo();
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            //Variables
            String Tname = txtTroname.Text;
            String start = txtStart.Text;
            String end = txtEnd.Text;
            String venue = txtVenue.Text;
            String price = txtPrice.Text;


            lblError.Text = "";

            if (Tname == "" || start == "" || end == "" || venue == "" || price == "")
            {
                lblError.Text = "All fields are required..!";
            }

            else
            {
                try
                {
                    if (fileLogo.HasFile)
                    {
                        string str = fileLogo.FileName;
                        fileLogo.PostedFile.SaveAs(Server.MapPath("~/img/trophy/" + str));
                        string logo = "~/img/trophy/" + str.ToString();

                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                        con.Open();

                        //check if player already exists
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select * from trophy where Name='" + Tname + "'";
                        cmd.ExecuteNonQuery();

                        if (cmd.ExecuteReader().Read())
                        {
                            lblError.Text = "The Trophy is already exist..!";

                            con.Close();
                        }


                        else
                        {
                            int Price = int.Parse(txtPrice.Text);

                            if (con.State == ConnectionState.Open)
                            {
                                con.Close();
                            }
                            con.Open();

                            string query = "insert into trophy(Logo, Name, StartDate, EndDate, Venue, TeamPrice) values('" + logo + "', '" + Tname + "', '" + start + "', '" + end + "', '" + venue + "', '" + price + "')";
                            SqlCommand cmd1 = con.CreateCommand();
                            cmd1.CommandType = CommandType.Text;
                            cmd1.CommandText = query;
                            cmd1.ExecuteNonQuery();

                            // getting trophy name to add teams
                            SqlCommand Com = new SqlCommand("select * from trophy where Name='" + Tname + "'", con);
                            SqlDataReader DR1 = Com.ExecuteReader();
                            if (DR1.Read())
                            {
                                lblTrophyid.Text = DR1.GetValue(0).ToString();
                                logoTrophy.ImageUrl = DR1.GetValue(1).ToString();
                                lblTrophyname.Text = DR1.GetValue(2).ToString();
                            }
                            load_trophy();

                            dplTeam.Items.Clear();
                            fillloadcombo();

                            con.Close();
                        }
                    }

                    else
                    {
                        lblError.Text = "All fields are required..!";

                    }

                }

                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                }
            }
        }

        public void load_trophy()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            // Load loads to trophy dtl
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from trophy";
            cmd.ExecuteNonQuery();

            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dtl_Trophy.DataSource = dt;
            dtl_Trophy.DataBind();

            con.Close();

        }

        private void fillloadcombo()
        {

            // Fill Items to Loadid select combo
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select Name from team ", con);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                dplTeam.Items.Add(dr["Name"].ToString());
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //Variables
            String Tname = txtTroname.Text;
            String start = txtStart.Text;
            String end = txtEnd.Text;
            String venue = txtVenue.Text;
            String price = txtPrice.Text;


            lblError.Text = "";

            if (Tname == "" || start == "" || end == "" || venue == "" || price == "")
            {
                lblError.Text = "All fields are required..!";
            }

            else
            {
                try
                {
                    if (fileLogo.HasFile)
                    {
                        string str = fileLogo.FileName;
                        fileLogo.PostedFile.SaveAs(Server.MapPath("~/img/trophy/" + str));
                        string logo = "~/img/trophy/" + str.ToString();

                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                        con.Open();


                        int Price = int.Parse(txtPrice.Text);

                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                        con.Open();

                        string query = "UPDATE trophy SET Logo ='" + logo + "', Name ='" + Tname + "', StartDate  ='" + start + "', EndDate ='" + end + "', Venue ='" + venue + "', TeamPrice ='" + Price + "'";
                        SqlCommand cmd1 = con.CreateCommand();
                        cmd1.CommandType = CommandType.Text;
                        cmd1.CommandText = query;
                        cmd1.ExecuteNonQuery();

                        load_trophy();

                        dplTeam.Items.Clear();
                        fillloadcombo();

                        con.Close();
                    }


                    else
                    {
                        lblError.Text = "All fields are required..!";

                    }

                }

                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                }
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            // view button function 
            string TrophyID = ((Button)sender).CommandArgument.ToString();
            int id = int.Parse(TrophyID);

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            SqlCommand Com = new SqlCommand("select * from trophy where TrophyID='" + id + "'", con);
            SqlDataReader DR1 = Com.ExecuteReader();
            if (DR1.Read())
            {
                lblTrophyid.Text = DR1.GetValue(0).ToString();
                logoTrophy.ImageUrl = DR1.GetValue(1).ToString();
                lblTrophyname.Text = DR1.GetValue(2).ToString();

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();

                // Load loads to team dtl
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from team where TrophyID='" + id + "'";
                cmd.ExecuteNonQuery();

                DataSet dt = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dtlTeams.DataSource = dt;
                dtlTeams.DataBind();

                dplTeam.Items.Clear();
                fillloadcombo();
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            // edit button function 
            string TrophyID = ((Button)sender).CommandArgument.ToString();
            int id = int.Parse(TrophyID);

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            SqlCommand Com = new SqlCommand("select * from trophy where TrophyID='" + id + "'", con);
            SqlDataReader DR1 = Com.ExecuteReader();
            if (DR1.Read())
            {
                txtTroname.Text = DR1.GetValue(2).ToString();
                txtStart.Text = DR1.GetValue(3).ToString();
                txtEnd.Text = DR1.GetValue(4).ToString();
                txtVenue.Text = DR1.GetValue(5).ToString();
                txtPrice.Text = DR1.GetValue(6).ToString();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string TrophyID = ((Button)sender).CommandArgument.ToString();
            int id = int.Parse(TrophyID);


            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            // delete command
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from trophy where TrophyID ='" + id + "' ";
            cmd.ExecuteNonQuery();

            load_trophy();

            dplTeam.Items.Clear();
            fillloadcombo();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            String team = dplTeam.SelectedValue;
            int TID = int.Parse(lblTrophyid.Text);

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            //check if player already exists
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from team where TrophyID='" + TID + "' and Name='" + team + "'";
            cmd.ExecuteNonQuery();

            if (cmd.ExecuteReader().Read())
            {
                lblTError.Text = "The team is already exist in the Trophy..!";

                con.Close();
            }

            else
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();

                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "UPDATE team SET TrophyID ='" + TID + "' WHERE Name='" + team + "'";
                cmd1.ExecuteNonQuery();

                // Load loads to team dtl
                DataSet dt = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter("select * from team where TrophyID= '" + TID + "'", con);
                da.Fill(dt);
                dtlTeams.DataSource = dt;
                dtlTeams.DataBind();

                lblTError.Text = "Team Added";
                lblTError.ForeColor = Color.Green;

                dplTeam.Items.Clear();
                fillloadcombo();

                con.Close();
            }
        }
    }
}