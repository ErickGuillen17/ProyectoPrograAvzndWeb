using BackEnd.Entities;
using Microsoft.AspNetCore.Http;
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
    public class SolicitudDALImpl : ISolicitudDAL
    {
        WorknetContext context;
        

        public SolicitudDALImpl()
        {
            context = new WorknetContext();

        }



        public bool Add(Solicitud entity)
        {
            try
            {

                using (UnidadDeTrabajoU<Solicitud> unidad = new UnidadDeTrabajoU<Solicitud>(context))
                {
                    Solicitud obj = new Solicitud();
                    obj.IdSolicitud = entity.IdSolicitud;
                    obj.IdEmpleo = entity.IdEmpleo;
                    obj.CorreoCandidato = entity.CorreoCandidato;
                    obj.FechaSolicitud = DateTime.Now;
                  


                    unidad.genericDAL.Add(obj);
                    return unidad.Complete();
                }

            }
            catch (Exception)
            {

                return false;
            }
        }

        public void AddRange(IEnumerable<Solicitud> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Solicitud> Find(Expression<Func<Solicitud, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Solicitud Get(string correo)
        {
            try
            {
                Solicitud solicitud;
                using (UnidadDeTrabajoU<Solicitud> unidad = new UnidadDeTrabajoU<Solicitud>(context))
                {
                    solicitud = unidad.genericDAL.Get(correo);
                }
                return solicitud;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Solicitud> GetAll()
        {
            try
            {
                IEnumerable<Solicitud> solicitud;
                using (UnidadDeTrabajo<Solicitud> unidad = new UnidadDeTrabajo<Solicitud>(context))
                {
                    solicitud = unidad.genericDAL.GetAll();
                }
                return solicitud;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Solicitud entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Solicitud> unidad = new UnidadDeTrabajo<Solicitud>(context))
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

        public void RemoveRange(IEnumerable<Solicitud> entities)
        {
            throw new NotImplementedException();
        }

        public Solicitud SingleOrDefault(Expression<Func<Solicitud, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Solicitud entity)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Solicitud> unidad = new UnidadDeTrabajo<Solicitud>(context))
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

        public List<Solicitud> consultarSolicitudes(string correo)
        {
            List<Solicitud> solicitudes = new List<Solicitud>();

            try
            {
                List<SP_Consultar_Solicitudes_Result> result;

                string sql = "[dbo].[SP_Consultar_Solicitudes] @pCorreo";

                var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@pCorreo",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 50,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = correo
                        }
                };

                result = context.SP_Consultar_Solicitudes_Result.FromSqlRaw(sql, param)
                    .ToListAsync()
                    .Result;

                foreach (var item in result)
                {
                    solicitudes.Add(new Solicitud
                    {
                        IdEmpleo = item.ID_EMPLEO,
                        IdSolicitud = item.ID_SOLICITUD,
                        CorreoCandidato = item.CORREO_CANDIDATO,
                        FechaSolicitud = item.FECHA_SOLICITUD   
                    });
                }


                return solicitudes;
            }
            catch (Exception e)
            {

                throw;
            }
        }

    }
}
