using DAL;
using Entidade;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PrestamoRepositorio : RepositorioBase<Prestamo>
    {
        public bool Guardar(Prestamo entity)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.prestamos.Add(entity) != null)
                {

                    var cuenta = contexto.cuentasBancarias.Find(entity.CuentaBancariaId);
                    //Incrementar el balance
                    cuenta.Balance += entity.MontoTotal;

                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();

            }
            catch (Exception) { throw; }

            return paso;
        }

        public bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                Prestamo prestamo = contexto.prestamos.Find(id);

                if (prestamo != null)
                {
                    var cuenta = contexto.cuentasBancarias.Find(prestamo.CuentaBancariaId);
                    //Incrementar la cantidad
                    cuenta.Balance -= prestamo.MontoTotal;
                    contexto.Entry(prestamo).State = EntityState.Deleted;
                }

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                    contexto.Dispose();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }


        public override bool Modificar(Prestamo entity)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            RepositorioBase<Prestamo> repositorio = new RepositorioBase<Prestamo>();
            try
            {

                //Buscar

                var prestamoAnterior = repositorio.Buscar(entity.PrestamoID);

                var Cuenta = contexto.cuentasBancarias.Find(entity.CuentaBancariaId);
                var Cuentasanterior = contexto.cuentasBancarias.Find(prestamoAnterior.CuentaBancariaId);

                if (entity.CuentaBancariaId != prestamoAnterior.CuentaBancariaId)
                {
                    Cuenta.Balance += entity.MontoTotal;
                    Cuentasanterior.Balance -= prestamoAnterior.MontoTotal;
                }

                //identificar la diferencia ya sea restada o sumada
                int diferencia;
                diferencia = entity.MontoTotal - prestamoAnterior.MontoTotal;

                //aplicar diferencia al inventario 
                Cuenta.Balance += diferencia;

                contexto.Entry(entity).State = EntityState.Modified;

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();

            }
            catch (Exception) { throw; }

            return paso;
        }
    }
}

