using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class EmpleoController : Controller
    {
        IEmpleoDAL empleoDAL;

        private EmpleoViewModel Convertir(Empleo empleo)
        {
            return new EmpleoViewModel
            {
                IdEmpleo = empleo.IdEmpleo,
                IdCategoria = empleo.IdCategoria,
                CorreoReclutador = empleo.CorreoReclutador,
                EmpleoNombre = empleo.EmpleoNombre,
                ExpMinima = empleo.ExpMinima,
                GradoEstudio = empleo.GradoEstudio,
                Compania = empleo.Compania,
                EstadoPuesto = empleo.EstadoPuesto,
                Descripcion = empleo.Descripcion,
                Requisitos = empleo.Requisitos,
                CategoriaDescripcion = empleo.CategoriaDescripcion
            };
        }

        public IActionResult Index()
        {

            List<Empleo> lista;
            EmpleoDALImpl empleoDAL = new EmpleoDALImpl();
            lista = empleoDAL.LlenarEmpleos().ToList();

            List<EmpleoViewModel> empleos = new List<EmpleoViewModel>();

            foreach (Empleo item in lista)
            {
                empleos.Add(Convertir(item));
            }

            return View(empleos);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Empleo empleo)
        {
            IReclutadorDAL reclutador = new ReclutadorDALImpl();


            empleo.CorreoReclutador = HttpContext.Session.GetString("CORREO");
            empleo.Compania = reclutador.Get(empleo.CorreoReclutador).Compania;
            

            empleoDAL = new EmpleoDALImpl();
            empleoDAL.Add(empleo);

            return RedirectToAction("Index");
        }

        public IActionResult Details(long id)
        {
            EmpleoDALImpl empleoDAL = new EmpleoDALImpl();
            List<Empleo> Empleo = empleoDAL.consultarEmpleo(id);
            return View(Convertir(Empleo[0]));
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

        public IActionResult EmpleoInteligente()
        {
            ICandidatoDAL candidato = new CandidatoDALImpl();

            Candidato result = candidato.Get(HttpContext.Session.GetString("CORREO"));

            List<Empleo> lista;
            EmpleoDALImpl empleoDAL = new EmpleoDALImpl();
            lista = empleoDAL.EmpleoInteligente(result.AreaInteres,result.ExpCandidato,result.GradoEstudio).ToList();

            List<EmpleoViewModel> empleos = new List<EmpleoViewModel>();

            foreach (Empleo item in lista)
            {
                empleos.Add(Convertir(item));
            }

            return View("Index", empleos);
        }

        public IActionResult EmpleosPublicados()
        {            
            EmpleoDALImpl empleoDAL = new EmpleoDALImpl();
            List<Empleo> lista = empleoDAL.EmpleosPublicados(HttpContext.Session.GetString("CORREO")).ToList();

            List<EmpleoViewModel> empleos = new List<EmpleoViewModel>();

            foreach (Empleo item in lista)
            {
                empleos.Add(Convertir(item));
            }

            return View("Index", empleos);
        }
    }


}
