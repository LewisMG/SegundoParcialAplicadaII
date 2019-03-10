using BLL;
using Entidade;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SolucionesMendoza.UI.Reportes
{
    public partial class ListadoDePrestamos : System.Web.UI.Page
    {
        RepositorioBase<Prestamo> repositorio = new BLL.RepositorioBase<Prestamo>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PrestamoReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                PrestamoReportViewer.Reset();

                PrestamoReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\UI\Reportes\ListadoDePrestamos.rdlc");

                PrestamoReportViewer.LocalReport.DataSources.Clear();

                PrestamoReportViewer.LocalReport.DataSources.Add(new ReportDataSource("PrestamosDataSet", repositorio.GetList(x => true)));
                PrestamoReportViewer.LocalReport.Refresh();
            }
        }
    }
}