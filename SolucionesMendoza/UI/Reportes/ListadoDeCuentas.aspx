<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoDeCuentas.aspx.cs" Inherits="SolucionesMendoza.UI.Reportes.ListadoDeCuentas" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager runat="server"></asp:ScriptManager> 
            
            <rsweb:ReportViewer ID="CuentasReportViewer" runat="server" ProcessingMode="Remote">
                <ServerReport ReportPath="" ReportServerUrl="" />
            </rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
