using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_AddUserGroup : System.Web.UI.Page
{
    CJDataClassesDataContext cjDataclass = new CJDataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Logged"].ToString() == "False")
            Response.Redirect("../Default.aspx");
    }
    protected void btn_addgrpuser_Click(object sender, EventArgs e)
    {
        if (txt_grpname.Text != "")
        {
            cjDataclass.AddGroupUser(0, int.Parse(drp_org.SelectedValue), int.Parse(drp_jobcatg.SelectedValue), txt_grpname.Text, int.Parse(drp_status.SelectedValue), 1, 1);
            lbl_orgadd.Text = "User Group Details Added";
            txt_grpname.Text = "";
            grd_organ.DataBind();
        }
    }
    protected void grd_organ_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string item = e.Row.Cells[1].Text;
            foreach (Button button in e.Row.Cells[1].Controls.OfType<Button>())
            {
                if (button.CommandName == "Delete")
                {
                    button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; };";
                }
            }
        }
    }
}