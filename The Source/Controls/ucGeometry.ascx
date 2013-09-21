<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucGeometry.ascx.cs" Inherits="G_Cam.Controls.ucGeometry" %>

<table width="100%" class="gpanel">
    <tr>
        <td colspan="2">
            <strong><span class="gpanelHead">Enter the Geometry of your Cam</span>&nbsp;&nbsp;
            <asp:Label ID="lblErrHead" runat="server" class="gpanelError" Text="Errors on page.  Correct before continuing!" Visible="False"></asp:Label>
            </strong>
        </td>
    </tr>
    <tr>
        <td>
            <table>
                <tr>
                    <td  width="300px">Name</td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" Height="16px" Width="280px" ToolTip="Name for this cam.  Shows on page headings."></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Description</td>
                    <td>
                        <asp:TextBox ID="txtDescription" runat="server" Height="48px" Width="280px" style="margin-left: 0px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblUnits" runat="server" Text="Units"></asp:Label>
                    </td>
                    <td>
                        <asp:RadioButtonList ID="radioUnits" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True">inches</asp:ListItem>
                            <asp:ListItem Value="mm">mm</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDecimals" runat="server" Text="Decimal places"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDecimals" runat="server" Height="16px" Width="26px" MaxLength="1" ToolTip="All calculations use double precision arithmetic before rounding to this many decimal places."></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblBaseRadius" runat="server" Text="Base radius"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtBaseRadius" runat="server" Height="16px" Width="80px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblFlankRadius" runat="server" Text="Flank radius"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFlankRadius" runat="server" Width="80px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblLift" runat="server" Text="Lobe lift"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtValveLift" runat="server" Width="80px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblAction" runat="server" Text="Duration degrees"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAction" runat="server" Width="80px" ToolTip="This is the angle between the transitions from base circle to flank arc.  Value must be less than 180 degrees."></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblRPM" runat="server" Text="RPM"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtRpm" runat="server" Width="80px" ToolTip="This value is used to compute acceleration and is the rotational speed of the CAM.  Not the crankshaft speed!"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblError" runat="server" class="gpanelError"></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
        <td width="40%">
            <img src="../Images/Geometry280.JPG" alt="">
        </td>
    </tr>
    <tr>
        <td align="right" colspan="2">
            <br />
            <asp:Button ID="cmdView" runat="server" Text="View metrics" ToolTip="View a scale diagram of the cam with various metrics." OnClick="cmdView_Click" />
            &nbsp;<asp:RadioButtonList ID="radioType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" Width="340px" Height="28px">
                    <asp:ListItem Selected="True" Value="L">Lift</asp:ListItem>
                    <asp:ListItem Value="V">Velocity</asp:ListItem>
                    <asp:ListItem Value="A">Acceleration</asp:ListItem>
                    <asp:ListItem Value="G">Grinding</asp:ListItem>
                </asp:RadioButtonList>
        </td>
    </tr>

</table>
