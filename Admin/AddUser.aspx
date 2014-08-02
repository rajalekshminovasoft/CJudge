<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/CJAdminMaster.master" AutoEventWireup="true" CodeFile="AddUser.aspx.cs" Inherits="Admin_AddUser" %>

 <asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
     <script src="../scripts/jquery.datepick.js"></script>
    <link href="../styles/jquery.datepick.css" rel="stylesheet" />
    <link href="../styles/style1.css" rel="stylesheet" />
    <script src="http://ajax.microsoft.com/ajax/jquery/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('#ctl00_ContentPlaceHolder1_txtLoginFromDate').datepick({ dateFormat: 'mm/dd/yyyy' });
            $('#ctl00_ContentPlaceHolder1_txtLoginToDate').datepick({ dateFormat: 'mm/dd/yyyy' });

        });
          </script>
 </asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%--<script src="../scripts/jquery.datepick.js"></script>
    <link href="../styles/jquery.datepick.css" rel="stylesheet" />
    <link href="../styles/style1.css" rel="stylesheet" />

    
    <script src="http://ajax.microsoft.com/ajax/jquery/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('#ctl00_ContentPlaceHolder1_txtLoginFromDate').datepick({ dateFormat: 'mm/dd/yyyy' });
            $('#ctl00_ContentPlaceHolder1_txtLoginToDate').datepick({ dateFormat: 'mm/dd/yyyy' });

        });
          </script>--%>

    <table  align="center">
           
            <tr>
                <td >
                   <h3>User Creation</h3>
                            </td>
                        </tr>
             
            <tr><td><h4>Organizational Details</h4></td></tr>
                      
                        <tr>
                            <td class="label1">
                                Name Of Organisation:</td>
                            <td>
                                <asp:DropDownList ID="drp_org" runat="server" 
                    AppendDataBoundItems="True" AutoPostBack="True"  Width="250px" DataSourceID="LnqOrg" DataTextField="Name" DataValueField="OrganizationID" >
                                    <asp:ListItem Value="0">--select--</asp:ListItem>
                                </asp:DropDownList>

                                <asp:LinqDataSource ID="LnqOrg" runat="server" ContextTypeName="CJDataClassesDataContext" OrderBy="Name" Select="new (OrganizationID, Name)" TableName="Organizations" Where="Status == @Status">
                                    <WhereParameters>
                                        <asp:Parameter DefaultValue="1" Name="Status" Type="Int32" />
                                    </WhereParameters>
                                </asp:LinqDataSource>

                            </td>
                             <td class="label1" >
                                Group Name:</td>
                            <td>
                                <asp:DropDownList ID="drp_groupuser" runat="server" AppendDataBoundItems="True" 
                                    Width="250px" AutoPostBack="True" DataSourceID="LnqGrpUser" DataTextField="GroupName" DataValueField="GroupUserID" >
                                    <asp:ListItem Value="0">--select--</asp:ListItem>
                                </asp:DropDownList>
                                
                                <asp:LinqDataSource ID="LnqGrpUser" runat="server" ContextTypeName="CJDataClassesDataContext" OrderBy="GroupName" Select="new (GroupUserID, GroupName)" TableName="GroupUsers" Where="OrganizationID == @OrganizationID">
                                    <WhereParameters>
                                        <asp:ControlParameter ControlID="drp_org" Name="OrganizationID" PropertyName="SelectedValue" Type="Int32" />
                                    </WhereParameters>
                                </asp:LinqDataSource>
                                
                            </td>
                        </tr>                      
            <tr><td><h3>Personal Details</h3></td></tr>
                        <tr>
            <td class="label1">
                First Name:</td>
            <td>
                <asp:TextBox ID="txtFsName" runat="server" MaxLength="100" Width="250px"></asp:TextBox>
                <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
            </td>
       
            <td class="label1">
                Middle Name:</td>
            <td>
                <asp:TextBox ID="txtMidName" runat="server" MaxLength="100" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="label1">
                Last Name:</td>
            <td>
                <asp:TextBox ID="txtLstName" runat="server" MaxLength="100" Width="250px"></asp:TextBox>
                <asp:Label ID="Label5" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
            </td>
                   <td class="label1">
                Gender:</td>
            <td>
                <asp:DropDownList ID="ddlGender" runat="server" Width="80px">
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="label1">
                Age:</td>
            <td>
                <asp:TextBox ID="txtAge" runat="server" Text="0"  
                                        onChange="myJSFunction(this);" 
                    inblur="myJSFunction(this);" MaxLength="3" Width="250px"></asp:TextBox>
                <asp:Label ID="Label6" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
            </td>
             <td class="label1" >
                                User Type :</td>
                            <td>
                                <asp:DropDownList ID="ddlUserType" runat="server" Width="128px">
                                   <asp:ListItem Value="0">--select--</asp:ListItem>
                                    <asp:ListItem Value="SuperAdmin">Super Admin</asp:ListItem>
                                    <asp:ListItem Value="SpecialAdmin">Special Admin</asp:ListItem>
                                    <asp:ListItem value="OrgAdmin">OrgAdmin</asp:ListItem>
                                    <asp:ListItem value="GrpAdmin">GrpAdmin</asp:ListItem>
                                    <asp:ListItem value="User">User</asp:ListItem>
                                </asp:DropDownList>
                            </td>
        </tr>
        <tr>
            <td class="label1">
                Email:</td>
            <td>
                <asp:TextBox ID="txtEmailId" runat="server" MaxLength="100" Width="250px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="txtEmailId" ErrorMessage="Invalid email" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
          <td class="label1">
                Contact Number:</td>
            <td>
                <asp:TextBox ID="txtPhoneNumber" runat="server" MaxLength="20" Width="250px"></asp:TextBox>
            </td>
        </tr>

                        
                        

         
 <%--           <tr><td><h4>Working Details</h4></td></tr>
        <tr>
            <td class="label1">
                Industry:</td>
            <td>
                <asp:DropDownList ID="ddlIndustry" runat="server" AppendDataBoundItems="True" 
                    AutoPostBack="True"                   Width="250px">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                </asp:DropDownList>
               
                <br /><asp:TextBox ID="txtIndustry" runat="server" Visible="False" Width="250px" 
                    MaxLength="200"></asp:TextBox>
            </td>

            <td class="label1">
                Vocation:</td>
            <td>
                <asp:DropDownList ID="drp_jobcategory" runat="server" AppendDataBoundItems="True" 
                     DataTextField="Name" DataValueField="JobCatID"
                     Width="250px">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                </asp:DropDownList>
               
                <asp:Label ID="Label2" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="label1">
                Designation:</td>
            <td>
                <asp:TextBox ID="txtJob" runat="server" MaxLength="100" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="label1">
                Total Years of Experience:</td>
            <td>
                <table>
                    <tr>
                        <td>
                            <asp:DropDownList ID="drp_totlexpyears" runat="server">
                                <asp:ListItem>0</asp:ListItem>
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                                <asp:ListItem>7</asp:ListItem>
                                <asp:ListItem>8</asp:ListItem>
                                <asp:ListItem>9</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>11</asp:ListItem>
                                <asp:ListItem>12</asp:ListItem>
                                <asp:ListItem>13</asp:ListItem>
                                <asp:ListItem>14</asp:ListItem>
                                <asp:ListItem>15</asp:ListItem>
                                <asp:ListItem>16</asp:ListItem>
                                <asp:ListItem>17</asp:ListItem>
                                <asp:ListItem>18</asp:ListItem>
                                <asp:ListItem>19</asp:ListItem>
                                <asp:ListItem>20</asp:ListItem>
                                <asp:ListItem>21</asp:ListItem>
                                <asp:ListItem>22</asp:ListItem>
                                <asp:ListItem>23</asp:ListItem>
                                <asp:ListItem>24</asp:ListItem>
                                <asp:ListItem>25</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            Years</td>
                                        <td>
                                            <asp:DropDownList ID="drp_TotExpMonths" runat="server">
                                                <asp:ListItem>0</asp:ListItem>
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                                <asp:ListItem>7</asp:ListItem>
                                <asp:ListItem>8</asp:ListItem>
                                <asp:ListItem>9</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>11</asp:ListItem>
                                                
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            Months</td>
                    </tr>
                </table>
            </td>
       
            <td class="label1">
                Experience in Present Job:</td>
            <td>
                <table>
                    <tr>
                        <td>
                            <asp:DropDownList ID="drp_CurExpYears" runat="server">
                                <asp:ListItem>0</asp:ListItem>
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                                <asp:ListItem>7</asp:ListItem>
                                <asp:ListItem>8</asp:ListItem>
                                <asp:ListItem>9</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>11</asp:ListItem>
                                <asp:ListItem>12</asp:ListItem>
                                <asp:ListItem>13</asp:ListItem>
                                <asp:ListItem>14</asp:ListItem>
                                <asp:ListItem>15</asp:ListItem>
                                <asp:ListItem>16</asp:ListItem>
                                <asp:ListItem>17</asp:ListItem>
                                <asp:ListItem>18</asp:ListItem>
                                <asp:ListItem>19</asp:ListItem>
                                <asp:ListItem>20</asp:ListItem>
                                <asp:ListItem>21</asp:ListItem>
                                <asp:ListItem>22</asp:ListItem>
                                <asp:ListItem>23</asp:ListItem>
                                <asp:ListItem>24</asp:ListItem>
                                <asp:ListItem>25</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            Years</td>
                        <td>
                                            <asp:DropDownList ID="drp_CurExpMonths" runat="server">
                                                <asp:ListItem>0</asp:ListItem>
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                                <asp:ListItem>7</asp:ListItem>
                                <asp:ListItem>8</asp:ListItem>
                                <asp:ListItem>9</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>11</asp:ListItem>
                                                
                                            </asp:DropDownList>
                                        </td>
                        <td>
                            Months</td>
                    </tr>
                </table>
            </td>
        </tr>
            <tr><td><h4>Educational Details</h4></td></tr>
        <tr>
            <td class="label1">
                Educational Qualification:</td>
            <td>
                <asp:DropDownList ID="drp_Qualification" runat="server" 
                    AppendDataBoundItems="True" AutoPostBack="True" 
                                    Width="250px">
                    <asp:ListItem Value="0">-- Select --</asp:ListItem>
                </asp:DropDownList>
                
                <asp:Label ID="Label4" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
                <br />
                <asp:TextBox ID="txtEduQual" runat="server" Visible="False" Width="350px" 
                    MaxLength="50"></asp:TextBox>
                
            </td>
        
            <td class="label1">
                Professional Qualification :</td>
            <td>
                <asp:TextBox ID="txtEduQual_professional" runat="server" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="label1">
                Professional Certification:</td>
            <td>
                <asp:TextBox ID="txtProffQual" runat="server" TextMode="MultiLine" 
                    Height="100px" Width="250px"></asp:TextBox>
            </td>
        </tr>--%>
                        <tr>
                            <td class="label">
                                Login From Date:</td>
                            <td>
                               <asp:TextBox ID="txtLoginFromDate" runat="server" ></asp:TextBox>(mm/dd/yyyy hh:mm:ss AM)
                               </td>
                      
                            <td class="label" >
                                Login To Date:</td>
                            <td>
                                <asp:TextBox ID="txtLoginToDate" runat="server"  ></asp:TextBox>(mm/dd/yyyy hh:mm:ss AM)
                                </td>
                        </tr>
                        
           <%--  <tr><td><h4>User Details</h4></td></tr>
             <tr>
                            <td class="label1" >
                                User Name:</td>
                            <td>
                                <asp:TextBox ID="txtUserName" runat="server" Width="250px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
                            </td>
                        
                            <td class="label1" >
                                Password:</td>
                            <td>
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="250px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                            </td>
                        </tr>--%>
            <tr><td>Are you recruited by someone?</td>
                <td>
                    <asp:DropDownList ID="drp_recruiter" runat="server"  AutoPostBack="True" OnSelectedIndexChanged="drp_recruiter_SelectedIndexChanged">
                        <asp:ListItem >Select</asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:DropDownList>
                 
                    <asp:TextBox ID="txtrecrutr" runat="server" Enabled="false"   Width="163px" ></asp:TextBox>

                </td>
                
                            <td class="label1" >
                                Status:</td>
                            <td>
                                <asp:DropDownList ID="drp_Status" runat="server" Width="128px">
                                    <asp:ListItem Value="1">Active</asp:ListItem>
                                    <asp:ListItem Value="0">InActive</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>


                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lblMessage" runat="server" ForeColor="#FF3300" ></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td >
                                &nbsp;</td>
                            <td>
                                <asp:Button ID="btnSave" runat="server" Text="Submit" OnClick="btnSave_Click" style="height: 26px"  />
                                
                            </td>
                        </tr>
        <tr>
            <td>
                <h4>Bulk Upload</h4>
            </td>
        </tr>
        <tr>
            <td>
                Select File(.xls 97/2007format)
            </td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
            <td>
                <asp:Button ID="btn_uploadusers" runat="server" Text="Upload" />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:GridView ID="grd_User" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="UserId" EnableModelValidation="True" PageSize="50" DataSourceID="LnqUserlist"  >
                                <Columns>
                                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                                    <asp:BoundField DataField="UserId" HeaderText="UserId" InsertVisible="False" ReadOnly="True" SortExpression="UserId" />
                                    <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                                    <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
                                    <asp:BoundField DataField="UserType" HeaderText="UserType" SortExpression="UserType" />
                                    <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                                    <asp:BoundField DataField="EmailId" HeaderText="EmailId" SortExpression="EmailId" />
                                    <asp:BoundField DataField="LoginFromDate" HeaderText="LoginFromDate" SortExpression="LoginFromDate" />
                                    <asp:BoundField DataField="LoginToDate" HeaderText="LoginToDate" SortExpression="LoginToDate" />
                                    <asp:BoundField DataField="Recruiter" HeaderText="Recruiter" SortExpression="Recruiter" />
                                </Columns>
                                <EditRowStyle ForeColor="Maroon" />
                                <RowStyle ForeColor="#800000" />
                            </asp:GridView>
                <asp:LinqDataSource ID="LnqUserlist" runat="server" ContextTypeName="CJDataClassesDataContext" EnableDelete="True" EnableUpdate="True" OrderBy="UserId desc"  TableName="UserProfiles">
                </asp:LinqDataSource>
            </td>
        </tr>
                        
                    </table>
</asp:Content>

