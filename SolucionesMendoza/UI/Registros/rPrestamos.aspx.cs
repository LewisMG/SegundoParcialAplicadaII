using BLL;
using Entidade;
using SolucionesMendoza.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SolucionesMendoza.UI.Registros
{
    public partial class rPrestamo : System.Web.UI.Page
    {
        List<Cuotas> ListaDetalle = new List<Cuotas>();
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!Page.IsPostBack)
            {
                PrestamoGridView.DataSource = null;
                PrestamoGridView.DataBind();
                LlenarDropDownList();
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                PrestamoidTextBox.Text = "0";
                MontoLabel.Text = "0";
                ViewState["Prestamo"] = new Prestamo();
            }
        }

        public void LlenarCampos(Prestamo prestamo)
        {
            LimpiarCampos();
            PrestamoidTextBox.Text = prestamo.PrestamoID.ToString();
            FechaTextBox.Text = prestamo.Fecha.ToString("yyyy-MM-dd");
            cuentaDropDownList.Text = Convert.ToString(prestamo.CuentaBancariaId);
            CapitalTextBox.Text = prestamo.Capital.ToString();
            InteresTextBox.Text = prestamo.pInteres.ToString();
            CantMesesTextBox.Text = prestamo.CantMeses.ToString();
            MontoLabel.Text = prestamo.MontoTotal.ToString();
            PrestamoGridView.DataSource = prestamo.Detalle.ToList();
            this.BindGrid();
        }

        private Prestamo LlenaClase()
        {
            Prestamo prestamo = new Prestamo();

            prestamo.PrestamoID = Utils.ToInt(PrestamoidTextBox.Text);
            prestamo.Fecha = Utils.ToDateTime(FechaTextBox.Text);
            prestamo.CuentaBancariaId = Utils.ToInt(cuentaDropDownList.Text);
            prestamo.Capital = Utils.ToInt(CapitalTextBox.Text);
            prestamo.pInteres = Utils.ToInt(InteresTextBox.Text);
            prestamo.CantMeses = Utils.ToInt(CantMesesTextBox.Text);
            prestamo.MontoTotal = Utils.ToInt(MontoLabel.Text);
            prestamo.Detalle = ListaDetalle;

            return prestamo;
        }

        private void LimpiarCampos()
        {
            PrestamoidTextBox.Text = "0";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            cuentaDropDownList.SelectedIndex = 0;
            CapitalTextBox.Text = "";
            InteresTextBox.Text = "";
            CantMesesTextBox.Text = "";
            MontoLabel.Text = "0";
            ViewState["Prestamo"] = new Prestamo();
            this.BindGrid();
        }

        private void LlenarDropDownList()
        {
            RepositorioBase<CuentasBancarias> cuentas = new RepositorioBase<CuentasBancarias>();
            cuentaDropDownList.Items.Clear();
            cuentaDropDownList.DataSource = cuentas.GetList(x => true);
            cuentaDropDownList.DataValueField = "CuentaBancariaId";
            cuentaDropDownList.DataTextField = "Nombre";
            cuentaDropDownList.DataBind();

            ViewState["Prestamo"] = new Prestamo();
        }

        protected void BindGrid()
        {
            PrestamoGridView.DataSource = ((Prestamo)ViewState["Prestamo"]).Detalle;
            PrestamoGridView.DataBind();
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Prestamo> repositorio = new RepositorioBase<Prestamo>();
            Prestamo prestamo = repositorio.Buscar(Utils.ToInt(PrestamoidTextBox.Text));

            if (prestamo != null)
            {
                LlenarCampos(prestamo);

                Utils.ShowToastr(this, "Encontrado!!", "Exito", "info");
            }
            else
            {
                Utils.ShowToastr(this, "No Hay Resultado", "Error", "error");
            }
            if (Utils.ToInt(PrestamoidTextBox.Text) == 0)
            {
                Utils.ShowToastr(this, "Id No Puede Ser Cero", "Error", "error");
            }
        }

        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            Prestamo Presta = new Prestamo();
            if (Utils.ToInt(CapitalTextBox.Text) <= 0 || Utils.ToInt(InteresTextBox.Text) <= 0 || Utils.ToInt(CantMesesTextBox.Text) <= 0)
            {
                Utils.ShowToastr(this, "LLene los campos vacios(Capital, Interes y Meses)", "Error", "error");                
            }
            else
            {
                double capital = Convert.ToDouble(CapitalTextBox.Text);
                double interes = Convert.ToDouble(InteresTextBox.Text) / 100;
                int plazo = Utils.ToInt(CantMesesTextBox.Text);
                double interesMensual = (interes * capital) / plazo;
                double Balance = 0;
                DateTime Fecha = DateTime.Now.Date;
                double cuota = capital / plazo;
                double interesTotal = interesMensual * plazo;
                Balance = capital + interesTotal;
                int i = 1;
                for (i = 1; i <= plazo; i++)
                {
                    Balance -= (cuota + interesMensual);

                    Presta = (Prestamo)ViewState["Prestamo"];
                    Presta.AgregarDetalle(0, Fecha.AddMonths(i), 1, i, Utils.ToInt(cuentaDropDownList.SelectedValue), interesMensual, cuota, Balance);

                    ViewState["Prestamo"] = Presta;

                    this.BindGrid();
                }
                double resultado = capital + (interesMensual * plazo);
                MontoLabel.Text = resultado.ToString();
            }
        }

        protected void BtnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }


        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            PrestamoRepositorio repositorio = new PrestamoRepositorio();
            Prestamo prestamo = LlenaClase();
            RepositorioBase<CuentasBancarias> cuentas = new RepositorioBase<CuentasBancarias>();

            bool paso = false;

            if (cuentaDropDownList != null)
            {

                if (Page.IsValid)
                {
                    if (PrestamoidTextBox.Text == "0" && Utils.ToInt(MontoLabel.Text) != 0)
                    {
                        paso = repositorio.Guardar(prestamo);
                    }
                    else if(Utils.ToInt(MontoLabel.Text) == 0)
                    {
                        Utils.ShowToastr(this, "Presionar Boton Calcular Antes de Guardar ", "Fallo", "error");
                    }
                    else if (Utils.ToInt(PrestamoidTextBox.Text) != 0)
                    {
                        var verificar = repositorio.Buscar(Utils.ToInt(PrestamoidTextBox.Text));
                        if (verificar != null)
                        {
                            paso = repositorio.Modificar(prestamo);
                        }
                        else
                        {
                            Utils.ShowToastr(this, "No se encuentra el ID", "Fallo", "error");
                            return;
                        }
                    }
                    if (paso)
                    {
                        Utils.ShowToastr(this, "Registro Con Exito", "Exito", "success");
                    }
                    else
                    {
                        Utils.ShowToastr(this, "No se pudo Guardar", "Fallo", "error");
                    }
                    LimpiarCampos();
                    return;
                }
            }
            else
            {
                Utils.ShowToastr(this, "El numero de cuenta no existe", "Fallo", "error");
                return;
            }
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Prestamo> repositorio = new RepositorioBase<Prestamo>();
            int id = Utils.ToInt(PrestamoidTextBox.Text);

            var CuentasBancarias = repositorio.Buscar(id);

            if (CuentasBancarias != null)
            {
                if (repositorio.Eliminar(id))
                {
                    Utils.ShowToastr(this, "Eliminado Exitosamente!!", "Exito", "info");
                    LimpiarCampos();
                }
                else
                    Utils.ShowToastr(this, "Fallo!! No se Puede Eliminar", "Error", "error");
            }
            else
                Utils.ShowToastr(this, "No Encontrado!!", "Error", "error");
            if (Utils.ToInt(PrestamoidTextBox.Text) == 0)
            {
                Utils.ShowToastr(this, "Id No Puede Ser Cero", "Error", "error");
            }
        }
    }
}