using Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Metodos
    {
        public static int ToInt(string valor)
        {
            int retorno = 0;
            int.TryParse(valor, out retorno);

            return retorno;
        }

        public static List<CuentasBancarias> FiltrarCuentas(int index, string criterio, DateTime desde, DateTime hasta)
        {
            Expression<Func<CuentasBancarias, bool>> filtro = p => true;
            RepositorioBase<CuentasBancarias> repositorio = new RepositorioBase<CuentasBancarias>();
            List<CuentasBancarias> list = new List<CuentasBancarias>();

            int id = ToInt(criterio);
            switch (index)
            {
                case 0://Todo
                    break;

                case 1://Todo por fecha
                    filtro = p => p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 2://CuentaId
                    filtro = p => p.CuentaBancariaId == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 3://Nombre
                    filtro = p => p.Nombre.Contains(criterio) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
            }

            list = repositorio.GetList(filtro);

            return list;
        }

        public static List<Depositos> FiltrarDepositos(int index, string criterio, DateTime desde, DateTime hasta)
        {
            Expression<Func<Depositos, bool>> filtro = p => true;
            RepositorioBase<Depositos> repositorio = new RepositorioBase<Depositos>();
            List<Depositos> list = new List<Depositos>();

            int id = ToInt(criterio);
            switch (index)
            {
                case 0://Todo
                    break;

                case 1://Todo por fecha
                    filtro = p => p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 2://DepositoId
                    filtro = p => p.DepositoId == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 3://CuentaId
                    filtro = p => p.CuentaId == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 4://Nombre
                    filtro = p => p.Concepto.Contains(criterio) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
            }

            list = repositorio.GetList(filtro);

            return list;
        }
    }
}
