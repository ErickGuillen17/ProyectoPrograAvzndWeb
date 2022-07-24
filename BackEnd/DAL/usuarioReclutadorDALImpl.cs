using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class usuarioReclutadorDALImpl : IusuarioReclutadorDAL
    {
        WorknetContext context;

        public usuarioReclutadorDALImpl()
        {
            context = new WorknetContext();

        }
        public bool Add(usuarioReclutador entity)
        {
            try
            {


                using (UnidadDeTrabajoU<Reclutador> unidad = new UnidadDeTrabajoU<Reclutador>(context))
                {
                    Reclutador obj = new Reclutador();
                    obj.NombreReclutador = entity.NombreReclutador;
                    obj.ApellidoReclutador = entity.ApellidoReclutador;
                    obj.CorreoReclutador = entity.CorreoReclutador;
                    obj.Compania = entity.Compania;
                    obj.TelefonoReclutador = entity.TelefonoReclutador;

                    unidad.genericDAL.Add(obj);
                    return unidad.Complete();
                }

            }
            catch (Exception)
            {

                return false;
            }
        }

        public void AddRange(IEnumerable<usuarioReclutador> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<usuarioReclutador> Find(Expression<Func<usuarioReclutador, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public usuarioReclutador Get(string id)
        {
            try
            {
                usuarioReclutador reclutador;
                using (UnidadDeTrabajoU<usuarioReclutador> unidad = new UnidadDeTrabajoU<usuarioReclutador>(context))
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

        public List<usuarioReclutador> Get()
        {
            try
            {
                IEnumerable<usuarioReclutador> reclutador;
                using (UnidadDeTrabajoU<usuarioReclutador> unidad = new UnidadDeTrabajoU<usuarioReclutador>(context))
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

        public IEnumerable<usuarioReclutador> GetAll()
        {

            try
            {
                IEnumerable<usuarioReclutador> reclutador;
                using (UnidadDeTrabajoU<usuarioReclutador> unidad = new UnidadDeTrabajoU<usuarioReclutador>(context))
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

        public bool Remove(usuarioReclutador entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajoU<usuarioReclutador> unidad = new UnidadDeTrabajoU<usuarioReclutador>(context))
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

        public void RemoveRange(IEnumerable<usuarioReclutador> entities)
        {
            throw new NotImplementedException();
        }

        public usuarioReclutador SingleOrDefault(Expression<Func<usuarioReclutador, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(usuarioReclutador reclutador)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajoU<usuarioReclutador> unidad = new UnidadDeTrabajoU<usuarioReclutador>(context))
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
