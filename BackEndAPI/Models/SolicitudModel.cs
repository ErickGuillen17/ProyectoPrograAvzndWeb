using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Models
{
    public class SolicitudModel
    {
        [Key]
        public long IdSolicitud { get; set; }
        public long IdEmpleo { get; set; }
        [Display(Name = "Correo Electrónico")]
        public string CorreoCandidato { get; set; } = null!;
        [Display(Name = "Fecha de Registro")]
        public DateTime FechaSolicitud { get; set; }
    }
}
