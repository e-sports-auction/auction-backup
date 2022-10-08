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
    public partial class crudOwner : System.Web.UI.Page
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

            //clear_labels();
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

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from owner";
            cmd.ExecuteNonQuery();

            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dl_teams.DataSource = dt;
            dl_teams.DataBind();

        }

        private void clear_labels()
        {
            txtEmail.Text = "";
            txtOwnerName.Text = "";
            txtPassword.Text = "";
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

            SqlCommand Com = new SqlCommand("select * from owner where OwnerID='" + id + "'", con);
            SqlDataReader DR1 = Com.ExecuteReader();
            if (DR1.Read())
            {
                lb_teamID.Text= DR1.GetValue(0).ToString();
                txtOwnerName.Text = DR1.GetValue(1).ToString();
                txtEmail.Text = DR1.GetValue(2).ToString();
                txtPassword.Text = DR1.GetValue(3).ToString();

            }
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
            cmd.CommandText = "delete from owner where OwnerID ='" + id + "' ";
            cmd.ExecuteNonQuery();

            loadTeam();
        }

        private void addOwner()
        {


            // validation of name and number
            String email = txtEmail.Text;
            String name = txtOwnerName.Text;
            String password = txtPassword.Text;


            if (email == "")
            {
                lblError.Text = "All field is required !";
            }
            if (name == "")
            {
                lblError.Text = "All field is required !";
            }
            if (password == "")
            {
                lblError.Text = "All field is required !";
            }
      


            else
            {
                try
                {
                        //check if player already exists


                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select * from owner where Email='" + email + "'";



                        //error message
                        if (cmd.ExecuteReader().Read())
                        {
                            lblError.Text = "Owner with this Name already exists";
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

                            string query = "insert into owner(Name, Email, Password) values('" + name + "', '" + email + "', '" + password + "')";

                            SqlCommand cmd1 = con.CreateCommand();
                            cmd1.CommandType = CommandType.Text;
                            cmd1.CommandText = query;
                            cmd1.ExecuteNonQuery();

                            loadTeam();

                            //registered successfully
                            Response.Write("Alert('Registered Successfully')");
                            //clear_labels();


                    }
                    con.Close();
                  

                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;

                }
            }

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            addOwner();
            loadTeam();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            // validation of name and number
            String email = txtEmail.Text;
            String name = txtOwnerName.Text;
            String password = txtPassword.Text;


            if (email == "")
            {
                lblError.Text = "All field is required !";
            }
            if (name == "")
            {
                lblError.Text = "All field is required !";
            }
            if (password == "")
            {
                lblError.Text = "All field is required !";
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

                    int id = int.Parse(lb_teamID.Text);


                    //insert command

                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update owner set Name = '" + name + "' , Email = '" + email + "', Password = '" + password + "' where OwnerID ='" + id + "' ";
                    cmd.ExecuteNonQuery();


                    loadTeam();

                        //registered successfully
                        Response.Write("Alert('Registered Successfully')");
                        //clear_labels();


                    
                    con.Close();


                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;

                }
            }
        }
    }
}