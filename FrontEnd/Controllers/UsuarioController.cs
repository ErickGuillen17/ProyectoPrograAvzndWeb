using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class UsuarioController : Controller
    {
       
        IUsuarioDAL usuarioDAL;
        IusuarioReclutadorDAL reclutadorDAL;
        IusuarioCandidatoDAL candidatoDAL;
        ICategoriaDAL categoriaDAL;


        public int Session { get; private set; }

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
            if (reclutador.contrasena.Equals(reclutador.confirmacion))
            {
                usuarioDAL = new UsuarioDALImpl();
                reclutadorDAL = new usuarioReclutadorDALImpl();
                Usuario usuario = new Usuario();
                usuario.CorreoUsuario = reclutador.CorreoReclutador;
                usuario.Contrasena = reclutador.contrasena;
                usuario.IdRol = 1;
                usuarioDAL.Add(usuario);
                reclutadorDAL.Add(reclutador);
                return RedirectToAction("Login", "Usuario");
            }
            else
            {
                return View();
            }
        }

        public IActionResult crearCandidato()
        {
            ViewBag.Grado = new List<string>() { "Noveno Año", "Bachiller Colegial", "Técnico Medio", "Bachiller Universitario", "Licenciado", "Maestria" };

            usuarioCandidatoViewModel candidato = new usuarioCandidatoViewModel();
            categoriaDAL = new CategoriaDALImpl();
            candidato.Categorias = categoriaDAL.GetAll();

            return View(candidato);
        }

        [HttpPost]
        public IActionResult crearCandidato(usuarioCandidato candidato)
        {
            ViewBag.Grado = new List<string>() { "Noveno Año", "Bachiller Colegial", "Técnico Medio", "Bachiller Universitario", "Licenciado", "Maestria" };

            if (candidato.contrasena.Equals(candidato.confirmacion))
            {
                usuarioDAL = new UsuarioDALImpl();
                candidatoDAL = new usuarioCandidatoDALImpl();
                Usuario usuario = new Usuario();
                usuario.CorreoUsuario = candidato.CorreoUsuario;
                usuario.Contrasena = candidato.contrasena;
                usuario.IdRol = 2;
                usuarioDAL.Add(usuario);
                candidatoDAL.Add(candidato);
                HttpContext.Session.SetString("ROL", usuario.IdRol.ToString());
                HttpContext.Session.SetString("CORREO", usuario.CorreoUsuario);
                return RedirectToAction("Login", "Usuario");
            }
            else
            {
                return View();
            }
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

                var correo = resultado[0].CorreoUsuario;
                var rol = Convert.ToString(resultado[0].IdRol);
                HttpContext.Session.SetString("CORREO", correo);
                HttpContext.Session.SetString("ROL", rol.ToString());

                if (resultado[0].IdRol == 2)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("EmpleosPublicados", "Empleo");

                }
             }
             else
             {
                return View();
             }

        }

        public IActionResult cerrarSesion()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login", "Usuario");
        }
    }
}
