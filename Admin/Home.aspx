<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/CJAdminMaster.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Admin_Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" width="80%">
        <tr>
            <td style="width:20%; text-align:center;" >
                <asp:imagebutton id="imgbtn_testlist" runat="server" width="100px" hight="100px" ImageUrl="~/images/TestList.png" OnClick="imgbtn_testlist_Click"  ></asp:imagebutton><br />
                <center><asp:label id="LAbel" runat="server" text="Test List" Font-Bold="True" ForeColor="Maroon"></asp:label></center>
            </td>
             <td style="width:20%; text-align:center;" >
                <asp:imagebutton id="imgbtn_Report" runat="server" width="100px" hight="100px" ImageUrl="~/images/Report.png" OnClick="imgbtn_Report_Click"></asp:imagebutton><br />
                 <center> <asp:label id="LAbel1" runat="server" text="Report" Font-Bold="True" ForeColor="Maroon"></asp:label></center> 
            </td>
                        <td style="width:20%; text-align:center;" >
                <asp:imagebutton id="imgbtn_User" runat="server" width="100px" hight="100px" ImageUrl="~/images/User.png" OnClick="imgbtn_User_Click" ></asp:imagebutton><br />
                <center><asp:label id="LAbel2" runat="server" text="Add User" Font-Bold="True" ForeColor="Maroon"></asp:label></center>
            </td>
             <td style="width:20%; text-align:center;" >
                <asp:imagebutton id="imgbtn_infokit" runat="server" width="100px" hight="100px" ImageUrl="~/images/Infokit.png" OnClick="imgbtn_infokit_Click"></asp:imagebutton><br />
                 <center> <asp:label id="LAbel3" runat="server" text="Infokit Details" Font-Bold="True" ForeColor="Maroon"></asp:label></center> 
            </td>
        </tr>
        <tr>
            <td style="width:20%; text-align:center;" >
                <asp:imagebutton id="imgbtn_Qunbank" runat="server" width="100px" hight="100px" ImageUrl="~/images/QuestionBank.png" OnClick="imgbtn_Qunbank_Click" ></asp:imagebutton><br />
                <center><asp:label id="LAbel4" runat="server" text="Add Questions" Font-Bold="True" ForeColor="Maroon"></asp:label></center>
            </td>
             <td style="width:20%; text-align:center;" >
                <asp:imagebutton id="imgbtn_assigntest" runat="server" width="100px" hight="100px" ImageUrl="~/images/AssignTest.png" OnClick="imgbtn_assigntest_Click"></asp:imagebutton><br />
                 <center> <asp:label id="LAbel5" runat="server" text="Assign Test" Font-Bold="True" ForeColor="Maroon"></asp:label></center> 
            </td>
                        <td style="width:20%; text-align:center;" >
                <asp:imagebutton id="imgbtn_repdescript" runat="server" width="100px" hight="100px" ImageUrl="~/images/AddREportDesc.png" OnClick="imgbtn_repdescript_Click" ></asp:imagebutton><br />
                <center><asp:label id="LAbel6" runat="server" text="Add Report Description" Font-Bold="True" ForeColor="Maroon"></asp:label></center>
            </td>
             <td style="width:20%; text-align:center;" >
                <asp:imagebutton id="imgbtn_addspecialadmin" runat="server" width="100px" hight="100px" ImageUrl="~/images/AddSpecialAdmin.png" OnClick="imgbtn_addspecialadmin_Click"></asp:imagebutton><br />
                 <center> <asp:label id="LAbel7" runat="server" text="Add Special Admin" Font-Bold="True" ForeColor="Maroon"></asp:label></center> 
            </td>
        </tr>
        <tr>
            <td style="width:20%; text-align:center;" >
                <asp:imagebutton id="imgbtn_specialadpermission" runat="server" width="100px" hight="100px" ImageUrl="~/images/SpecialAdminPermission.png" OnClick="imgbtn_specialadpermission_Click" ></asp:imagebutton><br />
                <center><asp:label id="LAbel8" runat="server" text="SpecialAdminPermission" Font-Bold="True" ForeColor="Maroon"></asp:label></center>
            </td>
           <%--  <td style="width:20%; text-align:center;" >
                <asp:imagebutton id="Imagebutton8" runat="server" width="100px" hight="100px" ImageUrl="~/images/Report.png"></asp:imagebutton><br />
                 <center> <asp:label id="LAbel9" runat="server" text="Report" Font-Bold="True" ForeColor="Maroon"></asp:label></center> 
            </td>
                        <td style="width:20%; text-align:center;" >
                <asp:imagebutton id="Imagebutton9" runat="server" width="100px" hight="100px" ImageUrl="~/images/TestList.png" ></asp:imagebutton><br />
                <center><asp:label id="LAbel10" runat="server" text="Test List" Font-Bold="True" ForeColor="Maroon"></asp:label></center>
            </td>
             <td style="width:20%; text-align:center;" >
                <asp:imagebutton id="Imagebutton10" runat="server" width="100px" hight="100px" ImageUrl="~/images/Report.png"></asp:imagebutton><br />
                 <center> <asp:label id="LAbel11" runat="server" text="Report" Font-Bold="True" ForeColor="Maroon"></asp:label></center> 
            </td>--%>
        </tr>
    </table>
</asp:Content>

