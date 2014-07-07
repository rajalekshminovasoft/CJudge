<%@ Page Title="" Language="C#" MasterPageFile="~/CJMaster.master" AutoEventWireup="true" CodeFile="InfoKit.aspx.cs" Inherits="InfoKit"   %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center">
        <tr>
            <td><table>
                <tr>
                    <td>
                        <asp:Panel ID="pnlDownloadFileList" runat="server" Height="400px" 
                                        HorizontalAlign="Left" ScrollBars="Auto" Width="300px">
                                    </asp:Panel>
                    </td>
                </tr>
                </table></td>
            <td>
                <asp:Panel ID="Panel2" runat="server" Height="550px" HorizontalAlign="Left" 
                            ScrollBars="Auto" Width="600px">
                            <table>
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td ID="tcelPhotoimage" runat="server" colspan="2" rowspan="5" width="100">
                                                                &nbsp;</td>
                                                            <td>
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="border-right-style: groove; border-right-width: 3px; border-right-color: #000000; border-top-style: groove; border-top-width: 3px; border-top-color: #000000;" 
                                                                width="600">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="border-right-style: groove; border-right-width: 3px; border-right-color: #000000">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="border-right-style: groove; border-right-width: 3px; border-right-color: #000000">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td style="border-right-style: groove; border-right-width: 3px; border-right-color: #000000">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="22">
                                                                &nbsp;</td>
                                                            <td ID="tcellInfoKitdetails" runat="server" colspan="2" height="400" 
                                                                style="border-right-style: groove; border-right-width: 3px; border-right-color: #000000; border-bottom-style: groove; border-bottom-width: 3px; border-bottom-color: #000000; border-left-style: groove; border-left-width: 3px; border-left-color: #000000; vertical-align: top; text-align: left;">
                                                                &nbsp;</td>
                                                        </tr>

                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>

