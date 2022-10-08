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

namespace e_sport_trial.player
{
    public partial class pgRegister : System.Web.UI.Page
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

            btnUpdate.Visible = false;
            lbRegister.Visible = false;
            lblRe.Text = "Registration";
            lblbelow.Text = "Something Wrong";
            clear_labels();
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            registerPlayer();
        }


        private void registerPlayer()
        {

                clear_labels();

            // validation of name and number
            String first = txtFirst.Text;
            String last = txtLast.Text;
            String email = txtEmail.Text;
            String dob = txtDob.Text;
            String role = dplRole.Text;
            String runs = txtRuns.Text;
            String wicket = txtWickets.Text;
            String matches = txtmatch.Text;
            String arm = dplArm.Text;
            String pass = txtPassword.Text;
            String conpass = txtConpass.Text;


            if (first == "")
            {
                lblError_first.Text = "This field is required !";
            }
            if (last == "")
            {
                lblError_last.Text = "This field is required !";
            }
            if (email == "")
            {
                lblError_mail.Text = "This field is required !";
            }
            if (dob == "")
            {
                lblError_dob.Text = "This field is required !";
            }
            if (role == "")
            {
                lblError_role.Text = "This field is required !";
            }
            if (runs == "")
            {
                lblError_runs.Text = "This field is required !";
            }
            if (wicket == "")
            {
                lblError_wickets.Text = "This field is required !";
            }
            if (matches == "")
            {
                lblError_match.Text = "This field is required !";
            }
            if (arm == "")
            {
                lblError_arm.Text = "This field is required !";
            }
            if (pass == "")
            {
                lblError_pass.Text = "This field is required !";
            }
            if (conpass == "")
            {
                lblError_conpass.Text = "This field is required !";
            }

            if (pass != conpass)
            {
                lblError_conpass.Text = "Password and Confirm Password arent the Same";
            }

            else
            {
                try
                {
                    if (FileUpload1.HasFile)
                    {
                        string str = FileUpload1.FileName;
                        FileUpload1.PostedFile.SaveAs(Server.MapPath("~/img/players/"+str));
                        string img = "~/img/players/" + str.ToString();
         
              

                        //check if player already exists


                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select * from player where Email='" + email + "'";



                        //error message
                        if (cmd.ExecuteReader().Read())
                        {
                            lblError.Text = "Player with this Email already exists";
                            con.Close();
                        }

                        //insert and success message
                        else
                        {
                            if (con.State == ConnectionState.Open)
                            {
                                con.Close();
                            }
                            con.Open();

                            //insert command
                        
                            string query = "insert into player(FirstName, LastName, Email, Dob, Role, Runs, Wickets, Matches, ArmStyle, Image, BasePrice, Password,Status) values('" + first + "', '" + last + "', '" + email + "', '" + dob + "', '" + role + "', '" + runs + "', '" + wicket + "', '" + matches + "', '" + arm + "', '" + img + "', 0, '" + pass + "',0)";

                            SqlCommand cmd1 = con.CreateCommand();
                            cmd1.CommandType = CommandType.Text;
                            cmd1.CommandText = query;
                            cmd1.ExecuteNonQuery();

                            //registered successfully
                            Response.Write("Alert('Registered Successfully')");

                        }
                        con.Close();
                    }
                    else
                    {
                        lblError_image.Text = "This field is required !";
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
            lblError_arm.Text = "";
            lblError_conpass.Text = "";
            lblError_dob.Text = "";
            lblError_first.Text = "";
            lblError_image.Text = "";
            lblError_last.Text = "";
            lblError_mail.Text = "";
            lblError_match.Text = "";
            lblError_pass.Text = "";
            lblError_role.Text = "";
            lblError_runs.Text = "";
            lblError_wickets.Text = "";
        }

        private void clear_textboxes()
        {
            txtFirst.Text = "";
            txtLast.Text = "";
            txtEmail.Text = "";
            txtDob.Text = "";
            dplRole.Text = "";
            txtRuns.Text = "";
            txtWickets.Text = "";
            txtmatch.Text = "";
            dplArm.Text = "";
            txtPassword.Text = "";
            txtConpass.Text = "";
        }

        protected void lbUpdate_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", "myFunction()", true);

            lblRe.Text = "Update Registration";
            lblbelow.Text = "Haven't Register";
            btnRegister.Visible = false;
            btnUpdate.Visible = true;
            lbUpdate.Visible = false;
            lbRegister.Visible = true;
            txtEmail.Enabled = false;

            String mail = lblUpdateEmail.Text;

            if (mail != "") 
            { 
                SqlCommand Com = new SqlCommand("select * from player where Email='" + mail + "'", con);
                SqlDataReader dr = Com.ExecuteReader();
                if (dr.Read())
                {

                    txtFirst.Text = dr.GetValue(1).ToString();
                    txtLast.Text = dr.GetValue(2).ToString();
                    txtEmail.Text = dr.GetValue(3).ToString();
                    txtDob.Text = dr.GetValue(4).ToString();
                    dplRole.Text = dr.GetValue(5).ToString();
                    txtRuns.Text = dr.GetValue(6).ToString();
                    txtWickets.Text = dr.GetValue(7).ToString();
                    txtmatch.Text = dr.GetValue(8).ToString();
                    dplArm.Text = dr.GetValue(9).ToString();
                    txtPassword.Text = dr.GetValue(12).ToString();     
                }
            }
        }

        protected void lbRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            clear_labels();

            // validation of name and number
            String first = txtFirst.Text;
            String last = txtLast.Text;
            String dob = txtDob.Text;
            String role = dplRole.Text;
            String runs = txtRuns.Text;
            String wicket = txtWickets.Text;
            String matches = txtmatch.Text;
            String arm = dplArm.Text;
            String pass = txtPassword.Text;
            String conpass = txtConpass.Text;
            String UpEmail = lblUpdateEmail.Text;


            if (first == "")
            {
                lblError_first.Text = "This field is required !";
            }
            if (last == "")
            {
                lblError_last.Text = "This field is required !";
            }
            if (dob == "")
            {
                lblError_dob.Text = "This field is required !";
            }
            if (role == "")
            {
                lblError_role.Text = "This field is required !";
            }
            if (runs == "")
            {
                lblError_runs.Text = "This field is required !";
            }
            if (wicket == "")
            {
                lblError_wickets.Text = "This field is required !";
            }
            if (matches == "")
            {
                lblError_match.Text = "This field is required !";
            }
            if (arm == "")
            {
                lblError_arm.Text = "This field is required !";
            }
            if (pass == "")
            {
                lblError_pass.Text = "This field is required !";
            }
            if (conpass == "")
            {
                lblError_conpass.Text = "This field is required !";
            }

            if (pass != conpass)
            {
                lblError_conpass.Text = "Password and Confirm Password arent the Same";
            }

            else
            {
                try
                {
                    if (FileUpload1.HasFile)
                    {
                        string str = FileUpload1.FileName;
                        FileUpload1.PostedFile.SaveAs(Server.MapPath("~/img/players/" + str));
                        string img = "~/img/players/" + str.ToString();

                        //check if player already exists


                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                        con.Open();


                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select * from player where Email='" + UpEmail + "'";

                        //Read Emails exist
                        if (cmd.ExecuteReader().Read())
                        {

                            //update command
                            string query = "UPDATE player SET FirstName ='" + first + "', LastName = '" + last + "', Email ='" + UpEmail + "', Dob = '" + dob + "', Role ='" + role + "', Runs ='" + runs + "', Wickets ='" + wicket + "', Matches = '" + matches + "', ArmStyle ='" + arm + "',, Image = '" + img + "', BasePrice = 0, Password = '" + pass + "',Status = 0 WHERE Email = '" + UpEmail + "'";
                            SqlCommand cmd1 = con.CreateCommand();
                            cmd1.CommandType = CommandType.Text;
                            cmd1.CommandText = query;
                            cmd1.ExecuteNonQuery();

                            //registered successfully
                            Response.Write("<script>Alert('Updated Successfully')</script>");

                            con.Close();
                        }

                        else
                        {
                            lblError.Text = "The entered Email-address does not exist..!";
                        }
                    }
                    else
                    {
                        lblError_image.Text = "This field is required !";
                    }

                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;

                }
            }
        }
    }
}