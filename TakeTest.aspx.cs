using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class TakeTest : System.Web.UI.Page
{
    CJDataClassesDataContext cjDataclass = new CJDataClassesDataContext();
    string Username = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Wizard1.ActiveStepIndex = 0;        
        }
    }
    private void checkdata()
    {
        if (Wizard1.ActiveStepIndex == 0)
        {
            //Label1.Text = Wizard1.ActiveStepIndex.ToString();
            Session["TestID"] = "";
            foreach (DataListItem dli in dtTestlist.Items)
            {
                CheckBox productID = ((CheckBox)dli.FindControl("chktest"));
                if (productID.Checked == true)
                {
                    Session["TestID"] = ((Label)dli.FindControl("lbltestid")).Text;
                    Session["TestIDList"] = Session["TestIDList"] + "," + Session["TestID"];
                }
            }
            //Label1.Text = Session["TestID"].ToString();
        }
        if ((Session["TestIDList"] == null))
        {
            lblmsg.Text = "Select Atleast One Test";
        }

    }
    protected void btnstp2_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        checkdata();
        Wizard1.ActiveStepIndex = 1;
    }
    protected void btnstp3_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        checkdata();
        Wizard1.ActiveStepIndex = 2;
    }
    protected void btnstp1_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        Wizard1.ActiveStepIndex = 0;
    }
    private string CreateUsernamePwd()
    {

        var lastUserID = from userdetails in cjDataclass.UserProfiles
                         orderby userdetails.UserId descending
                         select userdetails;
        if (lastUserID.Count() > 0)
        {
            Username = txtFsName.Text.Trim().Substring(0, 4) + "00" + (lastUserID.First().UserId + 1);
        }
        else
        {
            Username = txtFsName.Text.Trim().Substring(0, 4) + "00" + 1;
        }
        return Username;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtAge.Text != "")
        {
            if (txtEmailId.Text!="" &&  txtFsName.Text!="" && txtLstName.Text!="")
            {
                if (CheckAge() == true)
                {
                    CreateUsernamePwd();
                    cjDataclass.AddUser(0, Username, Username, "User", txtFsName.Text, txtMidName.Text, txtLstName.Text, ddlGender.SelectedValue, int.Parse(txtAge.Text), txtEmailId.Text, 1, 0, int.Parse(ddlJobCatgy.SelectedValue), 1, txtdesgnation.Text, int.Parse(ddlTotExpYears.SelectedValue), int.Parse(ddlTotExpMonths.SelectedValue), int.Parse(ddlCurExpYears.SelectedValue), int.Parse(ddlCurExpMonths.SelectedValue), txtEduQual.Text, txtProffQual.Text, 1, 1, DateTime.Now, txtPhoneNumber.Text, 1, txtrecrutr.Text);
                    Wizard1.ActiveStepIndex = 2;
                }
                else
                {
                    lblMessage.Text = "Enter valid age";
                    return;
                }
                
            }
        }
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
    protected void lnkSignup_Click(object sender, EventArgs e)
    {
        Wizard1.ActiveStepIndex = 3;
    }
    protected void ddlrecruiter_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlrecruiter.SelectedItem.Text == "Yes")
        {
            txtrecrutr.Enabled = true;
        }
        else
        {
            txtrecrutr.Enabled = false;
        }
    }
}