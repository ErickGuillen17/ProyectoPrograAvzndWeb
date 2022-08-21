using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Models
{
    public class CandidatoModel
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debe ingresar un nombre válido")]
        public string NombreCandidato { get; set; } = null!;
        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "Debe ingresar un apellido válido")]
        public string ApellidoCandidato { get; set; } = null!;
        [Display(Name = "Experiencia")]
        public int ExpCandidato { get; set; }
        [Display(Name = "Nivel Académico")]
        [Required(ErrorMessage = "Es obligatorio ingresar el nivel académico")]
        public string GradoEstudio { get; set; } = null!;
        [Display(Name = "Teléfono")]
        public int TelefonoCandidato { get; set; }
        [Display(Name = "Área de interes")]
        public long AreaInteres { get; set; }
        [Display(Name = "Correo electrónico")]
        [Required(ErrorMessage = "Debe ingresar un correo electrónico válido")]
        [EmailAddress]
        public string CorreoUsuario { get; set; } = null!;
    }
}
