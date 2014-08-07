﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using System.Numeric;
using System.Data;

public partial class Admin_TestPhotoTypeQuestions : System.Web.UI.Page
{
    string usercode = "";
    int userid = 0;
    DBManagementClass clsclass = new DBManagementClass();
    CJDataClassesDataContext cjDataclass = new CJDataClassesDataContext();
    DataSet ds;
    int qusid1 = 0;
    int pagecount = 0;
    int quesperPage = 1;
    int testId = 0; int testsectionid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserTestId"] != null)
        {
            if (Session["timeExpired"] != null)
                if (Session["timeExpired"].ToString() == "True")
                {
                    CheckTime();
                    return;
                }
            testId = int.Parse(Session["UserTestId"].ToString());
            if (Session["UserID"] != null)
            {
                userid = int.Parse(Session["UserID"].ToString());
                FillQuestion();
            }
        }
    }
    private void FillImageQuestionInstructions()
    {
        int testSecondVariableId = 0, testFirstVariableId = 0, testSectionID = 0;
        if (Session["CurrentTestSectionId"] != null)
            testSectionID = int.Parse(Session["CurrentTestSectionId"].ToString());
        if (Session["CurrentTestSecondVariableId"] != null)
            testSecondVariableId = int.Parse(Session["CurrentTestSecondVariableId"].ToString());
        if (Session["CurrentTestFirstVariableId"] != null)
            testFirstVariableId = int.Parse(Session["CurrentTestFirstVariableId"].ToString());

        bool valueexists = false;
        DataSet dsInstructiondet = new DataSet();
        string quesrystring = "";
        if (testSecondVariableId > 0)
            quesrystring = "select InstructionDetails,InstructionImage1,InstructionDetails2,InstructionImage2,InstructionDetails3 from TestSectionVariablewiseInstructions where CategoryId =4 and TestId=" + testId + " and TestSectionId =" + testSectionID + " and FirstVariableId=" + testFirstVariableId + " and SecondVariableId =" + testSecondVariableId;
        else if (testFirstVariableId > 0)
            quesrystring = "select InstructionDetails,InstructionImage1,InstructionDetails2,InstructionImage2,InstructionDetails3 from TestSectionVariablewiseInstructions where CategoryId =4 and TestId=" + testId + " and TestSectionId =" + testSectionID + " and FirstVariableId=" + testFirstVariableId;

        dsInstructiondet = clsclass.GetValuesFromDB(quesrystring);

        if (dsInstructiondet != null) if (dsInstructiondet.Tables.Count > 0) if (dsInstructiondet.Tables[0].Rows.Count > 0)
                {
                    //divInstructions.InnerHtml = dsInstructiondet.Tables[0].Rows[0]["InstructionDetails"].ToString(); valueexists = true; 
                    string styleproperties = "padding-left: 40px";
                    HtmlTable tblInstructions = new HtmlTable();
                    HtmlTableRow trInstructions = new HtmlTableRow();
                    HtmlTableCell tcellInstructions = new HtmlTableCell();
                    if (dsInstructiondet.Tables[0].Rows[0]["InstructionDetails"].ToString() != null && dsInstructiondet.Tables[0].Rows[0]["InstructionDetails"].ToString() != "")
                    {
                        tcellInstructions.InnerHtml = dsInstructiondet.Tables[0].Rows[0]["InstructionDetails"].ToString();
                        trInstructions.Cells.Add(tcellInstructions);
                        tblInstructions.Rows.Add(trInstructions);
                        valueexists = true;
                    }
                    if (dsInstructiondet.Tables[0].Rows[0]["InstructionImage1"].ToString() != null && dsInstructiondet.Tables[0].Rows[0]["InstructionImage1"].ToString() != "")
                    {
                        trInstructions = new HtmlTableRow();
                        tcellInstructions = new HtmlTableCell();
                        tcellInstructions.InnerHtml = "<div style='" + styleproperties + "'><img alt='' src='QuestionAnswerFiles/InstructionImages/" + dsInstructiondet.Tables[0].Rows[0]["InstructionImage1"].ToString() + "' /></div>";
                        trInstructions.Cells.Add(tcellInstructions);
                        tblInstructions.Rows.Add(trInstructions);
                        valueexists = true;
                    }
                    if (dsInstructiondet.Tables[0].Rows[0]["InstructionDetails2"].ToString() != null && dsInstructiondet.Tables[0].Rows[0]["InstructionDetails2"].ToString() != "")
                    {
                        trInstructions = new HtmlTableRow();
                        tcellInstructions = new HtmlTableCell();
                        tcellInstructions.InnerHtml = dsInstructiondet.Tables[0].Rows[0]["InstructionDetails2"].ToString();
                        trInstructions.Cells.Add(tcellInstructions);
                        tblInstructions.Rows.Add(trInstructions);
                        valueexists = true;
                    }
                    if (dsInstructiondet.Tables[0].Rows[0]["InstructionImage2"].ToString() != null && dsInstructiondet.Tables[0].Rows[0]["InstructionImage2"].ToString() != "")
                    {
                        trInstructions = new HtmlTableRow();
                        tcellInstructions = new HtmlTableCell();
                        tcellInstructions.InnerHtml = "<div style='" + styleproperties + "'><img alt='' src='QuestionAnswerFiles/InstructionImages/" + dsInstructiondet.Tables[0].Rows[0]["InstructionImage2"].ToString() + "' /></div>";
                        trInstructions.Cells.Add(tcellInstructions);
                        tblInstructions.Rows.Add(trInstructions);
                        valueexists = true;
                    }
                    if (dsInstructiondet.Tables[0].Rows[0]["InstructionDetails3"].ToString() != null && dsInstructiondet.Tables[0].Rows[0]["InstructionDetails3"].ToString() != "")
                    {
                        trInstructions = new HtmlTableRow();
                        tcellInstructions = new HtmlTableCell();
                        tcellInstructions.InnerHtml = dsInstructiondet.Tables[0].Rows[0]["InstructionDetails3"].ToString();
                        trInstructions.Cells.Add(tcellInstructions);
                        tblInstructions.Rows.Add(trInstructions);
                        valueexists = true;
                    }
                    divInstructions.Controls.Clear();
                    divInstructions.Controls.Add(tblInstructions);

                }


        if (valueexists == false)
            FillCommonInstructions();
        else FillTitle();
    }
    private void FillTitle()
    {
        var InstructionDetails = from instructiondet in cjDataclass.TestInstructions
                                 where instructiondet.CategoryId == 4
                                 select instructiondet;
        if (InstructionDetails.Count() > 0)
        {
            if (InstructionDetails.First().Title != null)
                divtitle.InnerHtml = InstructionDetails.First().Title.ToString();
        }
    }

    private void FillCommonInstructions()
    {
        var InstructionDetails = from instructiondet in cjDataclass.TestInstructions
                                 where instructiondet.CategoryId == 4
                                 select instructiondet;
        if (InstructionDetails.Count() > 0)
        {
            if (InstructionDetails.First().Title != null)
                divtitle.InnerHtml = InstructionDetails.First().Title.ToString();
            if (InstructionDetails.First().InstructionDetails != null)
                divInstructions.InnerHtml = InstructionDetails.First().InstructionDetails.ToString();
        }
    }

    private DataSet GetQuestionList(int testsectionid)
    {
        //// bip 07122009

        string firstVariableName = ""; string secondVariableName = "";
        if (Session["TestFirstVariableName"] != null)
            firstVariableName = Session["TestFirstVariableName"].ToString();
        if (Session["TestSecondVariableName"] != null)
            secondVariableName = Session["TestSecondVariableName"].ToString();

        //
        DataSet dsQuesCount;
        string querystring = "";
        DataTable dtQuestionList = new DataTable();

        dtQuestionList.Columns.Add("QuestionID");
        dtQuestionList.Columns.Add("Question");
        dtQuestionList.Columns.Add("Answer");
        dtQuestionList.Columns.Add("QuestionFileName");
        dtQuestionList.Columns.Add("QuestionFileNameSub1");
        dtQuestionList.Columns.Add("Option1FileName");
        dtQuestionList.Columns.Add("Option2FileName");
        dtQuestionList.Columns.Add("Option3FileName");
        dtQuestionList.Columns.Add("Option4FileName");
        dtQuestionList.Columns.Add("Option5FileName");
        dtQuestionList.Columns.Add("Option1");
        dtQuestionList.Columns.Add("Option2");
        dtQuestionList.Columns.Add("Option3");
        dtQuestionList.Columns.Add("Option4");
        dtQuestionList.Columns.Add("Option5");

        DataRow drQurstionList;

        // bip 08122009;
        if (secondVariableName != "")
            querystring = "select distinct PhotoTypeQuestionCount,SectionId from QuestionCount where PhotoTypeQuestionCount>0 and TestId=" + testId + " and TestSectionId=" + testsectionid + " and SectionName='" + firstVariableName + "' and SectionNameSub1='" + secondVariableName + "' order by sectionid";
        else if (firstVariableName != "")
            querystring = "select distinct PhotoTypeQuestionCount,SectionId from QuestionCount where PhotoTypeQuestionCount>0 and TestId=" + testId + " and TestSectionId=" + testsectionid + " and SectionName='" + firstVariableName + "' order by sectionid";

        DataSet dsQuestioncount = new DataSet();
        dsQuestioncount = clsclass.GetValuesFromDB(querystring);
        if (dsQuestioncount != null)
            if (dsQuestioncount.Tables.Count > 0)
                if (dsQuestioncount.Tables[0].Rows.Count > 0)
                    for (int c = 0; c < dsQuestioncount.Tables[0].Rows.Count; c++)//        
                    {
                        int imgQuescount = int.Parse(dsQuestioncount.Tables[0].Rows[c]["PhotoTypeQuestionCount"].ToString());
                        int sectionid = int.Parse(dsQuestioncount.Tables[0].Rows[c]["SectionId"].ToString());

                        if (imgQuescount > 0)
                        {
                            querystring = "SELECT TOP (" + imgQuescount + ") QuestionID,Question,Answer,QuestionFileName,Option1FileName,Option2FileName,Option3FileName,Option4FileName,Option5FileName,QuestionFileNameSub1,Option1,Option2,Option3,Option4,Option5  FROM View_TestBaseQuestionList where Category = 'PhotoType' AND TestBaseQuestionStatus=1 AND TestSectionId=" + testsectionid + " AND SectionId=" + sectionid + " AND TestId=" + testId + " ORDER BY RAND((100*QuestionID)*DATEPART(millisecond, GETDATE())) ";

                            dsQuesCount = new DataSet();
                            dsQuesCount = clsclass.GetValuesFromDB(querystring);
                            if (dsQuesCount != null)
                                if (dsQuesCount.Tables[0].Rows.Count > 0)
                                {
                                    for (int i = 0; i < dsQuesCount.Tables[0].Rows.Count; i++)
                                    {
                                        drQurstionList = dtQuestionList.NewRow();
                                        drQurstionList["QuestionID"] = dsQuesCount.Tables[0].Rows[i]["QuestionID"];
                                        drQurstionList["Question"] = dsQuesCount.Tables[0].Rows[i]["Question"];
                                        drQurstionList["Answer"] = dsQuesCount.Tables[0].Rows[i]["Answer"];
                                        drQurstionList["QuestionFileName"] = dsQuesCount.Tables[0].Rows[i]["QuestionFileName"];
                                        drQurstionList["QuestionFileNameSub1"] = dsQuesCount.Tables[0].Rows[i]["QuestionFileNameSub1"];
                                        drQurstionList["Option1FileName"] = dsQuesCount.Tables[0].Rows[i]["Option1FileName"];
                                        drQurstionList["Option2FileName"] = dsQuesCount.Tables[0].Rows[i]["Option2FileName"];
                                        drQurstionList["Option3FileName"] = dsQuesCount.Tables[0].Rows[i]["Option3FileName"];
                                        drQurstionList["Option4FileName"] = dsQuesCount.Tables[0].Rows[i]["Option4FileName"];
                                        drQurstionList["Option5FileName"] = dsQuesCount.Tables[0].Rows[i]["Option5FileName"];
                                        drQurstionList["Option1"] = dsQuesCount.Tables[0].Rows[i]["Option1"];
                                        drQurstionList["Option2"] = dsQuesCount.Tables[0].Rows[i]["Option2"];
                                        drQurstionList["Option3"] = dsQuesCount.Tables[0].Rows[i]["Option3"];
                                        drQurstionList["Option4"] = dsQuesCount.Tables[0].Rows[i]["Option4"];
                                        drQurstionList["Option5"] = dsQuesCount.Tables[0].Rows[i]["Option5"];

                                        dtQuestionList.Rows.Add(drQurstionList);
                                    }
                                }
                        }
                    }
        DataSet dsQuestionList = new DataSet();
        if (dtQuestionList.Rows.Count > 0)
        {
            dsQuestionList.Tables.Add(dtQuestionList); Session["questionColl_imgPhoto"] = dsQuestionList;
            Session["totalQuesCount_imgPhoto"] = dsQuestionList.Tables[0].Rows.Count.ToString();
        }
        else { Session["questionColl_imgPhoto"] = null; dsQuestionList = null; }

        return dsQuestionList;
    }

    private string GetAnswerOptionOrder(int index)
    {
        string option = "";

        if (index == 1)
            option = "A";
        else if (index == 2)
            option = "B";
        else if (index == 3)
            option = "C";
        else if (index == 4)
            option = "D";
        else if (index == 5)
            option = "E";

        return option;
    }
    private DataSet GetTempData()
    {
        DataSet dsTempData = new DataSet();
        //// 220110 ... bip
        int testSecondVariableId = 0, testFirstVariableId = 0;
        if (Session["CurrentTestSecondVariableId"] != null)
            testSecondVariableId = int.Parse(Session["CurrentTestSecondVariableId"].ToString());
        if (Session["CurrentTestFirstVariableId"] != null)
            testFirstVariableId = int.Parse(Session["CurrentTestFirstVariableId"].ToString());
        int questionid = 0; string questiontype = "PhotoType";

        string querystringquesTemp = "select distinct QuestionId from UserTestQuestions_Temp where UserID=" + userid + " and TestId=" + testId + " and TestSectionId=" + testsectionid + " and FirstVariableId=" + testFirstVariableId + " and QuestionType='" + questiontype + "'";
        if (testSecondVariableId > 0)
            querystringquesTemp += " and SecondVariableId = " + testSecondVariableId;
        DataSet dsquestionIdColl = clsclass.GetValuesFromDB(querystringquesTemp);
        if (dsquestionIdColl != null)
            if (dsquestionIdColl.Tables.Count > 0)
                if (dsquestionIdColl.Tables[0].Rows.Count > 0)
                {
                    string questionids = "";
                    for (int index = 0; index < dsquestionIdColl.Tables[0].Rows.Count; index++)
                    {
                        if (questionids != "")
                            questionids += " or ";
                        questionids += " QuestionId=" + dsquestionIdColl.Tables[0].Rows[index]["QuestionId"].ToString();
                    }

                    querystringquesTemp = "SELECT QuestionID,Question,Answer,QuestionFileName,Option1FileName,Option2FileName,Option3FileName,Option4FileName,Option5FileName,QuestionFileNameSub1,Option1,Option2,Option3,Option4,Option5  FROM View_TestBaseQuestionList where " + questionids;
                    dsTempData = clsclass.GetValuesFromDB(querystringquesTemp);
                    Session["questionColl_imgPhoto"] = dsTempData;

                    var GetPageIndex = from pageindex in cjDataclass.UserTestPageIndex_Temps
                                       where pageindex.UserId == userid && pageindex.TestId == testId && pageindex.TestSectionId == testsectionid &&
                                       pageindex.FirstVariableId == testFirstVariableId && pageindex.SecondVariableId == testSecondVariableId &&
                                       pageindex.QuestionType == questiontype
                                       select pageindex;
                    if (GetPageIndex.Count() > 0)
                    {
                        if (GetPageIndex.First().PageIndex != null)
                        {
                            pagecount = int.Parse(GetPageIndex.First().PageIndex.ToString());
                            Session["pagecount_imgPhoto"] = pagecount;
                        }
                    }
                }
                else dsTempData = null;

        return dsTempData;
    }
    private void FillQuestion()
    {
        //try
        //{
        ClearControls();
        string querystring = "";
        //int totalQues = 0;
        int QuestionID = 0;

        if (Session["pagecount_imgPhoto"] != null)
            pagecount = int.Parse(Session["pagecount_imgPhoto"].ToString());

        ds = new DataSet();//int testsectionid = 0;
        if (Session["CurrentTestSectionId"] != null)
            testsectionid = int.Parse(Session["CurrentTestSectionId"].ToString());
        //da.Fill(ds);
        if (Session["questionColl_imgPhoto"] != null)
            ds = (DataSet)Session["questionColl_imgPhoto"];
        else
        {
            //bip 081009
            //int testsectionid = 0;
            if (Session["CurrentTestSectionId"] != null)
            {
                testsectionid = int.Parse(Session["CurrentTestSectionId"].ToString());

                //  //// 220110 ... bip
                int testSecondVariableId = 0, testFirstVariableId = 0;
                if (Session["CurrentTestSecondVariableId"] != null)
                    testSecondVariableId = int.Parse(Session["CurrentTestSecondVariableId"].ToString());
                if (Session["CurrentTestFirstVariableId"] != null)
                    testFirstVariableId = int.Parse(Session["CurrentTestFirstVariableId"].ToString());
                int questionid = 0; string questiontype = "PhotoType";

                ds = GetTempData();
                bool newentry = false;
                if (ds == null)
                {
                    newentry = true;
                    ds = GetQuestionList(testsectionid);
                }
                else if (ds.Tables.Count <= 0)
                { newentry = true; ds = GetQuestionList(testsectionid); }


                //
                //  ds = GetQuestionList(testsectionid);
                if (ds == null)
                {
                    string evaldirection = "Next";
                    if (Session["evaldirection"] != null)
                        evaldirection = Session["evaldirection"].ToString();
                    if (evaldirection == "Next")
                        GoToNextPage();
                    else GoToPreviousPage();
                    return;

                    //GoToNextPage(); return;
                }
                else // store the questiondetails in a temp table.
                {
                    if (newentry == true)
                        if (ds.Tables.Count > 0)
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                for (int q = 0; q < ds.Tables[0].Rows.Count; q++)
                                {
                                    questionid = int.Parse(ds.Tables[0].Rows[q]["QuestionID"].ToString());
                                    cjDataclass.AddUserTestQuestions_Temp(userid, testId, testsectionid, testFirstVariableId, testSecondVariableId, questionid, questiontype);
                                }
                            }
                }

            }
        }
        int slno = 0;
        slno = pagecount * quesperPage + 1;
        if (slno < 0)
            slno = 1;

        int pagecnt = 0;
        int curntquescnt = 0;
        int slnos = 0;

        if (ds.Tables[0].Rows.Count > 0)
        {
            //Session["ValueExists"] = "True";

            FillImageQuestionInstructions();

            Session["totalQuesAvailable_imgPhoto"] = ds.Tables[0].Rows.Count.ToString();
            int j = 0;
            for (int i = slno - 1; i < ds.Tables[0].Rows.Count; i++)
            {
                if (j >= quesperPage) break;
                string Answer = "****";
                Session["CurrentControlCtrl"] = "TestPhotoTypeQuestions.aspx";// bip 08012010
                Session["ValueExists"] = "True";

                int optindex = 1;
                switch (j)
                {
                    case 0:

                        // slnos = CheckSlNo();
                        lblNo1.Text = slno.ToString() + ".  ";
                        //lblQues1.Text = ds.Tables[0].Rows[i]["Question"].ToString();
                        tcellQues1.InnerHtml = ds.Tables[0].Rows[i]["Question"].ToString();

                        lblQuesID1.Text = ds.Tables[0].Rows[i]["QuestionID"].ToString();

                        var Ques1 = from Ques in cjDataclass.EvaluationResults
                                    where Ques.UserId == userid && Ques.Question == ds.Tables[0].Rows[i]["Question"].ToString() && Ques.QuestionID == int.Parse(ds.Tables[0].Rows[i]["QuestionID"].ToString()) &&
                                    Ques.TestId == testId && Ques.TestSectionId == testsectionid
                                    select Ques;//Ques.UserCode == usercode &&
                        if (Ques1.Count() > 0)
                            if (Ques1.First().Answer != null)
                                Answer = Ques1.First().Answer.ToString();
                        if (ds.Tables[0].Rows[i]["QuestionFileName"].ToString() != "")
                        {
                            imgQuestion1.Visible = true;
                            imgQuestion1.ImageUrl = "QuestionAnswerFiles/" + ds.Tables[0].Rows[i]["QuestionFileName"].ToString();
                        }

                        if (ds.Tables[0].Rows[i]["QuestionFileNameSub1"].ToString() != "")
                        {
                            imgQuestion1Sub1.Visible = true;
                            imgQuestion1Sub1.ImageUrl = "QuestionAnswerFiles/" + ds.Tables[0].Rows[i]["QuestionFileNameSub1"].ToString();
                        }
                        if (ds.Tables[0].Rows[i]["Option1FileName"].ToString() != "" || ds.Tables[0].Rows[i]["Option2FileName"].ToString() != "" || ds.Tables[0].Rows[i]["Option3FileName"].ToString() != "" || ds.Tables[0].Rows[i]["Option4FileName"].ToString() != "" || ds.Tables[0].Rows[i]["Option5FileName"].ToString() != "")
                        {
                            if (ds.Tables[0].Rows[i]["Option1FileName"].ToString() != "")
                            {
                                imgQues1Answer1.Visible = true; rbQues1Answer1.Visible = true; lblA1.Visible = true;
                                imgQues1Answer1.ImageUrl = "QuestionAnswerFiles/" + ds.Tables[0].Rows[i]["Option1FileName"].ToString();
                                if (Answer == "1")
                                    rbQues1Answer1.Checked = true;
                                optindex++;
                            }
                            if (ds.Tables[0].Rows[i]["Option2FileName"].ToString() != "")
                            {
                                if (optindex != 2)
                                    lblB1.Text = GetAnswerOptionOrder(optindex);
                                imgQues1Answer2.Visible = true; rbQues1Answer2.Visible = true; lblB1.Visible = true;
                                imgQues1Answer2.ImageUrl = "QuestionAnswerFiles/" + ds.Tables[0].Rows[i]["Option2FileName"].ToString();
                                if (Answer == "2")
                                    rbQues1Answer2.Checked = true;
                                optindex++;
                            }
                            if (ds.Tables[0].Rows[i]["Option3FileName"].ToString() != "")
                            {
                                if (optindex != 3)
                                    lblC1.Text = GetAnswerOptionOrder(optindex);
                                imgQues1Answer3.Visible = true; rbQues1Answer3.Visible = true; lblC1.Visible = true;
                                imgQues1Answer3.ImageUrl = "QuestionAnswerFiles/" + ds.Tables[0].Rows[i]["Option3FileName"].ToString();
                                if (Answer == "3")
                                    rbQues1Answer3.Checked = true;
                                optindex++;
                            }
                            if (ds.Tables[0].Rows[i]["Option4FileName"].ToString() != "")
                            {
                                if (optindex != 4)
                                    lblD1.Text = GetAnswerOptionOrder(optindex);
                                imgQues1Answer4.Visible = true; rbQues1Answer4.Visible = true; lblD1.Visible = true;
                                imgQues1Answer4.ImageUrl = "QuestionAnswerFiles/" + ds.Tables[0].Rows[i]["Option4FileName"].ToString();
                                if (Answer == "4")
                                    rbQues1Answer4.Checked = true;
                                optindex++;
                            }
                            if (ds.Tables[0].Rows[i]["Option5FileName"].ToString() != "")
                            {
                                if (optindex != 5)
                                    lblE1.Text = GetAnswerOptionOrder(optindex);
                                imgQues1Answer5.Visible = true; rbQues1Answer5.Visible = true; lblE1.Visible = true;
                                imgQues1Answer5.ImageUrl = "QuestionAnswerFiles/" + ds.Tables[0].Rows[i]["Option5FileName"].ToString();
                                if (Answer == "5")
                                    rbQues1Answer5.Checked = true;
                            }
                        }
                        else
                        {
                            if (ds.Tables[0].Rows[i]["Option1"].ToString() != "")
                            {
                                imgQues1Answer1.Visible = false; rbQues1Answer1.Visible = true; lblA1.Visible = true;
                                rbQues1Answer1.Text = ds.Tables[0].Rows[i]["Option1"].ToString();
                                if (Answer == "1")
                                    rbQues1Answer1.Checked = true;
                                optindex++;
                            }
                            if (ds.Tables[0].Rows[i]["Option2"].ToString() != "")
                            {
                                if (optindex != 2)
                                    lblB1.Text = GetAnswerOptionOrder(optindex);
                                imgQues1Answer2.Visible = false; rbQues1Answer2.Visible = true; lblB1.Visible = true;
                                rbQues1Answer2.Text = ds.Tables[0].Rows[i]["Option2"].ToString();
                                if (Answer == "2")
                                    rbQues1Answer2.Checked = true;
                                optindex++;
                            }
                            if (ds.Tables[0].Rows[i]["Option3"].ToString() != "")
                            {
                                if (optindex != 3)
                                    lblC1.Text = GetAnswerOptionOrder(optindex);
                                imgQues1Answer3.Visible = false; rbQues1Answer3.Visible = true; lblC1.Visible = true;
                                rbQues1Answer3.Text = ds.Tables[0].Rows[i]["Option3"].ToString();
                                if (Answer == "3")
                                    rbQues1Answer3.Checked = true;
                                optindex++;
                            }
                            if (ds.Tables[0].Rows[i]["Option4"].ToString() != "")
                            {
                                if (optindex != 4)
                                    lblD1.Text = GetAnswerOptionOrder(optindex);
                                imgQues1Answer4.Visible = false; rbQues1Answer4.Visible = true; lblD1.Visible = true;
                                rbQues1Answer4.Text = ds.Tables[0].Rows[i]["Option4"].ToString();
                                if (Answer == "4")
                                    rbQues1Answer4.Checked = true;
                                optindex++;
                            }
                            if (ds.Tables[0].Rows[i]["Option5"].ToString() != "")
                            {
                                if (optindex != 5)
                                    lblE1.Text = GetAnswerOptionOrder(optindex);
                                imgQues1Answer5.Visible = false; rbQues1Answer5.Visible = true; lblE1.Visible = true;
                                rbQues1Answer5.Text = ds.Tables[0].Rows[i]["Option5"].ToString();
                                if (Answer == "5")
                                    rbQues1Answer5.Checked = true;
                            }
                        }
                        curntquescnt++;
                        j++;
                        break;
                }
            }
        }
        else { GoToNextPage(); }
        Session["curntques"] = curntquescnt;

    }
    private void GoToNextPage()
    {
        Session["evaldirection"] = "Next";
        Session["SubCtrl"] = "TestWordTypeMemmoryQuestions.aspx";
        Response.Redirect("TestWordTypeMemmoryQuestions.aspx");
    }

    private void SaveAnswer()
    {
        string quescategory = "PhotoType";
        int testsectionid = 0;
        if (Session["CurrentTestSectionId"] != null)
            testsectionid = int.Parse(Session["CurrentTestSectionId"].ToString());

        string answer = "";

        if (lblQuesID1.Text.Trim() != "")
        {
            if (rbQues1Answer1.Checked == true)
                answer = "1";
            else if (rbQues1Answer2.Checked == true)
                answer = "2";
            else if (rbQues1Answer3.Checked == true)
                answer = "3";
            else if (rbQues1Answer4.Checked == true)
                answer = "4";
            else if (rbQues1Answer5.Checked == true)
                answer = "5";

            qusid1 = int.Parse(lblQuesID1.Text.Trim());

            cjDataclass.QuesAnswers(qusid1, usercode, tcellQues1.InnerHtml, answer, userid, testId, testsectionid, quescategory);
        }

    }

    private void ClearControls()
    {
        rbQues1Answer1.Checked = false; rbQues1Answer2.Checked = false; rbQues1Answer3.Checked = false; rbQues1Answer4.Checked = false; rbQues1Answer5.Checked = false;
        lblNo1.Text = "";
        lblQues1.Text = "";
        imgQuestion1.ImageUrl = ""; imgQues1Answer1.ImageUrl = ""; imgQues1Answer2.ImageUrl = ""; imgQues1Answer3.ImageUrl = ""; imgQues1Answer4.ImageUrl = ""; imgQues1Answer5.ImageUrl = "";
    }

    private void ClearSessionValues()
    {
        // Session["pagecount_imgPhoto"] = null;

    }
    private void ClearAllPageCountValues(int index)
    {
        if (index == 0)
            Session["pagecount_imgPhoto"] = null;
        Session["pagecount_memWords"] = null;
        Session["pagecount_audio"] = null;
        Session["pagecount_memImages"] = null;
        Session["pagecountRating"] = null;
        Session["pagecount_video"] = null;
    }
    private void GoToPreviousPage()
    {
        //
        int testsectionid = 0;
        if (Session["CurrentTestSectionId"] != null)
        {
            testsectionid = int.Parse(Session["CurrentTestSectionId"].ToString());
        }

        ClearSessionValues();
        Session["evaldirection"] = "Previous";
        Session["SubCtrl"] = "TestImageQuestions.aspx";
        Response.Redirect("TestImageQuestions.aspx");
    }
    protected void ptnPrevious_Click(object sender, EventArgs e)
    {
        int curcount = 0;
        int totalcount = 0, totalquesavail = 0;
        if (Session["totalQuesCount_imgPhoto"] != null)
            totalcount = int.Parse(Session["totalQuesCount_imgPhoto"].ToString());
        if (Session["totalQuesAvailable_imgPhoto"] != null)
            totalquesavail = int.Parse(Session["totalQuesAvailable_imgPhoto"].ToString());
        if (totalcount == totalquesavail)
            curcount = totalcount;
        if (totalcount > totalquesavail)
            curcount = totalquesavail;
        if (Session["pagecount_imgPhoto"] != null)
            pagecount = int.Parse(Session["pagecount_imgPhoto"].ToString());

        int curindex = 0;
        curindex = (pagecount - 1) * quesperPage;
        if (curindex >= 0)
        {
            pagecount--;
            Session["pagecount_imgPhoto"] = pagecount; SetCurrentPageCount();
        }
        else
        {
            GoToPreviousPage();
        }
        FillQuestion();

    }

    private Boolean CheckTime()//bip 10052010 
    {
        Boolean timeExpired = false;//bip 10052010 
        if (CheckTestTimeValidity() == true)
        {
            lblpopup_timer.Text = "The time alloted for your test is completed, <br> If you are interested to take this test again please contact our site admin";
            pnlpopup_timer.Visible = true; btnYes_timer_Test.Visible = true; Timer1.Enabled = false;
            timeExpired = true; pnlMain.Visible = false; Session["timeExpired"] = "True";//bip 10052010
            //return;
        }
        else if (CheckTimeValidity() == true)
        {
            lblpopup_timer.Text = "The time alloted for this Test Section is completed, <br> Do you want to continue with the remaining sections under your Test?";
            pnlpopup_timer.Visible = true; btnYes_timer.Visible = true; btnNo_timer.Visible = true; Timer1.Enabled = false;
            timeExpired = true; pnlMain.Visible = false; Session["timeExpired"] = "True";//bip 10052010
            //return;
        }
        else if (CheckTestSecVarTimeValidity() == true)
        {
            lblpopup_timer.Text = "The time alloted for this Variable under selected Section is completed, <br> Do you want to continue with the remaining Variables under your Test Section?";
            pnlpopup_timer.Visible = true; btnYes_timer_TestVariable.Visible = true; btnNo_timer.Visible = true; Timer1.Enabled = false;
            timeExpired = true; pnlMain.Visible = false; Session["timeExpired"] = "True";//bip 10052010
            //return;
        }
        if (timeExpired == true)
        {
            if (Session["saved"] != null)
                if (Session["saved"].ToString() == "true")
                    return timeExpired;

            SaveAnswer(); Session["saved"] = "true";
        }
        return timeExpired;

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        Boolean timeExpired = CheckTime();
        if (timeExpired == false)//bip 10052010
        {
            if (CheckAnswer() == false)
            {
                Timer1.Enabled = false;
                pnlpopup.Visible = true;
                return;
            }
            SaveValues();
        }
        //else SaveAnswer();//bip 10052010

    }
    private Boolean CheckAnswer()
    {
        Boolean answercompleted = true;

        string answer = "";

        if (lblQuesID1.Text.Trim() != "")
        {
            if (rbQues1Answer1.Checked == true)
                answer = "1";
            else if (rbQues1Answer2.Checked == true)
                answer = "2";
            else if (rbQues1Answer3.Checked == true)
                answer = "3";
            else if (rbQues1Answer4.Checked == true)
                answer = "4";
            else if (rbQues1Answer5.Checked == true)
                answer = "5";
            if (answer == "")
            {
                lblpopup.Text += "You have missed question No:" + lblNo1.Text.Trim() + " Please, complete all questions before moving to the next page. <br> Do you want to go to next page? ";
                answercompleted = false;
            }
        }


        return answercompleted;
    }
    private void SaveValues()
    {
        SaveAnswer();

        //usercode = Session["UserCode"].ToString();
        if (Session["UserID"] != null)
            userid = int.Parse(Session["UserID"].ToString());

        int curcount = 0;
        int totalcount = 0, totalquesavail = 0;
        if (Session["totalQuesCount_imgPhoto"] != null)
            totalcount = int.Parse(Session["totalQuesCount_imgPhoto"].ToString());
        if (Session["totalQuesAvailable_imgPhoto"] != null)
            totalquesavail = int.Parse(Session["totalQuesAvailable_imgPhoto"].ToString());
        if (totalcount == totalquesavail)
            curcount = totalcount;
        if (totalcount > totalquesavail)
            curcount = totalquesavail;
        if (Session["pagecount_imgPhoto"] != null)
            pagecount = int.Parse(Session["pagecount_imgPhoto"].ToString());

        int curindex = 0;
        curindex = (pagecount + 1) * quesperPage;
        if (curindex < curcount)
        {
            pagecount++;
            Session["pagecount_imgPhoto"] = pagecount; SetCurrentPageCount();// 230110 bip
            FillQuestion();
        }
        else
        {
            ClearSessionValues();
            GoToNextPage();
        }
    }
    private void SetCurrentPageCount()
    {
        testsectionid = int.Parse(Session["CurrentTestSectionId"].ToString());
        //  //// 220110 ... bip
        int testSecondVariableId = 0, testFirstVariableId = 0;
        if (Session["CurrentTestSecondVariableId"] != null)
            testSecondVariableId = int.Parse(Session["CurrentTestSecondVariableId"].ToString());
        if (Session["CurrentTestFirstVariableId"] != null)
            testFirstVariableId = int.Parse(Session["CurrentTestFirstVariableId"].ToString());
        int questionid = 0; string questiontype = "PhotoType";
        cjDataclass.AddUserTestPageIndex_Temp(userid, testId, testsectionid, testFirstVariableId, testSecondVariableId, pagecount, questiontype);
    }
    protected void btnYes_Click(object sender, EventArgs e)
    {
        SaveValues(); pnlpopup.Visible = false;
        Timer1.Enabled = true;
    }

    // for first level variablewise time setting 24-02-2010 bip

    private Boolean CheckTestSecVarTimeValidity()
    {
        if (Session["TestSectionVariableStartTime"] != null)
        {
            if (Session["TestSectionVariableTimeDuration"] != null)
            {
                DateTime dtStart = (DateTime)Session["TestSectionVariableStartTime"];
                DateTime dtNow = DateTime.Now;
                TimeSpan tsNow = dtNow.Subtract(dtStart);
                int hrs = tsNow.Hours;
                int min = tsNow.Minutes;
                int sec = tsNow.Seconds;

                string strDuration = Session["TestSectionVariableTimeDuration"].ToString();
                string[] timeValues = strDuration.Split(new char[] { ':' });
                int setHrs = int.Parse(timeValues[0].ToString());
                int setMin = int.Parse(timeValues[1].ToString());
                int setSec = int.Parse(timeValues[2].ToString());

                TimeSpan tsDuration = new TimeSpan(setHrs, setMin, setSec);//25-02-2010 bip
                bool timeExpired = false;
                if (tsNow > tsDuration)
                    timeExpired = true;
                // return true;
                TimeSpan tsTimeRemains = tsDuration.Subtract(tsNow);

                // 03-02-2010 bip
                int firstvariableid = 0;
                if (Session["CurrentTestFirstVariableId"] != null)
                    firstvariableid = int.Parse(Session["CurrentTestFirstVariableId"].ToString());
                DataTable dtTimeDetails = new DataTable();
                if (Session["FirstvarTimeDet"] == null)
                {
                    dtTimeDetails.Columns.Add("FirstVarID");
                    dtTimeDetails.Columns.Add("TimeUsed");
                    dtTimeDetails.Columns.Add("CompletionStatus");
                    dtTimeDetails.Columns.Add("AssignTime");
                    dtTimeDetails.Columns.Add("AssignStatus");
                }
                else
                {
                    dtTimeDetails = (DataTable)Session["FirstvarTimeDet"];
                }
                bool valueexists = false;
                for (int i = 0; i < dtTimeDetails.Rows.Count; i++)
                {
                    int firstvarid = 0;
                    string competionstatus = "", assigntime = "", timeused = "", assignStatus = "";
                    if (dtTimeDetails.Rows[i]["FirstVarID"] != null)
                        firstvarid = int.Parse(dtTimeDetails.Rows[i]["FirstVarID"].ToString());
                    if (dtTimeDetails.Rows[i]["TimeUsed"] != null)
                        timeused = dtTimeDetails.Rows[i]["TimeUsed"].ToString();
                    if (dtTimeDetails.Rows[i]["CompletionStatus"] != null)
                        competionstatus = dtTimeDetails.Rows[i]["CompletionStatus"].ToString();
                    if (dtTimeDetails.Rows[i]["AssignTime"] != null)
                        assigntime = dtTimeDetails.Rows[i]["AssignTime"].ToString();
                    if (dtTimeDetails.Rows[i]["AssignStatus"] != null)
                        assignStatus = dtTimeDetails.Rows[i]["AssignStatus"].ToString();

                    if (firstvariableid == firstvarid)
                    {
                        valueexists = true;
                        if (dtTimeDetails.Rows[i]["CompletionStatus"].ToString() == "1")
                            return true;

                        dtTimeDetails.Rows[i]["TimeUsed"] = hrs + ":" + min + ":" + sec;

                        if (timeExpired == true)
                        {
                            dtTimeDetails.Rows[i]["CompletionStatus"] = 1;
                            Session["FirstvarTimeDet"] = dtTimeDetails;
                            return true;
                        }
                        Session["FirstvarTimeDet"] = dtTimeDetails;
                        break;
                    }
                }
                if (valueexists == false)
                {
                    // code to assign values from here
                    DataRow drTimedet = dtTimeDetails.NewRow();
                    drTimedet["FirstVarID"] = firstvariableid;
                    //drTimedet["CompletionStatus"] = 0;
                    drTimedet["TimeUsed"] = hrs + ":" + min + ":" + sec;
                    drTimedet["AssignTime"] = setHrs + ":" + setMin + ":" + 0;
                    drTimedet["AssignStatus"] = 1;
                    //dtTimeDetails.Rows.Add(drTimedet);

                    if (timeExpired == true)
                    {
                        drTimedet["CompletionStatus"] = 1;
                        dtTimeDetails.Rows.Add(drTimedet);
                        Session["FirstvarTimeDet"] = dtTimeDetails;
                        return true;
                    }
                    drTimedet["CompletionStatus"] = 0;
                    dtTimeDetails.Rows.Add(drTimedet);
                    Session["FirstvarTimeDet"] = dtTimeDetails;
                }
                ////

            }
            else return CheckTestSecVarGenValidity();

        }
        //else Session["AudioStatrtTime"] = DateTime.Now;

        return false;
    }
    private Boolean CheckTestSecVarGenValidity()
    {
        //if (Session["TestSectionVariableTimeDuration"] == null)
        if (Session["TotalTimeForUnAssgnSecVariables"] != null)
        {
            string[] totaltimeforUnAssgn = Session["TotalTimeForUnAssgnSecVariables"].ToString().Split(new char[] { ':' });
            int totalHrsforUnAssgn = int.Parse(totaltimeforUnAssgn[0]);
            int totalMinforUnAssgn = int.Parse(totaltimeforUnAssgn[1]);
            int totalSecforUnAssgn = int.Parse(totaltimeforUnAssgn[2]);

            TimeSpan tsUnAssgn = new TimeSpan(totalHrsforUnAssgn, totalMinforUnAssgn, totalSecforUnAssgn);
            int genHrs = 0, genMin = 0, genSec = 0;
            if (Session["GeneralVariableTimeUsed"] != null)
            {
                string[] genTimeUsed = Session["GeneralVariableTimeUsed"].ToString().Split(new char[] { ':' });
                genHrs = int.Parse(genTimeUsed[0]);
                genMin = int.Parse(genTimeUsed[1]);
                genSec = int.Parse(genTimeUsed[2]);
                TimeSpan tsGeneral = new TimeSpan(genHrs, genMin, genSec);

                if (tsGeneral > tsUnAssgn)
                    return true;
            }

            //

            if (Session["TestSectionVariableStartTime"] != null)
            {
                DateTime dtStartTime = (DateTime)Session["TestSectionVariableStartTime"];
                DateTime dtendTime = DateTime.Now;
                TimeSpan tsUsed = dtendTime.Subtract(dtStartTime);

                genHrs += tsUsed.Hours;
                genMin += tsUsed.Minutes;
                genSec += tsUsed.Seconds;

                if (genSec >= 60)
                {
                    double getMin = float.Parse(genSec.ToString()) / 60;
                    string[] newMin = getMin.ToString().Split(new char[] { '.' });
                    if (newMin.Length > 1)
                    {
                        int newminutes = int.Parse(newMin[0]);
                        genMin += newminutes;

                        float newSec = float.Parse(getMin.ToString().Substring(1)) * 60;
                        string[] newSeconds = newSec.ToString().Split(new char[] { '.' });
                        int seconds = int.Parse(newSeconds[0]);
                        genSec = seconds;
                    }
                }

                if (genMin >= 60)
                {
                    double getHrs = float.Parse(genMin.ToString()) / 60;
                    string[] newHrs = getHrs.ToString().Split(new char[] { '.' });
                    if (newHrs.Length > 1)
                    {
                        int newhours = int.Parse(newHrs[0]);
                        genHrs += newhours;

                        float newMin = float.Parse(getHrs.ToString().Substring(1)) * 60;
                        string[] newMinutes = newMin.ToString().Split(new char[] { '.' });
                        int minutes = int.Parse(newMinutes[0]);
                        genMin = minutes;
                    }
                }
                Session["GeneralVariableTimeUsed"] = genHrs + ":" + genMin + ":" + genSec;
                bool timeExpired = false;
                if (tsUsed > tsUnAssgn)
                    timeExpired = true;
                // return true;

                // return false;// 03-02-2010 bip

                TimeSpan tsTimeRemains = tsUnAssgn.Subtract(tsUsed);

                // 03-02-2010 bip
                int firstvariableid = 0;
                if (Session["CurrentTestFirstVariableId"] != null)
                    firstvariableid = int.Parse(Session["CurrentTestFirstVariableId"].ToString());
                DataTable dtTimeDetails = new DataTable();
                if (Session["FirstvarTimeDet"] == null)
                {
                    dtTimeDetails.Columns.Add("FirstVarID");
                    dtTimeDetails.Columns.Add("TimeUsed");
                    dtTimeDetails.Columns.Add("CompletionStatus");
                    dtTimeDetails.Columns.Add("AssignTime");
                    dtTimeDetails.Columns.Add("AssignStatus");
                }
                else
                {
                    dtTimeDetails = (DataTable)Session["FirstvarTimeDet"];
                }
                bool valueexists = false;
                for (int i = 0; i < dtTimeDetails.Rows.Count; i++)
                {
                    int firstvarid = 0;
                    string competionstatus = "", remainingtime = "", timeused = "";
                    if (dtTimeDetails.Rows[i]["FirstVarID"] != null)
                        firstvarid = int.Parse(dtTimeDetails.Rows[i]["FirstVarID"].ToString());
                    if (dtTimeDetails.Rows[i]["TimeUsed"] != null)
                        timeused = dtTimeDetails.Rows[i]["TimeUsed"].ToString();
                    if (dtTimeDetails.Rows[i]["CompletionStatus"] != null)
                        competionstatus = dtTimeDetails.Rows[i]["CompletionStatus"].ToString();
                    if (dtTimeDetails.Rows[i]["AssignTime"] != null)
                        remainingtime = dtTimeDetails.Rows[i]["AssignTime"].ToString();
                    if (dtTimeDetails.Rows[i]["AssignStatus"] != null)
                        remainingtime = dtTimeDetails.Rows[i]["AssignStatus"].ToString();

                    if (firstvariableid == firstvarid)
                    {
                        valueexists = true;
                        dtTimeDetails.Rows[i]["TimeUsed"] = genHrs + ":" + genMin + ":" + genSec;
                        if (timeExpired == true)
                        {
                            dtTimeDetails.Rows[i]["CompletionStatus"] = 1;
                            Session["FirstvarTimeDet"] = dtTimeDetails;
                            return true;
                        }
                        Session["FirstvarTimeDet"] = dtTimeDetails; break;
                    }
                }
                if (valueexists == false)
                {
                    // code to assign values from here
                    DataRow drTimedet = dtTimeDetails.NewRow();
                    drTimedet["FirstVarID"] = firstvariableid;
                    //drTimedet["CompletionStatus"] = 0;
                    drTimedet["TimeUsed"] = genHrs + ":" + genMin + ":" + genSec;
                    drTimedet["AssignTime"] = totalHrsforUnAssgn + ":" + totalMinforUnAssgn + ":" + totalSecforUnAssgn;
                    drTimedet["AssignStatus"] = 0;
                    //dtTimeDetails.Rows.Add(drTimedet);

                    if (timeExpired == true)
                    {
                        drTimedet["CompletionStatus"] = 1;
                        dtTimeDetails.Rows.Add(drTimedet);
                        Session["FirstvarTimeDet"] = dtTimeDetails;
                        return true;
                    }
                    drTimedet["CompletionStatus"] = 0;
                    dtTimeDetails.Rows.Add(drTimedet);
                    Session["FirstvarTimeDet"] = dtTimeDetails;
                }
                ////
            }
        }
        return false;
    }

    private Boolean CheckTimeValidity()
    {
        if (Session["TestSectionStartTime"] != null)
        {
            if (Session["TestSectionTimeDuration"] != null)
            {
                DateTime dtStart = (DateTime)Session["TestSectionStartTime"];
                DateTime dtNow = DateTime.Now;
                TimeSpan tsNow = dtNow.Subtract(dtStart);
                int hrs = tsNow.Hours;
                int min = tsNow.Minutes;

                string strDuration = Session["TestSectionTimeDuration"].ToString();
                string[] timeValues = strDuration.Split(new char[] { ':' });
                int setHrs = int.Parse(timeValues[0].ToString());
                int setMin = int.Parse(timeValues[1].ToString());

                TimeSpan tsDuration = new TimeSpan(setHrs, setMin, 0);//25-02-2010 bip
                if (tsNow > tsDuration)
                    return true;
            }
            else return CheckTestSecGenValidity();

        }
        //else Session["AudioStatrtTime"] = DateTime.Now;

        return false;
    }
    private Boolean CheckTestSecGenValidity()
    {
        if (Session["TestSectionTimeDuration"] == null)
            if (Session["TotalTimeForUnAssgnSections"] != null)
            {
                string[] totaltimeforUnAssgn = Session["TotalTimeForUnAssgnSections"].ToString().Split(new char[] { ':' });
                int totalHrsforUnAssgn = int.Parse(totaltimeforUnAssgn[0]);
                int totalMinforUnAssgn = int.Parse(totaltimeforUnAssgn[1]);

                TimeSpan tsUnAssgn = new TimeSpan(totalHrsforUnAssgn, totalMinforUnAssgn, 0);
                int genHrs = 0, genMin = 0;
                if (Session["GeneralTimeUsed"] != null)
                {
                    string[] genTimeUsed = Session["GeneralTimeUsed"].ToString().Split(new char[] { ':' });
                    genHrs = int.Parse(genTimeUsed[0]);
                    genMin = int.Parse(genTimeUsed[1]);
                    TimeSpan tsGeneral = new TimeSpan(genHrs, genMin, 0);
                    if (tsGeneral > tsUnAssgn)
                        return true;
                }

                //

                if (Session["TestSectionStartTime"] != null)
                {
                    DateTime dtStartTime = (DateTime)Session["TestSectionStartTime"];
                    DateTime dtendTime = DateTime.Now;
                    TimeSpan tsUsed = dtendTime.Subtract(dtStartTime);

                    genHrs += tsUsed.Hours;
                    genMin += tsUsed.Minutes;

                    if (genMin >= 60)
                    {
                        double getHrs = float.Parse(genMin.ToString()) / 60;
                        string[] newHrs = getHrs.ToString().Split(new char[] { '.' });
                        if (newHrs.Length > 1)
                        {
                            int newhours = int.Parse(newHrs[0]);
                            genHrs += newhours;

                            float newMin = float.Parse(getHrs.ToString().Substring(1)) * 60;
                            string[] newMinutes = newMin.ToString().Split(new char[] { '.' });
                            int minutes = int.Parse(newMinutes[0]);
                            genMin = minutes;
                        }
                    }
                    Session["GeneralTimeUsed"] = genHrs + ":" + genMin;
                    if (tsUsed > tsUnAssgn)
                        return true;
                }
            }
        return false;
    }
    private Boolean CheckTestTimeValidity()
    {
        if (Session["TestStartTime"] != null)
        {
            if (Session["TestTimeDuration"] != null)
            {
                DateTime dtTestStart = (DateTime)Session["TestStartTime"];
                string strTestDuration = Session["TestTimeDuration"].ToString();
                DateTime dtNow = DateTime.Now;
                TimeSpan tsNow = dtNow.Subtract(dtTestStart);
                int hrs = tsNow.Hours;
                int min = tsNow.Minutes;

                string[] timeValues = strTestDuration.Split(new char[] { ':' });
                int setHrs = int.Parse(timeValues[0].ToString());
                int setMin = int.Parse(timeValues[1].ToString());

                TimeSpan tsDuration = new TimeSpan(setHrs, setMin, 0);//25-02-2010 bip
                if (tsNow > tsDuration)
                    return true;
            }
        }

        return false;
    }
    private void SetNextSectionDetails_Timer()
    {
        int testsectionid = 0;
        if (Session["CurrentTestSectionId"] != null)
        {
            testsectionid = int.Parse(Session["CurrentTestSectionId"].ToString());
            cjDataclass.AddUserTestSectionDetails(0, userid, 0, testId, testsectionid);
        }

        int sectionIdIndexNo = 0;
        if (Session["sectionIdIndexNo"] != null)
            sectionIdIndexNo = int.Parse(Session["sectionIdIndexNo"].ToString());
        sectionIdIndexNo = sectionIdIndexNo + 1;
        Session["sectionIdIndexNo"] = sectionIdIndexNo.ToString();

        ShowNextControl_Timer(0);

    }
    private void SetNextSectionVariableDetails_Timer()// 24-02-2010 bip
    {

        // 27-02-2010 bip
        int firstvaridfortimer = 0, varidindex_timer = 0;
        if (Session["FirstVariableIdForTimer"] != null)
        {
            firstvaridfortimer = int.Parse(Session["FirstVariableIdForTimer"].ToString());
            firstvaridfortimer += 1;
            Session["FirstVariableIdForTimer"] = firstvaridfortimer;

            /// bip 12052010
            varidindex_timer = int.Parse(Session["VariableIdIndexNo_timer"].ToString());
            Session["VariableIdIndexNo_timer"] = varidindex_timer + 1;
            ///
        }

        ShowNextControl_Timer(1);

    }
    private void ShowNextControl_Timer(int index)// 24-02-2010 bip
    {
        Session["TestSectionVariableTimeDuration"] = null;// 24-02-2010 bip

        Session["AudioPrevious"] = null; Session["AudioCurrentpage"] = null;
        Session["VideoPrevious"] = null; Session["VideoCurrentpage"] = null;
        Session["MemWordPrevious"] = null; Session["MemWordCurrentpage"] = null;
        if (index == 0)// 24-02-2010 bip
        {
            Session["TestSectionTimeDuration"] = null;// to be added to each ctrl 22-02-2010 bip
            Session["VariableIdIndexNo"] = null;
            Session["dsTestVariableIds"] = null;
            Session["VariableIdIndexNo_timer"] = null;// bip 12052010

        }
        Session["questionColl_audio"] = null;
        Session["questionColl_fill"] = null;
        Session["questionColl_img"] = null;
        Session["questionColl_memImages"] = null;
        Session["questionColl"] = null;
        Session["questionColl_Rating"] = null;
        Session["questionColl_video"] = null;
        Session["questionColl_memWords"] = null;
        Session["questionColl_imgPhoto"] = null;

        Session["totalQuesCount_audio"] = null; Session["totalQuesAvailable_audio"] = null;
        Session["totalQuesCount_fill"] = null; Session["totalQuesAvailable_fill"] = null;
        Session["totalQuesCount_img"] = null; Session["totalQuesAvailable_img"] = null;
        Session["totalQuesCount_memImages"] = null; Session["totalQuesAvailable_memImages"] = null;
        Session["totalQuesCount"] = null; Session["totalQuesAvailable"] = null;
        Session["totalQuesCount_Rating"] = null; Session["totalQuesAvailable_Rating"] = null;
        Session["totalQuesCount_video"] = null; Session["totalQuesAvailable_video"] = null;
        Session["totalQuesCount_memWords"] = null; Session["totalQuesAvailable_memWords"] = null;

        Session["totalQuesCount_imgPhoto"] = null; Session["totalQuesAvailable_imgPhoto"] = null;


        Session["SubCtrl"] = "TestObjectiveQuestns.aspx";
        Response.Redirect("TestObjectiveQuestns.aspx");

        // FillQuestion();

    }

    protected void btnYes_timer_Click(object sender, EventArgs e)
    {
        Session["timeExpired"] = null; Session["saved"] = null;
        //SaveAnswer();// bip 07052010
        SetNextSectionDetails_Timer();
    }
    protected void btnNo_timer_Click(object sender, EventArgs e)
    {
        Session["timeExpired"] = null; Session["saved"] = null;
        //SaveAnswer();// bip 07052010
        //// 230110 bip        
        cjDataclass.DeleteUserTest_TempValues(userid, 0, 0);
        ////
        Session.Clear();
        Response.Redirect("Home.aspx"); //bipson 18082010// Response.Redirect("CareerJudge.htm");;
    }
    protected void btnYes_timer_Test_Click(object sender, EventArgs e)
    {
        Session["timeExpired"] = null; Session["saved"] = null;
        //SaveAnswer();// bip 07052010
        //// 230110 bip        
        cjDataclass.DeleteUserTest_TempValues(userid, 0, 0);
        ////
        Session.Clear();
        Response.Redirect("Home.aspx"); //bipson 18082010// Response.Redirect("CareerJudge.htm");;
    }
    protected void btnNo_timer_Test_Click(object sender, EventArgs e)
    {

    }
    protected void btnYes_timer_TestVariable_Click(object sender, EventArgs e)
    {
        Session["timeExpired"] = null; Session["saved"] = null;
        //SaveAnswer();// bip 07052010
        SetNextSectionVariableDetails_Timer();
    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {

        /// bip 10052010
        if (Session["timeExpired"] != null)
            if (Session["timeExpired"].ToString() == "True")
                return;

        CheckTime();
        //SaveAnswer();
        ///
    }

    protected void btnNo_Click(object sender, EventArgs e)
    {
        Timer1.Enabled = true;
    }
}