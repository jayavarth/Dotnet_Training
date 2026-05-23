using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment1
{
    public partial class Ques2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlProducts.Items.Add("Laptop");
                ddlProducts.Items.Add("Mobile");
                ddlProducts.Items.Add("Headphones");

                imgProduct.ImageUrl = "Images/laptop.jpg";
            }
        }
        protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProducts.SelectedItem.Text == "Laptop")
            {
                imgProduct.ImageUrl = "Images/laptop.jpeg";
            }
            else if (ddlProducts.SelectedItem.Text == "Mobile")
            {
                imgProduct.ImageUrl = "Images/mobile.jpeg";
            }
            else if (ddlProducts.SelectedItem.Text == "Headphones")
            {
                imgProduct.ImageUrl = "Images/headphones.jpeg";
            }
        }
        protected void btnPrice_Click(object sender, EventArgs e)
        {
            if (ddlProducts.SelectedItem.Text == "Laptop")
            {
                lblPrice.Text = "Price : $800";
            }
            else if (ddlProducts.SelectedItem.Text == "Mobile")
            {
                lblPrice.Text = "Price : $500";
            }
            else if (ddlProducts.SelectedItem.Text == "Headphones")
            {
                lblPrice.Text = "Price : $100";
            }
        }
    }
}