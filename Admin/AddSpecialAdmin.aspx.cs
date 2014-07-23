using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_AddSpecialAdmin : System.Web.UI.Page
{
    CJDataClassesDataContext cjDataclass = new CJDataClassesDataContext();
    string Username = "";
    int organizationid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserCode"] != null)
        {
            txtPassword.Enabled = false; ddlOrg.Enabled = false;
        }

        if (ViewState["Password"] != null)
            txtPassword.Attributes.Add("Value", ViewState["Password"].ToString());
        ddlOrg.DataBind();
        if (!IsPostBack)
            fillValues();

        fillDataGrid();
    }
    private string CreateUsernamePwd()
    {

        var lastUserID = from userdetails in cjDataclass.UserProfiles
                         orderby userdetails.UserId descending
                         select userdetails;
        if (lastUserID.Count() > 0)
        {
            Username = txtUserName.Text.Trim().Substring(0, 4).ToUpper() + "00" + (lastUserID.First().UserId + 1);
        }
        else
        {
            Username = txtUserName.Text.Trim().Substring(0, 4).ToUpper() + "00" + 1;
        }
        return Username;
    }
    private string ValidateDate(string ctrl)
    {
        try
        {
            if (ctrl.Length != 10)
            { lblMessage.Text = "Enter valid date"; return ""; }

            //DateTime dt = DateTime.Parse(txtPassword.Text);
            string dt = ctrl;
            string dateCheck = "";
            string date = "";
            string month = "";
            string year = "";
            for (int i = 0; i < dt.Length; i++)
            {
                char[] a = dt.ToCharArray();
                if (i < 2)
                    date += (a[i]).ToString();
                else if (i > 2 && i < 5)
                    month += (a[i]).ToString();
                else if (i > 5)
                    year += (a[i]).ToString();

            }
            dateCheck = month + "-" + date + "-" + year;
            string curdate = date + "-" + month + "-" + year;
            DateTime curdt = DateTime.Parse(dateCheck);
            //Session["dob"] = curdate;
            return curdt.ToString("MM-dd-yyyy");
        }
        catch (Exception ex)
        {
            lblMessage.Text = "Enter valid date "; return "";
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtUserName.Text.Trim() == "" || txtPassword.Text.Trim() == "" || ddlOrg.SelectedIndex < 0)
        { lblMessage.Text = "Enter the values"; }
        else
        {
            if (txtPassword.Text != "")
                ViewState["Password"] = txtPassword.Text;
            string fromDate = ValidateDate(txtLoginFromDate.Text );
            string toDate = ValidateDate(txtLoginToDate.Text);

            DateTime dtFrom = DateTime.Now.AddDays(-1);
            DateTime dtTo = DateTime.Now.AddDays(-1);

            if (fromDate != "")
                dtFrom = DateTime.Parse(fromDate);
            if (toDate != "")
                dtTo = DateTime.Parse(toDate);

            if (dtFrom > dtTo)
            { lblMessage.Text = "From Date must be less than Todate"; return; }

            
            CreateUsernamePwd();
            int testid = 0;

            organizationid = int.Parse(ddlOrg.SelectedValue);
            int status = int.Parse(ddlStatus.SelectedValue);
            string emailid = txtEmailId.Text.Trim();
            //Add New User with usertype special admin
            
            cjDataclass.AddUserByAdmin(Username, Username, "SpecialAdmin", int.Parse(ddlOrg.SelectedValue), 0, dtFrom , dtTo , int.Parse(ddlStatus.SelectedValue), 1, txtEmailId.Text.Trim(), 1, "","","", "",0, 0, 0, "", "", "");
            int adminaccess = 0;
            if (status == 0)
            {
                adminaccess = 1;
            }
            
            lblMessage.Text = "Values Saved";
            ClearControls();
            Session["UserCode"] = null;
            fillDataGrid();
            Session["OrgIndex"] = null;
            ddlOrg.SelectedIndex = 0;

        }

    }
    private void ClearControls()
    {
        txtUserName.Text = "";
        txtPassword.Text = "";
        txtLoginFromDate.Text = "";
        txtLoginToDate.Text = "";
        txtEmailId.Text = "";
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (Session["UserCode"] != null)
        {
            //lblMessageDelete.Text += "(" + ddlOrg.SelectedItem.Text + ")?";
            //cjDataclass.UpdateUserType(
             string fromDate = ValidateDate(txtLoginFromDate.Text );
            string toDate = ValidateDate(txtLoginToDate.Text);

            DateTime dtFrom = DateTime.Now.AddDays(-1);
            DateTime dtTo = DateTime.Now.AddDays(-1);

            if (fromDate != "")
                dtFrom = DateTime.Parse(fromDate);
            if (toDate != "")
                dtTo = DateTime.Parse(toDate);

            if (dtFrom > dtTo)
            { lblMessage.Text = "From Date must be less than Todate"; return; }

            cjDataclass.UpdateUserType(int.Parse(Session[""].ToString()), txtUserName.Text, txtPassword.Text, "SpecialAdmin", int.Parse(ddlOrg.SelectedValue), 0, dtFrom, dtTo, int.Parse(ddlStatus.SelectedValue), 1, txtEmailId.Text, 1);
            lblMessageDelete.Text = "Details Updated";
            fillDataGrid();
        }
        else lblMessage.Text = "Please select a user for deletion";
    }
    protected void gvwSpecialAdminCreation_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnupdate.Visible = true;
        btnSubmit.Visible = false;
        Session["UserCode"] = gvwSpecialAdminCreation.SelectedRow.Cells[3].Text;
        fillValues();
    }
    private void fillValues()
    {
        int userID = 0;
        if (Session["UserCode"] != null)
            userID = int.Parse(Session["UserCode"].ToString());
        if (userID > 0)
        {
            var details1 = from details in cjDataclass.UserProfiles where details.UserId == userID select details;

            if (details1.Count() > 0)
            {
                if (details1.First().UserName != null)
                    txtUserName.Text = details1.First().UserName.ToString();

                txtPassword.Enabled = false;
                txtPassword.Text = details1.First().Password.ToString();
                txtPassword.Attributes["Value"] = txtPassword.Text;
                ViewState["Password"] = txtPassword.Text;
                txtPassword.Attributes.Add("Value", ViewState["Password"].ToString());

                if (details1.First().OrganizationID != null)
                    for (int i = 0; i < ddlOrg.Items.Count; i++)
                    {
                        if (ddlOrg.Items[i].Value == details1.First().OrganizationID.ToString())
                        {
                            ddlOrg.SelectedIndex = i;
                            Session["OrgIndex"] = i.ToString();
                            ddlOrg.Enabled = false;
                            break;
                        }
                    }


                if (details1.First().LoginFromDate != null)
                    txtLoginFromDate.Text = DateTime.Parse(details1.First().LoginFromDate.ToString()).ToString("dd-MM-yyyy");
                if (details1.First().LoginToDate != null)
                    txtLoginToDate.Text = DateTime.Parse(details1.First().LoginToDate.ToString()).ToString("dd-MM-yyyy");

                if (details1.First().Status != null)
                    ddlStatus.SelectedValue = details1.First().Status.ToString();
                if (details1.First().EmailId != null)
                    txtEmailId.Text = details1.First().EmailId.ToString();



            }
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        ClearControls();
        Session["UserCode"] = null;
        txtUserName.Text = "";
        txtPassword.Text = "";
        ddlOrg.SelectedIndex = 0;
        ddlOrg.Enabled = true; txtPassword.Enabled = true;

    }
    protected void gvwSpecialAdminCreation_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvwSpecialAdminCreation.PageIndex = e.NewPageIndex;
        fillDataGrid();
    }
    private void fillDataGrid()
    {

        var userdetailfromdb = from userdet in cjDataclass.UserProfiles
                               where userdet.AdminAccess == 1 && userdet.UserType == "SpecialAdmin"
                               select userdet;// new {"UserName, Password, UserType, OrgName, GroupName, UserId, OrganizationID, GroupUserID, LoginFromDate, LoginToDate, ReportAccess, Status, EmailId"};

        gvwSpecialAdminCreation.DataSource = userdetailfromdb;
        gvwSpecialAdminCreation.DataBind();
        //if (gvwSpecialAdminCreation.Rows.Count <= 0)
        //    btnDeleteAll.Visible = false;
    }
}