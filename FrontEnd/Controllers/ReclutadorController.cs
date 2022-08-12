using BackEnd.DAL;
using BackEnd.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class ReclutadorController : Controller
    {

        IReclutadorDAL reclutadorDAL;
        // GET: ReclutadorController
        public ActionResult listaReclutadores()
        {
            List<Reclutador> reclutadores;
            ReclutadorDALImpl reclutadorDAL = new ReclutadorDALImpl();
            reclutadores = reclutadorDAL.GetAll().ToList();

            return View(reclutadores);
        }

        public ActionResult buscarReclutador(string correo)
        {
            Reclutador reclutador;
            ReclutadorDALImpl reclutadorDAL = new ReclutadorDALImpl();
            reclutador = reclutadorDAL.Get(correo);

            return View(reclutador);
        }

        // GET: ReclutadorController/Details/5
        public ActionResult Details(string correo)
        {
            return View();
        }

        // GET: ReclutadorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReclutadorController/Create
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

        // GET: ReclutadorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReclutadorController/Edit/5
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

        // GET: ReclutadorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReclutadorController/Delete/5
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
