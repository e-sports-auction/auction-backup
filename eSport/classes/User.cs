using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(eSport.classes.User))]

namespace eSport.classes
{
    abstract public class User
    {
        public string email;
        public string password;

        public User(string uEmail, string uPassword)
        {
            this.email = uEmail;
            this.password = uPassword;
        }

        public abstract string login();

        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
