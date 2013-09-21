<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucGCode.ascx.cs" Inherits="G_Cam.Controls.ucGCode" %>
<table width="100%">
    <tr>
        <td colspan="2">
            <strong><span class="gpanelHead">G-Code Generation Options</span>&nbsp;&nbsp;
            <asp:Label ID="lblErrHead" runat="server" class="gpanelError" Text="Errors on page.  Correct before continuing!" Visible="False"></asp:Label>
            </strong>
        </td>
    </tr>
    <tr>
        <td>
            <table>
               <tr>
                    <td >
                        Rotational step size in degrees</td>
                    <td valign="top">
                        <asp:TextBox ID="txtStep" runat="server" Width="80px" ToolTip="The program steps the blank by this increment.  At each step a position is calculated for the centre of the grinding wheel.  The smaller the step the larger the GCode program.  HINT: Set a step size of 10 degrees to produce a small file for checking. "></asp:TextBox>
                    </td>
                </tr>
               <tr>
                    <td colspan="2">
                        <em style="font-size: small">
                        Step size is the increment used to calculate the offsets needed for the cam profile.&nbsp;
                        A step size of 0.01 degrees should be sufficient.<br />
                        </em></td>
                    <td valign="top">
                        &nbsp;</td>
                </tr>
                 <tr>
                    <td>
                        Tracking leeway </td>
                    <td>
                        <asp:TextBox ID="txtAccuracy" runat="server" Height="16px" Width="80px" ToolTip="G Code is only generated when the position of the grinder changes by more than the leeway.  This saves generated many lines of code that will never do anything.  Set this value to about your mills positioning ability."></asp:TextBox>
                     </td>
                </tr>
                 <tr>
                    <td colspan="2">
                        <em style="font-size: small">
                        G Code is only generated if the offset changes by at least the tracking leeway.
                        <br />
                        Setting the tracking leeway finer than your mill will handle will produce a very long G Code file most of which will not be used.</em><br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="label-style" colspan="2">
                        G-Code to append to front of file (M3 M8 F S etc.)<br />
                        <asp:TextBox ID="txtPreCode" runat="server" Height="100px" TextMode="MultiLine" Width="350px"></asp:TextBox>
                        </td>
                </tr>
                <tr>
                    <td class="label-style" colspan="2">
                        G-Code to add to end of file (M3 M30 etc.)<br />
                        <asp:TextBox ID="txtPostCode" runat="server" Height="100px" TextMode="MultiLine" Width="350px"></asp:TextBox>
                        </td>
                </tr>
 
              <tr>
                    <td colspan="2">
                        <asp:Label ID="lblError" runat="server" class="gpanelError"></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
        <td width="40%" valign="top">
            <img src="../Images/Finished350.jpg" alt="" />
            <br />
            <br />
        </td>
    </tr>


</table>