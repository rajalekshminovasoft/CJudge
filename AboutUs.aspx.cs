using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AboutUs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (int.Parse(Request.QueryString["id"].ToString()) == 1)
        {
            pnl_Aboutus.Visible = true;
        }
        if (int.Parse(Request.QueryString["id"].ToString()) == 2)
        {
            pnl_OurVision .Visible = true;
        }
        if (int.Parse(Request.QueryString["id"].ToString()) == 3)
        {
            pnl_unque.Visible = true;
        }
        if (int.Parse(Request.QueryString["id"].ToString()) == 4)
        {
            pnl_ourvalues.Visible = true;
        }
    }
}