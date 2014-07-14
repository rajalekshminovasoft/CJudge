<%@ Page Title="" Language="C#" MasterPageFile="~/CJMaster.master" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="scripts/jquery.datepick.js"></script>
    <link href="styles/jquery.datepick.css" rel="stylesheet" />
    <link href="styles/style1.css" rel="stylesheet" />
        <script src="http://ajax.microsoft.com/ajax/jquery/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="scripts/jquery.datepick.js">
        $(function () {
            $('#ctl00_ContentPlaceHolder1_txt_fromdate').datepick({ dateFormat: 'mm/dd/yyyy' });

        });
          </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <table>
        <tr>
            <td>
                <asp:textbox id="txt_fromdate" runat="server"></asp:textbox>
            </td>
        </tr>
    </table>
</asp:Content>

