using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidade
{
    public class Cuotas
    {
        public int CuotaID { get; set; }
        public DateTime Fecha { get; set; }
        public int CuentaBancariaId { get; set; }
        public double Interes { get; set; }
        public double CapitalMensual { get; set; }
        public double Balance { get; set; }

        [ForeignKey("CuentaBancariaId")]
        public virtual CuentasBancarias CuentasBancarias { get; set; }

        public Cuotas()
        {
            CuotaID = 0;
            Fecha = DateTime.Now;
            CuentaBancariaId = 0;
            Interes = 0;
            CapitalMensual = 0;
            Balance = 0;
        }

        public Cuotas(int cuotaID, DateTime fecha, int cuentaBancariaId, double interes, double capitalMensual, double balance)
        {
            CuotaID = cuotaID;
            Fecha = fecha;
            CuentaBancariaId = cuentaBancariaId;
            Interes = interes;
            CapitalMensual = capitalMensual;
            Balance = balance;
        }
    }
}
