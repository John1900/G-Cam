<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucGrind.ascx.cs" Inherits="G_Cam.Controls.ucGrind" %>
<table width="100%" class="gpanel">
    <tr>
        <td colspan="2">
            <strong><span class="gpanelHead">Describe the Grinding Process</span>&nbsp;&nbsp;
            <asp:Label ID="lblErrHead" runat="server" class="gpanelError" Text="Errors on page.  Correct before continuing!" Visible="False"></asp:Label>
            </strong>
        </td>
    </tr>
    <tr>
        <td>
            <table cellpadding="5px" width="80%">
                <tr>
                    <td width="100%">
                        Diameter of grinding wheel</td>
                    <td>
                        <asp:TextBox ID="txtWheelDiameter" runat="server" Height="16px" Width="80px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Diameter of blank</td>
                    <td>
                        <asp:TextBox ID="txtBlankDiameter" runat="server" Height="16px" Width="80px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Maximum depth for of each of multiple passes.&nbsp; Enter zero to grind in one pass.</td>
                    <td>
                        <asp:TextBox ID="txtMaxPass" runat="server" Height="16px" Width="80px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Allowance 
                        to leave for a final finishing pass.&nbsp; Enter zero for no finish pass</td>
                    <td>
                        <asp:TextBox ID="txtFinishPass" runat="server" Height="16px" Width="80px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Backlash compensation in degrees</td>
                    <td>
                        <asp:TextBox ID="txtBacklash" runat="server" Height="16px" Width="80px" ToolTip="Before starting a grinding pass the grinder will be retracted a safe distance and the cam routed this number of degrees befor the start.  This will pick up any backlash."></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Clearance from blank for safe G0 moves</td>
                    <td>
                        <asp:TextBox ID="txtSafe" runat="server" Height="16px" Width="80px" ToolTip="Distance to retract the grinding wheel before repositioning.  Do not use a sign."></asp:TextBox>
                    </td>
                </tr>
            </table>
        </td>
        <td valign="top">
            <img alt="" src="../Images/Mill350.jpg" />
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Label ID="lblError" runat="server" class="gpanelError"></asp:Label>
        </td>
    </tr>
 </table>