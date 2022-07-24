using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entities
{
    public partial class usuarioCandidato
    {
        public string NombreCandidato { get; set; } = null!;
        public string ApellidoCandidato { get; set; } = null!;
        public int ExpCandidato { get; set; }
        public string GradoEstudio { get; set; } = null!;
        public int TelefonoCandidato { get; set; }
        public long AreaInteres { get; set; }
        public string CorreoUsuario { get; set; } = null!;

        public string  contrasena { get; set; }

        public long idrol { get; set; }

        public virtual Categoria AreaInteresNavigation { get; set; } = null!;
        public virtual Usuario CorreoUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<Solicitud> Solicitud { get; set; }
    }
}
