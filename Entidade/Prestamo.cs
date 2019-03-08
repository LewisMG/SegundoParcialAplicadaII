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
        public DateTime Feha { get; set; }
        public int CuentaBancariaId { get; set; }
        public int Capital { get; set; }
        public decimal pInteres { get; set; }
        public int CantMeses { get; set; }
        public int MontoTotal { get; set; }

        public virtual List<Cuotas> Detalle { get; set; }

        public Prestamo()
        {
            this.Detalle = new List<Cuotas>();
        }

        public void AgregarDetalle(int CuotaID, DateTime Fecha, int CuentaBancariaId, double Interes, double Capital, double Balance)
        {
            this.Detalle.Add(new Cuotas(CuotaID, Fecha, CuentaBancariaId, Interes, Capital, Balance));
        }
    }
}
