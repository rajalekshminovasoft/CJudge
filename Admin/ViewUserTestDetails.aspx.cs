using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_ViewUserTestDetails : System.Web.UI.Page
{
    CJDataClassesDataContext cjDataclass = new CJDataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDatagrid();
        }
    }
    private void FillDatagrid()
    {
        if (Session["usertype"].ToString() == "User")
        {
            var usertestdet = from userdetails in cjDataclass.View_UserTests
                              where (userdetails.UserId == int.Parse(Session["UserID"].ToString()))
                              select userdetails;

            if (usertestdet.Count() > 0)
            {
                grd_usertest.DataSource = usertestdet;
                grd_usertest.DataBind();
            }
            //Add A column taketest and enable it only if the test status ""
            for (int i = 0; i < usertestdet.Count(); i++)
            {
                if (grd_usertest.Rows[i].Cells[5].Text == "NOTTAKEN")
                {
                    grd_usertest.Rows[i].Cells[8].FindControl("btntest").EnableViewState = true;
                    grd_usertest.Rows[i].Cells[8].FindControl("btnReport").EnableViewState = false;
                }
                else
                {
                    grd_usertest.Rows[i].Cells[8].FindControl("btnReport").EnableViewState = true;
                    grd_usertest.Rows[i].Cells[8].FindControl("btntest").EnableViewState = false;
                }
            }

        }
        else if (Session["usertype"].ToString() == "SuperAdmin")
        {
            var usertestdet1 = from userdetails in cjDataclass.View_UserTests
                               select userdetails;

            if (usertestdet1.Count() > 0)
            {
                grd_usertest.DataSource = usertestdet1;
                grd_usertest.DataBind();
            }
            for (int i = 0; i < usertestdet1.Count(); i++)
            {
                if (grd_usertest.Rows[i].Cells[5].Text == "NOTTAKEN")
                {
                    grd_usertest.Rows[i].Cells[8].FindControl("btntest").Visible = true;
                    grd_usertest.Rows[i].Cells[8].FindControl("btnReport").Visible = false;
                }
                else
                {
                    grd_usertest.Rows[i].Cells[8].FindControl("btnReport").Visible = true;
                    grd_usertest.Rows[i].Cells[8].FindControl("btntest").Visible = false;
                }
            }
        }
        else if (Session["usertype"].ToString() == "SpecialAdmin")
        {
            var usertestdet2 = from userdetails in cjDataclass.View_UserTests
                               where userdetails.OrganizationID == int.Parse(Session["AdminOrganizationID"].ToString())
                               select userdetails;

            if (usertestdet2.Count() > 0)
            {
                grd_usertest.DataSource = usertestdet2;
                grd_usertest.DataBind();
            }
            for (int i = 0; i < usertestdet2.Count(); i++)
            {
                if (grd_usertest.Rows[i].Cells[5].Text == "NOTTAKEN")
                {
                    grd_usertest.Rows[i].Cells[8].FindControl("btntest").Visible = true;
                    grd_usertest.Rows[i].Cells[8].FindControl("btnReport").Visible = false;
                }
                else
                {
                    grd_usertest.Rows[i].Cells[8].FindControl("btnReport").Visible = true;
                    grd_usertest.Rows[i].Cells[8].FindControl("btntest").Visible = false;
                }
            }
        }
    }
}