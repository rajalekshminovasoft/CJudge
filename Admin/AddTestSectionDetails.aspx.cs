using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_AddTestSectionDetails : System.Web.UI.Page
{
    CJDataClassesDataContext cjDataclass = new CJDataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Logged"].ToString() == "False")
            Response.Redirect("../Default.aspx");
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (txtSectionName.Text != "")
        {
            cjDataclass.AddTestSectionsList(0, int.Parse(drp_TestName.SelectedValue), txtSectionName.Text, 1, 1, 1);
            grd_designation.DataBind();
            lblMessage.Text = "Test Section Added";
            txtSectionName.Text = "";
        }
    }
    protected void grd_designation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string item = e.Row.Cells[1].Text;
            foreach (Button button in e.Row.Cells[1].Controls.OfType<Button>())
            {
                if (button.CommandName == "Delete")
                {
                    button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; };";
                }
            }
        }
    }
    protected void btnAddSectionBands_Click(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        if (txtSectionMarksFrom.Text != "" && txtSectionMarksTo.Text != "" & txtSectionDisplayName.Text != "" && txtSectionBenchMark.Text != "" && drp_TestName.SelectedIndex != 0)
        {
            int testid = 0; int sectionid = 0;
            testid = int.Parse(drp_TestName.SelectedValue); sectionid = int.Parse(ddlSectionNameList.SelectedValue);
            int markfrom = 0, markto = 0, benchmark = 0;
            markfrom = int.Parse(txtSectionMarksFrom.Text.Trim()); markto = int.Parse(txtSectionMarksTo.Text.Trim());
            benchmark = int.Parse(txtSectionBenchMark.Text.Trim());
            int userid = int.Parse(Session["UserID"].ToString());
            cjDataclass.AddTestSectionResultBands(0, testid, sectionid, benchmark, markfrom, markto, txtSectionDisplayName.Text.Trim(), "", 1, userid);
            gvwSectionBands.DataBind();
            lblMessage.Text = "Details Added ";
        }
        else
        {
            lblMessage.Text = "Please Enter All Needed Details Including TestName and Organization from Selection list";
        }
    }
    protected void gvwSectionBands_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string item = e.Row.Cells[1].Text;
            foreach (Button button in e.Row.Cells[1].Controls.OfType<Button>())
            {
                if (button.CommandName == "Delete")
                {
                    button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; };";
                }
            }
        }
    }
    protected void gvwSectionBands_SelectedIndexChanged(object sender, EventArgs e)
    {
        //var Section = from Sectn in cjDataclass.TestSectionResultBands
        //                  where Sectn.SectionBandId== int.Parse(gvwSectionBands.SelectedRow.Cells[2].Text)
        //                  select Sectn ;
        //if (Section.Count() > 0)
        //{
        //    //enable viewstate of updatebutton
        //    Session.Add("id", int.Parse(gvwSectionBands.SelectedRow.Cells[2].Text));
        //    btn_update.Visible = true;
        //    drp_TestName.SelectedValue = Section.First().TestId.ToString();
        //    ddlSectionNameList.SelectedValue = Section.First().SectionId.ToString();
        //    txtSectionBenchMark.Text = Section.First().BenchMark.ToString();
        //    txtSectionDisplayName.Text = Section.First().DisplayName.ToString();
        //    txtSectionMarksFrom.Text = Section.First().MarkFrom.ToString();
        //    txtSectionMarksTo.Text = Section.First().MarkTo.ToString();
                       
        //}
    }
    protected void btn_update_Click(object sender, EventArgs e)
    {

    }
}