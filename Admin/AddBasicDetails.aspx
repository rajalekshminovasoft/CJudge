<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/CJAdminMaster.master" AutoEventWireup="true" CodeFile="AddBasicDetails.aspx.cs" Inherits="Admin_AddBasicDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <table align="center">
       <tr>
           <td>
                <table align="center">
        <tr>
            <td>
                <h3>Add designation</h3>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txt_designame" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="drp_dsgstatus" runat="server">
                    <asp:ListItem Text="Active" Value="1">Active</asp:ListItem>
                    <asp:ListItem Text="Inactive" Value="0">InActive</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btn_AddDesig" runat="server" Text="Add Designation" OnClick="btn_AddDesig_Click" />
            </td>
        </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_desig" runat="server" ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="grd_designation" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="PostId" DataSourceID="lnqdesgn" EnableModelValidation="True" PageSize="50">
                                <Columns>
                                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                                    <asp:BoundField DataField="PostId" HeaderText="PostId" InsertVisible="False" ReadOnly="True" SortExpression="PostId" />
                                    <asp:BoundField DataField="PostName" HeaderText="PostName" SortExpression="PostName" />
                                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                                </Columns>
                                <EditRowStyle ForeColor="Maroon" />
                                <RowStyle ForeColor="#800000" />
                            </asp:GridView>
                            <asp:LinqDataSource ID="lnqdesgn" runat="server" ContextTypeName="CJDataClassesDataContext" EnableDelete="True" EnableUpdate="True" TableName="Designations">
                            </asp:LinqDataSource>
                        </td>
                    </tr>
    </table>
           </td>
           <td>
               <table align="center">
        <tr>
            <td>
                <h3>Add Industry</h3>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txt_industryname" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="drp_Indstatus" runat="server">
                    <asp:ListItem Text="Active" Value="1">Active</asp:ListItem>
                    <asp:ListItem Text="Inactive" Value="0">InActive</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btn_AddIndustry" runat="server" Text="Add Industry" OnClick="btn_AddIndustry_Click" />
            </td>
        </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_addindustry" runat="server" ></asp:Label>
                        </td>
                    </tr>
                   <tr>
                       <td>
                           <asp:GridView ID="grd_Industry" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="IndustryID"  EnableModelValidation="True" DataSourceID="lnqIndustry" PageSize="50">
                                <Columns>
                                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                                    <asp:BoundField DataField="IndustryID" HeaderText="IndustryID" InsertVisible="False" ReadOnly="True" SortExpression="IndustryID" />
                                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                                </Columns>
                                <EditRowStyle ForeColor="Maroon" />
                                <RowStyle ForeColor="#800000" />
                            </asp:GridView>
                           <asp:LinqDataSource ID="lnqIndustry" runat="server" ContextTypeName="CJDataClassesDataContext" EnableDelete="True" EnableUpdate="True" TableName="Industries">
                           </asp:LinqDataSource>
                       </td>
                   </tr>
               </table>
                </td>
       </tr>
                   <tr>
                       <td>
                           <table align="center">
        <tr>
            <td>
                <h3>Add Occupation</h3>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txt_OccName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="drp_occstatus" runat="server">
                    <asp:ListItem Text="Active" Value="1">Active</asp:ListItem>
                    <asp:ListItem Text="Inactive" Value="0">InActive</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btn_AddOccupation" runat="server" Text="Add Occupation" OnClick="btn_AddOccupation_Click" />
            </td>
        </tr>
                                <tr>
                        <td>
                            <asp:Label ID="lbl_addoccpn" runat="server" ></asp:Label>
                        </td>
                    </tr>
                               <tr>
                                   <td>
                                       <asp:GridView ID="grd_Occupation" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="JobCatID"  EnableModelValidation="True" DataSourceID="lnqOccupation" PageSize="50" >
                                <Columns>
                                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                                    <asp:BoundField DataField="JobCatID" HeaderText="JobCatID" InsertVisible="False" ReadOnly="True" SortExpression="JobCatID" />
                                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                                </Columns>
                                <EditRowStyle ForeColor="Maroon" />
                                <RowStyle ForeColor="#800000" />
                            </asp:GridView>
                                       <asp:LinqDataSource ID="lnqOccupation" runat="server" ContextTypeName="CJDataClassesDataContext" EnableDelete="True" EnableUpdate="True" TableName="JobCategories">
                                       </asp:LinqDataSource>
                                   </td>
                               </tr>
    </table>
                       </td>
                      <td>
                          <table align="center">
        <tr>
            <td>
                <h3>Add Qualification</h3>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txt_qualName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="drp_qualstatus" runat="server">
                    <asp:ListItem Text="Active" Value="1">Active</asp:ListItem>
                    <asp:ListItem Text="Inactive" Value="0">InActive</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btn_AddQualfn" runat="server" Text="Add Qualification" OnClick="btn_AddQualfn_Click" />
            </td>
        </tr>
                               <tr>
                        <td>
                            <asp:Label ID="lbl_addqualfn" runat="server" ></asp:Label>
                        </td>
                    </tr>
<tr>
    <td>
        <asp:GridView ID="grd_qualifns" runat="server" AllowPaging="True" AutoGenerateColumns="False"  EnableModelValidation="True" DataSourceID="lnqQualfn" PageSize="50" >
                                <Columns>
                                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                                    <asp:BoundField DataField="QualificationId" HeaderText="QualificationId" InsertVisible="False" SortExpression="QualificationId" />
                                    <asp:BoundField DataField="Qualification1" HeaderText="Qualification" SortExpression="Qualification1" />
                                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                                </Columns>
                                <EditRowStyle ForeColor="Maroon" />
                                <RowStyle ForeColor="#800000" />
                            </asp:GridView>
        <asp:LinqDataSource ID="lnqQualfn" runat="server" ContextTypeName="CJDataClassesDataContext" EnableDelete="True" EnableUpdate="True" TableName="Qualifications">
        </asp:LinqDataSource>
    </td>
</tr>
    </table>
                      </td>
                   </tr>
    
          
   </table>
     
</asp:Content>

