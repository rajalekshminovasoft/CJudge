using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_AddUser : System.Web.UI.Page
{
    CJDataClassesDataContext cjDataclass = new CJDataClassesDataContext();
    string Username = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Logged"].ToString() == "False")
            Response.Redirect("../Default.aspx");
    }

    private bool CheckAge()
    {
        try
        {
            int age = int.Parse(txtAge.Text.Trim());
            if (age <= 12) { lblMessage.Text = "age should be greater than 12"; return false; }

            return true;
        }
        catch (Exception ex) { lblMessage.Text = "Enter valid age"; return false; }
    }
    private string CreateUsernamePwd()
    {
        
        var lastUserID = from userdetails in cjDataclass.UserProfiles
                         orderby userdetails.UserId descending
                         select userdetails;
        if (lastUserID.Count() > 0)
        {
            Username = txtFsName.Text.Trim().Substring(0, 4) +"00"+ (lastUserID.First().UserId + 1);
        }
        else
        {
            Username = txtFsName.Text.Trim().Substring(0, 4) + "00"+1;
        }
        return Username;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtFsName.Text != "" && txtLoginFromDate.Text != "" && txtLoginToDate.Text != "" && txtEmailId.Text != "")
        {
            if (CheckAge() == false)
            {
                lblMessage.Text = "Enter valid age";
                return;
            }
            CreateUsernamePwd();
            if (Username != "")
            {
                DateTime frmdate = Convert.ToDateTime(txtLoginFromDate.Text.Trim());
                DateTime todate = Convert.ToDateTime(txtLoginToDate.Text.Trim());
                cjDataclass.AddUserByAdmin(Username, Username, ddlUserType.SelectedItem.Text, int.Parse(drp_org.SelectedValue), int.Parse(drp_groupuser.SelectedValue), frmdate ,todate , int.Parse(drp_Status.SelectedValue), 1, txtEmailId.Text.Trim(), 1, txtFsName.Text.Trim(), txtMidName.Text.Trim(), txtLstName.Text.Trim(), ddlGender.SelectedItem.Text, int.Parse(txtAge.Text.Trim()), 0, 0, "", "", "");
                lblMessage.Text = "User Details Added";
            }
            
        }
    }
}