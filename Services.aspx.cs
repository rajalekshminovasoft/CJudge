using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Services : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (int.Parse(Request.QueryString["id"].ToString()) == 8)
        {
            pnl_corporatehr.Visible = true;
        }
        if (int.Parse(Request.QueryString["id"].ToString()) == 9)
        {
            pnl_assessment.Visible = true;
        }
        if (int.Parse(Request.QueryString["id"].ToString()) == 10)
        {
            pnl_careermanagement .Visible = true;
        }
        if (int.Parse(Request.QueryString["id"].ToString()) == 11)
        {
            pnl_psychometric.Visible = true;
        }
    }
}