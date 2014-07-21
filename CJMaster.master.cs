using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class CJMaster : System.Web.UI.MasterPage
{
    CJDataClassesDataContext cjDataclass = new CJDataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            
        }
    }
    protected void imgbtn_Submit_Click(object sender, ImageClickEventArgs e)
    
{
        if (txt_username.Text != "" && txt_password.Text != "")
        {
            var Checkuser = from userdetails in cjDataclass.UserProfiles
                            where userdetails.UserName == txt_username.Text.Trim() && userdetails.Password == txt_password.Text.Trim()
                            select userdetails;
            if (Checkuser.Count() > 0)
            {
                //Useradding page if SuperAdmin
                //Test Details page if user
                //Userlist page if Group admin
                Session.Add("Logged", true);
                Session.Add("UserID", Checkuser.First().UserId);
                Session.Add("usertype", Checkuser.First().UserType);
                if (Checkuser.First().OrganizationID != null && Checkuser.First().OrganizationID != 0)
                    Session.Add("AdminOrganizationID",Checkuser.First().OrganizationID);
                Response.Redirect("Admin/Home.aspx");
            }
        }
    }
}
