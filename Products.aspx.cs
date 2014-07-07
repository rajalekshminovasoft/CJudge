using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Products : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (int.Parse(Request.QueryString["id"].ToString()) == 5)
        {
            pnl_talentscout.Visible = true;
        }
        if (int.Parse(Request.QueryString["id"].ToString()) == 6)
        {
            pnl_codeinformatics.Visible = true;
        }
        if (int.Parse(Request.QueryString["id"].ToString()) == 7)
        {
            pnl_assessment.Visible = true;
        }
    }
}