using BackEnd.DAL;
using BackEnd.Entities;
using BackEndAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatoController : ControllerBase
    {
        private ICandidatoDAL candidatoDAL;

        public CandidatoController()
        {
            candidatoDAL = new CandidatoDALImpl();
        }


        CandidatoModel Convertir(Candidato candidato)
        {

            return new CandidatoModel
            {
                NombreCandidato = candidato.NombreCandidato,
                ApellidoCandidato = candidato.ApellidoCandidato,
                ExpCandidato = candidato.ExpCandidato,
                GradoEstudio = candidato.GradoEstudio,
                TelefonoCandidato = candidato.TelefonoCandidato,
                AreaInteres = candidato.AreaInteres,
                CorreoUsuario = candidato.CorreoUsuario,
                CategoriaDescripcion = candidato.CategoriaDescripcion
            };

        }

        Candidato Convertir(CandidatoModel candidato)
        {

            return new Candidato
            {
                NombreCandidato = candidato.NombreCandidato,
                ApellidoCandidato = candidato.ApellidoCandidato,
                ExpCandidato = candidato.ExpCandidato,
                GradoEstudio = candidato.GradoEstudio,
                TelefonoCandidato = candidato.TelefonoCandidato,
                AreaInteres = candidato.AreaInteres,
                CorreoUsuario = candidato.CorreoUsuario,
                CategoriaDescripcion = candidato.CategoriaDescripcion
            };

        }

        

        // GET: api/<CandidatoController>
        [HttpGet]
        public JsonResult Get()
        {
            CandidatoDALImpl candidatoDAL = new CandidatoDALImpl();

            List<Candidato> candidatos = candidatoDAL.LlenarCandidatos().ToList();
            List<CandidatoModel> result = new List<CandidatoModel>();

            foreach (Candidato candidato in candidatos)
            {
                result.Add(Convertir(candidato));
            }
            return new JsonResult(result);
        }

        // GET api/<CandidatoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CandidatoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CandidatoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CandidatoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
