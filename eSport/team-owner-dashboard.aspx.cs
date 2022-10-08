using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eSport
{
    public partial class team_owner_dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getEmail();
        }

        private void getEmail()
        {
            string email = Session["email"].ToString();
        }
    }
}