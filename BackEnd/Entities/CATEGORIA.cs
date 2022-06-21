using System;
using System.Collections.Generic;

namespace BackEnd.Entities
{
    public partial class Categoria
    {
        public Categoria()
        {
            Candidato = new HashSet<Candidato>();
            Empleo = new HashSet<Empleo>();
        }

        public long IdCategoria { get; set; }
        public string CategoriaDescripcion { get; set; } = null!;

        public virtual ICollection<Candidato> Candidato { get; set; }
        public virtual ICollection<Empleo> Empleo { get; set; }
    }
}
