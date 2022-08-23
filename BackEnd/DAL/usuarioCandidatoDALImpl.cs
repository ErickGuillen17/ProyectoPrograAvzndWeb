using BackEnd.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
                string sql = "[dbo].[SP_Insertar_Candidato] @pCorreo,@pNombre,@pApellido,@pExp,@pGradoEstudio,@pTelefono,@pAreaInteres";

                var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@pCorreo",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 150,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = entity.CorreoUsuario
                        },
                        new SqlParameter() {
                            ParameterName = "@pNombre",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 100,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = entity.NombreCandidato
                        },
                        new SqlParameter() {
                            ParameterName = "@pApellido",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 100,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = entity.ApellidoCandidato
                        },
                        new SqlParameter() {
                            ParameterName = "@pExp",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = entity.ExpCandidato
                        },
                        new SqlParameter() {
                            ParameterName = "@pGradoEstudio",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 20,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = entity.GradoEstudio
                        },
                        new SqlParameter() {
                            ParameterName = "@pTelefono",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = entity.TelefonoCandidato
                        },
                        new SqlParameter() {
                            ParameterName = "@pAreaInteres",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = entity.AreaInteres
                        }
                };

                context.Database.ExecuteSqlRaw(sql, param);
                context.SaveChanges();

                return true;
            }
            catch (Exception e)
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
