<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RestoreData.aspx.cs" Inherits="G_Cam.Gui.RestoreData" %>

<%@ Register Src="~/Controls/ucHeader.ascx" TagPrefix="uc1" TagName="ucHeader" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 1597px;
            text-align: right;
        }
    </style>
    </head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:ucHeader runat="server" id="ucHeader" />
    </div>

    <table width="60%" border="1" cellpadding="10", cellspacing="0">
        <tr>
            <td align="center">
                <table widt0="100%">
                    <tr>
                        <td colspan="2" align="left">
                            <strong><span class="auto-style4">
                            <br />
                            Restore CAM Values</span></strong>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="auto-style1">
                            <br />
                            <br />
                            <br />
                            Select file:
                            <asp:FileUpload ID="FileUpload" runat="server" Width="350px" />
                            <br />
                            <br />
                        </td>
                    </tr>
                        <tr>
                            <td style="text-align: right" class="auto-style1">
                                <br />
                                <asp:Button ID="cmdUploadNow" runat="server" OnClick="cmdUploadNow_Click" Text="Restore now" />
                                <br />
                            </td>
                       </tr>
                        <tr>
                            <td class="auto-style1">
                                <br />
                                <br />
                                <br />
                                <asp:Button ID="cmdCancel" runat="server" OnClick="cmdCancel_Click" Text="Close" />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lblError" runat="server" ForeColor="#FF3300"></asp:Label>
                            </td>
                        </tr>
                    </table>
                 </td>
            </tr>
        </table>
    </form>
</body>
</html>
