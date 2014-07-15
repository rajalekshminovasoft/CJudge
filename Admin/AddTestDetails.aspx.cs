using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_AddTestDetails : System.Web.UI.Page
{
    CJDataClassesDataContext cjDataclass = new CJDataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Logged"].ToString() == "False")
            Response.Redirect("../Default.aspx");
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (txt_TestName.Text != "")
        {
            int groupreportaccess = 0;
            if (chbGroupReport.Checked)// == true)
            groupreportaccess = 1;
            cjDataclass.AddTestLists(0, txt_TestName.Text, int.Parse(ddl_Org.SelectedValue), int.Parse(ddlStatus.SelectedValue), txt_instruction.Text, "",int.Parse(txt_passmark.Text), 1, drp_ReportType.SelectedItem.Text , 1, groupreportaccess, Convert.ToInt32(txt_price.Text), txt_remark.Text);
            lblMessage.Text = "Test Details Added";
            grd_designation.DataBind();
            txt_remark.Text = "";
            txt_TestName.Text = "";
            txt_price.Text = "";
            txt_passmark.Text = "";
            txt_instruction.Text = "";
        }
    }
}