using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Foodorder_CC
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPass.Text;

            if (username == "admin" && password == "food@123")
            {
                Session["Username"] = username;
                Session["Role"] = "Admin";

                Response.Redirect("MenuList.aspx");
            }
            else
            {
                lblMsg.Text = "Invalid login. You are not authorized.";
            }
        }
    }
}