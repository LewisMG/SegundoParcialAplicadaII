using BLL;
using Entidade;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SolucionesMendoza.UI.Reportes
{
    public partial class ListadoDeCuentas : System.Web.UI.Page
    {
        Expression<Func<CuentasBancarias, bool>> filtro = p => true;
        protected void Page_Load(object sender, EventArgs e)
        {
            CuentasReportViewer.ProcessingMode = ProcessingMode.Local;
            CuentasReportViewer.Reset();
            CuentasReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\UI\Reportes\ListadoDeCuentas.rdlc");
            CuentasReportViewer.LocalReport.DataSources.Clear();
            CuentasReportViewer.LocalReport.DataSources.Add(new ReportDataSource("CuentasDataSet", GetCuentas(filtro)));
            CuentasReportViewer.LocalReport.Refresh();
        }

        public List<CuentasBancarias> GetCuentas(Expression<Func<CuentasBancarias, bool>> filtro)
        {
            filtro = p => true;
            RepositorioBase<CuentasBancarias> repositorio = new RepositorioBase<CuentasBancarias>();
            List<CuentasBancarias> listCuentas = new List<CuentasBancarias>();

            listCuentas = repositorio.GetList(filtro);

            return listCuentas;
        }
    }    
}