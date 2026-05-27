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
    public partial class MenuDetails : System.Web.UI.Page
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
                if (Request.QueryString["MenuId"] != null)
                {
                    LoadDetails();
                }
            }
        }

        void LoadDetails()
        {
            int id = Convert.ToInt32(Request.QueryString["MenuId"]);

            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM MenuItems WHERE MenuId=@id", con);

                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    lblItem.Text = dr["ItemName"].ToString();
                    lblCategory.Text = dr["Category"].ToString();
                    lblType.Text = dr["FoodType"].ToString();
                    lblPrice.Text = dr["Price"].ToString();
                    lblQty.Text = dr["AvailableQuantity"].ToString();
                    lblAvailable.Text = dr["IsAvailable"].ToString();
                    lblDate.Text = dr["CreatedDate"].ToString();
                }
            }
        }
    }
}
