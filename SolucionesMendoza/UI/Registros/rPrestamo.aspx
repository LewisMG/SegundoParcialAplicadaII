<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="rPrestamo.aspx.cs" Inherits="SolucionesMendoza.UI.Registros.rPrestamo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <hr>
        <h2 style="color: #3366FF">Registro de Prestamo</h2>
        <hr>
        <div class="form-horizontal col-md-12" role="form">
            <div class="form-group row">
                <label class="control-label col-sm-2" for="PrestamoidTextBox">Prestamo ID:</label>
                <div class="col-sm-1 col-md-4 col-xs6">
                    <asp:TextBox type="Number" class="form-control" ID="PrestamoidTextBox" Text="0" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="PrestamoidRequiredFieldValidator" runat="server" ErrorMessage="Ingrese solo numero!" ControlToValidate="PrestamoidTextBox" ValidationGroup="Buscar" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="PrestamoidRegularExpressionValidator" runat="server" ErrorMessage="Ingrese solo numeros!" ControlToValidate="PrestamoidTextBox" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                </div>
                <div class="col-sm-1 col-md-4 col-xs6">
                    <asp:Button ID="BuscarButton" runat="server" Text="Buscar" class="btn btn-primary btn-sm" ValidationGroup="Buscar" />
                </div>
            </div>

            <div class="form-group row">
                <label class="control-label col-sm-2" for="FechaTextBox">Fecha:</label>
                <div class="col-sm-1 col-md-5">
                    <asp:TextBox ID="FechaTextBox" class="form-control input-group" TextMode="Date" runat="server" Enabled="true" ReadOnly="True" />
                </div>
            </div>
            <br>
            <div class="form-group row">
                <label class="control-label col-sm-2" for="Cuenta">Cuenta:</label>
                <div class="col-sm-1 col-md-5">
                    <asp:DropDownList class="form-control" ID="cuentaDropDownList" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
            <br>
            <div class="form-group row">
                <label class="control-label col-sm-2" for="CapitalTextBox">Capital:</label>
                <div class="col-sm-1 col-md-5">
                     <asp:TextBox type="Number" class="form-control" ID="CapitalTextBox" Text="0" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="CapitalRequiredFieldValidator" runat="server" ErrorMessage="Ingrese solo numero!" ControlToValidate="CapitalTextBox" ValidationGroup="Guardar" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="CapitalRegularExpressionValidator" runat="server" ErrorMessage="Ingrese solo numeros!" ControlToValidate="CapitalTextBox" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                </div>
            </div>

            <div class="form-group row">
                <label class="control-label col-sm-2" for="InteresTextBox">Interes:</label>
                <div class="col-sm-1 col-md-4 col-xs6">
                    <asp:TextBox type="Number" class="form-control" ID="InteresTextBox" Text="0" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="InteresRequiredFieldValidator" runat="server" ErrorMessage="Ingrese solo Numero!" ValidationGroup="Guardar" ControlToValidate="InteresTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="InteresRegularExpressionValidator" runat="server" ErrorMessage="Ingrese solo Numero!" ControlToValidate="InteresTextBox" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                </div>
            </div>

            <div class="form-group row">
                <label class="control-label col-sm-2" for="CantMesesTextBox">Meses:</label>
                <div class="col-sm-1 col-md-4 col-xs6">
                    <asp:TextBox type="Number" class="form-control" ID="CantMesesTextBox" Text="0" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="CantMesesRequiredFieldValidator" runat="server" ErrorMessage="Ingrese solo numero!" ControlToValidate="CantMesesTextBox" ValidationGroup="Guardar" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="CantMesesRegularExpressionValidator" runat="server" ErrorMessage="Ingrese solo numeros!" ControlToValidate="CantMesesTextBox" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                </div>
                <div class="col-sm-1 col-md-4 col-xs6">
                    <asp:Button ID="ButtonAgregar" runat="server" Text="Calcular" class="btn btn-primary btn-sm" ValidationGroup="Calcular" />
                </div>
            </div>

            <hr>
            <div class="panel">
                <div class="text-center">
                    <div class="form-group">
                        <asp:Button ID="BtnNuevo" runat="server" Text="Nuevo" class="btn btn-warning btn-sm" />
                        <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" class="btn btn-success btn-sm" ValidationGroup="Guardar" />
                        <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" class="btn btn-danger btn-sm" ValidationGroup="Buscar" />
                    </div>
                </div>
            </div>
            <hr>
        </div>
    </div>
</asp:Content>
