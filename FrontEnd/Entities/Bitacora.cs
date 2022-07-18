using System;
using System.Collections.Generic;

namespace FrontEnd.Entities
{
    public partial class Bitacora
    {
        public DateTime FechaHora { get; set; }
        public string DescripcionError { get; set; } = null!;
        public long CodigoError { get; set; }
        public string Origen { get; set; } = null!;
        public long Consecutivo { get; set; }
        public string CorreoUsuario { get; set; } = null!;

        public virtual Usuario CorreoUsuarioNavigation { get; set; } = null!;
    }
}
