using BackEnd.DAL;
using BackEnd.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class UsuarioController : Controller
    {
        IUsuarioDAL usuarioDAL;
        IusuarioReclutadorDAL reclutadorDAL;
        IusuarioCandidatoDAL candidatoDAL;

        public IActionResult Index()
        {
            IUsuarioDAL usuarioDAL;

            List<Usuario> usuarios;
            usuarioDAL = new UsuarioDALImpl();
            usuarios = usuarioDAL.GetAll().ToList();

            return View(usuarios);
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


        public IActionResult crearReclutador()
        {
            return View();
        }

        [HttpPost]
        public IActionResult crearReclutador(usuarioReclutador reclutador)
        {
            usuarioDAL = new UsuarioDALImpl();
            reclutadorDAL = new usuarioReclutadorDALImpl();
            Usuario usuario = new Usuario();
            usuario.CorreoUsuario = reclutador.CorreoReclutador;
            usuario.Contrasena = reclutador.contrasena;
            usuario.IdRol = 1;
            usuarioDAL.Add(usuario);
            reclutadorDAL.Add(reclutador);



            return RedirectToAction("Index","Usuario");

        }

        public IActionResult crearCandidato()
        {
            return View();
        }

        [HttpPost]
        public IActionResult crearCandidato(usuarioCandidato candidato)
        {
            usuarioDAL = new UsuarioDALImpl();
             candidatoDAL= new usuarioCandidatoDALImpl();
            Usuario usuario = new Usuario();
            usuario.CorreoUsuario = candidato.CorreoUsuario;
            usuario.Contrasena = candidato.contrasena;
            usuario.IdRol = 2;
            usuarioDAL.Add(usuario);
            candidatoDAL.Add(candidato);



            return RedirectToAction("Index", "Usuario");

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

        public IActionResult Login()
        {
            return View();
        }     
        
        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {

            UsuarioDALImpl usuarioDAL = new UsuarioDALImpl();
            List<Usuario> resultado = usuarioDAL.Login(usuario.CorreoUsuario, usuario.Contrasena);

            if (resultado.Count() >= 1)
            {
                return RedirectToAction("Index", "Empleo");
            }
            else
            {
                return View();
            }

        }
    }
}
