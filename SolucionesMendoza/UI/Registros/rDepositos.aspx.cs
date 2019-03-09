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
    public partial class rDepositos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LlenarDropDownList();
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                DepositoidTextBox.Text = "0";
            }
        }

        private void LimpiarCampos()
        {
            DepositoidTextBox.Text = "0";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            cuentaDropDownList.SelectedIndex = 0;
            ConceptoTextBox.Text = "";
            MontoTextBox.Text = "0";
        }

        public void LlenarCampos(Depositos depositos)
        {
            LimpiarCampos();
            DepositoidTextBox.Text = depositos.DepositoId.ToString();
            FechaTextBox.Text = depositos.Fecha.ToString("yyyy-MM-dd");
            cuentaDropDownList.Text = Convert.ToString(depositos.CuentaId);
            ConceptoTextBox.Text = depositos.Concepto;
            MontoTextBox.Text = depositos.Monto.ToString();
        }

        private void LlenarDropDownList()
        {
            RepositorioBase<CuentasBancarias> cuentas = new RepositorioBase<CuentasBancarias>();
            cuentaDropDownList.Items.Clear();
            cuentaDropDownList.DataSource = cuentas.GetList(x => true);
            cuentaDropDownList.DataValueField = "CuentaBancariaId";
            cuentaDropDownList.DataTextField = "Nombre";
            cuentaDropDownList.DataBind();
        }

        private Depositos LlenaClase()
        {
            Depositos depositos = new Depositos();

            depositos.DepositoId = Utils.ToInt(DepositoidTextBox.Text);
            depositos.Fecha = Utils.ToDateTime(FechaTextBox.Text);
            depositos.CuentaId = Utils.ToInt(cuentaDropDownList.Text);
            depositos.Concepto = ConceptoTextBox.Text;
            depositos.Monto = Utils.ToInt(MontoTextBox.Text);

            return depositos;
        }
        
        protected void BuscarButton_Click1(object sender, EventArgs e)
        {
            RepositorioBase<Depositos> repositorio = new RepositorioBase<Depositos>();
            Depositos depositos = repositorio.Buscar(Utils.ToInt(DepositoidTextBox.Text));

            if (depositos != null)
            {
                LlenarCampos(depositos);

                Utils.ShowToastr(this, "Encontrado!!", "Exito", "info");
            }
            else
            {
                Utils.ShowToastr(this, "No Hay Resultado", "Error", "error");
            }
            if (Utils.ToInt(DepositoidTextBox.Text) == 0)
            {
                Utils.ShowToastr(this, "Id No Puede Ser Cero", "Error", "error");
            }
        }

        protected void BtnNuevo_Click1(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private bool Verificar()
        {
            bool paso = false;
            bool resultado = Regex.IsMatch(ConceptoTextBox.Text, @"^[a-z A-Z]+$");
            if (!resultado)
            {
                resultado = Regex.IsMatch(ConceptoTextBox.Text, @"^[a-z A-Z]+$");
                if (resultado)
                {
                    paso = false;
                }
                else
                {
                    paso = true;
                    Utils.ShowToastr(this, "Solo Letras", "Fallo", "error");
                }
                Utils.ShowToastr(this, "Solo Letras", "Fallo", "error");
                paso = true;
            }
            return paso;
        }

        protected void BtnGuardar_Click1(object sender, EventArgs e)
        {
            DepositoRepositorio repositorio = new DepositoRepositorio();
            Depositos depositos = LlenaClase();
            RepositorioBase<CuentasBancarias> cuentas = new RepositorioBase<CuentasBancarias>();
            
            bool paso = false;

            if (Verificar())
            {
                Utils.ShowToastr(this, "Solo Letras!", "Error", "error");
                return;
            }

            if (cuentaDropDownList != null)
            {

                if (Page.IsValid)
                {
                    if (DepositoidTextBox.Text == "0")
                    {
                        paso = repositorio.Guardar(depositos);
                    }
                    else
                    {
                        var verificar = repositorio.Buscar(Utils.ToInt(DepositoidTextBox.Text));
                        if (verificar != null)
                        {
                            paso = repositorio.Modificar(depositos);
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

        protected void BtnEliminar_Click1(object sender, EventArgs e)
        {
            RepositorioBase<Depositos> repositorio = new RepositorioBase<Depositos>();
            int id = Utils.ToInt(DepositoidTextBox.Text);

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
            if (Utils.ToInt(DepositoidTextBox.Text) == 0)
            {
                Utils.ShowToastr(this, "Id No Puede Ser Cero", "Error", "error");
            }
        }
    }
}