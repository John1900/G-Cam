<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaveData.aspx.cs" Inherits="G_Cam.Gui.SaveData" %>

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

    <table width="50%" border="1" cellpadding="10", cellspacing="0">
        <tr>
            <td align="center">
                <table widt0="100%">
                    <tr>
                        <td colspan="2" align="left">
                            <br />
                            <strong><span class="auto-style4">
                            Save CAM Values</span></strong>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="auto-style1">
                            <br />
                            <br />
                            File name:&nbsp;&nbsp;
                            <asp:TextBox ID="txtFile" runat="server" Width="200px"></asp:TextBox>
&nbsp;<br />
                            <br />
                        </td>
                    </tr>
                        <tr>
                            <td style="text-align: right" class="auto-style1">
                                <br />
                                <asp:Button ID="cmdSaveNow" runat="server" OnClick="cmdSaveNow_Click" Text="Save now" />
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
