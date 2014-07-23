<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/CJAdminMaster.master" ValidateRequest="false"   AutoEventWireup="true" CodeFile="AddInstrByDisplayType.aspx.cs" Inherits="Admin_AddInstrByDisplayType" %>
<%@ Register assembly="FreeTextBox" namespace="FreeTextBoxControls" tagprefix="FTB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Left">
    <table width="75%" align="center">
           
            <tr>
                <td>
                    &nbsp;</td>
                <caption>
                    <td<h3>
                    &nbsp;Instructions By Display Type<h3></h3> </td>
            </td<h3>
                </caption>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblOrganization" runat="server" Text="Organization"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlOrganization" runat="server" 
                        AppendDataBoundItems="True" AutoPostBack="True" DataSourceID="LinqOrganization" 
                        DataTextField="Name" DataValueField="OrganizationID" 
                        onselectedindexchanged="ddlOrganization_SelectedIndexChanged">
                        <asp:ListItem Value="0">-- Select --</asp:ListItem>
                    </asp:DropDownList>
                    <asp:LinqDataSource ID="LinqOrganization" runat="server" 
                        ContextTypeName="CJDataClassesDataContext" 
                        Select="new (OrganizationID, Name)" TableName="Organizations" 
                        Where="AdminAccess == @AdminAccess &amp;&amp; Status == @Status">
                        <WhereParameters>
                            <asp:Parameter DefaultValue="1" Name="AdminAccess" Type="Int32" />
                            <asp:Parameter DefaultValue="1" Name="Status" Type="Int32" />
                        </WhereParameters>
                    </asp:LinqDataSource>
                </td>
            </tr>
            <tr>
                <td>
                    Category</td>
                <td>
                    <asp:DropDownList ID="ddlQuestionType" runat="server" 
                        AppendDataBoundItems="True" AutoPostBack="True" 
                        onselectedindexchanged="ddlQuestionType_SelectedIndexChanged" Width="250px">
                        <asp:ListItem Value="0">-- Select --</asp:ListItem>
                        <asp:ListItem Value="7">Word Type Memmory Questions</asp:ListItem>
                        <asp:ListItem Value="8">Image Type Memmory Questions</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Display Type</td>
                <td>
                    <asp:DropDownList ID="ddlDisplayType" runat="server" 
                        AppendDataBoundItems="True" AutoPostBack="True"  Width="250px" OnSelectedIndexChanged="ddlDisplayType_SelectedIndexChanged">
                        <asp:ListItem Value="0">-- Select --</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Instruction Details</td>
                <td>
                    <FTB:FreeTextBox ID="txtInstructions" runat="Server" Height="200px" Text="" 
                        ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline,Strikethrough;Superscript,Subscript,RemoveFormat" 
                        ToolbarStyleConfiguration="NotSet" UpdateToolbar="True" Width="550px"></FTB:FreeTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" 
                                    Text="Submit" />
                            </td>
                            <td>
                                <asp:Button ID="btnReset" runat="server" onclick="btnReset_Click" 
                                    Text="Reset" />
                            </td>
                            <td>
                                <asp:Button ID="btnDelete" runat="server" onclick="btnDelete_Click" 
                                    Text="Delete" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
         </asp:Panel> 
</asp:Content>

