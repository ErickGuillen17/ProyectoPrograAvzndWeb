using System;
using System.Collections.Generic;

namespace BackEnd.Entities
{
    public partial class Rol
    {
        public Rol()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public long IdRol { get; set; }
        public string NombreRol { get; set; } = null!;

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
