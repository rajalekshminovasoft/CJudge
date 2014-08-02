using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_TestIntroduction : System.Web.UI.Page
{
    CJDataClassesDataContext cjDataclass = new CJDataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillText();
        }
    }
    private void FillText()
    {
        Panel1.Visible = true;
        container.InnerHtml = "";
        Session.Add("curtestid", Request.QueryString["Id"]);
        int testid = 0;
        if (Session["curtestid"] != null)
        {
            testid = int.Parse(Session["curtestid"].ToString());
            var Details = from det in cjDataclass.TestLists
                          where det.TestId == testid
                          select det;
            if (Details.Count() > 0)
            {
                string trainingdetails = "<div>";
                if (Details.First().Instructions != null && Details.First().Instructions != "")
                    trainingdetails += Details.First().Instructions.ToString();

                if (Details.First().Description != null && Details.First().Description != "")
                    trainingdetails += "<br/>" + Details.First().Description.ToString();
                if (trainingdetails != "<div>")
                {
                    container.InnerHtml = trainingdetails;
                    return;
                }
            }
        }

    }
    protected void btnProceed_Click(object sender, EventArgs e)
    {
        Response.Redirect("TakeTest.aspx?Id=" + Request.QueryString["Id"].Trim() + "");
    }
}