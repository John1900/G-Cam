<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PreviewGrind.aspx.cs" Inherits="G_Cam.Gui.PreviewGrind" %>

<%@ Register Src="~/Controls/ucHeader.ascx" TagPrefix="uc1" TagName="ucHeader" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
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
                <td valign="top" colspan="3"> 
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: center; " colspan="6">
                    <asp:Image ID="imgMain" runat="server" ImageUrl="~/Temporary/grind.png" />
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 80%">
                    View ginding wheel at rotation:</td>
                <td style="text-align: right;">
                    &nbsp;</td>
                <td style="text-align: left;">
                     <asp:TextBox ID="txtAlpha" runat="server" Width="30px">0</asp:TextBox>
                </td>
                <td style="text-align: center; width: 10%">
                    <asp:Button ID="cmdUpdate" runat="server" Text="Update" OnClick="cmdCompute_Click" />
                </td>
                <td style="text-align: center; width: 10%">
                    <asp:CheckBox ID="chkZoom" runat="server" Text="Zoom" />
                </td>
                <td style="text-align: right; width: 20%">
                    <asp:Button ID="cmdExit" runat="server" Text="Close" OnClick="cmdExit_Click" />
                </td>
            </tr>
        </table>
        <asp:Label ID="lblErr" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
    </form>
</body>
</html>
