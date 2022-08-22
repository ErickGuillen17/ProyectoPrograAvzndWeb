using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class EmpleoController : Controller
    {
        IEmpleoDAL empleoDAL;
        ICategoriaDAL categoriaDAL;
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
            ViewBag.Grado = new List<string>() { "Noveno Año", "Bachiller Colegial", "Tecnico medio", "Bachiller Universitario", "Licenciado", "Maestria" };

            EmpleoViewModel empleo = new EmpleoViewModel();
            categoriaDAL = new CategoriaDALImpl();
            empleo.Categorias = categoriaDAL.GetAll();

            return View(empleo);
        }


        [HttpPost]
        public IActionResult Create(Empleo empleo)
        {
            ViewBag.Grado = new List<string>() { "Noveno Año", "Bachiller Colegial", "Tecnico medio", "Bachiller Universitario", "Licenciado", "Maestria" };

            IReclutadorDAL reclutador = new ReclutadorDALImpl();


            empleo.CorreoReclutador = HttpContext.Session.GetString("CORREO");
            empleo.Compania = reclutador.Get(empleo.CorreoReclutador).Compania;
            empleo.EstadoPuesto = "Activo";

            empleoDAL = new EmpleoDALImpl();
            empleoDAL.Add(empleo);

            return RedirectToAction("EmpleosPublicados");
        }

        [HttpPost]
        public IActionResult CrearSolicitud(EmpleoViewModel empleo)
        {
            BackEndAPI.Models.SolicitudModel solicitud = new BackEndAPI.Models.SolicitudModel();
            solicitud.IdEmpleo = empleo.IdEmpleo;
            solicitud.CorreoCandidato = HttpContext.Session.GetString("CORREO");

            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("api/solicitud", solicitud);
            response.EnsureSuccessStatusCode();

            return RedirectToAction("misSolicitudes","Solicitud");
          
        }


        public IActionResult Details(long id)
        {
            EmpleoDALImpl empleoDAL = new EmpleoDALImpl();
            List<Empleo> Empleo = empleoDAL.consultarEmpleo(id);
            return View(Convertir(Empleo[0]));
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Grado = new List<string>() { "Noveno Año", "Bachiller Colegial", "Tecnico medio", "Bachiller Universitario", "Licenciado", "Maestria" };
            ViewBag.Estado = new List<string>() { "Activo","Inactivo" };

            EmpleoDALImpl empleoDAL = new EmpleoDALImpl();
            
            List<Empleo> result = empleoDAL.consultarEmpleo(id);
            EmpleoViewModel empleo = new EmpleoViewModel();
            empleo=Convertir(result[0]);
            categoriaDAL = new CategoriaDALImpl();
            empleo.Categorias = categoriaDAL.GetAll();
            return View(empleo);
        }
        [HttpPost]
        public IActionResult Edit(Empleo Empleo)
        {
            empleoDAL = new EmpleoDALImpl();

            empleoDAL.Update(Empleo);
            return RedirectToAction("EmpleosPublicados");
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
            CandidatoDALImpl candidato = new CandidatoDALImpl();

            List<Candidato> result = candidato.consultarCandidato(HttpContext.Session.GetString("CORREO"));
            
            EmpleoDALImpl empleoDAL = new EmpleoDALImpl();
            List<Empleo> lista = empleoDAL.EmpleoInteligente(result[0].AreaInteres,result[0].ExpCandidato,result[0].GradoEstudio).ToList();

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
