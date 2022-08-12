using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class ReclutadorDALImpl : IReclutadorDAL
    {

        WorknetContext context;

        public ReclutadorDALImpl()
        {
            context = new WorknetContext();

        }
        public bool Add(Reclutador entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Reclutador> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reclutador> Find(Expression<Func<Reclutador, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Reclutador Get(string correo)
        {
            try
            {
                Reclutador reclutador;
                using (UnidadDeTrabajoU<Reclutador> unidad = new UnidadDeTrabajoU<Reclutador>(context))
                {
                    reclutador = unidad.genericDAL.Get(correo);
                }
                return reclutador;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Reclutador> GetAll()
        {
            try
            {
                IEnumerable<Reclutador> reclutadores;
                using (UnidadDeTrabajo<Reclutador> unidad = new UnidadDeTrabajo<Reclutador>(context))
                {
                    reclutadores = unidad.genericDAL.GetAll();
                }
                return reclutadores;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Reclutador entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Reclutador> unidad = new UnidadDeTrabajo<Reclutador>(context))
                {
                    unidad.genericDAL.Remove(entity);
                    result = unidad.Complete();
                }

            }
            catch (Exception)
            {

                result = false;
            }

            return result;
        }

        public void RemoveRange(IEnumerable<Reclutador> entities)
        {
            throw new NotImplementedException();
        }

        public Reclutador SingleOrDefault(Expression<Func<Reclutador, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Reclutador entity)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Reclutador> unidad = new UnidadDeTrabajo<Reclutador>(context))
                {
                    unidad.genericDAL.Update(entity);
                    result = unidad.Complete();
                }

            }
            catch (Exception)
            {

                return false;
            }

            return result;
        }
    }
}
