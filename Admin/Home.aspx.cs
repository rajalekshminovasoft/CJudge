using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Logged"].ToString() == "False")
            Response.Redirect("../Default.aspx");
    }
    protected void imgbtn_testlist_Click(object sender, ImageClickEventArgs e)
    {
        //User View
        Response.Redirect("ViewUserTestDetails.aspx");
        //Admin View

    }
}