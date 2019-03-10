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
        Expression<Func<Depositos, bool>> filtro = p => true;
        protected void Page_Load(object sender, EventArgs e)
        {
            DepositosReportViewer.ProcessingMode = ProcessingMode.Local;
            DepositosReportViewer.Reset();
            DepositosReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\UI\Reportes\ListadoDeDepositos.rdlc");
            DepositosReportViewer.LocalReport.DataSources.Clear();
            DepositosReportViewer.LocalReport.DataSources.Add(new ReportDataSource("DepositosDataSet", GetDepositos(filtro)));
            DepositosReportViewer.LocalReport.Refresh();
        }

        public List<Depositos> GetDepositos(Expression<Func<Depositos, bool>> filtro)
        {
            filtro = p => true;
            RepositorioBase<Depositos> repositorio = new RepositorioBase<Depositos>();
            List<Depositos> listDepositos = new List<Depositos>();

            listDepositos = repositorio.GetList(filtro);

            return listDepositos;
        }
    }
}