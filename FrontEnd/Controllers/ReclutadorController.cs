using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class ReclutadorController : Controller
    {
        IReclutadorDAL reclutadorDAL;
        IUsuarioDAL usuarioDAL;


        private Reclutador Convertir(Reclutador reclutador)
        {
            return new Reclutador
            {
                CorreoReclutador = reclutador.CorreoReclutador,
                NombreReclutador = reclutador.NombreReclutador,
                ApellidoReclutador = reclutador.ApellidoReclutador,
                Compania = reclutador.Compania,
                TelefonoReclutador = reclutador.TelefonoReclutador
            };
        }

        #region Lista
        public IActionResult Index()
        {
            IReclutadorDAL reclutadorDAL;

            List<Reclutador> reclutador;
            reclutadorDAL = new ReclutadorDALImpl();
            reclutador = reclutadorDAL.GetAll().ToList();

            return View(reclutador);
        }

        #endregion

        #region Agregar
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Reclutador reclutador)
        {
            reclutadorDAL = new ReclutadorDALImpl();
            reclutadorDAL.Add(reclutador);

            return RedirectToAction("Index","Reclutador");
        }

        #endregion

        #region  Editar


        public IActionResult Edit(string id)
        {
            reclutadorDAL = new ReclutadorDALImpl();
            Reclutador reclutador = reclutadorDAL.Get(id);
            return View(Convertir(reclutador));
        }
        [HttpPost]
        public IActionResult Edit(Reclutador reclutador)
        {
            reclutadorDAL = new ReclutadorDALImpl();

            reclutadorDAL.Update(reclutador);
            return RedirectToAction("Index","Reclutador");
        }

        #endregion


        #region Eliminar
        public IActionResult Delete(string id)
        {
            reclutadorDAL = new ReclutadorDALImpl();
            Reclutador reclutador = reclutadorDAL.Get(id);
            return View(Convertir(reclutador));
        }
        [HttpPost]
        public IActionResult Delete(Reclutador reclutador)
        {
            reclutadorDAL = new ReclutadorDALImpl();

            reclutadorDAL.Remove(reclutador);
            return RedirectToAction("Index","Reclutador");
        }

        #endregion
    }
}
