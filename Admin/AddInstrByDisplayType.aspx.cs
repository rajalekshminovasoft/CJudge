using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_AddInstrByDisplayType : System.Web.UI.Page
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
                lblOrganization.Visible = false; ddlOrganization.Visible = false;
                specialadmin = true; OrganizationID = int.Parse(Session["AdminOrganizationID"].ToString());

                bool perassigned = fillQuestionTypes();

                if (perassigned == false)
                { lblMessage.Text = "Please contact your site admin to get permissions to add questions"; return; }
            }
            else ddlOrganization.DataBind();

            if (Session["QuesTypeIndex"] != null)
            {
                ddlQuestionType.SelectedIndex = int.Parse(Session["QuesTypeIndex"].ToString());
                FillDisplayType();
            }
            if (Session["DisplyIndex"] != null)
            {
                ddlDisplayType.SelectedIndex = int.Parse(Session["DisplyIndex"].ToString());
            }
        }
        
        
    }
    private bool fillQuestionTypes()
    {
        bool perassigned = false;
        ListItem litem = new ListItem("-- select --", "0");
        ddlQuestionType.Items.Clear();
        ddlQuestionType.Items.Add(litem);

        var getQuestionTypes = from questiontypes in cjDataclass.OrganizationQuestionTypes where questiontypes.OrganizationId == OrganizationID select questiontypes;
        if (getQuestionTypes.Count() > 0)
        {
            //int a = 0, b = 0;
            foreach (var orgQuestionTypes in getQuestionTypes)
            {
                string questiontype = orgQuestionTypes.QuestionTypeName.ToString();
                if (questiontype == "MemTestWords")
                {
                    questiontype = "7";
                    litem = new ListItem(orgQuestionTypes.QuestionTypeDescription.ToString(), questiontype);
                    ddlQuestionType.Items.Add(litem);
                    perassigned = true; //a = 1;
                }
                else if (questiontype == "MemTestImages")
                {
                    questiontype = "8";
                    litem = new ListItem(orgQuestionTypes.QuestionTypeDescription.ToString(), questiontype);
                    ddlQuestionType.Items.Add(litem);
                    perassigned = true; //b = 1;
                }

            }
        }
        return perassigned;

    }
    private void FillDisplayType()
    {
        int index = 0;
        if (Session["DisplyIndex"] != null)
            index = int.Parse(Session["DisplyIndex"].ToString());
        else
        {

            ddlDisplayType.Items.Clear();
            ListItem litem = new ListItem("-- Select --", "0");
            ddlDisplayType.Items.Add(litem);
            if (ddlQuestionType.SelectedIndex > 0)
            {
                litem = new ListItem("Static", "1");
                ddlDisplayType.Items.Add(litem);
                litem = new ListItem("Sequence", "2");
                ddlDisplayType.Items.Add(litem);
                if (ddlQuestionType.SelectedValue == "7")
                {
                    litem = new ListItem("Passage", "3");
                    ddlDisplayType.Items.Add(litem);
                }
            }
        }
        
    }
    protected void ddlQuestionType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlQuestionType.SelectedIndex > 0)
        {
            if (Session["QuesTypeIndex"] != null)
                if (ddlQuestionType.SelectedIndex.ToString() != Session["QuesTypeIndex"].ToString())
                    Session["DisplyIndex"] = null;

            Session["QuesTypeIndex"] = ddlQuestionType.SelectedIndex.ToString();
            FillDisplayType();
        }
        else Session["QuesTypeIndex"] = null;
    }
    //protected void ddlDisplayType_SelectedIndexChanged(object sender, EventArgs e)
    //{
        //Session["DisplyIndex"] = ddlDisplayType.SelectedIndex.ToString();

        //if (ddlDisplayType.SelectedIndex > 0)
        //{
        //    if (Session["DisplyIndex"] != null)
        //    {
        //        if (Session["DisplyIndex"].ToString() != ddlDisplayType.SelectedIndex.ToString())
        //        { txtInstructions.Text = ""; FillInstructionDetails(); }
        //    }
        //    else { txtInstructions.Text = ""; FillInstructionDetails(); }
        //    Session["DisplyIndex"] = ddlDisplayType.SelectedIndex.ToString();
        //}
        //else Session["DisplyIndex"] = null;
    //}
    private void FillInstructionDetails()
    {
        int adminaccess = 0;
        if (specialadmin == false)
        {
            adminaccess = 1;
            if (ddlOrganization.SelectedIndex > 0)
                OrganizationID = int.Parse(ddlOrganization.SelectedValue);
            else return;
        }

        int quesTypeId = 0, dispTypeId = 0, userid = 0;
        if (ddlQuestionType.SelectedIndex > 0)
            quesTypeId = int.Parse(ddlQuestionType.SelectedValue);
        if (ddlDisplayType.SelectedIndex > 0)
            dispTypeId = int.Parse(ddlDisplayType.SelectedValue);
        if (quesTypeId > 0 && dispTypeId > 0)
        {
            var GetInstructiondetails = from Instructiondet in cjDataclass.InstructionByDisplayTypes
                                        where Instructiondet.CategoryId == quesTypeId && Instructiondet.DisplayTypeId == dispTypeId && Instructiondet.AdminAccess == adminaccess && Instructiondet.OrganizationId == OrganizationID
                                        select Instructiondet;
            if (GetInstructiondetails.Count() > 0)
            {
                txtInstructions.Text = GetInstructiondetails.First().Instructions.ToString();
            }
        }
    }
    protected void ddlOrganization_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlOrganization.SelectedIndex > 0)
            if (Session["OrgInstructIndex"] != null)
                if (Session["OrgInstructIndex"].ToString() == ddlOrganization.SelectedIndex.ToString())
                    return;

        ClearControls();
        Session["OrgInstructIndex"] = ddlOrganization.SelectedIndex;
    }
    private void ClearControls()
    {
        txtInstructions.Text = "";
        ddlQuestionType.SelectedIndex = 0; ddlDisplayType.SelectedIndex = 0;
        Session["QuesTypeIndex"] = null; Session["DisplyIndex"] = null;
        FillDisplayType();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int quesTypeId = 0, dispTypeId = 0, userid = 0;
        if (ddlQuestionType.SelectedIndex > 0)
            quesTypeId = int.Parse(ddlQuestionType.SelectedValue);
        if (ddlDisplayType.SelectedIndex > 0)
            dispTypeId = int.Parse(ddlDisplayType.SelectedValue);
        if (quesTypeId > 0 && dispTypeId > 0)
        {
            if (txtInstructions.Text.Trim() == "") { lblMessage.Text = "Please enter Instructions"; return; }
            if (Session["UserID"] != null)
                userid = int.Parse(Session["UserID"].ToString());

            int adminaccess = 0;
            if (specialadmin == false)
            {
                adminaccess = 1;
                if (ddlOrganization.SelectedIndex > 0)
                    OrganizationID = int.Parse(ddlOrganization.SelectedValue);
                else { lblMessage.Text = "Please select Organization"; return; }
            }

            cjDataclass.AddInstructionByDisplayType(0, quesTypeId, dispTypeId, txtInstructions.Text.Trim(), 1, userid, adminaccess, OrganizationID);
            lblMessage.Text = "Saved Successfully";
            ClearControls();
        }
        else
            if (quesTypeId <= 0)
                lblMessage.Text = "Please select Question Type";
            else lblMessage.Text = "Please select Display Type";
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        ClearControls();
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int adminaccess = 0;
        if (specialadmin == false)
        {
            adminaccess = 1;
            if (ddlOrganization.SelectedIndex > 0)
                OrganizationID = int.Parse(ddlOrganization.SelectedValue);
            else { lblMessage.Text = "Please select Organization"; return; }
        }

        int quesTypeId = 0, dispTypeId = 0, userid = 0;
        if (ddlQuestionType.SelectedIndex > 0)
            quesTypeId = int.Parse(ddlQuestionType.SelectedValue);
        if (ddlDisplayType.SelectedIndex > 0)
            dispTypeId = int.Parse(ddlDisplayType.SelectedValue);
        if (quesTypeId > 0 && dispTypeId > 0)
        {
            cjDataclass.DeleteInstructionByDisplayType(quesTypeId, dispTypeId, adminaccess, OrganizationID);
            lblMessage.Text = "Deleted Successfully";
            ClearControls();
        }
        else
            if (quesTypeId <= 0)
                lblMessage.Text = "Please select Question Type";
            else lblMessage.Text = "Please select Display Type";

    }
    protected void ddlDisplayType_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["DisplyIndex"] = "";
        txtInstructions.Text = "";
        Session["DisplyIndex"] = ddlDisplayType.SelectedIndex.ToString();
        FillInstructionDetails();
    }
}