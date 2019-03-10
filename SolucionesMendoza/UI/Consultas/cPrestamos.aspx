<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="cPrestamos.aspx.cs" Inherits="SolucionesMendoza.UI.Consultas.cPrestamo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="jumbotron" style="background-color: #E0FFFF">
        <hr>
        <h5 class="display-4" style="color: #0099FF; font-weight: bold;">Consulta de Prestamos</h5>
        <hr>
        <div class="form-row justify-content-center">
            <div class="form-group col-md-2">
                <asp:Label Text="Filtro" ForeColor="#0099FF" runat="server" />
                <asp:DropDownList ID="FiltroDropDownList" CssClass="form-control" runat="server">
                    <asp:ListItem>Todo</asp:ListItem>
                    <asp:ListItem>PrestamoID</asp:ListItem>
                    <asp:ListItem>CuentaBancariaId</asp:ListItem>
                    <asp:ListItem>Capital</asp:ListItem>
                    <asp:ListItem>pInteres</asp:ListItem>
                    <asp:ListItem>CantMeses</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group col-md-3">
                <asp:Label ID="Label1" runat="server" ForeColor="#0099FF">Criterio:</asp:Label>
                <asp:TextBox ID="CriterioTextBox" AutoCompleteType="Disabled" class="form-control input-group" runat="server"></asp:TextBox>
            </div>

            <div class="col-sm-2">
                <br>
                <asp:Button ID="BtnBuscar" class="form-control btn btn-primary btn-sm" runat="server" Text="Buscar" OnClick="BtnBuscar_Click" />
            </div>
        </div>
        <div class="form-row justify-content-center">
            <div class="form-group col-md-2">
                <asp:Label Text="Desde" ForeColor="#0099FF" runat="server" />
                <asp:TextBox ID="DesdeTextBox" class="form-control input-group" TextMode="Date" runat="server" />
            </div>
            <div class="form-group col-md-2">
                <asp:Label Text="Hasta" ForeColor="#0099FF" runat="server" />
                <asp:TextBox ID="HastaTextBox" class="form-control input-group" TextMode="Date" runat="server" />
            </div>
        </div>
        <hr>

        <div class="form-row justify-content-center">
            <asp:GridView ID="PrestamoGridView" runat="server" class="table table-condensed table-bordered table-responsive" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="PrestamoGridView_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="LightSkyBlue" />
                <Columns>
                    <asp:BoundField DataField="PrestamoID" HeaderText="PrestamoID" />
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                    <asp:BoundField DataField="CuentaBancariaId" HeaderText="Cuenta Id" />
                    <asp:BoundField DataField="Capital" HeaderText="Capital" />
                    <asp:BoundField DataField="pInteres" HeaderText="pInteres" />
                    <asp:BoundField DataField="CantMeses" HeaderText="CantMeses" />
                </Columns>
                <HeaderStyle BackColor="LightCyan" Font-Bold="True" />
            </asp:GridView>
        </div>
        <hr>
        <div class="panel">
            <div class="text-center">
                <div class="form-group">
                    <asp:Button ID="ButtonImprimir" class="form-control btn btn-primary btn-sm" runat="server" Text="Imprimir Reporte" OnClick="ButtonImprimir_Click" />
                </div>
            </div>
        </div>
        <hr>
    </div>
</asp:Content>
