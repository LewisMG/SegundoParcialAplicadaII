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
    public class DepositoRepositorio : RepositorioBase<Depositos>
    {
        public bool Guardar(Depositos entity)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                if (contexto.depositos.Add(entity) != null)
                {

                    var cuenta = contexto.cuentasBancarias.Find(entity.CuentaId);
                    //Incrementar el balance
                    cuenta.Balance += entity.Monto;


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
                Depositos depositos = contexto.depositos.Find(id);

                if (depositos != null)
                {
                    var cuenta = contexto.cuentasBancarias.Find(depositos.CuentaId);
                    //Incrementar la cantidad
                    cuenta.Balance -= depositos.Monto;
                    contexto.Entry(depositos).State = EntityState.Deleted;
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


        public override bool Modificar(Depositos entity)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            RepositorioBase<Depositos> repositorio = new RepositorioBase<Depositos>();
            try
            {

                //Buscar

                var depositosanterior = repositorio.Buscar(entity.DepositoId);

                var Cuenta = contexto.cuentasBancarias.Find(entity.CuentaId);
                var Cuentasanterior = contexto.cuentasBancarias.Find(depositosanterior.CuentaId);

                if (entity.CuentaId != depositosanterior.CuentaId)
                {
                    Cuenta.Balance += entity.Monto;
                    Cuentasanterior.Balance -= depositosanterior.Monto;
                }

                //identificar la diferencia ya sea restada o sumada
                int diferencia;
                diferencia = entity.Monto - depositosanterior.Monto;

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
