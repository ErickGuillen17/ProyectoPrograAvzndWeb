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
    public class EmpleoDALImpl : IEmpleoDAL
    {

        WorknetContext context;

        public EmpleoDALImpl()
        {
            context = new WorknetContext();

        }

        public bool Add(Empleo entity)
        {

            try
            {
                string sql = "[dbo].[SP_Insertar_Empleo] @pNombreEmpleo,@pRequisitos,@pDescripcionGeneral,@pCompania,@pIdCategoria,@pCorreo,@pEstado,@pExperienciaMinima,@pGradoEstudio";

                var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@pNombreEmpleo",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 100,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = entity.EmpleoNombre
                        },
                        new SqlParameter() {
                            ParameterName = "@pRequisitos",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 1000,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = entity.Requisitos
                        },
                        new SqlParameter() {
                            ParameterName = "@pDescripcionGeneral",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 1000,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = entity.Descripcion
                        },
                        new SqlParameter() {
                            ParameterName = "@pCompania",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 30,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = entity.Compania
                        },
                        new SqlParameter() {
                            ParameterName = "@pIdCategoria",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = entity.IdCategoria
                        },
                        new SqlParameter() {
                            ParameterName = "@pCorreo",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 150,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = entity.CorreoReclutador
                        },
                        new SqlParameter() {
                            ParameterName = "@pEstado",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 20,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = entity.EstadoPuesto
                        },
                        new SqlParameter() {
                            ParameterName = "@pExperienciaMinima",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = entity.ExpMinima
                        },
                        new SqlParameter() {
                            ParameterName = "@pGradoEstudio",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 50,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = entity.GradoEstudio
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

        public void AddRange(IEnumerable<Empleo> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Empleo> Find(Expression<Func<Empleo, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Empleo Get(long id)
        {
            try
            {
                Empleo empleo;
                using (UnidadDeTrabajo<Empleo> unidad = new UnidadDeTrabajo<Empleo>(context))
                {
                    empleo = unidad.genericDAL.Get(id);
                }
                return empleo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Empleo> Get()
        {
            try
            {
                IEnumerable<Empleo> empleos;
                using (UnidadDeTrabajo<Empleo> unidad = new UnidadDeTrabajo<Empleo>(context))
                {
                    empleos = unidad.genericDAL.GetAll();
                }
                return empleos.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Empleo> GetAll()
        {
            try
            {
                IEnumerable<Empleo> empleos;
                using (UnidadDeTrabajo<Empleo> unidad = new UnidadDeTrabajo<Empleo>(context))
                {
                    empleos = unidad.genericDAL.GetAll();
                }
                return empleos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Empleo entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Empleo> unidad = new UnidadDeTrabajo<Empleo>(context))
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

        public void RemoveRange(IEnumerable<Empleo> entities)
        {
            throw new NotImplementedException();
        }

        public Empleo SingleOrDefault(Expression<Func<Empleo, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Empleo empleo)
        {
            try
            {
                string sql = "[dbo].[SP_Actualizar_Empleo] @pEmpleo,@pCompania,@pRequisitos,@pDescripcion,@pExperiencia,@pEstudios,@pEstado,@pCategoria,@pIdPuesto";

                var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@pEmpleo",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 100,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = empleo.EmpleoNombre
                        },
                        new SqlParameter() {
                            ParameterName = "@pCompania",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 100,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = empleo.Compania
                        },
                        new SqlParameter() {
                            ParameterName = "@pRequisitos",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 500,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = empleo.Requisitos

                        },
                        new SqlParameter() {
                            ParameterName = "@pDescripcion",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 500,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = empleo.Descripcion

                        },
                        new SqlParameter() {
                            ParameterName = "@pExperiencia",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = empleo.ExpMinima
                        },
                        new SqlParameter() {
                            ParameterName = "@pEstudios",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 500,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = empleo.GradoEstudio
                        },
                        new SqlParameter() {
                            ParameterName = "@pEstado",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 200,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = empleo.EstadoPuesto
                        },

                        new SqlParameter() {
                            ParameterName = "@pCategoria",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = empleo.IdCategoria
                        },
                        new SqlParameter() {
                            ParameterName = "@pIdPuesto",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = empleo.IdEmpleo
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
    

        public List<Empleo> LlenarEmpleos()
        {
            List<Empleo> empleos = new List<Empleo>();

            try
            {
                List<SP_Llenar_Empleos_Result> result;

                string sql = "[dbo].[SP_Llenar_Empleos]";


                result = context.SP_Llenar_Empleos_Result.FromSqlRaw(sql)
                    .ToListAsync()
                    .Result;

                foreach (var item in result)
                {
                    empleos.Add(new Empleo
                    {
                        IdEmpleo = item.ID_EMPLEO,
                        IdCategoria = item.ID_CATEGORIA,
                        CorreoReclutador = item.CORREO_RECLUTADOR,
                        EmpleoNombre = item.EMPLEO_NOMBRE,
                        ExpMinima = item.EXP_MINIMA,
                        GradoEstudio = item.GRADO_ESTUDIO,
                        Compania = item.COMPANIA,
                        EstadoPuesto = item.ESTADO_PUESTO,
                        Descripcion = item.DESCRIPCION,
                        Requisitos = item.REQUISITOS,
                        CategoriaDescripcion = item.CATEGORIA_DESCRIPCION
                    });
                }


                return empleos;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public List<Empleo> consultarEmpleo(long id)
        {
            List<Empleo> empleos = new List<Empleo>();

            try
            {
                List<SP_Consultar_Empleo_Result> result;

                string sql = "[dbo].[SP_Consultar_Empleo] @pIdEmpleo";

                var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@pIdEmpleo",
                            SqlDbType =  System.Data.SqlDbType.BigInt,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = id
                        }
                };

                result = context.SP_Consultar_Empleo_Result.FromSqlRaw(sql, param)
                    .ToListAsync()
                    .Result;

                foreach (var item in result)
                {
                    empleos.Add(new Empleo
                    {
                        IdEmpleo = item.ID_EMPLEO,
                        IdCategoria = item.ID_CATEGORIA,
                        CorreoReclutador = item.CORREO_RECLUTADOR,
                        EmpleoNombre = item.EMPLEO_NOMBRE,
                        ExpMinima = item.EXP_MINIMA,
                        GradoEstudio = item.GRADO_ESTUDIO,
                        Compania = item.COMPANIA,
                        EstadoPuesto = item.ESTADO_PUESTO,
                        Descripcion = item.DESCRIPCION,
                        Requisitos = item.REQUISITOS,
                        CategoriaDescripcion = item.categoria_descripcion
                    });
                }


                return empleos;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public List<Empleo> EmpleoInteligente(long areaInteres, int exp, string gradoEstudio )
        {
            List<Empleo> empleos = new List<Empleo>();

            try
            {
                List<SP_Empleo_Inteligente_Result> result;

                string sql = "[dbo].[SP_Empleo_Inteligente] @pAreaInteres,@pExp,@pGradoEstudio";

                var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@pAreaInteres",
                            SqlDbType =  System.Data.SqlDbType.BigInt,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = areaInteres
                        },                      
                        new SqlParameter() {
                            ParameterName = "@pExp",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = exp
                        },                      
                        new SqlParameter() {
                            ParameterName = "@pGradoEstudio",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 50,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = gradoEstudio
                        }
                };

                result = context.SP_Empleo_Inteligente_Result.FromSqlRaw(sql, param)
                    .ToListAsync()
                    .Result;

                foreach (var item in result)
                {
                    empleos.Add(new Empleo
                    {
                        IdEmpleo = item.ID_EMPLEO,
                        IdCategoria = item.ID_CATEGORIA,
                        CorreoReclutador = item.CORREO_RECLUTADOR,
                        EmpleoNombre = item.EMPLEO_NOMBRE,
                        ExpMinima = item.EXP_MINIMA,
                        GradoEstudio = item.GRADO_ESTUDIO,
                        Compania = item.COMPANIA,
                        EstadoPuesto = item.ESTADO_PUESTO,
                        Descripcion = item.DESCRIPCION,
                        Requisitos = item.REQUISITOS,
                        CategoriaDescripcion = item.CATEGORIA_DESCRIPCION
                    });
                }


                return empleos;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public List<Empleo> EmpleosPublicados(string correo)
        {
            List<Empleo> empleos = new List<Empleo>();

            try
            {
                List<SP_Empleos_Publicados_Result> result;

                string sql = "[dbo].[SP_Empleos_Publicados] @pCorreo";

                var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@pCorreo",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 150,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = correo
                        }
                };

                result = context.SP_Empleos_Publicados_Result.FromSqlRaw(sql, param)
                    .ToListAsync()
                    .Result;

                foreach (var item in result)
                {
                    empleos.Add(new Empleo
                    {
                        IdEmpleo = item.ID_EMPLEO,
                        IdCategoria = item.ID_CATEGORIA,
                        CorreoReclutador = item.CORREO_RECLUTADOR,
                        EmpleoNombre = item.EMPLEO_NOMBRE,
                        ExpMinima = item.EXP_MINIMA,
                        GradoEstudio = item.GRADO_ESTUDIO,
                        Compania = item.COMPANIA,
                        EstadoPuesto = item.ESTADO_PUESTO,
                        Descripcion = item.DESCRIPCION,
                        Requisitos = item.REQUISITOS,
                        CategoriaDescripcion = item.categoria_descripcion
                    });
                }


                return empleos;
            }
            catch (Exception e)
            {

                throw;
            }
        }



    }
}
