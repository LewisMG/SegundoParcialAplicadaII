<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="rCuentasBancarias.aspx.cs" Inherits="SolucionesMendoza.UI.Registros.rCuentasBancarias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <hr>
        <h2 style="color: #3366FF">Registro Cuenta Bancaria</h2>
        <hr>
        <div class="form-horizontal col-md-12" role="form">
            <div class="form-group row">
                <label class="control-label col-sm-2" for="CBTextBox">Id:</label>
                <div class="col-sm-1 col-md-4 col-xs6">
                    <asp:TextBox type="Number" class="form-control" ID="CBTextBox" Text="0" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="CBTextBoxRequiredFieldValidator" runat="server" ErrorMessage="Ingrese solo numero!" ControlToValidate="CBTextBox" ValidationGroup="Buscar" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="CBTextBoxRegularExpressionValidator" runat="server" ErrorMessage="Ingrese solo numeros!" ControlToValidate="CBTextBox" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                </div>
                <div class="col-sm-1 col-md-4 col-xs6">
                    <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" class="btn btn-primary btn-sm" ValidationGroup="Buscar" OnClick="BtnBuscar_Click" />
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
                <label class="control-label col-sm-2" for="NombreTextBox">Nombre:</label>
                <div class="col-sm-1 col-md-5">
                    <asp:TextBox type="text" class="form-control" ID="NombreTextBox" placeholder="Ingrese Nombres" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="NombreRequiredFieldValidator" runat="server" ErrorMessage="Ingrese algun nombre!" ValidationGroup="guardar" ControlToValidate="NombreTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red" SetFocusOnError="True" ToolTip="Campo Descripcion obligatorio&quot;&gt;Por favor llenar el campo Nombre">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="NombreRegularExpressionValidator" runat="server" ErrorMessage="Ingrese algun nombre!" ControlToValidate="NombreTextBox" ValidationExpression="(^[a-zA-Z'.\s]{1,20}$)" SetFocusOnError="True"></asp:RegularExpressionValidator>
                </div>
            </div>

            <div class="form-group row">
                <label class="control-label col-sm-2" for="BalanceTextBox">Balance:</label>
                <div class="col-sm-1 col-md-4 col-xs6">
                    <asp:TextBox type="Number" class="form-control" ID="BalanceTextBox" Text="0" runat="server" ReadOnly="True"></asp:TextBox>
                </div>
            </div>
            <hr>
            <div class="panel">
                <div class="text-center">
                    <div class="form-group">
                        <asp:Button ID="BtnNuevo" runat="server" Text="Nuevo" class="btn btn-warning btn-sm" OnClick="BtnNuevo_Click1" />
                        <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" class="btn btn-success btn-sm" ValidationGroup="guardar" OnClick="BtnGuardar_Click1" />
                        <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" class="btn btn-danger btn-sm" ValidationGroup="Buscar" OnClick="BtnEliminar_Click1" />
                    </div>
                </div>
            </div>
            <hr>
        </div>
    </div>
</asp:Content>
