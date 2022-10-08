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
    public partial class crudTeams : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        string ownerName = "";
        string trophyName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check the Connection Status & close/Open it
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            clear_labels();
            loadTeam();
            dplTrophy.Items.Clear();
            getTrophy();
            dplOwner.Items.Clear();
            getOwner();
        }

        private void addTeam()
        {

            clear_labels();

            // validation of name and number
            String teamName = txtTeamName.Text;
            String ambassador = txtAmbassador.Text;
            String Owner = dplOwner.SelectedValue;
            String Trophy = dplTrophy.SelectedValue;

            
            if (teamName == "")
            {
                lblError.Text = "All field is required !";
            }
            if (ambassador == "")
            {
                lblError.Text = "All field is required !";
            }
            if (Owner == "")
            {
                lblError.Text = "All field is required !";
            }
            if (Trophy == "")
            {
                lblError.Text = "All field is required !";
            }


            else
            {
                try
                {
                    if (FileUpload1.HasFile)
                    {
                        string str = FileUpload1.FileName;
                        FileUpload1.PostedFile.SaveAs(Server.MapPath("~/img/teamLogo/" + str));
                        string img = "~/img/teamLogo/" + str.ToString();



                        //check if player already exists


                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select * from team where Name='" + teamName + "'";



                        //error message
                        if (cmd.ExecuteReader().Read())
                        {
                            lblError.Text = "Team with this Name already exists";
                            con.Close();
                        }

                        //insert and success message
                        else
                        {
                            int ownerID=0;
                            int trophyID=0;

                            if (con.State == ConnectionState.Open)
                            {
                                con.Close();
                            }
                            con.Open();
                            SqlCommand Com = new SqlCommand("select TrophyID from trophy where Name='" + Trophy + "'", con);
                            SqlDataReader DR1 = Com.ExecuteReader();
                            if (DR1.Read())
                            {
                                string trophy = DR1.GetValue(0).ToString();
                                trophyID = int.Parse(trophy);
                               
                            }

                            if (con.State == ConnectionState.Open)
                            {
                                con.Close();
                            }
                            con.Open();

                            DR1.Close();
                            SqlCommand Com1 = new SqlCommand("select OwnerID from owner where Name='" + Owner + "'", con);
                            SqlDataReader DR2 = Com1.ExecuteReader();
                            if (DR2.Read())
                            {
                                string owner = DR2.GetValue(0).ToString();
                                ownerID = int.Parse(owner);
                            }


                            if (con.State == ConnectionState.Open)
                            {
                                con.Close();
                            }
                            con.Open();
                           

                            //insert command

                            string query = "insert into team(OwnerID, TrophyID, Logo, Name, Ambassador) values('" + ownerID + "', '" + trophyID + "', '" + img + "', '" + teamName + "', '" + ambassador + "')";

                            SqlCommand cmd1 = con.CreateCommand();
                            cmd1.CommandType = CommandType.Text;
                            cmd1.CommandText = query;
                            cmd1.ExecuteNonQuery();

                            loadTeam();

                            //registered successfully
                            Response.Write("Alert('Registered Successfully')");

                        }
                        con.Close();
                    }
                    else
                    {
                        lblError.Text = "This field is required !";
                    }

                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;

                }
            }

        }

        private void clear_labels()
        {
            lblError.Text = "";
        }

        private void clear_textboxes()
        {
            txtTeamName.Text = "";
            txtAmbassador.Text = "";
            dplOwner.SelectedValue = "";
            dplTrophy.SelectedValue = "";
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            addTeam();
        }

        private void getTrophy()
        {
            // Fill Items to Loadid select combo
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select Name from trophy", con);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    dplTrophy.Items.Add(dr["Name"].ToString());
                }
            
        }

        private void getOwner()
        {
            //fill combo box

            // Fill Items to Loadid select combo
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select Name from owner", con);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                dplOwner.Items.Add(dr["Name"].ToString());
            }


        }

        private void loadTeam()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            //select command

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from team";
            cmd.ExecuteNonQuery();

            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dl_teams.DataSource = dt;
            dl_teams.DataBind();

        }



        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string TeamID = ((Button)sender).CommandArgument.ToString();
            int id = int.Parse(TeamID);


            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            // delete command
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from team where TeamID ='" + id + "' ";
            cmd.ExecuteNonQuery();

            loadTeam();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            // edit button function 
            string TeamID = ((Button)sender).CommandArgument.ToString();
            int id = int.Parse(TeamID);

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            SqlCommand Com = new SqlCommand("select * from team where TeamID='" + id + "'", con);
            SqlDataReader DR1 = Com.ExecuteReader();
            if (DR1.Read())
            {
                lb_teamID.Text= DR1.GetValue(0).ToString();
                txtTeamName.Text = DR1.GetValue(4).ToString();
                txtAmbassador.Text = DR1.GetValue(5).ToString();

            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            //update button function

            // validation of name and number
            String teamName = txtTeamName.Text;
            String ambassador = txtAmbassador.Text;
            String Owner = dplOwner.SelectedValue;
            String Trophy = dplTrophy.SelectedValue;


            if (teamName == "")
            {
                lblError.Text = "All field is required !";
            }
            if (ambassador == "")
            {
                lblError.Text = "All field is required !";
            }
            if (Owner == "")
            {
                lblError.Text = "All field is required !";
            }
            if (Trophy == "")
            {
                lblError.Text = "All field is required !";
            }
            if (!FileUpload1.HasFiles)
            {
                lblError.Text = "All field is required !";
            }

            else
            {
                try
                {
                    int ownerID = 0;
                    int trophyID = 0;
                    int id = int.Parse(lb_teamID.Text);

                    string str = FileUpload1.FileName;
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("~/img/teamLogo/" + str));
                    string img = "~/img/teamLogo/" + str.ToString();

                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Open();


                    SqlCommand Com = new SqlCommand("select TrophyID from trophy where Name='" + Trophy + "'", con);
                    SqlDataReader DR1 = Com.ExecuteReader();
                    if (DR1.Read())
                    {
                        string trophy = DR1.GetValue(0).ToString();
                        trophyID = int.Parse(trophy);

                    }

                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Open();

                    DR1.Close();

                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Open();

                    SqlCommand Com1 = new SqlCommand("select OwnerID from owner where Name='" + Owner + "'", con);
                    SqlDataReader DR2 = Com1.ExecuteReader();
                    if (DR2.Read())
                    {
                        string owner = DR2.GetValue(0).ToString();
                        ownerID = int.Parse(owner);
                    }
                    DR2.Close();


                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Open();

                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update team set OwnerID = '" + ownerID + "' , TrophyID = '" + trophyID + "', Logo = '" + img + "', Name = '" + teamName + "', Ambassador = '" + ambassador + "' where TeamID ='" + id + "' ";
                    cmd.ExecuteNonQuery();

                    loadTeam();
                }
                catch(Exception ex)
                {
                    lblError.Text = ex.Message;
                }
            }
        
        }
    }
}