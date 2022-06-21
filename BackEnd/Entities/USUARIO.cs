using System;
using System.Collections.Generic;

namespace BackEnd.Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            Bitacora = new HashSet<Bitacora>();
        }

        public string CorreoUsuario { get; set; } = null!;
        public string Contrasena { get; set; } = null!;
        public long IdRol { get; set; }

        public virtual Rol IdRolNavigation { get; set; } = null!;
        public virtual Candidato Candidato { get; set; } = null!;
        public virtual Reclutador Reclutador { get; set; } = null!;
        public virtual ICollection<Bitacora> Bitacora { get; set; }
    }
}
