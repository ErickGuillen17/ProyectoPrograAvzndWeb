using FrontEnd.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Controllers
{
    public class SolicitudController : Controller
    {
        // GET: SolicitudController
        public ActionResult listaSolicitudesAPI()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/solicitud/ConsultarSolicitudes/" + HttpContext.Session.GetString("CORREO").ToString());
                response.EnsureSuccessStatusCode();
                var content = response.Content.ReadAsStringAsync().Result;
                List<Models.SolicitudViewModel> solicitudes = JsonConvert.DeserializeObject<List<Models.SolicitudViewModel>>(content);

                ViewBag.Title = "All Categories";
                return View(solicitudes);
            }
            catch (Exception)
            {
                throw;
            }
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
                return RedirectToAction("listaSolicitudesAPI");
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
