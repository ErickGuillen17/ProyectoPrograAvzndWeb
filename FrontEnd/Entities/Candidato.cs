using System;
using System.Collections.Generic;

namespace FrontEnd.Entities
{
    public partial class Candidato
    {
        public Candidato()
        {
            Solicitud = new HashSet<Solicitud>();
        }

        public string NombreCandidato { get; set; } = null!;
        public string ApellidoCandidato { get; set; } = null!;
        public int ExpCandidato { get; set; }
        public string GradoEstudio { get; set; } = null!;
        public int TelefonoCandidato { get; set; }
        public long AreaInteres { get; set; }
        public string CorreoUsuario { get; set; } = null!;

        public virtual Categoria AreaInteresNavigation { get; set; } = null!;
        public virtual Usuario CorreoUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<Solicitud> Solicitud { get; set; }
    }
}
