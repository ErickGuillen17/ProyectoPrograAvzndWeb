using BackEnd.DAL;
using BackEnd.Entities;
using BackEndAPI.Models;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudController : ControllerBase
    {
        private ISolicitudDAL solicitudDAL;

        public SolicitudController()
        {
            solicitudDAL = new SolicitudDALImpl();
        }


        SolicitudModel Convertir(Solicitud solicitud)
        {

            return new SolicitudModel
            {
                IdSolicitud = solicitud.IdSolicitud,
                IdEmpleo = solicitud.IdEmpleo,
                CorreoCandidato = solicitud.CorreoCandidato,
                FechaSolicitud = solicitud.FechaSolicitud
            };

        }

        Solicitud Convertir(SolicitudModel solicitud)
        {

            return new Solicitud
            {
                IdSolicitud = solicitud.IdSolicitud,
                IdEmpleo = solicitud.IdEmpleo,
                CorreoCandidato = solicitud.CorreoCandidato,
                FechaSolicitud = solicitud.FechaSolicitud
            };

        }
        // GET: api/<SolicitudController>
        [HttpGet("{correo}")]
        [Route("api/solicitud/ConsultarSolicitudes")]
        public JsonResult Get(string correo)
        {
            SolicitudDALImpl solicitudDAL = new SolicitudDALImpl();

            List<Solicitud> solicitudes = solicitudDAL.consultarSolicitudes(correo).ToList();
            List<SolicitudModel> result = new List<SolicitudModel>();

            //List<Solicitud> solicitudes = solicitudDAL.GetAll().ToList();
            //List<SolicitudModel> result = new List<SolicitudModel>();

            foreach (Solicitud solicitud in solicitudes)
            {
                result.Add(Convertir(solicitud));
            }
            return new JsonResult(result);
        }

        // GET api/<SolicitudController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SolicitudController>
        [HttpPost]
        public JsonResult Post([FromBody] SolicitudModel solicitud)
        {
            solicitudDAL.Add(Convertir(solicitud));

            return new JsonResult(Convertir(solicitud));
        }

        // PUT api/<SolicitudController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SolicitudController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Solicitud solicitud = new Solicitud
            {
                IdSolicitud = id
            };
            solicitudDAL.Remove(solicitud);
        }
    }
}
