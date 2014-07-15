using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class TakeTest : System.Web.UI.Page
{
    CJDataClassesDataContext cjDataclass = new CJDataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private void checkdata()
    {
        if (Wizard1.ActiveStepIndex == 0)
        {
            //Label1.Text = Wizard1.ActiveStepIndex.ToString();
            Session["TestID"] = "";
            foreach (DataListItem dli in dtTestlist.Items)
            {
                CheckBox productID = ((CheckBox)dli.FindControl("chktest"));
                if (productID.Checked == true)
                {
                    Session["TestID"] = ((Label)dli.FindControl("lbltestid")).Text;
                    Session["TestIDList"] = Session["TestIDList"] + "," + Session["TestID"];
                }
            }
            //Label1.Text = Session["TestID"].ToString();
        }
        if ((Session["TestIDList"] == null))
        {
            lblmsg.Text = "Select Atleast One Test";
        }

    }
    protected void btnstp2_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        checkdata();
        Wizard1.ActiveStepIndex = 1;
    }
    protected void btnstp3_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        checkdata();
        Wizard1.ActiveStepIndex = 2;
    }
    protected void btnstp1_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        Wizard1.ActiveStepIndex = 0;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtAge.Text != "")
        {
            //cj
        }
    }
}