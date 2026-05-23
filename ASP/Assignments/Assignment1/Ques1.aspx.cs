using System;
using System.Web.UI;

namespace Assignment1
{
    public partial class Validator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ValidateName(object source,
            System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            if (txtName.Text != txtFamily.Text)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }
        protected void btnCheck_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                lblResult.ForeColor = System.Drawing.Color.Green;
                lblResult.Text = "All inputs are valid!";
            }
            else
            {
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Text = "Validation failed!";
            }
        }
    }
}