using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace e_sport_trial.admin
{
    public partial class pgLogin_admin : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        string userType;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            hideErrMessage();
        }

        private void userLogin()
        {

            if (txtEmail.Text == "" || txtPassword.Text == "")
            {
                if (txtEmail.Text == "")
                {
                    lblError_mail.Visible = true;
                }

                if (txtPassword.Text == "")
                {
                    lblError_pass.Visible = true;

                }
            }

            else
            {
                try
                {
                    userType = Request.QueryString["id"].ToString();
                    //open and close connection
                    //Check if entered username and password are correct

                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    if (userType == "admin")
                    {
                        eSport.classes.Admin user = new eSport.classes.Admin(txtEmail.Text, txtPassword.Text);
                        string result = user.login();

                        if (result == "success")
                        {
                            Session["email"] = txtEmail.Text;
                            Response.Redirect("admin.aspx");

                        }
                        if (result == "fail")
                        {
                            lblError.Visible = true;
                        }

                    }
                    if (userType == "player")
                    {
                        eSport.classes.Player user = new eSport.classes.Player(txtEmail.Text, txtPassword.Text);                     
                        string result = user.login();

                        if(result == "success")
                        {
                            Session["email"] = txtEmail.Text;
                            Response.Redirect("player-dashboard.aspx");

                        }
                        if (result == "fail")
                        {
                            lblError.Visible = true;
                        }
                    }

                    if (userType == "owner")
                    {

                        eSport.classes.Owner user = new eSport.classes.Owner(txtEmail.Text, txtPassword.Text);
                        string result = user.login();

                        if (result == "success")
                        {
                            Session["email"] = txtEmail.Text;
                            Response.Redirect("team-owner-dashboard.aspx");

                        }
                        if (result == "fail")
                        {
                            lblError.Visible = true;
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);

                }
            }

        }


        private void emptyTextBox()
        {
            txtPassword.Text = "";
            txtEmail.Text = "";
        }

        private void hideErrMessage()
        {
            lblError_mail.Visible = false;
            lblError.Visible = false;
            lblError_pass.Visible = false;

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            userLogin();
        }
    }
}