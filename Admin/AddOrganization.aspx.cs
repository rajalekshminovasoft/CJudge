using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Admin_AddOrganization : System.Web.UI.Page
{
    CJDataClassesDataContext cjDataclass = new CJDataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Logged"].ToString() == "False")
            Response.Redirect("../Default.aspx");
    }
    protected void btn_addOrg_Click(object sender, EventArgs e)
    {
        if (txt_orgname.Text != "")
        {
            if (fup_rightimage.HasFile == true)
            {
                fup_rightimage.SaveAs(Server.MapPath("~/images/InfoKitFiles/") + fup_rightimage.FileName.ToString());
            }
            if (fup_leftimage .HasFile == true)
            {
                fup_leftimage.SaveAs(Server.MapPath("~/images/InfoKitFiles/") + fup_leftimage.FileName.ToString());
            }
            if (fup_centerimage.HasFile == true)
            {
                fup_centerimage.SaveAs(Server.MapPath("~/images/InfoKitFiles/") + fup_centerimage.FileName.ToString());
            }
            cjDataclass.AddOrganization(0, txt_orgname.Text, int.Parse(drp_status.SelectedValue), 1, fup_rightimage.FileName, 1, fup_leftimage.FileName, fup_centerimage.FileName);
            lbl_orgadd.Text = "Organization added";
            grd_organ.DataBind();
        }
    }
}