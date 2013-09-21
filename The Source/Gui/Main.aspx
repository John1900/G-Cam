<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="G_Cam.Gui.Main" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register Src="~/Controls/ucGeometry.ascx" TagPrefix="uc1" TagName="ucGeometry" %>
<%@ Register Src="~/Controls/ucMill.ascx" TagPrefix="uc1" TagName="ucMill" %>
<%@ Register Src="~/Controls/ucTab.ascx" TagPrefix="uc1" TagName="ucTab" %>
<%@ Register Src="~/Controls/ucIntroduction.ascx" TagPrefix="uc1" TagName="ucIntroduction" %>
<%@ Register Src="~/Controls/ucGrind.ascx" TagPrefix="uc1" TagName="ucGrind" %>
<%@ Register Src="~/Controls/ucGCode.ascx" TagPrefix="uc1" TagName="ucGCode" %>
<%@ Register Src="~/Controls/ucBuild.ascx" TagPrefix="uc1" TagName="ucBuild" %>

<!DOCTYPE html>



<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <title></title>

    <style type="text/css">
        .gheader {
            background-color: antiquewhite;
            color: royalblue;
        }
        .gpanel {
            background-color: white;
            color: black;
        }
        .gpanelHead {
            background-color: white;
            color: royalblue;
        }
        .gpanelError {
            color: red;
            background-color: antiquewhite;
        }
    </style> 
</head>
<body>
    <form id="form1" runat="server" defaultbutton="btnEnter">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </div>
    
    <table cellpadding="0" cellspacing="0" width="100%" class="gheader">
        <tr>
            <td width="32px">
                <img alt="G-Cam" src="../Images/GCamIcon.png" />
            </td>
            <td>
                <h2>&nbsp;&nbsp; G-CAM - Build gcode to grind cams</h2>
            </td>
            <td align="right">
                <asp:Label ID="lblHead" runat="server"></asp:Label><br />
                <asp:Button ID="cmdSave" runat="server" Text="Save" Width="80px" OnClick="cmdSave_Click" />
                <asp:Button ID="cmdRestore" runat="server" Text="Restore" Width="80px" OnClick="cmdRestore_Click" />
                <asp:Button ID="cmdPrev" runat="server" Text="<< Previous" Width="80px" OnClick="cmdPrev_Click" />
                <asp:Button ID="cmdNext" runat="server" Text="Next >>" Width="80px" OnClick="cmdNext_Click" />
           </td>
        </tr>
    </table>
        <p></p>

<asp:TabContainer ID="GCamTabs" runat="server" AutoPostBack="true" OnActiveTabChanged="GCamTabs_ActiveTabChanged">

    

    <asp:TabPanel runat="server" ID="TabIntroduction"><HeaderTemplate>
<uc1:ucTab runat="server" id="ucIntroductionTab" />
</HeaderTemplate>
<ContentTemplate>
<asp:Panel ID="panelIntroduction" runat="server"  BackColor="Transparent" Width="100%" ><uc1:ucIntroduction runat="server" ID="ucIntroduction" />
</asp:Panel>
</ContentTemplate>
</asp:TabPanel>

<asp:TabPanel runat="server" ID="TabGeometry"><HeaderTemplate>
<uc1:ucTab runat="server" id="ucGeometryTab" />
</HeaderTemplate>
<ContentTemplate>
<asp:Panel ID="panelGeometry" runat="server"  BackColor="Transparent" Width="100%" ><uc1:ucGeometry runat="server" ID="ucGeometry" /></asp:Panel>
</ContentTemplate>
</asp:TabPanel>

<asp:TabPanel runat="server" ID="TabMill"><HeaderTemplate>
<uc1:ucTab runat="server" id="ucMillTab" />
</HeaderTemplate>
<ContentTemplate>
<asp:Panel ID="panelMill" runat="server"  BackColor="Transparent" Width="100%" ><uc1:ucMill runat="server" ID="ucMill" /></asp:Panel>
</ContentTemplate>
</asp:TabPanel>

<asp:TabPanel runat="server" ID="TabGrind"><HeaderTemplate>
<uc1:ucTab runat="server" id="ucGrindTab" />
</HeaderTemplate>
<ContentTemplate>
<asp:Panel ID="panelGrind" runat="server"  BackColor="Transparent" Width="100%" ><uc1:ucGrind runat="server" ID="ucGrind" /></asp:Panel>
</ContentTemplate>
</asp:TabPanel>
<asp:TabPanel runat="server" ID="TabGCode"><HeaderTemplate>
<uc1:ucTab runat="server" id="ucGcodeTab" />
</HeaderTemplate>
<ContentTemplate>
<asp:Panel ID="panelGCode" runat="server"  BackColor="Transparent" Width="100%" ><uc1:ucGCode runat="server" ID="ucGCode" /></asp:Panel>
</ContentTemplate>
</asp:TabPanel>
<asp:TabPanel runat="server" ID="TabBuild"><HeaderTemplate>
<uc1:ucTab runat="server" id="ucBuildTab" />
</HeaderTemplate>
<ContentTemplate>
<asp:Panel ID="panelBuild" runat="server"  BackColor="Transparent" Width="100%" ><uc1:ucBuild runat="server" ID="ucBuild" /></asp:Panel>
</ContentTemplate>
</asp:TabPanel>
</asp:TabContainer>
<asp:Button ID="btnEnter" runat="server" OnClick="btnEnter_Click" Text="" style="visibility:hidden;" />
</form>
</body>
</html>




