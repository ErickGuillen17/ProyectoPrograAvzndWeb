using System;
using System.Collections.Generic;

namespace FrontEnd.Entities
{
    public partial class Rol
    {
        public Rol()
        {
            Usuario = new HashSet<Usuario>();
        }

        public long IdRol { get; set; }
        public string NombreRol { get; set; } = null!;

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
