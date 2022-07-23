using BackEnd.Entities;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class ReclutadorViewModel
    {
        [Display(Name = "Correo electrónico")]
        public string CorreoReclutador { get; set; } = null!;
        public string NombreReclutador { get; set; } = null!;
        public string ApellidoReclutador { get; set; } = null!;
        public string Compania { get; set; } = null!;
        public int TelefonoReclutador { get; set; }

        public IEnumerable<Usuario> usuariosList { get; set; }
        public Usuario usuario { get; set; }
    }
}
