<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucBuild.ascx.cs" Inherits="G_Cam.Controls.ucBuild" %>

<table width="100%">
    <tr>
        <td colspan="2">
            <strong><span class="gpanelHead">Build the G Code</span>&nbsp;&nbsp;
            <asp:Label ID="lblErrHead" runat="server" class="gpanelError" Text="Errors on page.  Correct before continuing!" Visible="False"></asp:Label>
            </strong>
        </td>
    </tr>
    <tr>
        <td width="80%">
            <table>
                <tr>
                    <td>
                        <em>
                        <asp:Label ID="lblSetup" runat="server" style="font-size: small">If cutting several cams on the same blank, rotate the table until the part of the bank that will become the nose is pointing directly at the centre of the grinding wheel.<br />
                            Move the grinding wheel to just touch the blank and zero the A and X axis </asp:Label>
                        </em></td>
                 </tr>
                 <tr>
                    <td>
                        <asp:Label ID="lblBuildRough" runat="server">Build code for x passes of x.xxx inches</asp:Label>
                    </td>
                    <td>
                        <asp:Button ID="cmdBuildRough" runat="server" Text="Build Rough Passes" OnClick="cmdBuildRough_Click" />
                    </td>
                </tr> 
                <tr>
                    <td colspan="2">
                        <em>Save the parameters of this cam with the save button above. You will need to restore these values to compute the finish pass.<br />
                        Now run the code to rough grind the cam.
                        <br />
                        <br />
                        DO NOT change the setup when complete.</em></td>
                </tr>
                <tr>
                    <td colspan="2" style="font-style: italic">
                        <asp:Label ID="lblFinishNote" runat="server" style="font-style: italic">Your cam should now have a base diameter of x.xxx</asp:Label>
                        &nbsp;The final pass will be adjusted to compensate for any errors.<br />
                    </td>
                </tr>
                <tr>
                    <td>
                        Enter actual diameter of the base circle</td>
                    <td>
                        <asp:TextBox ID="txtNewBaseRadius" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Build code for the finish pass</td>
                    <td class="auto-style1">
                        <asp:Button ID="cmdBuildFinish" runat="server" OnClick="cmdBuildFinish_Click" Text="Build Finish Pass" style="height: 26px" />
                    </td>
                </tr>
            </table>
        </td>
        <td valign="top" width="275px" class="auto-style2">
            <img src="../Images/Finished350.jpg" alt="" style="height: 193px; width: 275px" /><br />
            <br />
            <asp:Button ID="cmdViewGrind" runat="server" OnClick="cmdViewGrind_Click" Text="View Grinder" />
        &nbsp;</td>
    </tr>   
    <tr>
        <td>
            <asp:Label ID="lblError" runat="server" class="gpanelError"></asp:Label>
        </td>
    </tr>
</table>