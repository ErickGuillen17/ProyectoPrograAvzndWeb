using System;
using System.Collections.Generic;

namespace BackEnd.Entities
{
    public partial class Candidato
    {
        public Candidato()
        {
            Solicituds = new HashSet<Solicitud>();
        }

        public string NombreCandidato { get; set; } = null!;
        public string ApellidoCandidato { get; set; } = null!;
        public int ExpCandidato { get; set; }
        public string GradoEstudio { get; set; } = null!;
        public int TelefonoCandidato { get; set; }
        public long AreaInteres { get; set; }
        public string CorreoUsuario { get; set; } = null!;

        public virtual Categorium AreaInteresNavigation { get; set; } = null!;
        public virtual Usuario CorreoUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<Solicitud> Solicituds { get; set; }
    }
}
