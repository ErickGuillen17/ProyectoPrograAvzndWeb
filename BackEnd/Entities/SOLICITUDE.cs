using System;
using System.Collections.Generic;

namespace BackEnd.Entities
{
    public partial class SOLICITUDE
    {
        public long ID_SOLICITUD { get; set; }
        public long ID_EMPLEO { get; set; }
        public string CORREO_CANDIDATO { get; set; } = null!;
        public DateTime FECHA_SOLICITUD { get; set; }

        public virtual CANDIDATO CORREO_CANDIDATONavigation { get; set; } = null!;
        public virtual EMPLEO ID_EMPLEONavigation { get; set; } = null!;
    }
}
