using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_AddTestSectionDetails : System.Web.UI.Page
{
    CJDataClassesDataContext cjDataclass = new CJDataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (txtSectionName.Text != "")
        {
            cjDataclass.AddTestSectionsList(0, int.Parse(drp_TestName.SelectedValue), txtSectionName.Text, 1, 1, 1);
            lblMessage.Text = "Test Section Added";
            txtSectionName.Text = "";
        }
    }
}