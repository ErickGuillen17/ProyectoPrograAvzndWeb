using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entities
{
    [Keyless]
    public class SP_Buscar_Usuario_Result
    {
        public string CorreoUsuario { get; set; } = null!;
        public string Contrasena { get; set; } = null!;
        public long IdRol { get; set; }
    }

}
