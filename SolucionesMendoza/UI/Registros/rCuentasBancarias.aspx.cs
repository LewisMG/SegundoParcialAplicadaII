using BLL;
using Entidade;
using SolucionesMendoza.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SolucionesMendoza.UI.Registros
{
    public partial class rCuentasBancarias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void LimpiarCampos()
        {
            CBTextBox.Text = "0";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            NombreTextBox.Text = "";
            BalanceTextBox.Text = "0";
        }

        private void LlenaCampos(CuentasBancarias cuentas)
        {
            CBTextBox.Text = cuentas.CuentaBancariaId.ToString();
            NombreTextBox.Text = cuentas.Nombre;
            BalanceTextBox.Text = cuentas.Balance.ToString();
        }

        private CuentasBancarias LlenaClase()
        {
            CuentasBancarias cb = new CuentasBancarias();

            cb.CuentaBancariaId = Utils.ToInt(CBTextBox.Text);
            cb.Fecha = Convert.ToDateTime(FechaTextBox.Text).Date;
            cb.Nombre = NombreTextBox.Text;
            cb.Balance = Utils.ToInt(BalanceTextBox.Text);

            return cb;
        }

        protected void BtnNuevo_Click1(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        protected void BtnGuardar_Click1(object sender, EventArgs e)
        {
            RepositorioBase<CuentasBancarias> repositorio = new RepositorioBase<CuentasBancarias>();
            CuentasBancarias cuentasbancarias = new CuentasBancarias();
            bool paso = false;

            cuentasbancarias = LlenaClase();

            if (cuentasbancarias.CuentaBancariaId == 0)
            {
                paso = repositorio.Guardar(cuentasbancarias);
                Utils.ShowToastr(this, "Guardado Exitosamente!!", "Exito", "success");
                LimpiarCampos();
            }
            else
            {
                CuentasBancarias user = new CuentasBancarias();
                int id = Utils.ToInt(CBTextBox.Text);
                RepositorioBase<CuentasBancarias> repository = new RepositorioBase<CuentasBancarias>();
                cuentasbancarias = repository.Buscar(id);

                if (user != null)
                {
                    paso = repositorio.Modificar(LlenaClase());
                    Utils.ShowToastr(this, "Modificado Exitosamente!!", "Exito", "success");
                }
                else
                    Utils.ShowToastr(this, "No Encontrado!!", "Error", "error");
            }

            if (paso)
            {
                LimpiarCampos();
            }
            else
                Utils.ShowToastr(this, "Fallo!! no ha podido Guardar", "Error", "error");
        }

        protected void BtnEliminar_Click1(object sender, EventArgs e)
        {
            RepositorioBase<CuentasBancarias> repositorio = new RepositorioBase<CuentasBancarias>();
            int id = Utils.ToInt(CBTextBox.Text);

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
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            RepositorioBase<CuentasBancarias> repositorio = new RepositorioBase<CuentasBancarias>();
            CuentasBancarias Cb = repositorio.Buscar(Utils.ToInt(CBTextBox.Text));

            if (Cb != null)
            {
                LlenaCampos(Cb);

                Utils.ShowToastr(this, "Encontrado!!", "Exito", "info");
            }
            else
            {
                Utils.ShowToastr(this, "No Hay Resultado", "Error", "error");
            }
            if (Utils.ToInt(CBTextBox.Text) == 0)
            {
                Utils.ShowToastr(this, "Id No Puede Ser Cero", "Error", "error");
            }

        }

    }
}