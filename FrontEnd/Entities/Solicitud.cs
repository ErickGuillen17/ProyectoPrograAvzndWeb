using System;
using System.Collections.Generic;

namespace FrontEnd.Entities
{
    public partial class Solicitud
    {
        public long IdSolicitud { get; set; }
        public long IdEmpleo { get; set; }
        public string CorreoCandidato { get; set; } = null!;
        public DateTime FechaSolicitud { get; set; }

        public virtual Candidato CorreoCandidatoNavigation { get; set; } = null!;
        public virtual Empleo IdEmpleoNavigation { get; set; } = null!;
    }
}
