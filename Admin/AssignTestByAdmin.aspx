<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/CJAdminMaster.master" AutoEventWireup="true" CodeFile="AssignTestByAdmin.aspx.cs" Inherits="Admin_AssignTestByAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="75%" align="center">
        <tr>
            <td>Select Organization</td>
            <td>
                 <asp:DropDownList ID="drp_org" runat="server" 
                    AppendDataBoundItems="True" AutoPostBack="True"  DataTextField="Name" DataValueField = "OrganizationID" Width="250px" OnSelectedIndexChanged="drp_org_SelectedIndexChanged" DataSourceID="LnqOrg"  >
                                    <asp:ListItem Value="0">--select--</asp:ListItem>
                                </asp:DropDownList>

                                <asp:LinqDataSource ID="LnqOrg" runat="server" ContextTypeName="CJDataClassesDataContext" OrderBy="Name" Select="new (OrganizationID, Name)" TableName="Organizations" Where="Status == @Status">
                                    <WhereParameters>
                                        <asp:Parameter DefaultValue="1" Name="Status" Type="Int32" />
                                    </WhereParameters>
                                </asp:LinqDataSource>
            </td>
        </tr>
        <tr>
            <td>Select Group</td>
            <td>
                <asp:DropDownList ID="drp_groupuser" runat="server" AppendDataBoundItems="True" 
                                    Width="250px" AutoPostBack="True" OnSelectedIndexChanged="drp_groupuser_SelectedIndexChanged"   >
                                    <asp:ListItem Value="0">--select--</asp:ListItem>
                                </asp:DropDownList>
                                
                                <asp:LinqDataSource ID="LnqGrpUser" runat="server" ContextTypeName="CJDataClassesDataContext" OrderBy="GroupName" Select="new (GroupUserID, GroupName)" TableName="GroupUsers" Where="OrganizationID == @OrganizationID">
                                    <WhereParameters>
                                        <asp:ControlParameter ControlID="drp_org" Name="OrganizationID" PropertyName="SelectedValue" Type="Int32" />
                                    </WhereParameters>
                                </asp:LinqDataSource>
                                
            </td>
        </tr>
        <tr>
            <td>Select User</td>
            <td>
                <asp:DropDownList ID="drp_users" runat="server" Width="250px" >
                    <asp:ListItem Value="0">--select--</asp:ListItem>
                </asp:DropDownList>
                <asp:LinqDataSource ID="lnqUser" runat="server" ContextTypeName="CJDataClassesDataContext" OrderBy="UserName" Select="new (UserId, UserName)" TableName="UserProfiles" Where="OrganizationID == @OrganizationID &amp;&amp; GrpUserID == @GrpUserID">
                    <WhereParameters>
                        <asp:ControlParameter ControlID="drp_org" Name="OrganizationID" PropertyName="SelectedValue" Type="Int32" />
                        <asp:ControlParameter ControlID="drp_groupuser" Name="GrpUserID" PropertyName="SelectedValue" Type="Int32" />
                    </WhereParameters>
                </asp:LinqDataSource>
            </td>
        </tr>
        <tr>
            <td>Select Test</td>
            <td>
                                                 <asp:DataList ID="dtTestlist" runat="server" RepeatColumns="2" DataSourceID="lnqTestlist" OnSelectedIndexChanged="dtTestlist_SelectedIndexChanged"   >
                                <ItemTemplate>
                                        
                                                        <div class="testlist1">
        	<div class="testlist1_head">
                <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="#660033" Font-Bold="True" Font-Names="Calibri" ><%# Eval("TestName") %></asp:LinkButton>

        	</div>
            <div class="testlist2">
                <asp:CheckBox ID="chktest" runat="server"  Text='<%# Eval("TestName") %>' />
                 <asp:Label ID="lbltest" runat="server" visible="false" Text='<%# Eval("TestId") %>'></asp:Label>
            </div>
             <div class="testlist2">         
                  Price:<asp:Label ID="Price" runat="server" Text='<%# Eval("Price") %>' />
                                                            <asp:Label ID="lbltestid" runat="server" Visible="false"  Text='<%# Eval("TestId") %>' /></div>
                                                            </div>
                             </ItemTemplate>
                                </asp:DataList>
                                 <asp:LinqDataSource ID="lnqTestlist" runat="server" ContextTypeName="CJDataClassesDataContext" OrderBy="TestId desc" Select="new (TestId, TestName, Price, Remark)" TableName="TestLists" Where="Status == @Status &amp;&amp; OrganizationName == @OrganizationName">
                                     <WhereParameters>
                                         <asp:Parameter DefaultValue="1" Name="Status" Type="Int32" />
                                         <asp:Parameter DefaultValue="1" Name="OrganizationName" Type="Int32" />
                                     </WhereParameters>
                                 </asp:LinqDataSource>
                            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Payment Date
            </td>
            <td>
                <asp:TextBox ID="txt_paydate" runat="server"></asp:TextBox>(mm/dd/yyyy hh:mm:ss AM)
            </td>
        </tr>
        <tr>
            <td>
                Payment Status
            </td>
            <td>
               <asp:dropdownlist id="drp_paidstatus" runat="server">
                     <asp:ListItem Text="PAID" Value="PAID">PAID</asp:ListItem>
                    <asp:ListItem Text="NOTPAID" Value="NOTPAID">NOTPAID</asp:ListItem>
                </asp:dropdownlist>
            </td>
        </tr>
        <tr>
            <td>Report Access</td>
            <td>
                <asp:CheckBox ID="chk_repaccess" runat="server" />
            </td>
        </tr>
        <tr>
            <td>Test Login Date</td>
            <td>                <asp:TextBox ID="txt_Logindate" runat="server"></asp:TextBox>(mm/dd/yyyy hh:mm:ss AM)
</td>
        </tr>
                <tr>
            <td>Test Logout Date</td>
            <td>                <asp:TextBox ID="txt_Logoutdate" runat="server"></asp:TextBox>(mm/dd/yyyy hh:mm:ss AM)
</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btn_save" runat="server" Text="Submit" OnClick="btn_save_Click" />
                <asp:Label ID="lbl_msg" runat="server" ></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

