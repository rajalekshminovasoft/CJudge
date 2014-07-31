<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/CJAdminMaster.master" AutoEventWireup="true" CodeFile="ViewUserTestDetails.aspx.cs" Inherits="Admin_ViewUserTestDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="75%" align="center">
        <tr>
            <td>
                <asp:gridview id="grd_usertest" runat="server" AllowPaging="True" AutoGenerateColumns="False"  EnableModelValidation="True" width="80%" align="center">
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
                            <ItemTemplate><a href="#">
                            <asp:Button id="btnReport" Text="Report"  runat="server"  ></asp:Button></a>
                            <a href="#">  <asp:Button id="btntest" Text="TakeTest"  runat="server" ></asp:Button></a>
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

