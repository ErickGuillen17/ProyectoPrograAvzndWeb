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
                Candidato candidato;
                using (UnidadDeTrabajoU<Candidato> unidad = new UnidadDeTrabajoU<Candidato>(context))
                {
                    candidato = unidad.genericDAL.Get(correo);
                }
                return candidato;
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
                IEnumerable<Candidato> candidatos;
                using (UnidadDeTrabajo<Candidato> unidad = new UnidadDeTrabajo<Candidato>(context))
                {
                    candidatos = unidad.genericDAL.GetAll();
                }
                return candidatos;
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

        public List<Candidato> LlenarCandidatos()
        {
            List<Candidato> candidatos = new List<Candidato>();

            try
            {
                List<SP_Llenar_Candidatos_Result> result;

                string sql = "[dbo].[SP_Llenar_Candidatos]";


                result = context.SP_Llenar_Candidatos_Result.FromSqlRaw(sql)
                    .ToListAsync()
                    .Result;

                foreach (var item in result)
                {
                    candidatos.Add(new Candidato
                    {
                        NombreCandidato = item.NOMBRE_CANDIDATO,
                        ApellidoCandidato = item.APELLIDO_CANDIDATO,
                        ExpCandidato = item.EXP_CANDIDATO,
                        GradoEstudio = item.GRADO_ESTUDIO,
                        TelefonoCandidato = item.TELEFONO_CANDIDATO,
                        AreaInteres = item.AREA_INTERES,
                        CorreoUsuario = item.CORREO_USUARIO,
                        CategoriaDescripcion = item.categoria_descripcion
                    });
                }


                return candidatos;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public List<Candidato> consultarCandidato(string correo)
        {
            List<Candidato> candidatos = new List<Candidato>();

            try
            {
                List<SP_Consultar_Candidato_Result> result;

                string sql = "[dbo].[SP_Consultar_Candidato] @pCorreo";

                var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@pCorreo",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 150,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = correo
                        }
                };

                result = context.SP_Consultar_Candidato_Result.FromSqlRaw(sql, param)
                    .ToListAsync()
                    .Result;

                foreach (var item in result)
                {
                    candidatos.Add(new Candidato
                    {
                        NombreCandidato = item.NOMBRE_CANDIDATO,
                        ApellidoCandidato = item.APELLIDO_CANDIDATO,
                        ExpCandidato = item.EXP_CANDIDATO,
                        GradoEstudio = item.GRADO_ESTUDIO,
                        TelefonoCandidato = item.TELEFONO_CANDIDATO,
                        AreaInteres = item.AREA_INTERES,
                        CorreoUsuario = item.CORREO_USUARIO,
                        CategoriaDescripcion = item.categoria_descripcion
                    });
                }


                return candidatos;
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
