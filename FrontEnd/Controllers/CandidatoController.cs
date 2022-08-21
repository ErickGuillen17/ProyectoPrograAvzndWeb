using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Controllers
{
    public class CandidatoController : Controller
    {
        ICandidatoDAL candidatoDAL;
        // GET: CandidatoController

        private CandidatoViewModel Convertir(Candidato candidato)
        {
            return new CandidatoViewModel
            {
                NombreCandidato = candidato.NombreCandidato,
                ApellidoCandidato = candidato.ApellidoCandidato,
                ExpCandidato = candidato.ExpCandidato,
                GradoEstudio = candidato.GradoEstudio,
                TelefonoCandidato = candidato.TelefonoCandidato,
                AreaInteres = candidato.AreaInteres,
                CorreoUsuario = candidato.CorreoUsuario,
            };
        }
        public ActionResult listaCandidatosAPI()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/candidato/");
                response.EnsureSuccessStatusCode();
                var content = response.Content.ReadAsStringAsync().Result;
                List<Models.CandidatoViewModel> candidatos = JsonConvert.DeserializeObject<List<Models.CandidatoViewModel>>(content);

                ViewBag.Title = "All Categories";
                return View(candidatos);
            }
            catch (Exception)
            {
                throw;
            }


            //List<Candidato> candidatos;
            //CandidatoDALImpl candidatoDAL = new CandidatoDALImpl();
            //candidatos = candidatoDAL.GetAll().ToList();

            //return View(candidatos);
        }

        // GET: CandidatoController/Details/5
        public IActionResult Details(string id)
        {
            candidatoDAL = new CandidatoDALImpl();
            
            Candidato item = candidatoDAL.Get(id);



            return View(Convertir(item));

        }

        // GET: CandidatoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CandidatoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CandidatoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CandidatoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CandidatoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CandidatoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
