<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/CJAdminMaster.master" AutoEventWireup="true" CodeFile="AddTestSectionDetails.aspx.cs" Inherits="Admin_AddTestSectionDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center">
        <tr>
            <td>
                <h3>Add Section Details</h3>
            </td>
        </tr>
          <tr>
                        <td>
                            <asp:Label ID="lblOrganization" runat="server" Text="Organization"></asp:Label>
                        </td>
                        <td  >
                            <asp:DropDownList ID="drp_Organization" runat="server" 
                                AppendDataBoundItems="True" AutoPostBack="True"  DataTextField="Name" 
                                DataValueField="OrganizationID" Width="402px" DataSourceID="lnqOrg">
                                <asp:ListItem Value="0">-- Select --</asp:ListItem>
                            </asp:DropDownList>
                           
                            <asp:LinqDataSource ID="lnqOrg" runat="server" ContextTypeName="CJDataClassesDataContext" OrderBy="Name" Select="new (OrganizationID, Name)" TableName="Organizations">
                            </asp:LinqDataSource>
                           
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Test Name</td>
                        <td >
                            <asp:DropDownList ID="drp_TestName" runat="server" AppendDataBoundItems="True" 
                                AutoPostBack="True"  Width="402px" DataSourceID="lnqTest" DataTextField="TestName" DataValueField="TestId">
                                <asp:ListItem Value="0">-- Select --</asp:ListItem>
                            </asp:DropDownList>
                            <asp:LinqDataSource ID="lnqTest" runat="server" ContextTypeName="CJDataClassesDataContext" OrderBy="TestName" Select="new (TestId, TestName)" TableName="TestLists" Where="OrganizationName == @OrganizationName">
                                <WhereParameters>
                                    <asp:ControlParameter ControlID="drp_Organization" Name="OrganizationName" PropertyName="SelectedValue" Type="Int32" />
                                </WhereParameters>
                            </asp:LinqDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Section Name</td>
                        <td  >
                            <asp:TextBox ID="txtSectionName" runat="server" Width="400px"></asp:TextBox>
                        </td>
                    </tr>
     <tr>
            <td>
                &nbsp;</td>
            <td >
                <asp:Label ID="lblMessage" runat="server" ForeColor="#CC3300"></asp:Label>
            </td>
        </tr>
         <tr>
                        <td>
                <asp:Button ID="btnAdd" runat="server"  Text="Add Test Details" OnClick="btnAdd_Click" />
                        </td>
             </tr> 
        <tr>
            <td colspan="2" >
                 <asp:GridView ID="grd_designation" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="TestSectionId"  EnableModelValidation="True" PageSize="50" DataSourceID="lnqSection">
                                <Columns>
                                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                                    <asp:BoundField DataField="TestSectionId" HeaderText="TestSectionId" InsertVisible="False" ReadOnly="True" SortExpression="TestSectionId" />
                                    <asp:BoundField DataField="TestId" HeaderText="TestId" SortExpression="TestId" />
                                    <asp:BoundField DataField="SectionName" HeaderText="SectionName" SortExpression="SectionName" />
                                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                                </Columns>
                                <EditRowStyle ForeColor="Maroon" />
                                <RowStyle ForeColor="#800000" />
                            </asp:GridView>
               
                 <asp:LinqDataSource ID="lnqSection" runat="server" ContextTypeName="CJDataClassesDataContext" EnableDelete="True" EnableUpdate="True" OrderBy="TestId" TableName="TestSectionsLists">
                 </asp:LinqDataSource>
               
            </td>
        </tr>
    </table>
</asp:Content>

