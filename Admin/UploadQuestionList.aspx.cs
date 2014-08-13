using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;

public partial class Admin_UploadQuestionList : System.Web.UI.Page
{
    CJDataClassesDataContext cjDataclass = new CJDataClassesDataContext();
    bool specialadmin = false;
    int OrganizationID = 0;
    string imagefilePath;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                if (Session["usertype"].ToString() == "SpecialAdmin")
                {
                    bool perassigned = false;
                    specialadmin = true; OrganizationID = int.Parse(Session["AdminOrganizationID"].ToString());
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
                    { //lblMessage.Text = "Please contact your site admin to approve question types to get permissions to add questions"; return;
                    }
                }
                FillSectionCategory();

                int catindex = 0;
                if (Session["catindex"] != null)
                {
                    catindex = int.Parse(Session["catindex"].ToString());
                    ddlCategory.SelectedIndex = catindex;
                    //if (ddlCategory.SelectedValue == "RatingType")
                    //{ pnlRatingStyle.Visible = true; pnlAnswer.Visible = false; }
                    //else if (ddlCategory.SelectedValue == "FillBlanks")
                    //{ //pnlAnswer.Visible = false; }
                }

                //FillGrid();

               // FillAnswerOptions();
            }
        }
        catch (Exception ex)
        { }
    }
    private void FillSectionCategory()
    {
        ListItem listname;
        int sectionCategoryId = 0;
        int sectionCategoryIndex = 0;
        if (Session["sectionCategoryIndex"] != null)
            sectionCategoryIndex = int.Parse(Session["sectionCategoryIndex"].ToString());
        listname = new ListItem("-- Select Section Category --", "0");
        ddlSectionCategory.Items.Clear();
        ddlSectionCategory.Items.Add(listname);
        ddlSectionCategory.DataSource = lnqseccatname;
        ddlSectionCategory.DataTextField = "SectionCategoryName";
        ddlSectionCategory.DataValueField = "SectionCategoryId";
        ddlSectionCategory.DataBind();
        if (sectionCategoryIndex > 0)
        {
            ddlSectionCategory.SelectedIndex = sectionCategoryIndex;
            sectionCategoryId = int.Parse(ddlSectionCategory.SelectedValue);

            FillSessionslist(sectionCategoryId);
        }
    }
    protected void ddlSectionList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSectionList.SelectedIndex > 0)
        {
            Session["sectionIndex"] = ddlSectionList.SelectedIndex.ToString();
            Session["SubLevel1Index"] = null; FillSubLevel1Sections();
        }
        else
        {
            Session["sectionIndex"] = null; Session["SubLevel1Index"] = null;
            ListItem listname;
            listname = new ListItem("-- select --", "0");
            ddlFirstLevelList.Items.Clear();
            ddlFirstLevelList.Items.Add(listname);
            listname = new ListItem("-- select --", "0");
            ddlSecondLevelList.Items.Clear();
            ddlSecondLevelList.Items.Add(listname);
        }
    }
    private void FillSessionslist(int sectionCategoryId)
    {
        try
        {
            ListItem listname;
            listname = new ListItem("-- select --", "0");
            ddlSectionList.Items.Clear();
            ddlSectionList.Items.Add(listname);
            int sectionIndex = 0;

            if (Session["sectionIndex"] != null)
                sectionIndex = int.Parse(Session["sectionIndex"].ToString());

            if (specialadmin == true)
            {
                var details1 = from details in cjDataclass.SectionDetails
                               where details.ParentId == 0 && details.OrganizationId == OrganizationID && details.SectionCategoryId == sectionCategoryId
                               orderby details.SectionName ascending
                               select details;
                if (details1.Count() > 0)
                {
                    ddlSectionList.DataSource = details1;
                    ddlSectionList.DataTextField = "SectionName";
                    ddlSectionList.DataValueField = "SectionId";
                    ddlSectionList.DataBind();
                }

            }
            else
            {
                var details1 = from details in cjDataclass.SectionDetails
                               where details.ParentId == 0 && details.AdminAccess == 1 && details.SectionCategoryId == sectionCategoryId
                               orderby details.SectionName ascending
                               select details;
                if (details1.Count() > 0)
                {
                    ddlSectionList.DataSource = details1;
                    ddlSectionList.DataTextField = "SectionName";
                    ddlSectionList.DataValueField = "SectionId";
                    ddlSectionList.DataBind();
                }
            }

            ddlSectionList.SelectedIndex = sectionIndex;
            if (sectionIndex > 0)
            {
                FillSubLevel1Sections();
            }
            else
            {
                Session["SubLevel1Index"] = null;
                Session["SubLevel2Index"] = null;
                listname = new ListItem("-- select --", "0");
                ddlFirstLevelList.Items.Clear();
                ddlFirstLevelList.Items.Add(listname);
                listname = new ListItem("-- select --", "0");
                ddlSecondLevelList.Items.Clear();
                ddlSecondLevelList.Items.Add(listname);

                //FillGrid();
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
        ddlFirstLevelList.Items.Clear();
        ddlFirstLevelList.Items.Add(listname);
        int parentindex = 0;
        if (Session["SubLevel1Index"] != null)
            parentindex = int.Parse(Session["SubLevel1Index"].ToString());

        var details1 = from details in cjDataclass.SectionDetails
                       where details.ParentId == int.Parse(ddlSectionList.SelectedValue)
                       select details;
        if (details1.Count() > 0)
        {
            ddlFirstLevelList.DataSource = details1;
            ddlFirstLevelList.DataTextField = "SectionName";
            ddlFirstLevelList.DataValueField = "SectionId";
            ddlFirstLevelList.DataBind();
        }

        ddlFirstLevelList.SelectedIndex = parentindex;
        if (parentindex > 0)
        {
            FillSubLevel2Sections();
        }
        else
        {
            Session["SubLevel2Index"] = null;
            listname = new ListItem("-- select --", "0");
            ddlSecondLevelList.Items.Clear();
            ddlSecondLevelList.Items.Add(listname);

            //FillGrid();
        }
    }
    private void FillSubLevel2Sections()
    {
        ListItem listname;
        listname = new ListItem("-- select --", "0");
        ddlSecondLevelList.Items.Clear();
        ddlSecondLevelList.Items.Add(listname);

        int subindex = 0;
        if (Session["SubLevel2Index"] != null)
            subindex = int.Parse(Session["SubLevel2Index"].ToString());

        var details1 = from details in cjDataclass.SectionDetails
                       where details.ParentId == int.Parse(ddlFirstLevelList.SelectedValue)
                       select details;
        if (details1.Count() > 0)
        {
            ddlSecondLevelList.DataSource = details1;
            ddlSecondLevelList.DataTextField = "SectionName";
            ddlSecondLevelList.DataValueField = "SectionId";
            ddlSecondLevelList.DataBind();
        }

        //if (subindex > 0)
        //{
        ddlSecondLevelList.SelectedIndex = subindex;
        //}else

        //FillGrid();
    }
    protected void ddlSecondLevelList_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["SubLevel2Index"] = ddlSecondLevelList.SelectedIndex.ToString();
    }
    protected void ddlFirstLevelList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlFirstLevelList.SelectedIndex > 0)
        {
            Session["SubLevel1Index"] = ddlFirstLevelList.SelectedIndex.ToString();
            FillSubLevel2Sections();
        }
        else
        {
            Session["SubLevel1Index"] = null;
            ListItem listname;
            listname = new ListItem("-- select --", "0");
            ddlSecondLevelList.Items.Clear();
            ddlSecondLevelList.Items.Add(listname);
        }
    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    protected void ddlSectionCategory_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlSectionCategory.SelectedIndex > 0)
        {
            // txtSectionName.Visible = true;
            if (ddlSectionCategory.SelectedValue != "0")
            {
                if (Session["sectionCategoryIndex"] != null)
                    if (ddlSectionCategory.SelectedValue != Session["sectionCategoryIndex"].ToString())
                    {
                        Session["sectionIndex"] = null; Session["SubLevel1Index"] = null;
                        ListItem listname;
                        listname = new ListItem("-- select --", "0");
                        ddlFirstLevelList.Items.Clear();
                        ddlFirstLevelList.Items.Add(listname);
                        listname = new ListItem("-- select --", "0");
                        ddlSecondLevelList.Items.Clear();
                        ddlSecondLevelList.Items.Add(listname);
                    }
                Session["sectionCategoryIndex"] = ddlSectionCategory.SelectedIndex;
                int sectionCategoryId = int.Parse(ddlSectionCategory.SelectedValue);
                FillSessionslist(sectionCategoryId);
            }
            else
            {
                Session["sectionIndex"] = null; Session["SubLevel1Index"] = null;
                ListItem listname;
                listname = new ListItem("-- select --", "0");
                ddlFirstLevelList.Items.Clear();
                ddlFirstLevelList.Items.Add(listname);
                listname = new ListItem("-- select --", "0");
                ddlSecondLevelList.Items.Clear();
                ddlSecondLevelList.Items.Add(listname);
            }
        }
        else
        {
            Session["sectionCategoryIndex"] = null;
            Session["sectionIndex"] = null; Session["SubLevel1Index"] = null;
            ListItem listname;
            listname = new ListItem("-- select --", "0");
            ddlFirstLevelList.Items.Clear();
            ddlFirstLevelList.Items.Add(listname);
            listname = new ListItem("-- select --", "0");
            ddlSecondLevelList.Items.Clear();
            ddlSecondLevelList.Items.Add(listname);
        }


    }       
//Public Sub read_file()
//        Dim connString As String = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" & Server.MapPath("~/files/") + FileUpload1.FileName + ";" & "Extended Properties=Excel 8.0;"
//        ' Create the connection object for excel
//        Dim oledbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(connString)
//        Try

//            oledbConn.Open()
//            count = 0
//            db1 = New DBClass
//            Dim cmd As OleDb.OleDbCommand = New OleDb.OleDbCommand("SELECT * FROM [Sheet1$]", oledbConn)
//            Dim oledr As OleDb.OleDbDataReader = cmd.ExecuteReader()
//            While oledr.Read()
//                ''sql = "Select count(*) from SHY_Stock where Company_id=" & Session("cmpid") & " and  Model='" & dr.Item(1) & "' and Type='" & dr.Item(2) & "' and Color='" & dr.Item(3) & "' order by S_id"
//                '' ''' MsgBox(sql)
//                ''dr1 = db.getDatareader(sql)
//                ''If dr1.Read() Then
//                ''    count = dr1.Item(0)
//                ''    ''' MsgBox(dr1.Item(0))
//                ''End If
//                ''dr1.Close()
//                ' PlaceHolder = 0
//                ' MsgBox(oledr.Item(0))
//                ' str = oledr.Item(10).ToString()

//                sql = "insert into Members(Name,Phone,Address,Email,Mobile,CategoryID,RegID)values('" & oledr.Item(0) & "','" & oledr.Item(1) & "','" & oledr.Item(2) & "','" & oledr.Item(3) & "','" & oledr.Item(4) & "'," & oledr.Item(5) & "," & Session("RegID") & ")"
//                db1.ExecuteCmd(sql)




//            End While

//            oledr.Close()
//            ''  '' MsgBox("Updated")
//            lbl_msg.Text = "Successfully uploaded"

//        Catch ex As Exception
//            '   MsgBox(ex.ToString())
//        Finally
//            oledbConn.Close()
//        End Try
//    End Sub


// Sent at 3:21 PM on Friday


// Protected Sub btn_import_Click(sender As Object, e As EventArgs) Handles btn_import.Click
//        Try
//            Dim path, str2 As String
//            path = FileUpload1.FileName
//            ' Session("path") = path.Substring(0, path.Length - 4)

//            If (FileUpload1.HasFile) Then
//                str2 = Server.MapPath("~/files/") + FileUpload1.FileName
//                FileUpload1.SaveAs(str2)
//                read_file()
//            End If

//        Catch ex As Exception
//            ' Response.Write(ex.ToString())
//        End Try
//    End Sub

    public void readfile()
    {
        string connString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Server.MapPath("~/Admin/UploadedImages/") + fileupload1.FileName + ";" + "Extended Properties=Excel 8.0;";
        // Create the connection object for excel
        System.Data.OleDb.OleDbConnection oledbConn = new System.Data.OleDb.OleDbConnection(connString);
        int sectionid = 0;
        if (ddlSecondLevelList.SelectedIndex > 0)
            sectionid = int.Parse(ddlSecondLevelList.SelectedValue);
        else if (ddlFirstLevelList.SelectedIndex > 0)
            sectionid = int.Parse(ddlFirstLevelList.SelectedValue);
        else if (ddlSectionList.SelectedIndex > 0)
            sectionid = int.Parse(ddlSectionList.SelectedValue);

        string sectionname = "", subsection1 = "", subsection2 = "";
        if (ddlSectionList.SelectedIndex > 0)
            sectionname = ddlSectionList.SelectedItem.Text;
        if (ddlFirstLevelList.SelectedIndex > 0)
            subsection1 = ddlFirstLevelList.SelectedItem.Text;
        if (ddlSecondLevelList.SelectedIndex > 0)
            subsection2 = ddlSecondLevelList.SelectedItem.Text;
        try
        {
            oledbConn.Open();
            System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand("SELECT * FROM [Sheet1$]", oledbConn);
            System.Data.OleDb.OleDbDataReader oledr = cmd.ExecuteReader();

            while (oledr.Read())
            {
                cjDataclass.AddQuestions(0, int.Parse(oledr[1].ToString()), oledr[2].ToString(), oledr[3].ToString(), oledr[4].ToString(), oledr[5].ToString(), oledr[6].ToString(),
                                        oledr[7].ToString(), oledr[8].ToString(), oledr[9].ToString(), oledr[10].ToString(), oledr[11].ToString(), oledr[12].ToString(), oledr[13].ToString(),
                                        oledr[14].ToString(), oledr[15].ToString(), oledr[16].ToString(), oledr[17].ToString(), oledr[23].ToString(), oledr[24].ToString(), oledr[25].ToString(),
                                        oledr[26].ToString(), oledr[27].ToString(), int.Parse(oledr[18].ToString()), 1, oledr[28].ToString(), oledr[29].ToString(), oledr[30].ToString(), oledr[31].ToString());
                //cjDataclass.AddQuestions(0, sectionid, sectionname, subsection1, subsection2, ddlCategory.SelectedValue,oledr[1].ToString(),
                //oledr[2].ToString(), oledr[3].ToString(), oledr[4].ToString(), oledr[5].ToString(), oledr[6].ToString(), oledr[7].ToString(), 
                //"", "", "", "", "", "","", "","", "", 0, 1, "", "", "", oledr[8].ToString());
            }

            oledr.Close();
            lblmsg.Text = "Successfully uploaded";

        }
        catch (Exception ex)
        {
            // MsgBox(ex.ToString())
        }
        finally
        {
            oledbConn.Close();
        }
    }
    protected void btn_add_Click(object sender, EventArgs e)
    {
        try
        {
            if (fileupload1.HasFile)
            {
                string str = Server.MapPath("UploadedImages/") + fileupload1.FileName;
                fileupload1.SaveAs(str);
                //if (ddlCategory.SelectedValue == "Objective")
                //{
                    readfile();
               // }
                
                //lblmsg.Text = "Objective Question Uploaded";
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btntest_Click(object sender, EventArgs e)
    {
        string connString = "Provider=System.Data.SqlClient;" + "Data Source=Tscout.db.4578161.hostedresource.com;Initial Catalog=Tscout;User ID=Tscout;Password=Tscout#123" + "Extended Properties=Excel 8.0;";
        // Create the connection object for excel
        SqlCommand _sqlCommand;
        SqlConnection _sqlConnenction;
        SqlDataAdapter _sqlDataAdapter;
        SqlDataReader _sqlDataReader;
        String _connString;
        System.Data. sqlco = new System.Data.OleDb.OleDbConnection(connString);
    }
}