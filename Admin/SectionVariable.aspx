<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/CJAdminMaster.master" AutoEventWireup="true" CodeFile="SectionVariable.aspx.cs" Inherits="Admin_SectionVariable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center">
        <tr>
            <td>
                Section Category</td>
            <td>
                <asp:DropDownList ID="ddlSectionCategory" runat="server" 
                    AppendDataBoundItems="True" AutoPostBack="True" Width="310px" DataSourceID="lnqsecCategory" DataTextField="SectionCategoryName" DataValueField="SectionCategoryId" OnSelectedIndexChanged="ddlSectionCategory_SelectedIndexChanged">
                    <asp:ListItem Value="0">-- Select Section Category --</asp:ListItem>
                </asp:DropDownList>
                
                <asp:LinqDataSource ID="lnqsecCategory" runat="server" ContextTypeName="CJDataClassesDataContext" Select="new (SectionCategoryId, SectionCategoryName)" TableName="SectionCategories" Where="Status == @Status">
                    <WhereParameters>
                        <asp:Parameter DefaultValue="1" Name="Status" Type="Int32" />
                    </WhereParameters>
                </asp:LinqDataSource>
                
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td width="110">
                Section List</td>
            <td>
                <asp:DropDownList ID="ddlSectionName" runat="server" 
                    AppendDataBoundItems="True" AutoPostBack="True" DataTextField="SectionName" 
                    DataValueField="SectionId Width="310px">
                    <asp:ListItem Value="0">-- Select --</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td >
                <asp:Label ID="SectionName" runat="server" Text="SectionName"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtSectionName" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td id="Td1">
                Status</td>
            <td>
                <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="True">
                    <asp:ListItem Value="1">Active</asp:ListItem>
                    <asp:ListItem Value="0">InActive</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
               <table>
                    <tr>
                        <td>
                            <asp:Button ID="btnAddSections" runat="server" onclick="btnAddSections_Click" 
                                Text="Submit" />
                        </td>
                        <td>
                            <asp:Button ID="btnResetSections" runat="server" 
                                onclick="btnResetSections_Click" Text="Reset" />
                        </td>
                        <td>
                            <asp:Button ID="btnDeleteSection" runat="server" 
                                onclick="btnDeleteSection_Click" Text="Delete" />
                        </td>
                        <td>
                            <asp:Button ID="btnAddSubUnderSections" runat="server" 
                                onclick="btnAddSubUnderSections_Click" Text="Add Sub Level 1" Visible="False" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>

        <tr>
            <td ID="Td3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Panel ID="pnlSublevel1" runat="server" Enabled="False">
                    <table>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="lblMessageSubSec1" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                1 st Level Sub variable List</td>
                            <td>
                                <asp:DropDownList ID="ddlFirstLevelVarList" runat="server" 
                                    AppendDataBoundItems="True" AutoPostBack="True" 
                                    Width="310px" OnSelectedIndexChanged="ddlFirstLevelVarList_SelectedIndexChanged">
                                    <asp:ListItem Value="0-">--select--</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                1 st Level Sub variable Name</td>
                            <td>
                                <asp:TextBox ID="txtParentName" runat="server" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Status</td>
                            <td>
                                <asp:DropDownList ID="ddlStatusSub1" runat="server" AutoPostBack="True">
                                    <asp:ListItem Value="1">Active</asp:ListItem>
                                    <asp:ListItem Value="0">InActive</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <table>
                                    <tr>
                                        <td colspan="2">
                                           <table>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnAddFirstLevelVar" runat="server" 
                                                onclick="btnAddFirstLevelVar_Click" Text="Submit" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnResetFirstLevelVar" runat="server" 
                                                onclick="btnResetFirstLevelVar_Click" Text="Reset" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnDeleteFirstLevelVar" runat="server" 
                                                onclick="btnDeleteFirstLevelVar_Click" Text="Delete" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnAddSubLevelUnderFirstLevel" runat="server" 
                                                onclick="btnAddSubLevelUnderFirstLevel_Click" Text="Add Sub Level 2" 
                                                Visible="False" />
                                        </td>
                                    </tr>
                                </table>
                                        </td>
                                       
                                       
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Panel ID="pnlsublevel2" runat="server" Enabled="False">
                    <table>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="lblMessageSubSec2" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                2 nd&nbsp; Level Sub variable List</td>
                            <td>
                                <asp:DropDownList ID="ddlSecondLevelVarList" runat="server" 
                                    AppendDataBoundItems="True" AutoPostBack="True"
                                    Width="310px" OnSelectedIndexChanged="ddlSecondLevelVarList_SelectedIndexChanged">
                                    <asp:ListItem Value="0">-- Select --</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                2 nd Level Sub variable Name</td>
                            <td>
                                <asp:TextBox ID="txtSectionName2" runat="server" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Status</td>
                            <td>
                                <asp:DropDownList ID="ddlStatusSub2" runat="server" AutoPostBack="True">
                                    <asp:ListItem Value="1">Active</asp:ListItem>
                                    <asp:ListItem Value="0">InActive</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                               <table>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnSubmitSecondLevelVar" runat="server" 
                                                onclick="btnSubmitSecondLevelVar_Click" Text="Submit" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnRestSecondLevelVar" runat="server" 
                                                onclick="btnRestSecondLevelVar_Click" Text="Reset" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnDeleteSecondLevelVar" runat="server" 
                                                onclick="btnDeleteSecondLevelVar_Click" Text="Delete" />
                                        </td>
                                    </tr>
                                </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

