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
    public partial class OrderStats : System.Web.UI.Page
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
                LoadApplicationState();
                LoadCachedData();
            }
        }

        void LoadApplicationState()
        {
            lblVisitors.Text = Application["Visitors"].ToString();
            lblActive.Text = Application["ActiveUsers"].ToString();
        }

        void LoadCachedData()
        {
            if (Cache["FoodCategoryStats"] == null)
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlDataAdapter da = new SqlDataAdapter(
                        "SELECT Category, COUNT(*) AS TotalItems FROM MenuItems GROUP BY Category", con);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    Cache.Insert("FoodCategoryStats", dt, null,
                        DateTime.Now.AddMinutes(5),
                        System.Web.Caching.Cache.NoSlidingExpiration);

                    gvStats.DataSource = dt;
                    gvStats.DataBind();
                }
            }
            else
            {
                gvStats.DataSource = (DataTable)Cache["FoodCategoryStats"];
                gvStats.DataBind();
            }
        }
    }
}
