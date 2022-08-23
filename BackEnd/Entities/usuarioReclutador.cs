using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entities
{
    public partial class usuarioReclutador
    {


        [Display(Name = "Email")]
        public string CorreoReclutador { get; set; } = null!;
        [Display(Name = "Nombre")]
        public string NombreReclutador { get; set; } = null!;
        [Display(Name = "Apellido")]
        public string ApellidoReclutador { get; set; } = null!;
        [Display(Name = "Compañía")]
        public string Compania { get; set; } = null!;
        [Display(Name = "Teléfono")]
        public int TelefonoReclutador { get; set; }
        [Display(Name = "Contraseña")]
        public string contrasena { get; set; }
        [Display(Name = "Confirmación")]
        public string confirmacion { get; set; }

        public long idrol { get; set; }

        public virtual Usuario CorreoReclutadorNavigation { get; set; } = null!;
        public virtual ICollection<Empleo> Empleo { get; set; }
    }
}
