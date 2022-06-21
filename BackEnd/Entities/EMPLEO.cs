using System;
using System.Collections.Generic;

namespace BackEnd.Entities
{
    public partial class Empleo
    {
        public Empleo()
        {
            Solicitud = new HashSet<Solicitud>();
        }

        public long IdEmpleo { get; set; }
        public long IdCategoria { get; set; }
        public int ExpMinima { get; set; }
        public string GradoEstudio { get; set; } = null!;
        public string Compania { get; set; } = null!;
        public string EmpleoNombre { get; set; } = null!;
        public string EstadoPuesto { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string Requisitos { get; set; } = null!;
        public string CorreoReclutador { get; set; } = null!;

        public virtual Reclutador CorreoReclutadorNavigation { get; set; } = null!;
        public virtual Categoria IdCategoriaNavigation { get; set; } = null!;
        public virtual ICollection<Solicitud> Solicitud { get; set; }
    }
}
