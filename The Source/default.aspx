<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GCam.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            vertical-align: top;
        }
        .auto-style2 {
            width: 64px;
            height: 64px;
        }
        .auto-style4 {
            background-color: #66FFFF;
        }
        .auto-style7 {
            width: 350px;
            height: 262px;
        }
        .auto-style8 {
            color: #CC0000;
        }
    </style>
</head>
<body>
    <table class="auto-style1">
        <tr>
            <td class="auto-style4" style="color: #000099">
                <img alt="" class="auto-style2" src="../Images/Cam.gif" /></td>
            <td class="auto-style4">
                <h1><em>G-CAM Generate gcode for cam grinding</em></h1>
                <h4>Developed by members of the <a href="http://tsme.ca">Toronto Society of Model Engineers</a></h4>
            </td>
        </tr>
    </table>
    <form id="form1" runat="server">
    <div>
        <table class="auto-style1">
            <tr>
                <td valign="top">
                    <td>
                        <table>
                            <tr>
                                <td valign="top" colspan="2">
                                    <em style="color: #CC0000">This program builds G Code to grind a cam.<br />
                                    <br />
                                    <strong>RELEASE 1.0&nbsp; Use with care!!&nbsp; Report errors to <a href="mailto:tsmewebmaster@gmail.com">tsmewebmaster@gmail.com</a></strong><br />
                                    </em>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" colspan="2">
                                    You enter the cam geometry, characteristics of your mill, depth of roughing and finishing passes and the program builds the G Code.<br />
                                    <br />
                                </td>
                            </tr>
                                <td>
                                     Click Next for guided instructions
                                </td>
                                <td style="text-align: left" width="40%">
                                     <asp:Button ID="cmdNext" runat="server" Text="Next" Width="100px" OnClick="cmdNext_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                     <br />
                                     Program written by John. Concept, setup testing and photographs by Dave.&nbsp;
                                     <br />
                                     Contact: <a href="mailto:tsmewebmaster@gmail.com">tsmewebmaster@gmail.com</a></td>
                            </tr>
                            <tr>
                                 <td colspan="2">
                                     <br />
                                     This free G-Cam program is licensed under a <a href="http://creativecommons.org/licenses/by/3.0/" rel="license">Creative Commons Attribution 3.0 License</a>.
                                        <br />
                                        <a href="http://opensource.org/../ToS">Terms of Service</a><br />
                                 </td>
                             </tr>
                            <tr>
                                <td colspan="2">
                                     <br />
                                     <span class="auto-style8"><strong>Remember!&nbsp; Workshops are dangerous.&nbsp; Wear safety equipment and take care.&nbsp; 
                                     <br />
                                     This program is free and comes without any warrenty.&nbsp; Check the G-Code before running.</strong></span></td>
                                     </tr>
                      </table>
                    </td>
                    <br />
                </td>
                <td>
                    <img alt="" class="auto-style7" src="../Images/Setup350.jpg" /></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <br />
                    <strong>Source code</strong> is available from <a href="https://github.com/">https://github.com/</a>&nbsp; Register for free and search for G-Cam or John1900<br />
                    Non-Programmers download CompGeometry.cs from the classes directory.&nbsp; This file contains all the calculations and can be opened in Notebook or other text editor.</td>
            </tr>
        </table>
    
    </div>
    </form>
    <p>
        &nbsp;</p>
</body>
</html>
