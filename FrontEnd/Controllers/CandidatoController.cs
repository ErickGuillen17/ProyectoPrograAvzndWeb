using BackEnd.DAL;
using BackEnd.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class CandidatoController : Controller
    {
        ICandidatoDAL candidatoDAL;
        // GET: CandidatoController
        public ActionResult listaCandidatos()
        {
            List<Candidato> candidatos;
            CandidatoDALImpl candidatoDAL = new CandidatoDALImpl();
            candidatos = candidatoDAL.GetAll().ToList();

            return View(candidatos);
        }

        // GET: CandidatoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
