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
using System.Data.SqlClient;
using System.Numeric;

public partial class Admin_TakeTest : System.Web.UI.Page
{
    CJDataClassesDataContext cjDataclass = new CJDataClassesDataContext();
    DBManagementClass clsclass = new DBManagementClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!Page.IsPostBack)
        //{
        //    //Load First control--------Test section
        //    Page.Controls.Add(Page.LoadControl("ObjectiveQuestns.ascx")); 

        //}
        try
        {
            if (Session["SubCtrl"] != null)
            {
                string str = Session["SubCtrl"].ToString();
                Page.Controls.Add(Page.LoadControl(str));
            }
            else
            {
                //Assign Session
                Session["SubCtrl"] = "ObjectiveQuestns.ascx";
                string str = Session["SubCtrl"].ToString();
                //Page.Controls.Add(Page.LoadControl(str));
                Page.Controls.Add(Page.LoadControl(str));
                
            }
        }
        catch (Exception ex)
        {
        }
        //else if (LastLoadedControl != null)
        //{
        //    AddControl(LastLoadedControl);
        //}
        //else
        //{
        //    if (Session["UserID"] != null)
        //    { lbtnLogout.Visible = true; }


        //} 

        //GetTotalTime();


        
    }
    //private void AddControl(string ControlPath)
    //{
    //    try
    //    {
    //        System.Web.UI.Control Control_ToAdd;
    //        Control_ToAdd = LoadControl(ControlPath);
    //        Control_ToAdd.ID = "fja";
    //        ContentPlaceHolder1.Controls.Clear();
    //        cplhLoader.Controls.Add(Control_ToAdd);
    //        LastLoadedControl = ControlPath;
    //    }
    //    catch (Exception ex) { lblmessage.Text = ex.Message; }//
    //}
    


}