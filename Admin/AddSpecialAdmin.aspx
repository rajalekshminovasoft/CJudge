<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/CJAdminMaster.master" AutoEventWireup="true" CodeFile="AddSpecialAdmin.aspx.cs" Inherits="Admin_AddSpecialAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="75%" align="center">
            <tr>
                            <td colspan="2" 
                valign="top">
                                <div class="titlemain">
                                    Special Admin&nbsp; Creation</div>
                            </td>
                        </tr>
                        <tr>
                            <td class="label" >
                                User Name:</td>
                            <td>
                                <asp:TextBox ID="txtUserName" runat="server" Width="400px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="label" >
                                Password:</td>
                            <td>
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="400px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="label">
                                EmailId</td>
                            <td>
                                <asp:TextBox ID="txtEmailId" runat="server" Width="400px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="label">
                                Name Of Organisation:</td>
                            <td>
                                <asp:DropDownList ID="ddlOrg" runat="server" 
                    AppendDataBoundItems="True" Width="402px" 
                                    DataSourceID="OrgLinqDataSource" DataTextField="Name" 
                                    DataValueField="OrganizationID">
                                    <asp:ListItem Value="0">--select--</asp:ListItem>
                                </asp:DropDownList>
                                <asp:LinqDataSource ID="OrgLinqDataSource" runat="server" 
                                    ContextTypeName="CJDataClassesDataContext" 
                                    Select="new (Name, OrganizationID)" TableName="Organizations" 
                                    Where="Status == @Status">
                                    <WhereParameters>
                                        <asp:Parameter DefaultValue="1" Name="Status" Type="Int32" />
                                    </WhereParameters>
                                </asp:LinqDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td class="label">
                                Login From Date:</td>
                            <td>

                                <asp:TextBox ID="txtLoginFromDate" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="label" >
                                Login To Date:</td>
                            <td>

                                <asp:TextBox ID="txtLoginToDate" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="label" >
                                Status:</td>
                            <td>
                                <asp:DropDownList ID="ddlStatus" runat="server" Width="128px">
                                    <asp:ListItem Value="1">Active</asp:ListItem>
                                    <asp:ListItem Value="0">InActive</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lblMessage" runat="server" ForeColor="#FF3300"></asp:Label>
                            </td>
                        </tr>
        <tr>
                            <td >
                                &nbsp;</td>
                            <td>
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
                    onclick="btnSubmit_Click" />
                                <asp:Button ID="btnReset" runat="server" Text="Reset" 
                    onclick="btnReset_Click" />
                                <asp:Button ID="btnupdate" runat="server" Visible="false"  onclick="btnDelete_Click" 
                    Text="Update" />
                                <asp:Label ID="lblMessageDelete" runat="server" ></asp:Label>
                                                                    
                                                                     </td>
                        </tr>
        <tr >
            <td colspan="2">
                <asp:GridView ID="gvwSpecialAdminCreation" runat="server"  ForeColor="#800000"
                    AutoGenerateColumns="False" 
                    onselectedindexchanged="gvwSpecialAdminCreation_SelectedIndexChanged" BackColor="#E2E2E2" GridLines="None" 
                        Width="98%" AllowPaging="True" AllowSorting="True" 
                                        onpageindexchanging="gvwSpecialAdminCreation_PageIndexChanging" 
                                        PageSize="20">
                                        <Columns>
                                        
                                            <asp:BoundField DataField="UserName" HeaderText="User Name" ReadOnly="True" 
                            SortExpression="UserName" />
                                            <%--<asp:BoundField DataField="OrgName" HeaderText="Organization" 
                            ReadOnly="True" SortExpression="OrgName" />--%>
                                            <asp:BoundField DataField="LoginFromDate" DataFormatString="{0:dd-MM-yyyy}" 
                                HeaderText="Login From" ReadOnly="True" SortExpression="LoginFromDate" >
                                                <HeaderStyle Wrap="False" />
                                                <ItemStyle Wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="LoginToDate" DataFormatString="{0:dd-MM-yyyy}" 
                                HeaderText="Login To" ReadOnly="True" SortExpression="LoginToDate" >
                                                <HeaderStyle Wrap="False" />
                                                <ItemStyle Wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="UserId" ReadOnly="True" SortExpression="UserId">
                                                <ItemStyle Font-Size="1px" ForeColor="Silver" Width="1px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="OrganizationID" ReadOnly="True" 
                                SortExpression="OrganizationID">
                                                <ItemStyle Font-Size="1px" ForeColor="Silver" Width="1px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Status" SortExpression="Status">
                                                <ItemStyle Font-Size="1px" ForeColor="Silver" Width="1px" />
                                            </asp:BoundField>
                                            <asp:CommandField SelectText="Edit" ShowSelectButton="True">
                                                <ControlStyle Width="30px" />
                                            </asp:CommandField>
                                        </Columns>
                                    </asp:GridView>
                                    
                                    <asp:LinqDataSource ID="UserLinqDataSource" runat="server" 
                                        ContextTypeName="CJDataClassesDataContext" 
                                        TableName="UserProfiles" EnableUpdate="True" Where="UserType == @UserType" >
                                        <WhereParameters>
                                            <asp:Parameter DefaultValue="SpecialAdmin" Name="UserType" Type="String" />
                                        </WhereParameters>
                                    </asp:LinqDataSource>
            </td>
        </tr>
    </table>
</asp:Content>

