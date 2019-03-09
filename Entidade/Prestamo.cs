using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidade
{
    [Serializable]
    public class Prestamo
    {
        public int PrestamoID { get; set; }
        public DateTime Fecha { get; set; }
        public int CuentaBancariaId { get; set; }
        public int Capital { get; set; }
        public double pInteres { get; set; }
        public int CantMeses { get; set; }
        public int MontoTotal { get; set; }

        public virtual List<Cuotas> Detalle { get; set; }

        public Prestamo()
        {
            this.Detalle = new List<Cuotas>();
        }

        public void AgregarDetalle(int CuotaID, DateTime Fecha, int PrestamoID, int NoCuotas, int CuentaBancariaId, double Interes, double Capital, double Balance)
        {
            this.Detalle.Add(new Cuotas(CuotaID, Fecha, PrestamoID, NoCuotas, CuentaBancariaId, Interes, Capital, Balance));
        }
    }
}
