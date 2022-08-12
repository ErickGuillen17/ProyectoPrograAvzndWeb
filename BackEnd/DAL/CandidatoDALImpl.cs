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
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Candidato> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Candidato> Find(Expression<Func<Candidato, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Candidato Get(string correo)
        {
            try
            {
                Candidato Candidato;
                using (UnidadDeTrabajoU<Candidato> unidad = new UnidadDeTrabajoU<Candidato>(context))
                {
                    Candidato = unidad.genericDAL.Get(correo);
                }
                return Candidato;
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
                IEnumerable<Candidato> Candidatos;
                using (UnidadDeTrabajo<Candidato> unidad = new UnidadDeTrabajo<Candidato>(context))
                {
                    Candidatos = unidad.genericDAL.GetAll();
                }
                return Candidatos;
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
                using (UnidadDeTrabajo<Candidato> unidad = new UnidadDeTrabajo<Candidato>(context))
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

        public bool Update(Candidato entity)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Candidato> unidad = new UnidadDeTrabajo<Candidato>(context))
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
