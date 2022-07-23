using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Entities
{
    public partial class Reclutador
    {
        public Reclutador()
        {
            Empleo = new HashSet<Empleo>();
        }

        [Display(Name = "Correo electrónico")]
        public string CorreoReclutador { get; set; } = null!;
        [Display(Name = "Nombre")]
        public string NombreReclutador { get; set; } = null!;
        [Display(Name = "Apellidos")]
        public string ApellidoReclutador { get; set; } = null!;
        [Display(Name = "Compañia")]
        public string Compania { get; set; } = null!;
        [Display(Name = "Teléfono")]
        public int TelefonoReclutador { get; set; }


        public virtual Usuario CorreoReclutadorNavigation { get; set; } = null!;
        public virtual ICollection<Empleo> Empleo { get; set; }
    }
}
