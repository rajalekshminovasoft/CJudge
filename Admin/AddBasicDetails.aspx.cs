using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_AddBasicDetails : System.Web.UI.Page
{
    CJDataClassesDataContext cjDataclass = new CJDataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_AddDesig_Click(object sender, EventArgs e)
    {
        if (txt_designame.Text != "" )
        {
            cjDataclass.AddDesignation(0, txt_designame.Text,int.Parse(drp_dsgstatus.SelectedValue), 1);
            lbl_desig.Text = "Designation added";
        }
    }
    protected void btn_AddIndustry_Click(object sender, EventArgs e)
    {
        if (txt_industryname.Text != "")
        {
            cjDataclass.AddIndustry(0, txt_industryname.Text, int.Parse(drp_Indstatus.SelectedValue), 1);
            lbl_addindustry.Text = "Industry added";
        }
    }
    protected void btn_AddOccupation_Click(object sender, EventArgs e)
    {
        if (txt_OccName.Text != "")
        {
            cjDataclass.AddJobCategory(0, txt_OccName.Text, int.Parse(drp_occstatus.SelectedValue), 1,1);
            lbl_addoccpn.Text = "Occupation added";
        }
    }
    protected void btn_AddQualfn_Click(object sender, EventArgs e)
    {
        if (txt_qualName.Text != "")
        {
            cjDataclass.AddQualification(0, txt_qualName.Text, int.Parse(drp_qualstatus.SelectedValue), 1);
            lbl_addqualfn.Text = "Qualification added";
        }
    }
}