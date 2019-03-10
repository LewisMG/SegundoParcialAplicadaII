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
        RepositorioBase<CuentasBancarias> repositorio = new BLL.RepositorioBase<CuentasBancarias>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CuentasReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                CuentasReportViewer.Reset();

                CuentasReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\UI\Reportes\ListadoDeCuentas.rdlc");

                CuentasReportViewer.LocalReport.DataSources.Clear();

                CuentasReportViewer.LocalReport.DataSources.Add(new ReportDataSource("CuentasDataSet", repositorio.GetList(x => true)));
                CuentasReportViewer.LocalReport.Refresh();
            }
        }
    }    
}