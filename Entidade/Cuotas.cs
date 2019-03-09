using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidade
{
    [Serializable]
    public class Cuotas
    {
        [Key]
        public int CuotaID { get; set; }
        public DateTime Fecha { get; set; }
        public int PrestamoID { get; set; }
        public int NoCuota { get; set; }
        public int CuentaBancariaId { get; set; }
        public double Interes { get; set; }
        public double Capital { get; set; }
        public double Balance { get; set; }

        [ForeignKey("CuentaBancariaId")]
        public virtual CuentasBancarias CuentasBancarias { get; set; }

        public Cuotas()
        {
            CuotaID = 0;
            Fecha = DateTime.Now;
            PrestamoID = 0;
            NoCuota = 0;
            CuentaBancariaId = 0;
            Interes = 0;
            Capital = 0;
            Balance = 0;
        }

        public Cuotas(int cuotaID, DateTime fecha, int prestamoID, int noCuota, int cuentaBancariaId, double interes, double capital, double balance)
        {
            CuotaID = cuotaID;
            Fecha = fecha;
            PrestamoID = prestamoID;
            NoCuota = noCuota;
            CuentaBancariaId = cuentaBancariaId;
            Interes = interes;
            Capital = capital;
            Balance = balance;
        }
    }
}
