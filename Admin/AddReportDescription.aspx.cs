using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Configuration;



public partial class Admin_AddReportDescription : System.Web.UI.Page
{
    CJDataClassesDataContext cjDataclass = new CJDataClassesDataContext();
    bool specialadmin = false;
    int OrganizationID = 0;
    string organizationName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["usertype"].ToString() == "SpecialAdmin")
            {
                lblOrganization.Visible = false; ddlOrganizationList.Visible = false;
                specialadmin = true; OrganizationID = int.Parse(Session["AdminOrganizationID"].ToString());

                if (Session["adminOrgName"] != null)
                    organizationName = Session["adminOrgName"].ToString();
                else
                {
                    var orgName = from orgDet in cjDataclass.Organizations
                                  where orgDet.OrganizationID == OrganizationID
                                  select orgDet;
                    if (orgName.Count() > 0)
                    { organizationName = orgName.First().Name.ToString(); Session["adminOrgName"] = organizationName; }

                }
                //FillTestList();
            }
            else
                ddlOrganizationList.DataBind();

            if (Session["orgIndex_report"] != null)
                ddlOrganizationList.SelectedIndex = int.Parse(Session["orgIndex_report"].ToString());
            FillTestList();
        }
    }
    protected void ddlOrganizationList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlOrganizationList.SelectedIndex > 0)
        {
            if (Session["orgIndex_report"] != null)
                if (Session["orgIndex_report"].ToString() != ddlOrganizationList.SelectedIndex.ToString())
                    Session["testIndex_report"] = null;
            Session["orgIndex_report"] = ddlOrganizationList.SelectedIndex.ToString();
            FillTestList();
        }
        else Session["orgIndex_report"] = null;
    }
    protected void ddlTestList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTestList.SelectedIndex > 0)
        {
            Session["testIndex_report"] = ddlTestList.SelectedIndex.ToString();
            FillReportDetails();
        }
        else Session["testIndex_report"] = null;
    }
    private void FillTestList()
    {
        int testindex = 0;
        if (Session["testIndex_report"] != null)
            testindex = int.Parse(Session["testIndex_report"].ToString());
        ddlTestList.Items.Clear();
        ListItem litem = new ListItem("-- Select --", "0");
        ddlTestList.Items.Add(litem);

        if (specialadmin == false)
            organizationName = ddlOrganizationList.SelectedItem.Text; OrganizationID = int.Parse(ddlOrganizationList.SelectedValue);

        if (ddlOrganizationList.SelectedIndex > 0 || specialadmin == true)
        {
            var Gettestdetails = from testdet in cjDataclass.TestLists
                                 where testdet.OrganizationName == OrganizationID 
                                 select testdet;
            if (Gettestdetails.Count() > 0)
            {
                ddlTestList.DataSource = Gettestdetails;
                ddlTestList.DataTextField = "TestName";
                ddlTestList.DataValueField = "TestId";
                ddlTestList.DataBind();
                if (testindex > 0)
                {
                    ddlTestList.SelectedIndex = testindex;
                    FillReportDetails();
                }
            }
        }
    }
    private void FillReportDetails()
    {
        int orgid = 0, testid = 0;

        //if(ddlOrganizationList.SelectedIndex>0)
        //    orgid=int.Parse(ddlOrganizationList.SelectedValue);
        if (specialadmin == false)
            OrganizationID = int.Parse(ddlOrganizationList.SelectedValue);

        if (ddlTestList.SelectedIndex > 0)
        {
            testid = int.Parse(ddlTestList.SelectedValue);
            var ReportTextDetails = from reportdet in cjDataclass.ReportDescriptions
                                    where reportdet.OrganizationId == OrganizationID && reportdet.TestId == testid
                                    select reportdet;
            if (ReportTextDetails.Count() > 0)
            {
                if (ReportTextDetails.First().Summary1 != null)
                    txtExeSummary1.Text = ReportTextDetails.First().Summary1.ToString();
                if (ReportTextDetails.First().Summary2 != null)
                    txtExeSummary2.Text = ReportTextDetails.First().Summary2.ToString();
                if (ReportTextDetails.First().Conclusion != null)
                    txtConclusion.Text = ReportTextDetails.First().Conclusion.ToString();
                if (ReportTextDetails.First().ReportType != null)
                    ddlSummaryGraph.SelectedValue = ReportTextDetails.First().ReportType.ToString();
                if (ReportTextDetails.First().DescriptiveReport != null)
                    txtDescriptiveRpt.Text = ReportTextDetails.First().DescriptiveReport.ToString();
                if (ReportTextDetails.First().ScoringType != null)
                    ddlScoringType.SelectedValue = ReportTextDetails.First().ScoringType.ToString();

                if (ReportTextDetails.First().ReportImage1 != null)
                {
                    txtimage1.Text = ReportTextDetails.First().ReportImage1.ToString();
                    Session["reportimage1"] = ReportTextDetails.First().ReportImage1.ToString();
                }
                if (ReportTextDetails.First().ReportImage2 != null)
                {
                    txtimage2.Text = ReportTextDetails.First().ReportImage2.ToString();
                    Session["reportimage2"] = ReportTextDetails.First().ReportImage2.ToString();
                }
            }
        }

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int userid = 0;
        int orgid = 0, testid = 0;
        //if (ddlOrganizationList.SelectedIndex > 0)
        //    orgid = int.Parse(ddlOrganizationList.SelectedValue);
        if (specialadmin == false)
            OrganizationID = int.Parse(ddlOrganizationList.SelectedValue);

        if (ddlTestList.SelectedIndex > 0)
            testid = int.Parse(ddlTestList.SelectedValue);
        if (OrganizationID > 0 && testid > 0)
        {
            if (ddlSummaryGraph.SelectedIndex <= 0) { lblMessage.Text = "Please select the Type of Graph.."; return; }

            if (Session["UserID"] != null)
                userid = int.Parse(Session["UserID"].ToString());
            if (txtConclusion.Text.Trim() != "" || txtExeSummary1.Text.Trim() != "" || txtExeSummary2.Text.Trim() != "" || txtDescriptiveRpt.Text.Trim() != "")
            {
                cjDataclass.AddReportDescriptions(0, OrganizationID, testid, txtExeSummary1.Text.Trim(), txtExeSummary2.Text.Trim(), txtConclusion.Text.Trim(), 1, userid, ddlSummaryGraph.SelectedValue, txtDescriptiveRpt.Text.Trim(), ddlScoringType.SelectedValue, txtimage1.Text, txtimage2.Text);
                saveImages();
                lblMessage.Text = "Saved succesfully";
                ClearControls();
            }
            else lblMessage.Text = "Please enter values for summary1/summary2/conclution fields";
        }
        else
            if (orgid <= 0)
                lblMessage.Text = "Please select an Organization";
            else lblMessage.Text = "Please select a Test";
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        ClearControls();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int orgid = 0, testid = 0;
        //if (ddlOrganizationList.SelectedIndex > 0)
        //    orgid = int.Parse(ddlOrganizationList.SelectedValue);
        if (specialadmin == false)
            OrganizationID = int.Parse(ddlOrganizationList.SelectedValue);

        if (ddlTestList.SelectedIndex > 0)
            testid = int.Parse(ddlTestList.SelectedValue);
        if (OrganizationID > 0 && testid > 0)
        {
            cjDataclass.DeleteReportDescriptions(OrganizationID, testid);
            deleteImages();
            lblMessage.Text = "Deletion Successfull";
            ClearControls();
        }
        else
            if (orgid <= 0)
                lblMessage.Text = "Please select an Organization";
            else lblMessage.Text = "Please select a Test";

    }
    private void ClearControls()
    {
        Session["testIndex_report"] = null; Session["orgIndex_report"] = null;
        ddlTestList.SelectedIndex = 0; ddlOrganizationList.SelectedIndex = 0;
        txtExeSummary1.Text = ""; txtExeSummary2.Text = ""; txtConclusion.Text = "";
        txtimage1.Text = ""; txtimage2.Text = ""; Session["reportimage1"] = null; Session["reportimage2"] = null;
    }
    protected void btnDeleteImage1_Click(object sender, EventArgs e)
    {
        if (txtimage1.Text != "")
        {
            if (Session["reportimage1"] != null)
                if (Session["reportimage1"].ToString() != txtimage1.Text)
                    deleteImage(Session["reportimage1"].ToString());


            deleteImage(txtimage1.Text); lblMessage.Text = "Image deleted successfully"; Session["reportimage1"] = null;
        }
        else lblMessage.Text = "no image found";
    }
    protected void btnDeleteImage2_Click(object sender, EventArgs e)
    {
        if (txtimage2.Text != "")
        {
            if (Session["reportimage2"] != null)
                if (Session["reportimage2"].ToString() != txtimage2.Text)
                    deleteImage(Session["reportimage2"].ToString());


            deleteImage(txtimage2.Text); lblMessage.Text = "Image deleted successfully"; Session["reportimage2"] = null;
        }
        else lblMessage.Text = "no image found";
    }
    private void saveImages()
    {// 08102010 bipson
        if (txtimage1.Text != "")
        {
            if (Session["reportimage1"] != null)
                if (Session["reportimage1"].ToString() != txtimage1.Text)
                    deleteImage(Session["reportimage1"].ToString());

            saveImage(txtimage1.Text);
        }
        if (txtimage2.Text != "")
        {
            if (Session["reportimage2"] != null)
                if (Session["reportimage2"].ToString() != txtimage2.Text)
                    deleteImage(Session["reportimage2"].ToString());

            saveImage(txtimage2.Text);
        }
        Session["reportimage1"] = null; Session["reportimage2"] = null;
    }
    private void saveImage(string filename)
    {
        // 08102010 bipson

        string sourcepath, destinationpath;
        sourcepath = "UploadedImages\\" + filename;
        destinationpath = "QuestionAnswerFiles\\InstructionImages\\" + filename;
        if (File.Exists(Server.MapPath(sourcepath)))
        {
            if (!File.Exists(Server.MapPath(destinationpath)))
                File.Copy(Server.MapPath(sourcepath), Server.MapPath(destinationpath));
            File.Delete(Server.MapPath(sourcepath));
        }
    }
    private void deleteImages()
    {// 08102010 bipson
        if (txtimage1.Text != "")
        {
            if (Session["reportimage1"] != null)
                if (Session["reportimage1"].ToString() != txtimage1.Text)
                    deleteImage(Session["reportimage1"].ToString());


            deleteImage(txtimage1.Text);

        }
        if (txtimage2.Text != "")
        {
            if (Session["reportimage2"] != null)
                if (Session["reportimage2"].ToString() != txtimage2.Text)
                    deleteImage(Session["reportimage2"].ToString());

            deleteImage(txtimage2.Text);
        }
        Session["reportimage1"] = null; Session["reportimage2"] = null;
    }
    private void deleteImage(string imagename)
    {
        // 08102010 bipson

        string sourcepath, destinationpath;
        sourcepath = "UploadedImages\\" + imagename;
        destinationpath = "QuestionAnswerFiles\\InstructionImages\\" + imagename;
        if (File.Exists(Server.MapPath(sourcepath)))
            File.Delete(Server.MapPath(sourcepath));
        else if (File.Exists(Server.MapPath(destinationpath)))
            File.Delete(Server.MapPath(destinationpath));
    }

}