<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/CJAdminMaster.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="AddTestSectionDetails.aspx.cs" Inherits="Admin_AddTestSectionDetails" %>
<%@ Register assembly="FreeTextBox" namespace="FreeTextBoxControls" tagprefix="FTB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
              <table align="center" >
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
                 <asp:GridView ID="grd_designation" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="TestSectionId"  EnableModelValidation="True" PageSize="20" DataSourceID="lnqSection" OnRowDataBound="grd_designation_RowDataBound">
                                <Columns>
                                    <asp:CommandField  ShowEditButton="True" />
                                    <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />
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
    <table align="center">
                                    <tr>
                        <td  style="font-weight: bold">
                            Add Result Bands Under each Test Sections</td>
                    </tr>

                    <tr>
                        <td  style="text-align: left">
                            <table>
                                <tr>
                                    <td>
                                        Section Name List</td>
                                    <td  style="text-align: left">
                                        <asp:DropDownList ID="ddlSectionNameList" runat="server"  DataTextField="SectionName" DataValueField="TestSectionId"
                                            AppendDataBoundItems="True" AutoPostBack="True"  Width="400px" DataSourceID="LinqTestSectionNameList">
                                            <asp:ListItem Value="0">-- Select a Section from the List --</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:LinqDataSource ID="LinqTestSectionNameList" runat="server" 
                                            ContextTypeName="CJDataClassesDataContext" 
                                            Select="new (TestSectionId, SectionName, AdminAccess)" 
                                            TableName="TestSectionsLists" OrderBy="SectionName" Where="Status == @Status">
                                            <WhereParameters>
                                                <asp:Parameter DefaultValue="1" Name="Status" Type="Int32" />
                                            </WhereParameters>
                                        </asp:LinqDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    
                                    <td >
                                        Display Name</td>
                                </tr>
                                <tr>
                                    <td>
                                        Marks From
                                        <asp:TextBox ID="txtSectionMarksFrom" runat="server" MaxLength="3" Width="75px"></asp:TextBox>
                                    </td>
                                    <td rowspan="3" >
                                        <FTB:FreeTextBox ID="txtSectionDisplayName" runat="Server" Height="100px" 
                                            Text="" 
                                            ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline,Strikethrough;Superscript,Subscript,RemoveFormat" 
                                            ToolbarStyleConfiguration="NotSet" UpdateToolbar="True" Width="525px">
                                        </FTB:FreeTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Marks To&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:TextBox ID="txtSectionMarksTo" runat="server" MaxLength="3" Width="75px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Bench Mark
                                        <asp:TextBox ID="txtSectionBenchMark" runat="server" MaxLength="3" Width="75px"></asp:TextBox>
                                    </td>
                                </tr>

                                <tr>
                                    
                                    <td >
                                        
                                                    <asp:Button ID="btnAddSectionBands" runat="server"  Text="Add" Width="55px" OnClick="btnAddSectionBands_Click" />
                                        <asp:Button ID="btn_update" runat="server" Text="Update Details" Visible="false" OnClick="btn_update_Click"  />
                                               
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td colspan="5">
                                        <asp:Label ID="lblMessageSectionBand" runat="server" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">

                                            <asp:GridView ID="gvwSectionBands" runat="server" ForeColor="#800000" AutoGenerateColumns="False"  EnableModelValidation="True" OnRowDataBound="gvwSectionBands_RowDataBound" AllowPaging="True" DataKeyNames="SectionBandId" DataSourceID="lnqresultband" OnSelectedIndexChanged="gvwSectionBands_SelectedIndexChanged"  >
                                                <Columns>
                                                    <asp:CommandField  ShowEditButton="True" SelectText="Edit" ItemStyle-ForeColor="#990000" />
                                                    
                                                    <asp:CommandField ShowDeleteButton="True" ButtonType="Button"  />
                                                    <asp:BoundField DataField="SectionBandId" HeaderText="SectionBandId" ReadOnly="True" SortExpression="SectionBandId" InsertVisible="False" />
                                                    <asp:BoundField DataField="TestId" HeaderText="TestId" ReadOnly="true"   SortExpression="TestId" />
                                                    <asp:BoundField DataField="SectionId" HeaderText="SectionId" ReadOnly="true"   SortExpression="SectionId" />
                                                    <asp:BoundField DataField="BenchMark" HeaderText="BenchMark"  SortExpression="BenchMark" />
                                                    <asp:BoundField DataField="MarkFrom" HeaderText="MarkFrom"  SortExpression="MarkFrom" />
                                                    <asp:BoundField DataField="MarkTo" HeaderText="MarkTo"  SortExpression="MarkTo" />
                                                    <asp:BoundField DataField="DisplayName" HeaderText="DisplayName"  SortExpression="DisplayName" />
                                                    <asp:BoundField DataField="Description" HeaderText="Description"  SortExpression="Description" />
                                                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                                                </Columns>
                                            </asp:GridView>
                                            <asp:LinqDataSource ID="lnqresultband" runat="server" ContextTypeName="CJDataClassesDataContext" EnableDelete="True" EnableUpdate="True" OrderBy="DisplayName" TableName="TestSectionResultBands" Where="SectionId == @SectionId">
                                                <WhereParameters>
                                                    <asp:ControlParameter ControlID="ddlSectionNameList" Name="SectionId" PropertyName="SelectedValue" Type="Int32" />
                                                </WhereParameters>
                                            </asp:LinqDataSource>
                                            <%--<asp:LinqDataSource ID="LinqSectionBandDetails" runat="server" 
                                                ContextTypeName="CJDataClassesDataContext" 
                                                Select="new (SectionBandId, TestId, SectionId, BenchMark, MarkFrom, MarkTo, DisplayName, Description, Status)" 
                                                TableName="TestSectionResultBands" Where="Status == @Status &amp;&amp; SectionId == @SectionId" EnableDelete="True" EnableUpdate="True">
                                                <WhereParameters>
                                                    <asp:Parameter DefaultValue="1" Name="Status" Type="Int32" />
                                                    <asp:ControlParameter ControlID="ddlSectionNameList" Name="SectionId" PropertyName="SelectedValue" Type="Int32" />
                                                </WhereParameters>
                                            </asp:LinqDataSource>--%>

                                    </td>
                                </tr>

                            </table>
                        </td>
                    </tr>
    </table>
      
    
</asp:Content>

