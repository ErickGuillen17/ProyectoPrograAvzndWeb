using BackEnd.DAL;
using BackEnd.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class EmpleoController : Controller
    {
        IEmpleoDAL empleoDAL;

        public IActionResult Index()
        {

            List<Empleo> empleos;
            EmpleoDALImpl empleoDAL = new EmpleoDALImpl();
            empleos = empleoDAL.LlenarEmpleos().ToList();

            return View(empleos);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Empleo Empleo)
        {

            empleoDAL = new EmpleoDALImpl();
            empleoDAL.Add(Empleo);

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            empleoDAL = new EmpleoDALImpl();
            Empleo Empleo = empleoDAL.Get(id);
            return View(Empleo);
        }

        public IActionResult Edit(int id)
        {
            empleoDAL = new EmpleoDALImpl();
            Empleo Empleo = empleoDAL.Get(id);
            return View(Empleo);
        }
        [HttpPost]
        public IActionResult Edit(Empleo Empleo)
        {
            empleoDAL = new EmpleoDALImpl();

            empleoDAL.Update(Empleo);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            empleoDAL = new EmpleoDALImpl();
            Empleo Empleo = empleoDAL.Get(id);
            return View(Empleo);
        }
        [HttpPost]
        public IActionResult Delete(Empleo Empleo)
        {
            empleoDAL = new EmpleoDALImpl();

            empleoDAL.Remove(Empleo);
            return RedirectToAction("Index");
        }
    }
}
