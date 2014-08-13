using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AssignTestByAdmin : System.Web.UI.Page
{
    CJDataClassesDataContext cjDataclass = new CJDataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            
        }
    }
   
    protected void drp_org_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drp_org.SelectedIndex != 0)
        {
            drp_groupuser.DataSource = LnqGrpUser;
            drp_groupuser.DataTextField = "GroupName";
            drp_groupuser.DataValueField = "GroupUserID";
            drp_groupuser.DataBind();
        }
        else
        { 
            drp_groupuser.SelectedIndex = 0;
            drp_users.SelectedIndex = 0;
        }
    }
    protected void drp_groupuser_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drp_groupuser.SelectedIndex != 0)
        {
            drp_users.DataSource = lnqUser;
            drp_users.DataTextField = "UserName";
            drp_users.DataValueField = "UserId";
            drp_users.DataBind();
        }
        else
        {
            drp_users.SelectedIndex = 0;
        }
    }
    protected void dtTestlist_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void btn_save_Click(object sender, EventArgs e)
    {
        if (txt_Logindate.Text != "" && txt_Logoutdate.Text != "" && txt_paydate.Text != "")
        {
            int repacc;
            DateTime frmdate = Convert.ToDateTime(txt_Logindate.Text.Trim());
            DateTime todate = Convert.ToDateTime(txt_Logoutdate.Text.Trim());
            DateTime paydate = Convert.ToDateTime(txt_paydate.Text.Trim());
            if(chk_repaccess.Checked==true)
            {
                repacc = 1;
            }
            else
            {
                repacc=0;
            }
            foreach (DataListItem item in dtTestlist.Items)
            {
                CheckBox myCheckBox = (CheckBox)item.FindControl("chktest");
                Label test=(Label)item.FindControl("lbltest");
                Label Pric=(Label)item.FindControl("Price"); 
                if (myCheckBox.Checked)
                {
                    cjDataclass.AddUserTestList(0, int.Parse(test.Text), int.Parse(drp_users.SelectedValue), drp_paidstatus.SelectedItem.Text, "NOTTAKEN", paydate , repacc, frmdate , todate , int.Parse(Pric.Text));
                    lbl_msg.Text = "Test Assigned";
                }
            }

        }
    }
}