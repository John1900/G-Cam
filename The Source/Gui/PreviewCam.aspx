<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PreviewCam.aspx.cs" Inherits="G_Cam.Gui.previewCam" %>

<%@ Register Src="~/Controls/ucHeader.ascx" TagPrefix="uc1" TagName="ucHeader" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <style type="text/css">
        .auto-style1 {
            width: 300px;
        }
        .auto-style2 {
            font-size: large;
        }
        .auto-style3 {
            width: auto;
        }
        .auto-style4 {
            width: 100%;
        }
        .auto-style5 {
            width: auto;
            text-align: right;
        }
        .auto-style6 {
            width: 139%;
        }
        </style>
    
</head>
<body>
    <form id="form1" runat="server">
    <uc1:ucHeader runat="server" id="ucHeader" />

    <table class="auto-style4">
        <tr>
            <td colspan="2">
                <asp:Label ID="lblName" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
            <table>
               <tr>
                    <td>
                        <asp:Label ID="lblDescription" runat="server" Font-Size="Smaller"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <table class="auto-style1">
                        <tr>
                            <td class="auto-style2" colspan="3"><strong>Entered Values</strong></td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td class="auto-style3">
                                <asp:Label ID="lblUnits" runat="server" Text="Units of measure"></asp:Label>
                            </td>
                             <td class="auto-style5">
                               <asp:Label ID="lblUnitsValue" runat="server">n</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="lblDecimals" runat="server" Text="Decimal places"></asp:Label>
                            </td>
                             <td class="auto-style5">
                                <asp:Label ID="lblDecimalsValue" runat="server">n</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="lblBaseRadius" runat="server" Text="Base radius"></asp:Label>
                            </td>
                             <td class="auto-style5">
                                <asp:Label ID="lblBaseRadiusValue" runat="server">n</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="lblFlankRadius" runat="server" Text="Flank radius"></asp:Label>
                            </td>
                             <td class="auto-style5">
                                <asp:Label ID="lblFlankRadiusValue" runat="server"> n</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="lblAction" runat="server" Text="Action"></asp:Label>
                            </td>
                             <td class="auto-style5">
                                <asp:Label ID="lblActionValue" runat="server">n</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="lblLift" runat="server" Text="Lift"></asp:Label>
                            </td>
                             <td class="auto-style5">
                                <asp:Label ID="lblLiftValue" runat="server">n</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="lblRPM" runat="server" Text="RPM" style="text-align: left"></asp:Label>
                            </td>
                             <td class="auto-style5">
                                <asp:Label ID="lblRPMValue" runat="server">n</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                    <table class="auto-style1">
                        <tr>
                            <td class="auto-style2" colspan="4"><strong>Computed Values</strong></td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td class="auto-style3">
                                <asp:Label ID="Label15" runat="server" Text="Nose radius"></asp:Label>
                            </td>
                            <td class="auto-style5">
                                <asp:Label ID="lblNoseRadius" runat="server">n</asp:Label>
                            </td>
                            <td class="auto-style5">
                                &nbsp;
                            </td>
                       </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td class="auto-style3">
                                &nbsp;</td>
                            <td class="auto-style5">
                                X</td>
                            <td class="auto-style5">
                                Y</td>
                       </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td class="auto-style3">
                                <asp:Label ID="Label1" runat="server" Text="Nose centre"></asp:Label>
                            </td>
                             <td class="auto-style5">
                                <asp:Label ID="lblNoseCentreX" runat="server"></asp:Label>
                            </td>
                            <td class="auto-style5">
                                <asp:Label ID="lblNoseCentreY" runat="server"></asp:Label>
                            </td>
                       </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td class="auto-style3">
                                Flank centre</td>
                             <td class="auto-style5">
                                <asp:Label ID="lblFlankCentreX" runat="server"></asp:Label>
                            </td>
                            <td class="auto-style5">
                                <asp:Label ID="lblFlankCentreY" runat="server"></asp:Label>
                            </td>
                       </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td class="auto-style3">
                                <asp:Label ID="Label5" runat="server" Text="Lower transition"></asp:Label>
                            </td>
                             <td class="auto-style5">
                                <asp:Label ID="lblLowerTransitionX" runat="server">n</asp:Label>
                            </td>
                            <td class="auto-style5">
                                <asp:Label ID="lblLowerTransitionY" runat="server">n</asp:Label>
                            </td>
                       </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td class="auto-style3">
                                <asp:Label ID="Label7" runat="server" Text="Upper transition"></asp:Label>
                            </td>
                              <td class="auto-style5">
                                <asp:Label ID="lblUpperTransitionX" runat="server">n</asp:Label>
                            </td>
                            <td class="auto-style5">
                                <asp:Label ID="lblUpperTransitionY" runat="server">n</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td class="auto-style3">
                                Flat lifter diameter (min!)</td>
                              <td class="auto-style5">
                                <asp:Label ID="lblLifterWidth" runat="server">n</asp:Label>
                            </td>
                       </tr>

                    </table>
                    </td>
                </tr>
            </table>
            </td>
            <td valign="top">    
                <asp:Image ID="imgGraph" runat="server" />
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td class="auto-style6">
                <strong><asp:Label ID="lblType" runat="server" Font-Bold="True" Text="Label"></asp:Label>
                </strong>
            </td>
            <td align="right">
                <asp:Button ID="cmdExit" runat="server" Text="Close" OnClick="cmdExit_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Image ID="imgChart" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:Label ID="lblAcceleration" runat="server" Text="Label"></asp:Label>
            </td>
            <td style="text-align: right" width ="30px">
                &nbsp;</td>
        </tr>

    </table>
    </form>
    </body>
</html>
