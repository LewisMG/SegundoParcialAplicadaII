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
    public partial class ListadodeDepositos : System.Web.UI.Page
    {
        RepositorioBase<Depositos> repositorio = new BLL.RepositorioBase<Depositos>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DepositosReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                DepositosReportViewer.Reset();

                DepositosReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\UI\Reportes\ListadoDeDepositos.rdlc");

                DepositosReportViewer.LocalReport.DataSources.Clear();

                DepositosReportViewer.LocalReport.DataSources.Add(new ReportDataSource("DepositosDataSet", repositorio.GetList(x => true)));
                DepositosReportViewer.LocalReport.Refresh();
            }
        }
    }
}