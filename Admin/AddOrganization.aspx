<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/CJAdminMaster.master" AutoEventWireup="true" CodeFile="AddOrganization.aspx.cs" Inherits="Admin_AddOrganization" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center">
        <tr>
            <td>
                <h3>Add Organization</h3>
            </td>
        </tr>
        <tr>
            <td>Organization Name</td>
            <td>
                <asp:textbox id="txt_orgname" runat="server"></asp:textbox>
            </td>
        </tr>
        <tr>
            <td>Image On Left</td>
            <td>
                <asp:fileupload id="fup_leftimage" runat="server"></asp:fileupload>
            </td>
        </tr>
         <tr>
            <td>Image On Center</td>
            <td>
                <asp:fileupload id="fup_centerimage" runat="server"></asp:fileupload>
            </td>
        </tr>
         <tr>
            <td>Image On Right</td>
            <td>
                <asp:fileupload id="fup_rightimage" runat="server"></asp:fileupload>
            </td>
        </tr>
         <tr>
            <td>Organization Status</td>
            <td>
                <asp:dropdownlist id="drp_status" runat="server">
                     <asp:ListItem Text="Active" Value="1">Active</asp:ListItem>
                    <asp:ListItem Text="Inactive" Value="0">InActive</asp:ListItem>
                </asp:dropdownlist>
            </td>
        </tr>
        <tr>
            <td>
                <asp:button id="btn_addOrg" runat="server" text="Add Organization" OnClick="btn_addOrg_Click" />
                <asp:label id="lbl_orgadd" runat="server" ></asp:label>
            </td>
        </tr>
        <tr>
            <td>
                 <asp:GridView ID="grd_organ" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="OrganizationID" EnableModelValidation="True" PageSize="50" DataSourceID="lnqOrg">
                                <Columns>
                                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                                    <asp:BoundField DataField="OrganizationID" HeaderText="OrganizationID" InsertVisible="False" ReadOnly="True" SortExpression="OrganizationID" />
                                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                                </Columns>
                                <EditRowStyle ForeColor="Maroon" />
                                <RowStyle ForeColor="#800000" />
                            </asp:GridView>
                 <asp:LinqDataSource ID="lnqOrg" runat="server" ContextTypeName="CJDataClassesDataContext" EnableDelete="True" EnableUpdate="True" TableName="Organizations">
                 </asp:LinqDataSource>
            </td>
        </tr>
    </table>
</asp:Content>

