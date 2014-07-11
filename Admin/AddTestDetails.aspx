<%@ Page Title="" ValidateRequest="false" Language="C#" MasterPageFile="~/Admin/CJAdminMaster.master" AutoEventWireup="true" CodeFile="AddTestDetails.aspx.cs" Inherits="Admin_AddTestDetails" %>
<%@ Register assembly="FreeTextBox" namespace="FreeTextBoxControls" tagprefix="FTB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center">
        <tr>
            <td><h3>Add Test Details</h3></td>
        </tr>
   <tr>
            <td class="label">
                <asp:Label ID="lblOrganization" runat="server" Text="Organization"></asp:Label>
            </td>
            <td colspan="2">
                <asp:DropDownList ID="ddl_Org" runat="server" 
                    AppendDataBoundItems="True" AutoPostBack="True" Width="502px" DataSourceID="lnqOrg" DataTextField="Name" DataValueField="OrganizationID" >                    
                </asp:DropDownList>

                <asp:LinqDataSource ID="lnqOrg" runat="server" ContextTypeName="CJDataClassesDataContext" OrderBy="Name" Select="new (OrganizationID, Name)" TableName="Organizations">
                </asp:LinqDataSource>

            </td>
        </tr>
        <tr>
            <td class="label">
                Test Name</td>
            <td colspan="2">
                <asp:TextBox ID="txt_TestName" runat="server" Width="500px" MaxLength="299"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="label">
                Report Type</td>
            <td>
                <asp:DropDownList ID="drp_ReportType" runat="server">
                    <asp:ListItem Value="0">-- Select --</asp:ListItem>
                    <asp:ListItem>Interpretative Report</asp:ListItem>
                    <asp:ListItem>Indicative Report</asp:ListItem>
                    <asp:ListItem>Certification Report</asp:ListItem>
                </asp:DropDownList>
            
            
                <asp:CheckBox ID="chbGroupReport" runat="server" Text="Group Report Access" />
            </td>
        </tr>
        <tr>
            <td class="label">
                Instructions</td>
            <td >
                <FTB:FreeTextBox ID="txt_instruction" runat="Server" Height="300px" Text="" 
                                                Width="525px" 
                                                ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline,Strikethrough;Superscript,Subscript,RemoveFormat" 
                                              ToolbarStyleConfiguration="NotSet" 
                    UpdateToolbar="True"></FTB:FreeTextBox></td>
        </tr>
        <tr>
            <td>Price</td>
            <td>
                <asp:TextBox ID="txt_price" runat="server" Width="514px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Passmark</td>
            <td>
                <asp:TextBox ID="txt_passmark" runat="server" Width="514px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Remark</td>
            <td>
                <asp:TextBox ID="txt_remark" runat="server" Height="49px" TextMode="MultiLine" Width="520px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Status</td>
            <td colspan="2">
                <asp:DropDownList ID="ddlStatus" runat="server" Width="128px">
                    <asp:ListItem Value="1">Active</asp:ListItem>
                    <asp:ListItem Value="0">Inactive</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td colspan="2">
                <asp:Label ID="lblMessage" runat="server" ForeColor="#CC3300"></asp:Label>
            </td>
        </tr>
         <tr>
                        <td>
                <asp:Button ID="btnAdd" runat="server"  Text="Add Test Details" OnClick="btnAdd_Click" />
                        </td>
             </tr> 
        <tr>
            <td colspan="3">
                 <asp:GridView ID="grd_designation" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="TestId" DataSourceID="lnqtest" EnableModelValidation="True" PageSize="50">
                                <Columns>
                                    <asp:CommandField ShowDeleteButton="false" ShowEditButton="True" />
                                    <asp:BoundField DataField="TestId" HeaderText="TestId" InsertVisible="False" ReadOnly="True" SortExpression="TestId" />
                                    <asp:BoundField DataField="TestName" HeaderText="TestName" SortExpression="TestName" />
                                    <asp:BoundField DataField="OrganizationName" HeaderText="OrganizationName" SortExpression="OrganizationName" />
                                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                                    <asp:BoundField DataField="PassMark" HeaderText="PassMark" SortExpression="PassMark" />
                                    <asp:BoundField DataField="Instructions" HeaderText="Instructions" SortExpression="Instructions" ItemStyle-Height="100px" ItemStyle-Font-Size="X-Small" ItemStyle-Wrap="true"  />
                                    <asp:BoundField DataField="ReportType" HeaderText="ReportType" SortExpression="ReportType" />
                                    <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                                    <asp:BoundField DataField="Remark" HeaderText="Remark" SortExpression="Remark" />
                                </Columns>
                                <EditRowStyle ForeColor="Maroon" />
                                <RowStyle ForeColor="#800000" />
                            </asp:GridView>
                 <asp:LinqDataSource ID="lnqtest" runat="server" ContextTypeName="CJDataClassesDataContext" EnableDelete="True" EnableUpdate="True" TableName="TestLists">
                 </asp:LinqDataSource>
            </td>
        </tr>
    </table>
</asp:Content>

