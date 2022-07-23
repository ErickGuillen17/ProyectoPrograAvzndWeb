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
            try
            {

                using (UnidadDeTrabajoU<Reclutador> unidad = new UnidadDeTrabajoU<Reclutador>(context))
                {
                    unidad.genericDAL.Add(entity);
                    return unidad.Complete();
                }

            }
            catch (Exception)
            {

                return false;
            }
        }

        public void AddRange(IEnumerable<Reclutador> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reclutador> Find(Expression<Func<Reclutador, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Reclutador Get(string id)
        {
            try
            {
                Reclutador reclutador;
                using (UnidadDeTrabajoU<Reclutador> unidad = new UnidadDeTrabajoU<Reclutador>(context))
                {
                    reclutador = unidad.genericDAL.Get(id);
                }
                return reclutador;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Reclutador> Get()
        {
            try
            {
                IEnumerable<Reclutador> reclutador;
                using (UnidadDeTrabajoU<Reclutador> unidad = new UnidadDeTrabajoU<Reclutador>(context))
                {
                    reclutador = unidad.genericDAL.GetAll();
                }
                return reclutador.ToList();
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
                IEnumerable<Reclutador> reclutador;
                using (UnidadDeTrabajoU<Reclutador> unidad = new UnidadDeTrabajoU<Reclutador>(context))
                {
                    reclutador = unidad.genericDAL.GetAll();
                }
                return reclutador;
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
                using (UnidadDeTrabajoU<Reclutador> unidad = new UnidadDeTrabajoU<Reclutador>(context))
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

        public bool Update(Reclutador reclutador)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajoU<Reclutador> unidad = new UnidadDeTrabajoU<Reclutador>(context))
                {
                    unidad.genericDAL.Update(reclutador);
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
