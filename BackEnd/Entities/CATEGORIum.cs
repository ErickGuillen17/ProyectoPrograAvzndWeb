using System;
using System.Collections.Generic;

namespace BackEnd.Entities
{
    public partial class Categorium
    {
        public Categorium()
        {
            Candidatos = new HashSet<Candidato>();
            Empleos = new HashSet<Empleo>();
        }

        public long IdCategoria { get; set; }
        public string CategoriaDescripcion { get; set; } = null!;

        public virtual ICollection<Candidato> Candidatos { get; set; }
        public virtual ICollection<Empleo> Empleos { get; set; }
    }
}
