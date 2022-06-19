using System;
using System.Collections.Generic;

namespace BackEnd.Entities
{
    public partial class ROLE
    {
        public ROLE()
        {
            USUARIOs = new HashSet<USUARIO>();
        }

        public long ID_ROL { get; set; }
        public string NOMBRE_ROL { get; set; } = null!;

        public virtual ICollection<USUARIO> USUARIOs { get; set; }
    }
}
