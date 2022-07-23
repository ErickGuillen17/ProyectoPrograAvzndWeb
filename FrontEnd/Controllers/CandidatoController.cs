using BackEnd.DAL;
using BackEnd.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class CandidatoController : Controller
    {
        ICandidatoDAL candidatoDAL;


        private Candidato Convertir(Candidato candidato)
        {
            return new Candidato
            {
                NombreCandidato = candidato.NombreCandidato,
                ApellidoCandidato = candidato.ApellidoCandidato,
                ExpCandidato = candidato.ExpCandidato,
                GradoEstudio = candidato.GradoEstudio,
                TelefonoCandidato = candidato.TelefonoCandidato,
                AreaInteres = candidato.AreaInteres,
                CorreoUsuario = candidato.CorreoUsuario
            };
        }

        #region Lista
        public IActionResult Index()
        {
            ICandidatoDAL candidatoDAL;

            List<Candidato> candidato;
            candidatoDAL = new CandidatoDALImpl();
            candidato = candidatoDAL.GetAll().ToList();

            return View(candidato);
        }

        #endregion

        #region Agregar
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Candidato candidato)
        {
            candidatoDAL = new CandidatoDALImpl();
            candidatoDAL.Add(candidato);

            return RedirectToAction("Index", "Candidato");
        }

        #endregion

        #region  Editar


        public IActionResult Edit(string id)
        {
            candidatoDAL = new CandidatoDALImpl();
            Candidato candidato = candidatoDAL.Get(id);
            return View(Convertir(candidato));
        }
        [HttpPost]
        public IActionResult Edit(Candidato candidato)
        {
            candidatoDAL = new CandidatoDALImpl();

            candidatoDAL.Update(candidato);
            return RedirectToAction("Index", "Candidato");
        }

        #endregion


        #region Eliminar
        public IActionResult Delete(string id)
        {
            candidatoDAL = new CandidatoDALImpl();
            Candidato candidato = candidatoDAL.Get(id);
            return View(Convertir(candidato));
        }
        [HttpPost]
        public IActionResult Delete(Candidato candidato)
        {
            candidatoDAL = new CandidatoDALImpl();

            candidatoDAL.Remove(candidato);
            return RedirectToAction("Index", "Candidato");
        }

        #endregion

    }
}
