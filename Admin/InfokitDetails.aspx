<%@ Page Title="" ValidateRequest="false" Language="C#" MasterPageFile="~/Admin/CJAdminMaster.master" AutoEventWireup="true" CodeFile="InfokitDetails.aspx.cs" Inherits="Admin_InfokitDetails" %>
<%@ Register assembly="FreeTextBox" namespace="FreeTextBoxControls" tagprefix="FTB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <table align="center">
<tr>
    <td><h3>Add Category Details</h3></td>
</tr>        <tr>
            <td>CategoryName</td>
            <td>
                <asp:textbox id="txt_catgname" runat="server"></asp:textbox>
            </td>
            <td>Disply Order</td>
            <td>
                <asp:textbox id="txt_Disorder" runat="server"></asp:textbox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:button id="btn_AddCategory" runat="server" text="Add Category" 
                    OnClick="btn_AddCategory_Click" OnClientClick="this.disabled='true';return true;" />
            </td>
            <td>
                <asp:Label ID="lblmsg" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td><h3>Add Infokit File List</h3></td>
        </tr>
        <tr>
            <td>Select Category</td>
            <td>
                <asp:DropDownList ID="drp_Category" runat="server" AutoPostBack="True" DataSourceID="CategoryList" DataTextField="CategoryName" DataValueField="CategoryId"></asp:DropDownList>
                <asp:LinqDataSource ID="CategoryList" runat="server" ContextTypeName="CJDataClassesDataContext" OrderBy="CategoryId" Select="new (CategoryId, CategoryName)" TableName="InfokitCategories">
                </asp:LinqDataSource>
            </td>
              <td>Select File</td>
            <td>
                <asp:FileUpload ID="flupload" runat="server" /></td>
        </tr>
        <tr>
            <td>Select Display Name</td>
            <td>
                <asp:TextBox ID="txt_disname" runat="server"></asp:TextBox></td>
         
            <td>Select Display Order</td>
            <td>
                <asp:TextBox ID="txt_disorderdet" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:button id="btn_addfiledetails" runat="server" text="Add Infokit File Details" 
                     OnClick="btn_addfiledetails_Click" />
            </td>
            <td>
                <asp:Label ID="lbl_msgfileadded" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td><h3>Add InfoKit Dyanamic Content</h3></td>
        </tr>
        <tr>
            <td>Select Image</td>
            <td>
                <asp:FileUpload ID="flu_image" runat="server" /></td>
            </tr>
        <tr><td>Add Description</td>
            <td>
                 <FTB:FreeTextBox ID="txt_descriptioncontnt" runat="Server" Height="200px" Text="" 
                        ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline,Strikethrough;Superscript,Subscript,RemoveFormat" 
                        ToolbarStyleConfiguration="NotSet" UpdateToolbar="True" Width="550px"></FTB:FreeTextBox>
            </td>
        </tr>
       <tr>
           <td>
               <asp:Button ID="btn_dyncontent" runat="server" Text="AddDyanamic Content" OnClick="btn_dyncontent_Click"  />
           </td>
           <td>
               <asp:Label ID="lbl_dynadded" runat="server" ></asp:Label></td>
       </tr>
    </table>
</asp:Content>

