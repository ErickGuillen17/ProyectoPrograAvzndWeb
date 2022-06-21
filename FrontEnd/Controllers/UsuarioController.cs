using BackEnd.DAL;
using BackEnd.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class UsuarioController : Controller
    {
        IUsuarioDAL usuarioDAL;

        public IActionResult Index()
        {
            IUsuarioDAL usuarioDAL;

            List<Usuario> categories;
            usuarioDAL = new UsuarioDALImpl();
            categories = usuarioDAL.GetAll().ToList();

            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Usuario usuario)
        {

            usuarioDAL = new UsuarioDALImpl();
            usuarioDAL.Add(usuario);

            return RedirectToAction("Index");
        }

        public IActionResult Details(string id)
        {
            usuarioDAL = new UsuarioDALImpl();
            Usuario usuario = usuarioDAL.Get(id);
            return View(usuario);
        }

        public IActionResult Edit(string id)
        {
            usuarioDAL = new UsuarioDALImpl();
            Usuario usuario = usuarioDAL.Get(id);
            return View(usuario);
        }
        [HttpPost]
        public IActionResult Edit(Usuario usuario)
        {
            usuarioDAL = new UsuarioDALImpl();

            usuarioDAL.Update(usuario);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(string id)
        {
            usuarioDAL = new UsuarioDALImpl();
            Usuario usuario = usuarioDAL.Get(id);
            return View(usuario);
        }
        [HttpPost]
        public IActionResult Delete(Usuario usuario)
        {
            usuarioDAL = new UsuarioDALImpl();

            usuarioDAL.Remove(usuario);
            return RedirectToAction("Index");
        }
    }
}
