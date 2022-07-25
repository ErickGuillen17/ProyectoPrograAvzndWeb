using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entities
{
    public partial class usuarioReclutador
    {

       

        public string CorreoReclutador { get; set; } = null!;
        public string NombreReclutador { get; set; } = null!;
        public string ApellidoReclutador { get; set; } = null!;
        public string Compania { get; set; } = null!;
        public int TelefonoReclutador { get; set; }

        public string contrasena { get; set; }
        public string confirmacion { get; set; }

        public long idrol { get; set; }

        public virtual Usuario CorreoReclutadorNavigation { get; set; } = null!;
        public virtual ICollection<Empleo> Empleo { get; set; }
    }
}
