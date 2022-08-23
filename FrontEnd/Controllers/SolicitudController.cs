using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Controllers
{
    public class SolicitudController : Controller
    {
        ISolicitudDAL solicitudDAL;

        private SolicitudViewModel Convertir(Solicitud solicitud)
        {

            return new SolicitudViewModel
            {
                IdSolicitud = solicitud.IdSolicitud,
                IdEmpleo = solicitud.IdEmpleo,
                CorreoCandidato = solicitud.CorreoCandidato,
                FechaSolicitud = solicitud.FechaSolicitud
            };

        }

        // GET: SolicitudController
        //public ActionResult listaSolicitudesAPI()
        //{
        //    try
        //    {
        //        ServiceRepository serviceObj = new ServiceRepository();
        //        HttpResponseMessage response = serviceObj.GetResponse("api/solicitud/ConsultarSolicitudes/" + HttpContext.Session.GetString("CORREO").ToString());
        //        response.EnsureSuccessStatusCode();
        //        var content = response.Content.ReadAsStringAsync().Result;
        //        List<Models.SolicitudViewModel> solicitudes = JsonConvert.DeserializeObject<List<Models.SolicitudViewModel>>(content);

        //        ViewBag.Title = "All Categories";
        //        return View(solicitudes);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        // GET: SolicitudController
        public ActionResult misSolicitudes()
        {

            SolicitudDALImpl solicitudDAL = new SolicitudDALImpl();
            List<Solicitud> resultSolicitudes = solicitudDAL.consultarSolicitudes(HttpContext.Session.GetString("CORREO")).ToList();            
            
            EmpleoDALImpl empleoDAL = new EmpleoDALImpl();
            

            List<SolicitudViewModel> solicitudes = new List<SolicitudViewModel>();

            foreach (Solicitud item in resultSolicitudes)
            {
                solicitudes.Add(Convertir(item));
                List<Empleo> empleo = empleoDAL.consultarEmpleo(item.IdEmpleo).ToList();
                solicitudes[solicitudes.Count - 1].EmpleoNombre = empleo[0].EmpleoNombre;
                solicitudes[solicitudes.Count - 1].EstadoPuesto = empleo[0].EstadoPuesto;
            }

            return View("Index", solicitudes);

        }
        public ActionResult listaSolicitudes()
        {

            SolicitudDALImpl solicitudDAL = new SolicitudDALImpl();
            List<Solicitud> resultSolicitudes = solicitudDAL.consultarSolicitudes(HttpContext.Session.GetString("CORREO")).ToList();

            EmpleoDALImpl empleoDAL = new EmpleoDALImpl();


            List<SolicitudViewModel> solicitudes = new List<SolicitudViewModel>();

            foreach (Solicitud item in resultSolicitudes)
            {
                solicitudes.Add(Convertir(item));
                List<Empleo> empleo = empleoDAL.consultarEmpleo(item.IdEmpleo).ToList();
                solicitudes[solicitudes.Count - 1].EmpleoNombre = empleo[0].EmpleoNombre;
                solicitudes[solicitudes.Count - 1].EstadoPuesto = empleo[0].EstadoPuesto;
            }

            return View("Index", solicitudes);

        }

        // GET: SolicitudController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SolicitudController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SolicitudController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.SolicitudViewModel solicitud, List<IFormFile> upload)
        {
            try
            {

                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/solicitud", solicitud);
                response.EnsureSuccessStatusCode();
                return RedirectToAction("misSolicitudes");
            }
            catch (HttpRequestException
          )
            {
                return RedirectToAction("Error", "Home");
            }

            catch (Exception
            )
            {

                throw;
            }
        }

        // GET: SolicitudController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SolicitudController/Edit/5
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

        // GET: SolicitudController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SolicitudController/Delete/5
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
