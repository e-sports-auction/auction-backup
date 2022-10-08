using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eSport
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(DropDownList1.SelectedValue, true);
        }

        protected void btn_Reg_Click(object sender, EventArgs e)
        {
            Response.Redirect("pgRegister.aspx");
        }
    }
}