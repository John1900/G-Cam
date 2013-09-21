<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucIntroduction.ascx.cs" Inherits="G_Cam.Controls.ucIntroduction" %>


<table class="gpanel">
    <tr>
        <td colspan="2">
            <strong><span class="gpanelHead">How to build a cam with this program.&nbsp;&nbsp;</span>
            <asp:Label ID="lblErrHead" runat="server" class="gpanelError" Text="Errors on page.  Correct before continuing!" Visible="False"></asp:Label>
            </strong>
        </td>
    </tr>
    <tr>
        <td>
            <img src="../Images/Setup350.JPG" align="right" alt="">
            <p>First turn a cam blank a little oversize and mount it in a rotary table.</p>
            <p>Setup a grinding wheel with it&#39;s axis of rotation parallel to that of the rotary table.&nbsp; The distance between the cam and the grinding wheel is adjusted through one of the mill&#39;s linear axis (X, Y or Z).</p>
            <p>In the following screens you enter the geometry of the cam, provide information about the milling machine and set the desired grinding depths.</p>
            <p>This program then builds a gcode file.</p>
            <p>Grinding is done in two stages.&nbsp; First, multiple passes to bring the blank close to the final dimension then a finish pass.&nbsp; The finish pass is computed separately, this gives the opportunity to adjust for any wear on the grinding wheel.</p>
            <p><span class="gpanelHead">Warning:</span> If you close your browser or leave it unattended for about 20 minutes the server will forget what you entered.&nbsp; Use the save and restore buttons on each page.</p>
        </td>
    </tr>
</table>