<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewGCode.aspx.cs" Inherits="G_Cam.Gui.ViewGCode" %>

<%@ Register Src="~/Controls/ucHeader.ascx" TagPrefix="uc1" TagName="ucHeader" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            font-size: large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:ucHeader runat="server" id="ucHeader" />
    </div>
        <table class="auto-style1">
            <tr>
                <td colspan="2" class="auto-style2">
                    <strong>Generated G Code </strong>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:TextBox ID="txtCode" runat="server" Height="400px" TextMode="MultiLine" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="80%">
                    <asp:Label ID="lblWarn" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <td style="text-align: right" >
                    <asp:Button ID="cmdDownload" runat="server" Text="Download G Code" Width="150px" OnClick="cmdDownload_Click" />
                </td>
                <td style="text-align: right">
                    <asp:Button ID="cmdExit" runat="server" Text="Close" Width="150px" OnClick="cmdExit_Click" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
