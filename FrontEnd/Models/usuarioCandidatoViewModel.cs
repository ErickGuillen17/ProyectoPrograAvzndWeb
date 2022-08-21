using BackEnd.Entities;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class usuarioCandidatoViewModel
    {
        [Required(ErrorMessage = "Debe indicar su nombre")]
        [Display(Name = "Nombre")]
        public string NombreCandidato { get; set; } = null!;
        [Required(ErrorMessage = "Debe indicar su apellido")]
        [Display(Name = "Apellido")]
        public string ApellidoCandidato { get; set; } = null!;
        [Required(ErrorMessage = "Debe indicar sus años de experiencia")]
        [Display(Name = "Años de experiencia")]
        public int ExpCandidato { get; set; }
        [Display(Name = "Grado de estudio")]
        public string GradoEstudio { get; set; } = null!;
        [Required(ErrorMessage = "Debe indicar su número de teléfono")]
        [Display(Name = "Teléfono")]
        public int TelefonoCandidato { get; set; }
        [Display(Name = "Área de interés")]
        public long AreaInteres { get; set; }
        public IEnumerable<Categoria> Categorias { get; set; }
        [Required(ErrorMessage = "Debe indicar su email")]
        [Display(Name = "Email")]
        public string CorreoUsuario { get; set; } = null!;
        [Required(ErrorMessage = "Debe indicar su contraseña")]
        [Display(Name = "Contraseña")]
        public string contrasena { get; set; }
        [Required(ErrorMessage = "Confirme su contraseña")]
        [Display(Name = "Confirmación")]
        public string confirmacion { get; set; }

        public long idrol { get; set; }
    }
}
