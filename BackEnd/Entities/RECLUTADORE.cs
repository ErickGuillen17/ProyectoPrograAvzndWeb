using System;
using System.Collections.Generic;

namespace BackEnd.Entities
{
    public partial class RECLUTADORE
    {
        public RECLUTADORE()
        {
            EMPLEOs = new HashSet<EMPLEO>();
        }

        public string CORREO_RECLUTADOR { get; set; } = null!;
        public string NOMBRE_RECLUTADOR { get; set; } = null!;
        public string APELLIDO_RECLUTADOR { get; set; } = null!;
        public string COMPANIA { get; set; } = null!;
        public int TELEFONO_RECLUTADOR { get; set; }

        public virtual USUARIO CORREO_RECLUTADORNavigation { get; set; } = null!;
        public virtual ICollection<EMPLEO> EMPLEOs { get; set; }
    }
}
