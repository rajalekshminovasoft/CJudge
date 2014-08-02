using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Logged"].ToString() == "False")
            Response.Redirect("../Default.aspx");
    }
    protected void imgbtn_testlist_Click(object sender, ImageClickEventArgs e)
    {
        //User View
        Response.Redirect("ViewUserTestDetails.aspx");
        //Admin View

    }
    protected void imgbtn_Report_Click(object sender, ImageClickEventArgs e)
    {
        //Response.Redirect("ViewUserTestDetails.aspx");
    }
    protected void imgbtn_User_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("AddUser.aspx");
    }
    protected void imgbtn_infokit_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("InfokitDetails.aspx");
    }
    protected void imgbtn_Qunbank_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("AddQuestions.aspx");
    }
    protected void imgbtn_assigntest_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("AssignTestByAdmin.aspx");
    }
    protected void imgbtn_repdescript_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void imgbtn_addspecialadmin_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void imgbtn_specialadpermission_Click(object sender, ImageClickEventArgs e)
    {

    }
}