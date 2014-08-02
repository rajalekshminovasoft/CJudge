<%@ Page Title="" Language="C#" ValidateRequest="false"  MasterPageFile="~/Admin/CJAdminMaster.master" AutoEventWireup="true" CodeFile="ViewUserTestDetails.aspx.cs" Inherits="Admin_ViewUserTestDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="75%" align="center">
        <tr>
            <td>
                <asp:gridview id="grd_usertest" runat="server" AllowPaging="True" AutoGenerateColumns="False"  EnableModelValidation="True" width="85%" align="center">
                    <Columns>

                        <asp:BoundField DataField="UserId" HeaderText="UserId" SortExpression="UserId" />
                        <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                        <asp:BoundField DataField="TestName" HeaderText="TestName" SortExpression="TestName" />
                        <asp:BoundField DataField="TestLoginDate" HeaderText="TestLoginDate" SortExpression="TestLoginDate" DataFormatString="{0:g}"  />
                        <asp:BoundField DataField="TestLogoutDate" HeaderText="TestLogoutDate" SortExpression="TestLogoutDate" />
                        <asp:BoundField DataField="TestStatus" HeaderText="TestStatus" SortExpression="TestStatus" />
                        <asp:BoundField DataField="PhoneNum" HeaderText="PhoneNum" SortExpression="PhoneNum" />
                        <asp:BoundField DataField="EmailId" HeaderText="EmailId" SortExpression="EmailId" />
                        
                        <asp:TemplateField>
                            <ItemTemplate><a target="_blank"  href="TestIntroduction.aspx?Id=<%#Eval("UserTestId") %>" >
                            <asp:Label id="btnReport" Text="Report" ForeColor="#800000"  runat="server"  ></asp:Label></a>
                            <a target="_blank"  href="TestIntroduction.aspx?Id=<%#Eval("UserTestId") %>">  
                                <asp:Label id="btntest"  Text="TakeTest" ForeColor="#800000"  runat="server" ></asp:Label></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                    </Columns>
                </asp:gridview>
                <asp:LinqDataSource ID="lnq_usertestlist" runat="server" ContextTypeName="CJDataClassesDataContext" OrderBy="EmailId, TestName" TableName="View_UserTestDetails">
                </asp:LinqDataSource>
            </td>
        </tr>
    </table>
</asp:Content>

