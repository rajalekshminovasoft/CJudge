using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Admin_InfokitDetails : System.Web.UI.Page
{
    CJDataClassesDataContext cjDataclass = new CJDataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private void ClearControl()
    {
        txt_catgname.Text = "";
        txt_Disorder.Text = "";
    }
    protected void btn_AddCategory_Click(object sender, EventArgs e)
    {
        if (txt_catgname.Text != "" && txt_Disorder.Text != "")
        {
            cjDataclass.AddInfokitCategory(0, txt_catgname.Text, int.Parse(txt_Disorder.Text), 1, 1);
            lblmsg.Text = "Category added";
            ClearControl();
        }
    }
    protected void btn_addfiledetails_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_disname.Text != "" && txt_disorderdet.Text != "" && flupload.HasFile == true)
            {
                string fname = flupload.FileName;
                flupload.SaveAs(Server.MapPath("~/images/InfoKitFiles/") + fname);
                //cjDataclass.AddInfokitFileDetails(0,int.Parse(drp_Category.SelectedValue), txt_disname.Text, flupload.FileName, int.Parse(txt_Disorder.Text), 1, 1);
                cjDataclass.AddInfokitFileDetails(0, int.Parse(drp_Category.SelectedValue), txt_disname.Text, fname, int.Parse(txt_disorderdet.Text), 1, 1);
                lbl_msgfileadded.Text = "File Details Added";
                txt_disname.Text = "";
                txt_disorderdet.Text = "";
            }
        }
        catch (Exception ex)
        { }
    }



    protected void btn_dyncontent_Click(object sender, EventArgs e)
    {
        if (txt_descriptioncontnt.Text != "" && flu_image.HasFile == true)
        {
            string fname = flu_image.FileName;
            flu_image.SaveAs(Server.MapPath("~/images/InfoKitFiles/") + fname);
            cjDataclass.AddInfokitDynamicContent(0, fname, txt_descriptioncontnt.Text, "", "", "", "", "", "", "", "", "", 1, 1);
            lbl_dynadded.Text = "Dyanamic Content Added";
            txt_descriptioncontnt.Text = "";
        }
    }
}