<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="cCuentasBancarias.aspx.cs" Inherits="SolucionesMendoza.UI.Consultas.cCuentasBancarias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="jumbotron" style="background-color: #E0FFFF">
        <hr>
        <h5 class="display-4" style="color: #0099FF; font-weight: bold;">Consulta de Cuentas</h5>
        <hr>
        <div class="form-row justify-content-center">
            <div class="form-group col-md-2">
                <asp:Label Text="Filtro" ForeColor="#0099FF" runat="server" />
                <asp:DropDownList ID="FiltroDropDownList" CssClass="form-control" runat="server">
                    <asp:ListItem>Todo</asp:ListItem>
                    <asp:ListItem>Todo por Fecha</asp:ListItem>
                    <asp:ListItem>CuentaId</asp:ListItem>
                    <asp:ListItem>Nombre</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group col-md-3">
                <asp:Label ID="Label1" runat="server" ForeColor="#0099FF">Criterio:</asp:Label>
                <asp:TextBox ID="CriterioTextBox" AutoCompleteType="Disabled" class="form-control input-group" runat="server"></asp:TextBox>
            </div>

            <div class="col-sm-2">
                <br>
                <asp:Button ID="BtnBuscar" class="form-control btn btn-primary btn-sm" runat="server" Text="Buscar" />
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
            <asp:GridView ID="CBGridView" runat="server" class="table table-condensed table-bordered table-responsive" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="LightSkyBlue" />
                <Columns>
                    <asp:BoundField DataField="CuentaBancariaId" HeaderText="Cuenta Id" />
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Balance" HeaderText="Balance" />
                </Columns>
                <HeaderStyle BackColor="LightCyan" Font-Bold="True" />
            </asp:GridView>
        </div>
        <hr>
    </div>
</asp:Content>
