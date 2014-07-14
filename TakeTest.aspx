﻿<%@ Page Title="" Language="C#" MasterPageFile="~/CJMaster.master" AutoEventWireup="true" CodeFile="TakeTest.aspx.cs" Inherits="TakeTest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div  align="center" style="padding-top: 5px; ">
 
<div class="tab_box"> 
    
    	<div class="tab_box_but">
            <asp:LinkButton ID="btnstp1" runat="server" >Select Test</asp:LinkButton></div>
        <div class="tab_box_but">
            <asp:LinkButton ID="btnstp2" runat="server" >Sign In</asp:LinkButton>
        </div>
        <div class="tab_box_but">
              <asp:LinkButton ID="btnstp3" runat="server" >Payment</asp:LinkButton>
        </div>
    </div>



<div>
    <asp:Label ID="lblmsg" runat="server" ForeColor="#CC0000" ></asp:Label>
</div>
                <asp:Wizard ID="Wizard1" runat="server" ActiveStepIndex="0"  NavigationStyle-VerticalAlign="Top" NavigationStyle-HorizontalAlign="NotSet" HeaderStyle-VerticalAlign="Top"  DisplaySideBar="true" >
                    <HeaderStyle VerticalAlign="Top" />
            <NavigationButtonStyle ForeColor="#660033" />
                    <NavigationStyle VerticalAlign="Top" />
            <SideBarButtonStyle ForeColor="#660033" />
            
            <WizardSteps>
                <asp:WizardStep ID="Stp1" runat="server" Title="Select Test" >
                    <table>
                        <tr>
                            <td>
                              
                                 <asp:DataList ID="dtTestlist" runat="server" RepeatColumns="3" DataSourceID="lnqTestlist"  >
                                     <ItemTemplate>
                                        
                                                        <div class="testlist1">
        	<div class="testlist1_head"><asp:LinkButton ID="LinkButton1" runat="server" ForeColor="#660033" Font-Bold="True"><%# Eval("TestName") %></asp:LinkButton></div>
            <div class="testlist2"><asp:CheckBox ID="chktest" runat="server"  Text='<%# Eval("TestName") %>' />
</div>
             <div class="testlist2">         
                  Price:<asp:Label ID="Price" runat="server" Text='<%# Eval("Price") %>' />
                                                            <asp:Label ID="lbltestid" runat="server" Visible="false"  Text='<%# Eval("TestId") %>' /></div>
                                                            <div class="testlist2">          <asp:Label ID="Remark" runat="server" Text='<%# Eval("Remark") %>' /></div> 
        </div>
                                                                                                                          </ItemTemplate>
                                 <%--   <ItemTemplate>
                                        
                                                        TestId:
                                                        <asp:Label ID="TestIdLabel" runat="server" Text='<%# Eval("TestId") %>' />
                                                        <br />
                                                        TestName:
                                                        <asp:Label ID="TestNameLabel" runat="server" Text='<%# Eval("TestName") %>' />
                                                        <br />
                                                        Price:
                                                        <asp:Label ID="PriceLabel" runat="server" Text='<%# Eval("Price") %>' />
                                                        <br />
                                                        Remark:
                                                        <asp:Label ID="RemarkLabel" runat="server" Text='<%# Eval("Remark") %>' />
                                                        <br />
                                                        <br />
                                                                                                                          </ItemTemplate>--%>
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
                    </table>
                </asp:WizardStep>
                <asp:WizardStep ID="Stp2" runat="server" Title="Sign Up">
                    <div class="tab_box_login">
    
    	<div class="tab_box_login1">       
        			<div class="tab_box_login1_head">New User</div>
                    <div class="tab_box_login1_inner">
                        <table>
                            <tr>
                                <td>
                                    <div class="tab_box_butsign"><asp:LinkButton ID="lnkSignup" runat="server" ForeColor="#006600"  >Sign Up</asp:LinkButton></div>
                                    
                                </td>
                            </tr>
                        </table>
                        </div>
        </div>        
        <div class="tab_box_login1">       
        <div class="tab_box_login1_head">Registered User</div>
        <div class="tab_box_login1_inner">
            <table>
                <tr>
                    <td>Username:</td>
                    <td><asp:TextBox ID="txtuname" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Password:</td>
                    <td><asp:TextBox ID="txtpwd" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <div class="tab_box_butsign">
                            <asp:LinkButton ID="lnklogin" runat="server" ForeColor="#006600" >Log In</asp:LinkButton>
                        </div> 
                    </td>
                </tr>
            </table>
          
            </div>
            </div> 
        <div class="tab_box_login1">       
        <div class="tab_box_login1_head">Forgot Password</div>
        <div class="tab_box_login1_inner"></div>       
        </div> 
      </div>

                </asp:WizardStep>
                <asp:WizardStep ID="Stp3" runat="server" Title="Payment">
                    <table>
                        <tr>
                            <td>Select Payment Option</td>
                            <td>
                                <asp:DropDownList ID="ddlpaymenttype" runat="server">
                                    <asp:ListItem>Visa</asp:ListItem>
                                    <asp:ListItem>MasterCard</asp:ListItem>
                                    <asp:ListItem>Amex</asp:ListItem>
                                    <asp:ListItem>Discover</asp:ListItem>
                                </asp:DropDownList></td>
                            <td>Credit Card Number</td>
                            <td>
                                <asp:TextBox ID="txtcreditcardnumber" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>CVV2 Number</td>
                            <td>
                                <asp:TextBox ID="txtcvv2" runat="server"></asp:TextBox></td>
                            <td>Credit Card Expiry Date</td>
                            <td><asp:TextBox ID="txtexpdate" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>First Name</td>
                            <td><asp:TextBox ID="txtfirstname" runat="server"></asp:TextBox></td>
                            <td>Last Name</td>
                            <td><asp:TextBox ID="txtlastname" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Street</td>
                            <td><asp:TextBox ID="txtstreet" runat="server"></asp:TextBox></td>
                            <td>City</td>
                            <td><asp:TextBox ID="txtcity" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>State</td>
                            <td><asp:TextBox ID="txtstate" runat="server"></asp:TextBox></td>
                            <td>ZIP</td>
                            <td><asp:TextBox ID="txtzip" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Country Code</td>
                            <td><asp:TextBox ID="txtcountry" runat="server"></asp:TextBox></td>
                            <td>Currency Code</td>
                            <td><asp:TextBox ID="txtcurrency" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Description</td>
                            <td><asp:TextBox ID="txtdescripion" runat="server"></asp:TextBox></td>
                        </tr>
                    </table>
                    <asp:Button ID="btn_payment" runat="server" Text="Payment" />
                    
                                <asp:Button ID="btntaketest" runat="server" Text="Take Test"    />
                            
                </asp:WizardStep>
                 <asp:WizardStep ID="stp4" runat="server" Title="User Registration">
                    
        <table>
           
            <tr>
                <td align="left" valign="top">
                   
                                <div class="titlemain">
                                    User Creation</div>
                            </td>
                        </tr>
             
            <tr><td class="titlesub">Organizational Details</td></tr>
                      
                        <tr>
                            <td class="label1">
                                Name Of Organisation:</td>
                            <td>
                                <asp:DropDownList ID="ddlOrg" runat="server" 
                    AppendDataBoundItems="True" AutoPostBack="True"  Width="250px" >
                                    <asp:ListItem Value="0">--select--</asp:ListItem>
                                </asp:DropDownList>
                                <asp:LinqDataSource ID="OrgLinqDataSource" runat="server" 
                                    ContextTypeName="AssesmentDataClassesDataContext" 
                                    Select="new (Name, OrganizationID)" TableName="Organizations" 
                                    Where="Status == @Status &amp;&amp; Name == @Name">
                                    <WhereParameters>
                                        <asp:Parameter DefaultValue="1" Name="Status" Type="Int32" />
                                        <asp:Parameter DefaultValue="Career Judge" Name="Name" Type="String" />
                                    </WhereParameters>
                                </asp:LinqDataSource>
                            </td>
                             <td class="label1" >
                                Group Name:</td>
                            <td>
                                <asp:DropDownList ID="ddlUserGroup" runat="server" AppendDataBoundItems="True" 
                                    Width="250px" AutoPostBack="True" >
                                    <asp:ListItem Value="0">--select--</asp:ListItem>
                                </asp:DropDownList>
                                <asp:LinqDataSource ID="GrpUserLinqDataSource" runat="server" 
                                    ContextTypeName="AssesmentDataClassesDataContext" 
                                    Select="new (GroupName, GroupUserID, OrganizationID)" TableName="GroupUsers" Where="OrganizationID == @OrganizationID">
                                    <WhereParameters>
                                        <asp:Parameter DefaultValue="1" Name="OrganizationID" Type="Int32" />
                                    </WhereParameters>
                                </asp:LinqDataSource>
                            </td>
                        </tr>

                       
            <tr><td class="titlesub">Personal Details</td></tr>
                        <tr>
            <td class="label1">
                First Name:</td>
            <td>
                <asp:TextBox ID="txtFsName" runat="server" MaxLength="100" Width="250px"></asp:TextBox>
                <asp:Label ID="Label2" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
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
                <asp:DropDownList ID="ddlGender" runat="server" Width="250px">
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
            <td class="label1">
                Contact Number:</td>
            <td>
                <asp:TextBox ID="txtPhoneNumber" runat="server" MaxLength="20" Width="250px"></asp:TextBox>
            </td>
       
        </tr>
        <tr>
            <td class="label1">
                Email:</td>
            <td>
                <asp:TextBox ID="txtEmailId" runat="server" MaxLength="100" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtEmailId"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="txtEmailId" ErrorMessage="Invalid email" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
          
              <td>Are you recruited by someone?</td>
                <td>
                    <asp:DropDownList ID="ddlrecruiter" runat="server"  AutoPostBack="True" >
                        <asp:ListItem >Select</asp:ListItem>
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:DropDownList>
                  
                    <asp:TextBox ID="txtrecrutr" runat="server" Enabled="false"   Width="163px" ></asp:TextBox>
                    <asp:Label ID="Label7" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                

        </tr>

   
            <tr><td class="titlesub">Working Details</td></tr>
        <tr>
            <td class="label1">
                Industry:</td>
            <td>
                <asp:DropDownList ID="ddlIndustry" runat="server" AppendDataBoundItems="True" 
                    AutoPostBack="True"                   Width="250px">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                </asp:DropDownList>
                <asp:LinqDataSource ID="LinqDataSource3" runat="server" 
                    ContextTypeName="AssesmentDataClassesDataContext" 
                    Select="new (Name, IndustryID)" TableName="Industries">
                </asp:LinqDataSource>
                <br /><asp:TextBox ID="txtIndustry" runat="server" Visible="False" Width="250px" 
                    MaxLength="200"></asp:TextBox>
            </td>

            <td class="label1">
                Vocation:</td>
            <td>
                <asp:DropDownList ID="ddlJobCatgy" runat="server" AppendDataBoundItems="True" 
                    DataSourceID="LinqDataSource4" DataTextField="Name" DataValueField="JobCatID"
                     Width="250px">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                </asp:DropDownList>
                <asp:LinqDataSource ID="LinqDataSource4" runat="server" 
                    ContextTypeName="AssesmentDataClassesDataContext" Select="new (Name, JobCatID)" 
                    TableName="JobCategories">
                </asp:LinqDataSource>
                <asp:Label ID="Label3" runat="server" ForeColor="#FF3300" Text="*"></asp:Label>
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
                            <asp:DropDownList ID="ddlTotExpYears" runat="server">
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
                                            <asp:DropDownList ID="ddlTotExpMonths" runat="server">
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
                            <asp:DropDownList ID="ddlCurExpYears" runat="server">
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
                                            <asp:DropDownList ID="ddlCurExpMonths" runat="server">
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
            <tr><td class="titlesub">Educational Details</td></tr>
        <tr>
            <td class="label1">
                Educational Qualification:</td>
            <td>
                <asp:DropDownList ID="ddlQualification" runat="server" 
                    AppendDataBoundItems="True" AutoPostBack="True" 
                                    Width="250px">
                    <asp:ListItem Value="0">-- Select --</asp:ListItem>
                </asp:DropDownList>
                <asp:LinqDataSource ID="LinqQualifications" runat="server" 
                    ContextTypeName="AssesmentDataClassesDataContext" 
                    Select="new (Qualification1, QualificationId)" TableName="Qualifications">
                </asp:LinqDataSource>
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
        </tr>
                 
                        
            <tr><td class="titlesub">User Details</td></tr>
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
                                <asp:Button ID="btnSave" runat="server" Text="Submit"  />
                              
                            </td>
                            
                        </tr>
                        
                    </table>
                
   
                </asp:WizardStep>
            </WizardSteps>
        </asp:Wizard>
                
  
</div>
</asp:Content>

