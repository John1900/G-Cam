<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMill.ascx.cs" Inherits="G_Cam.Controls.ucMill" %>

<table width="100%" class="gpanel">
    <tr>
        <td colspan="2">
            <strong><span  class="gpanelHead">Describe the Milling Machine</span>&nbsp;&nbsp;
            <asp:Label ID="lblErrHead" runat="server" class="gpanelError" Text="Errors on page.  Correct before continuing!" Visible="False"></asp:Label>
            </strong>
        </td>
    </tr>
    <tr>
        <td>
            <table cellpadding="5px">
                <tr>
                    <td colspan="4">
                            <em>The axis of the rotary table and grinding wheel must be aligned parallel.</em>
                    </td>
                </tr>
                <tr>
                    <td>
                        Positional axis <asp:TextBox ID="txtPositionalAxis" runat="server" Height="16px" Width="24px" MaxLength="1" ToolTip="Typically X, Y or Z."></asp:TextBox>
                    </td>
                    <td>
                        Default positional feed rate (F) <asp:TextBox ID="txtPositionalFeed" runat="server" Height="16px" Width="24px" ToolTip="Feed rate used with the F option on GCode where the postional axis changes."></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <em>
                            Mill must support both negative and positive values between -10 and +370 degrees.  
                        <br />
                        For Mach3 disable Rot 360 rollover, short rotate and set soft limits accordingly.
                        </em><br />
                        <br />
                        Increasing the positional axis value will&nbsp;<asp:RadioButtonList ID="radioPositional" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Value="I">Increase</asp:ListItem>
                            <asp:ListItem Value="R">Reduce</asp:ListItem>
                        </asp:RadioButtonList>&nbsp;the distance to the grinding wheel
                    </td>
                </tr>
                <tr>
                    <td>
                        Rotary axis <asp:TextBox ID="txtRotaryAxis" runat="server" Height="16px" Width="24px" MaxLength="1" ToolTip="Rotary axis.  Typically A."></asp:TextBox>
                    </td>
                    <td>
                        Default rotary feed rate (F) <asp:TextBox ID="txtRotaryFeed" runat="server" Height="16px" Width="34px" ToolTip="Feed rate used with the F option on GCode where only the rotary axis changes."></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                         While grinding <asp:RadioButtonList ID="radioRotary" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Selected="True" Value="I">Increase</asp:ListItem>
                            <asp:ListItem Value="R">Reduce</asp:ListItem>
                        </asp:RadioButtonList>
                    &nbsp;the rotary axis value<br />
                    </td>
                </tr>
                <tr>
                    <td>
                        Optional cross feed axis 
                        <asp:TextBox ID="txtCrossAxis" runat="server" Height="16px" Width="24px" MaxLength="1" ToolTip="Optionally used with a ball mill.  Each cut is repeated across the face of the cam. Typically X, Y or Z. Leave blank to not use."></asp:TextBox>
                    </td>
                    <td>
                        Starts at zero and continues to
                        <asp:TextBox ID="txtCrossEnd" runat="server" Height="16px" Width="32px" ToolTip="Feed rate used with the F option on GCode where the postional axis changes."></asp:TextBox>
                    &nbsp;&nbsp;with step size <asp:TextBox ID="txtCrossStep" runat="server" Height="16px" Width="32px" ToolTip="Feed rate used with the F option on GCode where the postional axis changes."></asp:TextBox>
                    </td>
                </tr>
            </table>
        </td>
        <td valign="top">
            <img alt="" src="../Images/Finished350.jpg" />
            <br />
            <br />
        </td>
    </tr>
    <tr>
        <td width="90%">
            <asp:Label ID="lblError" runat="server"  class="gpanelError"></asp:Label>
        </td>
        <td align="left">
            &nbsp;</td>
    </tr>
</table>