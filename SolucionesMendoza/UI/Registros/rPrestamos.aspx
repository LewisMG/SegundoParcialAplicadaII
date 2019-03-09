<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="rPrestamos.aspx.cs" Inherits="SolucionesMendoza.UI.Registros.rPrestamo" %>

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
                    <asp:Button ID="BuscarButton" runat="server" Text="Buscar" class="btn btn-primary btn-sm" ValidationGroup="Buscar" OnClick="BuscarButton_Click" />
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
                     <asp:TextBox type="Number" class="form-control" ID="CapitalTextBox" Placeholder="0" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="CapitalRequiredFieldValidator" runat="server" ErrorMessage="Ingrese solo numero!" ControlToValidate="CapitalTextBox" ValidationGroup="Guardar" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="CapitalRegularExpressionValidator" runat="server" ErrorMessage="Ingrese solo numeros!" ControlToValidate="CapitalTextBox" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                </div>
            </div>

            <div class="form-group row">
                <label class="control-label col-sm-2" for="InteresTextBox">Interes:</label>
                <div class="col-sm-1 col-md-4 col-xs6">
                    <asp:TextBox type="Number" class="form-control" ID="InteresTextBox" Placeholder="0" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="InteresRequiredFieldValidator" runat="server" ErrorMessage="Ingrese solo Numero!" ValidationGroup="Guardar" ControlToValidate="InteresTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="InteresRegularExpressionValidator" runat="server" ErrorMessage="Ingrese solo Numero!" ControlToValidate="InteresTextBox" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                </div>
            </div>

            <div class="form-group row">
                <label class="control-label col-sm-2" for="CantMesesTextBox">Meses:</label>
                <div class="col-sm-1 col-md-4 col-xs6">
                    <asp:TextBox type="Number" class="form-control" ID="CantMesesTextBox" Placeholder="0" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="CantMesesRequiredFieldValidator" runat="server" ErrorMessage="Ingrese solo numero!" ControlToValidate="CantMesesTextBox" ValidationGroup="Guardar" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="CantMesesRegularExpressionValidator" runat="server" ErrorMessage="Ingrese solo numeros!" ControlToValidate="CantMesesTextBox" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                </div>
                <div class="col-sm-1 col-md-4 col-xs6">
                    <asp:Button ID="ButtonAgregar" runat="server" Text="Calcular" class="btn btn-primary btn-sm" ValidationGroup="Calcular" OnClick="ButtonAgregar_Click" />
                </div>
            </div>
            <hr>
                <div class="row">
                        <asp:GridView ID="PrestamoGridView" runat="server" class="table table-condensed table-bordered table-responsive" AutoGenerateColumns="False" CellPadding="4" ForeColor="#0066FF" GridLines="None">
                            <AlternatingRowStyle BackColor="#999999" />
                            <Columns>
                                <asp:BoundField DataField="NoCuota" HeaderText="No. Cuota" />
                                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                                <asp:BoundField DataField="Interes" HeaderText="Interes" />
                                <asp:BoundField DataField="Capital" HeaderText="Capital" />
                                <asp:BoundField DataField="Balance" HeaderText="Balance" />
                            </Columns>
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                    </div>
            <hr>
            <hr>
            <div class="panel">
                <div class="text-center">
                    <div class="form-group">
                        <asp:Label ID="NombreLabel" runat="server" Text="Monto del Prestamo:"></asp:Label>
                        <asp:Label ID="MontoLabel" runat="server" Text=""></asp:Label>
                        </div>
                </div>
            </div>                
            <hr>
            <div class="panel">
                <div class="text-center">
                    <div class="form-group">
                        <asp:Button ID="BtnNuevo" runat="server" Text="Nuevo" class="btn btn-warning btn-sm" OnClick="BtnNuevo_Click" />
                        <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" class="btn btn-success btn-sm" ValidationGroup="Guardar" OnClick="BtnGuardar_Click" />
                        <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" class="btn btn-danger btn-sm" ValidationGroup="Buscar" OnClick="BtnEliminar_Click" />
                    </div>
                </div>
            </div>
            <hr>
        </div>
    </div>
</asp:Content>
