using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class SolicitudViewModel
    {
        public long IdSolicitud { get; set; }
        public long IdEmpleo { get; set; }
        public string CorreoCandidato { get; set; } = null!;
        public DateTime FechaSolicitud { get; set; }
    }
}
