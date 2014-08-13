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

public partial class Admin_AddInstructionByVariable : System.Web.UI.Page
{
    CJDataClassesDataContext cjDataclass = new CJDataClassesDataContext();
    DBManagementClass clsClasses = new DBManagementClass();
    int userid = 0;

    bool specialadmin = false;
    int OrganizationID = 0;
    string organizationName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["usertype"].ToString() == "SpecialAdmin")
            {
                ddlOrganizations.Visible = false; lblOrganization.Visible = false;
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
                bool perassigned = false;
                ListItem litem = new ListItem("-- select --", "0");
                ddlCategory.Items.Clear();
                ddlCategory.Items.Add(litem);

                var getQuestionTypes = from questiontypes in cjDataclass.OrganizationQuestionTypes where questiontypes.OrganizationId == OrganizationID select questiontypes;
                if (getQuestionTypes.Count() > 0)
                {
                    foreach (var orgQuestionTypes in getQuestionTypes)
                    {
                        litem = new ListItem(orgQuestionTypes.QuestionTypeDescription.ToString(), orgQuestionTypes.QuestionTypeName.ToString());
                        ddlCategory.Items.Add(litem);
                        perassigned = true;
                    }
                }
                if (perassigned == false)
                { lblMessage.Text = "Please contact your site admin to approve question types to add variablewise instructions"; return; }


                FillTestList();
            }
            else FillOrganizationList();

            if (Session["UserID"] != null)
                userid = int.Parse(Session["UserID"].ToString());
        }
    }
    private void FillTestList()
    {
        ListItem listnew;
        listnew = new ListItem("--select--", "0");
        ddlTestNameList.Items.Clear();
        ddlTestNameList.Items.Add(listnew);
        int testIndex = 0;
        if (Session["TestIndex_Intro"] != null)
        {
            testIndex = int.Parse(Session["TestIndex_Intro"].ToString());
        }
        if (specialadmin == false)
            organizationName = ddlOrganizations.SelectedItem.Text; OrganizationID = int.Parse(ddlOrganizations.SelectedValue);

        var testListDetails = from testlistsdet in cjDataclass.TestLists
                              where testlistsdet.OrganizationName == OrganizationID 
                              select testlistsdet;

        ddlTestNameList.DataSource = testListDetails;
        ddlTestNameList.DataTextField = "TestName";
        ddlTestNameList.DataValueField = "TestId";
        ddlTestNameList.DataBind();
        if (testIndex > 0)
        { ddlTestNameList.SelectedIndex = testIndex; FillTestSectionList(); }
        else { FreeTextBox1.Text = ""; }// FillInstructionDetails(); }
    }
    protected void ddlOrganizations_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlOrganizations.SelectedIndex > 0)
        {
            if (Session["OrgIndex_Intro"] != null)
                if (Session["OrgIndex_Intro"].ToString() == ddlOrganizations.SelectedIndex.ToString())
                    return;
            ClearListBoxes(0);
            Session["OrgIndex_Intro"] = ddlOrganizations.SelectedIndex.ToString(); FillTestList();
        }
        else { Session["OrgIndex_Intro"] = null; ClearListBoxes(0); }
    }
    protected void ddlTestNameList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTestNameList.SelectedIndex > 0)
        {
            if (Session["TestIndex_Intro"] != null)
                if (Session["TestIndex_Intro"].ToString() == ddlTestNameList.SelectedIndex.ToString()) return;

            ClearListBoxes(1);
            Session["TestIndex_Intro"] = ddlTestNameList.SelectedIndex.ToString(); FillTestSectionList();
        }
        else { Session["TestIndex_Intro"] = null; ClearListBoxes(1); }
    }
    protected void ddlTestSectionList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTestSectionList.SelectedIndex > 0)
        {
            if (Session["TestSectionIndex"] != null)
                if (Session["TestSectionIndex"].ToString() == ddlTestSectionList.SelectedIndex.ToString()) return;

            ClearListBoxes(2);
            Session["TestSectionIndex"] = ddlTestSectionList.SelectedIndex.ToString(); FillSessionslist();
        }// FillInstructionDetails(); }
        else { Session["TestSectionIndex"] = null; ClearListBoxes(2); }
    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCategory.SelectedIndex > 0)
        {
            if (Session["categoryIndex"] != null)
                if (Session["categoryIndex"].ToString() == ddlCategory.SelectedIndex.ToString())
                    return;

            FreeTextBox1.Text = "";
            Session["categoryIndex"] = ddlCategory.SelectedIndex.ToString(); FillInstructionDetails();
        }
        else
        {
            FreeTextBox1.Text = "";
            Session["categoryIndex"] = null;
        }
    }
    protected void ddlFirstLevelVariableList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlFirstLevelVariableList.SelectedIndex > 0)
        {
            if (Session["TestFirstVariableIndex"] != null)
                if (Session["TestFirstVariableIndex"].ToString() == ddlFirstLevelVariableList.SelectedIndex.ToString()) return;

            ClearListBoxes(3);
            Session["TestFirstVariableIndex"] = ddlFirstLevelVariableList.SelectedIndex.ToString(); FillSubLevel1Sections();
        }// FillInstructionDetails(); }
        else { Session["TestFirstVariableIndex"] = null; ClearListBoxes(3); }
    }
    protected void ddlSecondLevelVariableList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSecondLevelVariableList.SelectedIndex > 0)
        {
            if (Session["TestSecondVariableIndex"] != null)
                if (Session["TestSecondVariableIndex"].ToString() == ddlSecondLevelVariableList.SelectedIndex.ToString()) return;

            ClearListBoxes(4);
            Session["TestSecondVariableIndex"] = ddlSecondLevelVariableList.SelectedIndex.ToString(); FillInstructionDetails();
        }// FillInstructionDetails(); }
        else { Session["TestSecondVariableIndex"] = null; ClearListBoxes(4); }
    }
    private void ClearListBoxes(int index)
    {
        if (index == 0)
        //ddlOrganizations.SelectedIndex = 0; Session["OrgIndex_Intro"] = null;
        {
            ddlTestNameList.SelectedIndex = 0; Session["TestIndex_Intro"] = null;
            ddlTestNameList.Items.Clear();
            ListItem litem = new ListItem("-- Select --", "0");
            ddlTestNameList.Items.Add(litem);
        }
        if (index == 0 || index == 1)
        {
            ddlTestSectionList.SelectedIndex = 0; Session["TestSectionIndex"] = null;
            ddlTestSectionList.Items.Clear();
            ListItem litem = new ListItem("-- Select --", "0");
            ddlTestSectionList.Items.Add(litem);
        }
        if (index == 0 || index == 1 || index == 2)
        {
            ddlFirstLevelVariableList.SelectedIndex = 0; Session["TestFirstVariableIndex"] = null;
            ddlFirstLevelVariableList.Items.Clear();
            ListItem litem = new ListItem("-- Select --", "0");
            ddlFirstLevelVariableList.Items.Add(litem);
        }
        if (index == 0 || index == 1 || index == 2 || index == 3)
        {
            ddlSecondLevelVariableList.SelectedIndex = 0; Session["TestSecondVariableIndex"] = null;
            ddlSecondLevelVariableList.Items.Clear();
            ListItem litem = new ListItem("-- Select --", "0");
            ddlSecondLevelVariableList.Items.Add(litem);
        }
        if (index == 0 || index == 1 || index == 2 || index == 3 || index == 4)
        { ddlCategory.SelectedIndex = 0; Session["categoryIndex"] = null; }

        FreeTextBox1.Text = "";


    }
    private void ClearValues()
    {
        FreeTextBox1.Text = "";
        FreeTextBox2.Text = "";
        FreeTextBox3.Text = "";
        //txtfilename1.Value = "";
        //txtfilename2.Value = "";
    }
    private void FillOrganizationList()
    {
        ListItem listnew;
        listnew = new ListItem("--select--", "0");
        ddlOrganizations.Items.Clear();
        ddlOrganizations.Items.Add(listnew);
        int orgIndex = 0;

        if (Session["OrgIndex_Intro"] != null)
        {
            orgIndex = int.Parse(Session["OrgIndex_Intro"].ToString());
        }
        ddlOrganizations.DataSource = LinqOrganizationList;
        ddlOrganizations.DataTextField = "Name";
        ddlOrganizations.DataValueField = "OrganizationID";
        ddlOrganizations.DataBind();
        if (orgIndex > 0)
        { ddlOrganizations.SelectedIndex = orgIndex; FillTestList(); }
        else { FreeTextBox1.Text = ""; }// FillInstructionDetails(); }

    }
    private void FillInstructionDetails()
    {
        ClearValues();
        if (ddlSecondLevelVariableList.SelectedIndex >= 0)
        {

            if (ddlCategory.SelectedIndex > 0)
            {

                Session["instructionimage1"] = null; Session["instructionimage2"] = null;
                var Instructiondetails = from instructiondet in cjDataclass.TestSectionVariablewiseInstructions
                                         where instructiondet.OrganizationId == int.Parse(ddlOrganizations.SelectedValue) &&
                                         instructiondet.TestId == int.Parse(ddlTestNameList.SelectedValue) &&
                                         instructiondet.TestSectionId == int.Parse(ddlTestSectionList.SelectedValue) &&
                                         instructiondet.FirstVariableId == int.Parse(ddlFirstLevelVariableList.SelectedValue) &&
                                         instructiondet.SecondVariableId == int.Parse(ddlSecondLevelVariableList.SelectedValue) &&
                                         instructiondet.CategoryId == int.Parse(ddlCategory.SelectedValue)
                                         select instructiondet;
                if (Instructiondetails.Count() > 0)
                {
                    if (Instructiondetails.First().InstructionDetails != null)
                        FreeTextBox1.Text = Instructiondetails.First().InstructionDetails.ToString();
                    if (Instructiondetails.First().Status != null)
                        if (Instructiondetails.First().Status.ToString() == "1")
                            ddlStatus.SelectedIndex = 0;
                        else ddlStatus.SelectedIndex = 1;

                    if (Instructiondetails.First().InstructionImage1 != null)
                    {
                        txtfilename1.Text = Instructiondetails.First().InstructionImage1.ToString();
                        Session["instructionimage1"] = Instructiondetails.First().InstructionImage1.ToString();
                    }
                    if (Instructiondetails.First().InstructionDetails2 != null)
                        FreeTextBox2.Text = Instructiondetails.First().InstructionDetails2.ToString();
                    if (Instructiondetails.First().InstructionImage2 != null)
                    {
                        txtfilename2.Text = Instructiondetails.First().InstructionImage2.ToString();
                        Session["instructionimage2"] = Instructiondetails.First().InstructionImage2.ToString();
                    }
                    if (Instructiondetails.First().InstructionDetails3 != null)
                        FreeTextBox3.Text = Instructiondetails.First().InstructionDetails3.ToString();
                }
            }
        }
        else
        {
            if (ddlFirstLevelVariableList.SelectedIndex >= 0)
                if (ddlCategory.SelectedIndex > 0)
                {
                    Session["instructionimage1"] = null; Session["instructionimage2"] = null;
                    var Instructiondetails = from instructiondet in cjDataclass.TestSectionVariablewiseInstructions
                                             where instructiondet.OrganizationId == int.Parse(ddlOrganizations.SelectedValue) &&
                                             instructiondet.TestId == int.Parse(ddlTestNameList.SelectedValue) &&
                                             instructiondet.TestSectionId == int.Parse(ddlTestSectionList.SelectedValue) &&
                                             instructiondet.FirstVariableId == int.Parse(ddlFirstLevelVariableList.SelectedValue) &&
                                             instructiondet.CategoryId == int.Parse(ddlCategory.SelectedValue)
                                             select instructiondet;
                    if (Instructiondetails.Count() > 0)
                    {
                        if (Instructiondetails.First().InstructionDetails != null)
                            FreeTextBox1.Text = Instructiondetails.First().InstructionDetails.ToString();
                        if (Instructiondetails.First().Status != null)
                            if (Instructiondetails.First().Status.ToString() == "1")
                                ddlStatus.SelectedIndex = 0;
                            else ddlStatus.SelectedIndex = 1;

                        if (Instructiondetails.First().InstructionImage1 != null)
                        {
                            txtfilename1.Text = Instructiondetails.First().InstructionImage1.ToString();
                            Session["instructionimage1"] = Instructiondetails.First().InstructionImage1.ToString();
                        }
                        if (Instructiondetails.First().InstructionDetails2 != null)
                            FreeTextBox2.Text = Instructiondetails.First().InstructionDetails2.ToString();
                        if (Instructiondetails.First().InstructionImage2 != null)
                        {
                            txtfilename2.Text = Instructiondetails.First().InstructionImage2.ToString();
                            Session["instructionimage2"] = Instructiondetails.First().InstructionImage2.ToString();
                        }
                        if (Instructiondetails.First().InstructionDetails3 != null)
                            FreeTextBox3.Text = Instructiondetails.First().InstructionDetails3.ToString();

                    }
                }
        }
    }
    private void SaveFile(string filenameNew, string oldname)
    {

        //string fname = "UploadedImages/" + filenameNew;
        //Server.MapPath(fname);

        //string savePath = "ima;ges/TestImages/" + filenameNew;
        string imagePath = "QuestionAnswerFiles/InstructionImages/" + oldname;
        string FilePath = "UploadedImages/" + filenameNew;
        //string FilePath =  filenameNew;
        //Server.MapPath(FilePath);
        //string newfilename = filenameNew.Replace(" ", "");
        //string newfilename1 = newfilename.Replace(" ", "");
        //string newfilename2 = newfilename1.Replace(" ", "");
        string savePath = "QuestionAnswerFiles/InstructionImages/" + GetImageNameWithoutSpace(filenameNew);
        
        if (oldname != "")
        {
            if (File.Exists(Server.MapPath(imagePath)))
            { File.Delete(Server.MapPath(imagePath)); }
        }
        File.Copy(Server.MapPath(FilePath), Server.MapPath(savePath));
        //File.Copy((FilePath), (savePath));
        File.Delete(Server.MapPath(FilePath));
    }
    private string GetImageNameWithoutSpace(string filename)
    {
        string newfilename = filename.Replace(" ", "");
        string newfilename1 = newfilename.Replace(" ", "");
        string newfilename2 = newfilename1.Replace(" ", "");
        //string savePath = "images/TestImages/" + newfilename2;
        return newfilename2;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (FreeTextBox1.Text != "" || FreeTextBox2.Text != "" || FreeTextBox3.Text != "")
        {
            if (ddlFirstLevelVariableList.SelectedIndex <= 0 || ddlCategory.SelectedIndex <= 0)
            { lblMessage.Text = "Please select variable/category"; return; }
            bool updation = false;
            string imagefile1 = "", imagefile2 = "", oldfilename = "";
            //imagefile1 = txtfilename1.Value.Trim(); imagefile2 = txtfilename2.Value.Trim();
            if (FileUpload1.HasFile)
            {
                if (Session["instructionimage1"] != null)
                {
                    if (Session["instructionimage1"].ToString() != FileUpload1.FileName.Trim())
                    {
                        imagefile1 = GetImageNameWithoutSpace(FileUpload1.FileName.Trim());
                        oldfilename = Session["instructionimage1"].ToString();
                        string imagePath = "QuestionAnswerFiles/InstructionImages/" + FileUpload1.FileName.Trim();
                        FileUpload1.SaveAs(imagePath);
                        SaveFile(FileUpload1.FileName.Trim(), oldfilename);
                        updation = true;
                    }
                    else
                    {
                        imagefile1 = FileUpload1.FileName.Trim();
                    }
                }
                else
                {
                    if (FileUpload1.HasFile )
                    {

                        //SaveFile(FileUpload1.FileName.Trim(), oldfilename);
                        imagefile1 = GetImageNameWithoutSpace(FileUpload1.FileName.Trim());
                    }
                }
            }

            oldfilename = "";
            if (FileUpload2.HasFile )
            {
                if (Session["instructionimage2"] != null)
                {
                    if (Session["instructionimage2"].ToString() != FileUpload2.FileName.Trim())
                    {
                        imagefile2 = GetImageNameWithoutSpace(FileUpload2.FileName.Trim());
                        oldfilename = Session["instructionimage2"].ToString();
                        string imagefilePath = FileUpload2.PostedFile.FileName;
                        String[] strs = FileUpload2.PostedFile.FileName.Split(new char[] { '\\', '\\' });
                        if (strs.Length > 0)
                        {
                            String imageFleName = strs[strs.Length - 1];
                            String[] testImg = imageFleName.Split(new char[] { '.' });
                            int index = testImg.Count() - 1;
                            FileUpload2.PostedFile.SaveAs(Server.MapPath("UploadedImages/" + imageFleName));
                        }

                        //string imagePath = "QuestionAnswerFiles/InstructionImages/" + FileUpload2.FileName.Trim();
                        //FileUpload2.SaveAs(imagePath);
                        SaveFile(FileUpload2.FileName.Trim(), oldfilename);
                        updation = true;
                    }
                    else
                    {
                        imagefile2 = FileUpload2.FileName.Trim();
                    }
                }
                else
                {
                    if (FileUpload2.HasFile )
                    {
                        //string imagePath = "QuestionAnswerFiles/InstructionImages/" + FileUpload2.FileName.Trim();
                        //FileUpload2.SaveAs(imagePath);
                        SaveFile(FileUpload2.FileName.Trim(), oldfilename);
                        imagefile2 = GetImageNameWithoutSpace(FileUpload2.FileName.Trim());
                    }
                }
            }
            cjDataclass.AddTestSectionVariablewiseInstructions(0, FreeTextBox1.Text, int.Parse(ddlOrganizations.SelectedValue), int.Parse(ddlTestNameList.SelectedValue),
               int.Parse(ddlTestSectionList.SelectedValue), int.Parse(ddlFirstLevelVariableList.SelectedValue), int.Parse(ddlSecondLevelVariableList.SelectedValue),
               int.Parse(ddlCategory.SelectedValue), int.Parse(ddlStatus.SelectedValue), userid, imagefile1, FreeTextBox2.Text, imagefile2, FreeTextBox3.Text);

            lblMessage.Text = "Saved Successfully"; FreeTextBox1.Text = ""; ddlCategory.SelectedIndex = 0; Session["categoryIndex"] = null;
            FreeTextBox2.Text = ""; FreeTextBox3.Text = ""; 

            Session["instructionimage1"] = null; Session["instructionimage2"] = null;
        }
        else lblMessage.Text = "Enter Instruction details";
    }
    private bool DeleteFile(string filename)
    {
        bool deletionsuccess = false;
        string sourcepath, destinationpath;
        sourcepath = "UploadedImages/" + filename;
        destinationpath = "QuestionAnswerFiles/InstructionImages/" + filename;
        if (File.Exists(Server.MapPath(sourcepath)))
        {
            if (File.Exists(Server.MapPath(sourcepath)))
            { File.Delete(Server.MapPath(sourcepath)); deletionsuccess = true; }
        }
        else { if (File.Exists(Server.MapPath(destinationpath))) { File.Delete(Server.MapPath(destinationpath)); deletionsuccess = true; } }

        return deletionsuccess;
    }
    protected void btnDeleteImage1_Click(object sender, EventArgs e)
    {
        if (txtfilename1.Text.Trim() != "")
        {
            if (DeleteFile(txtfilename1.Text.Trim()) == true)
            { lblMessage.Text = "File deleted successfully.."; txtfilename1.Text = ""; }
            else lblMessage.Text = "File not found..";
        }
        else lblMessage.Text = "Please select a file";
    }
    protected void btnDeleteImage2_Click(object sender, EventArgs e)
    {
        if (txtfilename1.Text.Trim()!="")
        {
            if (DeleteFile(txtfilename2.Text.Trim()) == true)
            { lblMessage.Text = "File deleted successfully.."; txtfilename2.Text = ""; }
            else lblMessage.Text = "File not found..";
        }
        else lblMessage.Text = "Please select a file";
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        ddlOrganizations.SelectedIndex = 0; Session["OrgIndex_Intro"] = null;
        ClearListBoxes(0);
        FreeTextBox2.Text = ""; FreeTextBox3.Text = ""; txtfilename1.Text = ""; txtfilename2.Text = "";
        Session["instructionimage1"] = null; Session["instructionimage2"] = null;
        //ddlTestNameList.SelectedIndex = 0; Session["TestIndex_Intro"] = null;
        //ddlTestSectionList.SelectedIndex = 0; Session["TestSectionIndex"] = null;
        //ddlFirstLevelVariableList.SelectedIndex = 0; Session["TestFirstVariableIndex"] = null;
        //ddlSecondLevelVariableList.SelectedIndex = 0; Session["TestSecondVariableIndex"] = null;
        //ddlCategory.SelectedIndex = 0; Session["categoryIndex"] = null;
        //FreeTextBox1.Text = "";
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (FreeTextBox1.Text.Trim() != "" || FreeTextBox2.Text != "" || FreeTextBox3.Text != "")
        {
            cjDataclass.DeleteTestSectionVariablewiseInstructions(int.Parse(ddlOrganizations.SelectedValue), int.Parse(ddlTestNameList.SelectedValue),
               int.Parse(ddlTestSectionList.SelectedValue), int.Parse(ddlFirstLevelVariableList.SelectedValue), int.Parse(ddlSecondLevelVariableList.SelectedValue),
               int.Parse(ddlCategory.SelectedValue));
            if (txtfilename1.Text != "")
            {
                DeleteFile(txtfilename1.Text);
            }
            if (txtfilename2.Text != "")
            {
                DeleteFile(txtfilename2.Text);
            }
            lblMessage.Text = "Deletion Successfull"; FreeTextBox1.Text = ""; ddlCategory.SelectedIndex = 0; Session["categoryIndex"] = null;
            FreeTextBox2.Text = ""; FreeTextBox3.Text = ""; txtfilename1.Text = ""; txtfilename2.Text = "";
            Session["instructionimage1"] = null; Session["instructionimage2"] = null;
        }
        else lblMessage.Text = "Please select an Instruction";
    }
    private void FillTestSectionList()
    {
        ddlTestSectionList.Items.Clear();
        ListItem litem = new ListItem("-- Select --", "0");
        ddlTestSectionList.Items.Add(litem);
        if (ddlTestNameList.SelectedIndex > 0)
        {
            LinqTestSectionList.Where = "TestId=" + ddlTestNameList.SelectedValue;
            ddlTestSectionList.DataSource = LinqTestSectionList;
            ddlTestSectionList.DataTextField = "SectionName";
            ddlTestSectionList.DataValueField = "TestSectionId";
            ddlTestSectionList.DataBind();
            if (Session["TestSectionIndex"] != null)
            {
                ddlTestSectionList.SelectedIndex = int.Parse(Session["TestSectionIndex"].ToString());
                FillSessionslist();
            }
            else { FreeTextBox1.Text = ""; }// FillInstructionDetails(); }
        }
    }
    private void FillSessionslist()
    {
        try
        {
            ListItem listname;
            listname = new ListItem("-- select --", "0");
            ddlFirstLevelVariableList.Items.Clear();
            ddlFirstLevelVariableList.Items.Add(listname);
            int sectionIndex = 0;

            if (Session["TestFirstVariableIndex"] != null)
                sectionIndex = int.Parse(Session["TestFirstVariableIndex"].ToString());
            if (ddlTestSectionList.SelectedIndex > 0)// bip 111009
            {
                string querystring = "select distinct SectionName,SectionId from View_FirstLevelSectionList where ParentId=0 and TestId=" + ddlTestNameList.SelectedValue + " and TestSectionId=" + ddlTestSectionList.SelectedValue;
                DataSet dsFirstLevelSectionLists = new DataSet();
                dsFirstLevelSectionLists = clsClasses.GetValuesFromDB(querystring);
                if (dsFirstLevelSectionLists != null)
                {
                    ddlFirstLevelVariableList.DataSource = dsFirstLevelSectionLists.Tables[0];
                    ddlFirstLevelVariableList.DataTextField = "SectionName";
                    ddlFirstLevelVariableList.DataValueField = "SectionId";
                    ddlFirstLevelVariableList.DataBind();
                }

                if (sectionIndex > 0)
                {
                    ddlFirstLevelVariableList.SelectedIndex = sectionIndex;
                    FillSubLevel1Sections();
                }
                else
                {
                    listname = new ListItem("-- select --", "0");
                    ddlSecondLevelVariableList.Items.Clear();
                    ddlSecondLevelVariableList.Items.Add(listname);
                }
            }
            else
            {
                listname = new ListItem("-- select --", "0");
                ddlSecondLevelVariableList.Items.Clear();
                ddlSecondLevelVariableList.Items.Add(listname);
            }
        }
        catch (Exception ex)
        {

        }
    }
    private void FillSubLevel1Sections()
    {
        ListItem listname;

        listname = new ListItem("-- select --", "0");
        ddlSecondLevelVariableList.Items.Clear();
        ddlSecondLevelVariableList.Items.Add(listname);
        int parentindex = 0;
        if (Session["TestSecondVariableIndex"] != null)
            parentindex = int.Parse(Session["TestSecondVariableIndex"].ToString());

        
        if (ddlTestSectionList.SelectedIndex > 0 && ddlFirstLevelVariableList.SelectedIndex > 0)// bip 111009
        {

            string querystring = "select distinct SectionName,SectionId from View_SecondLevelSectionList where ParentId=" + ddlFirstLevelVariableList.SelectedValue + " and TestId=" + ddlTestNameList.SelectedValue + " and TestSectionId=" + ddlTestSectionList.SelectedValue;
            DataSet dsFirstLevelSectionLists = new DataSet();
            dsFirstLevelSectionLists = clsClasses.GetValuesFromDB(querystring);
            if (dsFirstLevelSectionLists != null)
            {
                ddlSecondLevelVariableList.DataSource = dsFirstLevelSectionLists.Tables[0];
                ddlSecondLevelVariableList.DataTextField = "SectionName";
                ddlSecondLevelVariableList.DataValueField = "SectionId";
                ddlSecondLevelVariableList.DataBind();
            }

            if (parentindex > 0)
            {
                ddlSecondLevelVariableList.SelectedIndex = parentindex;
            }
            FillInstructionDetails();
        }
    }



}