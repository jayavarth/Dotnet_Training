using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Foodorder_CC
{
    public partial class AddEditMenu : System.Web.UI.Page
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
                    LoadData();
                }
            }
        }

        void LoadData()
        {
            int id = Convert.ToInt32(Request.QueryString["MenuId"]);

            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("SELECT * FROM MenuItems WHERE MenuId=@id", con);
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                txtItem.Text = dr["ItemName"].ToString();
                txtCategory.Text = dr["Category"].ToString();
                ddlType.SelectedValue = dr["FoodType"].ToString();
                txtPrice.Text = dr["Price"].ToString();
                txtQty.Text = dr["AvailableQuantity"].ToString();
            }

            con.Close();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd;

            if (Request.QueryString["MenuId"] != null)
            {
                cmd = new SqlCommand(
                    "UPDATE MenuItems SET ItemName=@name, Category=@cat, FoodType=@type, Price=@price, AvailableQuantity=@qty WHERE MenuId=@id",
                    con);

                cmd.Parameters.AddWithValue("@id", Request.QueryString["MenuId"]);
            }
            else
            {
                cmd = new SqlCommand(
                    "INSERT INTO MenuItems(ItemName, Category, FoodType, Price, AvailableQuantity, IsAvailable, CreatedDate) VALUES(@name, @cat, @type, @price, @qty, 1, GETDATE())",
                    con);
            }

            cmd.Parameters.AddWithValue("@name", txtItem.Text);
            cmd.Parameters.AddWithValue("@cat", txtCategory.Text);
            cmd.Parameters.AddWithValue("@type", ddlType.SelectedValue);
            cmd.Parameters.AddWithValue("@price", txtPrice.Text);
            cmd.Parameters.AddWithValue("@qty", txtQty.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            Response.Redirect("MenuList.aspx");
        }
    }
}
