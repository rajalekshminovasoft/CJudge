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
    public  int testid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            testid = 0;
        }
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
    protected void grd_designation_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //string test = grd_designation.SelectedRow.Cells[1].Text;
        //var testdetails = from testlist in cjDataclass.TestLists
        //                  where testlist.TestId == int.Parse(grd_designation.Rows[e.NewEditIndex].Cells[1].Text)
        //                          select testlist;
        //if (testdetails.Count() > 0)
        //{
        //    //enable viewstate of updatebutton
        //    btn_update.Visible = true;
        //    txt_TestName.Text = testdetails.First().TestName;
        //    txt_remark.Text = testdetails.First().Remark;
        //    txt_price.Text = testdetails.First().Price.ToString();
        //    txt_passmark.Text = testdetails.First().PassMark.ToString();
        //    txt_instruction.Text = testdetails.First().Instructions;
        //    drp_ReportType.SelectedValue = testdetails.First().ReportType;
        //    ddl_Org.SelectedValue = testdetails.First().OrganizationName.ToString();
        //    ddlStatus.SelectedValue = testdetails.First().Status.ToString();
        //}
    }
    protected void btn_update_Click(object sender, EventArgs e)
    {
        if (int.Parse(Session["testid"].ToString()) != 0)
        {
            int groupreportaccess = 0;
            if (chbGroupReport.Checked)// == true)
                groupreportaccess = 1;
            cjDataclass.AddTestLists(int.Parse(Session["testid"].ToString()), txt_TestName.Text, int.Parse(ddl_Org.SelectedValue), int.Parse(ddlStatus.SelectedValue), txt_instruction.Text, "", int.Parse(txt_passmark.Text), 1, drp_ReportType.SelectedItem.Text, 1, groupreportaccess, Convert.ToInt32(txt_price.Text), txt_remark.Text);
            grd_designation.DataBind();
        }
    }
    protected void grd_designation_SelectedIndexChanged(object sender, EventArgs e)
    {
        var testdetails = from testlist in cjDataclass.TestLists
                          where testlist.TestId == int.Parse(grd_designation.SelectedRow.Cells[1].Text)
                          select testlist;
        if (testdetails.Count() > 0)
        {
            //enable viewstate of updatebutton
            Session.Add("testid" ,int.Parse(grd_designation.SelectedRow.Cells[1].Text));
            btn_update.Visible = true;
            txt_TestName.Text = testdetails.First().TestName;
            txt_remark.Text = testdetails.First().Remark;
            txt_price.Text = testdetails.First().Price.ToString();
            txt_passmark.Text = testdetails.First().PassMark.ToString();
            txt_instruction.Text = testdetails.First().Instructions;
            drp_ReportType.SelectedValue = testdetails.First().ReportType;
            ddl_Org.SelectedValue = testdetails.First().OrganizationName.ToString();
            ddlStatus.SelectedValue = testdetails.First().Status.ToString();
            if (testdetails.First().GroupReportAccess == 1)
            {
                chbGroupReport.Checked = true;
            }
            else
            {
                chbGroupReport.Checked = false;
            }
        }
    }
}