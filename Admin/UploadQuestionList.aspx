<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/CJAdminMaster.master" AutoEventWireup="true" CodeFile="UploadQuestionList.aspx.cs" Inherits="Admin_UploadQuestionList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="75%" align="center">
         <tr>
            <td colspan="2" 
                valign="top">
                <div class="titlemain">
                Upload&nbsp; Questions</div>
            </td>
        </tr>
        <tr>
            <td class="label">
                Section Category</td>
            <td>
                <asp:DropDownList ID="ddlSectionCategory" runat="server" 
                    AppendDataBoundItems="True" AutoPostBack="True" 
                    onselectedindexchanged="ddlSectionCategory_SelectedIndexChanged" 
                    Width="450px"  DataTextField="SectionCategoryName" DataValueField="SectionCategoryId">
                    <asp:ListItem Value="0">-- Select Section Category --</asp:ListItem>
                </asp:DropDownList>
                
                <asp:LinqDataSource ID="lnqseccatname" runat="server" ContextTypeName="CJDataClassesDataContext" OrderBy="SectionCategoryName" Select="new (SectionCategoryId, SectionCategoryName)" TableName="SectionCategories" Where="Status == @Status">
                    <WhereParameters>
                        <asp:Parameter DefaultValue="1" Name="Status" Type="Int32" />
                    </WhereParameters>
                </asp:LinqDataSource>
                
            </td>
        </tr>
        <tr>
            <td class="label">
                Section</td>
            <td>
                <asp:DropDownList ID="ddlSectionList" runat="server" 
                    AppendDataBoundItems="True" AutoPostBack="True" 
                    onselectedindexchanged="ddlSectionList_SelectedIndexChanged" Width="450px">
                    <asp:ListItem Value="0">-- Select --</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="label">
                1st Level SubSection</td>
            <td>
                <asp:DropDownList ID="ddlFirstLevelList" runat="server" 
                    AppendDataBoundItems="True" AutoPostBack="True" 
                    onselectedindexchanged="ddlFirstLevelList_SelectedIndexChanged" Width="450px">
                    <asp:ListItem Value="0">-- Select --</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="label">
                2nd Level SubSection</td>
            <td>
                <asp:DropDownList ID="ddlSecondLevelList" runat="server" 
                    AppendDataBoundItems="True" Width="450px" AutoPostBack="True" 
                    onselectedindexchanged="ddlSecondLevelList_SelectedIndexChanged">
                    <asp:ListItem Value="0">-- Select --</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="label">
                Category</td>
            <td>
                <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlCategory_SelectedIndexChanged" 
                    style="height: 22px" Width="450px">
                    <asp:ListItem Value="0">-- Select --</asp:ListItem>
                    <asp:ListItem Value="Objective">Objective Type Question</asp:ListItem>
                    <asp:ListItem Value="FillBlanks">Fill in the Blanks Question</asp:ListItem>
                    <asp:ListItem Value="RatingType">Rating Type Question</asp:ListItem>
                    <asp:ListItem Value="ImageType">Image Type Question</asp:ListItem>
                    <asp:ListItem Value="VideoType">Video Type Question</asp:ListItem>
                    <asp:ListItem Value="AudioType">Audio Type Question</asp:ListItem>
                    <asp:ListItem Value="MemTestWords">Memmory Test (Words)</asp:ListItem>
                    <asp:ListItem Value="MemTestImages">Memmory Test (Images)</asp:ListItem>
                    <asp:ListItem Value="PhotoType">Photo Type Question</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Select File
            </td>
            <td>
                <asp:fileupload ID="fileupload1" runat="server"></asp:fileupload>
            </td>
        </tr>
        <tr>
            <td>
                <asp:button id="btn_add" runat="server" text="Upload" OnClick="btn_add_Click" />
                <asp:label id="lblmsg" runat="server" ></asp:label>
            </td>
        </tr>
    </table>
</asp:Content>

