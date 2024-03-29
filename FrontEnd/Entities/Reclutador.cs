﻿using System;
using System.Collections.Generic;

namespace FrontEnd.Entities
{
    public partial class Reclutador
    {
        public Reclutador()
        {
            Empleo = new HashSet<Empleo>();
        }

        public string CorreoReclutador { get; set; } = null!;
        public string NombreReclutador { get; set; } = null!;
        public string ApellidoReclutador { get; set; } = null!;
        public string Compania { get; set; } = null!;
        public int TelefonoReclutador { get; set; }

        public virtual Usuario CorreoReclutadorNavigation { get; set; } = null!;
        public virtual ICollection<Empleo> Empleo { get; set; }
    }
}
