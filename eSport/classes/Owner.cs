using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

[assembly: OwinStartup(typeof(eSport.classes.Owner))]

namespace eSport.classes
{
    public class Owner : User
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        public string email;
        public string password;


        public Owner(string email, string password) : base(email, password)
        {
            this.email = email;
            this.password = password;
        }

        public override string login()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "select * from owner where Email='" + this.email + "'and Password='" + this.password + "'";
            cmd.ExecuteNonQuery();

            if (cmd.ExecuteReader().Read())
            {
                return "success";

            }
            //error message
            else
            {
                return "fail";
            }
            con.Close();
        }
    
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
