using System;
using System.Collections.Generic;

namespace BackEnd.Entities
{
    public partial class CATEGORIA
    {
        public CATEGORIA()
        {
            CANDIDATOs = new HashSet<CANDIDATO>();
            EMPLEOs = new HashSet<EMPLEO>();
        }

        public long ID_CATEGORIA { get; set; }
        public string CATEGORIA_DESCRIPCION { get; set; } = null!;

        public virtual ICollection<CANDIDATO> CANDIDATOs { get; set; }
        public virtual ICollection<EMPLEO> EMPLEOs { get; set; }
    }
}
