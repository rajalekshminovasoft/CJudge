<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/CJAdminMaster.master" AutoEventWireup="true" CodeFile="AddUserGroup.aspx.cs" Inherits="Admin_AddUserGroup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center">
        <tr>
            <td>
                <h3>
                    Add UserGroup
                </h3>
            </td>
        </tr>
        <tr>
            <td>
                Select Organization
            </td>
            <td>
                <asp:dropdownlist id="drp_org" runat="server" AutoPostBack="True" DataSourceID="lnqdrporg" DataTextField="Name" DataValueField="OrganizationID"></asp:dropdownlist>
                <asp:LinqDataSource ID="lnqdrporg" runat="server" ContextTypeName="CJDataClassesDataContext" OrderBy="Name" Select="new (OrganizationID, Name)" TableName="Organizations">
                </asp:LinqDataSource>
            </td>
        </tr>
        <tr>
            <td>
                Select JobCategory
            </td>
            <td>
                <asp:dropdownlist id="drp_jobcatg" runat="server" AutoPostBack="True" DataSourceID="lnqdrpjobcat" DataTextField="Name" DataValueField="JobCatID"></asp:dropdownlist>
                <asp:LinqDataSource ID="lnqdrpjobcat" runat="server" ContextTypeName="CJDataClassesDataContext" OrderBy="Name" Select="new (JobCatID, Name)" TableName="JobCategories">
                </asp:LinqDataSource>
            </td>
        </tr>
        <tr>
            <td>Group Name</td>
            <td>
                <asp:textbox id="txt_grpname" runat="server"></asp:textbox>
            </td>
        </tr>
        <tr>
            <td>
                Select Status
            </td>
            <td>
                <asp:dropdownlist id="drp_status" runat="server">
                     <asp:ListItem Text="Active" Value="1">Active</asp:ListItem>
                    <asp:ListItem Text="Inactive" Value="0">InActive</asp:ListItem>
                </asp:dropdownlist>
            </td>
        </tr>
         <tr>
            <td>
                <asp:button id="btn_addgrpuser" runat="server" text="Add UserGroup" OnClick="btn_addgrpuser_Click"  />
                <asp:label id="lbl_orgadd" runat="server" ></asp:label>
            </td>
        </tr>
        <tr>
            <td>
                 <asp:GridView ID="grd_organ" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="GroupUserID" EnableModelValidation="True" PageSize="50" DataSourceID="lnqgrpuser" >
                                <Columns>
                                    <asp:CommandField ShowEditButton="True" />
                                    <asp:BoundField DataField="GroupUserID" HeaderText="GroupUserID" InsertVisible="False" ReadOnly="True" SortExpression="GroupUserID" />
                                    <asp:BoundField DataField="GroupName" HeaderText="GroupName" SortExpression="GroupName" />
                                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                                </Columns>
                                <EditRowStyle ForeColor="Maroon" />
                                <RowStyle ForeColor="#800000" />
                            </asp:GridView>
                 
                 <asp:LinqDataSource ID="lnqgrpuser" runat="server" ContextTypeName="CJDataClassesDataContext" EnableDelete="True" EnableUpdate="True" TableName="GroupUsers">
                 </asp:LinqDataSource>
                 
            </td>
        </tr>
    </table>
</asp:Content>

