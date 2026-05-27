using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Foodorder_CC
{
    public partial class MenuList : System.Web.UI.Page
    {
        string conStr = System.Configuration.ConfigurationManager
                        .ConnectionStrings["connectionFOM"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadData();
            }
        }
        void LoadData()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM MenuItems", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvMenu.DataSource = dt;
                gvMenu.DataBind();
            }
        }

        protected void DeleteItem(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);

            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM MenuItems WHERE MenuId=@id", con);
                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            LoadData();
        }
    }
}