using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class usuarioCandidatoDALImpl : IusuarioCandidatoDAL
    {
        WorknetContext context;

        public usuarioCandidatoDALImpl()
        {
            context = new WorknetContext();

        }
        public bool Add(usuarioCandidato entity)
        {
            try
            {

                using (UnidadDeTrabajoU<Candidato> unidad = new UnidadDeTrabajoU<Candidato>(context))
                {
                    Candidato obj = new Candidato();
                    obj.NombreCandidato = entity.NombreCandidato;
                    obj.ApellidoCandidato = entity.ApellidoCandidato;
                    obj.CorreoUsuario = entity.CorreoUsuario;
                    obj.ExpCandidato = entity.ExpCandidato;
                    obj.TelefonoCandidato = entity.TelefonoCandidato;
                    obj.AreaInteres = entity.AreaInteres;
                    obj.GradoEstudio = entity.GradoEstudio;
                    

                    unidad.genericDAL.Add(obj);
                    return unidad.Complete();
                }

            }
            catch (Exception)
            {

                return false;
            }
        }

        public void AddRange(IEnumerable<usuarioCandidato> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<usuarioCandidato> Find(Expression<Func<usuarioCandidato, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public usuarioCandidato Get(string id)
        {
            try
            {
                usuarioCandidato candidato;
                using (UnidadDeTrabajoU<usuarioCandidato> unidad = new UnidadDeTrabajoU<usuarioCandidato>(context))
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
        public List<usuarioCandidato> Get()
        {
            try
            {
                IEnumerable<usuarioCandidato> candidato;
                using (UnidadDeTrabajoU<usuarioCandidato> unidad = new UnidadDeTrabajoU<usuarioCandidato>(context))
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

        public IEnumerable<usuarioCandidato> GetAll()
        {
            try
            {
                IEnumerable<usuarioCandidato> candidato;
                using (UnidadDeTrabajoU<usuarioCandidato> unidad = new UnidadDeTrabajoU<usuarioCandidato>(context))
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

        public bool Remove(usuarioCandidato entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajoU<usuarioCandidato> unidad = new UnidadDeTrabajoU<usuarioCandidato>(context))
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

        public void RemoveRange(IEnumerable<usuarioCandidato> entities)
        {
            throw new NotImplementedException();
        }

        public usuarioCandidato SingleOrDefault(Expression<Func<usuarioCandidato, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(usuarioCandidato candidato)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajoU<usuarioCandidato> unidad = new UnidadDeTrabajoU<usuarioCandidato>(context))
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
