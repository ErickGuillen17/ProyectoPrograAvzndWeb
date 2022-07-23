using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class CandidatoDALImpl : ICandidatoDAL
    {
        WorknetContext context;

        public CandidatoDALImpl()
        {
            context = new WorknetContext();

        }
        public bool Add(Candidato entity)
        {
            try
            {

                using (UnidadDeTrabajoU<Candidato> unidad = new UnidadDeTrabajoU<Candidato>(context))
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

        public void AddRange(IEnumerable<Candidato> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Candidato> Find(Expression<Func<Candidato, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Candidato Get(string id)
        {
            try
            {
                Candidato candidato;
                using (UnidadDeTrabajoU<Candidato> unidad = new UnidadDeTrabajoU<Candidato>(context))
                {
                    candidato = unidad.genericDAL.Get(id);
                }
                return candidato;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Candidato> Get()
        {
            try
            {
                IEnumerable<Candidato> candidato;
                using (UnidadDeTrabajoU<Candidato> unidad = new UnidadDeTrabajoU<Candidato>(context))
                {
                    candidato = unidad.genericDAL.GetAll();
                }
                return candidato.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Candidato> GetAll()
        {
            try
            {
                IEnumerable<Candidato> candidato;
                using (UnidadDeTrabajoU<Candidato> unidad = new UnidadDeTrabajoU<Candidato>(context))
                {
                    candidato = unidad.genericDAL.GetAll();
                }
                return candidato;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Candidato entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajoU<Candidato> unidad = new UnidadDeTrabajoU<Candidato>(context))
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

        public void RemoveRange(IEnumerable<Candidato> entities)
        {
            throw new NotImplementedException();
        }

        public Candidato SingleOrDefault(Expression<Func<Candidato, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Candidato candidato)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajoU<Candidato> unidad = new UnidadDeTrabajoU<Candidato>(context))
                {
                    unidad.genericDAL.Update(candidato);
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
