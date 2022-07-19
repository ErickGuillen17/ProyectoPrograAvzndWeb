using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class UsuarioDALImpl : IUsuarioDAL
    {

        WorknetContext context;

        public UsuarioDALImpl()
        {
            context = new WorknetContext();

        }

        public bool Add(Usuario entity)
        {
            try
            {
                //sumar o calcular 

                using (UnidadDeTrabajoU<Usuario> unidad = new UnidadDeTrabajoU<Usuario>(context))
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

        public void AddRange(IEnumerable<Usuario> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> Find(Expression<Func<Usuario, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Usuario Get(string UsuarioId)
        {
            try
            {
                Usuario usuario;
                using (UnidadDeTrabajoU<Usuario> unidad = new UnidadDeTrabajoU<Usuario>(context))
                {
                    usuario = unidad.genericDAL.Get(UsuarioId);
                }
                return usuario;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //public Usuario Login(string correo, string password)
        //{
        //    try
        //    {
        //        Usuario usuario;
        //        using (UnidadDeTrabajoU<Usuario> unidad = new UnidadDeTrabajoU<Usuario>(context))
        //        {
        //            usuario = context.Usuario.FromSqlRaw<Usuario>("SP_Buscar_Usuario {0}", correo, password)
        //                .ToList()
        //                .FirstOrDefault();
                    
        //        }
        //        return usuario;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public List<Usuario> Get()
        {
            try
            {
                IEnumerable<Usuario> usuarios;
                using (UnidadDeTrabajoU<Usuario> unidad = new UnidadDeTrabajoU<Usuario>(context))
                {
                    usuarios = unidad.genericDAL.GetAll();
                }
                return usuarios.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Usuario> GetAll()
        {
            try
            {
                IEnumerable<Usuario> usuarios;
                using (UnidadDeTrabajoU<Usuario> unidad = new UnidadDeTrabajoU<Usuario>(context))
                {
                    usuarios = unidad.genericDAL.GetAll();                     
                }
                return usuarios;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Usuario entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajoU<Usuario> unidad = new UnidadDeTrabajoU<Usuario>(context))
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

        public void RemoveRange(IEnumerable<Usuario> entities)
        {
            throw new NotImplementedException();
        }

        public Usuario SingleOrDefault(Expression<Func<Usuario, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Usuario usuario)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajoU<Usuario> unidad = new UnidadDeTrabajoU<Usuario>(context))
                {
                    unidad.genericDAL.Update(usuario);
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
