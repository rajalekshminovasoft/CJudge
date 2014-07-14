using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CJMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        { 
            
        }
    }
    protected void lnk_logout_Click(object sender, EventArgs e)
    {
        Session["Logged"]= false ;
        Response.Redirect("../Default.aspx");
    }
}
